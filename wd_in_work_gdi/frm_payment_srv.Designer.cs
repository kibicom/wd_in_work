namespace wd_in_work_gdi
{
	partial class frm_payment_srv
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
			this.btn_stop = new System.Windows.Forms.Button();
			this.btn_start = new System.Windows.Forms.Button();
			this.gc_log = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc_log_id = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_log_img = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_log_msg = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_log_dtcre = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc_log_type = new DevExpress.XtraGrid.Columns.GridColumn();
			this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.btn_update_log = new System.Windows.Forms.Button();
			this.rtxt_log = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.gc_log)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_stop
			// 
			this.btn_stop.BackColor = System.Drawing.Color.LightPink;
			this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_stop.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_stop.Location = new System.Drawing.Point(12, 76);
			this.btn_stop.Name = "btn_stop";
			this.btn_stop.Size = new System.Drawing.Size(142, 59);
			this.btn_stop.TabIndex = 1;
			this.btn_stop.Text = "Остановить";
			this.btn_stop.UseVisualStyleBackColor = false;
			this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
			// 
			// btn_start
			// 
			this.btn_start.BackColor = System.Drawing.Color.PaleGreen;
			this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_start.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_start.Location = new System.Drawing.Point(12, 11);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(142, 59);
			this.btn_start.TabIndex = 1;
			this.btn_start.Text = "Запустить";
			this.btn_start.UseVisualStyleBackColor = false;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// gc_log
			// 
			this.gc_log.Location = new System.Drawing.Point(160, 12);
			this.gc_log.MainView = this.gridView1;
			this.gc_log.Name = "gc_log";
			this.gc_log.Size = new System.Drawing.Size(780, 272);
			this.gc_log.TabIndex = 2;
			this.gc_log.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gc_log.Click += new System.EventHandler(this.gridControl1_Click);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_log_id,
            this.gc_log_img,
            this.gc_log_type,
            this.gc_log_dtcre,
            this.gc_log_msg});
			this.gridView1.GridControl = this.gc_log;
			this.gridView1.Name = "gridView1";
			// 
			// gc_log_id
			// 
			this.gc_log_id.Caption = "id";
			this.gc_log_id.Name = "gc_log_id";
			this.gc_log_id.Visible = true;
			this.gc_log_id.VisibleIndex = 0;
			// 
			// gc_log_img
			// 
			this.gc_log_img.FieldName = "gc_log_img";
			this.gc_log_img.Name = "gc_log_img";
			this.gc_log_img.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.gc_log_img.Visible = true;
			this.gc_log_img.VisibleIndex = 1;
			// 
			// gc_log_msg
			// 
			this.gc_log_msg.Caption = "Сообщение";
			this.gc_log_msg.Name = "gc_log_msg";
			this.gc_log_msg.Visible = true;
			this.gc_log_msg.VisibleIndex = 2;
			// 
			// gc_log_dtcre
			// 
			this.gc_log_dtcre.Caption = "Когда";
			this.gc_log_dtcre.Name = "gc_log_dtcre";
			this.gc_log_dtcre.Visible = true;
			this.gc_log_dtcre.VisibleIndex = 3;
			// 
			// gc_log_type
			// 
			this.gc_log_type.Caption = "Тип";
			this.gc_log_type.Name = "gc_log_type";
			this.gc_log_type.Visible = true;
			this.gc_log_type.VisibleIndex = 4;
			// 
			// radioGroup1
			// 
			this.radioGroup1.Location = new System.Drawing.Point(13, 225);
			this.radioGroup1.Name = "radioGroup1";
			this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("online", "Онлайн"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("db", "Из базы")});
			this.radioGroup1.Size = new System.Drawing.Size(141, 98);
			this.radioGroup1.TabIndex = 3;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelControl1.Location = new System.Drawing.Point(13, 190);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(36, 22);
			this.labelControl1.TabIndex = 4;
			this.labelControl1.Text = "Лог";
			this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
			// 
			// btn_update_log
			// 
			this.btn_update_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_update_log.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_update_log.Location = new System.Drawing.Point(55, 186);
			this.btn_update_log.Name = "btn_update_log";
			this.btn_update_log.Size = new System.Drawing.Size(99, 33);
			this.btn_update_log.TabIndex = 5;
			this.btn_update_log.Text = "Обновить";
			this.btn_update_log.UseVisualStyleBackColor = true;
			// 
			// rtxt_log
			// 
			this.rtxt_log.Location = new System.Drawing.Point(160, 290);
			this.rtxt_log.Name = "rtxt_log";
			this.rtxt_log.Size = new System.Drawing.Size(780, 259);
			this.rtxt_log.TabIndex = 6;
			this.rtxt_log.Text = "";
			// 
			// frm_payment_srv
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(952, 561);
			this.Controls.Add(this.rtxt_log);
			this.Controls.Add(this.btn_update_log);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.radioGroup1);
			this.Controls.Add(this.gc_log);
			this.Controls.Add(this.btn_start);
			this.Controls.Add(this.btn_stop);
			this.Name = "frm_payment_srv";
			this.Text = "frm_payment_srv";
			((System.ComponentModel.ISupportInitialize)(this.gc_log)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_stop;
		private System.Windows.Forms.Button btn_start;
		private DevExpress.XtraGrid.GridControl gc_log;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gc_log_id;
		private DevExpress.XtraGrid.Columns.GridColumn gc_log_img;
		private DevExpress.XtraGrid.Columns.GridColumn gc_log_msg;
		private DevExpress.XtraGrid.Columns.GridColumn gc_log_dtcre;
		private DevExpress.XtraGrid.Columns.GridColumn gc_log_type;
		private DevExpress.XtraEditors.RadioGroup radioGroup1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.Button btn_update_log;
		private System.Windows.Forms.RichTextBox rtxt_log;

	}
}