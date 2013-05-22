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
	public partial class kibicom_mwh_frm_main : Form
	{

		DropShadow ds = new DropShadow();

		frm_finder_customer frm_customer_finder;
		frm_finder_address frm_address_finder;
		System.Threading.Timer timer = null;

		public Atechnology.ecad.Document.OrderItemForm oif;
		public Atechnology.ecad.Document.Classes.OrderClass order;

		bool is_show_blocked=false;

		public t args = new t();

		string using_store = "mssql";

		//используется для тестов
		public kibicom_mwh_frm_main()
		{
			InitializeComponent();

			this.args["top"].f_set(220);
			this.args["right_offset"].f_set(30);

			frm_customer_finder = new frm_finder_customer(new t());

			frm_address_finder = new frm_finder_address(new t());

		}

		//production конструктор
		public kibicom_mwh_frm_main(t args)//:this()
		{
			InitializeComponent();

			this.args["f_activate"] = args["f_activate"];
			this.args["f_select_customer"] = args["f_select_customer"];
			this.args["f_select_address"] = args["f_select_address"];

			this.args["wd_dbconn"] = args["wd_dbconn"];
			this.args["wd_ds"] = args["wd_ds"];

			//this.args["top"] = args["top"].f_def(220);
			//this.args["right_offset"] = args["right_offset"].f_def(30);

			this.args["top"] = args["top"].f_def(0);
			this.args["right_offset"] = args["right_offset"].f_def(150);

			this.args["josi_store"]["josi_end_point"] = args["josi_end_point"].
				f_def("http://kibicom.com/order_store_339/index.php");
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php");
			this.args["josi_store"]["login"] = args["josi_end_point"].f_def("dnclive");
			this.args["josi_store"]["pass"] = args["josi_end_point"].f_def("135");

			this.args["local_store"]["file_name"] = args["local_store"]["file_name"].f_def("kibicom_wd_josi.db");

			frm_customer_finder = new frm_finder_customer(new t()
			{
				{"owner", this},
				{"josi_store", this.args["josi_store"]},
				{
					"local_store", new t()
					{
						{"store_type", using_store},
						{
							"sqlite_cli", new t()
							{
								this.args["local_store"]
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
				},
			});

			frm_address_finder = new frm_finder_address(new t()
			{
				{"owner", this},
				{"josi_store", this.args["josi_store"]},
				{
					"local_store", new t()
					{
						{"store_type", using_store},
						{
							"sqlite_cli", new t()
							{
								this.args["local_store"]
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
				},
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
			//Left = Screen.PrimaryScreen.Bounds.Width - Width - this.args["right_offset"].f_int();
			//Top = this.args["top"].f_int();
			//TopLevel = true;
			//Height = 60;

			//f_drop_shadow();

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
									Height = 60;

									ds.f_hide();

									//f_drop_shadow();

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


		private void f_ds_init()
		{
			
		}


		private void f_drop_shadow()
		{
			
			ds.f_show(this);
			this.BringToFront();

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

				this.args["customer"] = cust;

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
				t address= frm_address_finder.args["selected_item"]["item"];

				this.args["address"] = address;

				btn_add_address.Text = address["name"].f_str();
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

			t.f_f("f_activate", this.args);

			//f_drop_shadow();
			
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
			ds.Close();
			foreach (Form frm in OwnedForms)
			{
				frm.Close();
			}
			Close();
		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		//border only
		protected override void WndProc(ref Message message)
		{
			const int WM_NCHITTEST = 0x0084;

			if (message.Msg == WM_NCHITTEST)
				return;

			base.WndProc(ref message);
		}

		private void kibicom_mwh_frm_main_Load(object sender, EventArgs e)
		{
			Left = Screen.PrimaryScreen.Bounds.Width - Width - this.args["right_offset"].f_int();
			Top = this.args["top"].f_int();
			TopLevel = true;
			Height = 60;
		}

		public void f_tab_enter(object sender, EventArgs e)
		{
			this.args["wd"]["active_tab"].f_set(sender);
			MessageBox.Show("123");
		}
	}

	public class DropShadow : Form
	{
		public DropShadow()
		{
			return;
			this.Opacity = 0.5;
			this.BackColor = Color.Gray;
			this.ShowInTaskbar = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.Manual;
			this.TopMost = true;
		}
		private const int WS_EX_TRANSPARENT = 0x20;
		private const int WS_EX_NOACTIVATE = 0x8000000;
		protected override System.Windows.Forms.CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT | WS_EX_NOACTIVATE;
				return cp;
			}
		}

		public void f_show(Form frm)
		{
			return;
			Rectangle rc = frm.Bounds;
			rc.Inflate(10, 10);
			this.Bounds = rc;
			//frm.le
			//this.level
			this.Show();
			frm.Show();
			this.BringToFront();
		}

		public void f_hide()
		{
			return;
			this.Hide();
		}

	}
}
