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
			this.btn_pick = new System.Windows.Forms.Button();
			this.btn_change = new System.Windows.Forms.Button();
			this.btn_drop = new System.Windows.Forms.Button();
			this.btn_revert = new System.Windows.Forms.Button();
			this.lbl_invite = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.fp_actions.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_query
			// 
			this.txt_query.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_query.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_query.Location = new System.Drawing.Point(11, 45);
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
			this.lbx_items.Location = new System.Drawing.Point(12, 85);
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
			this.pb_loading_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_loading_2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pb_loading_2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.pb_loading_2.Location = new System.Drawing.Point(776, 50);
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
			this.fp_actions.Controls.Add(this.btn_pick);
			this.fp_actions.Controls.Add(this.flowLayoutPanel1);
			this.fp_actions.Location = new System.Drawing.Point(682, 85);
			this.fp_actions.Name = "fp_actions";
			this.fp_actions.Size = new System.Drawing.Size(200, 45);
			this.fp_actions.TabIndex = 14;
			this.fp_actions.Visible = false;
			// 
			// btn_pick
			// 
			this.btn_pick.BackColor = System.Drawing.Color.White;
			this.btn_pick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_pick.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.btn_pick.FlatAppearance.BorderSize = 0;
			this.btn_pick.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_pick.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_pick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_pick.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_pick.Image = global::my_helper.Properties.Resources.btn_pick_1;
			this.btn_pick.Location = new System.Drawing.Point(3, 3);
			this.btn_pick.Margin = new System.Windows.Forms.Padding(3, 3, 28, 3);
			this.btn_pick.Name = "btn_pick";
			this.btn_pick.Size = new System.Drawing.Size(39, 39);
			this.btn_pick.TabIndex = 13;
			this.btn_pick.UseVisualStyleBackColor = false;
			this.btn_pick.Click += new System.EventHandler(this.btn_pick_Click);
			this.btn_pick.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.btn_pick.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
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
			this.btn_change.Location = new System.Drawing.Point(7, 3);
			this.btn_change.Margin = new System.Windows.Forms.Padding(0);
			this.btn_change.Name = "btn_change";
			this.btn_change.Size = new System.Drawing.Size(39, 39);
			this.btn_change.TabIndex = 13;
			this.btn_change.UseVisualStyleBackColor = false;
			this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
			this.btn_change.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.btn_change.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// btn_drop
			// 
			this.btn_drop.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btn_drop.BackColor = System.Drawing.Color.White;
			this.btn_drop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_drop.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.btn_drop.FlatAppearance.BorderSize = 0;
			this.btn_drop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_drop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_drop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_drop.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_drop.Image = global::my_helper.Properties.Resources.btn_drop_1;
			this.btn_drop.Location = new System.Drawing.Point(46, 3);
			this.btn_drop.Margin = new System.Windows.Forms.Padding(0);
			this.btn_drop.Name = "btn_drop";
			this.btn_drop.Size = new System.Drawing.Size(39, 39);
			this.btn_drop.TabIndex = 13;
			this.btn_drop.UseVisualStyleBackColor = false;
			this.btn_drop.Click += new System.EventHandler(this.btn_drop_Click);
			this.btn_drop.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.btn_drop.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// btn_revert
			// 
			this.btn_revert.BackColor = System.Drawing.Color.White;
			this.btn_revert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btn_revert.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.btn_revert.FlatAppearance.BorderSize = 0;
			this.btn_revert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btn_revert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btn_revert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_revert.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_revert.Image = global::my_helper.Properties.Resources.btn_revert_1;
			this.btn_revert.Location = new System.Drawing.Point(85, 3);
			this.btn_revert.Margin = new System.Windows.Forms.Padding(0);
			this.btn_revert.Name = "btn_revert";
			this.btn_revert.Size = new System.Drawing.Size(39, 39);
			this.btn_revert.TabIndex = 13;
			this.btn_revert.UseVisualStyleBackColor = false;
			this.btn_revert.Visible = false;
			this.btn_revert.Click += new System.EventHandler(this.btn_revert_Click);
			this.btn_revert.MouseEnter += new System.EventHandler(this.btn_change_MouseEnter);
			this.btn_revert.MouseLeave += new System.EventHandler(this.btn_change_MouseLeave);
			// 
			// lbl_invite
			// 
			this.lbl_invite.AutoSize = true;
			this.lbl_invite.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_invite.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbl_invite.Location = new System.Drawing.Point(12, 9);
			this.lbl_invite.Name = "lbl_invite";
			this.lbl_invite.Size = new System.Drawing.Size(348, 27);
			this.lbl_invite.TabIndex = 15;
			this.lbl_invite.Text = "Начните ввод в поле ниже";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel1.Controls.Add(this.btn_revert);
			this.flowLayoutPanel1.Controls.Add(this.btn_drop);
			this.flowLayoutPanel1.Controls.Add(this.btn_change);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(70, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(130, 45);
			this.flowLayoutPanel1.TabIndex = 14;
			// 
			// frm_finder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 582);
			this.ControlBox = false;
			this.Controls.Add(this.lbl_invite);
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
			this.flowLayoutPanel1.ResumeLayout(false);
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
		public System.Windows.Forms.Button btn_drop;
		public System.Windows.Forms.Button btn_pick;
		public System.Windows.Forms.Label lbl_invite;
		public System.Windows.Forms.Button btn_revert;
		public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		//public t_FlowLayoutPanel fp_actions;
	}
}