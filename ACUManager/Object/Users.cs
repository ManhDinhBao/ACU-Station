using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Users
    {
        public Users() { }

        public Users(string userName, string passWord, string userId)
        {
            UserName = userName;
            PassWord = passWord;
            Id = userId;

        }

        public Users(string id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            UserName = username;
            PassWord = password;
        }
        public Users(string id, string name, string username, string password, string email)
        {
            Id = id;
            Name = name;
            UserName = username;
            PassWord = password;
            Email = email;
        }

        public Users(string id, string name, string username, string password, string email, string phoneNo, bool status, string optLevel, List<Card> listCard,byte[] avatar,DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            UserName = username;
            PassWord = password;
            Email = email;
            PhoneNo = phoneNo;
            Status = status;
            OperatorLevel = optLevel;
            ListCard = listCard;
            Avatar = avatar;
            StartDate = startDate;
            ExperiedDate = endDate;
        }


        public Users(string id, string name, string username, string password, string email, string phoneNo, bool status, string optLevel)
        {
            Id = id;
            Name = name;
            UserName = username;
            PassWord = password;
            Email = email;
            PhoneNo = phoneNo;
            Status = status;
            OperatorLevel = optLevel;
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phoneNo;

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        private string optLevel;

        public string OperatorLevel
        {
            get { return optLevel; }
            set { optLevel = value; }
        }

        private List<Card> listCard;

        public List<Card> ListCard
        {
            get { return listCard; }
            set { listCard = value; }
        }

        private byte[] avatar;

        public byte[] Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime experiedDate;

        public DateTime ExperiedDate
        {
            get { return experiedDate; }
            set { experiedDate = value; }
        }

        #region Query
        /// <summary>
        /// Get all user info from DB
        /// </summary>
        /// <returns> List of user</returns>
        public static List<Users> LoadAllUsers()
        {
            List<Users> users = new List<Users>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserQuery("Q", "", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();

                    Users user = LoadUsersById(Id);
                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user from DB by user id
        /// </summary>
        /// <param name="id">ID of user need get</param>
        /// <returns>one user object</returns>
        public static Users LoadUsersById(string id)
        {
            Users users=null;
            DataTable dt = null;
            byte[] avatar = null;
            DateTime start=DateTime.Today;
            DateTime end = DateTime.Today;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserQuery("Q", id, "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();
                    string Name = dr["personName"].ToString();
                    string userName = dr["userName"].ToString();
                    string passWord = dr["password"].ToString();
                    string email = dr["email"].ToString();
                    string phoneNo = dr["phoneNo"].ToString();
                    bool status = Convert.ToBoolean(dr["status"]);
                    string optLevel = dr["optLevel"].ToString();
                    string s = dr["avatar"].ToString();
                    if (s != "")
                    {
                       avatar = (byte[])dr["avatar"];
                    }
                    string sStart = dr["startDate"].ToString();
                    if (sStart != "")
                    {
                        start = Convert.ToDateTime(sStart);
                    }
                    string sEnd = dr["experiedDate"].ToString();
                    if (sEnd != "")
                    {
                        end = Convert.ToDateTime(sEnd);
                    }                  

                    List<Card> cards = Card.LoadCardByUserId(Id);

                    users = new Users(Id, Name, userName, passWord, email, phoneNo, status, optLevel,cards, avatar, start,end);                   
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get users inside user group
        /// </summary>
        /// <param name="groupId">ID of group user include user need get</param>
        /// <returns>List of user inside group user</returns>
        public static List<Users> LoadUsersByGroup(string groupId)
        {
            List<Users> users = new List<Users>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupUserDetailQuery("Q", groupId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();

                    Users user = LoadUsersById(Id);
                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user inside access group
        /// </summary>
        /// <param name="groupId">ID of access group id include user</param>
        /// <returns>List of user insider access group</returns>
        public static List<Users> LoadUsersByACGroup(string groupId)
        {
            List<Users> users = new List<Users>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.GroupAccessUQuery("Q", groupId, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();
                    Users u = Users.LoadUsersById(Id);
                    users.Add(u);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Check duplicate account when create new account
        /// </summary>
        /// <param name="userName">account need check</param>
        /// <returns>true: account not exsist; false: account exsist</returns>
        public static bool CheckUserAccount(string userName)
        {
            try
            {
                bool check = true;
                List<Users> users = LoadAllUsers();
                foreach (Users u in users)
                {
                    if (u.userName == userName)
                    {
                        check = false;
                    }
                }
                return check;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Auto generate user id base on max user id in DB
        /// </summary>
        /// <returns>User id: Uxxxxxxxxx </returns>
        public static string GenUserId()
        {
            string Id = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserQuery("S", "", "", "");
                dt = ds.Tables[0];
                Id = dt.Rows[0][0].ToString();

                return Id;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Get user info when user login
        /// </summary>
        /// <param name="userName">account of user</param>
        /// <param name="passWord">password of user</param>
        /// <returns>One user object</returns>
        public static Users Login(string userName, string passWord)
        {
            Users users = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserQuery("L", "", userName, passWord);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();
                    string Name = dr["personName"].ToString();                 
                    
                    users = new Users(Id, Name, userName, passWord);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get user info to check when user fogot account
        /// </summary>
        /// <param name="userName">account of user</param>
        /// <returns>One user object</returns>
        public static Users GetForgotUser(string userName)
        {
            Users users = null;
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserQuery("F", "", userName, "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["userId"].ToString();

                    users = LoadUsersById(Id);
                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Add new user in DB
        /// </summary>
        /// <param name="groupUser">group user id include user</param>
        /// <param name="groupAccess">group access id include user</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Add(string groupUser,string groupAccess,string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                //Add new user
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserSave("A", id, optLevel, userName, passWord, name, avatar, email, phoneNo, status, startDate, experiedDate, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                if (result == "OK")
                {
                    //Add user to user group
                    GroupUser group = new GroupUser(groupUser, "");
                    result = group.AddUser(id, creator);

                    if (result == "OK")
                    {
                        //Add user to access group
                        GroupAccess accessGroup = new GroupAccess(groupAccess, "");
                        result = accessGroup.AddUser(id, creator);

                        if (result == "OK")
                        {
                            //Add card
                            foreach (Card c in listCard)
                            {
                                //Add new card
                                result = c.Add(creator);
                                result = c.AddUser(id, creator);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("User class - Add: {0}",ex.ToString());
            }

        }

        /// <summary>
        /// Update user info in DB
        /// </summary>
        /// <param name="groupUser">group user id include user</param>
        /// <param name="groupAccess">group access id include user</param>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Update(string groupUser, string groupAccess, string creator)
        {
            string result = "OK";
            DataTable dt = null;           
            try
            {
                //Update user master
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserSave("U", id, optLevel, userName, passWord, name, avatar, email, phoneNo, status, startDate, experiedDate, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                if (result == "OK")
                {
                    //Delete user in old group user
                    GroupUser group = new GroupUser("", "");
                    result = group.DeleteUser(id, creator);

                    if (result == "OK")
                    {
                        //Add user to user group
                        GroupUser group1 = new GroupUser(groupUser, "");
                        result = group1.AddUser(id, creator);

                        if (result == "OK")
                        {
                            //Delete user in old access group
                            GroupAccess accessGroup = new GroupAccess("", "");
                            result = accessGroup.DeleteUser(id, creator);

                            if (result == "OK")
                            {
                                //Add user to access group
                                GroupAccess accessGroup1 = new GroupAccess(groupAccess, "");
                                result = accessGroup1.AddUser(id, creator);

                                if(result=="OK")
                                {
                                    //Add card
                                    foreach (Card c in listCard)
                                    {
                                        result = c.Add(creator);
                                        result = c.AddUser(id, creator);
                                    }
                                }
                            }
                        }                        
                       
                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                return string.Format("User class - Update: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Delete user info in DB
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string Delete(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                //Delete user master, user in group access, group user and card
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserSave("D", id, optLevel, userName, passWord, name, avatar, email, phoneNo, status, startDate, experiedDate, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("User class - Delete: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Change password login
        /// </summary>
        /// <param name="creator">user login id</param>
        /// <returns>OK or error from DB</returns>
        public string ChangePass(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.UserSave("C", id, optLevel, userName, passWord, name, avatar, email, phoneNo, status, startDate, experiedDate, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("User class - Change password: {0}", ex.ToString());
            }

        }
        #endregion


    }
}
