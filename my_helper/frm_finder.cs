using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using customer_info;
using josi;
//using josi.store.res;
using kibicom.tlib;
using kibicom.josi;


namespace my_helper
{

	
	public partial class frm_finder : Form
	{

		public bool is_shown = false;

		//������ �������� � josi
		//t_josi_store josi_store = new t_josi_store(new t_josi_auth_args("dnclive", "135"));
		public t_store josi_store =null;// new t_store(new t(){{"login_name","dnclive"}, {"pass","135"}});

		public t_kwj kwj = new t_kwj(new t(){{"local_db",new t(){{"file_name","kibicom_wd_josi.db"}}}});

		//����� ���������� ������� �� �������
		public TimeSpan last_key_down;

		//��������� �������� ������� txt_query
		public string last_filter_val = "";

		//���� - ����� �� ���������� ������������ ���������� �������
		//public bool show_result=true;

		//���������, ��� ��������� �������
		//public t selected_item;

		//public t tab=new t();

		//���������� ��������� ���� �� listbox
		Point last_lbx_mouse_point;

		//���������
		public t args=new t();

		//����� ����� ������/�������������� ��������
		public Form frm_cre_edit_item;

		public frm_finder()
		{
			InitializeComponent();
		}

		public frm_finder(t args)
			: this()
		{
			string login_name = args["login_name"].f_def("dnclive").f_str();
			string pass = args["pass"].f_def("135").f_str();
			string josi_end_point = args["josi_end_point"].
				//f_def("https://192.168.1.139/webproj/git/kibicom_venta/index.php").f_str();
				f_def("https://192.168.1.37/webproj/git/kibicom_venta/index.php").f_str();

			josi_store = new t_store(new t()
			{
				{"josi_end_point", josi_end_point},		//����� ����������� josi
				{"req_timeout", args["req_timeout"].f_def(5000).f_int()},	//������� �������
				{"login_name",login_name},				//��� ��� �����
				{"pass",pass},							//������ ��� �����
				{"login_on_cre", true},					//���������
				{"auth_try_count", args["auth_try_count"].f_def(3).f_int()},	//���������� ������� �����������
				{"f_done", args["f_done"].f_f()},		//�������� ����� ������������ �������
				{"f_fail", args["f_fail"].f_f()}		//�������� ���� ����������� �� �������
			});

			args["login_name"] = new t(login_name);
			args["pass"] = new t(pass);
			args["josi_end_point"] = new t(josi_end_point);
		}

		#region �������

		//������� �� ������ � ������ ������
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
		
		//���������� ������ � ������ ������
		private void txt_query_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
			{
				return;
			}

			if (txt_query.Text.Length < 2)
			{

				lbx_items.Items.Clear();
				btn_change.Visible = false;
				//show_result = false;
				return;
			}

			if (last_filter_val == txt_query.Text)
			{
				//show_result = false;
				return;
			}

			last_filter_val = txt_query.Text;

			f_find(new t());
			
			

		}

		//����� ����������
		private void josi_customer_Shown(object sender, EventArgs e)
		{
			txt_query.Focus();
		}

		//����� ��������� � listbox
		private void lbx_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			//MessageBox.Show("lbx");
			ListBox lbx = (ListBox)sender;

			//���� � ������ ��� ��������� ������ ������������� �������
			if (lbx.Items.Count == 0 || e.Index < 0)
			{
				return;
			}

			//�������� ������ �������� ������� � t_customer
			t item = (t)lbx.Items[e.Index];

			// Draw the background of the ListBox control for each item.
			e.DrawBackground();
			// Define the default color of the brush as black.
			//Brush text_brush = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#333"));

			//Brush b1 = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#0099cc"));

			//Font text_font = e.Font;

			//������������ ������� ���������� �������
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				//������ ������������ ����������� �������� (���)
				e.Graphics.FillRectangle(new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#0099cc")), e.Bounds);
				//text_brush = SystemBrushes.HighlightText;
				//text_brush = new System.Drawing.SolidBrush(ColorTranslator.FromHtml("#9cc"));
				//text_font = new Font(e.Font, FontStyle.Bold);

				//������� fio ������� � ������ �������
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str1"].f_str(),
					new Font(e.Font, FontStyle.Bold),	//����� ������ ������
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//���� ������
					new SolidBrush(ColorTranslator.FromHtml("#333")),	//���� ����
					//������������� � ������� ��������� �����
					new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
				);

