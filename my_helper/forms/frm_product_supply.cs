using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

			this._args["kwj"] = args["kwj"];
			this._args["mssql_cli"]=args["mssql_cli"];
			this._args["ds"] = args["ds"].f_def(_args["ds"].f_val<DataSet>());

			f_get_product_supply_wd(args);

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

		public t f_get_product_supply_wd(t args)
		{
			DataSet ds=_args["ds"].f_val<DataSet>();
			DataTable tab = dbconn._db.GetDataTable("select * from view_supply_1");
			tab.TableName="tab_supply";
			ds.Tables.Add(tab);

			DataView tab_view = new DataView(tab);
			_args["tab_view"].f_set(tab_view);

			//dg_supply.Columns[0].
			dg_supply.AutoGenerateColumns = false;
			dg_supply.DataSource = tab_view;

			dgc_seller_name.DataPropertyName = "customer_name";
			dgc_num.DataPropertyName = "name";
			dgc_make_dt.DataPropertyName = "dtcre";
			dgc_done_dt.DataPropertyName = "dtdoc";
			dgc_comment.DataPropertyName = "comment";


			return new t();
		}


		private void frm_product_supply_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'kwj_testDataSet.tab_product_supply' table. You can move, or remove it, as needed.
			this.tab_product_supplyTableAdapter.Fill(this.kwj_testDataSet.tab_product_supply);

		}

		private void tabproductsupplyBindingSource_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void dg_supply_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btn_save_Click(object sender, EventArgs e)
		{

		}

		private void txt_filter_KeyUp(object sender, KeyEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string f_val=txt.Text;

			if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Enter)
			{
				return;
			}

			DataSet ds=_args["ds"].f_val<DataSet>();
			DataTable tab=ds.Tables["tab_supply"];

			DataView tab_view = _args["tab_view"].f_val<DataView>();

			tab_view.RowFilter = "name like '%" + f_val + "%' or comment like '%" + f_val + "%'"+
								"dtcre like '%"+f_val+"%'";

			MessageBox.Show(tab.Select(tab_view.RowFilter).Length.ToString());



			if (txt.Text.Length ==0)
			{

				tab_view.RowFilter = "";
			}

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

	}
}
