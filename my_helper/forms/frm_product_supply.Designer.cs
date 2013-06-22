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
			this.components = new System.ComponentModel.Container();
			this.chb_dt_done = new System.Windows.Forms.CheckBox();
			this.chb_dtcre = new System.Windows.Forms.CheckBox();
			this.btn_close = new System.Windows.Forms.Button();
			this.lbl_dtcre = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_dt_done = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp_done_filt = new System.Windows.Forms.DateTimePicker();
			this.dtp_dtcre_filt = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.dg_related_supply = new System.Windows.Forms.DataGridView();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.dg_supply = new System.Windows.Forms.DataGridView();
			this.dgc_rs_iddocrelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_idsupplydoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgs_rs_order_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_seller_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_make_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_done_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_rs_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabproductsupplyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kwj_testDataSet = new kibicom.my_wd_helper.kwj_testDataSet();
			this.tab_product_supplyTableAdapter = new kibicom.my_wd_helper.kwj_testDataSetTableAdapters.tab_product_supplyTableAdapter();
			this.dgc_idsupplydoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_idcustomer = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dgc_seller_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_dtcre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_dtdone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dg_related_supply)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabproductsupplyBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kwj_testDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// chb_dt_done
			// 
			this.chb_dt_done.AutoSize = true;
			this.chb_dt_done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chb_dt_done.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.chb_dt_done.ForeColor = System.Drawing.Color.DimGray;
			this.chb_dt_done.Location = new System.Drawing.Point(759, 56);
			this.chb_dt_done.Name = "chb_dt_done";
			this.chb_dt_done.Size = new System.Drawing.Size(14, 13);
			this.chb_dt_done.TabIndex = 7;
			this.chb_dt_done.UseVisualStyleBackColor = true;
			this.chb_dt_done.CheckedChanged += new System.EventHandler(this.chb_dt_done_CheckedChanged);
			// 
			// chb_dtcre
			// 
			this.chb_dtcre.AutoSize = true;
			this.chb_dtcre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chb_dtcre.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.chb_dtcre.ForeColor = System.Drawing.Color.DimGray;
			this.chb_dtcre.Location = new System.Drawing.Point(494, 56);
			this.chb_dtcre.Name = "chb_dtcre";
			this.chb_dtcre.Size = new System.Drawing.Size(14, 13);
			this.chb_dtcre.TabIndex = 7;
			this.chb_dtcre.UseVisualStyleBackColor = true;
			this.chb_dtcre.CheckedChanged += new System.EventHandler(this.chb_dtcre_CheckedChanged);
			// 
			// btn_close
			// 
			this.btn_close.BackColor = System.Drawing.Color.IndianRed;
			this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_close.Font = new System.Drawing.Font("Corbel", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_close.ForeColor = System.Drawing.Color.White;
			this.btn_close.Location = new System.Drawing.Point(851, 5);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(37, 32);
			this.btn_close.TabIndex = 6;
			this.btn_close.Text = "x";
			this.btn_close.UseVisualStyleBackColor = false;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// lbl_dtcre
			// 
			this.lbl_dtcre.AutoSize = true;
			this.lbl_dtcre.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_dtcre.ForeColor = System.Drawing.Color.DimGray;
			this.lbl_dtcre.Location = new System.Drawing.Point(389, 52);
			this.lbl_dtcre.Name = "lbl_dtcre";
			this.lbl_dtcre.Size = new System.Drawing.Size(99, 20);
			this.lbl_dtcre.TabIndex = 5;
			this.lbl_dtcre.Text = "Заявка от";
			this.lbl_dtcre.Click += new System.EventHandler(this.lbl_dtcre_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(12, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(478, 22);
			this.label2.TabIndex = 5;
			this.label2.Text = "Найдите нужные заявки и нажмите Выбрать";
			// 
			// lbl_dt_done
			// 
			this.lbl_dt_done.AutoSize = true;
			this.lbl_dt_done.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_dt_done.ForeColor = System.Drawing.Color.DimGray;
			this.lbl_dt_done.Location = new System.Drawing.Point(654, 52);
			this.lbl_dt_done.Name = "lbl_dt_done";
			this.lbl_dt_done.Size = new System.Drawing.Size(99, 20);
			this.lbl_dt_done.TabIndex = 5;
			this.lbl_dt_done.Text = "Выполнена";
			this.lbl_dt_done.Click += new System.EventHandler(this.lbl_dt_done_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.DimGray;
			this.label5.Location = new System.Drawing.Point(-698, 411);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(202, 22);
			this.label5.TabIndex = 5;
			this.label5.Text = "Связанные заявки";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(12, 386);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(202, 22);
			this.label1.TabIndex = 5;
			this.label1.Text = "Связанные заявки";
			// 
			// dtp_done_filt
			// 
			this.dtp_done_filt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp_done_filt.Location = new System.Drawing.Point(779, 52);
			this.dtp_done_filt.Name = "dtp_done_filt";
			this.dtp_done_filt.Size = new System.Drawing.Size(109, 22);
			this.dtp_done_filt.TabIndex = 4;
			this.dtp_done_filt.ValueChanged += new System.EventHandler(this.dtp_done_filt_ValueChanged);
			// 
			// dtp_dtcre_filt
			// 
			this.dtp_dtcre_filt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp_dtcre_filt.Location = new System.Drawing.Point(514, 52);
			this.dtp_dtcre_filt.Name = "dtp_dtcre_filt";
			this.dtp_dtcre_filt.Size = new System.Drawing.Size(109, 22);
			this.dtp_dtcre_filt.TabIndex = 4;
			this.dtp_dtcre_filt.ValueChanged += new System.EventHandler(this.dtp_dtcre_filt_ValueChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(12, 997);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(166, 47);
			this.button1.TabIndex = 3;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.Location = new System.Drawing.Point(540, 571);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(166, 47);
			this.button2.TabIndex = 3;
			this.button2.Text = "Отменить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_save
			// 
			this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_save.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_save.Location = new System.Drawing.Point(712, 571);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(166, 47);
			this.btn_save.TabIndex = 3;
			this.btn_save.Text = "Применить";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Visible = false;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// dg_related_supply
			// 
			this.dg_related_supply.AllowUserToAddRows = false;
			this.dg_related_supply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dg_related_supply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_related_supply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_rs_iddocrelation,
            this.dgc_rs_idsupplydoc,
            this.dgs_rs_order_name,
            this.dgc_rs_seller_name,
            this.dgc_rs_num,
            this.dgc_rs_make_dt,
            this.dgc_rs_done_dt,
            this.dgc_rs_comment});
			this.dg_related_supply.Location = new System.Drawing.Point(12, 414);
			this.dg_related_supply.Name = "dg_related_supply";
			this.dg_related_supply.ReadOnly = true;
			this.dg_related_supply.RowTemplate.Height = 24;
			this.dg_related_supply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dg_related_supply.Size = new System.Drawing.Size(876, 234);
			this.dg_related_supply.TabIndex = 0;
			this.dg_related_supply.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_related_supply_CellContentClick);
			// 
			// txt_filter
			// 
			this.txt_filter.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txt_filter.Location = new System.Drawing.Point(12, 47);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(371, 30);
			this.txt_filter.TabIndex = 2;
			this.txt_filter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyUp);
			// 
			// dg_supply
			// 
			this.dg_supply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dg_supply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_supply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_idsupplydoc,
            this.dgc_idcustomer,
            this.dgc_seller_name,
            this.dgc_name,
            this.dgc_dtcre,
            this.dgc_dtdone,
            this.dgc_comment});
			this.dg_supply.Location = new System.Drawing.Point(12, 83);
			this.dg_supply.Name = "dg_supply";
			this.dg_supply.RowTemplate.Height = 24;
			this.dg_supply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dg_supply.Size = new System.Drawing.Size(876, 300);
			this.dg_supply.TabIndex = 0;
			this.dg_supply.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_supply_CellContentClick);
			this.dg_supply.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_supply_CellContentDoubleClick);
			this.dg_supply.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_supply_CellValueChanged);
			this.dg_supply.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dg_supply_DataError);
			this.dg_supply.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dg_supply_DefaultValuesNeeded);
			this.dg_supply.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_supply_RowsAdded);
			this.dg_supply.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_supply_RowValidated);
			// 
			// dgc_rs_iddocrelation
			// 
			this.dgc_rs_iddocrelation.HeaderText = "iddocrelation";
			this.dgc_rs_iddocrelation.Name = "dgc_rs_iddocrelation";
			this.dgc_rs_iddocrelation.ReadOnly = true;
			this.dgc_rs_iddocrelation.Visible = false;
			// 
			// dgc_rs_idsupplydoc
			// 
			this.dgc_rs_idsupplydoc.HeaderText = "idsupplydoc";
			this.dgc_rs_idsupplydoc.Name = "dgc_rs_idsupplydoc";
			this.dgc_rs_idsupplydoc.ReadOnly = true;
			this.dgc_rs_idsupplydoc.Visible = false;
			// 
			// dgs_rs_order_name
			// 
			this.dgs_rs_order_name.HeaderText = "Заказ";
			this.dgs_rs_order_name.Name = "dgs_rs_order_name";
			this.dgs_rs_order_name.ReadOnly = true;
			this.dgs_rs_order_name.Visible = false;
			// 
			// dgc_rs_seller_name
			// 
			this.dgc_rs_seller_name.HeaderText = "Поставщик";
			this.dgc_rs_seller_name.Name = "dgc_rs_seller_name";
			this.dgc_rs_seller_name.ReadOnly = true;
			this.dgc_rs_seller_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgc_rs_seller_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dgc_rs_num
			// 
			this.dgc_rs_num.HeaderText = "Номер";
			this.dgc_rs_num.Name = "dgc_rs_num";
			this.dgc_rs_num.ReadOnly = true;
			// 
			// dgc_rs_make_dt
			// 
			this.dgc_rs_make_dt.HeaderText = "Дата заявки";
			this.dgc_rs_make_dt.Name = "dgc_rs_make_dt";
			this.dgc_rs_make_dt.ReadOnly = true;
			// 
			// dgc_rs_done_dt
			// 
			this.dgc_rs_done_dt.HeaderText = "Выполнена";
			this.dgc_rs_done_dt.Name = "dgc_rs_done_dt";
			this.dgc_rs_done_dt.ReadOnly = true;
			// 
			// dgc_rs_comment
			// 
			this.dgc_rs_comment.HeaderText = "Комментарий";
			this.dgc_rs_comment.Name = "dgc_rs_comment";
			this.dgc_rs_comment.ReadOnly = true;
			// 
			// tabproductsupplyBindingSource
			// 
			this.tabproductsupplyBindingSource.DataMember = "tab_product_supply";
			this.tabproductsupplyBindingSource.DataSource = this.kwj_testDataSet;
			this.tabproductsupplyBindingSource.CurrentChanged += new System.EventHandler(this.tabproductsupplyBindingSource_CurrentChanged);
			// 
			// kwj_testDataSet
			// 
			this.kwj_testDataSet.DataSetName = "kwj_testDataSet";
			this.kwj_testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tab_product_supplyTableAdapter
			// 
			this.tab_product_supplyTableAdapter.ClearBeforeFill = true;
			// 
			// dgc_idsupplydoc
			// 
			this.dgc_idsupplydoc.HeaderText = "idsupplydoc";
			this.dgc_idsupplydoc.Name = "dgc_idsupplydoc";
			this.dgc_idsupplydoc.ReadOnly = true;
			this.dgc_idsupplydoc.Visible = false;
			// 
			// dgc_idcustomer
			// 
			this.dgc_idcustomer.HeaderText = "Поставщик";
			this.dgc_idcustomer.Name = "dgc_idcustomer";
			this.dgc_idcustomer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgc_idcustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// dgc_seller_name
			// 
			this.dgc_seller_name.HeaderText = "Поставщик";
			this.dgc_seller_name.Name = "dgc_seller_name";
			this.dgc_seller_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgc_seller_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dgc_seller_name.Visible = false;
			// 
			// dgc_name
			// 
			this.dgc_name.HeaderText = "Номер";
			this.dgc_name.Name = "dgc_name";
			// 
			// dgc_dtcre
			// 
			this.dgc_dtcre.HeaderText = "Дата заявки";
			this.dgc_dtcre.Name = "dgc_dtcre";
			// 
			// dgc_dtdone
			// 
			this.dgc_dtdone.HeaderText = "Выполнена";
			this.dgc_dtdone.Name = "dgc_dtdone";
			// 
			// dgc_comment
			// 
			this.dgc_comment.HeaderText = "Комментарий";
			this.dgc_comment.Name = "dgc_comment";
			// 
			// frm_product_supply
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 660);
			this.Controls.Add(this.chb_dt_done);
			this.Controls.Add(this.chb_dtcre);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.lbl_dtcre);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbl_dt_done);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtp_done_filt);
			this.Controls.Add(this.dtp_dtcre_filt);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.dg_related_supply);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.dg_supply);
			this.Name = "frm_product_supply";
			this.Load += new System.EventHandler(this.frm_product_supply_Load);
			this.VisibleChanged += new System.EventHandler(this.frm_product_supply_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.dg_related_supply)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabproductsupplyBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kwj_testDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dg_supply;
		private kwj_testDataSet kwj_testDataSet;
		private System.Windows.Forms.BindingSource tabproductsupplyBindingSource;
		private kwj_testDataSetTableAdapters.tab_product_supplyTableAdapter tab_product_supplyTableAdapter;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.DataGridView dg_related_supply;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker dtp_dtcre_filt;
		private System.Windows.Forms.DateTimePicker dtp_done_filt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_close;
		private System.Windows.Forms.Label lbl_dt_done;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chb_dtcre;
		private System.Windows.Forms.Label lbl_dtcre;
		private System.Windows.Forms.CheckBox chb_dt_done;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_iddocrelation;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_idsupplydoc;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgs_rs_order_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_seller_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_num;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_make_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_done_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_rs_comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_idsupplydoc;
		private System.Windows.Forms.DataGridViewComboBoxColumn dgc_idcustomer;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_seller_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_dtcre;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_dtdone;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_comment;
	}
}