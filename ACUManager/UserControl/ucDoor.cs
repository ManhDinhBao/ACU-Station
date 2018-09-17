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
    public partial class ucDoor : UserControl
    {
        string userId;
        DataTable dt;

        public ucDoor()
        {
            InitializeComponent();
        }
        public ucDoor(string _userId)
        {
            InitializeComponent();
            this.userId = _userId;
        }
        private void ucDoor_Load(object sender, EventArgs e)
        {
            InitTableStructure();
            LoadAllDoors();
        }

        #region Common
        /// <summary>
        /// Init data structure store door data to show in gridControl
        /// </summary>
        private void InitTableStructure()
        {
            dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("device", typeof(string));

        }

        /// <summary>
        /// Load all door info from DB and add to listControl, gridControl
        /// </summary>
        private void LoadAllDoors()
        {
            try
            {
                dt.Clear();
                List<Door> doors = Door.LoadAllDoors();
                //Add to list
                if (doors != null)
                {
                    listDoor.DataSource = doors;
                    listDoor.DisplayMember = "DoorName";
                    listDoor.ValueMember = "DoorId";
                }

                //Show in grid
                foreach (Door d in doors)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = d.DoorId;
                    dr["name"] = d.DoorName;
                    dr["device"] = d.DeviceControl.DeviceName;
                    dt.Rows.Add(dr);
                }

                gridData.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        /// <summary>
        /// Show door info in grid when user select door 
        /// </summary>
        private void listDoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listDoor.SelectedValue != null)
                {
                    string id = listDoor.SelectedValue.ToString();
                    if (id != "ACUManager.Door")
                    {
                        dt.Clear();
                        Door d = Door.LoadDoorById(id);
                        dt.Clear();

                        DataRow dr = dt.NewRow();
                        dr["id"] = d.DoorId;
                        dr["name"] = d.DoorName;
                        dr["device"] = d.DeviceControl.DeviceName;
                        dt.Rows.Add(dr);

                        lblTitle.Text = d.DoorName;
                        gridData.DataSource = dt;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Delete door when user choose delete in popup
        /// </summary>
        private void itemDeleteDoor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue(gcId).ToString();
                string name = gridView1.GetFocusedRowCellValue(gcName).ToString();

                Door d = new Door(id, name);
                if (id != null)
                {
                    DialogResult drQ = MessageBox.Show("Confirm delete door: " + name + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.Yes)
                    {
                        string result = d.Delete(userId);
                        if (result == "OK")
                        {
                            DialogResult dr = MessageBox.Show("Delete door " + name + " success!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dr == DialogResult.OK)
                            {
                                LoadAllDoors();
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
            }
        }
        
        /// <summary>
        /// Show popup delete door when user right click in gridControl
        /// </summary>
        private void gridData_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                popupDoor.ShowPopup(Control.MousePosition);
            }
        }

        /// <summary>
        /// Show door detail
        /// </summary>
        /// <remarks>
        /// Mode = E, send user login id and id of door what user choose
        /// </remarks>
        private void gridData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Get doorId in grid
                DataRowView drv = (DataRowView)gridView1.GetFocusedRow();
                DataRow dr = drv.Row;
                string doorId = dr[0].ToString();
                string doorName = dr[1].ToString();

                //Show detail device
                ucDoorDetail uc = new ucDoorDetail("E", userId, doorId);
                Common.GoBack(uc, this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Add new door
        /// </summary>
        /// <remarks>
        /// Mode = A, send user login id and id of door what user choose
        /// </remarks>
        private void btnAddDoor_Click(object sender, EventArgs e)
        {          
            ucDoorDetail uc = new ucDoorDetail("A", userId, "");
            Panel p = (this.Parent as Panel);
            p.Controls.Clear();
            p.Controls.Add(uc);
        }
    }
}
