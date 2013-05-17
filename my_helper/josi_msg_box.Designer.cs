namespace josi.store
{
    partial class josi_msg_box
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.rich_msg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.AutoSize = true;
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_ok.Location = new System.Drawing.Point(492, 0);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(115, 41);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "ОК";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.AutoSize = true;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_cancel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_cancel.Location = new System.Drawing.Point(0, 0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(115, 41);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // rich_msg
            // 
            this.rich_msg.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rich_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rich_msg.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rich_msg.Location = new System.Drawing.Point(8, 8);
            this.rich_msg.Name = "rich_msg";
            this.rich_msg.ReadOnly = true;
            this.rich_msg.Size = new System.Drawing.Size(601, 67);
            this.rich_msg.TabIndex = 4;
            this.rich_msg.Text = "Проверьте правильность введеннх данных. Если все введено верно, нажмите ОК";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 41);
            this.panel1.TabIndex = 5;
            // 
            // josi_msg_box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(617, 126);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rich_msg);
            this.MaximumSize = new System.Drawing.Size(625, 500);
            this.MinimumSize = new System.Drawing.Size(625, 125);
            this.Name = "josi_msg_box";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Внимание!!!";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.RichTextBox rich_msg;
        private System.Windows.Forms.Panel panel1;
    }
}