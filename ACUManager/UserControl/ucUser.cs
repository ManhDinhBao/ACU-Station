using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Effects;
using Bunifu.Framework.UI;
using System.IO;
using System.Threading;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;

namespace ACUManager
{
    public partial class ucUser : UserControl
    {
        string userId, groupUserId,groupUserName;
        DataTable dtSource=new DataTable();
        public ucUser()
        {
            InitializeComponent();
        }
        public ucUser(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void ucUser_Load(object sender, EventArgs e)
        {

            GenTreeUserData();
        }

        #region Common
        /// <summary>
        /// Generate Treelist structure
        /// </summary>
        private void GenTreeUserData()
        {
            List<GroupUser> groupUsers = GroupUser.LoadAllUserGroup();
            CreateColumns(treeMenu);
            CreateTree(treeMenu, groupUsers);
        }

        /// <summary>
        /// Create treee colums
        /// </summary>
        /// <param name="tl">TreeList need create columns</param>
        private void CreateColumns(TreeList tl)
        {
            try
            {
                // Create 2 columns.
                tl.BeginUpdate();
                TreeListColumn col1 = tl.Columns.Add();
                col1.Caption = "GroupId";
                col1.VisibleIndex = 0;
                col1.Visible = false;
                TreeListColumn col2 = tl.Columns.Add();
                col2.Caption = "GroupName";
                col2.VisibleIndex = 1;
                TreeListColumn col3 = tl.Columns.Add();
                col3.Caption = "mode";
                col3.VisibleIndex = 2;
                col3.Visible = false;

                tl.EndUpdate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Create treee structure
        /// </summary>
        /// <param name="tl">TreeList need create</param>
        private void CreateTree(TreeList tl, List<GroupUser> groupUsers)
        {
            try
            {
                tl.BeginUnboundLoad();
                // Create a root node .
                treeMenu.Nodes.Clear();
                TreeListNode treeRootNodes = null;
                TreeListNode parentForRootNodes = tl.AppendNode(new object[] { "", "All user", "R" }, treeRootNodes);

                foreach (GroupUser g in groupUsers)
                {
                    //Create note
                    TreeListNode rootNode = tl.AppendNode(new object[] { g.groupId, g.groupName, "G" }, parentForRootNodes);

                    //Create child of note
                    foreach (Users u in g.ListUsers)
                    {
                        tl.AppendNode(new object[] { u.Id, u.Name, "I" }, rootNode);
                    }
                }
                tl.EndUnboundLoad();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Init data table structure for store user data => show in grid control
        /// </summary>
        /// <param name="dt"></param>
        private void InitTableStructure(DataTable dt)
        {
            dt.Columns.Clear();
            dt.Columns.Add("userId", typeof(string));
            dt.Columns.Add("personName", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("card", typeof(int));
            dt.Columns.Add("status", typeof(string));
        }
        #endregion

        #region treeUser
        /// <summary>
        /// Show user info in gridcontrol when user choose in treelist control
        /// </summary>
        private void treeMenu_RowCellClick(object sender, DevExpress.XtraTreeList.RowCellClickEventArgs e)
        {
            try
            {
                TreeList treeList = (TreeList)sender;
                TreeListMultiSelection selectedNodes = treeList.Selection;
                //Get mode from treelist
                //G: Group 
                //R: All user
                //I: One user
                string mode = selectedNodes[0].GetValue(treeList.Columns[2]).ToString();

                //Edit user group info
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Right)
                {
                    if (mode == "G")
                    {
                        groupUserId = selectedNodes[0].GetValue(treeList.Columns[0]).ToString();
                        groupUserName = selectedNodes[0].GetValue(treeList.Columns[1]).ToString();
                        popupUser.ShowPopup(Control.MousePosition);

                    }
                    return;

                }

                //Load user information to grid
                string title = "";

                //Get all user          
                List<GroupUser> groupUsers = GroupUser.LoadAllUserGroup();

                //Init DataTable
                InitTableStructure(dtSource);



                if (mode == "R")
                {
                    dtSource.Clear();
                    DataTable dt = new DataTable();
                    InitTableStructure(dt);

                    //Load all user to grid
                    foreach (GroupUser g in groupUsers)
                    {
                        dt = g.ToDataTable();
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            dtSource.ImportRow(dr1);
                        }
                    }
                    title = "All user";
                }
                else
                    if (mode == "G")
                {
                    dtSource.Clear();
                    string groupUserId = selectedNodes[0].GetValue(treeList.Columns[0]).ToString();

                    //Load user by group to grid
                    foreach (GroupUser g in groupUsers)
                    {
                        if (g.groupId == groupUserId)
                        {
                            dtSource = g.ToDataTable();
                            title = g.groupName;
                        }
                    }
                }
                else
                    if (mode == "I")
                {
                    dtSource.Clear();
                    string userId = selectedNodes[0].GetValue(treeList.Columns[0]).ToString();

                    //Load one user to grid
                    foreach (GroupUser g in groupUsers)
                    {
                        foreach (Users u in g.ListUsers)
                        {
                            if (u.Id == userId)
                            {
                                DataRow dr2 = dtSource.NewRow();
                                dr2["userId"] = u.Id;
                                dr2["personName"] = u.Name;
                                dr2["email"] = u.Email;
                                if (u.ListCard == null)
                                {
                                    dr2["card"] = 0;
                                }
                                else
                                    dr2["card"] = u.ListCard.Count;
                                dtSource.Rows.Add(dr2);
                                if (Convert.ToBoolean(u.Status))
                                {
                                    dr2["status"] = "Active";
                                }
                                else
                                    dr2["status"] = "Deactive";
                                title = u.Name;
                            }
                        }
                    }
                }

                gridUser.DataSource = dtSource;
                lblTitle.Text = title;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void treeMenu_MouseUp(object sender, MouseEventArgs e)
        {
            //MouseEventArgs me = (MouseEventArgs)e;
            //if (me.Button == MouseButtons.Right)
            //{
            //    popupAddGUser.ShowPopup(Control.MousePosition);             
            //}
        }
        #endregion

        #region grid  
        /// <summary>
        /// Delete user group when user choose delete in popup
        /// </summary>
        private void DeleteUGroup(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (groupUserId.Count() <= 0)
                {
                    MessageBox.Show("Please choose user group!");
                }
                else
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete group: " + groupUserName + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        //Delete group user
                        GroupUser g = new GroupUser(groupUserId, groupUserName);
                        string result = g.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete group " + groupUserName + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                GenTreeUserData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show group detail when user choose edit in popup
        /// </summary>
        /// <remarks>
        /// Mode = E
        /// </remarks>
        private void itemEditGUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (groupUserId.Count() <= 0)
                {
                    MessageBox.Show("Please choose user group!");
                }
                else
                {
                    frmGUserDetail frm = new frmGUserDetail("E", groupUserName, groupUserId, userId);
                    DialogResult r = frm.ShowDialog();
                    if (r == DialogResult.Cancel)
                    {
                        GenTreeUserData();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Delete user when user choose delete in popup
        /// </summary>
        private void itemDeleteUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue(gcUserId).ToString();
                string name = gridView1.GetFocusedRowCellValue(gcUserName).ToString();
                Users u = Users.LoadUsersById(id);
                if (id != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete user: " + gcUserName + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        //Delete user                   
                        string result = u.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete user " + groupUserName + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                GenTreeUserData();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show popup delete user when user right click on grid control
        /// </summary>
        private void gridUser_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDeleteUser.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// Show group detail when user choose add group in popup
        /// </summary>
        /// <remarks>
        /// Mode = A
        /// </remarks>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Add new group user
                frmGUserDetail frm = new frmGUserDetail("A", "", "", "");
                DialogResult r = frm.ShowDialog();
                if (r == DialogResult.Cancel)
                {
                    ucUser_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Show user detail form
        /// </summary>
        /// <remarks>
        /// Mode = E
        /// </remarks>
        private void gridUser_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Get user id, name
                string Id = gridView1.GetFocusedRowCellDisplayText(gcUserId);
                string Name = gridView1.GetFocusedRowCellDisplayText(gcUserName);

                //Show info 
                ucUserInfo uc = new ucUserInfo("E", Id, Name, userId);
                Common.GoBack(uc, this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show user detail form
        /// </summary>
        /// <remarks>
        /// Mode = A
        /// </remarks>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                ucUserInfo uc = new ucUserInfo("A", "", "", userId);
                Panel p = (this.Parent as Panel);
                p.Controls.Clear();
                p.Controls.Add(uc);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion


    }
}
