using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

using kibicom.tlib;
using kibicom.tlib.data_store_cli;

using Atechnology.DBConnections2;

namespace kibicom.my_wd_helper.forms
{
	public partial class frm_product_supply : frm_popup
	{

		public void f_init_wd()
		{
			dbconn.Init("MultipleActiveResultSets=True;database=ecad_venta;server=192.168.1.201;Connection Timeout = 10;uid=sa;Password=82757662=z");

			dbconn._db = new dbconn();

			this._args["ds"].f_set(new DataSet());
		}

		public frm_product_supply()
		{
			InitializeComponent();
		}

		public frm_product_supply(t args): base(args)
		{
			InitializeComponent();

			f_init_wd();

			Owner = args["owner"].f_val<Form>();
			this._args["owner"].f_set(Owner);
			this._args["kwj"] = args["kwj"];
			this._args["mssql_cli"]=args["mssql_cli"];
			this._args["ds"] = args["ds"].f_def(_args["ds"].f_val<DataSet>());
			this._args["o_dr_arr"] = args["o_dr_arr"];

			this._args["o_dr_arr"].f_set(dbconn._db.GetDataTable("select top 1 * from view_orders").Select());

			this._args["tab_supply_changed"].f_set(false);

			//инициализация gridов
			dg_supply.RowTemplate.Height = 30;

			dg_supply.Columns.Add(new DataGridViewImageButtonRevertColumn());
			dg_supply.Columns[dg_supply.Columns.Count - 1].Width = 30;

			dg_supply.Columns.Add(new DataGridViewImageButtonDropColumn());
			dg_supply.Columns[dg_supply.Columns.Count - 1].Width = 30;

			//инициализация gridов
			dg_related_supply.RowTemplate.Height = 30;

			//DataGridViewImageButtonRevertColumn btn = new DataGridViewImageButtonRevertColumn();
			//MessageBox.dg_related_supply.Columns.Add(new DataGridViewImageButtonRevertColumn());
			//dg_related_supply.Columns[dg_related_supply.Columns.Count - 1].Width = 30;
			
			dg_related_supply.Columns.Add(new DataGridViewImageButtonDropColumn());
			dg_related_supply.Columns[dg_related_supply.Columns.Count - 1].Width = 30;

			

			//наполняем таблицы
			//f_get_product_supply_wd(args);
			//f_get_related_supply_wd(args);
			//f_get_supply_customer_wd(args);

		}

