namespace BookManagement.views.Admin
{
    partial class UserForm
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
            this.mnu_DonViTinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_SanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýBánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_BanHangLe = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmBánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_ThongKeBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_diemDanh = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_DongChuongTrinh = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.quảnLýBánHàngToolStripMenuItem,
            this.mnu_diemDanh,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1711, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_LoaiSanPham,
            this.mnu_DonViTinh,
            this.mnu_SanPham});
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
            // mnu_DonViTinh
            // 
            this.mnu_DonViTinh.Name = "mnu_DonViTinh";
            this.mnu_DonViTinh.Size = new System.Drawing.Size(355, 36);
            this.mnu_DonViTinh.Text = "Danh mục đơn vị tính";
            this.mnu_DonViTinh.Click += new System.EventHandler(this.mnu_DonViTinh_Click);
            // 
            // mnu_SanPham
            // 
            this.mnu_SanPham.Name = "mnu_SanPham";
            this.mnu_SanPham.Size = new System.Drawing.Size(355, 36);
            this.mnu_SanPham.Text = "Danh mục sản phẩm";
            this.mnu_SanPham.Click += new System.EventHandler(this.mnu_SanPham_Click);
            // 
            // quảnLýBánHàngToolStripMenuItem
            // 
            this.quảnLýBánHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_BanHangLe,
            this.tìmKiếmBánHàngToolStripMenuItem,
            this.mnu_ThongKeBanHang});
            this.quảnLýBánHàngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLýBánHàngToolStripMenuItem.Name = "quảnLýBánHàngToolStripMenuItem";
            this.quảnLýBánHàngToolStripMenuItem.Size = new System.Drawing.Size(209, 35);
            this.quảnLýBánHàngToolStripMenuItem.Text = "Quản lý bán hàng";
            // 
            // mnu_BanHangLe
            // 
            this.mnu_BanHangLe.Name = "mnu_BanHangLe";
            this.mnu_BanHangLe.Size = new System.Drawing.Size(299, 36);
            this.mnu_BanHangLe.Text = "Bán hàng lẻ";
            this.mnu_BanHangLe.Click += new System.EventHandler(this.mnu_BanHangLe_Click);
            // 
            // tìmKiếmBánHàngToolStripMenuItem
            // 
            this.tìmKiếmBánHàngToolStripMenuItem.Name = "tìmKiếmBánHàngToolStripMenuItem";
            this.tìmKiếmBánHàngToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.tìmKiếmBánHàngToolStripMenuItem.Text = "Tìm kiếm bán hàng";
            this.tìmKiếmBánHàngToolStripMenuItem.Click += new System.EventHandler(this.mnnu_TimKiemBanHang_Click);
            // 
            // mnu_ThongKeBanHang
            // 
            this.mnu_ThongKeBanHang.Name = "mnu_ThongKeBanHang";
            this.mnu_ThongKeBanHang.Size = new System.Drawing.Size(299, 36);
            this.mnu_ThongKeBanHang.Text = "Thống kê bán hàng";
            this.mnu_ThongKeBanHang.Click += new System.EventHandler(this.mnu_ThongKeBanHang_Click);
            // 
            // mnu_diemDanh
            // 
            this.mnu_diemDanh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnu_diemDanh.Name = "mnu_diemDanh";
            this.mnu_diemDanh.Size = new System.Drawing.Size(140, 35);
            this.mnu_diemDanh.Text = "Điểm danh";
            this.mnu_diemDanh.Click += new System.EventHandler(this.mnu_diemDanh_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_DangXuat,
            this.mnu_DongChuongTrinh});
            this.thoátToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(86, 35);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // mnu_DangXuat
            // 
            this.mnu_DangXuat.Name = "mnu_DangXuat";
            this.mnu_DangXuat.Size = new System.Drawing.Size(297, 36);
            this.mnu_DangXuat.Text = "Đăng xuất";
            this.mnu_DangXuat.Click += new System.EventHandler(this.mnu_DangXuat_Click);
            // 
            // mnu_DongChuongTrinh
            // 
            this.mnu_DongChuongTrinh.Name = "mnu_DongChuongTrinh";
            this.mnu_DongChuongTrinh.Size = new System.Drawing.Size(297, 36);
            this.mnu_DongChuongTrinh.Text = "Đóng chương trình";
            this.mnu_DongChuongTrinh.Click += new System.EventHandler(this.mnu_DongChuongTrinh_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 37);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1711, 802);
            this.pnlContainer.TabIndex = 1;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 839);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_LoaiSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnu_SanPham;
        private System.Windows.Forms.ToolStripMenuItem mnu_DonViTinh;
        private System.Windows.Forms.ToolStripMenuItem quảnLýBánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_BanHangLe;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmBánHàngToolStripMenuItem;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_DangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnu_DongChuongTrinh;
        private System.Windows.Forms.ToolStripMenuItem mnu_ThongKeBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnu_diemDanh;
    }
}