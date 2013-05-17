namespace josi.store
{
    partial class josi_customer_add
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
            this.btnAction = new System.Windows.Forms.Button();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.menu_lbx_items = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_fio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_card = new System.Windows.Forms.TextBox();
            this.btn_edit_cancel = new System.Windows.Forms.Button();
            this.btn_edit_save = new System.Windows.Forms.Button();
            this.menu_lbx_items.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAction.Location = new System.Drawing.Point(246, 328);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(480, 33);
            this.btnAction.TabIndex = 6;
            this.btnAction.Text = "Поиск";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.bntAction_Click);
            // 
            // lbxItems
            // 
            this.lbxItems.AllowDrop = true;
            this.lbxItems.BackColor = System.Drawing.Color.White;
            this.lbxItems.ContextMenuStrip = this.menu_lbx_items;
            this.lbxItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxItems.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbxItems.IntegralHeight = false;
            this.lbxItems.ItemHeight = 40;
            this.lbxItems.Location = new System.Drawing.Point(491, 6);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.Size = new System.Drawing.Size(473, 316);
            this.lbxItems.TabIndex = 5;
            this.lbxItems.SelectedIndexChanged += new System.EventHandler(this.lbxItems_SelectedIndexChanged);
            this.lbxItems.Leave += new System.EventHandler(this.lbxItems_Leave);
            this.lbxItems.Enter += new System.EventHandler(this.lbxItems_Enter);
            this.lbxItems.MouseEnter += new System.EventHandler(this.lbxItems_MouseEnter);
            this.lbxItems.DoubleClick += new System.EventHandler(this.lbxItems_DoubleClick);
            this.lbxItems.MouseLeave += new System.EventHandler(this.lbxItems_MouseLeave);
            this.lbxItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbxItems_KeyUp);
            this.lbxItems.Click += new System.EventHandler(this.lbxItems_Click);
            // 
            // menu_lbx_items
            // 
            this.menu_lbx_items.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_edit});
            this.menu_lbx_items.Name = "menu_lbx_items";
            this.menu_lbx_items.Size = new System.Drawing.Size(165, 26);
            // 
            // mi_edit
            // 
            this.mi_edit.Name = "mi_edit";
            this.mi_edit.Size = new System.Drawing.Size(164, 22);
            this.mi_edit.Text = "Редактировать";
            this.mi_edit.Click += new System.EventHandler(this.mi_edit_Click);
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_address.Location = new System.Drawing.Point(121, 74);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(364, 27);
            this.txt_address.TabIndex = 2;
            this.txt_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fio_KeyDown);
            this.txt_address.Enter += new System.EventHandler(this.txt_fio_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Адрес";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_email.Location = new System.Drawing.Point(121, 108);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(364, 27);
            this.txt_email.TabIndex = 3;
            this.txt_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fio_KeyDown);
            this.txt_email.Enter += new System.EventHandler(this.txt_fio_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_phone.Location = new System.Drawing.Point(121, 41);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(364, 27);
            this.txt_phone.TabIndex = 1;
            this.txt_phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fio_KeyDown);
            this.txt_phone.Enter += new System.EventHandler(this.txt_fio_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Телефоны";
            // 
            // txt_fio
            // 
            this.txt_fio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_fio.Location = new System.Drawing.Point(121, 6);
            this.txt_fio.Name = "txt_fio";
            this.txt_fio.Size = new System.Drawing.Size(364, 27);
            this.txt_fio.TabIndex = 0;
            this.txt_fio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fio_KeyDown);
            this.txt_fio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fio_KeyPress);
            this.txt_fio.Enter += new System.EventHandler(this.txt_fio_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "ФИО";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 174);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(473, 148);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar1.Location = new System.Drawing.Point(683, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Value = 50;
            this.progressBar1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Карта";
            // 
            // txt_card
            // 
            this.txt_card.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_card.Location = new System.Drawing.Point(121, 141);
            this.txt_card.Name = "txt_card";
            this.txt_card.Size = new System.Drawing.Size(364, 27);
            this.txt_card.TabIndex = 4;
            this.txt_card.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fio_KeyDown);
            this.txt_card.Enter += new System.EventHandler(this.txt_fio_Enter);
            // 
            // btn_edit_cancel
            // 
            this.btn_edit_cancel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_edit_cancel.Location = new System.Drawing.Point(12, 328);
            this.btn_edit_cancel.Name = "btn_edit_cancel";
            this.btn_edit_cancel.Size = new System.Drawing.Size(228, 33);
            this.btn_edit_cancel.TabIndex = 6;
            this.btn_edit_cancel.Text = "Отменить";
            this.btn_edit_cancel.UseVisualStyleBackColor = true;
            this.btn_edit_cancel.Visible = false;
            this.btn_edit_cancel.Click += new System.EventHandler(this.btn_edit_cancel_Click);
            // 
            // btn_edit_save
            // 
            this.btn_edit_save.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_edit_save.Location = new System.Drawing.Point(732, 328);
            this.btn_edit_save.Name = "btn_edit_save";
            this.btn_edit_save.Size = new System.Drawing.Size(232, 33);
            this.btn_edit_save.TabIndex = 6;
            this.btn_edit_save.Text = "Сохранить";
            this.btn_edit_save.UseVisualStyleBackColor = true;
            this.btn_edit_save.Visible = false;
            this.btn_edit_save.Click += new System.EventHandler(this.btn_edit_save_Click);
            // 
            // josi_customer_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 366);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lbxItems);
            this.Controls.Add(this.txt_card);
            this.Controls.Add(this.btn_edit_cancel);
            this.Controls.Add(this.btn_edit_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_fio);
            this.Controls.Add(this.label1);
            this.Name = "josi_customer_add";
            this.Text = "Клиенты ВЕНТА";
            this.Load += new System.EventHandler(this.josi_customer_add_Load);
            this.menu_lbx_items.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ListBox lbxItems;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_fio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_card;
        private System.Windows.Forms.ContextMenuStrip menu_lbx_items;
        private System.Windows.Forms.ToolStripMenuItem mi_edit;
        private System.Windows.Forms.Button btn_edit_cancel;
        private System.Windows.Forms.Button btn_edit_save;
    }
}