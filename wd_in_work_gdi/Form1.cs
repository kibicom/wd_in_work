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

			kibicom_mwh_frm_main mwh = new kibicom_mwh_frm_main(new t());

			

			wd_josi_num = new t_wd_josi_num(new t()
			{
				{"josi_store", mwh.args["kwj"]["josi_store"]},
				//{"josi_end_point_","https://192.168.1.139/webproj/git/kibicom_venta/index.php"},
				//"josi_end_point","https://192.168.1.193/webproj/git/kibicom_venta/index.php"},
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

		private void button1_Click(object sender, EventArgs e)
		{
			wd_josi_num.f_get_num(new t()
			{
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
			wd_josi_num.f_load_wd_order_ds(new t());

			wd_josi_num.f_put_order(new t()
			{
				{"ds", wd_josi_num["ds"].f_val<DataSet>()}
			});
		}

	}
}
