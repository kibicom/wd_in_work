namespace kibicom.my_wd_helper
{
	partial class frm_in_work
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_give_to_work = new System.Windows.Forms.Button();
			this.btn_give_to_check = new System.Windows.Forms.Button();
			this.lbl_prev_date_capt = new System.Windows.Forms.Label();
			this.lbl_duration_max = new System.Windows.Forms.Label();
			this.lbl_msg = new System.Windows.Forms.Label();
			this.lbl_msg_1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_give_to_work
			// 
			this.btn_give_to_work.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_give_to_work.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_give_to_work.Location = new System.Drawing.Point(515, 338);
			this.btn_give_to_work.Name = "btn_give_to_work";
			this.btn_give_to_work.Size = new System.Drawing.Size(111, 40);
			this.btn_give_to_work.TabIndex = 0;
			this.btn_give_to_work.Text = "В работу";
			this.btn_give_to_work.UseVisualStyleBackColor = true;
			this.btn_give_to_work.Click += new System.EventHandler(this.btn_give_to_work_Click);
			// 
			// btn_give_to_check
			// 
			this.btn_give_to_check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_give_to_check.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_give_to_check.Location = new System.Drawing.Point(12, 338);
			this.btn_give_to_check.Name = "btn_give_to_check";
			this.btn_give_to_check.Size = new System.Drawing.Size(147, 40);
			this.btn_give_to_check.TabIndex = 1;
			this.btn_give_to_check.Text = "На проверку";
			this.btn_give_to_check.UseVisualStyleBackColor = true;
			this.btn_give_to_check.Click += new System.EventHandler(this.btn_give_to_check_Click);
			// 
			// lbl_prev_date_capt
			// 
			this.lbl_prev_date_capt.AutoSize = true;
			this.lbl_prev_date_capt.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_prev_date_capt.Location = new System.Drawing.Point(8, 9);
			this.lbl_prev_date_capt.Name = "lbl_prev_date_capt";
			this.lbl_prev_date_capt.Size = new System.Drawing.Size(579, 20);
			this.lbl_prev_date_capt.TabIndex = 2;
			this.lbl_prev_date_capt.Text = "Предварительный срок готовности через    календарных дней\r\n";
			// 
			// lbl_duration_max
			// 
			this.lbl_duration_max.AutoSize = true;
			this.lbl_duration_max.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_duration_max.Location = new System.Drawing.Point(386, 7);
			this.lbl_duration_max.Name = "lbl_duration_max";
			this.lbl_duration_max.Size = new System.Drawing.Size(22, 23);
			this.lbl_duration_max.TabIndex = 2;
			this.lbl_duration_max.Text = "7";
			// 
			// lbl_msg
			// 
			this.lbl_msg.AllowDrop = true;
			this.lbl_msg.AutoSize = true;
			this.lbl_msg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lbl_msg.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_msg.Location = new System.Drawing.Point(12, 82);
			this.lbl_msg.Name = "lbl_msg";
			this.lbl_msg.Size = new System.Drawing.Size(0, 23);
			this.lbl_msg.TabIndex = 2;
			// 
			// lbl_msg_1
			// 
			this.lbl_msg_1.AllowDrop = true;
			this.lbl_msg_1.AutoSize = true;
			this.lbl_msg_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lbl_msg_1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_msg_1.Location = new System.Drawing.Point(12, 139);
			this.lbl_msg_1.Name = "lbl_msg_1";
			this.lbl_msg_1.Size = new System.Drawing.Size(0, 23);
			this.lbl_msg_1.TabIndex = 2;
			// 
			// frm_in_work
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(638, 390);
			this.ControlBox = false;
			this.Controls.Add(this.lbl_duration_max);
			this.Controls.Add(this.lbl_msg_1);
			this.Controls.Add(this.lbl_msg);
			this.Controls.Add(this.lbl_prev_date_capt);
			this.Controls.Add(this.btn_give_to_check);
			this.Controls.Add(this.btn_give_to_work);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(656, 408);
			this.MinimizeBox = false;
			this.Name = "frm_in_work";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Deactivate += new System.EventHandler(this.frm_Deactivate);
			this.Shown += new System.EventHandler(this.frm_in_work_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button btn_give_to_work;
		public System.Windows.Forms.Button btn_give_to_check;
		public System.Windows.Forms.Label lbl_prev_date_capt;
		public System.Windows.Forms.Label lbl_duration_max;
		public System.Windows.Forms.Label lbl_msg;
		public System.Windows.Forms.Label lbl_msg_1;
	}
}