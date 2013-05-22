using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace my_helper
{
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
}
