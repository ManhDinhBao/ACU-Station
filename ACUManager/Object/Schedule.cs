using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Schedule
    {
        public Schedule() { }

        public Schedule(string scheduleId, string scheduleName, string description)
        {
            ScheduleId = scheduleId;
            ScheduleName = scheduleName;
            Description = description;
        }

        public Schedule(string scheduleId)
        {
            ScheduleId = scheduleId;
        }

        public Schedule(string scheduleId,string scheduleName, string description, List<Period> listPeriod)
        {
            ScheduleId = scheduleId;
            ScheduleName = scheduleName;
            Description = description;
            ListPeriod = listPeriod;
        }

        private string  scheduleId;

        public string  ScheduleId
        {
            get { return scheduleId; }
            set { scheduleId = value; }
        }

        private string scheduleName;

        public string ScheduleName
        {
            get { return scheduleName; }
            set { scheduleName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private List<Period> listPeriod;

        public List<Period> ListPeriod
        {
            get { return listPeriod; }
            set { listPeriod = value; }
        }

        #region Query
        /// <summary>
        /// Get all schedules in DB
        /// </summary>
        /// <returns>List of scheduls in DB</returns>
        public static List<Schedule> LoadAllSchedule()
        {
            List<Schedule> schedules = new List<Schedule>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleQry("Q", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["scheduleId"].ToString();
                    string Name = dr["scheduleName"].ToString();
                    string description = dr["description"].ToString();

                    Schedule schedule = new Schedule(Id, Name, description);
                    schedules.Add(schedule);
                }
                return schedules;
            }
            catch (Exception ex)
            {
                return schedules;
            }
        }

        /// <summary>
        /// Get schdule by schedule ID
        /// </summary>
        /// <param name="scheduleId">ID of schedule need get</param>
        /// <returns>One schedule object</returns>
        public static Schedule LoadScheduleById(string scheduleId)
        {
            Schedule schedule = new Schedule();
            List<Period> periods = new List<Period>();

            DataTable dt = null;
            DataTable dt1 = NewMethod();
            try
            {
                //Get schedule master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleQry("Q", scheduleId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["scheduleId"].ToString();
                    string Name = dr["scheduleName"].ToString();
                    string description = dr["description"].ToString();

                    schedule = new Schedule(Id, Name, description);

                }

                //Get periods in schedule
                ServiceReference1.WSACUSoapClient client1 = new ServiceReference1.WSACUSoapClient();
                DataSet ds1 = client1.PeriodQuery("Q", scheduleId);
                dt1 = ds1.Tables[0];

                foreach (DataRow dr in dt1.Rows)
                {
                    string dayInWeek = dr["DayInWeek"].ToString();
                    DateTime startTime = DateTime.ParseExact(dr["StartTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime endTime = DateTime.ParseExact(dr["EndTime"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

                    Period period = new Period(dayInWeek, startTime, endTime);
                    periods.Add(period);

                }
                schedule.ListPeriod = periods;

                return schedule;

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        private static DataTable NewMethod()
        {
            return null;
        }

        /// <summary>
        /// Auto Gen schedule ID base on Max schedule ID in DB
        /// </summary>
        /// <returns>ScheduleID: Sxxxxxxxxx </returns>
        public static string GenScheduleId()
        {
            string scheduleId = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleQry("S", "", "");
                dt = ds.Tables[0];
                scheduleId = dt.Rows[0][0].ToString();
         
                return scheduleId;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Add new schedule to DB
        /// </summary>
        /// <param name="creator">User login id</param>
        /// <returns>Result of command: OK or get error from DB</returns>
        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                //Add new schedule
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleSave("A", scheduleId, scheduleName, description, creator, DateTime.Now);
                dt = ds.Tables[0];

                if (dt.Rows[0][0].ToString() == "OK")
                {
                    //Add period
                    foreach (Period p in listPeriod)
                    {
                        ServiceReference1.WSACUSoapClient client1 = new ServiceReference1.WSACUSoapClient();
                        DataSet ds1 = client.PeriodSave("A", scheduleId, p.DayInWeek, p.startTime, p.endTime, creator, DateTime.Now);
                        dt1 = ds1.Tables[0];

                        if (dt1.Rows[0][0].ToString() != "OK")
                        {
                            result = dt1.Rows[0][0].ToString();
                            break;
                        }
                    }
                }
                else result = dt.Rows[0][0].ToString();


                return result;
            }
            catch (Exception ex)
            {               
                return string.Format("Schedule class - Add: {0}",ex.ToString());
            }
        }

        /// <summary>
        /// Uddate schedule info 
        /// </summary>
        /// <param name="creator">User login id</param>
        /// <returns>Result of command: OK or get error from DB</returns>
        public string Update(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                //Update schedule master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleSave("U", scheduleId, scheduleName, description, creator, DateTime.Now);
                dt = ds.Tables[0];

                //Delete old period
                result = DeleteAllPeriod(scheduleId,creator);

                if (dt.Rows[0][0].ToString() == "OK")
                {
                    //Add new period
                    foreach (Period p in listPeriod)
                    {
                        ServiceReference1.WSACUSoapClient client1 = new ServiceReference1.WSACUSoapClient();
                        DataSet ds1 = client.PeriodSave("A", scheduleId, p.DayInWeek, p.startTime, p.endTime, creator, DateTime.Now);
                        dt1 = ds1.Tables[0];

                        if (dt1.Rows[0][0].ToString() != "OK")
                        {
                            result = dt1.Rows[0][0].ToString();
                            break;
                        }                        
                    }
                }
                else result=dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Schedule class - Update: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete Schedule
        /// </summary>
        /// <param name="creator">User login id</param>
        /// <returns>OK or get error from DB</returns>
        public string Delete(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete schedule master and detail (in DB delete detail command)
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.ScheduleSave("D", scheduleId, "", "", creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Schedule class - Delete: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete period by schedule id
        /// </summary>
        /// <param name="scheduleID">ID of schedule include periods</param>
        /// <param name="creator">User login id</param>
        /// <returns>OK or get error from DB</returns>
        public static string DeleteAllPeriod(string scheduleID,string creator)
        {
            string result = "OK";
            DataTable dt = null;
            DataTable dt1 = null;
            try
            {
                //Delete all period
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.PeriodSave("D", scheduleID, "",DateTime.Now,DateTime.Now, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Schedule class - DeleteAllPeiod: {0}", ex.ToString());
            }
        }
        #endregion

    }
}
