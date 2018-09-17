using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ACUManager
{
    public partial class frmMain : Form
    {
        string userId;
        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ucDashBoard uc = new ucDashBoard(userId);
            ShowFunction(uc);
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            ucUser uc = new ucUser(userId);
            ShowFunction(uc);
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            ucSetting uc = new ucSetting(userId);
            ShowFunction(uc);
        }

        private void btnDevice_Click(object sender, EventArgs e)
        {
            ucDevice uc = new ucDevice(userId);
            ShowFunction(uc);
        }

        private void btnDoor_Click(object sender, EventArgs e)
        {
            ucDoor uc = new ucDoor(userId);
            ShowFunction(uc);
        }

        private void btnAccessControl_Click(object sender, EventArgs e)
        {
            ucAccessControl uc = new ucAccessControl(userId);
            ShowFunction(uc);
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            ucMornitoring uc = new ucMornitoring();
            ShowFunction(uc);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for(int i=0;i<200;i++)
            {
                Thread.Sleep(10);
            }

            Users u = Users.LoadUsersById(userId);
            txtUser.Text = u.Name;

            ucDashBoard uc = new ucDashBoard(userId);
            panelData.Controls.Clear();
            panelData.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                frmSignIn frm = new frmSignIn();
                frm.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkHelp_Click(object sender, EventArgs e)
        {
            ucHelp uc = new ucHelp(userId);
            ShowFunction(uc);
        }

        private void ShowFunction(UserControl uc)
        {
            SplashScreenManager.ShowForm(typeof(frmWaitForm));
            for(int i=0;i<100;i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            panelData.Controls.Clear();
            panelData.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
