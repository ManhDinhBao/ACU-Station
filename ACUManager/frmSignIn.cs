using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Configuration;

namespace ACUManager
{
    public partial class frmSignIn : DevExpress.XtraEditors.XtraForm
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {
            //UpdateAppConfig("192.168.1.51:8088");
        }

        static void UpdateAppConfig(String Name)
        {
            var doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            XmlNodeList endpoints = doc.GetElementsByTagName("endpoint");
            foreach (XmlNode item in endpoints)
            {
                var addressAttribute = item.Attributes["address"];
                if (!ReferenceEquals(null, addressAttribute))
                {
                    addressAttribute.Value = "http://" + Name + "/WSACU.ASMX";

                }
            }
            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUserName.Text.Count()<=0)
                {
                    MessageBox.Show("Please input account name!");
                    txtUserName.Focus();
                    return;
                }

                if (txtPassword.Text.Count() <= 0)
                {
                    MessageBox.Show("Please input password!");
                    txtPassword.Focus();
                    return;
                }

                Users u = Users.Login(txtUserName.Text, txtPassword.Text);
                if(u!=null)
                {                    
                    frmMain frm = new frmMain(u.Id);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong user name or password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            frmForgot frm = new frmForgot();
            frm.ShowDialog();
        }

        private void frmSignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }                

        private void btnPassMode_Click(object sender, EventArgs e)
        {
            if (txtPassword.isPassword)
            {
                txtPassword.isPassword = false;
            }
            else
            {
                txtPassword.isPassword = true;
            }
        }
    }
}