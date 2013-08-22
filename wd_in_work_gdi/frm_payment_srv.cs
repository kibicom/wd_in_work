using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using kibicom.tlib;
using fastJSON;

namespace wd_in_work_gdi
{
	public partial class frm_payment_srv : Form
	{
		t_wd_josi_num wd_josi_num;

		System.Threading.Timer timer = null;

		public frm_payment_srv()
		{
			InitializeComponent();

			wd_josi_num = new t_wd_josi_num(new t()
			{
				//{"josi_store", mwh.args["kwj"]["josi_store"]},
				//{"josi_end_point_","https://192.168.1.139/webproj/git/kibicom_venta/index.php"},
				//{"josi_end_point","https://192.168.1.193/webproj/git/kibicom_venta/index.php"},
				{"josi_end_point","http://kibicom.com/order_store_339/index.php"},
				{"login_name","dnclive"},
				{"req_timeout", 5000},
				{"auth_try_count", 3},
				{"pass","4947"},
				//{"pass","135"},
				{
					"f_done",new t_f<t,t>(delegate(t args1)
					{

						//MessageBox.Show("Залогинились...");

						return new t();
					})
				},
				{
					"f_fail",new t_f<t,t>(delegate(t args1)
					{

						MessageBox.Show("Войти не удалось");

						return new t();
					})
				},
			});

		}

		private void gridControl1_Click(object sender, EventArgs e)
		{

		}

		private void labelControl1_Click(object sender, EventArgs e)
		{

		}

