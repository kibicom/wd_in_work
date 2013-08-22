using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using kibicom.tlib;
using kibicom.tlib.data_store_cli;

using Atechnology.DBConnections2;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.ViewInfo;
using System.Reflection;

namespace wd_in_work_gdi
{
	public partial class frm_work_monitor : Form// Atechnology.Components.AtUserControl
	{
		
		System.Threading.Timer timer = null;

		static object locker = new object();
		bool busy = false;

		string idmanufactdoc = "0";

		int last_idmanufactdocsign = 0;
		int last_idtechdocpos = 0;

		bool by_dtmake = true;

		DataTable tab;

		DataTable mf_tab;

		dbconn db;

		public frm_work_monitor()
		{
			dbconn.Init("MultipleActiveResultSets=True;database=ecad_venta;server=192.168.1.201;Connection Timeout = 10;uid=sa;Password=82757662=z");
			db = new dbconn();

			InitializeComponent();
		}

		public frm_work_monitor(dbconn db)
		{
			this.db = db;
			InitializeComponent();
		}

		private void frm_work_monitor_Shown(object sender, EventArgs e)
		{
			

			pgc_1.CustomAppearance += pgc_1_CustomAppearance;
			pgc_1.OptionsView.ShowColumnGrandTotals = false;
			pgc_1.OptionsView.ShowRowGrandTotals = false;

			//по умолчанию берем сегодняшнюю дату
			de_dtmake.EditValue = DateTime.Now;

			//запрашиваем задания на текущее число
			//f_load_mf_by_dtmake((DateTime)de_dtmake.EditValue);

			//gc_main.MainView.row

			f_go();
		}

		//раскрашиваем ячейки в зависимости от статуса заказа
		void pgc_1_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
		{

			try
			{

				if (e.RowField == null || e.ColumnField == null)
				{
					return;
				}

				string item_i = pgc_1.GetFieldValue(e.RowField, e.RowFieldIndex).ToString();
				string posgroup = pgc_1.GetFieldValue(e.ColumnField, e.ColumnFieldIndex).ToString();

				//MessageBox.Show(posgroup+"   "+item_i);

				DataRow[] dr_arr = tab.Select("item_i =" + item_i + " and posgroup=" + posgroup);

				if (dr_arr.Length == 0)
				{
					return;
				}

				e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#c03");
				e.Appearance.ForeColor = Color.White;
				//e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);

				if (dr_arr[0]["assembly_check"].ToString() == "1")
				{
					e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#ff0");
					e.Appearance.ForeColor = Color.Black;
					
				}

				if (dr_arr[0]["otk_check"].ToString() == "OK")
				{
					e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#690");
					e.Appearance.ForeColor = Color.White;
				}

				if (dr_arr[0]["otk_check"].ToString().Contains("DEF"))
				{
					e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#099");
					e.Appearance.ForeColor = Color.White;
				}
			}
			catch (Exception ex)
			{
				
			}

		}

		//запуск периодического обновления
		void f_go()
		{
			timer = new System.Threading.Timer(new TimerCallback(delegate(object args)
			{
				//timer.Dispose();
				try
				{
					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{


							f_upd_all(false);

							return new t();

						}), new object[] { new t() });
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}),new t(), 1000, 3000);
		}

		//обвновляем бар с заданиями и текущее задание
		void f_upd_all(bool need)
		{

			lock (locker)
			{
				if (busy)
				{
					return;
				}
				else
				{
					busy = true;
				}
			}


			System.Threading.Timer tm = null;
			tm = new System.Threading.Timer(new TimerCallback(delegate(object args)
			{
				tm.Dispose();
				try
				{
					if (!need)
					{
						bool need_update = false;

						int current_id = 0;
						db.ExecScalar("select num from generator where name like 'gen_manufactdocsign'", 0, out current_id);

						if (last_idmanufactdocsign != current_id)
						{
							need_update = true;
							last_idmanufactdocsign = current_id;
						}
						else
						{
							db.ExecScalar("select num from generator where name like 'gen_techdocpos'", 0, out current_id);

							if (last_idtechdocpos != current_id)
							{
								need_update = true;
								last_idtechdocpos = current_id;
							}

						}

						if (!need_update)
						{
							//освобождаем ресурс
							busy = false;

							return;
						}
					}

					if (pic_loader.InvokeRequired)
					{
						pic_loader.Invoke(new t_f<t, t>(delegate(t args1)
						{
							pic_loader.Visible = true;
							return new t();
						}), new object[] { new t() });
					}
					else
					{
						pic_loader.Visible = true;
					}


					tab = db.GetDataTable("select * from f_work_flow_by_mf(" + idmanufactdoc + ")");

					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{

							//DataTable tab = new DataTable("tab");

							//string cmd = "select * from view_work_flow";

							//db.adapter.Fill(tab);



							//MessageBox.Show( tab.Rows.Count.ToString());

							//gc_main.DataSource = tab;


							//GridView main_view = gc_main.MainView as GridView;
							//main_view.Columns["posgroup"].GroupIndex = 0;
							//main_view.ExpandAllGroups();

							//pivot

							pgc_1.DataSource = tab;

							pgc_1.BestFit();

							int columnCount = pgc_1.Cells.ColumnCount;
							PropertyInfo fi = typeof(PivotGridControl).GetProperty("ViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
							PivotGridViewInfo viewInfo = (PivotGridViewInfo)fi.GetValue(pgc_1, null);
							int bestWidth = viewInfo.ColumnHeaders.Bounds.Width / columnCount;
							foreach (PivotGridField field in pgc_1.Fields)
								if (field.Area == PivotArea.ColumnArea)
									field.Width = bestWidth;

							//обновляем панель заданий
							f_update_mf_bar((DateTime)de_dtmake.EditValue);

							return new t();

						}), new object[] { new t() });
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}), new t(), 100, 100000000);
			
		}

