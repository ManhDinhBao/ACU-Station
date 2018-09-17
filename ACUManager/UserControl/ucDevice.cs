using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACUManager
{
    public partial class ucDevice : UserControl
    {
        string userId;
        DataTable dt;
        public ucDevice()
        {
            InitializeComponent();
        }

        public ucDevice(string _userId)
        {
            InitializeComponent();
            userId = _userId;
        }

        private void ucDevice_Load(object sender, EventArgs e)
        {
            InitTableStructure();
            LoadAllDevices();
        }
        #region Common
        /// <summary>
        /// Load all device from DB and show in listControl and gridControl
        /// </summary>
        private void LoadAllDevices()
        {
            try
            {
                dt.Clear();
                List<Device> devices = Device.LoadAllDevices();
                if (devices!=null)
                {
                    listDevice.DataSource = devices;
                    listDevice.DisplayMember = "DeviceName";
                    listDevice.ValueMember = "DeviceId";
                }

                foreach (Device d in devices)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = d.DeviceId;
                    dr["name"] = d.DeviceName;
                    dr["ip"] = d.IP;
                    dt.Rows.Add(dr);
                }

                gridData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Init data table structure for gridControl
        /// </summary>
        private void InitTableStructure()
        {
            dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("ip", typeof(string));
        }
        #endregion

        /// <summary>
        /// Show info of selected device on gridControl
        /// </summary>
        private void listDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listDevice.SelectedValue != null)
                {
                    string id = listDevice.SelectedValue.ToString();
                    if (id != "ACUManager.Device")
                    {
                        //Load device info
                        Device d = Device.LoadDeviceById(id);
                        dt.Clear();

                        DataRow dr = dt.NewRow();
                        dr["id"] = d.DeviceId;
                        dr["name"] = d.DeviceName;
                        dr["ip"] = d.IP;
                        dt.Rows.Add(dr);

                        //Show device on grid control
                        lblTitle.Text = d.DeviceName;
                        gridData.DataSource = dt;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Delete device
        /// </summary>
        private void itemDeleteDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue(gcId).ToString();
                string name = gridView1.GetFocusedRowCellValue(gcName).ToString();
                string ip = gridView1.GetFocusedRowCellValue(gcIp).ToString();

                Device d = new Device(id, name, ip);
                if (id != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete device: " + name + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        //Delete device by ID
                        string result = d.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete device " + name + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                //Reload device
                                LoadAllDevices();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Show popup delete device when user right click on gridControl
        /// </summary>
        private void gridData_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDeleteDevice.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// Go to Device detail form
        /// </summary>
        /// <remarks>
        /// Send to device detail form: Mode = E, creator id, device selected id
        /// </remarks>
        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Get deviceId in grid
                DataRowView drv = (DataRowView)gridView1.GetFocusedRow();
                DataRow dr = drv.Row;
                string deviceId = dr[0].ToString();
                string deviceName = dr[1].ToString();

                //Show detail device
                ucDeviceDetail uc = new ucDeviceDetail("E", userId, deviceId);
                Common.GoBack(uc, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Go to Device detail form
        /// </summary>
        /// <remarks>
        /// Send to device detail form: Mode = A, creator id
        /// </remarks>
        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                ucDeviceDetail uc = new ucDeviceDetail("A", userId, "");
                Panel p = (this.Parent as Panel);
                p.Controls.Clear();
                p.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}