				//������ �������� � email �� ������ ������
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str2"].f_str(),
					e.Font,			//����� ��������� ����������
					new SolidBrush(ColorTranslator.FromHtml("#eee")),	//���� ������
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//���� ����
					//������������� � ������� ��������� ����� - ������ �� 31 ������� �� ��������� (����� ������ ������)
					new Rectangle(e.Bounds.X, e.Bounds.Y + 31, e.Bounds.Width, e.Bounds.Height)
				);

				//������� ������ �������������� �� ���������� ��������
				RectangleF rect = e.Bounds;
				btn_change.Top = Convert.ToInt32(lbx_items.Top + rect.Top + rect.Height / 2 - btn_change.Height / 2);
				btn_change.Left = Convert.ToInt32(lbx_items.Left + rect.Right - rect.Height / 2 + btn_change.Height / 2 - btn_change.Width);

			}
			else	//������������ �� ���������� ��������
			{
				//�������� ������ ����� ����� ���
				if (e.Index % 2 == 0)
				{
					e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#fff")), e.Bounds);
				}
				else//������ ������ �����
				{
					e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#eee")), e.Bounds);
				}

				//������� fio ������� � ������ �������
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str1"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#333")),	//���� ������
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//���� ����
					e.Bounds
				);
				//������ �������� � email �� ������ ������
				t_uti.f_draw_text
				(
					e.Graphics,
					item["str2"].f_str(),
					e.Font,
					new SolidBrush(ColorTranslator.FromHtml("#555")),	//���� ������
					new SolidBrush(ColorTranslator.FromHtml("#fff")),	//���� ����
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
			btn_change.Visible = true;
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
			}

		}

		private void josi_customer_Deactivate(object sender, EventArgs e)
		{
			is_shown = false;
			Hide();
			if (frm_cre_edit_item != null)
			{
				frm_cre_edit_item.Activate();
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
			f_touch_lbx_item();
		}

		private void btn_change_Click(object sender, EventArgs e)
		{
			//�������� ���������� �������
			t selected_item = this.args["selected_item"].f_set((t)lbx_items.SelectedItem);

			//�������� ������� ��������������
			f_modify_item(new t() { { "item", selected_item } });
		}

		#endregion �������

		//��������� �����
		public void f_find(t args)
		{
			btn_change.Visible = false;

			this.args["items"].Clear();

			//���� ���� ����� �������� � ���� ���������� �� �����
			if (this.args["new_items"].Count > 0)
			{
				foreach (t new_item in (IList<t>) this.args["new_items"])
				{
					this.args["items"].Add(new_item);
				}

				this.args["new_items"].Clear();

				f_fill_lbx(args);
			}

			pb_loading_2.Show();

			f_get_items(new t());
		}

		//��������� ��������� �� ���������
		virtual public t f_get_items(t args)
		{

			return new t();
		}

		//���������� listbox ����������� ����������
		virtual public t f_fill_lbx(t args)
		{

			t_f<t,t> f=new t_f<t, t>(delegate(t args1)
			{
				pb_loading_2.Hide();

				//���� ���������� ������������ ����������� 0
				//�� ��������� ����� �������
				if (this.args["items"].Count == 0)
				{
					f_add_new();
				}

				//�������
				lbx_items.Items.Clear();

				//��������� � �������� ������
				foreach (t item in (IList<t>)this.args["items"])
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

		//���� ������� ������� ����, ���������� ������� ����� ������� �������
		virtual public void f_add_new()
		{
			this.args["items"].Add(new t()
			{
				{"str1",this.args["new_item_caption"].f_def("�������� ����� �������")},
				{"str2",txt_query.Text},
				{"is_new", true}
			});
		}

		//����� �������� listbox
		virtual public void f_touch_lbx_item()
		{
			//�������� ���������� �������
			t selected_item=this.args["selected_item"].f_set((t)lbx_items.SelectedItem);

			//���� �� �����
			if (selected_item["is_new"].f_bool())
			{
				//�������� ��� ��������
				f_cre_item(new t());
			}
			else
			{
				//����� ������ ��������
				f_select_item();
			}
		}

		//����� ����������� ��������
		virtual public t f_select_item()
		{
			return new t();
		}

		//�������� ������ ��������
		virtual public t f_cre_item(t args)
		{

			t item = args["new item"];

			this.args["items"][0] = item;

			this.args["selected_item"] = item;

			lbx_items.Items.Clear();

			lbx_items.Items.Add(item);

			lbx_items.SelectedIndex = 0;

			t.f_f("f_done", this.args);

			Hide();

			return new t();
		}

		virtual public t f_modify_item(t args)
		{
			return new t();
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