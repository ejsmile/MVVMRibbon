namespace MVVMRibbon {
    partial class MainView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biLogout = new DevExpress.XtraBars.BarButtonItem();
            this.biiSalary = new DevExpress.XtraBars.BarButtonItem();
            this.biiEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.biiManager = new DevExpress.XtraBars.BarButtonItem();
            this.biiSalesman = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, this.tabbedView1)});
            this.mvvmContext1.ViewModelType = typeof(MVVMRibbon.Models.ViewModels.MyDbContextViewModel);
            // 
            // tabbedView1
            // 
            this.tabbedView1.RootContainer.Element = null;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.biLogout,
            this.biiSalary,
            this.biiEmployee,
            this.biiManager,
            this.biiSalesman});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.biLogout);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(644, 140);
            // 
            // biLogout
            // 
            this.biLogout.Caption = "Logout";
            this.biLogout.Id = 1;
            this.biLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biLogout.ImageOptions.Image")));
            this.biLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biLogout.ImageOptions.LargeImage")));
            this.biLogout.Name = "biLogout";
            this.biLogout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biLogout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // biiSalary
            // 
            this.biiSalary.Caption = "Salary";
            this.biiSalary.Id = 2;
            this.biiSalary.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biiSalary.ImageOptions.Image")));
            this.biiSalary.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biiSalary.ImageOptions.LargeImage")));
            this.biiSalary.Name = "biiSalary";
            // 
            // biiEmployee
            // 
            this.biiEmployee.Caption = "Employee";
            this.biiEmployee.Id = 3;
            this.biiEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biiEmployee.ImageOptions.Image")));
            this.biiEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biiEmployee.ImageOptions.LargeImage")));
            this.biiEmployee.Name = "biiEmployee";
            // 
            // biiManager
            // 
            this.biiManager.Caption = "Manager";
            this.biiManager.Id = 4;
            this.biiManager.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biiManager.ImageOptions.Image")));
            this.biiManager.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biiManager.ImageOptions.LargeImage")));
            this.biiManager.Name = "biiManager";
            // 
            // biiSalesman
            // 
            this.biiSalesman.Caption = "Salesman";
            this.biiSalesman.Id = 5;
            this.biiSalesman.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biiSalesman.ImageOptions.Image")));
            this.biiSalesman.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biiSalesman.ImageOptions.LargeImage")));
            this.biiSalesman.Name = "biiSalesman";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Pages";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.biiSalary);
            this.ribbonPageGroup1.ItemLinks.Add(this.biiEmployee);
            this.ribbonPageGroup1.ItemLinks.Add(this.biiManager);
            this.ribbonPageGroup1.ItemLinks.Add(this.biiSalesman);
            this.ribbonPageGroup1.ItemLinks.Add(this.biLogout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Navigation";
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 355);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses Application";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem biLogout;
        private DevExpress.XtraBars.BarButtonItem biiSalary;
        private DevExpress.XtraBars.BarButtonItem biiEmployee;
        private DevExpress.XtraBars.BarButtonItem biiManager;
        private DevExpress.XtraBars.BarButtonItem biiSalesman;
    }
}

