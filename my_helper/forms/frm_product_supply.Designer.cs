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
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).BeginInit();
			this.SuspendLayout();
			// 
			// dg_supply
			// 
			this.dg_supply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_supply.Location = new System.Drawing.Point(12, 12);
			this.dg_supply.Name = "dg_supply";
			this.dg_supply.RowTemplate.Height = 24;
			this.dg_supply.Size = new System.Drawing.Size(614, 288);
			this.dg_supply.TabIndex = 0;
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
	}
}