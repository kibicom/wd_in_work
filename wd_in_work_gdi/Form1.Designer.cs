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
			this.txt_num.Location = new System.Drawing.Point(190, 32);
			this.txt_num.Name = "txt_num";
			this.txt_num.Size = new System.Drawing.Size(200, 22);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 363);
			this.Controls.Add(this.btn_order_to_kibicom);
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
	}
}

