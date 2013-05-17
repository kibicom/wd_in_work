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

namespace customer_info
{
	public partial class customer_info_form : Form
	{
		public t customer =null;

		public customer_info_form()
		{
			InitializeComponent();						
		}

		public customer_info_form(string fio):this()
		{
			textBox1.Text = fio;
			//textBox1.
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
			
			if (textBox1.Text.Length < 5 || textBox1.Text.Length < 5 || CountWords(maskedTextBox1.Text, " ") > 24)
			{				
				MessageBox.Show("Данные в форме некорректны!\nПроверьте правильность ввода!", "Ошибка заполнения полей");
			}
			else
			{
				string telephone = maskedTextBox1.Text;
				customer = new t()
				{
					{"name", textBox1.Text},
					{"phone", maskedTextBox1.Text},
					{"email", textBox2.Text}
				};
				//customer = new t_customer();
				
				//customer.phone = telephone;
				//MessageBox.Show(customer.phone, "Customer_phone");
				//customer.name = textBox1.Text;
				//MessageBox.Show(customer.name, "Customer_name");
				//customer.email = textBox2.Text;
				//MessageBox.Show(customer.email, "Customer_email");
				//if (!isValid(textBox2.Text) || (!isValid(textBox2.Text)))
				//{
				//	MessageBox.Show("Email введён неверно!\nПовторите ввод!", "Ошибочный Email!");
				//}
				//else
				{

					string[] result = telephone.Split(';');
					for (int i = 0; i < result.Length; i++)
					{
						int x = CountWords(result[i], " ");
						if (x < 3)
						{
							customer["phone_arr"].Add(result[i]);
						}
					}
					//MessageBox.Show(customer.phone_arr[0], "Customer_phone_arr");
					Hide();
				}
			}

		}
		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}		
	}
}
