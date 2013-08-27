namespace kibicom.my_wd_helper.forms
{
	partial class frm_payment_manager
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.tab_orders = new DevExpress.XtraTab.XtraTabPage();
			this.tab_payments = new DevExpress.XtraTab.XtraTabPage();
			this.gc_orders = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc_payments = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc_orders_idorder = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_orders_name = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_orders_smbase = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc_payments_idpayment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraVertGridBlending1 = new DevExpress.XtraVerticalGrid.Blending.XtraVertGridBlending();
			this.gc_payments_payment_name = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_payments_sm = new DevExpress.XtraGrid.Columns.GridColumn();
			this.kwj_testDataSet = new kibicom.my_wd_helper.kwj_testDataSet();
			this.kwjtestDataSetBindingSource = new System.Windows.Forms.BindingSource();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.tab_orders.SuspendLayout();
			this.tab_payments.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gc_orders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_payments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kwj_testDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kwjtestDataSetBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.5F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.50649F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.49351F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 616);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(647, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.01205F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(470, 415);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.xtraTabControl1, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 379F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(638, 415);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(3, 39);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.tab_orders;
			this.xtraTabControl1.Size = new System.Drawing.Size(632, 373);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tab_orders,
            this.tab_payments});
			// 
			// tab_orders
			// 
			this.tab_orders.Controls.Add(this.gc_orders);
			this.tab_orders.Name = "tab_orders";
			this.tab_orders.Size = new System.Drawing.Size(626, 342);
			this.tab_orders.Text = "Заказы";
			// 
			// tab_payments
			// 
			this.tab_payments.Controls.Add(this.gc_payments);
			this.tab_payments.Name = "tab_payments";
			this.tab_payments.Size = new System.Drawing.Size(626, 342);
			this.tab_payments.Text = "Платежи";
			// 
			// gc_orders
			// 
			this.gc_orders.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.gridView3;
			gridLevelNode1.RelationName = "Level1";
			this.gc_orders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.gc_orders.Location = new System.Drawing.Point(0, 0);
			this.gc_orders.MainView = this.gridView1;
			this.gc_orders.Name = "gc_orders";
			this.gc_orders.Size = new System.Drawing.Size(626, 342);
			this.gc_orders.TabIndex = 0;
			this.gc_orders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_orders_idorder,
            this.gc_orders_name,
            this.gc_orders_smbase});
			this.gridView1.GridControl = this.gc_orders;
			this.gridView1.Name = "gridView1";
			// 
			// gc_payments
			// 
			this.gc_payments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gc_payments.Location = new System.Drawing.Point(0, 0);
			this.gc_payments.MainView = this.gridView2;
			this.gc_payments.Name = "gc_payments";
			this.gc_payments.Size = new System.Drawing.Size(626, 342);
			this.gc_payments.TabIndex = 0;
			this.gc_payments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.GridControl = this.gc_payments;
			this.gridView2.Name = "gridView2";
			// 
			// gc_orders_idorder
			// 
			this.gc_orders_idorder.Caption = "idorder";
			this.gc_orders_idorder.FieldName = "idorder";
			this.gc_orders_idorder.Name = "gc_orders_idorder";
			this.gc_orders_idorder.Visible = true;
			this.gc_orders_idorder.VisibleIndex = 0;
			// 
			// gc_orders_name
			// 
			this.gc_orders_name.Caption = "Имя";
			this.gc_orders_name.FieldName = "name";
			this.gc_orders_name.Name = "gc_orders_name";
			this.gc_orders_name.Visible = true;
			this.gc_orders_name.VisibleIndex = 1;
			// 
			// gc_orders_smbase
			// 
			this.gc_orders_smbase.Caption = "Сумма";
			this.gc_orders_smbase.FieldName = "smbase";
			this.gc_orders_smbase.Name = "gc_orders_smbase";
			this.gc_orders_smbase.Visible = true;
			this.gc_orders_smbase.VisibleIndex = 2;
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_payments_idpayment,
            this.gc_payments_payment_name,
            this.gc_payments_sm});
			this.gridView3.GridControl = this.gc_orders;
			this.gridView3.Name = "gridView3";
			// 
			// gc_payments_idpayment
			// 
			this.gc_payments_idpayment.Caption = "idpayment";
			this.gc_payments_idpayment.FieldName = "idpayment";
			this.gc_payments_idpayment.Name = "gc_payments_idpayment";
			this.gc_payments_idpayment.Visible = true;
			this.gc_payments_idpayment.VisibleIndex = 0;
			// 
			// gc_payments_payment_name
			// 
			this.gc_payments_payment_name.Caption = "Номер";
			this.gc_payments_payment_name.FieldName = "payment_name";
			this.gc_payments_payment_name.Name = "gc_payments_payment_name";
			this.gc_payments_payment_name.Visible = true;
			this.gc_payments_payment_name.VisibleIndex = 1;
			// 
			// gc_payments_sm
			// 
			this.gc_payments_sm.Caption = "Сумма";
			this.gc_payments_sm.FieldName = "payment_smbase";
			this.gc_payments_sm.Name = "gc_payments_sm";
			this.gc_payments_sm.Visible = true;
			this.gc_payments_sm.VisibleIndex = 2;
			// 
			// kwj_testDataSet
			// 
			this.kwj_testDataSet.DataSetName = "kwj_testDataSet";
			this.kwj_testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// kwjtestDataSetBindingSource
			// 
			this.kwjtestDataSetBindingSource.DataSource = this.kwj_testDataSet;
			this.kwjtestDataSetBindingSource.Position = 0;
			// 
			// frm_payment_manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1120, 616);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "frm_payment_manager";
			this.Text = "frm_payment_manager";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.tab_orders.ResumeLayout(false);
			this.tab_payments.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gc_orders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_payments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kwj_testDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kwjtestDataSetBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage tab_orders;
		private DevExpress.XtraTab.XtraTabPage tab_payments;
		private DevExpress.XtraGrid.GridControl gc_orders;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gc_payments_idpayment;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gc_orders_idorder;
		private DevExpress.XtraGrid.Columns.GridColumn gc_orders_name;
		private DevExpress.XtraGrid.Columns.GridColumn gc_orders_smbase;
		private DevExpress.XtraGrid.GridControl gc_payments;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraVerticalGrid.Blending.XtraVertGridBlending xtraVertGridBlending1;
		private DevExpress.XtraGrid.Columns.GridColumn gc_payments_payment_name;
		private DevExpress.XtraGrid.Columns.GridColumn gc_payments_sm;
		private kwj_testDataSet kwj_testDataSet;
		private System.Windows.Forms.BindingSource kwjtestDataSetBindingSource;
	}
}