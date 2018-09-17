using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACUManager
{
    public partial class ucSetting : UserControl
    {
        string userId;
        public ucSetting()
        {
            InitializeComponent();
        }

        public ucSetting(string _userId)
        {
            InitializeComponent();
            userId = _userId;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ucSchedule uc = new ucSchedule(userId);
            Common.GoBack(uc, this);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ucChangePass uc = new ucChangePass(userId);
            Common.GoBack(uc, this);
        }
    }
}
