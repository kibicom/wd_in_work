namespace my_helper
{
	partial class frm_main
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
			this.btn_add_customer = new System.Windows.Forms.Button();
			this.btn_add_address = new System.Windows.Forms.Button();
			this.btn_add_pay = new System.Windows.Forms.Button();
			this.btn_take_in_work = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_add_customer
			// 
			this.btn_add_customer.BackColor = System.Drawing.Color.Transparent;
			this.btn_add_customer.FlatAppearance.BorderSize = 0;
			this.btn_add_customer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_add_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_add_customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_add_customer.Location = new System.Drawing.Point(12, 12);
			this.btn_add_customer.Name = "btn_add_customer";
			this.btn_add_customer.Size = new System.Drawing.Size(251, 49);
			this.btn_add_customer.TabIndex = 0;
			this.btn_add_customer.Text = "Добавить заказчика";
			this.btn_add_customer.UseVisualStyleBackColor = false;
			this.btn_add_customer.Click += new System.EventHandler(this.btn_add_customer_Click);
			// 
			// btn_add_address
			// 
			this.btn_add_address.FlatAppearance.BorderSize = 0;
			this.btn_add_address.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_address.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_address.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_add_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_add_address.Location = new System.Drawing.Point(12, 67);
			this.btn_add_address.Name = "btn_add_address";
			this.btn_add_address.Size = new System.Drawing.Size(251, 49);
			this.btn_add_address.TabIndex = 0;
			this.btn_add_address.Text = "Добавить адрес";
			this.btn_add_address.UseVisualStyleBackColor = true;
			// 
			// btn_add_pay
			// 
			this.btn_add_pay.FlatAppearance.BorderSize = 0;
			this.btn_add_pay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_add_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_add_pay.Location = new System.Drawing.Point(12, 122);
			this.btn_add_pay.Name = "btn_add_pay";
			this.btn_add_pay.Size = new System.Drawing.Size(251, 49);
			this.btn_add_pay.TabIndex = 0;
			this.btn_add_pay.Text = "Внести платеж";
			this.btn_add_pay.UseVisualStyleBackColor = true;
			this.btn_add_pay.Click += new System.EventHandler(this.button4_Click);
			// 
			// btn_take_in_work
			// 
			this.btn_take_in_work.FlatAppearance.BorderSize = 0;
			this.btn_take_in_work.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_take_in_work.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_take_in_work.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_take_in_work.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_take_in_work.Location = new System.Drawing.Point(12, 177);
			this.btn_take_in_work.Name = "btn_take_in_work";
			this.btn_take_in_work.Size = new System.Drawing.Size(251, 71);
			this.btn_take_in_work.TabIndex = 0;
			this.btn_take_in_work.Text = "Запросить срок изготовления";
			this.btn_take_in_work.UseVisualStyleBackColor = true;
			this.btn_take_in_work.Click += new System.EventHandler(this.button4_Click);
			// 
			// frm_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(275, 264);
			this.Controls.Add(this.btn_take_in_work);
			this.Controls.Add(this.btn_add_pay);
			this.Controls.Add(this.btn_add_address);
			this.Controls.Add(this.btn_add_customer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_main";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "My helper";
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.frm_main_Activated);
			this.Shown += new System.EventHandler(this.frm_main_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_add_customer;
		private System.Windows.Forms.Button btn_add_address;
		private System.Windows.Forms.Button btn_add_pay;
		private System.Windows.Forms.Button btn_take_in_work;
	}
}

