using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace ACUManager
{    
         
    public partial class ucAccessControl : UserControl
    {
        string userId;
        DataTable dt;
        public ucAccessControl()
        {
            InitializeComponent();
        }
        public ucAccessControl(string _userId)
        {
            InitializeComponent();
            userId = _userId;
        }
        private void ucAccessControl_Load(object sender, EventArgs e)
        {
            InitTableStructure();
            xtraTabControl1.SelectedTabPage = xtabGroup;
            GetAllGroupAccess();

        }

        #region Common
        /// <summary>
        /// Init table structure for show data in gridcontrol
        /// </summary>
        private void InitTableStructure()
        {
            dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("number", typeof(string));
        }

        /// <summary>
        /// Get all access group from DB
        /// </summary>
        private void GetAllGroupAccess()
        {
            try
            {
                //Load all access group
                List<GroupAccess> group = GroupAccess.GetAllAccessGroup();

                listAccessGroup.DataSource = group;
                listAccessGroup.DisplayMember = "groupName";
                listAccessGroup.ValueMember = "groupId";

                gcDescription.Caption = "Description";
                dt.Clear();

                //Create grid soure
                foreach (GroupAccess g in group)
                {
                    DataRow row = dt.NewRow();
                    row["id"] = g.groupId;
                    row["name"] = g.groupName;
                    row["number"] = g.GroupDescription;

                    dt.Rows.Add(row);
                }
                gridData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Get all access level from DB
        /// </summary>
        private void GetAllAccessLevel()
        {
            try
            {
                //Load all access level
                List<AccessLevel> accessLevels = AccessLevel.LoadAllAccessLevel();

                listAccessLevel.DataSource = accessLevels;
                listAccessLevel.DisplayMember = "groupName";
                listAccessLevel.ValueMember = "groupId";

                gcDescription.Caption = "Description";
                dt.Clear();

                //Create grid soure
                foreach (AccessLevel ac in accessLevels)
                {
                    DataRow row = dt.NewRow();
                    row["id"] = ac.groupId;
                    row["name"] = ac.groupName;
                    row["number"] = "";

                    dt.Rows.Add(row);
                }
                gridData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Tab Access Group
        /// <summary>
        /// Add new access group
        /// </summary>
        private void btnAddAG_Click(object sender, EventArgs e)
        {
            ucAccessGroupDetail uc = new ucAccessGroupDetail("Add New Access Group", "A", userId, "");
            Panel p = (this.Parent as Panel);
            p.Controls.Clear();
            p.Controls.Add(uc);
        }

        /// <summary>
        /// Show access group info on gridcontrol
        /// </summary>
        private void listAccessGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listAccessGroup.SelectedValue != null)
                {
                    string groupId = listAccessGroup.SelectedValue.ToString();
                    GroupAccess g = GroupAccess.GetAccessGroupById(groupId);
                    if (g != null)
                    {
                        dt.Clear();
                        DataRow row = dt.NewRow();
                        row["id"] = g.groupId;
                        row["name"] = g.groupName;
                        row["number"] = g.GroupDescription;

                        dt.Rows.Add(row);
                        gridData.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Delete access group
        /// </summary>
        private void itemDelACSGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                GroupAccess g = (GroupAccess)listAccessGroup.SelectedItem;

                if (g != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete access group: " + g.groupName + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        string result = g.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete access group " + g.groupName + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                GetAllGroupAccess();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
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
        /// Show popup when user right click
        /// </summary>
        private void listAccessGroup_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDelACSGroup.ShowPopup(Control.MousePosition);
            }
        }

        #endregion

        #region Tab Access Level
        /// <summary>
        /// Add new access level
        /// </summary>
        private void btnAddAccessLevel_Click(object sender, EventArgs e)
        {
            ucAccessLevelDetail uc = new ucAccessLevelDetail(userId, "A", "");
            Panel p = (this.Parent as Panel);
            p.Controls.Clear();
            p.Controls.Add(uc);
        }

        /// <summary>
        /// Delete access level
        /// </summary>
        private void itemDelACSLevel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AccessLevel g = (AccessLevel)listAccessLevel.SelectedItem;

                if (g != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete access level: " + g.groupName + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        string result = g.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete access level: " + g.groupName + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                GetAllGroupAccess();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
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
        /// Show popup delete access level when user right click
        /// </summary>
        private void listAccessLevel_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDelACSLevel.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// Show access level info on gridcontrol
        /// </summary>
        private void listAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listAccessLevel.SelectedValue != null)
                {
                    string accessLvId = listAccessLevel.SelectedValue.ToString();
                    AccessLevel accessLevel = AccessLevel.LoadAccessLevelById(accessLvId);
                    if (accessLevel != null)
                    {
                        dt.Clear();
                        DataRow row = dt.NewRow();
                        row["id"] = accessLevel.groupId;
                        row["name"] = accessLevel.groupName;
                        row["number"] = "";

                        dt.Rows.Add(row);
                        gridData.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtabGroup)
            {
                GetAllGroupAccess();
                lblTitle.Text = "All group access";
            }
            else
            if (xtraTabControl1.SelectedTabPage == xtabLevel)
            {
                GetAllAccessLevel();
                lblTitle.Text = "All access level";
            }            
        }                        

        /// <summary>
        /// Show access level or access group detail
        /// </summary>
        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue(gcId).ToString();
                string name = gridView1.GetFocusedRowCellValue(gcName).ToString();
                if (xtraTabControl1.SelectedTabPage == xtabGroup)
                {
                    ucAccessGroupDetail uc = new ucAccessGroupDetail(name, "E", userId, id);
                    Panel p = (this.Parent as Panel);
                    p.Controls.Clear();
                    p.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
                else
                if (xtraTabControl1.SelectedTabPage == xtabLevel)
                {
                    ucAccessLevelDetail uc = new ucAccessLevelDetail(userId, "E", id);
                    Panel p = (this.Parent as Panel);
                    p.Controls.Clear();
                    p.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }       

       

       

        

        
    }
    
}
