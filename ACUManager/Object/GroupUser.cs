using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{ 
    class GroupUser
    {
        public GroupUser() { }
        public GroupUser(string groupId, string groupName, List<Users> listUsers)
        {
            GroupId = groupId;
            GroupName = groupName;
            ListUsers = listUsers;
        }
        public GroupUser(string groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }

        private string GroupId;

        public string  groupId
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

        private List<Users> listUsers;

        public List<Users> ListUsers
        {
            get { return listUsers; }
            set { listUsers = value; }
        }

        #region Query

        /// <summary>
        /// Get all user group from DB
        /// </summary>
        /// <returns>List of user group</returns>
        public static List<GroupUser> LoadAllUserGroup()
        {
            List<GroupUser> groupUsers = new List<GroupUser>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserQuery("Q", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string groupId = dr["groupId"].ToString();                   

                    GroupUser groupUser = LoadGroupUserById(groupId);
                    groupUsers.Add(groupUser);
                }
                return groupUsers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user group inside access group
        /// </summary>
        /// <param name="groupId">Id of access group include user groups</param>
        /// <returns>List of user group</returns>
        public static List<GroupUser> LoadUserGroupByACGroup(string groupId)
        {
            List<GroupUser> groupUsers = new List<GroupUser>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUGQuery("Q", groupId,"");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["groupUserId"].ToString();

                    GroupUser groupUser = LoadGroupUserById(Id);
                    groupUsers.Add(groupUser);
                }
                return groupUsers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user group from DB
        /// </summary>
        /// <param name="groupId">ID of user group need get</param>
        /// <returns>One group user object</returns>
        public static GroupUser LoadGroupUserById(string groupId)
        {
            DataTable dt = null;
            GroupUser groupUser = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserQuery("Q", groupId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["groupId"].ToString();
                    string groupName = dr["groupName"].ToString();
                   
                    List<Users> listUsers = Users.LoadUsersByGroup(groupId);

                    groupUser = new GroupUser(groupId, groupName, listUsers);                    
                }
                return groupUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user group by user inside this group
        /// </summary>
        /// <param name="userId">ID of user inside</param>
        /// <returns>One group user object</returns>
        public static GroupUser LoadGroupUserByUserId(string userId)
        {
            DataTable dt = null;
            GroupUser groupUser = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserDetailQuery("Q", "", userId);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string groupId = dr["groupId"].ToString();

                    groupUser = LoadGroupUserById(groupId);
                }
                return groupUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Convert list user info to data table
        /// </summary>
        /// <returns>Data table store list user info</returns>
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                
                dt.Columns.Add("userId", typeof(string));
                dt.Columns.Add("personName", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("card", typeof(int));
                dt.Columns.Add("status", typeof(string));

                foreach (Users u in listUsers)
                {
                    DataRow dr = dt.NewRow();
                    dr["userId"] = u.Id;
                    dr["personName"] = u.Name;
                    dr["email"] = u.Email;
                    if (u.ListCard == null)
                    {
                        dr["card"] = 0;
                    }
                    else
                        dr["card"] = u.ListCard.Count;

                    if (u.Status)
                    {
                        dr["status"] = "Active";
                    }
                    else
                    {
                        dr["status"] = "Deactive";
                    }

                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        /// <summary>
        /// Auto generate group user id base on max group user in DB
        /// </summary>
        /// <returns></returns>
        public static string GenGroupId()
        {
            string Id = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserQuery("S", "", "");
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
        /// Add group user
        /// </summary>
        /// <param name="creator">user id login</param>
        /// <returns>OK or error from DB</returns>
        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserSave("A",groupId,groupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Group user class - Add: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// update group user
        /// </summary>
        /// <param name="creator">user id login</param>
        /// <returns>OK or error from DB</returns>
        public string Update(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserSave("U", groupId, groupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Group user class - Update: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Delete group user
        /// </summary>
        /// <param name="creator">user id login</param>
        /// <returns>OK or error from DB</returns>
        public string Delete (string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserSave("D", groupId, groupName, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Group user class - Delete: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Add user into group
        /// </summary>
        /// <param name="userId">ID of user need add</param>
        /// <param name="creator">user id login</param>
        /// <returns>OK or error from DB</returns>
        public string AddUser(string userId, string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserDetailSave("A",groupId, userId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch(Exception ex)
            {
                return string.Format("Group user class - Add user: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Delete user into group
        /// </summary>
        /// <param name="userId">ID of user need delete</param>
        /// <param name="creator">user id login</param>
        /// <returns>OK or error from DB</returns>
        public string DeleteUser(string userId, string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserDetailSave("D", "", userId, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Group user class - Delete user: {0}", ex.ToString());
            }

        }
        
        #endregion
    }
}
