using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using josi.store;

using kibicom.tlib;

namespace kibicom.my_wd_helper
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new kibicom_mwh_frm_main(new t()));
			//Application.Run(new josi_customer());
			Application.Run(new frm_conf());
		}
	}
}