		public t f_get_product_supply(t args)
		{
			this._args["kwj"].f_val<t_kwj>().f_get_tab_product_supply(new t()
			{
				{
					"f_done", new t_f<t,t>(delegate (t args1)
					{
						DataTable tab = args1["tab"].f_val<DataTable>();

						DataView tab_view = new DataView(tab);
						
						//dg_supply.Columns[0].
						dgc_seller_name.DataPropertyName="seller_id";

						dg_supply.DataSource = tab_view;

						return new t();
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate (t args1)
					{

						return new t();
					})
				},
			});


			return new t();
		}

		//имеющиеся документы снабжения
		public t f_get_product_supply_wd(t args)
		{
			DataSet ds=_args["ds"].f_val<DataSet>();

			//создаем фильтр для выборки
			string supply_where= f_make_supply_filter();

			string order_by = " order by dtcre ";

			DataTable tab = dbconn._db.GetDataTable("select top 50 * from view_supply_1 where "+supply_where+order_by);
			_args["tab_supply"].f_set(tab);
			tab.TableName="tab_supply";
			//tab.RowChanging += frm_product_supply_RowChanged;

			if (!ds.Tables.Contains("tab_supply"))
			{
				ds.Tables.Add(tab);
			}

			DataView tab_view = new DataView(tab);
			_args["tab_view"].f_set(tab_view);


			//dg_supply.Columns[0].
			dg_supply.AutoGenerateColumns = false;
			dg_supply.DataSource = tab;

			dgc_idsupplydoc.DataPropertyName = "idsupplydoc";
			dgc_idcustomer.DataPropertyName = "idcustomer";
			dgc_seller_name.DataPropertyName = "seller_name";
			dgc_name.DataPropertyName = "name";
			dgc_addstr1.DataPropertyName = "addstr1";
			dgc_dtcre.DataPropertyName = "dtcre";
			dgc_dtdone.DataPropertyName = "dtdone";
			dgc_comment.DataPropertyName = "comment";


			return new t();
		}

		//имеющиеся документы снабжения
		public t f_get_supply_customer_wd(t args)
		{
			DataSet ds = _args["ds"].f_val<DataSet>();

			//создаем фильтр для выборки
			string where = " where idcustomergroup=51 ";

			string order_by = " order by dtcre ";

			DataTable tab = dbconn._db.GetDataTable("select idcustomer, name from customer "+where+order_by);
			_args["tab_customer"].f_set(tab);
			tab.TableName = "tab_customer";
			//tab.RowChanging += frm_product_supply_RowChanged;

			if (!ds.Tables.Contains("tab_customer"))
			{
				ds.Tables.Add(tab);
			}

			//DataView tab_view = new DataView(tab);
			//_args["tab_view"].f_set(tab_view);

			dgc_idcustomer.DataSource = tab;
			dgc_idcustomer.DisplayMember = "name";
			dgc_idcustomer.ValueMember = "idcustomer";


			return new t();
		}


		//связанные документы снабжения
		public t f_get_related_supply_wd(t args)
		{
			DataSet ds = _args["ds"].f_val<DataSet>();
			DataRow[] o_dr_arr = _args["o_dr_arr"].f_val<DataRow[]>();

			//формируем фильтр из id выбранных заказов
			string in_idorder = "";
			foreach (DataRow dr in o_dr_arr)
			{
				in_idorder = t_uti.fjoin(in_idorder, ',', dr["idorder"].ToString());
			}
			//in_idorder = "(" + in_idorder + ")";

			DataTable tab = dbconn._db.GetDataTable
			(
				"select * from view_related_supply_group "+ 
				"where idsupplydoc in "+
				"( select idsupplydoc from view_related_supply_1 where idorder in ("+in_idorder+"))"
			);
			_args["tab_related_supply"].f_set(tab);
			tab.TableName = "tab_related_supply";
			//tab.RowChanging+=tab_related_supply_RowChanged;

			if (!ds.Tables.Contains("tab_related_supply"))
			{
				ds.Tables.Add(tab);
			}

			DataView tab_view = new DataView(tab);
			_args["tab_related_supply_view"].f_set(tab_view);

			//dg_supply.Columns[0].
			dg_related_supply.AutoGenerateColumns = false;
			dg_related_supply.DataSource = tab;

			dgc_rs_iddocrelation.DataPropertyName = "iddocrelation";
			dgc_rs_idsupplydoc.DataPropertyName = "idsupplydoc";
			dgc_rs_seller_name.DataPropertyName = "customer_name";
			dgc_rs_num.DataPropertyName = "name";
			dgc_rs_addstr1.DataPropertyName = "addstr1";
			dgc_rs_make_dt.DataPropertyName = "dtcre";
			dgc_rs_done_dt.DataPropertyName = "dtdone";
			dgc_rs_comment.DataPropertyName = "comment";



			return new t();
		}

		//формирует поисковый фильтр where для всех имеющихся supplydoc
		string f_make_supply_filter()
		{
			string f_val = txt_filter.Text;

			string supply_where="1=0";

			if (f_val != "")
			{
				supply_where += " or name like '%" + f_val + "%' or comment like '%" + f_val + "%'"+
								" or seller_name like '%"+f_val+"%'";
			}
			if (chb_dtcre.Checked)
			{
				supply_where+=" or dtcre = '" + 
								dtp_dtcre_filt.Value.Year.ToString()+ "-"+
								dtp_dtcre_filt.Value.Month.ToString() + "-"+
								dtp_dtcre_filt.Value.Day.ToString() + "'";
			}
			if (chb_dt_done.Checked)
			{
				supply_where += " or dtdone = '" +
								dtp_done_filt.Value.Year.ToString() + "-" +
								dtp_done_filt.Value.Month.ToString() + "-" +
								dtp_done_filt.Value.Day.ToString() + "'";
			}

			if (supply_where == "1=0")
			{
				supply_where = "1=1";
			}

			return supply_where;

			//if(System.Text.RegularExpressions.Regex.Match(f_val, "(\\d\\d.\\d\\d.\\d\\d\\d\\d)")


		}

		t f_add_2_related()
		{
			DataSet ds = _args["ds"].f_val<DataSet>();
			DataTable tab_related_supply = _args["tab_related_supply"].f_val<DataTable>();
			DataView view_related_supply = _args["view_related_supply"].f_val<DataView>();

			DataRow[] o_dr_arr = args["o_dr_arr"].f_val<DataRow[]>();

			foreach (DataGridViewRow dg_r in dg_supply.SelectedRows)
			{
				if (dg_r.Cells["dgc_idsupplydoc"].Value.ToString() == "")
				{
					continue;
				}

				DataRow dr= tab_related_supply.NewRow();

				//int id = dbconn.GetGenId("gen_docrelation");

				//dr["iddocrelation"] = id.ToString();
				dr["idsupplydoc"] = dg_r.Cells["dgc_idsupplydoc"].Value.ToString();
				//dr["idcustomer"] = dg_r.Cells["dgc_idcustomer"].Value.ToString();
				dr["customer_name"] =
					((DataGridViewComboBoxCell)dg_r.Cells["dgc_idcustomer"]).FormattedValue.ToString();
				dr["name"] = dg_r.Cells["dgc_name"].Value.ToString();
				dr["addstr1"] = dg_r.Cells["dgc_addstr1"].Value.ToString();
				dr["dtcre"] = dg_r.Cells["dgc_dtcre"].Value.ToString();
				dr["dtdone"] = dg_r.Cells["dgc_dtdone"].Value.ToString();
				dr["comment"] = dg_r.Cells["dgc_comment"].Value.ToString();

				

				tab_related_supply.Rows.Add(dr);
			}

			return new t();
		}

		t f_save(t args)
		{
			DataSet ds = _args["ds"].f_val<DataSet>();
			DataTable tab_related_supply = _args["tab_related_supply"].f_val<DataTable>();

			DataRow[] o_dr_arr = _args["o_dr_arr"].f_val<DataRow[]>();

			//сохранение связей документов
			//foreach (DataGridViewRow dg_r in dg_related_supply.Rows)
			foreach (DataRow rs_dr in tab_related_supply.Rows)
			{
				foreach (DataRow dr in o_dr_arr)
				{
					if (rs_dr.RowState==DataRowState.Added)
					{
						//запрашиваем из базы строку на данную комбинацию документа снабзения и заказа
						DataRow dr_dr = dbconn._db.GetDataRow
						(
							"select iddocrelation from docrelation where idparentdoc="
							+ rs_dr["idsupplydoc"].ToString() + " and idchilddoc="
							+ dr["idorder"].ToString()
						);

						//если в базе еще нет строки для данной комбинации заказа добавляем ее
						if (dr_dr == null)
						{
							int id = dbconn.GetGenId("gen_docrelation");

							string sql_cmd = "insert docrelation " +
											"(iddocrelation, idparentdoc, idchilddoc, " +
											"iddocappearanceparent, iddocappearancechild)" +
											" values ("
											+ id.ToString() + ","
											+ rs_dr["idsupplydoc"].ToString() + ","
											+ dr["idorder"].ToString() + ","
											+ "4,1)";

							dbconn._db.Exec(sql_cmd);
						}
					}
					if (rs_dr.RowState == DataRowState.Deleted)
					{
						string cmd =
						"update docrelation set deleted=getdate() where "
						+ " deleted is null and iddocappearanceparent=4 and iddocappearancechild=1"
						+ " and idparentdoc=" + rs_dr["idsupplydoc", DataRowVersion.Original].ToString()
						+ " and idchilddoc=" + dr["idorder", DataRowVersion.Original].ToString();

						dbconn._db.Exec(cmd);
					}
				}
			}
			tab_related_supply.AcceptChanges();

			//сохранение документов
			DataTable tab_supply = _args["tab_supply"].f_val<DataTable>();
			foreach (DataRow dr in tab_supply.Rows)
			{
				if (dr.RowState == DataRowState.Added)
				{
					string cmd =
					"insert supplydoc " +
					"(idsupplydoc, name, addstr1, dtcre, dtdoc, idcustomer, comment)" +
					" values ("
					+ t_sql_builder.f_db_val(dr, "idsupplydoc") + ","
					+ t_sql_builder.f_db_val(dr, "name") + ","
					+ t_sql_builder.f_db_val(dr, "addstr1") + ","
					+ t_sql_builder.f_db_val(dr, "dtcre") + ","
					+ t_sql_builder.f_db_val(dr, "dtdone") + ","
					+ t_sql_builder.f_db_val(dr, "idcustomer") + ","
					+ t_sql_builder.f_db_val(dr, "comment") + ")";

					dbconn._db.Exec(cmd);
					dr.AcceptChanges();
				}
				if (dr.RowState == DataRowState.Modified)
				{
					string cmd =
					"update supplydoc set "
					+ " name=" + t_sql_builder.f_db_val(dr, "name") + ","
					+ " addstr1=" + t_sql_builder.f_db_val(dr, "addstr1") + ","
					+ " dtcre="+ t_sql_builder.f_db_val(dr, "dtcre") + ","
					+ " dtdoc="+ t_sql_builder.f_db_val(dr, "dtdone") + ","
					+ " idcustomer=" + t_sql_builder.f_db_val(dr, "idcustomer") + ","
					+ " comment="+ t_sql_builder.f_db_val(dr, "comment")
					+ " where idsupplydoc=" + t_sql_builder.f_db_val(dr, "idsupplydoc");

					dbconn._db.Exec(cmd);
				}
				if (dr.RowState == DataRowState.Deleted)
				{
					string cmd =
					"update supplydoc set deleted=getdate() where idsupplydoc=" 
					+dr["idsupplydoc", DataRowVersion.Original].ToString();

					dbconn._db.Exec(cmd);
				}
			}
			tab_supply.AcceptChanges();

			return new t();
		}

		#region events

		private void frm_product_supply_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'kwj_testDataSet.tab_product_supply' table. You can move, or remove it, as needed.
			this.tab_product_supplyTableAdapter.Fill(this.kwj_testDataSet.tab_product_supply);

		}
		
