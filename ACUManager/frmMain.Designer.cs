namespace ACUManager
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ACUManager.frmSplashScreenMain), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnAccessControl = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnEvent = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDashBoard = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnUser = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDevice = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnDoor = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogOut = new Bunifu.Framework.UI.BunifuImageButton();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.linkHelp = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hyperlinkLabelControl2 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 100;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.btnAccessControl);
            this.panelMenu.Controls.Add(this.btnEvent);
            this.panelMenu.Controls.Add(this.btnDashBoard);
            this.panelMenu.Controls.Add(this.btnUser);
            this.panelMenu.Controls.Add(this.btnDevice);
            this.panelMenu.Controls.Add(this.btnDoor);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 55);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(89, 770);
            this.panelMenu.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Controls.Add(this.btnMinimize);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 743);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(89, 27);
            this.panel4.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(66, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Image = global::ACUManager.Properties.Resources.minimize;
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(42, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnAccessControl
            // 
            this.btnAccessControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnAccessControl.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnAccessControl.colorActive = System.Drawing.Color.RosyBrown;
            this.btnAccessControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccessControl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccessControl.ForeColor = System.Drawing.Color.White;
            this.btnAccessControl.Image = global::ACUManager.Properties.Resources.AccessGroup;
            this.btnAccessControl.ImagePosition = 10;
            this.btnAccessControl.ImageZoom = 45;
            this.btnAccessControl.LabelPosition = 30;
            this.btnAccessControl.LabelText = "ACCESS GROUP";
            this.btnAccessControl.Location = new System.Drawing.Point(0, 320);
            this.btnAccessControl.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccessControl.Name = "btnAccessControl";
            this.btnAccessControl.Size = new System.Drawing.Size(89, 80);
            this.btnAccessControl.TabIndex = 1;
            this.btnAccessControl.Click += new System.EventHandler(this.btnAccessControl_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnEvent.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnEvent.colorActive = System.Drawing.Color.RosyBrown;
            this.btnEvent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvent.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.Color.White;
            this.btnEvent.Image = global::ACUManager.Properties.Resources.Monitoring;
            this.btnEvent.ImagePosition = 10;
            this.btnEvent.ImageZoom = 45;
            this.btnEvent.LabelPosition = 30;
            this.btnEvent.LabelText = "MONITORING";
            this.btnEvent.Location = new System.Drawing.Point(0, 402);
            this.btnEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(89, 80);
            this.btnEvent.TabIndex = 1;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDashBoard.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDashBoard.colorActive = System.Drawing.Color.RosyBrown;
            this.btnDashBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashBoard.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.White;
            this.btnDashBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashBoard.Image")));
            this.btnDashBoard.ImagePosition = 10;
            this.btnDashBoard.ImageZoom = 45;
            this.btnDashBoard.LabelPosition = 30;
            this.btnDashBoard.LabelText = "DASHBOARD";
            this.btnDashBoard.Location = new System.Drawing.Point(0, 0);
            this.btnDashBoard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(89, 80);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnUser.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnUser.colorActive = System.Drawing.Color.RosyBrown;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.ImagePosition = 10;
            this.btnUser.ImageZoom = 45;
            this.btnUser.LabelPosition = 30;
            this.btnUser.LabelText = "USER";
            this.btnUser.Location = new System.Drawing.Point(0, 80);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(89, 80);
            this.btnUser.TabIndex = 1;
            this.btnUser.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            // 
            // btnDevice
            // 
            this.btnDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDevice.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDevice.colorActive = System.Drawing.Color.RosyBrown;
            this.btnDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevice.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevice.ForeColor = System.Drawing.Color.White;
            this.btnDevice.Image = global::ACUManager.Properties.Resources.arcade;
            this.btnDevice.ImagePosition = 12;
            this.btnDevice.ImageZoom = 45;
            this.btnDevice.LabelPosition = 30;
            this.btnDevice.LabelText = "DEVICE";
            this.btnDevice.Location = new System.Drawing.Point(0, 160);
            this.btnDevice.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.Size = new System.Drawing.Size(89, 80);
            this.btnDevice.TabIndex = 1;
            this.btnDevice.Click += new System.EventHandler(this.btnDevice_Click);
            // 
            // btnDoor
            // 
            this.btnDoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDoor.color = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.btnDoor.colorActive = System.Drawing.Color.RosyBrown;
            this.btnDoor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoor.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoor.ForeColor = System.Drawing.Color.White;
            this.btnDoor.Image = global::ACUManager.Properties.Resources.door;
            this.btnDoor.ImagePosition = 10;
            this.btnDoor.ImageZoom = 45;
            this.btnDoor.LabelPosition = 30;
            this.btnDoor.LabelText = "DOOR";
            this.btnDoor.Location = new System.Drawing.Point(0, 240);
            this.btnDoor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoor.Name = "btnDoor";
            this.btnDoor.Size = new System.Drawing.Size(89, 80);
            this.btnDoor.TabIndex = 1;
            this.btnDoor.Click += new System.EventHandler(this.btnDoor_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelData);
            this.panel3.Controls.Add(this.panelMenu);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1261, 825);
            this.panel3.TabIndex = 2;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(89, 55);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1172, 770);
            this.panelData.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.linkHelp);
            this.panel1.Controls.Add(this.hyperlinkLabelControl2);
            this.panel1.Controls.Add(this.hyperlinkLabelControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 55);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ACUManager.Properties.Resources.help;
            this.pictureBox3.Location = new System.Drawing.Point(427, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ACUManager.Properties.Resources.information;
            this.pictureBox2.Location = new System.Drawing.Point(339, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ACUManager.Properties.Resources.settings;
            this.pictureBox1.Location = new System.Drawing.Point(251, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Controls.Add(this.txtUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1061, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 55);
            this.panel2.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Image = global::ACUManager.Properties.Resources.logout;
            this.btnLogOut.ImageActive = null;
            this.btnLogOut.Location = new System.Drawing.Point(168, 25);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(24, 24);
            this.btnLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.TabStop = false;
            this.btnLogOut.Zoom = 10;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(18, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(174, 16);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "Dinh Bao Manh";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // linkHelp
            // 
            this.linkHelp.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.linkHelp.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHelp.Appearance.ForeColor = System.Drawing.Color.White;
            this.linkHelp.Appearance.LinkColor = System.Drawing.Color.White;
            this.linkHelp.Appearance.Options.UseBackColor = true;
            this.linkHelp.Appearance.Options.UseFont = true;
            this.linkHelp.Appearance.Options.UseForeColor = true;
            this.linkHelp.Appearance.Options.UseLinkColor = true;
            this.linkHelp.LineColor = System.Drawing.Color.Black;
            this.linkHelp.Location = new System.Drawing.Point(457, 19);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(25, 16);
            this.linkHelp.TabIndex = 1;
            this.linkHelp.Text = "Help";
            this.linkHelp.Click += new System.EventHandler(this.linkHelp_Click);
            // 
            // hyperlinkLabelControl2
            // 
            this.hyperlinkLabelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.hyperlinkLabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperlinkLabelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.hyperlinkLabelControl2.Appearance.LinkColor = System.Drawing.Color.White;
            this.hyperlinkLabelControl2.Appearance.Options.UseBackColor = true;
            this.hyperlinkLabelControl2.Appearance.Options.UseFont = true;
            this.hyperlinkLabelControl2.Appearance.Options.UseForeColor = true;
            this.hyperlinkLabelControl2.Appearance.Options.UseLinkColor = true;
            this.hyperlinkLabelControl2.LineColor = System.Drawing.Color.Black;
            this.hyperlinkLabelControl2.Location = new System.Drawing.Point(369, 19);
            this.hyperlinkLabelControl2.Name = "hyperlinkLabelControl2";
            this.hyperlinkLabelControl2.Size = new System.Drawing.Size(33, 16);
            this.hyperlinkLabelControl2.TabIndex = 1;
            this.hyperlinkLabelControl2.Text = "About";
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.hyperlinkLabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperlinkLabelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.hyperlinkLabelControl1.Appearance.LinkColor = System.Drawing.Color.White;
            this.hyperlinkLabelControl1.Appearance.Options.UseBackColor = true;
            this.hyperlinkLabelControl1.Appearance.Options.UseFont = true;
            this.hyperlinkLabelControl1.Appearance.Options.UseForeColor = true;
            this.hyperlinkLabelControl1.Appearance.Options.UseLinkColor = true;
            this.hyperlinkLabelControl1.LineColor = System.Drawing.Color.Black;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(281, 19);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(40, 16);
            this.hyperlinkLabelControl1.TabIndex = 1;
            this.hyperlinkLabelControl1.Text = "Setting";
            this.hyperlinkLabelControl1.Click += new System.EventHandler(this.hyperlinkLabelControl1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lefa Station";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 825);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUser;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton btnLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.HyperlinkLabelControl linkHelp;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuTileButton btnEvent;
        private Bunifu.Framework.UI.BunifuTileButton btnDashBoard;
        private Bunifu.Framework.UI.BunifuTileButton btnUser;
        private Bunifu.Framework.UI.BunifuTileButton btnDevice;
        private Bunifu.Framework.UI.BunifuTileButton btnAccessControl;
        private Bunifu.Framework.UI.BunifuTileButton btnDoor;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private System.Windows.Forms.Panel panel4;
    }
}

