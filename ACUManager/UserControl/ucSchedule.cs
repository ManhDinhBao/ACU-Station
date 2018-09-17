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
    public partial class ucSchedule : UserControl
    {
        string userId;
        public ucSchedule()
        {
            InitializeComponent();
        }
        public ucSchedule(string _userId)
        {
            InitializeComponent();
            userId = _userId;
        }
        private void ucSchedule_Load(object sender, EventArgs e)
        {
            LoadAllSchedule();
        }

        #region Common
        /// <summary>
        /// Get all schedule from DB and show in listControl & gridControl
        /// </summary>
        private void LoadAllSchedule()
        {
            try
            {
                List<Schedule> schedules = Schedule.LoadAllSchedule();
                if (schedules != null)
                {
                    listSchedule.DataSource = schedules;
                    listSchedule.DisplayMember = "ScheduleName";
                    listSchedule.ValueMember = "ScheduleId";

                    gridSchedule.DataSource = getGridScheduleSource(schedules);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Convert schedule to data table row
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns>Data table of schedule</returns>
        private DataTable getGridScheduleSource(Schedule schedule)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("scheduleId", typeof(string));
                dt.Columns.Add("scheduleName", typeof(string));
                dt.Columns.Add("description", typeof(string));

                //Add to table for grid
                DataRow dr = dt.NewRow();
                dr["scheduleId"] = schedule.ScheduleId;
                dr["scheduleName"] = schedule.ScheduleName;
                dr["description"] = schedule.Description;

                dt.Rows.Add(dr);
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }

        }

        /// <summary>
        /// Convert list of schedule to data table
        /// </summary>
        /// <param name="schedules"></param>
        /// <returns>Data table of list schedule</returns>
        private DataTable getGridScheduleSource(List<Schedule> schedules)
        {
            DataTable dt = new DataTable();
            try
            {              
                dt.Columns.Add("scheduleId", typeof(string));
                dt.Columns.Add("scheduleName", typeof(string));
                dt.Columns.Add("description", typeof(string));
                foreach (Schedule s in schedules)
                {
                    //Add to table for grid
                    DataRow dr = dt.NewRow();
                    dr["scheduleId"] = s.ScheduleId;
                    dr["scheduleName"] = s.ScheduleName;
                    dr["description"] = s.Description;

                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return dt;
            }
        }
        #endregion

        #region Click
        /// <summary>
        /// Go back to Setting screen
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            ucSetting uc = new ucSetting(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Go to Schedule detail form
        /// </summary>
        /// <remarks>
        /// Mode = A: Add new schedule, userId: user login
        /// </remarks>
        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            ucScheduleDetail uc = new ucScheduleDetail("A",userId);
            Panel p = (this.Parent as Panel);
            p.Controls.Clear();
            p.Controls.Add(uc);
        }

        /// <summary>
        /// Go to Schedule detail form
        /// </summary>
        /// <remarks>
        /// Mode = E: show schedule detail, userId: user login
        /// </remarks>
        private void gridSchedule_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Get scheduleId in grid
                DataRowView drv = (DataRowView)gridView1.GetFocusedRow();
                DataRow dr = drv.Row;
                string scheduleId = dr[0].ToString();
                string scheduleName = dr[1].ToString();

                //Show detail schedule
                ucScheduleDetail uc = new ucScheduleDetail("E", scheduleId, scheduleName, userId);
                Common.GoBack(uc, this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Show popup delete schedule: Right click in gridcontrol
        /// </summary>
        private void gridSchedule_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDeleteSchedule.ShowPopup(Control.MousePosition);
            }
        }
        #endregion

        /// <summary>
        /// Show schedule info in gridControl
        /// </summary>
        private void listSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get schedule id
                string scheduleId = listSchedule.SelectedItem.ToString();
                
                //Show in grid
                Schedule schedule = Schedule.LoadScheduleById(scheduleId);
                if (schedule.ScheduleId != null)
                {
                    gridSchedule.DataSource = getGridScheduleSource(schedule);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Delete schedule
        /// </summary>
        /// <remarks>
        /// Select schedule in gridControl and
        /// </remarks>
        private void itemDeleteSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue(gcScheduleId).ToString();
                string name = gridView1.GetFocusedRowCellValue(gcScheduleName).ToString();
                string des = gridView1.GetFocusedRowCellValue(gcDescription).ToString();

                Schedule schedule = new Schedule(id, name, des);
                if (id != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete schedule: " + name + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        //Delete schedule                  
                        string result = schedule.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete schedule " + name + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                //Reload data
                                LoadAllSchedule();
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
                return;
            }
            
        }
        
    }
}
