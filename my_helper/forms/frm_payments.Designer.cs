namespace kibicom.my_wd_helper.forms
{
	partial class frm_payments
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
			this.de_dg = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.de_gcol_tab_payment_idpayment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.de_gcol_tab_payment_name = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.de_dg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// de_dg
			// 
			this.de_dg.Location = new System.Drawing.Point(12, 12);
			this.de_dg.MainView = this.gridView1;
			this.de_dg.Name = "de_dg";
			this.de_dg.Size = new System.Drawing.Size(795, 143);
			this.de_dg.TabIndex = 0;
			this.de_dg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.de_gcol_tab_payment_idpayment,
            this.de_gcol_tab_payment_name});
			this.gridView1.GridControl = this.de_dg;
			this.gridView1.Name = "gridView1";
			// 
			// de_gcol_tab_payment_idpayment
			// 
			this.de_gcol_tab_payment_idpayment.Caption = "idpayment";
			this.de_gcol_tab_payment_idpayment.Name = "de_gcol_tab_payment_idpayment";
			this.de_gcol_tab_payment_idpayment.Visible = true;
			this.de_gcol_tab_payment_idpayment.VisibleIndex = 0;
			// 
			// de_gcol_tab_payment_name
			// 
			this.de_gcol_tab_payment_name.Caption = "Номер";
			this.de_gcol_tab_payment_name.Name = "de_gcol_tab_payment_name";
			this.de_gcol_tab_payment_name.Visible = true;
			this.de_gcol_tab_payment_name.VisibleIndex = 1;
			// 
			// frm_payments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 493);
			this.Controls.Add(this.de_dg);
			this.Name = "frm_payments";
			this.Text = "frm_payments";
			((System.ComponentModel.ISupportInitialize)(this.de_dg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl de_dg;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn de_gcol_tab_payment_idpayment;
		private DevExpress.XtraGrid.Columns.GridColumn de_gcol_tab_payment_name;
	}
}