using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace ACUManager
{
    public partial class ucUserInfo : UserControl
    {
        string mode, id, name,userId, cardNo;
        int cardIndex;
        public ucUserInfo()
        {
            InitializeComponent();
        }
        public ucUserInfo(string _mode, string _id, string _name,string _userId)
        {
            InitializeComponent();
            mode = _mode;
            id = _id;
            name = _name;
            userId = _userId;
        }
        private void ucUserInfo_Load(object sender, EventArgs e)
        {         
            //Reset control
            ResetControl();
            GetComboBoxData();

            if (mode == "A")
            {
                lblTitle.Text = "Add new user";             
                txtUserId.ReadOnly = false;
                txtUserId.Text = Users.GenUserId();
            }
            else
                if (mode == "E")
            {
                lblTitle.Text = name;
                txtUserId.ReadOnly = true;
                ShowUserInfo(id);
            }
        }

        #region Common
        /// <summary>
        /// Reset control after save
        /// </summary>
        private void ResetControl()
        {
            txtName.Text = "";            
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            lblCheckAccount.Text = "";
            listCard.Items.Clear();
            picAvatar.Image = ACUManager.Properties.Resources.avatar__1_;
            dateStart.EditValue = DateTime.Now;
            dateEnd.EditValue = DateTime.Now;
            txtUserId.Text = Users.GenUserId();
        }

        /// <summary>
        /// Get group access, operator level, Group user from DB and add in combobox
        /// </summary>
        private void GetComboBoxData()
        {
            try
            {
                List<GroupAccess> groupAccesses = GroupAccess.GetAllAccessGroup();
                cboAccess.Properties.DataSource = groupAccesses;
                cboAccess.Properties.DisplayMember = "groupName";
                cboAccess.Properties.ValueMember = "groupId";

                List<OperatorLevel> operatorLevels = OperatorLevel.GetAllOptLevel();
                cboOptLevel.Properties.DataSource = operatorLevels;
                cboOptLevel.Properties.DisplayMember = "OptName";
                cboOptLevel.Properties.ValueMember = "OptId";

                List<GroupUser> groupUsers = GroupUser.LoadAllUserGroup();
                cboGroup.Properties.DataSource = groupUsers;
                cboGroup.Properties.DisplayMember = "groupName";
                cboGroup.Properties.ValueMember = "groupId";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show user info in controls when user choose edit user
        /// </summary>
        /// <param name="Id">ID of user</param>
        private void ShowUserInfo(string Id)
        {
            try
            {
                Users u = Users.LoadUsersById(Id);
                if (u != null)
                {
                    txtUserId.Text = u.Id;
                    txtName.Text = u.Name;
                    dateStart.EditValue = u.StartDate;
                    dateEnd.EditValue = u.ExperiedDate;
                    txtUserName.Text = u.UserName;
                    txtPassword.Text = u.PassWord;
                    txtEmail.Text = u.Email;
                    txtPhoneNo.Text = u.PhoneNo;
                    switchStatus.Value = u.Status;

                    GroupUser g = GroupUser.LoadGroupUserByUserId(u.Id);
                    if (g != null)
                    {
                        cboGroup.EditValue = g.groupId;
                        cboGroup.Text = g.groupName;
                    }

                    OperatorLevel o = OperatorLevel.GetOptLevelByUser(u.Id);
                    if (o != null)
                    {
                        cboOptLevel.EditValue = o.OptId;
                        cboOptLevel.Text = o.OptName;
                    }

                    GroupAccess access = GroupAccess.GetAccessGroupByUser(u.Id);
                    if (access != null)
                    {
                        cboAccess.EditValue = access.groupId;
                        cboAccess.Text = access.groupName;
                    }

                    picAvatar.Image = Common.byteArrayToImage(u.Avatar);

                    foreach (Card c in u.ListCard)
                    {
                        listCard.Items.Add(c.CardNo);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Change user status
        /// </summary>
        private void switchStatus_OnValueChange(object sender, EventArgs e)
        {
            if (switchStatus.Value == true)
            {
                lblStatus.Text = "Active";
            }
            else
            {
                lblStatus.Text = "Deactive";
            }
        }

        /// <summary>
        /// Show avatar in picturebox after user click OK in dialog 
        /// </summary>
        private void openFileAvatar_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string file = openFileAvatar.FileName;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                System.IO.FileStream fileStream = fileInfo.OpenRead();
                picAvatar.Image = System.Drawing.Image.FromStream(fileStream);
                Application.DoEvents();
                fileStream.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Check exsist account
        /// </summary>
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Users.CheckUserAccount(txtUserName.Text))
                {
                    lblCheckAccount.Text = "OK";
                    lblCheckAccount.ForeColor = Color.Green;
                    btnApply.Enabled = true;
                }
                else
                {
                    lblCheckAccount.Text = "Duplicate";
                    lblCheckAccount.ForeColor = Color.Red;
                    btnApply.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkPin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPin.Checked == true)
            {
                txtPIN.ReadOnly = false;
            }
            else
            {
                txtPIN.ReadOnly = true;
            }
        }

        #region Click
        /// <summary>
        /// Go back user master form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            ucUser uc = new ucUser(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Show popup list card
        /// </summary>
        private void btnAddCard_Click(object sender, EventArgs e)
        {
            popupCard.Show();
        }

        /// <summary>
        /// Show open file dialog for choose user avatar
        /// </summary>
        private void btnLoadAvatar_Click(object sender, EventArgs e)
        {
            openFileAvatar.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileAvatar.Title = "Please select image for user avatar";
            openFileAvatar.ShowDialog();
        }

        /// <summary>
        /// Close card popup
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            popupCard.Hide();
        }

        /// <summary>
        /// Add card to list card
        /// </summary>
        private void btnInserCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCardNo.Text.Count() > 0)
                {
                    listCard.Items.Add(txtCardNo.Text);
                    txtCardNo.Text = "";
                    txtCardNo.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show popup when user right click in list card control
        /// </summary>
        private void listCard_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxControl listBox = (ListBoxControl)sender;
                cardIndex = listBox.SelectedIndex;
                cardNo = listBox.GetItemText(cardIndex);
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    popupDeleteCard.ShowPopup(Control.MousePosition);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Clear all items in list card
        /// </summary>
        private void itemDeleteAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listCard.Items.Clear();
        }

        /// <summary>
        /// Delete item what user choose in list card
        /// </summary>
        private void itemDeleteCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listCard.Items.RemoveAt(cardIndex);
        }

        /// <summary>
        /// Save data to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup.Text == "Choose user group...")
                {
                    MessageBox.Show("Please choose user group!");
                    return;
                }

                if (cboOptLevel.Text == "Choose operator level...")
                {
                    MessageBox.Show("Please choose operator level!");
                    return;
                }

                if (cboAccess.Text == "Choose access group...")
                {
                    MessageBox.Show("Please choose access group!");
                    return;
                }

                List<Card> cards = new List<Card>();
                for (int i = 0; i < listCard.ItemCount; i++)
                {
                    Card card = new Card("", listCard.Items[i].ToString());
                    cards.Add(card);
                }

                //string ext = Path.GetExtension(openFileAvatar.FileName);
                byte[] image = Common.ImageToByteArray(picAvatar.Image);

                Users u = new Users(txtUserId.Text, txtName.Text, txtUserName.Text, txtPassword.Text,
                        txtEmail.Text, txtPhoneNo.Text, switchStatus.Value, cboOptLevel.EditValue.ToString(), cards,
                        image, Convert.ToDateTime(dateStart.EditValue), Convert.ToDateTime(dateEnd.EditValue));

                if (mode == "A")
                {
                    string result = u.Add(cboGroup.EditValue.ToString(), cboAccess.EditValue.ToString(), userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add user: " + u.UserName + " success!");
                        ResetControl();
                        GetComboBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Add user: " + u.UserName + " fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    if (mode == "E")
                {
                    Users user = Users.LoadUsersById(u.Id);

                    //Delete old card
                    foreach (Card c in user.ListCard)
                    {
                        string r = c.Delete(userId);
                    }

                    string r1 = Card.DeleteAllUser(u.Id, userId);

                    //Update user info
                    string result = u.Update(cboGroup.EditValue.ToString(), cboAccess.EditValue.ToString(), userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update user: " + u.UserName + " success!");

                    }
                    else
                    {
                        MessageBox.Show("Update user: " + u.UserName + " fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

    }
}
