using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACUManager.Dialog
{
    public partial class SuccessDialog : Form
    {
        public SuccessDialog()
        {
            InitializeComponent();
        }

        public SuccessDialog(string title,string content)
        {
            InitializeComponent();
            lblTitle.Text = title;
            txtContent.Text = content;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
