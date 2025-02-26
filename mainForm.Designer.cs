namespace AFTAB
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Main_menu = new System.Windows.Forms.MenuStrip();
            this.BOM = new System.Windows.Forms.ToolStripMenuItem();
            this.BomCemical = new System.Windows.Forms.ToolStripMenuItem();
            this.BomCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.BomSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.Planing = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaningAsk = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaningProduction = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaningRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.Store = new System.Windows.Forms.ToolStripMenuItem();
            this.StoreSell = new System.Windows.Forms.ToolStripMenuItem();
            this.مالیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تولیدوکارکردToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشروزانهتولیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشروزانهاستریلیزاسیونToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشروزانهدریافتشیرخامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشروزانهCIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتگزارشروزانهپاستورToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتفرمدوبارهکاریتولیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انبارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.شناسنامهپالتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.NewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_menu
            // 
            resources.ApplyResources(this.Main_menu, "Main_menu");
            this.Main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BOM,
            this.Planing,
            this.Store,
            this.مالیToolStripMenuItem,
            this.تولیدوکارکردToolStripMenuItem,
            this.انبارToolStripMenuItem,
            this.UserManage});
            this.Main_menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Main_menu.Name = "Main_menu";
            // 
            // BOM
            // 
            this.BOM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BomCemical,
            this.BomCreate,
            this.BomSearch});
            this.BOM.Name = "BOM";
            resources.ApplyResources(this.BOM, "BOM");
            // 
            // BomCemical
            // 
            this.BomCemical.Name = "BomCemical";
            resources.ApplyResources(this.BomCemical, "BomCemical");
            this.BomCemical.Click += new System.EventHandler(this.CemicalMaterial_Click);
            // 
            // BomCreate
            // 
            this.BomCreate.Name = "BomCreate";
            resources.ApplyResources(this.BomCreate, "BomCreate");
            this.BomCreate.Click += new System.EventHandler(this.CreateBom_Click);
            // 
            // BomSearch
            // 
            this.BomSearch.Name = "BomSearch";
            resources.ApplyResources(this.BomSearch, "BomSearch");
            this.BomSearch.Click += new System.EventHandler(this.BomSearch_Click);
            // 
            // Planing
            // 
            this.Planing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlaningAsk,
            this.PlaningProduction,
            this.PlaningRedo});
            this.Planing.Name = "Planing";
            resources.ApplyResources(this.Planing, "Planing");
            // 
            // PlaningAsk
            // 
            this.PlaningAsk.Name = "PlaningAsk";
            resources.ApplyResources(this.PlaningAsk, "PlaningAsk");
            // 
            // PlaningProduction
            // 
            this.PlaningProduction.Name = "PlaningProduction";
            resources.ApplyResources(this.PlaningProduction, "PlaningProduction");
            // 
            // PlaningRedo
            // 
            this.PlaningRedo.Name = "PlaningRedo";
            resources.ApplyResources(this.PlaningRedo, "PlaningRedo");
            // 
            // Store
            // 
            this.Store.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StoreSell});
            this.Store.Name = "Store";
            resources.ApplyResources(this.Store, "Store");
            // 
            // StoreSell
            // 
            this.StoreSell.Name = "StoreSell";
            resources.ApplyResources(this.StoreSell, "StoreSell");
            // 
            // مالیToolStripMenuItem
            // 
            this.مالیToolStripMenuItem.Name = "مالیToolStripMenuItem";
            resources.ApplyResources(this.مالیToolStripMenuItem, "مالیToolStripMenuItem");
            // 
            // تولیدوکارکردToolStripMenuItem
            // 
            this.تولیدوکارکردToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.گزارشروزانهتولیدToolStripMenuItem,
            this.گزارشروزانهاستریلیزاسیونToolStripMenuItem,
            this.گزارشروزانهدریافتشیرخامToolStripMenuItem,
            this.گزارشروزانهCIPToolStripMenuItem,
            this.گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem,
            this.گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem,
            this.ثبتگزارشروزانهپاستورToolStripMenuItem,
            this.ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem,
            this.ثبتفرمدوبارهکاریتولیدToolStripMenuItem,
            this.ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem});
            this.تولیدوکارکردToolStripMenuItem.Name = "تولیدوکارکردToolStripMenuItem";
            resources.ApplyResources(this.تولیدوکارکردToolStripMenuItem, "تولیدوکارکردToolStripMenuItem");
            // 
            // گزارشروزانهتولیدToolStripMenuItem
            // 
            this.گزارشروزانهتولیدToolStripMenuItem.Name = "گزارشروزانهتولیدToolStripMenuItem";
            resources.ApplyResources(this.گزارشروزانهتولیدToolStripMenuItem, "گزارشروزانهتولیدToolStripMenuItem");
            // 
            // گزارشروزانهاستریلیزاسیونToolStripMenuItem
            // 
            this.گزارشروزانهاستریلیزاسیونToolStripMenuItem.Name = "گزارشروزانهاستریلیزاسیونToolStripMenuItem";
            resources.ApplyResources(this.گزارشروزانهاستریلیزاسیونToolStripMenuItem, "گزارشروزانهاستریلیزاسیونToolStripMenuItem");
            // 
            // گزارشروزانهدریافتشیرخامToolStripMenuItem
            // 
            this.گزارشروزانهدریافتشیرخامToolStripMenuItem.Name = "گزارشروزانهدریافتشیرخامToolStripMenuItem";
            resources.ApplyResources(this.گزارشروزانهدریافتشیرخامToolStripMenuItem, "گزارشروزانهدریافتشیرخامToolStripMenuItem");
            // 
            // گزارشروزانهCIPToolStripMenuItem
            // 
            this.گزارشروزانهCIPToolStripMenuItem.Name = "گزارشروزانهCIPToolStripMenuItem";
            resources.ApplyResources(this.گزارشروزانهCIPToolStripMenuItem, "گزارشروزانهCIPToolStripMenuItem");
            // 
            // گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem
            // 
            this.گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem.Name = "گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem";
            resources.ApplyResources(this.گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem, "گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem");
            // 
            // گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem
            // 
            this.گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem.Name = "گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem";
            resources.ApplyResources(this.گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem, "گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem");
            // 
            // ثبتگزارشروزانهپاستورToolStripMenuItem
            // 
            this.ثبتگزارشروزانهپاستورToolStripMenuItem.Name = "ثبتگزارشروزانهپاستورToolStripMenuItem";
            resources.ApplyResources(this.ثبتگزارشروزانهپاستورToolStripMenuItem, "ثبتگزارشروزانهپاستورToolStripMenuItem");
            // 
            // ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem
            // 
            this.ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem.Name = "ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem";
            resources.ApplyResources(this.ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem, "ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem");
            // 
            // ثبتفرمدوبارهکاریتولیدToolStripMenuItem
            // 
            this.ثبتفرمدوبارهکاریتولیدToolStripMenuItem.Name = "ثبتفرمدوبارهکاریتولیدToolStripMenuItem";
            resources.ApplyResources(this.ثبتفرمدوبارهکاریتولیدToolStripMenuItem, "ثبتفرمدوبارهکاریتولیدToolStripMenuItem");
            // 
            // ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem
            // 
            this.ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem.Name = "ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem";
            resources.ApplyResources(this.ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem, "ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem");
            // 
            // انبارToolStripMenuItem
            // 
            this.انبارToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.شناسنامهپالتToolStripMenuItem,
            this.ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem,
            this.ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem});
            this.انبارToolStripMenuItem.Name = "انبارToolStripMenuItem";
            resources.ApplyResources(this.انبارToolStripMenuItem, "انبارToolStripMenuItem");
            // 
            // شناسنامهپالتToolStripMenuItem
            // 
            this.شناسنامهپالتToolStripMenuItem.Name = "شناسنامهپالتToolStripMenuItem";
            resources.ApplyResources(this.شناسنامهپالتToolStripMenuItem, "شناسنامهپالتToolStripMenuItem");
            // 
            // ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem
            // 
            this.ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem.Name = "ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem";
            resources.ApplyResources(this.ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem, "ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem");
            // 
            // ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem
            // 
            this.ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem.Name = "ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem";
            resources.ApplyResources(this.ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem, "ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem");
            // 
            // UserManage
            // 
            this.UserManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewUser});
            this.UserManage.Name = "UserManage";
            resources.ApplyResources(this.UserManage, "UserManage");
            // 
            // NewUser
            // 
            this.NewUser.Name = "NewUser";
            resources.ApplyResources(this.NewUser, "NewUser");
            this.NewUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Main_menu;
            this.Name = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Main_menu.ResumeLayout(false);
            this.Main_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Main_menu;
        private System.Windows.Forms.ToolStripMenuItem BOM;
        private System.Windows.Forms.ToolStripMenuItem BomCemical;
        private System.Windows.Forms.ToolStripMenuItem BomCreate;
        private System.Windows.Forms.ToolStripMenuItem BomSearch;
        private System.Windows.Forms.ToolStripMenuItem Planing;
        private System.Windows.Forms.ToolStripMenuItem Store;
        private System.Windows.Forms.ToolStripMenuItem مالیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تولیدوکارکردToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انبارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlaningAsk;
        private System.Windows.Forms.ToolStripMenuItem StoreSell;
        private System.Windows.Forms.ToolStripMenuItem گزارشروزانهتولیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشروزانهاستریلیزاسیونToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشروزانهدریافتشیرخامToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشروزانهCIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشکارکرددستگاهبستهبندیتتراپکToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem گزارشروزانهقسمتموادزنیمحصولاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشروزانهپاستورToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشتولیدآبآشامیدنیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتفرمدوبارهکاریتولیدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتکنترلدمایدستگاهپرکنیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem شناسنامهپالتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشروزانهتحویلمحصولبهانبارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ثبتگزارشاقلامبرگشتیبهانبارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserManage;
        private System.Windows.Forms.ToolStripMenuItem NewUser;
        private System.Windows.Forms.ToolStripMenuItem PlaningProduction;
        private System.Windows.Forms.ToolStripMenuItem PlaningRedo;
    }
}

