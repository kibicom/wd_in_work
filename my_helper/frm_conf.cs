using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using kibicom.tlib;

namespace my_helper
{
	public partial class frm_conf : Form
	{

		string using_store = "mssql";

		t_kwj kwj_conf = new t_kwj();

		public frm_conf()
		{
			InitializeComponent();

			SaveFileDialog fsd = new SaveFileDialog();
			if (using_store == "sqlite")
			{

				fsd.FileName = "kibicom_wd_josi.db";

				fsd.ShowDialog();
			}

			kwj_conf = new t_kwj(new t()
			{
				{
					"local_store", new t()
					{
						{"store_type", using_store},
						{
							"sqlite_cli", new t()
 							{
								{"file_name", fsd.FileName}
							}
						},
						{
							"mssql_cli", new t()
 							{
								{"server",					"192.168.1.201"},
								{"server_name",				""},
								{"login",					"sa"},
								{"pass",					"82757662=z"},
								{"db_name",					"kwj_test"}
							}
						}
					}
				}
			});
		}

		private void btn_cre_kwj_Click(object sender, EventArgs e)
		{
			if (using_store == "mssql")
			{
				kwj_conf.f_kwj_mssql_cre(new t());
			}
			else if (using_store == "sqlite")
			{
				kwj_conf.f_kwj_sqlite_cre(new t());
			}
		}

		private void btn_fill_from_kibicom_Click(object sender, EventArgs e)
		{

			if (using_store == "mssql")
			{
				kwj_conf.f_fill_tab_customer_mssql(new t());
			}
			else if (using_store == "sqlite")
			{
				kwj_conf.f_fill_tab_customer_sqlite(new t());
			}
		}

		private void btn_fill_tab_address_Click(object sender, EventArgs e)
		{

			if (using_store == "mssql")
			{
				kwj_conf.f_fill_tab_address_mssql(new t());
			}
			else if (using_store == "sqlite")
			{
				kwj_conf.f_fill_tab_address_sqlite(new t());
			}
		}

		
	}
}