		private void btn_start_Click(object sender, EventArgs e)
		{

			timer = new System.Threading.Timer(new TimerCallback(delegate(object args)
			{
				try
				{
					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{

							timer.Dispose();

							//MessageBox.Show("tick");

							//получаем заказы для которых необходимо получить платежи
							wd_josi_num.f_load_wd_order_to_get_payment(new t())
							.f_call("f_done", new t_f<t, t>(delegate (t args2)
							{
								//получаем платежи из Кибиком по этим заказам
								wd_josi_num.f_get_payment(args2.f_add(true, new t()
								{
									{"rtxt_log",rtxt_log}
								}))
								//Если не удалось
								.f_when("f_fail", new t_f<t, t>(delegate(t args5)
								{

									f_to_txt_log(args5["err"]["message"].f_str());

									return new t();
								}))
								.f_when("f_done", new t_f<t, t>(delegate (t args3)
								{
									/*
									//выводим результат запроса в лог
									if (rtxt_log.InvokeRequired)
									{
										rtxt_log.Invoke(new t_f<t, t>(delegate(t args5)
										{
											rtxt_log.Text +="\r\n\r\n"+ args3["resp_str"].f_str();
											return new t();
										}), args3);
									}
									else
									{
										rtxt_log.Text = args3["resp_str"].f_str();
										return new t();
									}
									*/

									//получаем декодированный json объект из ответа
									Dictionary<string, object> resp_json = 
											args3["resp_json"].f_val<Dictionary<string, object>>();

									//преобразуем в t
									t resp_json_t = t.f_dict_2_t(new t() { { "dict", resp_json } });

									//MessageBox.Show("123");

									//накопитель создаваемых в WD новых платежей для синхронизации guid
									t payments_to_kibicom = new t();

									//int order_i = 0;
									//int payment_i = 0;


									//если не возвращен ни один заказ то нечего синхронизировать...
									if (resp_json_t["tab_order"].Count == 0)
									{
										f_to_txt_log("Нет платежей для синхронизации");
										return new t();
									}
									

									//рекурсивно перебираем заказы и платежи
									//сохраняем или обновляем текущий платеж в WD
									wd_josi_num.f_put_payment_wd(new t()
									{
										//{"payment", payment},
										//{"order", order},
										{"payments_to_kibicom", payments_to_kibicom},
										{"tab_order", resp_json_t["tab_order"]},
										{"order_i", 0},
										{"payment_i", 0}
									})
									//неудача
									.f_when("f_fail", f_each_payment_f_fail)
									//если платеж успешно сохранен/обновлен в WD
									.f_when("f_done", f_each_payment_f_done);

									return new t();
								}));

								return new t();
							}))
							.f_call("f_fail", new t_f<t, t>(delegate (t args2)
							{

								f_to_txt_log("ошибка при получении заказов для синхронизации из WD");

								return new t();
							}));

							

							return new t();

						}), new object[] { new t() });
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}


			}), new t(), 1000, 100000);

			
		}

		public t f_each_payment_f_fail(t args4)
		{
			f_to_txt_log("не смог сохранить платеж в WD");
			return new t();
		}

		public t f_each_payment_f_done(t args4)
		{
			t tab_order = args4["when"]["args"]["tab_order"];
			t payments_to_kibicom =args4["when"]["args"]["payments_to_kibicom"];
			int order_i = args4["when"]["args"]["order_i"].f_int();
			int payment_i = args4["when"]["args"]["payment_i"].f_int();


			//если текущий платеж в текущем заказе не последний
			if (payment_i+1 < tab_order[order_i]["tab_payment"].Count)
			{
				//берем следующий платеж и сохраняем
				wd_josi_num.f_put_payment_wd(new t()
				{
					//{"payment", payment},
					//{"order", order},
					{"payments_to_kibicom", payments_to_kibicom},
					{"tab_order", tab_order},
					{"order_i", order_i},
					{"payment_i", ++payment_i}
				})
					//если очередной платеж успешно сохранен/обновлен в WD
				.f_when("f_done", f_each_payment_f_done)
					/*
					.f_when("f_done", new t_f<t, t>(delegate(t args6)
					{
						args4["when"].f_when
						(
							"f_done",
							args4["when"]["when_f"]["f_done"]["f_arr"][0].f_f()
						);

						return new t();
					}))*/
					//если сохранить не удалось
				.f_when("f_fail", f_each_payment_f_fail);
				/*
				.f_when("f_fail", new t_f<t, t>(delegate(t args6)
				{
					args4["when"].f_when
					(
						"f_fail",
						args4["when"]["when_f"]["f_fail"]["f_arr"][0].f_f()
					);

					return new t();
				}));*/
			}
			else
			{
				//Сохраняем в Кибиком guid для новых только что добавленных 
				//в WD платежей
				wd_josi_num.f_put_payment_kibicom(new t()
				{
					{"tab_payment",payments_to_kibicom}
				})
				//если успешно сохранено в Кибиком
				.f_when("f_done", new t_f<t, t>(delegate(t args5)
				{
					payments_to_kibicom.Clear();
					f_to_txt_log(args5["resp_str"].f_str());

					//если текущий заказ (платежи которого только что были сохранены)
					//не последний (еще есть не обработынные)
					if (order_i + 1 < tab_order.Count)
					{

						//берем следующий заказ и сохраняем его первый платеж
						wd_josi_num.f_put_payment_wd(new t()
						{
							//{"payment", payment},
							//{"order", order},
							{"payments_to_kibicom", payments_to_kibicom},
							{"tab_order", tab_order},
							{"order_i", ++order_i},
							{"payment_i", 0}
						})
							//если очередной платеж успешно сохранен/обновлен в WD
						.f_when("f_done", f_each_payment_f_done)
							//если сохранить не удалось
						.f_when("f_fail", f_each_payment_f_fail);
					}
					else
					{
						f_to_txt_log("Синхронизация успешно выполнена");
					}
					return new t();
				}))
				//Если не удалось
				.f_when("f_fail", new t_f<t, t>(delegate(t args5)
				{

					MessageBox.Show("Ошибка при сохранении в Кибиком");

					return new t();
				}));
			}

			return new t();
		}

		private void btn_stop_Click(object sender, EventArgs e)
		{

		}

		public t f_to_txt_log(string text)
		{
			//выводим результат запроса в лог
			if (rtxt_log.InvokeRequired)
			{
				rtxt_log.Invoke(new t_f<t, t>(delegate(t args5)
				{
					rtxt_log.Text += "\r\n\r\n" + text;
					return new t();
				}), new t(){{"text", text}});
			}
			else
			{
				rtxt_log.Text += "\r\n\r\n"+text;
				//return new t();
			}
			return new t();
		}

	}
}
