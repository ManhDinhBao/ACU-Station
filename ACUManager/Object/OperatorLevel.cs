using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class OperatorLevel
    {
        public OperatorLevel() { }
        public OperatorLevel(string optId, string optName)
        {
            OptId = optId;
            OptName = optName;
        }
        private string optId;

        public string  OptId
        {
            get { return optId; }
            set { optId = value; }
        }

        private string optName;

        public string OptName
        {
            get { return optName; }
            set { optName = value; }
        }

        public static List<OperatorLevel> GetAllOptLevel()
        {
            List<OperatorLevel> operatorLevels = new List<OperatorLevel>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.OperatorQuery("Q", "", "","");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["optLevelid"].ToString();
                    string Name = dr["optLevelName"].ToString();

                    OperatorLevel operatorLevel = new OperatorLevel(Id, Name);
                    operatorLevels.Add(operatorLevel);
                }
                return operatorLevels;
            }
            catch (Exception ex)
            {
                return operatorLevels;
            }
        }
        public static OperatorLevel GetOptLevelByUser(string userId)
        {
            OperatorLevel operatorLevel = null;
            DataTable dt = null;
            try
            {                
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.OperatorQuery("U", "", "", userId);
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["optLevelid"].ToString();
                    string Name = dr["optLevelName"].ToString();

                    operatorLevel = new OperatorLevel(Id, Name);
                    
                }
                return operatorLevel;
            }
            catch (Exception ex)
            {
                return operatorLevel;
            }
        }
    }
}
