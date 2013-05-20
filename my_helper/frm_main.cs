using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
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
		frm_finder_customer frm_customer_finder;
		frm_finder_address frm_address_finder;
		System.Threading.Timer timer = null;

		public Atechnology.ecad.Document.OrderItemForm oif;
		public Atechnology.ecad.Document.Classes.OrderClass order;

		bool is_show_blocked=false;

		public t args = new t();

		//используется для тестов
		public frm_main()
		{
			InitializeComponent();

			this.args["top"].f_set(220);
			this.args["right_offset"].f_set(30);

			frm_customer_finder = new frm_finder_customer(new t());

			frm_address_finder = new frm_finder_address(new t());

		}

		//production конструктор
		public frm_main(t args)//:this()
		{
			InitializeComponent();

			this.args["f_select_customer"] = args["f_select_customer"];
			this.args["f_select_address"] = args["f_select_address"];

			this.args["top"] = args["top"].f_def(220);
			this.args["right_offset"] = args["right_offset"].f_def(30);

			this.args["josi_store"]["josi_end_point"] = args["josi_end_point"].
				f_def("http://kibicom.com/order_store_339/index.php");
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php");
			this.args["josi_store"]["login"] = args["josi_end_point"].f_def("dnclive");
			this.args["josi_store"]["pass"] = args["josi_end_point"].f_def("135");

			this.args["local_store"]["file_name"] = args["local_store"]["file_name"].f_def("kibicom_wd_josi.db");

			frm_customer_finder = new frm_finder_customer(new t()
			{
				{"josi_store", this.args["josi_store"]},
				{"local_store", this.args["local_store"]},
			});

			frm_address_finder = new frm_finder_address(new t()
			{
				{"josi_store", this.args["josi_store"]},
				{"local_store", this.args["local_store"]},
			});
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//this.StartPosition = FormStartPosition.Manual;
			//
		}

		private void frm_main_Shown(object sender, EventArgs e)
		{
			//MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString());
			Left = Screen.PrimaryScreen.Bounds.Width - Width - this.args["right_offset"].f_int();
			Top = this.args["top"].f_int();
			TopLevel = true;
			Height = 40;

			timer = new System.Threading.Timer(new TimerCallback(delegate(object args)
			{
				try
				{
					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{
							if (!is_show_blocked)
							{

								if (Cursor.Position.X < Location.X
								  || Cursor.Position.Y < Location.Y
								  || Cursor.Position.X > Location.X + Width
								  || Cursor.Position.Y > Location.Y + Height)
								{
									Height = 40;
									return new t();
								}
							}

							//контроль активности основной формы WD
							if (oif != null)
							{

								if (oif.OrderForm.mainForm.Focused)
								//if (order.OrderItemForm.OrderForm.mainForm.Focused)
								{
									Hide();
								}
								else
								{
									Show();
								}
							}

							return new t();

						}), new object[] { new t() });
					}
				}
				catch (Exception ex)
				{

				}

				
			}), new t(), 1000, 1000);

		}

		#region команды

		private void btn_add_customer_Click(object sender, EventArgs e)
		{
			frm_customer_finder.Top = Top;
			frm_customer_finder.Left = Left - frm_customer_finder.Width;
			
			//callback когда контрагент будет выбран
			frm_customer_finder.args["f_done"]=new t(new t_f<t, t>(delegate(t args)
			{
				t cust=frm_customer_finder.args["selected_item"]["item"];

				this.args["customer"] = args["customer"];

				btn_add_customer.Text = cust["name"].f_str();
				btn_add_customer.Font = new Font(btn_add_address.Font.FontFamily, 10);
				//btn_add_customer.Height *= 2;

				t.f_f("f_select_customer", this.args);

				return new t();
			}));


			if (frm_customer_finder.is_shown)
			{
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);

				frm_customer_finder.is_shown = false;
				frm_customer_finder.Hide();
				is_show_blocked = false;
			}
			else
			{
				btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Bold);

				frm_customer_finder.is_shown = true;
				frm_customer_finder.Show();
				frm_customer_finder.TopMost = true;

				is_show_blocked = true;
			}
		}

		private void btn_add_address_Click(object sender, EventArgs e)
		{
			frm_address_finder.Top = Top;
			frm_address_finder.Left = Left - frm_address_finder.Width;

			//callback когда адресс будет выбран
			frm_address_finder.args["f_done"] = new t(new t_f<t, t>(delegate(t args)
			{
				t cust = frm_address_finder.args["selected_item"]["item"];
				this.args["address"] = args["address"];

				btn_add_address.Text = cust["name"].f_str();
				btn_add_address.Font = new Font(btn_add_address.Font.FontFamily, 10);
				//btn_add_address.Height *= 2;

				t.f_f("f_select_address", this.args);

				return new t();
			}));


			if (frm_customer_finder.is_shown)
			{
				btn_add_address.Font = new Font(btn_add_address.Font, FontStyle.Regular);

				frm_address_finder.is_shown = false;
				frm_address_finder.Hide();
				is_show_blocked = false;
			}
			else
			{
				btn_add_address.Font = new Font(btn_add_address.Font, FontStyle.Bold);

				frm_address_finder.is_shown = true;
				frm_address_finder.Show();
				frm_address_finder.TopMost = true;
				is_show_blocked = true;
			}
		}

		#endregion команды

		private void frm_main_Activated(object sender, EventArgs e)
		{
			btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);
			is_show_blocked = false;
		}

		private void frm_main_MouseEnter(object sender, EventArgs e)
		{
			
			Height = 600;
			
		}

		private void frm_main_MouseLeave(object sender, EventArgs e)
		{

		}



		private void frm_main_Click(object sender, EventArgs e)
		{
			//Height = 600;
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			Close();
		}


	}
}
