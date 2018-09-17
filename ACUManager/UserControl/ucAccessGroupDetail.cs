using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace ACUManager
{
    public partial class ucAccessGroupDetail : UserControl
    {
        string title, userId;
        string mode, accessGroupId;
        List<Users> users;
        List<GroupUser> groupUsers;
        List<AccessLevel> accessLevels;

        public ucAccessGroupDetail()
        {
            InitializeComponent();
        }
        public ucAccessGroupDetail(string _title, string _mode,string _userId,string _accessGroupId)
        {
            InitializeComponent();
            this.title = _title;
            this.mode = _mode;
            this.userId = _userId;
            this.accessGroupId = _accessGroupId;
        }
        private void ucAccessGroupDetail_Load(object sender, EventArgs e)
        {           

            //Set title
            lblTitle.Text = title;

            LoadAllAccessLevel();
            LoadAllUserGroup();
            LoadAllUser();
           
            //Mode = A: Add new 
            //Mode = E: modify
            if (mode == "A")
            {
                txtID.ReadOnly = false;
                txtID.Text = GroupAccess.GenGroupId();
            }
            else
            if (mode == "E")
            {
                txtID.ReadOnly = true;
                ShowAGInfo();
            }
          

        }

        #region common
        /// <summary>
        /// Show access group detail
        /// </summary>
        private void ShowAGInfo()
        {
            try
            {
                GroupAccess group = GroupAccess.GetAccessGroupById(accessGroupId);
                if (group != null)
                {
                    txtID.Text = group.groupId;
                    txtName.Text = group.groupName;
                    txtDescription.Text = group.GroupDescription;

                    //Fill user in checked combo box
                    foreach (Users u in group.ListUsers)
                    {
                        int index = users.FindIndex(f => f.Id == u.Id);
                        if (index >= 0)
                        {
                            chkcbUser.Properties.Items[index].CheckState = CheckState.Checked;
                        }
                    }

                    //Fill user group in checked combo box
                    foreach (GroupUser groupU in group.ListGroupUsers)
                    {
                        int index = groupUsers.FindIndex(f => f.groupId == groupU.groupId);
                        if (index >= 0)
                        {
                            chkcbUserGroup.Properties.Items[index].CheckState = CheckState.Checked;
                        }
                    }

                    //Fill access level in checked combo box
                    foreach (AccessLevel accessLv in group.AccessLv)
                    {
                        int index = accessLevels.FindIndex(f => f.groupId == accessLv.groupId);
                        if (index >= 0)
                        {
                            chkcbAccessLevel.Properties.Items[index].CheckState = CheckState.Checked;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load all user from DB and fill into checked combo box
        /// </summary>
        private void LoadAllUser()
        {
            try
            {
                users = Users.LoadAllUsers();
                foreach (Users u in users)
                {
                    CheckedListBoxItem listBoxItem = new CheckedListBoxItem();
                    listBoxItem.Value = u.Id;
                    listBoxItem.Description = u.Name;

                    chkcbUser.Properties.Items.Add(listBoxItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load all user group from DB and fill into checked combo box
        /// </summary>
        private void LoadAllUserGroup()
        {
            try
            {
                groupUsers = GroupUser.LoadAllUserGroup();
                foreach (GroupUser u in groupUsers)
                {
                    CheckedListBoxItem listBoxItem = new CheckedListBoxItem();
                    listBoxItem.Value = u.groupId;
                    listBoxItem.Description = u.groupName;

                    chkcbUserGroup.Properties.Items.Add(listBoxItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load all access level from DB and fill into checked combo box
        /// </summary>
        private void LoadAllAccessLevel()
        {
            try
            {
                accessLevels = AccessLevel.LoadAllAccessLevel();
                foreach (AccessLevel u in accessLevels)
                {
                    CheckedListBoxItem listBoxItem = new CheckedListBoxItem();
                    listBoxItem.Value = u.groupId;
                    listBoxItem.Description = u.groupName;

                    chkcbAccessLevel.Properties.Items.Add(listBoxItem);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Get user what state = checked in checked combo box
        /// </summary>
        /// <returns>list of user</returns>
        private List<Users> GetUsersSave()
        {
            List<Users> userSend = new List<Users>();
            try
            {
                foreach (CheckedListBoxItem item in chkcbUser.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        int pos = chkcbUser.Properties.Items.IndexOf(item);
                        Users u = users[pos];
                        userSend.Add(u);
                    }

                }
                return userSend;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user group what state = checked in checked combo box
        /// </summary>
        /// <returns>list of user group</returns>
        private List<GroupUser> GetGroupUsersSave()
        {
            List<GroupUser> GuserSend = new List<GroupUser>();
            try
            {
                foreach (CheckedListBoxItem item in chkcbUserGroup.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        int pos = chkcbUserGroup.Properties.Items.IndexOf(item);
                        GroupUser g = groupUsers[pos];
                        GuserSend.Add(g);
                    }

                }
                return GuserSend;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get access level what state = checked in checked combo box
        /// </summary>
        /// <returns>list of access level</returns>
        private List<AccessLevel> GetAccessLvSave()
        {
            List<AccessLevel> accessLv = new List<AccessLevel>();
            try
            {
                foreach (CheckedListBoxItem item in chkcbAccessLevel.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        int pos = chkcbAccessLevel.Properties.Items.IndexOf(item);
                        AccessLevel g = accessLevels[pos];
                        accessLv.Add(g);
                    }

                }
                return accessLv;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucAccessControl uc = new ucAccessControl(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Save data to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {

                //Mode = A: Add new 
                //Mode = E: modify
                GroupAccess g = new GroupAccess(txtID.Text, txtName.Text, txtDescription.Text, GetAccessLvSave(), GetUsersSave(), GetGroupUsersSave());
                if (mode == "A")
                {
                    if (txtID.Text.Count() <= 0)
                    {
                        MessageBox.Show("Please input group ID");
                        txtID.Focus();
                        return;
                    }
                    //Add new access group
                    string result = g.Add(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add group access " + txtName.Text + " success!");
                        txtID.Text = GroupAccess.GenGroupId();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + result);
                    }

                }
                else
                if (mode == "E")
                {
                    //Update access group info
                    string result = g.Update(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update group access " + txtName.Text + " success!");
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
