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

		public frm_finder_customer frm_customer_finder;
		public frm_finder_address frm_address_finder;

		public frm_finder_customer_address frm_customer_address_finder;

		public frm_in_work frm_in_work;

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

			this.args["self"].f_set(this);

			this.args["f_activate"] = args["f_activate"];
			this.args["f_select_customer"] = args["f_select_customer"];
			this.args["f_select_address"] = args["f_select_address"];

			this.args["wd"]["dbconn"] = args["wd"]["dbconn"];
			this.args["wd"]["ds"] = args["wd"]["ds"];

			//this.args["top"] = args["top"].f_def(220);
			//this.args["right_offset"] = args["right_offset"].f_def(30);

			this.args["top"] = args["top"].f_def(0);
			this.args["right_offset"] = args["right_offset"].f_def(150);

			this.args["real_state"].f_set("hidden");

			this.args["josi_store"]["josi_end_point"] = args["josi_end_point"].
				f_def("http://kibicom.com/order_store_339/index.php");
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php");
			this.args["josi_store"]["login"] = args["josi_end_point"].f_def("dnclive");
			this.args["josi_store"]["pass"] = args["josi_end_point"].f_def("135");

			this.args["local_store"]["file_name"] = args["local_store"]["file_name"].f_def("kibicom_wd_josi.db");

			frm_customer_finder = new frm_finder_customer(new t()
			{
				{"owner", this},
				{"caption", "Выберите клиента"},
				{"wd_seller_guid", args["wd_seller_guid"].f_def("1DC71FEB-2F5C-413E-AF1A-39B43B272C9B")},
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
				{"caption", "Выберите адрес"},
				{"wd_seller_guid", args["wd_seller_guid"]},
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

			frm_customer_address_finder = new frm_finder_customer_address(new t()
			{
				{"owner", this},
				{"caption", "Начните вводить фамилию, телефон, или адрес клиента..."},
				{"wd_seller_guid", args["wd_seller_guid"].f_def("1DC71FEB-2F5C-413E-AF1A-39B43B272C9B")},
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

			//форма получения сроков передачи в работу
			frm_in_work = new frm_in_work(new t()
			{
				{"owner", this},
				{"f_give_to_work", args["f_give_to_work"]},
				{"f_give_to_check",args["f_give_to_work"]}
			});

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

		private t f_frm_address(t args)
		{

			frm_address_finder.Top = args["top"].f_int();
			frm_address_finder.Left = args["left"].f_int();

			if (!args["tab_customer_uid"].f_is_empty())
			{
				frm_address_finder.args["tab_customer_uid"] = args["tab_customer_uid"];
			}

			//callback когда адресс будет выбран
			frm_address_finder.args["f_done"] = new t(new t_f<t, t>(delegate(t args1)
			{
				t address = frm_address_finder.args["selected_item"]["item"];

				this.args["address"] = address;

				btn_add_address.Text = address["name"].f_str();
				btn_add_address.Font = new Font(btn_add_address.Font.FontFamily, 10);
				//btn_add_address.Height *= 2;

				t.f_f("f_select_address", this.args);

				t.f_f("f_done", args);

				//сохраняем связь между выбранным контрагентом и адресом
				frm_address_finder.f_store_related_customer(new t());

				return new t();
			}));

			frm_address_finder.args["f_leaved"]= new t(new t_f<t, t>(delegate(t args1)
			{
				
				t.f_f("f_leaved", args);

				return new t();
			}));



			if (frm_address_finder.is_shown)
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

				//очищаем поле запроса если нужно
				if (args["clear_query"].f_bool())
				{
					frm_address_finder.txt_query.Text = "";
				}

				//запрашиваем элементы по умолчанию
				frm_address_finder.f_find(args);

			}

			return new t();
		}

		public t f_frm_customer(t args)
		{
			frm_customer_finder.Top = args["top"].f_int();
			frm_customer_finder.Left = args["left"].f_int();

			if (!args["tab_address_uid"].f_is_empty())
			{
				frm_customer_finder.args["tab_address_uid"] = args["tab_address_uid"];
			}

			//callback когда контрагент будет выбран
			frm_customer_finder.args["f_done"] = new t(new t_f<t, t>(delegate(t args1)
			{
				t cust = frm_customer_finder.args["selected_item"]["item"];

				this.args["customer"] = cust;

				btn_add_customer.Text = cust["name"].f_str();
				btn_add_customer.Font = new Font(btn_add_address.Font.FontFamily, 10);
				//btn_add_customer.Height *= 2;

				t.f_f("f_select_customer", this.args);

				t.f_f("f_done", args);

				//сохраняем связь между выбранным контрагентом и адресом
				frm_customer_finder.f_store_related_address(new t());

				//после выбора клиента вызываем окно выбора адреса
				//btn_add_address_Click(null, null);

				return new t();
			}));

			frm_customer_finder.args["f_leaved"] = new t(new t_f<t, t>(delegate(t args1)
			{

				t.f_f("f_leaved", args);

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

				//очищаем поле запроса если нужно
				if (args["clear_query"].f_bool())
				{
					frm_customer_finder.txt_query.Text = "";
				}

				//запрашиваем элементы по умолчанию
				frm_customer_finder.f_find(args);
			}

			return new t();
		}

		public t f_frm_customer_address(t args)
		{
			frm_customer_address_finder.Top = Top;
			frm_customer_address_finder.Left = Left - frm_customer_address_finder.Width;

			//аркументы для окна выбора адреса/клиента
			t frm_finder_args = new t()
			{
				{
					"f_done", new t_f<t, t>(delegate(t args1)
					{

						//скрываем форму клиент/адрес
						frm_customer_address_finder.Hide();

						//восстанавливаем форму клиент/адрес
						frm_customer_address_finder.fpn_selected_pane.Visible = false;
						frm_customer_address_finder.fpn_finder_pane.Visible = true;
						frm_customer_address_finder.args["is_blocked"].f_set(false);
						frm_customer_address_finder.args.f_drop("selected_item");
						frm_customer_address_finder.txt_query.Text="";

						t.f_f("f_select_customer_address", this.args);

						return new t();
					})
				},
				{
					"f_leaved", new t_f<t, t>(delegate(t args1)
					{

						//скрываем форму клиент/адрес
						//но не восстанавливаем ее
						//пользователь не закончил выбор контрагента
						//и когда вернятся продолжит с выбора адреса
						//при этом если курсор не над формой
						if (Cursor.Position.X < frm_customer_address_finder.Location.X
								  || Cursor.Position.Y < frm_customer_address_finder.Location.Y
								  || Cursor.Position.X > frm_customer_address_finder.Location.X +
															frm_customer_address_finder.Width
								  || Cursor.Position.Y > frm_customer_address_finder.Location.Y +
															frm_customer_address_finder.Height)
						{
							frm_customer_address_finder.Hide();

							
							return new t();
						}
						else
						{
							//иначе возвращаемся к выбору клиента/адреса
							//frm_customer_finder.Hide();
							//frm_address_finder.Hide();

							frm_customer_address_finder.fpn_selected_pane.Visible = false;
							frm_customer_address_finder.fpn_finder_pane.Visible = true;
							frm_customer_address_finder.args["is_blocked"].f_set(false);
							frm_customer_address_finder.args.f_drop("selected_item");

							//блокируем popup так как работа еще ведеться
							is_show_blocked = true;
						}
						



						//t.f_f("f_select_customer_address", this.args);

						return new t();
					})
				},
				{
					"f_cancel_", new t_f<t, t>(delegate(t args1)
					{

						//скрываем форму клиент/адрес
						//frm_customer_address_finder.Hide();

						//восстанавливаем форму клиент/адрес
						frm_customer_address_finder.fpn_selected_pane.Visible = false;
						frm_customer_address_finder.fpn_finder_pane.Visible = true;
						///frm_customer_address_finder.args["is_blocked"].f_set(false);
						frm_customer_address_finder.args.f_drop("selected_item");
						//frm_customer_address_finder.txt_query.Text="";

						//t.f_f("f_select_customer_address", this.args);

						return new t();
					})
				}

			};

			//callback когда контрагент будет выбран
			frm_customer_address_finder.args["f_done"] = new t(new t_f<t, t>(delegate(t args1)
			{
				t selected_item = frm_customer_address_finder.args["selected_item"]["item"];

				//копируем название выбранного контрагента в опционную кнопку finder
				frm_customer_address_finder.btn_opt.Text =
					frm_customer_address_finder.args["selected_item"]["str1"].f_str();

				//включаем видимость опционной панели
				frm_customer_address_finder.fpn_selected_pane.Visible = true;

				//выключаем видимость панели finder
				frm_customer_address_finder.fpn_finder_pane.Visible = false;

				//обновляем окно что бы оно подстроило свой размер
				frm_customer_address_finder.Refresh();

				//блокируем окно от скрывания в результате деактивации
				frm_customer_address_finder.args["is_blocked"].f_set(true);

				//размещаем окно выбора адреса под окном выбора контрагента
				//после выбора клиента вызываем окно выбора адреса
				//указываем что был выбран клиент/адрес
				if (frm_customer_address_finder.args["selected_item"]["tab_name"].f_str() == "customer")
				{
					//frm_customer_address_finder.args["selected"].f_set(true);
					this.args["customer"] = selected_item;
					f_frm_address(frm_finder_args.f_add(true, new t()
					{
						{"top", frm_customer_address_finder.Bottom},
						{"left", Left - frm_address_finder.Width},
						{"tab_customer_uid", this.args["customer"]["uid"]},
						{"clear_query", true}
					}));

					//вызываем событие выбора контрагента
					t.f_f("f_select_customer", this.args);

				}
				else if (frm_customer_address_finder.args["selected_item"]["tab_name"].f_str() == "address")
				{
					//frm_customer_address_finder.args["selected"].f_set(true);
					this.args["address"] = selected_item;
					f_frm_customer(frm_finder_args.f_add(true,new t()
					{
						{"top", frm_customer_address_finder.Bottom},
						{"left", Left - frm_customer_finder.Width},
						{"tab_address_uid", this.args["address"]["uid"]},
						{"clear_query", true}
					}));

					//вызываем событие выбора адреса
					t.f_f("f_select_address", this.args);

				}



				//lbl_invite.Text = "Выберите адрес...";



				//btn_add_customer.Text = cust["name"].f_str();
				//btn_add_customer.Font = new Font(btn_add_address.Font.FontFamily, 10);
				//btn_add_customer.Height *= 2;




				return new t();
			}));


			if (frm_customer_address_finder.is_shown)
			{
				frm_customer_address_finder.Font = new Font(frm_customer_address_finder.Font, FontStyle.Regular);

				frm_customer_address_finder.is_shown = false;
				frm_customer_address_finder.Hide();
				is_show_blocked = false;
			}
			else
			{
				frm_customer_address_finder.Font = new Font(frm_customer_address_finder.Font, FontStyle.Bold);

				frm_customer_address_finder.is_shown = true;
				//frm_customer_address_finder.Hide();
				frm_customer_address_finder.TopMost = true;
				frm_customer_address_finder.Show();

				//если уже выбран клиент
				if (frm_customer_address_finder.args["selected_item"]["tab_name"].f_str() == "customer")
				{
					f_frm_address(frm_finder_args.f_add(true, new t()
					{
						{"top", frm_customer_address_finder.Bottom},
						{"left", Left - frm_address_finder.Width},
					}));
				}
				else if (frm_customer_address_finder.args["selected_item"]["tab_name"].f_str() == "address")
				{
					f_frm_customer(frm_finder_args.f_add(true, new t()
					{
						{"top", frm_customer_address_finder.Bottom},
						{"left", Left - frm_customer_finder.Width}
					}));
				}

				is_show_blocked = true;
			}

			return new t();
		}

		private t f_frm_in_work(t args)
		{
			
			frm_in_work.Top = args["top"].f_int();
			frm_in_work.Left = args["left"].f_int();


			if (frm_in_work.args["is_shown"].f_bool())
			{
				frm_in_work.Font = new Font(frm_in_work.Font, FontStyle.Regular);

				frm_in_work.args["is_shown"].f_set(false);
				frm_in_work.Hide();
				is_show_blocked = false;
			}
			else
			{

				frm_in_work.Font = new Font(frm_in_work.Font, FontStyle.Bold);

				frm_in_work.args["is_shown"].f_set(true);
				frm_in_work.Show();
				frm_in_work.Refresh();
				frm_in_work.TopMost = true;
				is_show_blocked = true;

				//t.f_f("f_", this.args);

			}

			return new t();
		}


		//событие активации вкладки wd
		public void f_tab_enter(object sender, EventArgs e)
		{
			
			this.args["wd"]["active_tab"].f_set(sender);
			Atechnology.ecad.Document.OrderItemForm oif = (Atechnology.ecad.Document.OrderItemForm)sender;

			//MessageBox.Show(oif.Name.ToString());

			//MessageBox.Show(oif.ds.Tables.Count.ToString());

			//MessageBox.Show(oif.ds.Tables["orders"].Rows[0]["name"].ToString());

			if (sender.GetType() == typeof(Atechnology.ecad.Document.OrderItemForm))
			{
				this.args["wd"]["dbconn"].f_set(oif.db);
				this.args["wd"]["ds"].f_set(oif.ds);
			}


		}

		public void f_set_context(t args)
		{
			try
			{
				f_set_context(args);
				f_set_context(args);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void f_set_customer(t args)
		{
			string customer_name=args["customer_name"].f_str();

			btn_add_customer.Text = customer_name;
		}

		public void f_set_address(t args)
		{
			string address_name = args["address_name"].f_str();

			btn_add_address.Text = address_name;
		}


		public void f_get_items(t args)
		{
			//получение последних элементов
			//frm_customer_finder.f_find(args);
			//frm_address_finder.f_find(args);
			frm_customer_address_finder.f_find(args);
		}

		#endregion команды


		#region события


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

			this.args["real_state"].f_set("shown");

			timer = new System.Threading.Timer(new TimerCallback(delegate(object args)
			{
				try
				{
					if (this.InvokeRequired)
					{
						this.Invoke(new t_f<t, t>(delegate(t args1)
						{
							
							//если состояние формы заблокировано
							if (!is_show_blocked)
							{

								if (Cursor.Position.X < Location.X
								  || Cursor.Position.Y < Location.Y
								  || Cursor.Position.X > Location.X + Width
								  || Cursor.Position.Y > Location.Y + Height)
								{
									Height = 60;

									ds.f_hide();

									this.args["is_active"].f_set(false);

									//MessageBox.Show(this.Focused.ToString());

									//если требуемое состояние спратан
									if (this.args["required_state"].f_str() == "hidden" )
									{
										//то если форма видна прячем ее
										if (this.args["real_state"].f_str() == "shown")
										{
											Hide();
											this.args["real_state"].f_set("hidden");
										}
									}
									else
									{
										//то если должна быть видна но спрятана показываем
										if (this.args["real_state"].f_str() == "hidden")
										{
											Show();
											this.args["real_state"].f_set("shown");
										}
									}

									//f_drop_shadow();

									return new t();
								}
								else
								{
									
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


		private void btn_add_customer_Click(object sender, EventArgs e)
		{
			f_frm_customer(new t()
			{
				{"top", Top},
				{"left", Left - frm_customer_finder.Width}
			});

		}

		private void btn_add_address_Click(object sender, EventArgs e)
		{
			f_frm_address(new t()
			{
				{"top", Top},
				{"left", Left - frm_address_finder.Width}
			});
		}

		private void btn_customer_address_Click(object sender, EventArgs e)
		{
			f_frm_customer_address(new t()
			{
				{"top", Top},
				{"left", Left - frm_customer_address_finder.Width}
			});
		}

		private void btn_gate_to_work_Click(object sender, EventArgs e)
		{
			f_frm_in_work(new t()
			{
				{"top", Top},
				{"left", Left - frm_in_work.Width}
			});
		}


		private void frm_main_Activated(object sender, EventArgs e)
		{
			btn_add_customer.Font = new Font(btn_add_customer.Font, FontStyle.Regular);
			is_show_blocked = false;
			this.args["real_state"].f_set("shown");
		}

		private void frm_main_MouseEnter(object sender, EventArgs e)
		{

			if (!this.args["is_active"].f_bool())
			{

				Height = 600;

				this.Refresh();

				t.f_f("f_activate", this.args);

				//new Delegate(f_get_items)

				f_get_items(new t());

				this.args["is_active"].f_set(true);

				//f_drop_shadow();
			}
			
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

		/*
		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams baseParams = base.CreateParams;
				
				baseParams.ExStyle |= (int)(0x08000000L | 0x00000080L);

				return baseParams;
			}
		}
		*/

		#endregion события

		


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
