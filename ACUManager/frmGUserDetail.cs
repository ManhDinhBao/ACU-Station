using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ACUManager
{
    public partial class frmGUserDetail : DevExpress.XtraEditors.XtraForm
    {
        string mode, title, groupId, userId;

        public frmGUserDetail()
        {
            InitializeComponent();
        }
        public frmGUserDetail(string mode, string title, string groupId, string userId)
        {
            InitializeComponent();
            this.mode = mode;
            this.title = title;
            this.groupId = groupId;
            this.userId = userId;
        }
        private void frmGUserDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (mode == "A") //Add new group
                {
                    this.Text = "Add new user group";
                    txtID.ReadOnly = false;
                    btnApply.Enabled = false;
                    txtID.Text = GroupUser.GenGroupId();
                }
                else
                    if (mode == "E") //Edit group
                {
                    this.Text = title;
                    txtID.ReadOnly = true;
                    btnApply.Enabled = true;
                    txtName.Focus();
                    GetGroupUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Show group user info in controls
        /// </summary>
        private void GetGroupUser()
        {
            try
            {
                GroupUser g = GroupUser.LoadGroupUserById(groupId);
                if (g != null)
                {
                    txtID.Text = g.groupId;
                    txtName.Text = g.groupName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Check exist group id 
        /// </summary>
        private void txtID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (mode == "A")
                {
                    GroupUser g = GroupUser.LoadGroupUserById(txtID.Text);
                    if (g != null)
                    {
                        lblTestID.Text = "Duplicate";
                        lblTestID.ForeColor = Color.Red;
                        btnApply.Enabled = false;
                        txtID.Focus();
                    }
                    else
                    {
                        lblTestID.Text = "OK";
                        lblTestID.ForeColor = Color.Green;
                        btnApply.Enabled = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }      

        /// <summary>
        /// Save data to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Count() <= 0)
                {
                    MessageBox.Show("Group ID can't be empty");
                    txtID.Focus();
                    return;
                }

                if (mode == "A")
                {
                    //Add new group user
                    GroupUser g = new GroupUser(txtID.Text, txtName.Text);
                    string result = g.Add(userId);
                    if (result == "OK")
                    {
                        DialogResult dr = MessageBox.Show("Add group " + txtName.Text + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            txtID.Text = GroupUser.GenGroupId();
                            txtName.Focus();
                            txtName.Text = "";
                            btnApply.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + result);
                    }
                }
                else
                    if (mode == "E")
                {
                    //Update group user
                    GroupUser g = new GroupUser(txtID.Text, txtName.Text);
                    string result = g.Update(userId);
                    if (result == "OK")
                    {
                        DialogResult dr = MessageBox.Show("Update group " + txtName.Text + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + result);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }     

       

    }
}