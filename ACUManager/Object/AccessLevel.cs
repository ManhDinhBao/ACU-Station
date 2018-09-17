using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class AccessLevel
    {
        public AccessLevel() { }
        public AccessLevel(string groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }
        public AccessLevel(string groupId, string groupName, List<Door> listDoor, List<Schedule> listSchedule)
        {
            GroupId = groupId;
            GroupName = groupName;
            ListDoor = listDoor;
            ListSchedule = listSchedule;
        }

        private string GroupId;

        public string groupId
        {
            get { return GroupId; }
            set { GroupId = value; }
        }

        private string GroupName;

        public string groupName
        {
            get { return GroupName; }
            set { GroupName = value; }
        }

        private List<Door> listDoor;

        public List<Door> ListDoor
        {
            get { return listDoor; }
            set { listDoor = value; }
        }

        private List<Schedule> listSchedule;

        public List<Schedule> ListSchedule
        {
            get { return listSchedule; }
            set { listSchedule = value; }
        }

        #region Query
        /// <summary>
        /// Get all access level from DB
        /// </summary>
        /// <returns>List of access level</returns>
        public static List<AccessLevel> LoadAllAccessLevel()
        {
            List<AccessLevel> accessLevels = new List<AccessLevel>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelQry("Q", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string groupId = dr["accessLevelID"].ToString();

                    AccessLevel accessLevel = LoadAccessLevelById(groupId);
                    accessLevels.Add(accessLevel);
                }
                return accessLevels;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get access level inside access group
        /// </summary>
        /// <param name="groupId">Id of group access include access level</param>
        /// <returns>List of access level</returns>
        public static List<AccessLevel> LoadAccessLevelByACGroup(string groupId)
        {
            List<AccessLevel> accessLevels = new List<AccessLevel>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessLQuery("Q", groupId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["accessLevelId"].ToString();                   

                    AccessLevel accessLevel = LoadAccessLevelById(Id);
                    accessLevels.Add(accessLevel);
                }
                return accessLevels;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get access level by Id
        /// </summary>
        /// <param name="accessLvId">ID of access level need get</param>
        /// <returns>one access level object</returns>
        public static AccessLevel LoadAccessLevelById(string accessLvId)
        {
            AccessLevel accessLevel = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelQry("Q", accessLvId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["accessLevelID"].ToString();
                    string Name = dr["accessLevelName"].ToString();

                    List<Door> doors = GetDoors(Id);
                    List<Schedule> schedules = GetSchedules(Id);

                    accessLevel = new AccessLevel(Id, Name, doors, schedules);
                                     
                }
                return accessLevel;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get doors inside access level
        /// </summary>
        /// <param name="accessLvId">ID of access level include door</param>
        /// <returns>List of door</returns>
        public static List<Door> GetDoors(string accessLvId)
        {
            List<Door> doors = new List<Door>();
            DataTable dt = null;
            try
            {               
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelDQry("D", accessLvId);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["doorId"].ToString();
                    Door door = Door.LoadDoorById(Id);
                    doors.Add(door);
                }

                return doors;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Get schedules inside access level
        /// </summary>
        /// <param name="accessLvId">ID of access level include schedules</param>
        /// <returns>List of schedule</returns>
        public static List<Schedule> GetSchedules(string scheduleId)
        {
            List<Schedule> schedules = new List<Schedule>();
            DataTable dt = null;
            try
            {               
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSQry("S", scheduleId);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["scheduleId"].ToString();
                    Schedule schedule = Schedule.LoadScheduleById(Id);
                    schedules.Add(schedule);
                }

                return schedules;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Auto generate access level id base on max id on DB
        /// </summary>
        /// <returns>ID: ACSxxxxxxx </returns>
        public static string GenId()
        {
            string id = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelQry("S", "", "");
                dt = ds.Tables[0];
                id = dt.Rows[0][0].ToString();
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Save

        /// <summary>
        /// Add access level
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Add aclv master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSave("A", groupId, GroupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                //Add schedule of aclv
                foreach (Schedule s in listSchedule)
                {
                    result = AddSchedule(groupId, s.ScheduleId, creator);
                }

                //Add door of aclv
                foreach (Door d in listDoor)
                {
                    result = AddSchedule(groupId, d.DoorId, creator);
                }

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Add: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// delete access level
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Delete(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete aclv master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSave("D", groupId, GroupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Delete: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// update access level
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Update(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //update aclv master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSave("U", groupId, GroupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                //Delete old schedule
                result = DeleteAllSchedule(groupId, creator);

                //Add schedule of aclv
                foreach (Schedule s in listSchedule)
                {
                    result = AddSchedule(groupId, s.ScheduleId, creator);
                }

                //Delete old door
                result = DeleteAllDoor(groupId, creator);

                //Add door of aclv
                foreach (Door d in listDoor)
                {
                    result = AddDoor(groupId, d.DoorId, creator);
                }

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Update: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Add schedule to accesslevel
        /// </summary>
        /// <param name="accessLvId">ID of access level need add</param>
        /// <param name="scheduleId">id of schedule need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string AddSchedule(string accessLvId, string scheduleId, string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSSave("A", accessLvId, scheduleId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Add schedule: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// delete schedule inside accesslevel
        /// </summary>
        /// <param name="scheduleId">id of schedule need delete</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteSchedule(string scheduleId, string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete schedule in access level
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSSave("D","",scheduleId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();               

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Delete schedule: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// delete all schedule inside accesslevel
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteAllSchedule(string accesslvId,string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete schedule in access level
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelSSave("D", accesslvId, "", creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Delete all schedule: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Add door to accesslevel
        /// </summary>
        /// <param name="accessLvId">ID of access level need add</param>
        /// <param name="doorId">id of door need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string AddDoor(string accessLvId, string doorId, string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {                
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelDSave("A", accessLvId, doorId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Add door: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// delete all door inside accesslevel
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteAllDoor(string accesslvId, string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete door in access level
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.AccessLevelDSave("D", accesslvId, "", creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Access level class - Delete all door: {0}", ex.ToString());
            }

        }  
        #endregion
    }
}
