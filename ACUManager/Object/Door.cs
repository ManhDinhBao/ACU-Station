using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Door
    {
        public Door() { }

        public Door(string doorId, string doorName)
        {
            DoorId = doorId;
            DoorName = doorName;
        }

        public Door(string doorId, string doorName, Device deviceControl, string readerNumber, string inputNumber, string outputNumber, string relayNumber)
        {
            DoorId = doorId;
            DoorName = doorName;
            DeviceControl = deviceControl;
            ReaderNumber = readerNumber;
            InputNumber = inputNumber;
            OutputNumber = outputNumber;
            RelayNumber = relayNumber;
        }

        private string  doorId;

        public string  DoorId
        {
            get { return doorId; }
            set { doorId = value; }
        }

        private string doorName;

        public string  DoorName
        {
            get { return doorName; }
            set { doorName = value; }
        }

        private Device deviceControl;

        public Device DeviceControl
        {
            get { return deviceControl; }
            set { deviceControl = value; }
        }

        private string readerNumber;

        public string ReaderNumber
        {
            get { return readerNumber; }
            set { readerNumber = value; }
        }

        private string inputNumber;

        public string InputNumber
        {
            get { return inputNumber; }
            set { inputNumber = value; }
        }

        private string outputNumber;

        public string OutputNumber
        {
            get { return outputNumber; }
            set { outputNumber = value; }
        }

        private string relayNumber;

        public string RelayNumber
        {
            get { return relayNumber; }
            set { relayNumber = value; }
        }

        #region Query
        /// <summary>
        /// Get all door from DB
        /// </summary>
        /// <returns>List of door</returns>
        public static List<Door> LoadAllDoors()
        {
            List<Door> doors = new List<Door>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorQuery("Q", "", "", "");
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
        /// Get door by Id
        /// </summary>
        /// <param name="doorId">ID of door need get</param>
        /// <returns>one door object</returns>
        public static Door LoadDoorById(string doorId)
        {
            Door door = new Door();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorQuery("Q", doorId, "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["doorId"].ToString();
                    string Name = dr["doorName"].ToString();
                    string deviceId = dr["deviceId"].ToString();
                    Device device = Device.LoadDeviceById(deviceId);
                    string rNumber = dr["readerNumber"].ToString();
                    string iNumber = dr["inputNumber"].ToString();
                    string oNumber = dr["outputNumber"].ToString();
                    string reNumber = dr["relayNumber"].ToString();

                    door = new Door(Id, Name, device, rNumber, iNumber, oNumber, reNumber);
                }
                return door;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Auto generate door id base on max door id on DB
        /// </summary>
        /// <returns>DoorID: Dxxxxxxxxx </returns>
        public static string GenId()
        {
            string id = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorQuery("S", "", "", "");
                dt = ds.Tables[0];
                id = dt.Rows[0][0].ToString();
                return id;
            }
            catch (Exception ex)
            {
                return id;
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Add new door
        /// </summary>
        /// <param name="creator">User login</param>
        /// <returns>OK or error from DB</returns>
        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;           
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorSave("A",doorId,doorName,DeviceControl.DeviceId,readerNumber,inputNumber,outputNumber,relayNumber, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Door class - Add: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Update door info
        /// </summary>
        /// <param name="creator">User login</param>
        /// <returns>OK or error from DB</returns>
        public string Update(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorSave("U", doorId, doorName, DeviceControl.DeviceId, readerNumber, inputNumber, outputNumber, relayNumber, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Door class - Update: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Delete door
        /// </summary>
        /// <param name="creator">User login</param>
        /// <returns>OK or error from DB</returns>
        public string Delete(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DoorSave("D", doorId, "", "", "", "", "", "", creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Door class - Delete: {0}", ex.ToString());

            }
        }
        #endregion

    }
}
