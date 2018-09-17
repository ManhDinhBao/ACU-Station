using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ACUManager
{
    public partial class ucMornitoring : UserControl
    {
        List<Event> evs;
        DateTime logTime;
        public ucMornitoring()
        {
            InitializeComponent();
        }
        private void ucMornitoring_Load(object sender, EventArgs e)
        {
            LoadAllEvent();
            InitMonth();
            SetDate();
        }

        #region Common
        /// <summary>
        /// Load 100 newest events from DB
        /// </summary>
        private void LoadAllEvent()
        {
            try
            {
                List<Event> events = Event.LoadTOP100Event();

                if (events.Count > 0)
                {
                    gridEvent.DataSource = ListToTable(events);

                }
                else
                {
                    MessageBox.Show("NO DATA!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load 1 newest events from DB
        /// </summary>
        private void LoadNewestEvent()
        {
            try
            {
                evs = Event.LoadTOP1Event();
                if (evs.Count > 0)
                {
                    gridRealTime.DataSource = ListToTable(evs);
                    logTime = Convert.ToDateTime(ListToTable(evs).Rows[0]["eventDate"]);
                }
                else
                {
                    MessageBox.Show("NO DATA!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }        
        }

        /// <summary>
        /// Convert List event to data table to show in gridcontrol
        /// </summary>
        /// <param name="events">List events need convert</param>
        /// <returns>Data table store events data</returns>
        private DataTable ListToTable(List<Event> events)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("eventDate", typeof(DateTime));
                dt.Columns.Add("deviceName", typeof(string));
                dt.Columns.Add("deviceIP", typeof(string));
                dt.Columns.Add("person", typeof(string));
                dt.Columns.Add("cardNo", typeof(string));
                dt.Columns.Add("doorName", typeof(string));
                dt.Columns.Add("status", typeof(string));

                foreach (Event e in events)
                {
                    DataRow dr = dt.NewRow();
                    dr["eventDate"] = e.EventDate;
                    dr["deviceName"] = e.DeviceName;
                    dr["deviceIP"] = e.DeviceIP;
                    dr["person"] = e.Person;
                    dr["cardNo"] = e.CardNo;
                    dr["doorName"] = e.DoorName;
                    dr["status"] = e.Status;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DataTable ListToTable(List<Event> events,string mode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("eventDate", typeof(DateTime));
                dt.Columns.Add("deviceName", typeof(string));
                dt.Columns.Add("deviceIP", typeof(string));
                dt.Columns.Add("person", typeof(string));
                dt.Columns.Add("cardNo", typeof(string));
                dt.Columns.Add("doorName", typeof(string));
                dt.Columns.Add("status", typeof(string));
                dt.Columns.Add("company", typeof(string));

                foreach (Event e in events)
                {
                    DataRow dr = dt.NewRow();
                    dr["eventDate"] = e.EventDate;
                    dr["deviceName"] = e.DeviceName;
                    dr["deviceIP"] = e.DeviceIP;
                    dr["person"] = e.Person;
                    dr["cardNo"] = e.CardNo;
                    dr["doorName"] = e.DoorName;
                    dr["status"] = e.Status;
                    dr["company"] = e.GroupUser;

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Set button status
        /// </summary>
        /// <param name="status">status of button</param>
        private void SetControl(bool status)
        {
            if (status)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        /// <summary>
        /// Fill month into combobox
        /// </summary>
        private void InitMonth()
        {
            cboMonth.Properties.Items.Add("January");
            cboMonth.Properties.Items.Add("February");
            cboMonth.Properties.Items.Add("March");
            cboMonth.Properties.Items.Add("April");
            cboMonth.Properties.Items.Add("May");
            cboMonth.Properties.Items.Add("June");
            cboMonth.Properties.Items.Add("July");
            cboMonth.Properties.Items.Add("August");
            cboMonth.Properties.Items.Add("September");
            cboMonth.Properties.Items.Add("October");
            cboMonth.Properties.Items.Add("November");
            cboMonth.Properties.Items.Add("December");

            cboMonth.EditValue = cboMonth.Properties.Items[0];
        }
        /// <summary>
        /// Set default date for date edit
        /// </summary>
        private void SetDate()
        {
            DateTime Sdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime Edate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            dtpSDate.EditValue = Sdate;
            dtpEDate.EditValue = Edate;
            dtpSLdate.EditValue = Sdate;
            dtpELdate.EditValue = Edate;
        }
        #endregion

        #region History
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Get conditions
                string sDate = dtpSDate.EditValue.ToString();
                string eDate = dtpEDate.EditValue.ToString();
                string cardNo = txtCardNo.Text;

                //Get event from DB
                List<Event> events = Event.LoadEventFilter(sDate, eDate, cardNo);
                if (events.Count > 0)
                {
                    gridEvent.DataSource = ListToTable(events);
                }
                else
                {
                    MessageBox.Show("NO DATA!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xtraSaveFileDialog1.Filter = "Excel 97-2003|*.xls|Excel Sheet|*.xlsx";
                xtraSaveFileDialog1.FileName = string.Format("History");
                DialogResult dr = xtraSaveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && xtraSaveFileDialog1.FileName != null)
                {
                    string path = Path.GetFullPath(xtraSaveFileDialog1.FileName);
                    string extension = Path.GetExtension(xtraSaveFileDialog1.FileName);
                    if (extension == ".xls")
                    {
                        gridAttendance.ExportToXls(path);
                    }
                    else
                    if (extension == ".xlsx")
                    {
                        gridAttendance.ExportToXlsx(path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region RealTime
        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadNewestEvent();
            timer1.Interval = 3000;
            timer1.Start();
            SetControl(true);
        }        
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SetControl(false);            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string log = logTime.ToString("yyyy/MM/dd HH:mm:ss");
                string toTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                evs = Event.LoadNewEvent(log, toTime);
                if (evs.Count > 0)
                {
                    DataTable dtNew = ListToTable(evs);
                    DataTable dtOld = (DataTable)gridRealTime.DataSource;
                    foreach (DataRow dr in dtNew.Rows)
                    {
                        DataRow dr1 = dtOld.NewRow();
                        dr1["eventDate"] = dr["eventDate"];
                        dr1["deviceName"] = dr["deviceName"];
                        dr1["deviceIP"] = dr["deviceIP"];
                        dr1["person"] = dr["person"];
                        dr1["cardNo"] = dr["cardNo"];
                        dr1["doorName"] = dr["doorName"];
                        dr1["status"] = dr["status"];
                        dtOld.Rows.InsertAt(dr1, 0);
                    }
                    gridRealTime.DataSource = dtOld;

                    logTime = Convert.ToDateTime(dtNew.Rows[0]["eventDate"]);
                }
                else
                    logTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Attendance
        private void btnAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                int month = cboMonth.SelectedIndex + 1;
                DateTime attendanceDate = new DateTime(DateTime.Now.Year, month, DateTime.Now.Day);
               
                List<Event> events = Event.LoadAttendance(attendanceDate);
                if (events.Count > 0)
                {
                    gridAttendance.DataSource = ListToTable(events,"Attendance");
                }
                else
                {
                    MessageBox.Show("NO DATA!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAttendanceExport_Click(object sender, EventArgs e)
        {
            try
            {
                xtraSaveFileDialog1.Filter = "Excel 97-2003|*.xls|Excel Sheet|*.xlsx";
                xtraSaveFileDialog1.FileName = string.Format("Attendance - {0}",cboMonth.EditValue.ToString());
                DialogResult dr = xtraSaveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && xtraSaveFileDialog1.FileName != null)
                {
                    string path = Path.GetFullPath(xtraSaveFileDialog1.FileName);
                    string extension = Path.GetExtension(xtraSaveFileDialog1.FileName);
                    if (extension == ".xls")
                    {
                        gridAttendance.ExportToXls(path);
                    }
                    else
                    if (extension == ".xlsx")
                    {
                        gridAttendance.ExportToXlsx(path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Login History
        private void btnSLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime sDate = Convert.ToDateTime(dtpSLdate.EditValue);
                DateTime eDate = Convert.ToDateTime(dtpELdate.EditValue);

                DataTable dt = Event.LoadLogin(sDate, eDate);
                if (dt != null)
                {
                    gridLogin.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("NO DATA!");
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
