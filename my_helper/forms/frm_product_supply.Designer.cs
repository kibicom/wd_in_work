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
			this.dg_supply = new System.Windows.Forms.DataGridView();
			this.dgc_seller_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_make_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_done_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgc_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabproductsupplyBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.kwj_testDataSet = new kibicom.my_wd_helper.kwj_testDataSet();
			this.tab_product_supplyTableAdapter = new kibicom.my_wd_helper.kwj_testDataSetTableAdapters.tab_product_supplyTableAdapter();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_save = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dg_supply)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabproductsupplyBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kwj_testDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// dg_supply
			// 
			this.dg_supply.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dg_supply.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg_supply.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgc_seller_name,
            this.dgc_num,
            this.dgc_make_dt,
            this.dgc_done_dt,
            this.dgc_comment});
			this.dg_supply.Location = new System.Drawing.Point(12, 49);
			this.dg_supply.Name = "dg_supply";
			this.dg_supply.RowTemplate.Height = 24;
			this.dg_supply.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dg_supply.Size = new System.Drawing.Size(725, 377);
			this.dg_supply.TabIndex = 0;
			this.dg_supply.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_supply_CellContentClick);
			// 
			// dgc_seller_name
			// 
			this.dgc_seller_name.HeaderText = "Поставщик";
			this.dgc_seller_name.Name = "dgc_seller_name";
			this.dgc_seller_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dgc_seller_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dgc_num
			// 
			this.dgc_num.HeaderText = "Номер";
			this.dgc_num.Name = "dgc_num";
			// 
			// dgc_make_dt
			// 
			this.dgc_make_dt.HeaderText = "Дата заявки";
			this.dgc_make_dt.Name = "dgc_make_dt";
			// 
			// dgc_done_dt
			// 
			this.dgc_done_dt.HeaderText = "Выполнена";
			this.dgc_done_dt.Name = "dgc_done_dt";
			// 
			// dgc_comment
			// 
			this.dgc_comment.HeaderText = "Комментарий";
			this.dgc_comment.Name = "dgc_comment";
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
			// txt_filter
			// 
			this.txt_filter.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txt_filter.Location = new System.Drawing.Point(12, 13);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(725, 30);
			this.txt_filter.TabIndex = 2;
			this.txt_filter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyUp);
			// 
			// btn_save
			// 
			this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_save.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_save.Location = new System.Drawing.Point(571, 432);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(166, 47);
			this.btn_save.TabIndex = 3;
			this.btn_save.Text = "Применить";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// frm_product_supply
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 491);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.dg_supply);
			this.Name = "frm_product_supply";
			this.Load += new System.EventHandler(this.frm_product_supply_Load);
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
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_seller_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_num;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_make_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_done_dt;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgc_comment;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_save;
	}
}