		//при изменении даты изготовления
		private void de_dtmake_EditValueChanged(object sender, EventArgs e)
		{

			by_dtmake = true;

			//очищаем бар
			fnl_mf.Controls.Clear();

			//ощищаем строки грида
			//tab.Rows.Clear();

			//обновляем все (асинхронно)
			f_upd_all(true);
			
		}

		//при изменении даты вывоза
		private void de_dtout_EditValueChanged(object sender, EventArgs e)
		{
			by_dtmake = false;

			//очищаем бар
			fnl_mf.Controls.Clear();
			
			//ощищаем строки грида
			//tab.Rows.Clear();

			//обновляем все (асинхронно)
			f_upd_all(true);
		}

		//при выборе задания для отображения в гриде
		void f_mf_click(t args)
		{

			//меняем визуально включенный
			mf_bar_item mf_bi = args["self"].f_val<mf_bar_item>();
			string idmanufactdoc = args["idmanufactdoc"].f_str();

			foreach (mf_bar_item mf_b_i in fnl_mf.Controls)
			{
				mf_b_i.tlp_mf_1.BackColor = System.Drawing.SystemColors.Control;
				mf_b_i.ForeColor = Color.Black;
			}

			mf_bi.tlp_mf_1.BackColor = Color.SeaGreen;
			mf_bi.ForeColor = Color.White;

			//меняем текущее отображаемое в гриде задание
			this.idmanufactdoc = idmanufactdoc;

			//MessageBox.Show(idmanufactdoc);

			//обновляем все асинхронно
			f_upd_all(true);

		}

		//обновляет прогрессбары
		void f_update_mf_bar(DateTime dtmake)
		{
			string dt1="";
			if (by_dtmake)
			{
				dt1 = ((DateTime)de_dtmake.EditValue).ToString("yyyy-MM-dd");
			}
			else
			{
				dt1 = ((DateTime)de_dtout.EditValue).ToString("yyyy-MM-dd");
			}


			System.Threading.Timer tm = null;
			tm = new System.Threading.Timer(new TimerCallback(delegate(object args2)
			{
				tm.Dispose();
				try
				{
					if (by_dtmake)
					{
						mf_tab = db.GetDataTable("select * from f_mf_by_dtmake('" + dt1 + "', null)");
					}
					else
					{
						mf_tab = db.GetDataTable("select * from f_mf_by_dtout('" + dt1 + "', null)");
					}

					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{
							//если бар пустой выбрали новую дату заполняем
							if (fnl_mf.Controls.Count == 0)
							{
								foreach (DataRow dr in mf_tab.Rows)
								{
									mf_bar_item mf_f_i = new mf_bar_item(dr, f_mf_click);
									//mf_f_i.Click += mf_f_i_Click;
									fnl_mf.Controls.Add(mf_f_i);
								}
							}
							else //иначе обновляем
							{

								int i = 0;
								foreach (DataRow dr in mf_tab.Rows)
								{
									((mf_bar_item)fnl_mf.Controls[i++]).f_pb_inc(dr);
								}
							}

							//освобождаем ресурс
							busy = false;

							//убираем лоадер
							pic_loader.Visible = false;

							return new t();

						}), new object[] { new t() });
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			}), new t(), 100, 100000000);

			

		}



	}
}
