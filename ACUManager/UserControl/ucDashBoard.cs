using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Globalization;

namespace ACUManager
{
    public partial class ucDashBoard : UserControl
    {
        string userId;
        public ucDashBoard()
        {
            InitializeComponent();
        }

        public ucDashBoard(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ucDashBoard_Load(object sender, EventArgs e)
        {
            //Create overview chart
            CreateYearChart();
            CreateMonthChart();

            //Create usage chart
            CreateUsageChart();

            //Show new event in grid
            ShowEvent();
        }

        #region Common
        /// <summary>
        /// Create small chart inside of panel USAGE
        /// </summary>
        /// <param name="title">Chart title</param>
        /// <param name="number">Number value of chart</param>
        /// <param name="location">Location of chart in panel</param>
        private void CreateChart(string title,int number,Point location)
        {
            ibsChart chart = new ibsChart(title, number);                      
            chart.Location = location;
            //panelUsage.Controls.Add(chart);
            tableLayoutPanel2.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Create series for show line in chart overview
        /// </summary>
        /// <param name="chart">Chart control</param>
        /// <param name="seriesName">Series name in chart </param>
        /// <param name="dtSource">Data table include agurment and value</param>
        private void CreateSeries(ChartControl chart, string seriesName,DataTable dtSource)
        {
            try
            {
                Series series = chart.Series[seriesName];
                if (dtSource != null)
                {
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        string agurment = dr["Agurment"].ToString();
                        int value = Convert.ToInt32(dr["Value"]);
                        series.Points.AddPoint(agurment, value);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Convert list of events to Data table show in grid
        /// </summary>
        /// <param name="events">list of events need convert to data table</param>
        /// <returns></returns>
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
                return dt;
            }
        }
        #endregion

        #region Overview
        /// <summary>
        /// Create line chart year
        /// </summary>
        private void CreateYearChart()
        {
            try
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                DateTime lastDay = new DateTime(year, 12, 31);
                DataSet ds = Event.LoadEventByYear(firstDay.ToString(), lastDay.ToString());

                DateTimeFormatInfo m = new DateTimeFormatInfo();
                lblYear.Text = string.Format("January ~ {0} {1}", m.GetMonthName(DateTime.Now.Month), DateTime.Now.Year.ToString());

                DataTable dtDeny = ds.Tables[0];
                CreateSeries(chartYear, "DENY", dtDeny);

                DataTable dtGrant = ds.Tables[1];
                CreateSeries(chartYear, "GRANTED", dtGrant);

                DataTable dtNotF = ds.Tables[2];
                CreateSeries(chartYear, "NOT DEFINED", dtNotF);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Create line chart month
        /// </summary>
        private void CreateMonthChart()
        {
            try
            {
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day;
                List<int> month31 = new List<int> { 1, 3, 5, 7, 8, 10, 12 };
                List<int> month30 = new List<int> { 4, 6, 9, 11 };
                if (month31.Contains(month))
                {
                    day = 31;
                }
                else
                if (month30.Contains(month))
                {
                    day = 30;
                }
                else
                {
                    if (year % 4 == 0)
                    {
                        day = 29;
                    }
                    else day = 28;
                }

                DateTime firstDay = new DateTime(year, month, 1);
                DateTime lastDay = new DateTime(year, month, day);
                DataSet ds = Event.LoadEventByMonth(firstDay.ToString(), lastDay.ToString());

                DateTimeFormatInfo m = new DateTimeFormatInfo();
                //lblMonth.Text = string.Format("{0} {1}", m.GetMonthName(DateTime.Now.Month), DateTime.Now.Year.ToString());

                DataTable dtDeny = ds.Tables[0];
                CreateSeries(chartMonth, "DENY", dtDeny);

                DataTable dtGrant = ds.Tables[1];
                CreateSeries(chartMonth, "GRANTED", dtGrant);

                DataTable dtNotF = ds.Tables[2];
                CreateSeries(chartMonth, "NOT DEFINED", dtNotF);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Usage
        private void CreateUsageChart()
        {
            try
            {
                //Chart user
                int userCount = 0;
                List<Users> users = Users.LoadAllUsers();
                if (users != null)
                {
                    userCount = users.Count;
                }
                Point p = new Point(20, 3);
                CreateChart(string.Format("User({0})",userCount.ToString()), userCount, p);

                //Chart card
                int cardCount = 0;
                List<Card> cards = Card.LoadAllCard();
                if (cards != null)
                {
                    cardCount = cards.Count;
                }
                Point p1 = new Point(138, 3);
                CreateChart(string.Format("Card({0})", cardCount.ToString()), cardCount, p1);

                //Chart device
                int deviceCount = 0;
                List<Device> devices = Device.LoadAllDevices();
                if (devices != null)
                {
                    deviceCount = devices.Count;
                }
                Point p2 = new Point(256, 3);
                CreateChart(string.Format("Device({0})", deviceCount.ToString()), deviceCount, p2);

                //Chart door
                int doorCount = 0;
                List<Door> doors = Door.LoadAllDoors();
                if (doors != null)
                {
                    doorCount = doors.Count;
                }
                Point p3 = new Point(374, 3);
                CreateChart(string.Format("Door({0})", doorCount.ToString()), doorCount, p3);

                //Chart access group
                int accessCount = 0;
                List<GroupAccess> g = GroupAccess.GetAllAccessGroup();
                if (g != null)
                {
                    accessCount = g.Count;
                }
                Point p4 = new Point(492, 3);
                CreateChart(string.Format("Access group({0})", accessCount.ToString()), accessCount, p4);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region NewEvent
        private void ShowEvent()
        {
            try
            {
                //Show event in grid
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

    }
}
