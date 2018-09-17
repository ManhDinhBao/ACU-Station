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
    public partial class ucChangePass : UserControl
    {
        string userId;
        public ucChangePass()
        {
            InitializeComponent();
        }

        public ucChangePass(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ucChangePass_Load(object sender, EventArgs e)
        {
            try
            {
                //Show user account of user login
                Users u = Users.LoadUsersById(userId);
                if (u != null)
                {
                    txtAccount.Text = u.UserName;
                    lblTitle.Text = u.Name;
                }

                //Reset control
                SetControl(true);
                txtPass.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetControl(bool mode)
        {
            txtAccount.ReadOnly = mode;
            txtNewPass.ReadOnly = mode;
            txtPass.ReadOnly = !mode;
            txtConfirmPass.ReadOnly = mode;
            btnVerify.Enabled = mode;
            btnApply.Enabled = !mode;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucSetting uc = new ucSetting(userId);
            Common.GoBack(uc, this);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string account = txtAccount.Text;
                string pass = txtPass.Text;

                Users u = Users.Login(account, pass);
                if(u!=null)
                {
                    SetControl(false);
                    txtAccount.ReadOnly = true;
                    txtNewPass.Focus();
                }
                else
                {
                    MessageBox.Show("Can't verify this account. Please check your password!");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string newPass = txtNewPass.Text;
                string confirmPass = txtConfirmPass.Text;

                if (newPass == confirmPass)
                {
                    Users u = Users.LoadUsersById(userId);
                    if (u != null)
                    {
                        u.PassWord = txtConfirmPass.Text;
                    }
                                  
                    string result = u.ChangePass(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Change password success!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetControl(true);
                        txtPass.Text = "";
                        txtConfirmPass.Text = "";
                        txtNewPass.Text = "";
                        txtNewPass.Text = "";
                        txtPass.Focus();
                    }
                    else
                    {
                        MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("New password and confirm password not same!");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
