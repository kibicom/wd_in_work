namespace wd_in_work_gdi
{
	partial class frm_work_monitor
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
			this.tableAdapterManager1 = new kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager();
			this.tfl_main = new System.Windows.Forms.TableLayoutPanel();
			this.tfl_main_bar = new System.Windows.Forms.TableLayoutPanel();
			this.fnl_mf = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.de_dtmake = new DevExpress.XtraEditors.DateEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.de_dtout = new DevExpress.XtraEditors.DateEdit();
			this.pic_loader = new System.Windows.Forms.PictureBox();
			this.pgc_1 = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.tableAdapterManager2 = new kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager();
			this.tfl_main.SuspendLayout();
			this.tfl_main_bar.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.de_dtmake.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtmake.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtout.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtout.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_loader)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pgc_1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableAdapterManager1
			// 
			this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager1.Connection = null;
			this.tableAdapterManager1.tab_product_supplyTableAdapter = null;
			this.tableAdapterManager1.UpdateOrder = kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// tfl_main
			// 
			this.tfl_main.ColumnCount = 1;
			this.tfl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tfl_main.Controls.Add(this.tfl_main_bar, 0, 0);
			this.tfl_main.Controls.Add(this.pgc_1, 0, 1);
			this.tfl_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tfl_main.Location = new System.Drawing.Point(0, 0);
			this.tfl_main.Name = "tfl_main";
			this.tfl_main.RowCount = 2;
			this.tfl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tfl_main.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tfl_main.Size = new System.Drawing.Size(1093, 583);
			this.tfl_main.TabIndex = 5;
			// 
			// tfl_main_bar
			// 
			this.tfl_main_bar.ColumnCount = 2;
			this.tfl_main_bar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.85944F));
			this.tfl_main_bar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.14056F));
			this.tfl_main_bar.Controls.Add(this.fnl_mf, 1, 0);
			this.tfl_main_bar.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tfl_main_bar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tfl_main_bar.Location = new System.Drawing.Point(3, 3);
			this.tfl_main_bar.Name = "tfl_main_bar";
			this.tfl_main_bar.RowCount = 1;
			this.tfl_main_bar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tfl_main_bar.Size = new System.Drawing.Size(1087, 194);
			this.tfl_main_bar.TabIndex = 0;
			// 
			// fnl_mf
			// 
			this.fnl_mf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fnl_mf.Location = new System.Drawing.Point(164, 3);
			this.fnl_mf.Name = "fnl_mf";
			this.fnl_mf.Padding = new System.Windows.Forms.Padding(3);
			this.fnl_mf.Size = new System.Drawing.Size(920, 188);
			this.fnl_mf.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.labelControl1);
			this.flowLayoutPanel1.Controls.Add(this.de_dtmake);
			this.flowLayoutPanel1.Controls.Add(this.labelControl2);
			this.flowLayoutPanel1.Controls.Add(this.de_dtout);
			this.flowLayoutPanel1.Controls.Add(this.pic_loader);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(161, 194);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(3, 3);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(90, 17);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Изготовление";
			// 
			// de_dtmake
			// 
			this.de_dtmake.EditValue = new System.DateTime(2013, 8, 13, 18, 2, 9, 0);
			this.de_dtmake.Location = new System.Drawing.Point(3, 26);
			this.de_dtmake.Name = "de_dtmake";
			this.de_dtmake.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.de_dtmake.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.de_dtmake.Size = new System.Drawing.Size(155, 22);
			this.de_dtmake.TabIndex = 0;
			this.de_dtmake.EditValueChanged += new System.EventHandler(this.de_dtmake_EditValueChanged);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(3, 54);
			this.labelControl2.MinimumSize = new System.Drawing.Size(150, 0);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(150, 17);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Вывоз";
			// 
			// de_dtout
			// 
			this.de_dtout.EditValue = new System.DateTime(2013, 8, 13, 18, 2, 9, 0);
			this.de_dtout.Location = new System.Drawing.Point(3, 77);
			this.de_dtout.Name = "de_dtout";
			this.de_dtout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.de_dtout.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.de_dtout.Size = new System.Drawing.Size(155, 22);
			this.de_dtout.TabIndex = 0;
			this.de_dtout.EditValueChanged += new System.EventHandler(this.de_dtout_EditValueChanged);
			// 
			// pic_loader
			// 
			this.pic_loader.Image = global::wd_in_work_gdi.Properties.Resources.loader_9;
			this.pic_loader.Location = new System.Drawing.Point(3, 105);
			this.pic_loader.Name = "pic_loader";
			this.pic_loader.Size = new System.Drawing.Size(155, 86);
			this.pic_loader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pic_loader.TabIndex = 2;
			this.pic_loader.TabStop = false;
			// 
			// pgc_1
			// 
			this.pgc_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgc_1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3});
			this.pgc_1.Location = new System.Drawing.Point(3, 203);
			this.pgc_1.Name = "pgc_1";
			this.pgc_1.Size = new System.Drawing.Size(1087, 428);
			this.pgc_1.TabIndex = 6;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Изделие";
			this.pivotGridField1.FieldName = "item_i";
			this.pivotGridField1.Name = "pivotGridField1";
			this.pivotGridField1.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField2.AreaIndex = 0;
			this.pivotGridField2.Caption = "Порция";
			this.pivotGridField2.FieldName = "posgroup";
			this.pivotGridField2.Name = "pivotGridField2";
			this.pivotGridField2.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.CellFormat.FormatString = "{0}";
			this.pivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.pivotGridField3.FieldName = "o_name_full";
			this.pivotGridField3.Name = "pivotGridField3";
			this.pivotGridField3.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
			this.pivotGridField3.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// tableAdapterManager2
			// 
			this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager2.Connection = null;
			this.tableAdapterManager2.tab_product_supplyTableAdapter = null;
			this.tableAdapterManager2.UpdateOrder = kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// frm_work_monitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1093, 583);
			this.Controls.Add(this.tfl_main);
			this.Name = "frm_work_monitor";
			this.Text = "frm_work_monitor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.frm_work_monitor_Shown);
			this.tfl_main.ResumeLayout(false);
			this.tfl_main_bar.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.de_dtmake.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtmake.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtout.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.de_dtout.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pic_loader)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pgc_1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
		private System.Windows.Forms.TableLayoutPanel tfl_main;
		private DevExpress.XtraPivotGrid.PivotGridControl pgc_1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraEditors.DateEdit de_dtmake;
		private System.Windows.Forms.FlowLayoutPanel fnl_mf;
		private System.Windows.Forms.TableLayoutPanel tfl_main_bar;
		private kibicom.my_wd_helper.kwj_testDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.DateEdit de_dtout;
		private System.Windows.Forms.PictureBox pic_loader;
	}
}