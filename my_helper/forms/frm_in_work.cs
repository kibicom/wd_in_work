using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using kibicom;
using kibicom.tlib;

namespace kibicom.my_wd_helper
{
	public partial class frm_in_work : Form, ikibifrm
	{
		public t _args = new t();

		public t args
		{
			get{return _args;}
			set { _args = value; }
		}

		public frm_in_work()
		{
			InitializeComponent();
		}

		public frm_in_work(string fio):this()
		{
			//txt_address.Text = fio;
			//textBox1.
		}

		public frm_in_work(t args): this()
		{
			Owner = args["owner"].f_val<Form>();

			this._args["owner"].f_set(Owner);

			this._args["self"].f_set(this);

			this._args["max_duration"] = args["max_duration"];
			this._args["max_res_name"] = args["max_res_name"];

			this._args["f_give_to_work"] = args["f_give_to_work"];
			this._args["f_give_to_check"] = args["f_give_to_check"];

			lbl_duration_max.Text = args["max_duration"].f_str();

			InitLayout();
		}

		#region события

		private void btn_give_to_check_Click(object sender, EventArgs e)
		{
			t.f_f("f_give_to_work", this._args);
		}

		private void btn_give_to_work_Click(object sender, EventArgs e)
		{
			t.f_f("f_give_to_check", this._args);
		}

		private void frm_Deactivate(object sender, EventArgs e)
		{
			_args["is_shown"].f_set(false);
			f_leaved(this._args);
			return;
			if (!this._args["is_blocked"].f_def(false).f_bool())
			{
				this._args["is_shown"].f_set(false);
				f_leaved(this._args);
				Hide();
			}
			if (Owner != null)
			{
				//Owner.Activate();
			}

		}
		
		//форма деактивирована
		virtual public t f_leaved(t args)
		{

			t.f_f("f_leaved", this._args);

			return new t();
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

			if (message.Msg == WM_ACTIVATE && 1 == 0)
			{
				if (message.WParam == new IntPtr(0))
				{
					frm_Deactivate(null, null);
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

		public t f_set_duration(t args)
		{
			this._args["max_duration"] = args["max_duration"];
			this._args["max_res_name"] = args["max_res_name"];

			lbl_duration_max.Text = args["max_duration"].f_str();

			return new t();
		}

		public t f_set_msg(t args)
		{
			this._args["msg"] = args["msg"];
			this._args["msg_1"] = args["msg_1"];

			lbl_msg.Text = args["msg"].f_str();
			lbl_msg_1.Text = args["msg_1"].f_str();

			return new t();
		}
	}
}
