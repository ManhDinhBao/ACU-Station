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
    public partial class ucDoorDetail : UserControl
    {
        string mode, userId, doorId;
        public ucDoorDetail()
        {
            InitializeComponent();
        }
        public ucDoorDetail(string _mode, string _userId, string _doorId)
        {
            InitializeComponent();
            this.mode = _mode;
            this.userId = _userId;
            this.doorId = _doorId;
        }
        private void ucDoorDetail_Load(object sender, EventArgs e)
        {
            LoadAllDevice();
            btnApply.Enabled = false;

            //Mode = A: Add new 
            //Mode = E: modify
            if (mode == "A")
            {
                txtID.ReadOnly = false;
                lblTitle.Text = "Add new door";
                txtID.Text = Door.GenId();
                if(lblCheckId.Text=="OK")
                {
                    btnApply.Enabled = true;
                }
            }
            else
            if (mode == "E")
            {
                txtID.ReadOnly = true;
                ShowDoorInfo();
                btnApply.Enabled = true;
            }
        }

        #region Common
        /// <summary>
        /// Get door data from DB and show in controls 
        /// </summary>
        private void ShowDoorInfo()
        {
            try
            {
                Door door = Door.LoadDoorById(doorId);
                if (door.DoorId != null)
                {
                    txtID.Text = door.DoorId;
                    txtName.Text = door.DoorName;
                    numReader.Value = Convert.ToInt16(door.ReaderNumber);
                    numInput.Value = Convert.ToInt16(door.InputNumber);
                    numOutput.Value = Convert.ToInt16(door.OutputNumber);
                    numRelay.Value = Convert.ToInt16(door.RelayNumber);

                    cboDevice.EditValue = door.DeviceControl.DeviceId;
                    lblTitle.Text = door.DoorName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Load all device from DB
        /// </summary>
        private void LoadAllDevice()
        {
            try
            {
                List<Device> devices = Device.LoadAllDevices();
                if (devices.Count > 0)
                {
                    cboDevice.Properties.DataSource = devices;
                    cboDevice.Properties.ValueMember = "DeviceId";
                    cboDevice.Properties.DisplayMember = "DeviceName";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Go back to door master form
        /// </summary>
        private void GoBack()
        {
            ucDoor uc = new ucDoor(userId);
            Common.GoBack(uc, this);
        }

        /// <summary>
        /// reset control status after save
        /// </summary>
        private void ResetControl()
        {
            txtID.Text = Door.GenId();
            txtName.Text = "";
            numReader.Value = 0;
            numInput.Value = 0;
            numOutput.Value = 0;
            numRelay.Value = 0;
        }
        #endregion

        /// <summary>
        /// Check duplicate door id when add new
        /// </summary>
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (mode == "A")
                {
                    if (txtID.Text.Count() > 0)
                    {
                        Door door = Door.LoadDoorById(txtID.Text);
                        if (door.DoorId != null)
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
            }
        }

        /// <summary>
        /// Save door data into DB
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Device device = new Device(cboDevice.EditValue.ToString(), cboDevice.Text, "");
                Door d = new Door(txtID.Text, txtName.Text, device, numReader.Value.ToString(), numInput.Value.ToString(), numOutput.Value.ToString(), numRelay.Value.ToString());
                if (mode == "A")
                {
                    //Add door              
                    string result = d.Add(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Add door " + d.DoorName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
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
                    //Update door
                    string result = d.Update(userId);
                    if (result == "OK")
                    {
                        MessageBox.Show("Update door " + d.DoorName + " success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }       

        /// <summary>
        /// Go back to door master form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

       
    }
}
