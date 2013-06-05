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
using System.Text.RegularExpressions;
using kibicom.tlib;

namespace kibicom
{
	public partial class address_info_form : Form
	{
		public t customer =null;

		public t args=new t();

		public address_info_form()
		{
			InitializeComponent();						
		}

		public address_info_form(string fio):this()
		{
			txt_address.Text = fio;
			//textBox1.
		}

		public address_info_form(t args)
			: this()
		{
			this.args["item"] = args["item"].f_def(new t());
			txt_address.Text = args["item"]["name"].f_str();
		}			


		private t f_make_cust()
		{

			this.args["item"]["name"].f_set(txt_address.Text);

			args["is_done"].f_set(true);

			//MessageBox.Show(customer.phone_arr[0], "Customer_phone_arr");
			Hide();

			return new t();
		}

		private void txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{

				f_make_cust();

			}
		}

		private void customer_info_form_Activated(object sender, EventArgs e)
		{
			txt_address.SelectionStart = txt_address.Text.Length;
		}

		private void btn_ok(object sender, EventArgs e)
		{
			f_make_cust();

			return;
		}

		private void btn_cancel(object sender, EventArgs e)
		{
			Close();
		}
	
	}
}