		private void tabproductsupplyBindingSource_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void txt_filter_KeyUp(object sender, KeyEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string f_val = txt.Text;

			if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Enter)
			{
				return;
			}

			f_get_product_supply_wd(new t());

			/*
			DataSet ds = _args["ds"].f_val<DataSet>();
			DataTable tab = ds.Tables["tab_supply"];

			DataView tab_view = _args["tab_view"].f_val<DataView>();

			tab_view.RowFilter = "name like '%" + f_val + "%' or comment like '%" + f_val + "%'" +
								 "or dtcre = #" + f_val + "#";



			//MessageBox.Show(tab.Select(tab_view.RowFilter).Length.ToString());



			if (txt.Text.Length == 0)
			{

				tab_view.RowFilter = "";
			}
			*/
			//if (last_filter_val == txt_query.Text)
			{
				//show_result = false;
				//return;
			}

			/*
			this._args["eimit"].f_set(false);
			if (!f_check_speed_dial(new t())["emit"].f_bool())
			{
				return;
			}
			*/

			//last_filter_val = txt_query.Text;



			//f_find(new t());
		}
		
		private void btn_add_Click(object sender, EventArgs e)
		{
			DataSet ds = _args["ds"].f_val<DataSet>();
			DataTable tab_related_supply = _args["tab_related_supply"].f_val<DataTable>();
			DataView tab_view = _args["tab_related_supply_view"].f_val<DataView>();

			DataRow[] o_dr_arr = args["o_dr_arr"].f_val<DataRow[]>();

			foreach (DataGridViewRow dg_r in dg_supply.SelectedRows)
			{
				foreach (DataRow dr in o_dr_arr)
				{

					//запрашиваем из базы строку на данную комбинацию документа снабзения и заказа
					DataRow dr_dr=dbconn._db.GetDataRow
					(
						"select iddocrelation from docrelation where idparantdoc="
						+dg_r.Cells["dgc_idsupplydoc"].Value.ToString() + " and idchilddoc="
						+dr["idorder"].ToString()
					);

					//если в базе еще нет строки для данной комбинации заказа добавляем ее
					if (dr_dr == null)
					{
						int id = dbconn.GetGenId("gen_docrelation");

						string sql_cmd = "insert docrelation " +
										"(iddocrelation, idparentdoc, idchilddoc, " +
										"iddocappearanceparent, iddocappearancechild)" +
										" values ("
										+ id.ToString() + ","
										+ dg_r.Cells["dgc_idsupplydoc"].Value.ToString() + ","
										+ dr["idorder"].ToString() + ","
										+ "4,1)";

						dbconn._db.Exec(sql_cmd);
					}
				}
			}

			f_get_related_supply_wd(new t());

		}
		
