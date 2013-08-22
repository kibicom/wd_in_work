namespace wd_in_work_gdi
{
	partial class frm_work_monitor_3
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
			this.gc_main = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc1_w1_posgroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc1_w1_mf_name = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc1_w1_o_name = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc1_w1_oi_numpos = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc1_w1_otk_check = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc1_w1_assembly_check = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gc_main)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// gc_main
			// 
			this.gc_main.Location = new System.Drawing.Point(153, 12);
			this.gc_main.MainView = this.gridView1;
			this.gc_main.Name = "gc_main";
			this.gc_main.Size = new System.Drawing.Size(440, 515);
			this.gc_main.TabIndex = 1;
			this.gc_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc1_w1_posgroup,
            this.gc1_w1_mf_name,
            this.gc1_w1_o_name,
            this.gc1_w1_oi_numpos,
            this.gc1_w1_otk_check,
            this.gc1_w1_assembly_check});
			this.gridView1.GridControl = this.gc_main;
			this.gridView1.Name = "gridView1";
			// 
			// gc1_w1_posgroup
			// 
			this.gc1_w1_posgroup.Caption = "Порция";
			this.gc1_w1_posgroup.FieldName = "posgroup";
			this.gc1_w1_posgroup.Name = "gc1_w1_posgroup";
			this.gc1_w1_posgroup.OptionsColumn.AllowEdit = false;
			this.gc1_w1_posgroup.OptionsColumn.AllowFocus = false;
			this.gc1_w1_posgroup.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.gc1_w1_posgroup.Visible = true;
			this.gc1_w1_posgroup.VisibleIndex = 0;
			// 
			// gc1_w1_mf_name
			// 
			this.gc1_w1_mf_name.Caption = "Задание";
			this.gc1_w1_mf_name.FieldName = "mf_name";
			this.gc1_w1_mf_name.Name = "gc1_w1_mf_name";
			this.gc1_w1_mf_name.OptionsColumn.AllowEdit = false;
			this.gc1_w1_mf_name.OptionsColumn.AllowFocus = false;
			this.gc1_w1_mf_name.Visible = true;
			this.gc1_w1_mf_name.VisibleIndex = 1;
			// 
			// gc1_w1_o_name
			// 
			this.gc1_w1_o_name.Caption = "Заказ";
			this.gc1_w1_o_name.FieldName = "o_name";
			this.gc1_w1_o_name.Name = "gc1_w1_o_name";
			this.gc1_w1_o_name.OptionsColumn.AllowEdit = false;
			this.gc1_w1_o_name.OptionsColumn.AllowFocus = false;
			this.gc1_w1_o_name.Visible = true;
			this.gc1_w1_o_name.VisibleIndex = 2;
			// 
			// gc1_w1_oi_numpos
			// 
			this.gc1_w1_oi_numpos.Caption = "Поизция";
			this.gc1_w1_oi_numpos.FieldName = "oi_numpos";
			this.gc1_w1_oi_numpos.Name = "gc1_w1_oi_numpos";
			this.gc1_w1_oi_numpos.OptionsColumn.AllowEdit = false;
			this.gc1_w1_oi_numpos.OptionsColumn.AllowFocus = false;
			this.gc1_w1_oi_numpos.Visible = true;
			this.gc1_w1_oi_numpos.VisibleIndex = 3;
			// 
			// gc1_w1_otk_check
			// 
			this.gc1_w1_otk_check.Caption = "gridColumn1";
			this.gc1_w1_otk_check.FieldName = "otk_check";
			this.gc1_w1_otk_check.Name = "gc1_w1_otk_check";
			// 
			// gc1_w1_assembly_check
			// 
			this.gc1_w1_assembly_check.Caption = "gridColumn1";
			this.gc1_w1_assembly_check.FieldName = "assembly_check";
			this.gc1_w1_assembly_check.Name = "gc1_w1_assembly_check";
			// 
			// frm_work_monitor_3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1102, 603);
			this.Controls.Add(this.gc_main);
			this.Name = "frm_work_monitor_3";
			this.Text = "frm_work_monitor_3";
			((System.ComponentModel.ISupportInitialize)(this.gc_main)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gc_main;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_posgroup;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_mf_name;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_o_name;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_oi_numpos;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_otk_check;
		private DevExpress.XtraGrid.Columns.GridColumn gc1_w1_assembly_check;

	}
}