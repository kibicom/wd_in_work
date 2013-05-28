namespace my_helper
{
	partial class frm_conf
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
			this.btn_cre_kwj = new System.Windows.Forms.Button();
			this.btn_fill_tab_customer = new System.Windows.Forms.Button();
			this.btn_fill_tab_address = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_cre_kwj
			// 
			this.btn_cre_kwj.Location = new System.Drawing.Point(12, 12);
			this.btn_cre_kwj.Name = "btn_cre_kwj";
			this.btn_cre_kwj.Size = new System.Drawing.Size(161, 59);
			this.btn_cre_kwj.TabIndex = 0;
			this.btn_cre_kwj.Text = "Создать kibicom_wd_josi.db";
			this.btn_cre_kwj.UseVisualStyleBackColor = true;
			this.btn_cre_kwj.Click += new System.EventHandler(this.btn_cre_kwj_Click);
			// 
			// btn_fill_tab_customer
			// 
			this.btn_fill_tab_customer.Location = new System.Drawing.Point(12, 77);
			this.btn_fill_tab_customer.Name = "btn_fill_tab_customer";
			this.btn_fill_tab_customer.Size = new System.Drawing.Size(161, 62);
			this.btn_fill_tab_customer.TabIndex = 1;
			this.btn_fill_tab_customer.Text = "Заполнить tab_customer";
			this.btn_fill_tab_customer.UseVisualStyleBackColor = true;
			this.btn_fill_tab_customer.Click += new System.EventHandler(this.btn_fill_from_kibicom_Click);
			// 
			// btn_fill_tab_address
			// 
			this.btn_fill_tab_address.Location = new System.Drawing.Point(179, 77);
			this.btn_fill_tab_address.Name = "btn_fill_tab_address";
			this.btn_fill_tab_address.Size = new System.Drawing.Size(161, 62);
			this.btn_fill_tab_address.TabIndex = 1;
			this.btn_fill_tab_address.Text = "Заполнить tab_address";
			this.btn_fill_tab_address.UseVisualStyleBackColor = true;
			this.btn_fill_tab_address.Click += new System.EventHandler(this.btn_fill_tab_address_Click);
			// 
			// frm_conf
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 395);
			this.Controls.Add(this.btn_fill_tab_address);
			this.Controls.Add(this.btn_fill_tab_customer);
			this.Controls.Add(this.btn_cre_kwj);
			this.Name = "frm_conf";
			this.Text = "frm_conf";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_cre_kwj;
		private System.Windows.Forms.Button btn_fill_tab_customer;
		private System.Windows.Forms.Button btn_fill_tab_address;
	}
}