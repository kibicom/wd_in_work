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

namespace kibicom.my_wd_helper.forms
{
	public partial class frm_product_supply : frm_popup
	{

		public frm_product_supply()
		{
			InitializeComponent();
		}

		public frm_product_supply(t args): base(args)
		{
			InitializeComponent();

			this._args["kwj"] = args["kwj"];

			this._args["mssql_cli"]=args["mssql_cli"];

			t mssql_cli=args["mssql_cli"];

			f_get_product_supply(args);

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

	}
}
