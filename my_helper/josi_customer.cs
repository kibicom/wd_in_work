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
using kibicom;


namespace josi.store
{

	
	public partial class josi_customer : Form
	{

		public bool is_shown = false;

		//объект запросов к josi
		//t_josi_store josi_store = new t_josi_store(new t_josi_auth_args("dnclive", "135"));
		t_store josi_store =null;// new t_store(new t(){{"login_name","dnclive"}, {"pass","135"}});

		//время последнего нажатия на клавишу
		public TimeSpan last_key_down;

		//последнее значение фильтра txt_query
		public string last_filter_val = "";

		//флаг - нужно ли показывать возвращенные результаты запроса
		public bool show_result=true;

		//выбранный, или созданный клиента
		t selected_customer;

		t tab_customer=new t();

		//предыдущее положение мыщи на listbox
		Point last_lbx_mouse_point;

		//аргументы
		public t args=new t();

		//форма ввода нового контрагента
		customer_info_form cif_form;

		public josi_customer()
		{
			InitializeComponent();
		}

		public josi_customer(t args):this()
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_end_point"].
				f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				//f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();

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

			args["login_name"] = new t(login_name);
			args["pass"] = new t(pass);
			args["josi_end_point"] = new t(josi_end_point);
		}

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

				f_select_cust();

			}
			
		}
		
		//отпускание кнопки в строке поиска
		private void txt_query_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
			{
				return;
			}

			if (txt_query.Text.Length < 2)
			{

				lbx_items.Items.Clear();
				show_result = false;
				return;
			}

			if (last_filter_val == txt_query.Text)
			{
				//show_result = false;
				return;
			}

			last_filter_val = txt_query.Text;
			show_result = true;

			string res_dot_key_query_str =	"&kvl.1.where.tab_customer.0._query.entry.0=name" +
											"&kvl.1.where.tab_customer.0.id=" +
											"&kvl.1.where.tab_customer.0.name=" + txt_query.Text +
											"&kvl.1.where.tab_customer.0.phone=" +
											"&kvl.1.where.tab_customer.0.email=";

			t query = new t()
			{
				{
					"_query",new t()
					{
						{
							"entry", new t()
							{
								"name"
							}
						}
					}
				},
				{"id", ""},
				{"name", txt_query.Text},
				{"phone", ""},
				{"email", ""}
			};

			//выполняем запрос
			josi_store.f_store(new t 
			{
				//{"res_dot_key_query_str",res_dot_key_query_str},
				//когда возвращен ответ
				{"needs", new t(){"is_auth_done"}},		//когда выполниться процесс авторизации
				{"method", "POST"},
				{
					"get_tab_arr", new t()
					{
						{"tab_customer", new t(){query}}
					}
				},
				{
					//когда получен id
					//сохраняем заказ с учетом полученного id
					"f_done", new t_f<t,t>(delegate(t args1)
					{

						if (lbx_items.InvokeRequired)
						{
							lbx_items.Invoke(new t_f<t,t>(ffill_lbx_items), new object[] {args1});
						}

						return new t();
					})
				},
				{"encode_json",true},
				{"cancel_prev",false},
			});

			/*
			josi_store.f_store(new t 
			{
				{"res_dot_key_query_str",res_dot_key_query_str},
				{
					"f_done",	
					new t_f<t,t>(delegate(t args)
					{
						//MessageBox.Show("123");
						//string resp_str = ((t_josi_store_req_args)args).resp_str;
						//Dictionary <string, object> resp_json=((t_josi_store_req_args)args).resp_json;
						//TimeSpan query_start = ((t_josi_store_req_args)args).query_start;

						if (lbx_items.InvokeRequired)
						{
							lbx_items.Invoke(new t_f<t,t>(ffill_lbx_items), new object[] {args});
						}

						return null;
					})
				},
				{"encode_json",true},
				{"cancel_prev",true},
			});

			*/

			/*
			josi_store.f_store(new t_josi_store_req_args
			(
				res_dot_key_query_str,
				delegate(t_josi_store_req_args args)
				{
					//MessageBox.Show("123");
					//string resp_str = ((t_josi_store_req_args)args).resp_str;
					//Dictionary <string, object> resp_json=((t_josi_store_req_args)args).resp_json;
					//TimeSpan query_start = ((t_josi_store_req_args)args).query_start;

					if (lbx_items.InvokeRequired)
					{
						lbx_items.Invoke(new Action<t_josi_store_req_args>(ffill_lbx_items), new object[] {args});
					}
				},
				true, true
			));
			*/
			pb_loading_2.Show();

		}

		//заполняем список результатами запроса
		private t ffill_lbx_items(t args)
		{

			pb_loading_2.Hide();

			//если ответ null то не удалось связаться с сервером
			//или если результаты показывать не нужно
			if (args["resp_json"].f_val() == null || !show_result)
			{
				return null;
			}

			richTextBox1.Text = args["query_str"].f_str() + "\r\n";

			richTextBox1.Text += args["resp_str"].f_str();

            
			//очищаем список
			lbx_items.Items.Clear();

			//foreach (string tab in json_obj.Keys)
			//{
			string tab = "tab_customer";
			ArrayList tab_rows = (ArrayList)args["resp_json"].f_val<Dictionary<string, object>>()[tab];

			//если количество возвращенных результатов 0
			//то предлагаем создать нового контрагента
			if (tab_rows.Count == 0)
			{
				f_add_new();
			}

			//int lbx_items_selected_index==

			foreach (Dictionary<string, object> row in tab_rows)
			{
				//string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";

				string row_id = row.ContainsKey("id") && row["id"] != null ? row["id"].ToString() : "";
				string row_wd_idcustomer = row.ContainsKey("wd_idcustomer") && row["wd_idcustomer"] != null ? row["wd_idcustomer"].ToString() : "";
				string row_name = row.ContainsKey("name") && row["name"] != null ? row["name"].ToString() : "";
				string row_phone = row.ContainsKey("phone") && row["phone"] != null ? row["phone"].ToString() : "";
				string row_email = row.ContainsKey("email") && row["email"] != null ? row["email"].ToString() : "";
				//string row_address = row.ContainsKey("address") && row["address"] != null ? row["address"].ToString() : "";

				
				int int_wd_idcustomer = !int.TryParse(row_wd_idcustomer, out int_wd_idcustomer) ? int_wd_idcustomer : 0;


				lbx_items.Items.Add(new t()
				{
					{"id",row_id},
					{"wd_idcustomer",row_wd_idcustomer},
					{"name",row_name},
					{"phone",row_phone},
					{"email",row_email}//,
					//row_tab_address_id,
					/*row_tab_address_name*/
				});

				/*
				lbx_items.Items.Add(new t_customer(row_id,
									row_wd_idcustomer,
									row_name,
									row_phone,
									row_email//,
					//row_tab_address_id,
					/*row_tab_address_name));*/

			}
			lbx_items.SelectedIndex = 0;
			//lbx_items.Refresh();
			//}
			return null;
		}

		//если результ запроса пуст, предлагаем создать новый элемент ресурса
		public void f_add_new()
		{
            try
            {
                tab_customer["id"] = new t(30);
                //MessageBox.Show(tab_customer["id"].f_str());

				lbx_items.Items.Add(new t()
				{
					{"name","Добавить нового клиента"},
					{"phone",txt_query.Text},
				});

				/*
                lbx_items.Items.Add(new t_customer
                ("",
                    "",
                    "Добавить нового клиента",
                    txt_query.Text,
                    ""
                ));*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

		}

		//форма отображена
		private void josi_customer_Shown(object sender, EventArgs e)
		{
			txt_query.Focus();
		}

	
		//сохранение созданного клиента в josi_store
		private void fstore_customer()
		{
			//текст введенный менеджером - номер карты
			//string fio = txt_fio.Text;
			//string phone = txt_phone.Text;
			//string email = txt_email.Text;
			//string address = txt_address.Text;

			josi_store.f_gen_id(new t()
			{
				{"res_name","tab_customer"}, 
				{"id_key","id"},
				{
					"f_done",
					new t_f<t,t>(delegate(t args)
					{
						MessageBox.Show(args["id_str"].f_str());
						string id = args["id_str"].f_str();
						string res_dot_key_query_str =	"&kvl.1.tab_arr.tab_customer.0.id=" + id +
														"&kvl.1.tab_arr.tab_customer.0.name=" + selected_customer["name"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.phone=" + selected_customer["phone"].f_str() +
														"&kvl.1.tab_arr.tab_customer.0.email=" + selected_customer["email"].f_str();


						josi_store.f_store(new t()
						{
							{"res_dot_key_query_str",res_dot_key_query_str},
							{
								"f_done",
								new t_f<t,t>(delegate(t args1)
								{
									MessageBox.Show(args1["resp_str"].f_str());
									return null;
								})
							},
							{"encode_json",true},
							{"cancel_prev",true},
						});

						/*
						josi_store.f_store(new t_josi_store_req_args
						(
							res_dot_key_query_str,
							delegate(t_josi_store_req_args args1)
							{
								MessageBox.Show(args1.resp_str);
							}, 
							true, 
							true
						));
						 * */
						return null;
					})
				}
			});

			return;

		}

		//вывод элементов в listbox
		private void lbx_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			//MessageBox.Show("lbx");
			ListBox lbx = (ListBox)sender;

			//если в списке нет элементов нечего прорисовывать выходим
			if (lbx.Items.Count == 0||e.Index<0)
			{
				return;
			}

			//приводим ткущий рисуемый элемент к t_customer
			t customer = (t)lbx.Items[e.Index];

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
					customer["name"].f_str(),
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
					customer["phone"].f_str(),
					e.Font,			//текст оставляем нормальным
					new SolidBrush(ColorTranslator.FromHtml("#eee")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//цвет тени
					//прямоугольник в который выводится текст - смещен на 31 пиксель по вертикали (вывод второй строки)
					new Rectangle(e.Bounds.X, e.Bounds.Y + 31, e.Bounds.Width, e.Bounds.Height)
				);
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
					customer["name"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#333")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//цвет тени
					e.Bounds
				);
				//вывдим телефоны и email во второй строке
				t_uti.f_draw_text
				(
					e.Graphics,
					customer["phone"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//цвет текста
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//цвет тени
					new Rectangle(e.Bounds.X, e.Bounds.Y + 31, e.Bounds.Width, e.Bounds.Height)
				);

			}

			// If the ListBox has focus, draw a focus rectangle around the selected item.
			e.DrawFocusRectangle();
			//e.
		}

		private void lbx_items_Enter(object sender, EventArgs e)
		{
			//txt_query.Focus();
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

		private void lbx_items_MouseEnter(object sender, EventArgs e)
		{
			ListBox lbx = (ListBox)sender;
			//lbx.Focus();
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
			}

		}

		private void lbx_items_MouseHover(object sender, EventArgs e)
		{
			//MessageBox.Show("123");
		}

		private void josi_customer_Deactivate(object sender, EventArgs e)
		{
			is_shown = false;
			Hide();
			if (cif_form != null)
			{
				cif_form.Activate();
			}
			
		}

		private void josi_customer_FormClosing(object sender, FormClosingEventArgs e)
		{
			is_shown = false;
			Hide();
			e.Cancel = true;
		}

		private void lbx_items_Click(object sender, EventArgs e)
		{
			f_select_cust();
		}


		//выбор отмеченного контрагента
		private t f_select_cust()
		{
			if (((t)lbx_items.SelectedItem)["name"].f_str() == "Добавить нового клиента")
			{
				//создаем форму ввода данных нового контрагента
				cif_form = new customer_info_form(txt_query.Text);
				
				//показываем форму как диалог
				cif_form.ShowDialog();

				if (cif_form.args["is_done"].f_bool())
				{

				

					//в результате деактивации текущего окна (окна поиска)
					//оно скроется так как предыдущее окно было диалогом
					//сюда мы попадем когда его закроют - данные введут
					//поэтом вновь показываем себя
					Show();

					selected_customer = cif_form.customer;

					lbx_items.Items.Clear();

					lbx_items.Items.Add(selected_customer);

					lbx_items.SelectedIndex = 0;

					fstore_customer();

					args["customer"].f_set(selected_customer);

					t.f_f("f_done", args);

					Hide();


				}

			}
			else
			{
				selected_customer = (t)lbx_items.SelectedItem;

				args["customer"]=selected_customer;

				t.f_f("f_done", args);

				Hide();

			}

			


			return new t();
		}

	}


}