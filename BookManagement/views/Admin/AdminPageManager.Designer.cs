namespace BookManagement.views
{
    partial class AdminPageManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_LoaiSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcĐơnVịTínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.staffToolStripMenuItem,
            this.shiftToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.doanhThuToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1540, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_LoaiSanPham,
            this.danhMụcĐơnVịTínhToolStripMenuItem,
            this.danhMụcSảnPhẩmToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(132, 35);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // mnu_LoaiSanPham
            // 
            this.mnu_LoaiSanPham.Name = "mnu_LoaiSanPham";
            this.mnu_LoaiSanPham.Size = new System.Drawing.Size(355, 36);
            this.mnu_LoaiSanPham.Text = "Danh mục loại sản phẩm";
            this.mnu_LoaiSanPham.Click += new System.EventHandler(this.mnu_LoaiSanPham_Click);
            // 
            // danhMụcĐơnVịTínhToolStripMenuItem
            // 
            this.danhMụcĐơnVịTínhToolStripMenuItem.Name = "danhMụcĐơnVịTínhToolStripMenuItem";
            this.danhMụcĐơnVịTínhToolStripMenuItem.Size = new System.Drawing.Size(355, 36);
            this.danhMụcĐơnVịTínhToolStripMenuItem.Text = "Danh mục đơn vị tính";
            this.danhMụcĐơnVịTínhToolStripMenuItem.Click += new System.EventHandler(this.mnu_DonViTinh_Click);
            // 
            // danhMụcSảnPhẩmToolStripMenuItem
            // 
            this.danhMụcSảnPhẩmToolStripMenuItem.Name = "danhMụcSảnPhẩmToolStripMenuItem";
            this.danhMụcSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(355, 36);
            this.danhMụcSảnPhẩmToolStripMenuItem.Text = "Danh mục sản phẩm";
            this.danhMụcSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.mnu_SanPham_Click);
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffManagerToolStripMenuItem});
            this.staffToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(131, 35);
            this.staffToolStripMenuItem.Text = "Nhân viên";
            // 
            // staffManagerToolStripMenuItem
            // 
            this.staffManagerToolStripMenuItem.Name = "staffManagerToolStripMenuItem";
            this.staffManagerToolStripMenuItem.Size = new System.Drawing.Size(285, 36);
            this.staffManagerToolStripMenuItem.Text = "Quản lý nhân viên";
            this.staffManagerToolStripMenuItem.Click += new System.EventHandler(this.staffManagerToolStripMenuItem_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftManagerToolStripMenuItem});
            this.shiftToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(98, 35);
            this.shiftToolStripMenuItem.Text = "Ca làm";
            // 
            // shiftManagerToolStripMenuItem
            // 
            this.shiftManagerToolStripMenuItem.Name = "shiftManagerToolStripMenuItem";
            this.shiftManagerToolStripMenuItem.Size = new System.Drawing.Size(253, 36);
            this.shiftManagerToolStripMenuItem.Text = "Quản lý ca làm";
            this.shiftManagerToolStripMenuItem.Click += new System.EventHandler(this.shiftManagerToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleManagerToolStripMenuItem,
            this.reportSchedule});
            this.scheduleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(113, 35);
            this.scheduleToolStripMenuItem.Text = "Lịch làm";
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // scheduleManagerToolStripMenuItem
            // 
            this.scheduleManagerToolStripMenuItem.Name = "scheduleManagerToolStripMenuItem";
            this.scheduleManagerToolStripMenuItem.Size = new System.Drawing.Size(268, 36);
            this.scheduleManagerToolStripMenuItem.Text = "Quản lý lịch làm";
            this.scheduleManagerToolStripMenuItem.Click += new System.EventHandler(this.scheduleManagerToolStripMenuItem_Click);
            // 
            // reportSchedule
            // 
            this.reportSchedule.Name = "reportSchedule";
            this.reportSchedule.Size = new System.Drawing.Size(268, 36);
            this.reportSchedule.Text = "Báo cáo lịch làm";
            this.reportSchedule.Click += new System.EventHandler(this.reportSchedule_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(135, 35);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 35);
            this.toolStripMenuItem1.Text = "Thoát";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.exitToolStripMenuItem.Text = "Thoát chương trình";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.logOutToolStripMenuItem.Text = "Đăng xuất";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1540, 724);
            this.panel1.TabIndex = 1;
            // 
            // AdminPageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 763);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminPageManager";
            this.Text = "AdminPageManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem reportSchedule;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_LoaiSanPham;
        private System.Windows.Forms.ToolStripMenuItem danhMụcĐơnVịTínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcSảnPhẩmToolStripMenuItem;
    }
}