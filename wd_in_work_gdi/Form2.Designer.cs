namespace wd_in_work_gdi
{
	partial class Form2
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
			this.label1 = new System.Windows.Forms.Label();
			this.txt_idorderitem = new System.Windows.Forms.TextBox();
			this.rtxt_log = new System.Windows.Forms.RichTextBox();
			this.btn_ok = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "idorderitem";
			// 
			// txt_idorderitem
			// 
			this.txt_idorderitem.Location = new System.Drawing.Point(97, 6);
			this.txt_idorderitem.Name = "txt_idorderitem";
			this.txt_idorderitem.Size = new System.Drawing.Size(100, 22);
			this.txt_idorderitem.TabIndex = 1;
			// 
			// rtxt_log
			// 
			this.rtxt_log.Location = new System.Drawing.Point(12, 40);
			this.rtxt_log.Name = "rtxt_log";
			this.rtxt_log.Size = new System.Drawing.Size(981, 468);
			this.rtxt_log.TabIndex = 2;
			this.rtxt_log.Text = "";
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(203, 5);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(102, 23);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "button1";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1005, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "m_main";
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1005, 520);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.rtxt_log);
			this.Controls.Add(this.txt_idorderitem);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_idorderitem;
		private System.Windows.Forms.RichTextBox rtxt_log;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}