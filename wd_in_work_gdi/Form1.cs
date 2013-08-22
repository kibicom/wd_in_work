using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using kibicom.tlib;
using fastJSON;
using kibicom.my_wd_helper;

namespace wd_in_work_gdi
{
	public partial class Form1 : Form
	{
		t_wd_josi_num wd_josi_num;

		public Form1()
		{
			InitializeComponent();

			//kibicom_mwh_frm_main mwh = new kibicom_mwh_frm_main(new t());

			wd_josi_num = new t_wd_josi_num(new t()
			{
				//{"josi_store", mwh.args["kwj"]["josi_store"]},
				{"josi_end_point_","https://192.168.1.139/webproj/git/kibicom_venta/index.php"},
				//{"josi_end_point","https://192.168.1.193/webproj/git/kibicom_venta/index.php"},
				//{"josi_end_point","http://kibicom.com/order_store_339/index.php"},
				{"login_name","dnclive"},
				//{"pass","4947"},
				{"pass","135"},
				//{"login_name","Ирина"},
				//{"pass","5623"},
				{"req_timeout", 5000},
				{"auth_try_count", 3},
				{"auth_try_timeout", 1500},
				{"auth_relogin_delay", 100000},
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

		private void button1_Click(object sender, EventArgs e)
		{
			wd_josi_num.f_get_num(new t()
			{
				{
					"josi_store", new t()
					{
						{"login_name", "Виктория"},
						{"pass", "6580"}
					}
				},
				{
					"f_done",new t_f<t,t>(delegate(t args1)
					{
						//если необходима синхронизация потоков
						if (txt_num.InvokeRequired)
						{
							txt_num.Invoke(new t_f<t,t>(delegate(t args2)
							{

								//если ответ null то не удалось связаться с сервером
								//или если результаты показывать не нужно
								if (args2["resp_json"].f_val() == null)
								{
									return null;
								}

								string order_full_num = t_dot.f_get_val_from_json_obj
									(args1["resp_json"].f_val(), "order_full_num").ToString();

								txt_num.Text = order_full_num;

								return new t();
							}), 
							new object[] {args1});
						}

						return new t();
					})
				},
				{
					"f_fail",new t_f<t,t>(delegate(t args1)
					{
						MessageBox.Show("Номер получить не удалось");

						return null;
					})
				}
			});

			/*
			fastJSON.JSON.Instance.ToJSON(new t()
			{

			});
			*/
		}

		private void btn_order_to_kibicom_Click(object sender, EventArgs e)
		{
			wd_josi_num.f_load_wd_order_ds(new t(){{"idorder",txt_idorder.Text}});

			wd_josi_num.f_put_order(new t()
			{
				{"ds", wd_josi_num["ds"].f_val<DataSet>()},
				{"idorder", txt_idorder.Text},
				{
					"f_done", new t_f<t,t>(delegate(t args3)
					{

						f_to_txt_log(args3["resp_str"].f_str());

						//MessageBox.Show("fail");

						//t.f_f("f_fail", args3);

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args3)
					{

						MessageBox.Show("fail");

						MessageBox.Show(args3.f_json()["json_str"].f_str());

						//t.f_f("f_fail", args3);

						return new t();
					})
				}
			});
		}

		private void btn_store_stages_Click(object sender, EventArgs e)
		{
			wd_josi_num.f_load_wd_order_ds(new t(){{"idorder", txt_idorder.Text}});

			wd_josi_num.f_put_order_diraction(new t()
			{
				{"ds", wd_josi_num["ds"].f_val<DataSet>()},
				{"idorder", txt_idorder.Text},
				{
					"f_done", new t_f<t,t>(delegate(t args3)
					{

						f_to_txt_log(args3["resp_str"].f_str());

						//MessageBox.Show("fail");

						//t.f_f("f_fail", args3);

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args3)
					{

						MessageBox.Show("fail");

						MessageBox.Show(args3.f_json()["json_str"].f_str());

						//t.f_f("f_fail", args3);

						return new t();
					})
				}
			});
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
				}), new t() { { "text", text } });
			}
			else
			{
				rtxt_log.Text = text;
				//return new t();
			}
			return new t();
		}

		private void btn_clear_log_Click(object sender, EventArgs e)
		{
			rtxt_log.Text = "";
		}

	}
}
