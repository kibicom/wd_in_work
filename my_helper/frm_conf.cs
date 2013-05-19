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

		t_kwj kwj_conf = new t_kwj();

		public frm_conf()
		{
			InitializeComponent();
		}

		private void btn_cre_kwj_Click(object sender, EventArgs e)
		{
			SaveFileDialog fsd=new SaveFileDialog();

			fsd.FileName = "kibicom_wd_josi.db";

			fsd.ShowDialog();

			kwj_conf.f_kwj_cre(new t()
			{
				{"file_name", fsd.FileName}
			});
		}

		private void btn_fill_from_kibicom_Click(object sender, EventArgs e)
		{
			SaveFileDialog fsd = new SaveFileDialog();

			fsd.FileName = "kibicom_wd_josi.db";

			fsd.ShowDialog();

			kwj_conf.f_fill_tab_customer(new t()
			{
				{"file_name", fsd.FileName}
			});
		}

		private void btn_fill_tab_address_Click(object sender, EventArgs e)
		{
			SaveFileDialog fsd = new SaveFileDialog();

			fsd.FileName = "kibicom_wd_josi.db";

			fsd.ShowDialog();

			kwj_conf.f_fill_tab_address(new t()
			{
				{"file_name", fsd.FileName}
			});
		}

		
	}
}
