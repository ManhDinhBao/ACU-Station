namespace ACUManager
{
    partial class ucSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuTileButton4 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnSchedule = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnAccount = new Bunifu.Framework.UI.BunifuTileButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuTileButton4);
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Controls.Add(this.btnAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 770);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bunifuTileButton4
            // 
            this.bunifuTileButton4.BackColor = System.Drawing.Color.SeaGreen;
            this.bunifuTileButton4.color = System.Drawing.Color.SeaGreen;
            this.bunifuTileButton4.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuTileButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton4.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton4.Image = global::ACUManager.Properties.Resources.card;
            this.bunifuTileButton4.ImagePosition = 20;
            this.bunifuTileButton4.ImageZoom = 40;
            this.bunifuTileButton4.LabelPosition = 40;
            this.bunifuTileButton4.LabelText = "CARD";
            this.bunifuTileButton4.Location = new System.Drawing.Point(335, 34);
            this.bunifuTileButton4.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton4.Name = "bunifuTileButton4";
            this.bunifuTileButton4.Size = new System.Drawing.Size(120, 120);
            this.bunifuTileButton4.TabIndex = 0;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSchedule.color = System.Drawing.Color.SeaGreen;
            this.btnSchedule.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchedule.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Image = global::ACUManager.Properties.Resources.calendar;
            this.btnSchedule.ImagePosition = 20;
            this.btnSchedule.ImageZoom = 40;
            this.btnSchedule.LabelPosition = 40;
            this.btnSchedule.LabelText = "SCHEDULE";
            this.btnSchedule.Location = new System.Drawing.Point(185, 34);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(6);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(120, 120);
            this.btnSchedule.TabIndex = 0;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAccount.color = System.Drawing.Color.SeaGreen;
            this.btnAccount.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Image = global::ACUManager.Properties.Resources.user;
            this.btnAccount.ImagePosition = 20;
            this.btnAccount.ImageZoom = 40;
            this.btnAccount.LabelPosition = 40;
            this.btnAccount.LabelText = "ACCOUNT";
            this.btnAccount.Location = new System.Drawing.Point(35, 34);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(6);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(120, 120);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // ucSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucSetting";
            this.Size = new System.Drawing.Size(1181, 770);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton4;
        private Bunifu.Framework.UI.BunifuTileButton btnSchedule;
        private Bunifu.Framework.UI.BunifuTileButton btnAccount;
    }
}
