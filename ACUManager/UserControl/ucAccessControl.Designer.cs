namespace ACUManager
{
    partial class ucAccessControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccessControl));
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.itemDelACSGroup = new DevExpress.XtraBars.BarButtonItem();
            this.itemDelACSLevel = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddAG = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddAccessLevel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtabGroup = new DevExpress.XtraTab.XtraTabPage();
            this.listAccessGroup = new DevExpress.XtraEditors.ListBoxControl();
            this.xtabLevel = new DevExpress.XtraTab.XtraTabPage();
            this.listAccessLevel = new DevExpress.XtraEditors.ListBoxControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.popupDelACSGroup = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupDelACSLevel = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gridData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listAccessGroup)).BeginInit();
            this.xtabLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listAccessLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDelACSGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDelACSLevel)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Add user group";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Rename user group";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Delete user groop";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.itemDelACSGroup,
            this.itemDelACSLevel});
            this.barManager1.MaxItemId = 11;
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
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1181, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 770);
            // 
            // itemDelACSGroup
            // 
            this.itemDelACSGroup.Caption = "Delete Access group";
            this.itemDelACSGroup.Id = 9;
            this.itemDelACSGroup.Name = "itemDelACSGroup";
            this.itemDelACSGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemDelACSGroup_ItemClick);
            // 
            // itemDelACSLevel
            // 
            this.itemDelACSLevel.Caption = "Delete Access Level";
            this.itemDelACSLevel.Id = 10;
            this.itemDelACSLevel.Name = "itemDelACSLevel";
            this.itemDelACSLevel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.itemDelACSLevel_ItemClick);
            // 
            // btnAddAG
            // 
            this.btnAddAG.Active = false;
            this.btnAddAG.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddAG.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddAG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAG.BorderRadius = 0;
            this.btnAddAG.ButtonText = "  ADD ACCESS GROUP";
            this.btnAddAG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAG.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddAG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAG.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddAG.Iconimage = global::ACUManager.Properties.Resources.AccessGroup;
            this.btnAddAG.Iconimage_right = null;
            this.btnAddAG.Iconimage_right_Selected = null;
            this.btnAddAG.Iconimage_Selected = null;
            this.btnAddAG.IconMarginLeft = 15;
            this.btnAddAG.IconMarginRight = 15;
            this.btnAddAG.IconRightVisible = true;
            this.btnAddAG.IconRightZoom = 0D;
            this.btnAddAG.IconVisible = true;
            this.btnAddAG.IconZoom = 50D;
            this.btnAddAG.IsTab = false;
            this.btnAddAG.Location = new System.Drawing.Point(12, 8);
            this.btnAddAG.Name = "btnAddAG";
            this.btnAddAG.Normalcolor = System.Drawing.Color.SeaGreen;
            this.btnAddAG.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAddAG.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddAG.selected = false;
            this.btnAddAG.Size = new System.Drawing.Size(176, 35);
            this.btnAddAG.TabIndex = 0;
            this.btnAddAG.Text = "  ADD ACCESS GROUP";
            this.btnAddAG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAG.Textcolor = System.Drawing.Color.White;
            this.btnAddAG.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAG.Click += new System.EventHandler(this.btnAddAG_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 770);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddAccessLevel);
            this.panel3.Controls.Add(this.btnAddAG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 93);
            this.panel3.TabIndex = 0;
            // 
            // btnAddAccessLevel
            // 
            this.btnAddAccessLevel.Active = false;
            this.btnAddAccessLevel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddAccessLevel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddAccessLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAccessLevel.BorderRadius = 0;
            this.btnAddAccessLevel.ButtonText = "  ADD ACCESS LEVEL";
            this.btnAddAccessLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAccessLevel.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddAccessLevel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccessLevel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddAccessLevel.Iconimage = global::ACUManager.Properties.Resources.AccessGroup;
            this.btnAddAccessLevel.Iconimage_right = null;
            this.btnAddAccessLevel.Iconimage_right_Selected = null;
            this.btnAddAccessLevel.Iconimage_Selected = null;
            this.btnAddAccessLevel.IconMarginLeft = 15;
            this.btnAddAccessLevel.IconMarginRight = 15;
            this.btnAddAccessLevel.IconRightVisible = true;
            this.btnAddAccessLevel.IconRightZoom = 0D;
            this.btnAddAccessLevel.IconVisible = true;
            this.btnAddAccessLevel.IconZoom = 50D;
            this.btnAddAccessLevel.IsTab = false;
            this.btnAddAccessLevel.Location = new System.Drawing.Point(12, 49);
            this.btnAddAccessLevel.Name = "btnAddAccessLevel";
            this.btnAddAccessLevel.Normalcolor = System.Drawing.Color.SeaGreen;
            this.btnAddAccessLevel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnAddAccessLevel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddAccessLevel.selected = false;
            this.btnAddAccessLevel.Size = new System.Drawing.Size(176, 35);
            this.btnAddAccessLevel.TabIndex = 0;
            this.btnAddAccessLevel.Text = "  ADD ACCESS LEVEL";
            this.btnAddAccessLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAccessLevel.Textcolor = System.Drawing.Color.White;
            this.btnAddAccessLevel.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccessLevel.Click += new System.EventHandler(this.btnAddAccessLevel_Click);
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
            this.panel1.TabIndex = 8;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.DarkGreen;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 93);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtabGroup;
            this.xtraTabControl1.Size = new System.Drawing.Size(198, 675);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtabGroup,
            this.xtabLevel});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtabGroup
            // 
            this.xtabGroup.Controls.Add(this.listAccessGroup);
            this.xtabGroup.Name = "xtabGroup";
            this.xtabGroup.Size = new System.Drawing.Size(192, 647);
            this.xtabGroup.Text = "Access Group";
            // 
            // listAccessGroup
            // 
            this.listAccessGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAccessGroup.Location = new System.Drawing.Point(0, 0);
            this.listAccessGroup.Name = "listAccessGroup";
            this.listAccessGroup.Size = new System.Drawing.Size(192, 647);
            this.listAccessGroup.TabIndex = 3;
            this.listAccessGroup.SelectedIndexChanged += new System.EventHandler(this.listAccessGroup_SelectedIndexChanged);
            this.listAccessGroup.Click += new System.EventHandler(this.listAccessGroup_Click);
            // 
            // xtabLevel
            // 
            this.xtabLevel.Controls.Add(this.listAccessLevel);
            this.xtabLevel.Controls.Add(this.treeList1);
            this.xtabLevel.Name = "xtabLevel";
            this.xtabLevel.Size = new System.Drawing.Size(192, 647);
            this.xtabLevel.Text = "Access Level";
            // 
            // listAccessLevel
            // 
            this.listAccessLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAccessLevel.Location = new System.Drawing.Point(0, 0);
            this.listAccessLevel.Name = "listAccessLevel";
            this.listAccessLevel.Size = new System.Drawing.Size(192, 647);
            this.listAccessLevel.TabIndex = 4;
            this.listAccessLevel.SelectedIndexChanged += new System.EventHandler(this.listAccessLevel_SelectedIndexChanged);
            this.listAccessLevel.Click += new System.EventHandler(this.listAccessLevel_Click);
            // 
            // treeList1
            // 
            this.treeList1.Appearance.HeaderPanel.Options.UseImage = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DarkCyan;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseImage = true;
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(192, 662, 260, 232);
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[0], -1, 0, 0, 0);
            this.treeList1.AppendNode(new object[0], 0, 0, 0, 0);
            this.treeList1.AppendNode(new object[0], 0, 0, 0, 0);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.EnableAppearanceOddRow = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowFirstLines = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(192, 647);
            this.treeList1.StateImageList = this.imageCollection1;
            this.treeList1.TabIndex = 2;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.btnAddAG;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this.btnAddAccessLevel;
            // 
            // popupDelACSGroup
            // 
            this.popupDelACSGroup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.itemDelACSGroup)});
            this.popupDelACSGroup.Manager = this.barManager1;
            this.popupDelACSGroup.Name = "popupDelACSGroup";
            // 
            // popupDelACSLevel
            // 
            this.popupDelACSLevel.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.itemDelACSLevel)});
            this.popupDelACSLevel.Manager = this.barManager1;
            this.popupDelACSLevel.Name = "popupDelACSLevel";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 770);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(960, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(21, 770);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(22, 747);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(938, 23);
            this.panel7.TabIndex = 7;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblTitle);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(22, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(938, 35);
            this.panel9.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(22, 35);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(938, 712);
            this.panel10.TabIndex = 10;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.gridData);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(938, 712);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // gridData
            // 
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.Location = new System.Drawing.Point(0, 0);
            this.gridData.MainView = this.gridView1;
            this.gridData.MenuManager = this.barManager1;
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(938, 712);
            this.gridData.TabIndex = 5;
            this.gridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridData.DoubleClick += new System.EventHandler(this.gridData_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcId,
            this.gcName,
            this.gcDescription});
            this.gridView1.GridControl = this.gridData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcId
            // 
            this.gcId.AppearanceCell.Options.UseTextOptions = true;
            this.gcId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcId.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcId.AppearanceHeader.Options.UseFont = true;
            this.gcId.AppearanceHeader.Options.UseTextOptions = true;
            this.gcId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcId.Caption = "ID";
            this.gcId.FieldName = "id";
            this.gcId.Name = "gcId";
            this.gcId.OptionsColumn.AllowEdit = false;
            this.gcId.Visible = true;
            this.gcId.VisibleIndex = 0;
            // 
            // gcName
            // 
            this.gcName.AppearanceCell.Options.UseTextOptions = true;
            this.gcName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcName.AppearanceHeader.Options.UseFont = true;
            this.gcName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            // 
            // gcDescription
            // 
            this.gcDescription.AppearanceCell.Options.UseTextOptions = true;
            this.gcDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDescription.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcDescription.AppearanceHeader.Options.UseFont = true;
            this.gcDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDescription.Caption = "Card";
            this.gcDescription.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDescription.FieldName = "number";
            this.gcDescription.Name = "gcDescription";
            this.gcDescription.Visible = true;
            this.gcDescription.VisibleIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 19);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "All Access Group";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.xtraScrollableControl1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(938, 712);
            this.panel8.TabIndex = 14;
            // 
            // ucAccessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ucAccessControl";
            this.Size = new System.Drawing.Size(1181, 770);
            this.Load += new System.EventHandler(this.ucAccessControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listAccessGroup)).EndInit();
            this.xtabLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listAccessLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDelACSGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupDelACSLevel)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddAG;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtabGroup;
        private DevExpress.XtraTab.XtraTabPage xtabLevel;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddAccessLevel;
        private DevExpress.XtraEditors.ListBoxControl listAccessGroup;
        private DevExpress.XtraEditors.ListBoxControl listAccessLevel;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private DevExpress.XtraBars.BarButtonItem itemDelACSGroup;
        private DevExpress.XtraBars.BarButtonItem itemDelACSLevel;
        private DevExpress.XtraBars.PopupMenu popupDelACSGroup;
        private DevExpress.XtraBars.PopupMenu popupDelACSLevel;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraGrid.GridControl gridData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcId;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescription;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
    }
}
