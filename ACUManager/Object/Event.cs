using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Event
    {
        public Event() { }
        public Event(DateTime eventDate, string deviceName, string deviceIP, string person, string cardNo, string doorName,string status)
        {
            EventDate = eventDate;
            DeviceName = deviceName;
            DeviceIP = deviceIP;
            Person = person;
            CardNo = cardNo;
            DoorName = doorName;
            Status = status;
        }

        public Event(DateTime eventDate, string deviceName, string deviceIP, string person, string cardNo, string doorName, string status, string groupUser)
        {
            EventDate = eventDate;
            DeviceName = deviceName;
            DeviceIP = deviceIP;
            Person = person;
            CardNo = cardNo;
            DoorName = doorName;
            Status = status;
            GroupUser = groupUser;
        }
        private DateTime eventDate;

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        private string deviceName;

        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }

        private string deviceIP;

        public string DeviceIP
        {
            get { return deviceIP; }
            set { deviceIP = value; }
        }

        private string person;

        public string Person
        {
            get { return person; }
            set { person = value; }
        }

        private string cardNo;

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        private string doorName;

        public string DoorName
        {
            get { return doorName; }
            set { doorName = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string groupUser;

        public string GroupUser
        {
            get { return groupUser; }
            set { groupUser = value; }
        }


        #region Query
        /// <summary>
        /// Get 100 newest event from DB
        /// </summary>
        /// <returns>List of event</returns>
        public static List<Event> LoadTOP100Event()
        {
            List<Event> events = new List<Event>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.EventQry("T", "", "", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime eDate = Convert.ToDateTime(dr["eventDate"].ToString());
                    string dName= dr["deviceName"].ToString();
                    string dIP = dr["device"].ToString();
                    string ePerson = dr["personName"].ToString();
                    string eCardNo = dr["cardNo"].ToString();
                    string eDoorName = dr["doorName"].ToString();
                    string eStatus = dr["status"].ToString();

                    Event e = new Event(eDate, dName, dIP, ePerson, eCardNo, eDoorName, eStatus);
                    events.Add(e);
                }
                return events;
            }
            catch (Exception ex)
            {
                return events;
            }
        }

        /// <summary>
        /// Load newest event from DB
        /// </summary>
        /// <returns></returns>
        public static List<Event> LoadTOP1Event()
        {
            List<Event> events = new List<Event>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.EventQry("O", "", "", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime eDate = Convert.ToDateTime(dr["eventDate"].ToString());
                    string dName = dr["deviceName"].ToString();
                    string dIP = dr["device"].ToString();
                    string ePerson = dr["personName"].ToString();
                    string eCardNo = dr["cardNo"].ToString();
                    string eDoorName = dr["doorName"].ToString();
                    string eStatus = dr["status"].ToString();

                    Event e = new Event(eDate, dName, dIP, ePerson, eCardNo, eDoorName, eStatus);
                    events.Add(e);
                }
                return events;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Load new event realtime
        /// </summary>
        /// <param name="SDate">start time</param>
        /// <param name="EDate">end time</param>
        /// <returns>List of event</returns>
        public static List<Event> LoadNewEvent(string SDate, string EDate)
        {
            List<Event> events = new List<Event>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.EventQry("N", "", "", SDate, EDate);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime eDate = Convert.ToDateTime(dr["eventDate"].ToString());
                    string dName = dr["deviceName"].ToString();
                    string dIP = dr["device"].ToString();
                    string ePerson = dr["personName"].ToString();
                    string eCardNo = dr["cardNo"].ToString();
                    string eDoorName = dr["doorName"].ToString();
                    string eStatus = dr["status"].ToString();

                    Event e = new Event(eDate, dName, dIP, ePerson, eCardNo, eDoorName, eStatus);
                    events.Add(e);
                }
                return events;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get event with conditions
        /// </summary>
        /// <param name="SDate">start time</param>
        /// <param name="EDate">end time</param>
        /// <param name="CardNo">card no</param>
        /// <returns>List of events</returns>
        public static List<Event> LoadEventFilter(string SDate, string EDate, string CardNo)
        {
            List<Event> events = new List<Event>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.EventQry("Q", "", CardNo, SDate, EDate);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime eDate = Convert.ToDateTime(dr["eventDate"].ToString());
                    string dName = dr["deviceName"].ToString();
                    string dIP = dr["device"].ToString();
                    string ePerson = dr["personName"].ToString();
                    string eCardNo = dr["cardNo"].ToString();
                    string eDoorName = dr["doorName"].ToString();
                    string eStatus = dr["status"].ToString();

                    Event e = new Event(eDate, dName, dIP, ePerson, eCardNo, eDoorName, eStatus);
                    events.Add(e);
                }
                return events;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// statistic event from january of this year to now
        /// </summary>
        /// <param name="SDate">start time</param>
        /// <param name="EDate">end time</param>
        /// <returns>Data set have 3 table :DENY, GRANTED, NOT_DEFINED</returns>
        public static DataSet LoadEventByYear(string SDate, string EDate)
        {
            List<Event> events = new List<Event>();
            DataSet ds = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                ds = client.EventQry("Y", "", "", SDate, EDate);               
                
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// statistic event from first of month to end of month
        /// </summary>
        /// <param name="SDate">start time</param>
        /// <param name="EDate">end time</param>
        /// <returns>Data set have 3 table :DENY, GRANTED, NOT_DEFINED</returns>
        public static DataSet LoadEventByMonth(string SDate, string EDate)
        {
            List<Event> events = new List<Event>();
            DataSet ds = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                ds = client.EventQry("M", "", "", SDate, EDate);

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }        

        /// <summary>
        /// Get attendance of each person by date
        /// </summary>
        /// <param name="attendanceDate">date need to get attendance data</param>
        /// <returns>List of event</returns>
        public static List<Event> LoadAttendance(DateTime attendanceDate)
        {
            List<Event> events = new List<Event>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AttendanceQuery("A",attendanceDate);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime eDate = Convert.ToDateTime(dr["eventDate"].ToString());
                    string dName = dr["deviceName"].ToString();
                    string dIP = dr["device"].ToString();
                    string ePerson = dr["personName"].ToString();
                    string eCardNo = dr["cardNo"].ToString();
                    string eDoorName = dr["doorName"].ToString();
                    string eStatus = dr["status"].ToString();
                    string eGroup = dr["company"].ToString();

                    Event e = new Event(eDate, dName, dIP, ePerson, eCardNo, eDoorName, eStatus,eGroup);
                    events.Add(e);
                }
                return events;
            }
            catch (Exception ex)
            {
                return events;
            }
        }

        /// <summary>
        /// Get login history
        /// </summary>
        /// <param name="sDate">start time</param>
        /// <param name="eDate">end time</param>
        /// <returns></returns>
        public static DataTable LoadLogin(DateTime sDate, DateTime eDate)
        {            
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.LoginQuery("Q", sDate,eDate);
                dt = ds.Tables[0];                
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        #endregion
    }
}
