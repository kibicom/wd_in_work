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
	public partial class frm_in_work : Form
	{
		public t args = new t();

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

			this.args["owner"].f_set(Owner);

			this.args["max_duration"] = args["max_duration"];
			this.args["max_res_name"] = args["max_res_name"];

			this.args["f_give_to_work"] = args["f_give_to_work"];
			this.args["f_give_to_check"] = args["f_give_to_check"];

			lbl_duration_max.Text = args["max_duration"].f_str();

			InitLayout();
		}

		#region события

		private void btn_give_to_check_Click(object sender, EventArgs e)
		{
			t.f_f("f_give_to_work", this.args);
		}

		private void btn_give_to_work_Click(object sender, EventArgs e)
		{
			t.f_f("f_give_to_check", this.args);
		}

		private void frm_Deactivate(object sender, EventArgs e)
		{
			if (!this.args["is_blocked"].f_def(false).f_bool())
			{
				this.args["is_shown"].f_set(false);
				f_leaved(this.args);
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

			t.f_f("f_leaved", this.args);

			return new t();
		}

		#endregion события

		public t f_set_duration(t args)
		{
			this.args["max_duration"] = args["max_duration"];
			this.args["max_res_name"] = args["max_res_name"];

			lbl_duration_max.Text = args["max_duration"].f_str();

			return new t();
		}
	}
}
