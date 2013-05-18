using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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
			
			//callback когда контрагент будет выбран
			frm_customer_finder.args["f_done"]=new t(new t_f<t, t>(delegate(t args)
			{
				t cust=frm_customer_finder.args["customer"];

				btn_add_customer.Text = cust["name"].f_str();

				return new t();
			}));


			if (frm_customer_finder.is_shown)
			{
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);

				frm_customer_finder.is_shown = false;
				frm_customer_finder.Hide();
			}
			else
			{
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Bold);

				frm_customer_finder.is_shown = true;
				frm_customer_finder.Show();
				frm_customer_finder.TopMost = true;
			}
		}

		private void frm_main_Activated(object sender, EventArgs e)
		{
			btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);
		}

		private void frm_main_MouseEnter(object sender, EventArgs e)
		{
			/*
			Height = 600;
			 * */
		}

		private void frm_main_MouseLeave(object sender, EventArgs e)
		{

			/*
			if (Cursor.Position.X < Location.X
				  || Cursor.Position.Y < Location.Y
				  || Cursor.Position.X > Location.X + Width
				  || Cursor.Position.Y > Location.Y + Height)
			{
				//out of scope
				Height = 311;
			}
			*/
			
			
		}
	}
}
