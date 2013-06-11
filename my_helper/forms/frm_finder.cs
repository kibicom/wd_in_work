using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Collections;
//using customer_info;
using josi;
//using josi.store.res;
using kibicom.tlib;
using kibicom.josi;


namespace kibicom.my_wd_helper
{

	
	public partial class frm_finder : Form, ikibifrm
	{

		//DropShadow ds = new DropShadow();

		public bool is_shown = false;

		//объект запросов к josi
		//t_josi_store josi_store = new t_josi_store(new t_josi_auth_args("dnclive", "135"));
		public t_store josi_store =null;// new t_store(new t(){{"login_name","dnclive"}, {"pass","135"}});

		public t_kwj kwj;

		//время последнего нажатия на клавишу
		public TimeSpan last_key_down;

		//последнее значение фильтра txt_query
		public string last_filter_val = "";

		//флаг - нужно ли показывать возвращенные результаты запроса
		//public bool show_result=true;

		//выбранный, или созданный клиента
		//public t selected_item;

		//public t tab=new t();

		//предыдущее положение мыщи на listbox
		Point last_lbx_mouse_point;

		//аргументы
		public t _args=new t();

		public t args
		{
			get { return _args; }
			set { _args = value; }
		}

		//форма ввода нового/редактирования элемента
		public Form frm_cre_edit_item;

		public frm_finder()
		{
			InitializeComponent();
		}

