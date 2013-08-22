using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frm_wd_print_etk
{
	public partial class frm_wd_print_etk : Form
	{
		public frm_wd_print_etk()
		{
			InitializeComponent();
		}

		private void frm_wd_print_etk_Load(object sender, EventArgs e)
		{
			//chbl_what_print.SetItemChecked(
			int i=0;
			while (i < chbl_what_print.Items.Count)
			{
				chbl_what_print.SetItemChecked(i++, true);
			}
			//chbl_what_print.CheckedItems
			//if (chbl_what_print.SelectedItems[0].GetType().FullName

		}
	}
}
