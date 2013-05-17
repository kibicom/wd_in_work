using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace josi.store
{
    public partial class josi_msg_box : Form
    {
        static private josi_msg_box msg_box;
        static private bool last_relust;


        public josi_msg_box()
        {
            InitializeComponent();
        }

        public josi_msg_box(string msg)
        {
            InitializeComponent();
            rich_msg.Text = msg;
        }

        public josi_msg_box(string msg, string caption)
        {
            InitializeComponent();
        }

        static public bool fshow(string msg)
        {
            if (msg_box == null)
            {
                msg_box = new josi_msg_box();
            }
            msg_box.rich_msg.Text = msg;
            msg_box.ShowDialog();

            return last_relust;
            //msg_box.Text = caption;
        }

        static public bool fshow(string msg, string btn_ok_text, string btn_cancel_text)
        {
            if (msg_box == null)
            {
                msg_box = new josi_msg_box();
            }
            msg_box.rich_msg.Text = msg;
            //msg_box.Text = caption;

            msg_box.btn_ok.Text = btn_ok_text;
            msg_box.btn_cancel.Text = btn_cancel_text;

            msg_box.rich_msg.Height = msg_box.rich_msg.GetPositionFromCharIndex(msg_box.rich_msg.TextLength).Y+100;

            msg_box.Height = msg_box.rich_msg.GetPositionFromCharIndex(msg_box.rich_msg.TextLength - 1).Y;

            msg_box.Refresh();

            msg_box.ShowDialog();

            return last_relust;
        }

        static public bool fshow(string msg, string caption)
        {
            if (msg_box == null)
            {
                msg_box = new josi_msg_box();
            }
            msg_box.rich_msg.Text = msg;
            msg_box.Text = caption;

            msg_box.rich_msg.Height = msg_box.rich_msg.GetPositionFromCharIndex(msg_box.rich_msg.TextLength - 1).Y;

            msg_box.ShowDialog();

            return last_relust;
        }

        static public bool fshow(string msg, string caption, string btn_ok_text, string btn_cancel_text)
        {
            if (msg_box == null)
            {
                msg_box = new josi_msg_box();
            }
            msg_box.rich_msg.Text = msg;
            msg_box.Text = caption;

            msg_box.btn_ok.Text = btn_ok_text;
            msg_box.btn_cancel.Text = btn_cancel_text;

            msg_box.rich_msg.Height = msg_box.rich_msg.GetPositionFromCharIndex(msg_box.rich_msg.TextLength - 1).Y;

            //msg_box.rich_msg.Height=msg_box.rich_msg.Text.Length+30;

            msg_box.ShowDialog();

            return last_relust;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            last_relust = false;
            msg_box.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            last_relust = true;
            msg_box.Close();
        }
    }
}