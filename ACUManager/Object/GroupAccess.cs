using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class GroupAccess
    {
        public GroupAccess() { }
        public GroupAccess(string groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }

        public GroupAccess(string groupId, string groupName, string groupDescription)
        {
            GroupId = groupId;
            GroupName = groupName;
            GroupDescription = groupDescription;
        }

        public GroupAccess(string groupId, string groupName, string groupDescription, List<AccessLevel> accessLv, List<Users> listUsers, List<GroupUser> listGroupUsers)
        {
            GroupId = groupId;
            GroupName = groupName;
            GroupDescription = groupDescription;
            ListGroupUsers = listGroupUsers;
            ListUsers = listUsers;
            AccessLv = accessLv;
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

        private string groupDescription;

        public string GroupDescription
        {
            get { return groupDescription; }
            set { groupDescription = value; }
        }

        private List<AccessLevel> accessLv;

        public List<AccessLevel> AccessLv
        {
            get { return accessLv; }
            set { accessLv = value; }
        }

        private List<Users> listUsers;

        public List<Users> ListUsers
        {
            get { return listUsers; }
            set { listUsers = value; }
        }

        private List<GroupUser> listGroupUsers;

        public List<GroupUser> ListGroupUsers
        {
            get { return listGroupUsers; }
            set { listGroupUsers = value; }
        }

        #region Query
        /// <summary>
        /// Get all access group from DB
        /// </summary>
        /// <returns>list of access group</returns>
        public static List<GroupAccess> GetAllAccessGroup()
        {
            List<GroupAccess> groupAccesses = new List<GroupAccess>();            
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessQuery("Q", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["groupID"].ToString();
                    GroupAccess group = GroupAccess.GetAccessGroupById(Id);
                    groupAccesses.Add(group);

                }
                return groupAccesses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get access group base on user inside it from DB
        /// </summary>
        /// <returns>one group access object</returns>
        public static GroupAccess GetAccessGroupByUser(string userId)
        {
            GroupAccess groupAccesses = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUQuery("Q", "", userId);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["groupAccessId"].ToString();                  
                    groupAccesses = GroupAccess.GetAccessGroupById(Id);

                }
                return groupAccesses;
            }
            catch (Exception ex)
            {
                return groupAccesses;
            }
        }

        /// <summary>
        /// Get access group base on group id from DB
        /// </summary>
        /// <returns>one group access object</returns>
        public static GroupAccess GetAccessGroupById(string groupId)
        {
            GroupAccess groupAccesses = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessQuery("Q",groupId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["groupId"].ToString();
                    string Name = dr["groupName"].ToString();
                    string description = dr["groupDescription"].ToString();

                    //Get user in group
                    List<Users> users = Users.LoadUsersByACGroup(Id);

                    //Get Guser in group
                    List<GroupUser> groupUsers = GroupUser.LoadUserGroupByACGroup(Id);

                    //Get Access Lv in group
                    List<AccessLevel> accessLevels = AccessLevel.LoadAccessLevelByACGroup(Id);

                    groupAccesses = new GroupAccess(Id, Name, description,accessLevels,users,groupUsers);

                }
                return groupAccesses;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Auto generate access group id base on max group id from DB
        /// </summary>
        /// <returns>Group ID: ACGxxxxxxx</returns>
        public static string GenGroupId()
        {
            string Id = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessQuery("S", "", "");
                dt = ds.Tables[0];
                Id = dt.Rows[0][0].ToString();

                return Id;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Add new access group to DB
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Add(string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                //Add access group master info
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessSave("A", groupId, groupName,groupDescription, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();

                if (Result == "OK")
                {
                    //Add user
                    foreach (Users u in listUsers)
                    {
                        Result = AddUser(u.Id, creator);
                    }

                    //Add Guser
                    foreach (GroupUser gu in listGroupUsers)
                    {
                        Result = AddUserGroup(gu.groupId, creator);
                    }

                    //Add accesslv
                    foreach (AccessLevel ac in accessLv)
                    {
                        Result = AddAccessLevel(ac.groupId, creator);
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Add: {0}",ex.ToString());
            }
        }

        /// <summary>
        /// Update access group info
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Update(string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessSave("U", groupId, groupName, groupDescription, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();

                //Delete old user
                Result = DeleteAllUser(groupId,creator);

                //Add user
                foreach (Users u in listUsers)
                {
                    Result = AddUser(u.Id, creator);
                }

                //Delete old user group
                Result = DeleteAllUserGroup(groupId, creator);
                //Add Guser
                foreach (GroupUser gu in listGroupUsers)
                {
                    Result = AddUserGroup(gu.groupId, creator);
                }

                //Delete old accessLv
                Result = DeleteAllAccesslv(groupId, creator);
                //Add accesslv
                foreach (AccessLevel ac in accessLv)
                {
                    Result = AddAccessLevel(ac.groupId, creator);
                }
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Update: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete access group
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Delete(string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessSave("D", groupId, groupName, groupDescription, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();                
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Add access level into access group
        /// </summary>
        /// <param name="accessLevelId">ID of access level need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string AddAccessLevel(string accessLevelId, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessLSave("A", groupId, accessLevelId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Add access level: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete access level in access group
        /// </summary>
        /// <param name="accessLevelId">ID of access level need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string DeleteAccessLevel(string accessLevelId, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessLSave("D", "", accessLevelId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete access level: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete all access level in access group
        /// </summary>
        /// <param name="groupid">ID of access group include access level need delete</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteAllAccesslv(string groupid, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessLSave("D", groupid, "", creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete all access level: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Add user into access group
        /// </summary>
        /// <param name="userId">Id of user need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string AddUser(string userId,string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUSave("A", groupId, userId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Add user: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete user in access group
        /// </summary>
        /// <param name="userId">Id of user need delete</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string DeleteUser(string userId, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUSave("D", "", userId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete user: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete all user in access group
        /// </summary>
        /// <param name="groupid">Id of access group need delete user</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteAllUser(string groupid, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUSave("D", groupid, "", creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete all user: {0}", ex.ToString());
            }
        }


        /// <summary>
        /// Add user group in access group
        /// </summary>
        /// <param name="groupId">Id of user group need add</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string AddUserGroup(string groupId, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUGSave("A", GroupId, groupId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Add user group: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete user group in access group
        /// </summary>
        /// <param name="groupId">Id of user group need delete</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string DeleteUserGroup(string groupId, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUGSave("D", "", groupId, creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete user group: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// Delete all user group in access group
        /// </summary>
        /// <param name="groupid">Id of access group need delete</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public static string DeleteAllUserGroup(string groupid, string creator)
        {
            string Result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUGSave("D", groupid, "", creator, DateTime.Today);
                dt = ds.Tables[0];
                Result = dt.Rows[0][0].ToString();
                return Result;
            }
            catch (Exception ex)
            {
                return string.Format("Access group class - Delete all user group: {0}", ex.ToString());
            }
        }        
        #endregion


    }
}
