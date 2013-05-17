using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using josi.store;
using kibicom.tlib;

namespace my_helper
{
	public partial class frm_main : Form
	{
		josi_customer frm_customer_finder = new josi_customer(new t());



		public frm_main()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//this.StartPosition = FormStartPosition.Manual;
			//
		}

		private void frm_main_Shown(object sender, EventArgs e)
		{
			//MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString());
			Left = Screen.PrimaryScreen.Bounds.Width - Width;
			Top = 300;
			TopLevel = true;
		}

		private void btn_add_customer_Click(object sender, EventArgs e)
		{
			frm_customer_finder.Top = Top;
			frm_customer_finder.Left = Left - frm_customer_finder.Width;

			if (frm_customer_finder.is_shown)
			{
				//this.btn_add_customer.BackColor = System.Drawing.Color.Transparent;
				//this.btn_add_customer.FlatAppearance.BorderSize = 1;
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);

				frm_customer_finder.is_shown = false;
				frm_customer_finder.Hide();
			}
			else
			{
				//this.btn_add_customer.BackColor = System.Drawing.Color.White;
				//this.btn_add_customer.FlatAppearance.BorderSize = 3;
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Bold);

				frm_customer_finder.is_shown = true;
				frm_customer_finder.Show();
				frm_customer_finder.TopMost = true;
			}
		}

		private void frm_main_Activated(object sender, EventArgs e)
		{
			//this.btn_add_customer.BackColor = System.Drawing.Color.Transparent;
			//this.btn_add_customer.FlatAppearance.BorderSize = 1;
			btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);
		}
	}
}
