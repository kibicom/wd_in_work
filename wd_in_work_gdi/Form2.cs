using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using kibicom.tlib;
using fastJSON;
using kibicom.my_wd_helper;
using Atechnology.winDraw.Model;

namespace wd_in_work_gdi
{
	public partial class Form2 : Form
	{

		t_wd_josi_num wd_josi_num;

		public Form2()
		{
			
			
			InitializeComponent();

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

		private void btn_ok_Click(object sender, EventArgs e)
		{

			 DataSet ds =wd_josi_num.f_load_wd_model_ds(new t() { { "idorderitem", txt_idorderitem.Text } })
							["ds"].f_val<DataSet>();


			 DataRow modeldr = ds.Tables["model"].Rows[0];

			 //загружаем конструкцию
			 Atechnology.winDraw.Model.Construction model=null;
			 try
			 {
				 model = new Atechnology.winDraw.Model.Construction();
				 model.Load(Atechnology.Components.ZipArchiver.UnZip2(((byte[])modeldr["class"])));
				 //args.ss.Run(args.db, orderitemdr, model);
			 }
			 catch (Exception ex)
			 {
				 //MessageBox.Show(dr["typ"].ToString());
				 if (modeldr["typ"].ToString() == "0")
				 {
					 //return null;
					 //fCalcMaterial(dr);
					 //continue;
				 }
				 else
				 {
					 //Atechnology.ecad.Calc.SystemScript.RunCalc.AddError
					//	 ("Не возможно получить модель", "позиции", 0, Convert.ToInt32(orderitemdr["numpos"]));
					 //throw new Exception("ошибка расчета позиции");
					 //tdeb.fdeb("___model_loading___Не возможно получить модель! Позиция:" + orderitemdr["numpos"].ToString());
				 }
			 }

			 string otv = "";

			//рама
			int i=0;
			foreach (Atechnology.winDraw.Model.RamaItem ri in model.Rama)
			{
				otv += "\r\nrama." + (i++).ToString() +" "+ ri.Side.ToString();
				int j = 0;
				foreach (List<int> pos_list in ri.Otvetka)
				{
					otv+="\r\n"+j.ToString()+" - ";
					foreach (int pos_i in pos_list)
					{
						otv+=pos_i.ToString()+" | ";
					}
					j++;
				}
			}

			//rtxt_log.Text+="\r\n"+otv;

			otv += "\r\n\r\n\r\n\r\n";

			//импоста
			i = 0;
			foreach (Atechnology.winDraw.Model.Impost imp in model.ImpostList)
			{
				otv += "\r\nimpost." + (i++).ToString() + " " + imp.Position.ToString();
				otv += "\r\notvetka_1";
				int j = 0;
				foreach (List<int> pos_list in imp.Otvetka)
				{
					otv += "\r\n" + j.ToString() + " - ";
					foreach (int pos_i in pos_list)
					{
						otv += pos_i.ToString() + " | ";
					}
					j++;
				}
				otv += "\r\notvetka_2";
				j = 0;
				foreach (List<int> pos_list in imp.Otvetka2)
				{
					otv += "\r\n" + j.ToString() + " - ";
					foreach (int pos_i in pos_list)
					{
						otv += pos_i.ToString() + " | ";
					}
					j++;
				}
			}

			//rtxt_log.Text += "\r\n" + otv;

			otv += "\r\n\r\n\r\n\r\n";

			//створка
			i = 0;
			foreach (Atechnology.winDraw.Model.Stvorka s in model.StvorkaList)
			{
				otv += "\r\nstvorka." + (i++).ToString();
				int k = 0;
				foreach (Atechnology.winDraw.Model.StvorkaItem si in s)
				{
					otv += "\r\nstvorka_item." + (k++).ToString() + " " + si.Side.ToString();
					int j = 0;
					foreach (List<int> pos_list in si.Otvetka)
					{
						otv += "\r\n" + j.ToString() + " - ";
						foreach (int pos_i in pos_list)
						{
							otv += pos_i.ToString() + " | ";
						}
						j++;
					}
				}
			}

			rtxt_log.Text += "\r\n" + otv;

		}
	}
}
