namespace frm_wd_print_etk
{
	partial class frm_wd_print_etk
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
			this.chbl_what_print = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_print = new System.Windows.Forms.Button();
			this.btn_exit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chbl_what_print
			// 
			this.chbl_what_print.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.chbl_what_print.FormattingEnabled = true;
			this.chbl_what_print.Items.AddRange(new object[] {
            "Отливы",
            "Подоконники",
            "Соединители",
            "Откосы внутренние",
            "Откосы наружние",
            "Москитки",
            "Сендвич"});
			this.chbl_what_print.Location = new System.Drawing.Point(12, 34);
			this.chbl_what_print.Name = "chbl_what_print";
			this.chbl_what_print.Size = new System.Drawing.Size(371, 290);
			this.chbl_what_print.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "Печетать";
			// 
			// btn_print
			// 
			this.btn_print.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_print.Location = new System.Drawing.Point(277, 362);
			this.btn_print.Name = "btn_print";
			this.btn_print.Size = new System.Drawing.Size(106, 39);
			this.btn_print.TabIndex = 2;
			this.btn_print.Text = "Печетать";
			this.btn_print.UseVisualStyleBackColor = true;
			// 
			// btn_exit
			// 
			this.btn_exit.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_exit.Location = new System.Drawing.Point(12, 362);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(106, 39);
			this.btn_exit.TabIndex = 2;
			this.btn_exit.Text = "Выйти";
			this.btn_exit.UseVisualStyleBackColor = true;
			// 
			// frm_wd_print_etk
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(395, 413);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.btn_print);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chbl_what_print);
			this.Name = "frm_wd_print_etk";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Печатаю этикетки";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frm_wd_print_etk_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox chbl_what_print;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button btn_print;
		public System.Windows.Forms.Button btn_exit;
	}
}