		public frm_finder(t args): this()
		{
			Owner = args["owner"].f_val<Form>();

			this._args["caption"] = args["caption"];
			lbl_invite.Text = this._args["caption"].f_def(lbl_invite.Text).f_str();

			string login_name = args["josi_store"]["login_name"].f_def("dnclive").f_str();
			string pass = args["josi_store"]["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_store"]["josi_end_point"].
				f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				//f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();

			josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},		//точка подключения josi
				{"req_timeout", args["josi_store"]["req_timeout"].f_def(5000).f_int()},	//таймаут запроса
				{"login_name",login_name},				//имя для входа
				{"pass",pass},							//пароль для входа
				{"login_on_cre", true},					//логинимся
				{"auth_try_count", args["josi_store"]["auth_try_count"].f_def(3).f_int()},	//количество попыток авторизации
				{"f_done", args["f_done"].f_f()},		//вызываем когда авторизуемся успешно
				{"f_fail", args["f_fail"].f_f()}		//вызываем если авторизация не удалась
			});

			this._args["using_local_store"] = args["local_store"]["store_type"].f_def("mssql");

			//инициализируем локальное хранилище
			f_cre_kwj(args);

			f_set_grafix(args);
		}


		public t f_set_grafix(t args)
		{

			//this.Scale((float)0.8);
			//lbx_items.Scale((float)0.8);
			lbx_items.ItemHeight = args["lbx"]["item_hight"].f_def(63).f_int();
			lbx_items.Font=new Font(lbx_items.Font.FontFamily, args["lbx"]["font_size"].f_def(16).f_int());

			lbx_items.ItemHeight = args["lbx"]["item_hight"].f_def(55).f_int();
			lbx_items.Font = new Font(lbx_items.Font.FontFamily, args["lbx"]["font_size"].f_def(14).f_int());

			//lbx_items.ItemHeight = args["lbx"]["item_hight"].f_def(43).f_int();
			//lbx_items.Font = new Font(lbx_items.Font.FontFamily, args["lbx"]["font_size"].f_def(11).f_int());

			return new t();
		}

		public t f_cre_kwj(t args)
		{
			//создаем клиента, подключаемся
			kwj = new t_kwj(new t()
			{
				{"josi_store", args["josi_store"]},
				{
					"local_store", args["local_store"]
				}
			});

			return new t();
		}

		public t f_cre_josi_store(t args)
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_end_point"].
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();

			josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},		//точка подключения josi
				{"req_timeout", args["req_timeout"].f_def(5000).f_int()},	//таймаут запроса
				{"login_name",login_name},				//имя для входа
				{"pass",pass},							//пароль для входа
				{"login_on_cre", true},					//логинимся
				{"auth_try_count", args["auth_try_count"].f_def(3).f_int()},	//количество попыток авторизации
				{"f_done", args["f_done"].f_f()},		//вызываем когда авторизуемся успешно
				{"f_fail", args["f_fail"].f_f()}		//вызываем если авторизация не удалась
			});

			//this["josi_store"] = josi_store;

			return new t();
		}

		#region события

		//нажатие на кнопку в строке поиска
		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyData == Keys.Down || e.KeyData == Keys.Up)
			{
				e.Handled = true;
				if (lbx_items.Items.Count == 0)
				{
					return;
				}
				if (e.KeyData == Keys.Down)
				{
					if (lbx_items.SelectedIndex == lbx_items.Items.Count - 1)
					{
						lbx_items.SelectedIndex = 0;
						e.Handled = false;
					}
					else
					{
						lbx_items.SelectedIndex++;
					}
					e.Handled = true;
				}
				if (e.KeyData == Keys.Up)
				{
					if (lbx_items.SelectedIndex == 0)
					{
						lbx_items.SelectedIndex = lbx_items.Items.Count - 1;
					}
					else
					{
						lbx_items.SelectedIndex--;
					}
					e.Handled = true;
				}
			}

			if (e.KeyData == Keys.Enter)
			{
				
				//f_select_item();
				f_touch_lbx_item();

			}
			
		}
		
		//отпускание кнопки в строке поиска
		private void txt_query_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData==Keys.Enter)
			{
				return;
			}

			if (txt_query.Text.Length < 2&&1==0)
			{

				lbx_items.Items.Clear();
				fp_actions.Visible = false;
				//show_result = false;
				return;
			}

			if (last_filter_val == txt_query.Text)
			{
				//show_result = false;
				return;
			}

			/*
			this._args["eimit"].f_set(false);
			if (!f_check_speed_dial(new t())["emit"].f_bool())
			{
				return;
			}
			*/

			last_filter_val = txt_query.Text;

			f_find(new t());
			
			

		}

		//форма отображена
		private void josi_customer_Shown(object sender, EventArgs e)
		{
			txt_query.Focus();
			//ds.f_show(this);
		}

		//вывод элементов в listbox
		private void lbx_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			//MessageBox.Show("lbx");
			ListBox lbx = (ListBox)sender;
			//если в списке нет элементов нечего прорисовывать выходим
			if (lbx.Items.Count == 0 || e.Index < 0)
			{
				return;
			}

			//приводим ткущий рисуемый элемент к t_customer
			t item = (t)lbx.Items[e.Index];

			// Draw the background of the ListBox control for each item.
			e.DrawBackground();
			// Define the default color of the brush as black.
			//Brush text_brush = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#333"));

			//Brush b1 = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#0099cc"));

			//Font text_font = e.Font;

			//отрисовываем текущий выделенный элемент
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				//рисуем прямоуголник выделенного элемента (фон)
				e.Graphics.FillRectangle(new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#0099cc")), e.Bounds);
				//text_brush = SystemBrushes.HighlightText;
				//text_brush = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#9cc"));
				//text_font = new Font(e.Font, FontStyle.Bold);

				//выводим fio клиента в первой строчке
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str1"].f_str(),
					new Font(e.Font, FontStyle.Bold),	//текст делаем жирным
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#333")),	//цвет тени
					//прямоугольник в который выводится текст
					new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
				);

				//вывдим телефоны и email во второй строке
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str2"].f_str(),
					e.Font,			//текст оставляем нормальным
					new SolidBrush(ColorTranslator.FromHtml("#eee")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//цвет тени
					//прямоугольник в который выводится текст - смещен на 31 пиксель по вертикали (вывод второй строки)
					new Rectangle(e.Bounds.X, e.Bounds.Y + lbx_items.ItemHeight/2-2, e.Bounds.Width, e.Bounds.Height)
				);

				//выводим кнопку редактирования на выделенном элементе
				RectangleF rect = e.Bounds;
				fp_actions.Top = Convert.ToInt32(lbx_items.Top + rect.Top + rect.Height / 2 - fp_actions.Height / 2);
				fp_actions.Left = Convert.ToInt32(lbx_items.Left + rect.Right - rect.Height / 2 + fp_actions.Height / 2 - fp_actions.Width);

			}
			else	//отрисовываем не выделенные элементы
			{
				//нечетные строки имеют белый фон
				if (e.Index % 2 == 0)
				{
					e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#fff")), e.Bounds);
				}
				else//четные светло серый
				{
					e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#eee")), e.Bounds);
				}

				//выводим fio клиента в первой строчке
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str1"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#333")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//цвет тени
					e.Bounds
				);
				//вывдим телефоны и email во второй строке
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str2"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//цвет тени
					new Rectangle(e.Bounds.X, e.Bounds.Y + lbx_items.ItemHeight / 2-2, e.Bounds.Width, e.Bounds.Height)
				);

			}

			// If the ListBox has focus, draw a focus rectangle around the selected item.
			e.DrawFocusRectangle();
			//e.
		}

		private void lbx_items_Enter(object sender, EventArgs e)
		{
			//txt_query.Focus();
			if (lbx_items.Items.Count > 0)
			{
				fp_actions.Visible = true;
			}
		}

		private void lbx_items_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			//MessageBox.Show("kd");
			txt_query.Focus();
			//txt_query.fi
			//RaiseKeyEvent(e.KeyCode, new KeyEventArgs(e.KeyData));
			//RaiseKeyEvent(lbx_items, new KeyEventArgs(e.KeyData));
			//textBox1_KeyDown(txt_query, new KeyEventArgs(e.KeyData));
			//txt_query_KeyUp(txt_query, new KeyEventArgs(e.KeyData));
			//te

			//var key = Keys.Insert;                    // Key to send
			//var target = Keyboard.FocusedElement;    // Target element
			//var routedEvent = Keyboard.KeyDownEvent; // Event to send




			//target.RaiseEvent(new KeyEventArgs
			//(
			//	Keyboard.PrimaryDevice,
			//	PresentationSource.FromVisual(target),
			//	0,
			//	key)//,
			//{RoutedEvent=routedEvent }
			//);

		}

		private void lbx_items_MouseMove(object sender, MouseEventArgs e)
		{

			ListBox lbx = (ListBox)sender;


			if (last_lbx_mouse_point != null)
			{
				if (last_lbx_mouse_point.X == e.X && last_lbx_mouse_point.Y == e.Y)
				{
					return;
				}
			}

			//MessageBox.Show("move");

			lbx.Focus();

			last_lbx_mouse_point = new Point(e.X, e.Y);

			int itemIndex = lbx.IndexFromPoint(last_lbx_mouse_point);

			if (itemIndex >= 0 && itemIndex != 65535)
			{
				lbx.SelectedIndex = itemIndex;
				f_mouse_change_selected_item(new t()
				{
					{"item", (t)(lbx.Items[itemIndex])}
				});
				fp_actions.Visible = true;
			}

		}

		private void josi_customer_Deactivate(object sender, EventArgs e)
		{
			is_shown = false;
			f_leaved(this._args);
			return;
			int l = 0;
			is_shown = false;
			if (!this._args["is_blocked"].f_def(false).f_bool())
			{
				//ds.f_hide();
				f_leaved(this._args);

				if (Owner != null)
				{
					((kibicom_mwh_frm_main)Owner).f_hide_all_not_under_mouse_cursor(new t());
				}
				else
				{
					Hide();
				}
			}
			else
			{
				l = 0;
			}
			if (frm_cre_edit_item != null)
			{
				frm_cre_edit_item.Activate();
			}
		}

		private void josi_customer_FormClosing(object sender, FormClosingEventArgs e)
		{
			is_shown = false;
			//ds.f_hide();
			Hide();
			//e.Cancel = true;
		}

		private void lbx_items_Click(object sender, EventArgs e)
		{
			f_touch_lbx_item();
		}

		#region кнопки

		private void btn_change_Click(object sender, EventArgs e)
		{
			//выбираем затронутый элемент
			//t selected_item = this._args["selected_item"].f_set((t)lbx_items.SelectedItem);

			//вызываем функцию редактирования
			f_modify_item(new t() { { "item", (t)lbx_items.SelectedItem } });
		}

		private void btn_change_MouseEnter(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			f_btn_push(btn);
		}

		private void btn_change_MouseLeave(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			f_btn_up(btn);
		}

		//pick
		private void btn_pick_Click(object sender, EventArgs e)
		{
			//вызываем функцию редактирования
			f_pick_item(new t() 
			{ 
				{ "item", (t)lbx_items.SelectedItem },
				{"btn", sender}
			});
		}

		//делаем кнопку нажатой
		public void f_btn_push(Button btn)
		{
			//btn.Image = ((System.Drawing.Image)(Properties.Resources.btn_print_1));
			btn.FlatAppearance.BorderSize = 3;
		}

		//делаем отпущенной
		public void f_btn_up(Button btn)
		{
			//btn.Image = ((System.Drawing.Image)(Properties.Resources.btn_print_1));
			btn.FlatAppearance.BorderSize = 0;
		}

		//drop
		private void btn_drop_Click(object sender, EventArgs e)
		{
			//вызываем функцию редактирования
			f_drop_item(new t() 
			{ 
				{"item", (t)lbx_items.SelectedItem},
				{"btn", sender}
			});
		}

		//восстановление
		private void btn_revert_Click(object sender, EventArgs e)
		{
			//вызываем функцию редактирования
			f_revert_item(new t() 
			{ 
				{"item", (t)lbx_items.SelectedItem},
				{"btn", sender}
			});
		}

		//опция
		private void btn_opt_Click(object sender, EventArgs e)
		{
			//вызываем функцию редактирования
			f_opt(new t());
		}


		#endregion кнопки


		private void frm_finder_Load(object sender, EventArgs e)
		{

		}

		private void lbx_items_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		
		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		protected override void WndProc(ref Message message)
		{

			const int WM_NCHITTEST = 0x0084;
			const int WM_ACTIVATEAPP = 0x001C;
			const int WM_ACTIVATE = 0x0006;
			const int WM_NCACTIVATE = 0x0086;
			//const int WS_EX_TOPMOST = 0x00000008;
			//const int WS_EX_TOOLWINDOW = 0x00000080;
			//const int WS_EX_NOACTIVATE = 0x08000000;
			//message.
			if (message.Msg == WM_NCHITTEST)
			{
				//message.Result = IntPtr.Zero;
				base.WndProc(ref message);
				return;
			}

			if (message.Msg == WM_ACTIVATE&&1==0)
			{
				if (message.WParam == new IntPtr(0))
				{
					josi_customer_Deactivate(null, null);
					base.WndProc(ref message);
				}
				if (message.WParam == new IntPtr(1))
				{
					//message.Result = IntPtr.Zero;
					base.WndProc(ref message);
					return;
				}
				if (message.WParam == new IntPtr(2))
				{
					//message.Result = IntPtr.Zero;
					base.WndProc(ref message);
					return;
				}

			}
			if (message.Msg == WM_NCACTIVATE)
			{
				if (message.WParam == new IntPtr(0))
				{
					base.WndProc(ref message);
				}
				if (message.WParam == new IntPtr(1))
				{
					message.Result = IntPtr.Zero;
					return;
				}
				if (message.WParam == new IntPtr(2))
				{
					message.Result = IntPtr.Zero;
					return;
				}
			}

			base.WndProc(ref message);

		}

		protected override CreateParams CreateParams
		{
			get
			{
				//const int WM_NCHITTEST = 0x0084;
				//const int WS_EX_TOPMOST = 0x00000008;
				const int WS_EX_TOOLWINDOW = 0x00000080;
				const int WS_EX_NOACTIVATE = 0x08000000;
				const int WS_EX_TOPMOST = 0x00000008;
				const int WS_EX_WINDOWEDGE = 0x00000100;

				CreateParams baseParams = base.CreateParams;

				baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST | WS_EX_WINDOWEDGE);

				return baseParams;
			}
		}
		


		#endregion события

		public t f_check_speed_dial(t args)
		{

			TimeSpan last_key_down= this._args["last_key_down"].
					f_def_set(new TimeSpan(DateTime.Now.Ticks)).f_val<TimeSpan>();

			if (DateTime.Now.Ticks - last_key_down.Ticks > 10000000)
			{
				this._args["emit"].f_set(true);
			}

			this._args["last_key_down"].f_set(new TimeSpan(DateTime.Now.Ticks));

			return this._args;
		}

		//курсон переведен на другой элемента
		virtual public t f_mouse_change_selected_item(t args)
		{
			return new t();
		}

		//форма деактивирована
		virtual public t f_leaved(t args)
		{

			t.f_f("f_leaved", this._args);

			return new t();
		}

		//выполнить поиск
		public void f_find(t args)
		{
			fp_actions.Visible = false;

			this._args["items"].Clear();

			//если есть новые элементы в кеше показываем их сразу
			if (this._args["new_items"].Count > 0)
			{
				foreach (t new_item in (IList<t>) this._args["new_items"])
				{
					this._args["items"].Add(new_item);
				}

				this._args["new_items"].Clear();

				f_fill_lbx(args);

				return;
			}

			pb_loading_2.Show();

			f_get_items(args);
		}

		//получение элементов из источника
		virtual public t f_get_items(t args)
		{

			return new t();
		}

		//заполнение listbox полученными элементами
		virtual public t f_fill_lbx(t args)
		{

			//t_f<t,t> f_done=

			t_f<t,t> f=new t_f<t, t>(delegate(t args1)
			{
				//string lbx_add = args1["lbx_add"].f_def("replace").f_str();

				

				bool lbx_add_replace = args1["lbx_add"].f_def("replace").f_str() == "replace";

				//MessageBox.Show(lbx_add_replace.ToString());

				pb_loading_2.Hide();

				//если количество возвращенных результатов 0 и запрос не пуст
				//то добавляем новый элемент
				if (this._args["items"].Count == 0&& txt_query.Text!="")
				{
					f_add_new();
				}

				//очищаем если нужно
				if (lbx_add_replace) lbx_items.Items.Clear();

				//наполняем и рендерим список
				foreach (t item in (IList<t>)this._args["items"])
				{
					lbx_items.Items.Add(item);
				}

				lbx_items.SelectedIndex = 0;

				t.f_f("f_done", args1);

				return new t();

			});

			if (lbx_items.InvokeRequired)
			{
				lbx_items.Invoke(f, new object[] { args });
			}
			else
			{
				f(args);
			}

			return new t();
		}

		//если результ запроса пуст, предлагаем создать новый элемент ресурса
		virtual public void f_add_new()
		{
			this._args["items"].Add(new t()
			{
				{"str1",this._args["new_item_caption"].f_def("Добавить новый элемент")},
				{"str2",txt_query.Text},
				{"is_new", true}
			});
		}

		//выбор элемента listbox
		virtual public void f_touch_lbx_item()
		{
			//выбираем затронутый элемент
			t selected_item=this._args["selected_item"].f_set((t)lbx_items.SelectedItem);

			//если он новый
			if (selected_item["is_new"].f_bool())
			{
				//вызываем его сознание
				f_cre_item(new t());
			}
			else
			{
				//иначе просто выбираем
				f_select_item();
			}
		}

		//выбор отмеченного элемента
		virtual public t f_select_item()
		{
			return new t();
		}

		//создание нового элемента
		virtual public t f_cre_item(t args)
		{

			t item = args["new item"];

			this._args["items"][0] = item;

			this._args["selected_item"] = item;

			lbx_items.Items.Clear();

			lbx_items.Items.Add(item);

			lbx_items.SelectedIndex = 0;

			t.f_f("f_done", this._args);

			//ds.f_hide();

			Hide();

			return new t();
		}

		//редактирование
		virtual public t f_modify_item(t args)
		{
			return new t();
		}

		//прикрепление
		virtual public t f_pick_item(t args)
		{
			return new t();
		}

		//удаление
		virtual public t f_drop_item(t args)
		{
			return new t();
		}

		//восстановление
		virtual public t f_revert_item(t args)
		{
			return new t();
		}

		//опциональное действие
		virtual public t f_opt(t args)
		{
			return new t();
		}

	}

	public partial class t_FlowLayoutPanel : FlowLayoutPanel
	{
		public t_FlowLayoutPanel()
		{
			this.SetStyle(ControlStyles.Opaque, true);
		}
		protected override CreateParams CreateParams
		{
			get
			{
				// Turn on the WS_EX_TRANSPARENT style
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;
				return cp;
			}
		}
	}

	public class t_customer
	{
		public string id;
		public string wd_idcustomer;
		public string name;
		public string phone;
		public List<string> phone_arr = new List<string>();
		public string email;
		//public string tab_address_id;
		//public string tab_address_name;
		//public string text = null;
		//public string wd_name=null;

		public t_customer()
		{

		}

		public t_customer(string id, string wd_idcustomer, string name, string phone, string email)
		{
			this.id = id;
			this.wd_idcustomer = wd_idcustomer;
			this.name = name;
			this.phone = phone;
			this.email = email;
			//MessageBox.Show(tab_address_name);
			//this.tab_address_id = tab_address_id;
			//this.tab_address_name = tab_address_name;
			//MessageBox.Show(this.tab_address_name);
		}

		public override string ToString()
		{
			//
			return fnotvarstr(name, 50, ' ') + fnotvarstr(phone, 30, ' ') + fnotvarstr(email, 30, ' ');// +tab_address_name;
			return name + "       " + phone + "           " + email;// +"       " + tab_address_name;
		}

		string fnotvarstr(string str, int len, char fill)
		{
			int cnt = len - str.Length;
			string conststr = str + new string(fill, cnt < 0 ? 0 : cnt);
			return conststr;
		}
	}

}