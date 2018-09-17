namespace ACUManager
{
    partial class ucSchedule
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSchedule));
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.itemDeleteSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnAddSchedule = new Bunifu.Framework.UI.BunifuFlatButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gridSchedule = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcScheduleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcScheduleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBack = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.listSchedule = new DevExpress.XtraEditors.ListBoxControl();
            this.popupDeleteSchedule = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDeleteSchedule)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1181, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 770);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.itemDeleteSchedule});
            this.barManager1.MaxItemId = 10;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1181, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 770);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1181, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 770);
            // 
            // itemDeleteSchedule
            // 
            this.itemDeleteSchedule.Caption = "Delete schedule";
            this.itemDeleteSchedule.Id = 9;
            this.itemDeleteSchedule.Name = "itemDeleteSchedule";
            this.itemDeleteSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemDeleteSchedule_ItemClick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.btnAddSchedule;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Active = false;
            this.btnAddSchedule.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddSchedule.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddSchedule.BorderRadius = 0;
            this.btnAddSchedule.ButtonText = "     ADD SCHEDULE";
            this.btnAddSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSchedule.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddSchedule.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddSchedule.Iconimage = global::ACUManager.Properties.Resources.calendar;
            this.btnAddSchedule.Iconimage_right = null;
            this.btnAddSchedule.Iconimage_right_Selected = null;
            this.btnAddSchedule.Iconimage_Selected = null;
            this.btnAddSchedule.IconMarginLeft = 15;
            this.btnAddSchedule.IconMarginRight = 15;
            this.btnAddSchedule.IconRightVisible = true;
            this.btnAddSchedule.IconRightZoom = 0D;
            this.btnAddSchedule.IconVisible = true;
            this.btnAddSchedule.IconZoom = 50D;
            this.btnAddSchedule.IsTab = false;
            this.btnAddSchedule.Location = new System.Drawing.Point(13, 8);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Normalcolor = System.Drawing.Color.SeaGreen;
            this.btnAddSchedule.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAddSchedule.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddSchedule.selected = false;
            this.btnAddSchedule.Size = new System.Drawing.Size(176, 35);
            this.btnAddSchedule.TabIndex = 0;
            this.btnAddSchedule.Text = "     ADD SCHEDULE";
            this.btnAddSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSchedule.Textcolor = System.Drawing.Color.White;
            this.btnAddSchedule.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.gridSchedule);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(933, 701);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // gridSchedule
            // 
            this.gridSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSchedule.Location = new System.Drawing.Point(0, 0);
            this.gridSchedule.MainView = this.gridView1;
            this.gridSchedule.MenuManager = this.barManager1;
            this.gridSchedule.Name = "gridSchedule";
            this.gridSchedule.Size = new System.Drawing.Size(933, 701);
            this.gridSchedule.TabIndex = 3;
            this.gridSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridSchedule.Click += new System.EventHandler(this.gridSchedule_Click);
            this.gridSchedule.DoubleClick += new System.EventHandler(this.gridSchedule_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcScheduleId,
            this.gcScheduleName,
            this.gcDescription});
            this.gridView1.GridControl = this.gridSchedule;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcScheduleId
            // 
            this.gcScheduleId.AppearanceCell.Options.UseTextOptions = true;
            this.gcScheduleId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcScheduleId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcScheduleId.AppearanceHeader.Options.UseFont = true;
            this.gcScheduleId.AppearanceHeader.Options.UseTextOptions = true;
            this.gcScheduleId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcScheduleId.Caption = "Schedule ID";
            this.gcScheduleId.FieldName = "scheduleId";
            this.gcScheduleId.Name = "gcScheduleId";
            this.gcScheduleId.OptionsColumn.AllowEdit = false;
            this.gcScheduleId.Visible = true;
            this.gcScheduleId.VisibleIndex = 0;
            // 
            // gcScheduleName
            // 
            this.gcScheduleName.AppearanceCell.Options.UseTextOptions = true;
            this.gcScheduleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcScheduleName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcScheduleName.AppearanceHeader.Options.UseFont = true;
            this.gcScheduleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcScheduleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcScheduleName.Caption = "Schedule Name";
            this.gcScheduleName.FieldName = "scheduleName";
            this.gcScheduleName.Name = "gcScheduleName";
            this.gcScheduleName.OptionsColumn.AllowEdit = false;
            this.gcScheduleName.Visible = true;
            this.gcScheduleName.VisibleIndex = 1;
            // 
            // gcDescription
            // 
            this.gcDescription.AppearanceCell.Options.UseTextOptions = true;
            this.gcDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcDescription.AppearanceHeader.Options.UseFont = true;
            this.gcDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDescription.Caption = "Description";
            this.gcDescription.FieldName = "description";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.OptionsColumn.AllowEdit = false;
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Schedule";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.xtraScrollableControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(933, 701);
            this.panel4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 770);
            this.panel2.TabIndex = 11;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Image = global::ACUManager.Properties.Resources.back;
            this.btnBack.ImageActive = null;
            this.btnBack.Location = new System.Drawing.Point(3, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBack.TabIndex = 18;
            this.btnBack.TabStop = false;
            this.btnBack.Zoom = 10;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddSchedule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 50);
            this.panel3.TabIndex = 0;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "man_user.png");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.xtraTabControl1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 770);
            this.panel1.TabIndex = 10;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkGreen;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 50);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(198, 718);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.listSchedule);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(192, 690);
            this.xtraTabPage1.Text = "Schedule";
            // 
            // listSchedule
            // 
            this.listSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSchedule.Location = new System.Drawing.Point(0, 0);
            this.listSchedule.Name = "listSchedule";
            this.listSchedule.Size = new System.Drawing.Size(192, 690);
            this.listSchedule.TabIndex = 2;
            this.listSchedule.SelectedIndexChanged += new System.EventHandler(this.listSchedule_SelectedIndexChanged);
            // 
            // popupDeleteSchedule
            // 
            this.popupDeleteSchedule.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.itemDeleteSchedule)});
            this.popupDeleteSchedule.Manager = this.barManager1;
            this.popupDeleteSchedule.Name = "popupDeleteSchedule";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(23, 770);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(956, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(25, 770);
            this.panel6.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.btnBack);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(23, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(933, 44);
            this.panel7.TabIndex = 20;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(23, 745);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(933, 25);
            this.panel8.TabIndex = 21;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(23, 44);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(933, 701);
            this.panel9.TabIndex = 22;
            // 
            // ucSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucSchedule";
            this.Size = new System.Drawing.Size(1181, 770);
            this.Load += new System.EventHandler(this.ucSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDeleteSchedule)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddSchedule;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btnBack;
        private DevExpress.XtraEditors.ListBoxControl listSchedule;
        private DevExpress.XtraGrid.GridControl gridSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcScheduleId;
        private DevExpress.XtraGrid.Columns.GridColumn gcScheduleName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private DevExpress.XtraBars.PopupMenu popupDeleteSchedule;
        private DevExpress.XtraBars.BarButtonItem itemDeleteSchedule;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
    }
}
