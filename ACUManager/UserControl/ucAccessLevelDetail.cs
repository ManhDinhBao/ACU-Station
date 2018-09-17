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
    public partial class ucAccessLevelDetail : UserControl
    {
        string userId, mode,accessLvId;
        List<Schedule> schedules;
        List<Door> doors;
        public ucAccessLevelDetail(string _userId, string _mode, string _accessLvId)
        {
            InitializeComponent();
            this.userId = _userId;
            this.mode = _mode;
            this.accessLvId = _accessLvId;
        }
        private void ucAccessLevelDetail_Load(object sender, EventArgs e)
        {
            LoadAllDoor();
            LoadAllSchedule();
            btnApply.Enabled = false;
            if(mode=="A")
            {
                txtID.Text = AccessLevel.GenId();
                txtID.ReadOnly = false;
                lblTitle.Text = "Add new access level";
                if(lblCheckID.Text=="OK") btnApply.Enabled = true;
            }
            else
            if (mode == "E")
            {
                ShowAccessLvInfo();
                btnApply.Enabled = true;
                txtID.ReadOnly = true;
            }
        }

        #region Common
        /// <summary>
        /// Get all schedule into checked combo Box
        /// </summary>
        private void LoadAllSchedule()
        {
            try
            {
                schedules = Schedule.LoadAllSchedule();
                if (schedules != null)
                {
                    foreach (Schedule s in schedules)
                    {
                        CheckedListBoxItem listBoxItem = new CheckedListBoxItem();
                        listBoxItem.Value = s.ScheduleId;
                        listBoxItem.Description = s.ScheduleName;

                        chkcboSchedule.Properties.Items.Add(listBoxItem);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Get all door into checked combo Box
        /// </summary>
        private void LoadAllDoor()
        {
            try
            {
                doors = Door.LoadAllDoors();
                if (doors != null)
                {
                    foreach (Door d in doors)
                    {
                        CheckedListBoxItem listBoxItem = new CheckedListBoxItem();
                        listBoxItem.Value = d.DoorId;
                        listBoxItem.Description = d.DoorName;

                        chkcboDoor.Properties.Items.Add(listBoxItem);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show access level detail 
        /// </summary>
        private void ShowAccessLvInfo()
        {
            try
            {
                AccessLevel access = AccessLevel.LoadAccessLevelById(accessLvId);
                if (access.groupId != null)
                {
                    txtID.Text = access.groupId;
                    txtName.Text = access.groupName;
                    lblTitle.Text = access.groupName;

                    foreach (Schedule s in access.ListSchedule)
                    {
                        //Set checked state base on index or schedule in list schedule
                        int index = schedules.FindIndex(f => f.ScheduleId == s.ScheduleId);
                        if (index >= 0)
                        {
                            chkcboSchedule.Properties.Items[index].CheckState = CheckState.Checked;
                        }
                    }

                    foreach (Door d in access.ListDoor)
                    {
                        //Set checked state base on index or door in list door
                        int index = doors.FindIndex(f => f.DoorId == d.DoorId);
                        if (index >= 0)
                        {
                            chkcboDoor.Properties.Items[index].CheckState = CheckState.Checked;
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
        /// Go back to Access Control form
        /// </summary>
        private void GoBack()
        {
            ucAccessControl uc = new ucAccessControl(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Get all schedule what state = checked in checked combo box schedule
        /// </summary>
        /// <returns>list of schedule</returns>
        private List<Schedule> GetSchedule()
        {
            List<Schedule> scheduleSend = new List<Schedule>();
            try
            {

                foreach (CheckedListBoxItem item in chkcboSchedule.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        int pos = chkcboSchedule.Properties.Items.IndexOf(item);
                        Schedule s = schedules[pos];
                        scheduleSend.Add(s);
                    }

                }
                return scheduleSend;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get all door what state = checked in checked combo box door
        /// </summary>
        /// <returns>list of door</returns>
        private List<Door> GetDoor()
        {
            List<Door> doorSend = new List<Door>();
            try
            {
                foreach (CheckedListBoxItem item in chkcboDoor.Properties.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        int pos = chkcboDoor.Properties.Items.IndexOf(item);
                        Door d = doors[pos];
                        doorSend.Add(d);
                    }

                }
                return doorSend;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// Save data to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                //Make access level object
                AccessLevel accessLevel = new AccessLevel(txtID.Text, txtName.Text, GetDoor(), GetSchedule());
                if (mode == "A")
                {
                    //Add access level
                    string result = accessLevel.Add(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add access level " + txtName.Text + " success!");
                    }
                    else
                    {
                        MessageBox.Show("Error: " + result);
                    }

                }
                else
                if (mode == "E")
                {
                    //Update access level info
                    string result = accessLevel.Update(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update access level " + txtName.Text + " success!");
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

        /// <summary>
        /// Check duplicate access level id
        /// </summary>
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (mode == "A")
                {
                    if (txtID.Text.Count() > 0)
                    {
                        AccessLevel accessLevel = AccessLevel.LoadAccessLevelById(txtID.Text);
                        if (accessLevel == null)
                        {
                            lblCheckID.Text = "OK";
                            lblCheckID.ForeColor = Color.Green;
                            btnApply.Enabled = true;
                        }
                        else
                        {
                            lblCheckID.Text = "Duplicated";
                            lblCheckID.ForeColor = Color.Red;
                            btnApply.Enabled = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

       
        

    }
}