		private void lbl_dtcre_Click(object sender, EventArgs e)
		{
			chb_dtcre.Checked = !chb_dtcre.Checked;

			f_get_product_supply_wd(new t());
		}

		private void lbl_dt_done_Click(object sender, EventArgs e)
		{
			chb_dt_done.Checked = !chb_dt_done.Checked;

			f_get_product_supply_wd(new t());
		}

		private void dtp_dtcre_filt_ValueChanged(object sender, EventArgs e)
		{
			chb_dtcre.Checked = true;

			f_get_product_supply_wd(new t());

		}

		private void dtp_done_filt_ValueChanged(object sender, EventArgs e)
		{
			chb_dt_done.Checked = true;

			f_get_product_supply_wd(new t());
		}

		private void chb_dtcre_CheckedChanged(object sender, EventArgs e)
		{
			f_get_product_supply_wd(new t());
		}

		private void chb_dt_done_CheckedChanged(object sender, EventArgs e)
		{
			f_get_product_supply_wd(new t());
		}


		private void dg_supply_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dg=(DataGridView)sender;

			f_keep_win_shown(true);

			if (dg.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageButtonRevertColumn))
			{
				f_add_2_related();
				f_save(new t());
			}
			if (dg.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageButtonDropColumn))
			{
				if
				(
					MessageBox.Show
					(
						"Вы хотите удалить это документ?", "Удаление",
						MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button2
					) == DialogResult.Yes
				)
				{
					//запрашиваем из базы строку на данную комбинацию документа снабзения и заказа
					DataRow dr_dr = dbconn._db.GetDataRow
					(
						"select iddocrelation from docrelation where idparentdoc="
						+ dg.Rows[e.RowIndex].Cells["dgc_idsupplydoc"].Value.ToString()
					);
					if (dr_dr != null)
					{
						if
						(
							MessageBox.Show
							(
								"Вы точно хотите удалить это документ? \r\n" +
								"Документ связан с заказами - это плохая идея!",
								"Удаление",
								MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button2
							) == DialogResult.Yes
						)
						{
							((DataTable)dg_supply.DataSource).Select
							(
								"idsupplydoc =" + dg.Rows[e.RowIndex].Cells["dgc_idsupplydoc"].Value.ToString()
							)[0].Delete();

							f_save(new t());
						}
					}
					else
					{
						((DataTable)dg_supply.DataSource).Select
						(
							"idsupplydoc =" + dg.Rows[e.RowIndex].Cells["dgc_idsupplydoc"].Value.ToString()
						)[0].Delete();

						f_save(new t());
					}
				}

				//f_add_2_related();
			}

			f_keep_win_shown(false);
		}

		private void dg_supply_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//f_add_2_related();
		}

		private void dg_supply_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			DataGridView dg=(DataGridView)sender;
			if (e.RowIndex > 1)
			{
				if (dg.Rows[e.RowIndex - 1].Cells["dgc_idsupplydoc"].Value == null||
					dg.Rows[e.RowIndex - 1].Cells["dgc_idsupplydoc"].Value.ToString() == "")
				{
					dg.Rows[e.RowIndex - 1].Cells["dgc_idsupplydoc"].Value = dbconn.GetGenId("gen_supplydoc");
					//MessageBox.Show(e.RowIndex.ToString());
				}
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			f_save(new t());
		}

		private void frm_product_supply_Shown(object sender, EventArgs e)
		{
			//MessageBox.Show("shown");

			//подгружаем данные контекста
			kibicom_mwh_frm_main h_frm = (kibicom_mwh_frm_main)Owner;

			if (h_frm.args["wd"]["active_tab"].f_val().GetType() == typeof(Atechnology.ecad.Document.OrderForm))
			{
				//MessageBox.Show((h_frm.args["wd"]["orderform"]["ds"].f_val() == null).ToString());
				this._args["ds"] = h_frm.args["wd"]["orderform"]["ds"];
				this._args["o_dr_arr"] = h_frm.args["wd"]["orderform"]["o_dr_arr"];
			}

			if (h_frm.args["wd"]["active_tab"].f_val().GetType() == typeof(Atechnology.ecad.Document.OrderItemForm))
			{
				//MessageBox.Show((h_frm.args["wd"]["orderitemform"]["ds"].f_val() == null).ToString());
				DataSet ds = h_frm.args["wd"]["orderitemform"]["ds"].f_val<DataSet>();
				this._args["ds"].f_set(ds);
				this._args["o_dr_arr"].f_set(ds.Tables["orders"].Select());
			}

			//наполняем таблиц
			f_get_product_supply_wd(args);
			f_get_related_supply_wd(args);

			dg_supply.Focus();
		}

		private void dg_supply_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells["dgc_dtcre"].Value = DateTime.Now.ToShortDateString();
			e.Row.Cells["dgc_dtdone"].Value = DateTime.Now.ToShortDateString();
		}

		private void dg_related_supply_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dg = (DataGridView)sender;

			f_keep_win_shown(true);

			if (dg.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageButtonDropColumn))
			{
				if
				(
					MessageBox.Show
					(
						"Вы действительно хотите убрать\r\n этот документ из выбранных заказов?",
						"Удаление",
						MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button2
					) == DialogResult.Yes
				)
				{
					((DataTable)dg_related_supply.DataSource).Select
					(
						"idsupplydoc =" + dg.Rows[e.RowIndex].Cells["dgc_rs_idsupplydoc"].Value.ToString()
					)[0].Delete();

					f_save(new t());
				}

				//f_add_2_related();
			}

			f_keep_win_shown(false);
		}


		#endregion events

		private void dg_supply_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			f_hide();
		}

		private void dg_supply_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			//долбанное событие вызывается при запуске 
			//поэтому проверяем таблицы на наличие изменения и только тогда сохраняем

			DataTable tab_supply = null;
			DataTable tab_related_supply = null;

			if (dg_supply.DataSource != null)
			{
				tab_supply = ((DataTable)dg_supply.DataSource).GetChanges();
			}
			if (dg_related_supply.DataSource != null)
			{
				tab_related_supply = ((DataTable)dg_related_supply.DataSource).GetChanges();
			}
			if (tab_supply != null || tab_related_supply!=null)
			{
				if (_args["tab_related_supply"].f_val() != null && _args["tab_supply"].f_val() != null)
				{
					f_save(new t());
				}
			}
		}

		private void frm_product_supply_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			f_save(new t());
		}

		private void tab_related_supply_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			f_save(new t());
		}

		private void frm_product_supply_VisibleChanged(object sender, EventArgs e)
		{
			//MessageBox.Show("shown");

			//подгружаем данные контекста
			kibicom_mwh_frm_main h_frm = (kibicom_mwh_frm_main)Owner;
			if (!h_frm.args["wd"]["active_tab"].f_is_empty())
			{
				if (h_frm.args["wd"]["active_tab"].f_val().GetType() == typeof(Atechnology.ecad.Document.OrderForm))
				{
					//MessageBox.Show((h_frm.args["wd"]["orderform"]["ds"].f_val() == null).ToString());
					this._args["ds"] = h_frm.args["wd"]["orderform"]["ds"];
					this._args["o_dr_arr"] = h_frm.args["wd"]["orderform"]["o_dr_arr"];
				}

				if (h_frm.args["wd"]["active_tab"].f_val().GetType() == typeof(Atechnology.ecad.Document.OrderItemForm))
				{
					//MessageBox.Show((h_frm.args["wd"]["orderitemform"]["ds"].f_val() == null).ToString());
					DataSet ds = h_frm.args["wd"]["orderitemform"]["ds"].f_val<DataSet>();
					if (ds == null)
					{
						return;
					}
					
					this._args["ds"].f_set(ds);
					this._args["o_dr_arr"].f_set(ds.Tables["orders"].Select());
				}
			}

			//наполняем таблиц
			f_get_product_supply_wd(args);
			f_get_related_supply_wd(args);
			f_get_supply_customer_wd(args);

			dg_supply.Focus();
		}

		private void dg_supply_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.Cancel = true;
		}



	}

	public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell
	{
		private bool _enabled;                // Is the button enabled
		private PushButtonState _buttonState; // What is the button state
		protected Image _buttonImageHot;      // The hot image
		protected Image _buttonImageNormal;   // The normal image
		protected Image _buttonImageDisabled; // The disabled image
		private int _buttonImageOffset;       // The amount of offset or border around the image

		protected DataGridViewImageButtonCell()
		{
			// In my project, buttons are disabled by default
			_enabled = false;
			_buttonState = PushButtonState.Disabled;

			// Changing this value affects the appearance of the image on the button.
			_buttonImageOffset = 2;

			// Call the routine to load the images specific to a column.
			LoadImages();
		}

		// Button Enabled Property
		public bool Enabled
		{
			get
			{
				return _enabled;
			}

			set
			{
				_enabled = value;
				_buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
			}
		}

		// PushButton State Property
		public PushButtonState ButtonState
		{
			get { return _buttonState; }
			set { _buttonState = value; }
		}

		// Image Property
		// Returns the correct image based on the control's state.
		public Image ButtonImage
		{
			get
			{
				switch (_buttonState)
				{
					case PushButtonState.Disabled:
						return _buttonImageDisabled;

					case PushButtonState.Hot:
						return _buttonImageHot;

					case PushButtonState.Normal:
						return _buttonImageNormal;

					case PushButtonState.Pressed:
						return _buttonImageNormal;

					case PushButtonState.Default:
						return _buttonImageNormal;

					default:
						return _buttonImageNormal;
				}
			}
		}

		protected override void Paint(Graphics graphics,
			Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
			DataGridViewElementStates elementState, object value,
			object formattedValue, string errorText,
			DataGridViewCellStyle cellStyle,
			DataGridViewAdvancedBorderStyle advancedBorderStyle,
			DataGridViewPaintParts paintParts)
		{
			//base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

			// Draw the cell background, if specified.
			if ((paintParts & DataGridViewPaintParts.Background) ==
				DataGridViewPaintParts.Background)
			{
				SolidBrush cellBackground =
					new SolidBrush(cellStyle.BackColor);
				graphics.FillRectangle(cellBackground, cellBounds);
				cellBackground.Dispose();
			}

			// Draw the cell borders, if specified.
			if ((paintParts & DataGridViewPaintParts.Border) ==
				DataGridViewPaintParts.Border)
			{
				PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
					advancedBorderStyle);
			}

			// Calculate the area in which to draw the button.
			// Adjusting the following algorithm and values affects
			// how the image will appear on the button.
			Rectangle buttonArea = cellBounds;

			Rectangle buttonAdjustment =
				BorderWidths(advancedBorderStyle);

			buttonArea.X += buttonAdjustment.X;
			buttonArea.Y += buttonAdjustment.Y;
			buttonArea.Height -= buttonAdjustment.Height;
			buttonArea.Width -= buttonAdjustment.Width;

			Rectangle imageArea = new Rectangle(
				buttonArea.X + _buttonImageOffset,
				buttonArea.Y + _buttonImageOffset,
				16,
				16);

			ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState);
		}

		// An abstract method that must be created in each derived class.
		// The images in the derived class will be loaded here.
		public abstract void LoadImages();
	}

	public class DataGridViewImageButtonRevertCell : DataGridViewImageButtonCell
	{
		public override void LoadImages()
		{
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = global::kibicom.my_wd_helper.Properties.Resources.btn_revert_1;
			_buttonImageNormal = global::kibicom.my_wd_helper.Properties.Resources.btn_revert_1;
			_buttonImageDisabled = global::kibicom.my_wd_helper.Properties.Resources.btn_revert_1;

		}
	}

	public class DataGridViewImageButtonRevertColumn : DataGridViewButtonColumn
	{
		public DataGridViewImageButtonRevertColumn()
		{
			this.CellTemplate = new DataGridViewImageButtonRevertCell();
			this.Width = 22;
			//this.Resizable = DataGridViewTriState.False;
		}
	}

	public class DataGridViewImageButtonDropCell : DataGridViewImageButtonCell
	{
		public override void LoadImages()
		{
			// Load the Normal, Hot and Disabled "Delete" images here.
			// Load them from a resource file, local file, hex string, etc.

			_buttonImageHot = global::kibicom.my_wd_helper.Properties.Resources.btn_drop_1;
			_buttonImageNormal = global::kibicom.my_wd_helper.Properties.Resources.btn_drop_1;
			_buttonImageDisabled = global::kibicom.my_wd_helper.Properties.Resources.btn_drop_1;

		}
	}

	public class DataGridViewImageButtonDropColumn : DataGridViewButtonColumn
	{
		public DataGridViewImageButtonDropColumn()
		{
			this.CellTemplate = new DataGridViewImageButtonDropCell();
			this.Width = 22;
			//this.Resizable = DataGridViewTriState.False;
		}
	}

}
