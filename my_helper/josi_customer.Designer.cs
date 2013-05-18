namespace josi.store
{
	partial class josi_customer
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
			this.txt_query = new System.Windows.Forms.TextBox();
			this.lbx_items = new System.Windows.Forms.ListBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.pb_loading_2 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// txt_query
			// 
			this.txt_query.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_query.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_query.Location = new System.Drawing.Point(11, 12);
			this.txt_query.Name = "txt_query";
			this.txt_query.Size = new System.Drawing.Size(871, 34);
			this.txt_query.TabIndex = 0;
			this.txt_query.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.txt_query.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_query_KeyUp);
			// 
			// lbx_items
			// 
			this.lbx_items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbx_items.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lbx_items.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbx_items.FormattingEnabled = true;
			this.lbx_items.ItemHeight = 63;
			this.lbx_items.Location = new System.Drawing.Point(12, 47);
			this.lbx_items.Name = "lbx_items";
			this.lbx_items.Size = new System.Drawing.Size(870, 359);
			this.lbx_items.TabIndex = 1;
			this.lbx_items.Click += new System.EventHandler(this.lbx_items_Click);
			this.lbx_items.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbx_DrawItem);
			this.lbx_items.Enter += new System.EventHandler(this.lbx_items_Enter);
			this.lbx_items.MouseEnter += new System.EventHandler(this.lbx_items_MouseEnter);
			this.lbx_items.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbx_items_MouseMove);
			this.lbx_items.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lbx_items_PreviewKeyDown);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(933, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(235, 373);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// pb_loading_2
			// 
			this.pb_loading_2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pb_loading_2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.pb_loading_2.Location = new System.Drawing.Point(779, 15);
			this.pb_loading_2.Name = "pb_loading_2";
			this.pb_loading_2.Size = new System.Drawing.Size(100, 23);
			this.pb_loading_2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pb_loading_2.TabIndex = 12;
			this.pb_loading_2.Value = 50;
			this.pb_loading_2.Visible = false;
			// 
			// josi_customer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 418);
			this.Controls.Add(this.pb_loading_2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.lbx_items);
			this.Controls.Add(this.txt_query);
			this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "josi_customer";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Выбор клиента";
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.josi_customer_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.josi_customer_FormClosing);
			this.Shown += new System.EventHandler(this.josi_customer_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_query;
		private System.Windows.Forms.ListBox lbx_items;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ProgressBar pb_loading_2;
	}
}