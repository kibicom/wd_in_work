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

							MessageBox.Show("tick");

							wd_josi_num.f_load_wd_order_to_get_payment(new t())
							.f_call("f_done", new t_f<t, t>(delegate (t args2)
							{
								wd_josi_num.f_get_payment(args2.f_add(true, new t()
								{
									{"rtxt_log",rtxt_log}
								}))
								.f_call("f_done", new t_f<t, t>(delegate (t args3)
								{
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


									string kibicom_order_id = "";
									//получаем декодированный json объект
									Dictionary<string, object> resp_json = 
											args3["resp_json"].f_val<Dictionary<string, object>>();

									t resp_json_t = t.f_dict_2_t(new t() { { "dict", resp_json } });

									//MessageBox.Show("123");
									
									//перебираем заказы
									foreach (t order in (IList<t>)resp_json_t["tab_order"])
									{
										if (!order["tab_payment"].f_is_empty())
										{
											//перебираем платежи по текущему заказу
											foreach (t payment in (IList<t>)order["tab_payment"])
											{
												wd_josi_num.f_put_payment_wd(new t()
												{
													{"payment", payment},
													{"order", order}
												});
											}
										}
									}

									if (args1["resp_str"].f_str().Contains("id"))
									{
										kibicom_order_id = t_dot.f_get_val_from_json_obj
										(
											args1["resp_json"].f_val(),
											"tab_order.0.id"
										).ToString();
									}
									

									return new t();
								}))
								.f_call("f_fail", new t_f<t, t>(delegate(t args3)
								{
									return new t();
								}));

								return new t();
							}))
							.f_call("f_fail", new t_f<t, t>(delegate (t args2)
							{
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


			}), new t(), 1000, 1000);

			
		}

		private void btn_stop_Click(object sender, EventArgs e)
		{

		}
	}
}
