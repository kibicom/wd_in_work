namespace kibicom.my_wd_helper.forms
{
	partial class frm_product_supply
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
			this.dg_supply = new System.Windows.Forms.DataGridView();
			this.seller_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.make_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.done_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).BeginInit();
			this.SuspendLayout();
			// 
			// dg_supply
			// 
			this.dg_supply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_supply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seller_name,
            this.make_dt,
            this.done_dt,
            this.num,
            this.comment});
			this.dg_supply.Location = new System.Drawing.Point(12, 12);
			this.dg_supply.Name = "dg_supply";
			this.dg_supply.RowTemplate.Height = 24;
			this.dg_supply.Size = new System.Drawing.Size(614, 288);
			this.dg_supply.TabIndex = 0;
			// 
			// seller_name
			// 
			this.seller_name.HeaderText = "Поставщик";
			this.seller_name.Name = "seller_name";
			// 
			// make_dt
			// 
			this.make_dt.HeaderText = "Дата заявки";
			this.make_dt.Name = "make_dt";
			// 
			// done_dt
			// 
			this.done_dt.HeaderText = "Выполнена";
			this.done_dt.Name = "done_dt";
			// 
			// num
			// 
			this.num.HeaderText = "Номер";
			this.num.Name = "num";
			// 
			// comment
			// 
			this.comment.HeaderText = "Комментарий";
			this.comment.Name = "comment";
			// 
			// frm_product_supply
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 354);
			this.Controls.Add(this.dg_supply);
			this.Name = "frm_product_supply";
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dg_supply;
		private System.Windows.Forms.DataGridViewComboBoxColumn seller_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn make_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn done_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn num;
		private System.Windows.Forms.DataGridViewTextBoxColumn comment;
	}
}