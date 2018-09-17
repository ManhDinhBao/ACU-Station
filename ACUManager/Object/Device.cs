using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ACUManager
{
    class Device
    {
        public Device() { }

        public Device(string deviceId, string deviceName, string ip)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
            IP = ip;
        }

        private string deviceId;

        public string DeviceId
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        private string deviceName;

        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }

        private string ip;

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        #region Query
        /// <summary>
        /// Get all device info from DB
        /// </summary>
        /// <returns>List of device</returns>
        public static List<Device> LoadAllDevices()
        {
            List<Device> devices = new List<Device>();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceQuery("Q", "", "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["deviceId"].ToString();
                    string Name = dr["deviceName"].ToString();
                    string ip = dr["deviceIP"].ToString();

                    Device device = new Device(Id, Name, ip);
                    devices.Add(device);
                }
                return devices;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get device by device id from DB
        /// </summary>
        /// <param name="deviceId">Id of device need get</param>
        /// <returns>One device object</returns>
        public static Device LoadDeviceById(string deviceId)
        {
            Device device = new Device();
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceQuery("Q", deviceId, "", "");
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string Id = dr["deviceId"].ToString();
                    string Name = dr["deviceName"].ToString();
                    string ip = dr["deviceIP"].ToString();

                    device = new Device(Id, Name, ip);
                } 
                return device;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Auto generate device id base on max device id on DB
        /// </summary>
        /// <returns>Device ID: DExxxxxxxx </returns>
        public static string GenId()
        {
            string id = "";
            DataTable dt = null;
            try
            {
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceQuery("S", "", "", "");
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
        /// Add new device
        /// </summary>
        /// <param name="creator">User log in</param>
        /// <returns>Ok or error from DB</returns>
        public string Add(string creator)
        {
            string result = "OK";
            DataTable dt = null;          
            try
            {
                //Add new device
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceSave("A",deviceId,deviceName,ip, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();               

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Device class - Add: {0}",ex.ToString());
            }

        }

        /// <summary>
        /// Update device info
        /// </summary>
        /// <param name="creator">User log in</param>
        /// <returns>Ok or error from DB</returns>
        public string Update(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                //Update device info
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceSave("U", deviceId, deviceName, ip, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Device class - Update: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// Delete device
        /// </summary>
        /// <param name="creator">User log in</param>
        /// <returns>Ok or error from DB</returns>
        public string Delete(string creator)
        {
            string result = "OK";
            DataTable dt = null;            
            try
            {
                //Delete device
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceSave("D", deviceId, deviceName, ip, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Device class - Delete: {0}", ex.ToString());
            }

        }

        public string ChangePassword(string creator)
        {
            string result = "OK";
            DataTable dt = null;
            try
            {
                //Delete device
                ServiceReference1.WSACUSoapClient client = new ServiceReference1.WSACUSoapClient();
                DataSet ds = client.DeviceSave("D", deviceId, deviceName, ip, creator, DateTime.Now);
                dt = ds.Tables[0];
                result = dt.Rows[0][0].ToString();

                return result;
            }
            catch (Exception ex)
            {
                return string.Format("Device class - Delete: {0}", ex.ToString());
            }

        }
        #endregion
    }
}
