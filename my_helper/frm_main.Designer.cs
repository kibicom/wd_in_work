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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_close = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_add_customer
			// 
			this.btn_add_customer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_add_customer.BackColor = System.Drawing.Color.Transparent;
			this.btn_add_customer.FlatAppearance.BorderSize = 0;
			this.btn_add_customer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_customer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_customer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_add_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_add_customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btn_add_customer.Location = new System.Drawing.Point(3, 3);
			this.btn_add_customer.Name = "btn_add_customer";
			this.btn_add_customer.Size = new System.Drawing.Size(238, 49);
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
			this.btn_add_address.Location = new System.Drawing.Point(3, 58);
			this.btn_add_address.Name = "btn_add_address";
			this.btn_add_address.Size = new System.Drawing.Size(238, 49);
			this.btn_add_address.TabIndex = 0;
			this.btn_add_address.Text = "Добавить адрес";
			this.btn_add_address.UseVisualStyleBackColor = true;
			this.btn_add_address.Click += new System.EventHandler(this.btn_add_address_Click);
			// 
			// btn_add_pay
			// 
			this.btn_add_pay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_add_pay.FlatAppearance.BorderSize = 0;
			this.btn_add_pay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.btn_add_pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_add_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_add_pay.Location = new System.Drawing.Point(3, 113);
			this.btn_add_pay.Name = "btn_add_pay";
			this.btn_add_pay.Size = new System.Drawing.Size(238, 49);
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
			this.btn_take_in_work.Location = new System.Drawing.Point(3, 168);
			this.btn_take_in_work.Name = "btn_take_in_work";
			this.btn_take_in_work.Size = new System.Drawing.Size(237, 86);
			this.btn_take_in_work.TabIndex = 0;
			this.btn_take_in_work.Text = "Запросить срок изготовления";
			this.btn_take_in_work.UseVisualStyleBackColor = true;
			this.btn_take_in_work.Click += new System.EventHandler(this.button4_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btn_add_customer);
			this.flowLayoutPanel1.Controls.Add(this.btn_add_address);
			this.flowLayoutPanel1.Controls.Add(this.btn_add_pay);
			this.flowLayoutPanel1.Controls.Add(this.btn_take_in_work);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 46);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 345);
			this.flowLayoutPanel1.TabIndex = 1;
			this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.frm_main_MouseLeave);
			this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_main_MouseMove);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.flowLayoutPanel2.Controls.Add(this.btn_close);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(260, 40);
			this.flowLayoutPanel2.TabIndex = 2;
			this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
			this.flowLayoutPanel2.MouseEnter += new System.EventHandler(this.frm_main_MouseEnter);
			// 
			// btn_close
			// 
			this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_close.Location = new System.Drawing.Point(215, 3);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(42, 37);
			this.btn_close.TabIndex = 0;
			this.btn_close.Text = "X";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// frm_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(260, 400);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
			this.Click += new System.EventHandler(this.frm_main_Click);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_add_customer;
		private System.Windows.Forms.Button btn_add_address;
		private System.Windows.Forms.Button btn_add_pay;
		private System.Windows.Forms.Button btn_take_in_work;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Button btn_close;
	}
}

