using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ACUManager
{
    public partial class ucScheduleDetail : UserControl
    {
        DataTable dtMon, dtTue, dtWed, dtThu, dtFri, dtSat, dtSun;
        string mode, scheduleId, scheduleName,userId;
        public ucScheduleDetail()
        {
            InitializeComponent();
        }

        public ucScheduleDetail(string _mode,string _userId)
        {
            InitializeComponent();
            this.mode = _mode; //A: Add new schedule; E:Edit schedule info
            this.userId = _userId;
        }

        public ucScheduleDetail(string _mode,string _scheduleId,string _scheduleName, string _userId)
        {
            InitializeComponent();
            this.mode = _mode; //A: Add new schedule; E:Edit schedule info
            this.scheduleName = _scheduleName;
            this.scheduleId = _scheduleId;
            this.userId = _userId;
        }

        private void ucSchedule_Load(object sender, EventArgs e)
        {
            CreatePointNumber();
            InitPeriodData();            
            if (mode == "A")
            {
                lblTitle.Text = "Add new schedule";
                txtID.Text = Schedule.GenScheduleId();
                txtID.ReadOnly = false;
            }
            else //mode==E
            {
                lblTitle.Text = scheduleName;                
                LoadScheduleInfoById(scheduleId);
                txtID.ReadOnly = true;
            }
        }

        #region Common

        /// <summary>
        /// Go back to Schedule master form
        /// </summary>
        private void GoBack()
        {
            ucSchedule uc = new ucSchedule(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Show schedule image in panel when user add new period
        /// </summary>
        /// <param name="panel">Panel show schedule detail</param>
        /// <param name="source">Data table store schedule data</param>
        private void UpdatePeriodInChart(Panel panel, DataTable source)
        {
            try
            {
                //Get data source of this Period -> data table
                panel.Controls.Clear();
                DataView data = (DataView)gridView1.DataSource;
                source = data.Table;

                foreach(DataRow dr in source.Rows)
                {
                    if(dr[0].ToString().Count()<=0)
                    {
                        source.Rows.Remove(dr);
                    }
                }

                //Show schedule image in panel
                foreach (DataRow dr in source.Rows)
                {
                    DateTime startTime = Convert.ToDateTime(dr["StartTime"]);
                    DateTime endTime = Convert.ToDateTime(dr["EndTime"]);
                    AddPeriodChart(panel, startTime, endTime);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Show 1 schedule image in parent panel
        /// </summary>
        /// <param name="panelParent"></param>
        /// <param name="startTime">Period: start time</param>
        /// <param name="endTime">Period: end time </param>
        private void AddPeriodChart(Panel panelParent, DateTime startTime, DateTime endTime)
        {
            try
            {
                Panel p = new Panel();

                //Set period image location
                int PeriodChartX = Convert.ToInt32(DateTimeToDouble(startTime) * 30);
                int PeriodChartY = 0;
                Point point = new Point(PeriodChartX, PeriodChartY);
                p.Location = point;

                //Set period image size
                ///<example>
                ///Star time: 07:00
                ///End time: 13:00
                ///=> periodValue = 13-7=6
                ///=> schedule image width = 180
                ///</example>
                int periodValue = Convert.ToInt32(DateTimeToDouble(endTime) - DateTimeToDouble(startTime)) * 30;               
                Size size = new Size(periodValue, panelParent.Height);
                p.Size = size;
                p.BackColor = Color.Orange;
                
                //Add period image to panel parent
                panelParent.Controls.Add(p);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        /// <summary>
        /// Change Time to hour format and convert to double
        /// </summary>
        /// <param name="dateTime">Time value need convert</param>
        /// <returns>Double value of time</returns>
        private double DateTimeToDouble(DateTime dateTime)
        {
            double result = 0;
            try
            {
                result = dateTime.Hour + dateTime.Minute / 60;
                return result;
            }
            catch
            {
                return result;
            }
        }

        /// <summary>
        /// Generate schedule object from periods
        /// </summary>
        /// <returns>One schdule include all periods</returns>
        private Schedule GenScheduleData()
        {
            Schedule schedule = null;
            try
            {
                List<Period> periods = new List<Period>();
                //Gen period of schedule
                GenPeriodData(periods, dtMon);
                GenPeriodData(periods, dtTue);
                GenPeriodData(periods, dtWed);
                GenPeriodData(periods, dtThu);
                GenPeriodData(periods, dtFri);
                GenPeriodData(periods, dtSat);
                GenPeriodData(periods, dtSun);

                schedule = new Schedule(txtID.Text, txtName.Text, txtDescription.Text, periods);
                return schedule;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Generate period data and add to one List of period
        /// </summary>
        /// <param name="periods">List of period</param>
        /// <param name="PeriodData">Data table source</param>
        private void GenPeriodData(List<Period> periods, DataTable PeriodData)
        {
            try
            {
                //Base on table name => set day
                string dayInWeek = "";
                switch (PeriodData.TableName)
                {
                    case "dtMon":
                        dayInWeek = "mon";
                        break;
                    case "dtTue":
                        dayInWeek = "tue";
                        break;
                    case "dtWed":
                        dayInWeek = "wed";
                        break;
                    case "dtThu":
                        dayInWeek = "thu";
                        break;
                    case "dtFri":
                        dayInWeek = "fri";
                        break;
                    case "dtSat":
                        dayInWeek = "sat";
                        break;
                    case "dtSun":
                        dayInWeek = "sun";
                        break;
                }

                //Add period data from data table source to list of period
                foreach (DataRow dr in PeriodData.Rows)
                {
                    Period period = new Period();
                    period.DayInWeek = dayInWeek;
                    period.startTime = Convert.ToDateTime(dr["StartTime"]);
                    period.endTime = Convert.ToDateTime(dr["EndTime"]);
                    periods.Add(period);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }     

        /// <summary>
        /// Load schedule by id and show in controls
        /// </summary>
        /// <param name="scheduleId"></param>
        private void LoadScheduleInfoById(string scheduleId)
        {
            try
            {
                //Get schedule info
                Schedule scheduleR = Schedule.LoadScheduleById(scheduleId);

                //Fill schedule info
                txtID.Text = scheduleR.ScheduleId;
                txtName.Text = scheduleR.ScheduleName;
                txtDescription.Text = scheduleR.Description;

                //Show period chart
                ShowPeriodChart(scheduleR.ListPeriod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Show Period image in panel load from DB
        /// </summary>
        /// <param name="listPeriod">List of periods of schedule</param>
        private void ShowPeriodChart(List<Period> listPeriod)
        {
            try
            {
                foreach (Period p in listPeriod)
                {
                    switch (p.DayInWeek)
                    {
                        case "mon":
                            AddPeriodToTable(dtMon, p);
                            AddPeriodChart(panelMonday, p.startTime, p.endTime);
                            break;
                        case "tue":
                            AddPeriodToTable(dtTue, p);
                            AddPeriodChart(panelTuesday, p.startTime, p.endTime);
                            break;
                        case "wed":
                            AddPeriodToTable(dtWed, p);
                            AddPeriodChart(panelWednesday, p.startTime, p.endTime);
                            break;
                        case "thu":
                            AddPeriodToTable(dtThu, p);
                            AddPeriodChart(panelThursday, p.startTime, p.endTime);
                            break;
                        case "fri":
                            AddPeriodToTable(dtFri, p);
                            AddPeriodChart(panelFriday, p.startTime, p.endTime);
                            break;
                        case "sat":
                            AddPeriodToTable(dtSat, p);
                            AddPeriodChart(panelSaturday, p.startTime, p.endTime);
                            break;
                        case "sun":
                            AddPeriodToTable(dtSun, p);
                            AddPeriodChart(panelSunday, p.startTime, p.endTime);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Add period data to table
        /// </summary>
        /// <param name="dt">data table store period data</param>
        /// <param name="period"></param>
        private void AddPeriodToTable(DataTable dt, Period period)
        {
            try
            {
                DataRow dataRow = dt.NewRow();
                dataRow["StartTime"] = period.startTime;
                dataRow["EndTime"] = period.endTime;

                dt.Rows.Add(dataRow);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Init data table structure for store periods data
        /// </summary>
        private void InitPeriodData()
        {
            try
            {
                dtMon = new DataTable();
                dtMon.Columns.Add("StartTime", typeof(DateTime));
                dtMon.Columns.Add("EndTime", typeof(DateTime));

                dtTue = dtMon.Clone();
                dtWed = dtMon.Clone();
                dtThu = dtMon.Clone();
                dtFri = dtMon.Clone();
                dtSat = dtMon.Clone();
                dtSun = dtMon.Clone();

                dtMon.TableName = "dtMon";
                dtTue.TableName = "dtTue";
                dtWed.TableName = "dtWed";
                dtThu.TableName = "dtThu";
                dtFri.TableName = "dtFri";
                dtSat.TableName = "dtSat";
                dtSun.TableName = "dtSun";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Create hour value at top and bottom of period pannel
        /// </summary>
        private void CreatePointNumber()
        {
            try
            {
                for (int i = 0; i <= 24; i += 3)
                {
                    LabelControl label = new LabelControl();
                    label.Text = i.ToString();
                    Point point1 = new Point(panelMonday.Location.X + (i * 30), 20);
                    label.Location = point1;
                    panelPeriod.Controls.Add(label);

                }

                for (int i = 0; i <= 24; i += 3)
                {
                    LabelControl label = new LabelControl();
                    label.Text = i.ToString();
                    Point point1 = new Point(panelMonday.Location.X + (i * 30), 302);
                    label.Location = point1;
                    panelPeriod.Controls.Add(label);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Show popup include period data
        /// </summary>
        /// <param name="dt">Data table store this period data</param>
        /// <param name="dayName">Day in week</param>
        private void ShowDetail(DataTable dt, string dayName)
        {
            try
            {
                gridData.DataSource = dt;
                gridData.Tag = dayName;
                popupContainerControl1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        #endregion

        /// <summary>
        /// Show popup period when click
        /// </summary>
        #region Show period popup
        private void btnEditMonday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtMon, "mon");
        }

        private void btnEditTuesday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtTue, "tue");
        }

        private void btnEditWednesday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtWed,"wed");
        }

        private void btnEditThursday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtThu,"thu");
        }

        private void btnEditFriday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtFri,"fri");
        }

        private void btnEditSaturday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtSat,"sat");
        }

        private void btnEditSunday_Click(object sender, EventArgs e)
        {
            ShowDetail(dtSun,"sun");
        }
        #endregion

        #region Button click
        private void btnCalcelPeriod_Click(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        /// <summary>
        /// Show period image on panel when click
        /// </summary>
        private void btnApplyPeriod_Click(object sender, EventArgs e)
        {
            switch (gridData.Tag)
            {
                case "mon":
                    UpdatePeriodInChart(panelMonday, dtMon);
                    break;
                case "tue":
                    UpdatePeriodInChart(panelTuesday, dtTue);
                    break;
                case "wed":
                    UpdatePeriodInChart(panelWednesday, dtWed);
                    break;
                case "thu":
                    UpdatePeriodInChart(panelThursday, dtThu);
                    break;
                case "fri":
                    UpdatePeriodInChart(panelFriday, dtFri);
                    break;
                case "sat":
                    UpdatePeriodInChart(panelSaturday, dtSat);
                    break;
                case "sun":
                    UpdatePeriodInChart(panelSunday, dtSun);
                    break;
            }
            popupContainerControl1.Hide();
        }             

        /// <summary>
        /// Save schedule data to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Schedule schedule = GenScheduleData();

                if (txtID.Text.Count() <= 0)
                {
                    MessageBox.Show("Please input schedule ID");
                    return;
                }
                if (mode == "A") //Add new
                {
                    string result = schedule.Add(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add schedule " + schedule.ScheduleName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    GoBack();
                }
                else if (mode == "E")//Edit
                {
                    //Update schedule
                    string result = schedule.Update(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update schedule " + schedule.ScheduleName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        #endregion

        
    }
}
