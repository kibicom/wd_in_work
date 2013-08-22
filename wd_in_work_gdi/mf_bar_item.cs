using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using kibicom.tlib;

namespace wd_in_work_gdi
{
	public partial class mf_bar_item : UserControl
	{
		public string idmanufactdoc = "0";
		Action<t> f_on_click;
		public mf_bar_item()
		{
			InitializeComponent();
		}

		public mf_bar_item(DataRow dr, Action<t> f_on_click)
		{
			InitializeComponent();

			this.f_on_click = f_on_click;

			if (dr == null) return;
			lbl_mf_name_1.Text = dr["mf_name"].ToString();

			f_pb_inc(dr);

			idmanufactdoc = dr["idmanufactdoc"].ToString();

		}

		public void f_pb_inc(DataRow dr)
		{
			lbl_mf_counter.Text =  dr["oi_qu"].ToString();
			lbl_assembly.Text = dr["oi_assembly_qu"].ToString();
			lbl_otk.Text = dr["oi_otk_qu"].ToString();

			pb_mf_assembly.Properties.Maximum = int.Parse(dr["oi_qu"].ToString());
			pb_mf_assembly.Position=int.Parse(dr["oi_assembly_qu"].ToString());
			
			pb_mf_otk.Properties.Maximum = int.Parse(dr["oi_qu"].ToString());
			pb_mf_otk.Position = int.Parse(dr["oi_otk_qu"].ToString());
		}

		private void mf_bar_item_Click(object sender, EventArgs e)
		{
			f_on_click(new t(){{"self",this},{"idmanufactdoc",idmanufactdoc}});
			base.RaiseMouseEvent(this, (MouseEventArgs)e );
		}

		private void lbl_otk_Click(object sender, EventArgs e)
		{

		}

		private void pb_mf_otk_EditValueChanged(object sender, EventArgs e)
		{

		}
	}
}
