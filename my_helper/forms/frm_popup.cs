using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using kibicom.tlib;

namespace kibicom.my_wd_helper.forms
{
	public partial class frm_popup : Form, ikibifrm
	{
		public t _args = new t();

		public t args
		{
			get { return _args; }
			set { _args = value; }
		}

		public frm_popup()
		{
			InitializeComponent();
		}

		public frm_popup(t args)
		{
			ControlBox = false;
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
				return;
			}

			if (message.Msg == WM_ACTIVATE && 1 == 0)
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

				baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOPMOST | WS_EX_TOOLWINDOW | WS_EX_WINDOWEDGE);

				return baseParams;
			}
		}

	}
}
