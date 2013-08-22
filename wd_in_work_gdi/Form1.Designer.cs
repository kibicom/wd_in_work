namespace wd_in_work_gdi
{
	partial class Form1
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
			this.btn_get_num = new System.Windows.Forms.Button();
			this.txt_num = new System.Windows.Forms.TextBox();
			this.btn_order_to_kibicom = new System.Windows.Forms.Button();
			this.txt_order_name = new System.Windows.Forms.TextBox();
			this.btn_store_stages = new System.Windows.Forms.Button();
			this.rtxt_log = new System.Windows.Forms.RichTextBox();
			this.btn_clear_log = new System.Windows.Forms.Button();
			this.txt_idorder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_get_num
			// 
			this.btn_get_num.Location = new System.Drawing.Point(12, 12);
			this.btn_get_num.Name = "btn_get_num";
			this.btn_get_num.Size = new System.Drawing.Size(172, 62);
			this.btn_get_num.TabIndex = 0;
			this.btn_get_num.Text = "Получить номер";
			this.btn_get_num.UseVisualStyleBackColor = true;
			this.btn_get_num.Click += new System.EventHandler(this.button1_Click);
			// 
			// txt_num
			// 
			this.txt_num.Location = new System.Drawing.Point(12, 210);
			this.txt_num.Name = "txt_num";
			this.txt_num.Size = new System.Drawing.Size(172, 22);
			this.txt_num.TabIndex = 1;
			// 
			// btn_order_to_kibicom
			// 
			this.btn_order_to_kibicom.Location = new System.Drawing.Point(12, 80);
			this.btn_order_to_kibicom.Name = "btn_order_to_kibicom";
			this.btn_order_to_kibicom.Size = new System.Drawing.Size(172, 59);
			this.btn_order_to_kibicom.TabIndex = 2;
			this.btn_order_to_kibicom.Text = "Выгрузить заказ";
			this.btn_order_to_kibicom.UseVisualStyleBackColor = true;
			this.btn_order_to_kibicom.Click += new System.EventHandler(this.btn_order_to_kibicom_Click);
			// 
			// txt_order_name
			// 
			this.txt_order_name.Location = new System.Drawing.Point(12, 238);
			this.txt_order_name.Name = "txt_order_name";
			this.txt_order_name.Size = new System.Drawing.Size(172, 22);
			this.txt_order_name.TabIndex = 1;
			// 
			// btn_store_stages
			// 
			this.btn_store_stages.Location = new System.Drawing.Point(12, 145);
			this.btn_store_stages.Name = "btn_store_stages";
			this.btn_store_stages.Size = new System.Drawing.Size(172, 59);
			this.btn_store_stages.TabIndex = 2;
			this.btn_store_stages.Text = "Выгрузить этапы";
			this.btn_store_stages.UseVisualStyleBackColor = true;
			this.btn_store_stages.Click += new System.EventHandler(this.btn_store_stages_Click);
			// 
			// rtxt_log
			// 
			this.rtxt_log.Location = new System.Drawing.Point(190, 12);
			this.rtxt_log.Name = "rtxt_log";
			this.rtxt_log.Size = new System.Drawing.Size(832, 422);
			this.rtxt_log.TabIndex = 3;
			this.rtxt_log.Text = "";
			// 
			// btn_clear_log
			// 
			this.btn_clear_log.Location = new System.Drawing.Point(12, 375);
			this.btn_clear_log.Name = "btn_clear_log";
			this.btn_clear_log.Size = new System.Drawing.Size(172, 59);
			this.btn_clear_log.TabIndex = 2;
			this.btn_clear_log.Text = "Очистить лог";
			this.btn_clear_log.UseVisualStyleBackColor = true;
			this.btn_clear_log.Click += new System.EventHandler(this.btn_clear_log_Click);
			// 
			// txt_idorder
			// 
			this.txt_idorder.Location = new System.Drawing.Point(12, 309);
			this.txt_idorder.Name = "txt_idorder";
			this.txt_idorder.Size = new System.Drawing.Size(172, 22);
			this.txt_idorder.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 286);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "idorder";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 446);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rtxt_log);
			this.Controls.Add(this.btn_clear_log);
			this.Controls.Add(this.btn_store_stages);
			this.Controls.Add(this.btn_order_to_kibicom);
			this.Controls.Add(this.txt_idorder);
			this.Controls.Add(this.txt_order_name);
			this.Controls.Add(this.txt_num);
			this.Controls.Add(this.btn_get_num);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_get_num;
		private System.Windows.Forms.TextBox txt_num;
		private System.Windows.Forms.Button btn_order_to_kibicom;
		private System.Windows.Forms.TextBox txt_order_name;
		private System.Windows.Forms.Button btn_store_stages;
		private System.Windows.Forms.RichTextBox rtxt_log;
		private System.Windows.Forms.Button btn_clear_log;
		private System.Windows.Forms.TextBox txt_idorder;
		private System.Windows.Forms.Label label1;
	}
}

