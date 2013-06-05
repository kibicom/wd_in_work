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
	public partial class customer_info_form : Form
	{
		public t customer =null;

		public t args=new t();

		public customer_info_form()
		{
			InitializeComponent();						
		}

		public customer_info_form(string fio):this()
		{
			textBox1.Text = fio;
			//textBox1.
		}

		public customer_info_form(t args): this()
		{
			this.args["item"] = args["item"].f_def(new t());
			textBox1.Text = args["item"]["name"].f_str();
			txt_phone.Text = args["item"]["phone"].f_str();
			textBox2.Text = args["item"]["email"].f_str();
		}

		public static bool isValid(string email)
		{
			string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
			Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);

			if (isMatch.Success)
			{
				return true;
			}
			else
			{
				return false;
			}
		}			

		private void Form1_Load(object sender, EventArgs e)
		{
			maskedTextBox1.Mask = "+7(000) 000-00-00; +7(000) 000-00-00; +7(000) 000-00-00";

			maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
			maskedTextBox1.KeyDown += new KeyEventHandler(maskedTextBox1_KeyDown);
		}
		
		void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
			if (maskedTextBox1.MaskFull)
			{
				toolTip1.ToolTipTitle = "Ввод запрещён";
				toolTip1.Show("Вы не можете вводить больше символов, удалите символы и повторите попытку", maskedTextBox1, 0, -20, 5000);
			}
			else if (e.Position == maskedTextBox1.Mask.Length)
			{
				toolTip1.ToolTipTitle = "Ввод запрещён";
				toolTip1.Show("Вы не можете вводить больше символов, достигнут конец поля ввода", maskedTextBox1, 0, -20, 5000);
			}
			else
			{
				toolTip1.ToolTipTitle = "Ввод запрещён";
				toolTip1.Show("Вы можете вводить только цифры (0-9) в это поле ввода.", maskedTextBox1, 0, -20, 5000);
			}		
		}

		void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			// The balloon tip is visible for five seconds; if the user types any data before it disappears, collapse it ourselves.
			toolTip1.Hide(maskedTextBox1);
		}

		public int CountWords(string s, string s0)
		{
			int count = (s.Length - s.Replace(s0, "").Length) / s0.Length;
			return count;
		}

		private void button2_Click(object sender, EventArgs e)
		{

			f_make_cust();

			return;

		}
		
		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}

		private t f_make_cust()
		{

			string telephone = maskedTextBox1.Text;

			this.args["item"]["name"].f_set(textBox1.Text);
			this.args["item"]["fio"].f_set(textBox1.Text);
			this.args["item"]["phone"].f_set(txt_phone.Text);
			this.args["item"]["email"].f_set(textBox2.Text);


			string[] result = telephone.Split(new char[] { ';', ' ', ',' });
			for (int i = 0; i < result.Length; i++)
			{
				int x = CountWords(result[i], " ");
				if (x < 3)
				{
					this.args["item"]["phone_arr"].Add(result[i]);
				}
			}

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
			textBox1.SelectionStart = textBox1.Text.Length;
		}		
	}
}
