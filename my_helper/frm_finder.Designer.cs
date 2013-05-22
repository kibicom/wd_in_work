namespace my_helper
{
	partial class frm_finder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_finder));
			this.txt_query = new System.Windows.Forms.TextBox();
			this.lbx_items = new System.Windows.Forms.ListBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.pb_loading_2 = new System.Windows.Forms.ProgressBar();
			this.fp_actions = new System.Windows.Forms.FlowLayoutPanel();
			this.button2 = new System.Windows.Forms.Button();
			this.btn_change = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.fp_actions.SuspendLayout();
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
			this.lbx_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbx_items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbx_items.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lbx_items.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbx_items.FormattingEnabled = true;
			this.lbx_items.ItemHeight = 63;
			this.lbx_items.Location = new System.Drawing.Point(12, 47);
			this.lbx_items.Name = "lbx_items";
			this.lbx_items.Size = new System.Drawing.Size(870, 485);
			this.lbx_items.TabIndex = 1;
			this.lbx_items.Click += new System.EventHandler(this.lbx_items_Click);
			this.lbx_items.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbx_DrawItem);
			this.lbx_items.Enter += new System.EventHandler(this.lbx_items_Enter);
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
			// fp_actions
			// 
			this.fp_actions.BackColor = System.Drawing.Color.White;
			this.fp_actions.Controls.Add(this.button2);
			this.fp_actions.Controls.Add(this.btn_change);
			this.fp_actions.Controls.Add(this.button1);
			this.fp_actions.Location = new System.Drawing.Point(679, 52);
			this.fp_actions.Name = "fp_actions";
			this.fp_actions.Padding = new System.Windows.Forms.Padding(3);
			this.fp_actions.Size = new System.Drawing.Size(200, 45);
			this.fp_actions.TabIndex = 14;
			this.fp_actions.Visible = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.White;
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Image = global::my_helper.Properties.Resources.btn_pick_1;
			this.button2.Location = new System.Drawing.Point(3, 3);
			this.button2.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(39, 39);
			this.button2.TabIndex = 13;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.btn_change_Click);
			this.button2.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.button2.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// btn_change
			// 
			this.btn_change.BackColor = System.Drawing.Color.White;
			this.btn_change.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_change.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.btn_change.FlatAppearance.BorderSize = 0;
			this.btn_change.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_change.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_change.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_change.Image = ((System.Drawing.Image)(resources.GetObject("btn_change.Image")));
			this.btn_change.Location = new System.Drawing.Point(72, 3);
			this.btn_change.Margin = new System.Windows.Forms.Padding(0);
			this.btn_change.Name = "btn_change";
			this.btn_change.Size = new System.Drawing.Size(39, 39);
			this.btn_change.TabIndex = 13;
			this.btn_change.UseVisualStyleBackColor = false;
			this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
			this.btn_change.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.btn_change.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Image = global::my_helper.Properties.Resources.btn_drop_1;
			this.button1.Location = new System.Drawing.Point(111, 3);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(39, 39);
			this.button1.TabIndex = 13;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.btn_change_Click);
			this.button1.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.button1.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// frm_finder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 582);
			this.ControlBox = false;
			this.Controls.Add(this.fp_actions);
			this.Controls.Add(this.pb_loading_2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.lbx_items);
			this.Controls.Add(this.txt_query);
			this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_finder";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.josi_customer_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.josi_customer_FormClosing);
			this.Shown += new System.EventHandler(this.josi_customer_Shown);
			this.fp_actions.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TextBox txt_query;
		public System.Windows.Forms.ListBox lbx_items;
		public System.Windows.Forms.RichTextBox richTextBox1;
		public System.Windows.Forms.ProgressBar pb_loading_2;
		public System.Windows.Forms.Button btn_change;
		public System.Windows.Forms.FlowLayoutPanel fp_actions;
		public System.Windows.Forms.Button button1;
		public System.Windows.Forms.Button button2;
		//public t_FlowLayoutPanel fp_actions;
	}
}