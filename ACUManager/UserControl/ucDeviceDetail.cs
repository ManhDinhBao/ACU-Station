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
    public partial class ucDeviceDetail : UserControl
    {
        string userId, mode,deviceId;
        public ucDeviceDetail()
        {
            InitializeComponent();
        }
        public ucDeviceDetail(string _mode, string _userId, string _deviceId)
        {
            InitializeComponent();
            this.userId = _userId;
            this.mode = _mode;
            this.deviceId = _deviceId;

        }
        private void ucDeviceDetail_Load(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            if (mode == "A")
            {
                txtID.Text = Device.GenId();
                txtID.ReadOnly = false;
                if (lblCheckId.Text == "OK") btnApply.Enabled = true;
            }
            else
                if (mode == "E")
            {
                txtID.ReadOnly = true;
                btnApply.Enabled = true;
                ShowDeviceInfo();
            }

        }

        #region Common
        /// <summary>
        /// Show device info to controls
        /// </summary>
        private void ShowDeviceInfo()
        {
            try
            {
                Device d = Device.LoadDeviceById(deviceId);
                if (d != null)
                {
                    txtID.Text = d.DeviceId;
                    txtName.Text = d.DeviceName;
                    txtIP.Text = d.IP;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            
        }

        /// <summary>
        /// Go back to Device master form
        /// </summary>
        private void GoBack()
        {
            ucDevice uc = new ucDevice(userId);

            Common.GoBack(uc, this);
        }

        /// <summary>
        /// Reset controls after add new device
        /// </summary>
        private void ResetControl()
        {
            txtID.Text = Device.GenId();
            txtIP.Text = "";
            txtName.Text = "";
        }
        #endregion       

        /// <summary>
        /// Check duplicate ID
        /// </summary>
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (mode == "A")
                {
                    if (txtID.Text.Count() > 0)
                    {
                        Device d = Device.LoadDeviceById(txtID.Text);
                        if (d.DeviceId != null)
                        {
                            lblCheckId.Text = "Duplicated";
                            lblCheckId.ForeColor = Color.Red;
                            btnApply.Enabled = false;
                        }
                        else
                        {
                            lblCheckId.Text = "OK";
                            lblCheckId.ForeColor = Color.Green;
                            btnApply.Enabled = true;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }        

        /// <summary>
        /// Save device info to DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Device d = new Device(txtID.Text, txtName.Text, txtIP.Text);
                if (mode == "A")
                {
                    //Add device                
                    string result = d.Add(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add device " + d.DeviceName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ResetControl();
                }
                else
                   if (mode == "E")
                {
                    //Update device
                    string result = d.Update(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update device " + d.DeviceName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }   
        
    }
}
