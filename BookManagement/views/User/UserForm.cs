using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagement.views.User;
using BookManagement.views.User.Danhmuc;
using BookManagement.views.User.QuanLyBanHang;
using YourNamespace;

namespace BookManagement.views.Admin
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void mnu_SanPham_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;

            // Nếu form hiện tại đã là DanhMucSanPham thì không cần mở lại
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is DanhMucSanPham)
            {
                return;
            }

            // Nếu là form khác hoặc không có form nào, xoá panel và hiển thị form mới
            pnlContainer.Controls.Clear();
            DanhMucSanPham frmDanhMucSanPham = new DanhMucSanPham
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            pnlContainer.Controls.Add(frmDanhMucSanPham);
            frmDanhMucSanPham.Show();
        }



        private void mnu_DongChuongTrinh_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Đóng toàn bộ chương trình
            }
        }

        private void mnu_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form hiện tại (không đóng hẳn)
                DangNhap loginForm = new DangNhap(); // Tạo form đăng nhập
                loginForm.ShowDialog(); // Hiển thị form đăng nhập
                this.Close(); // Đóng form hiện tại khi đăng nhập xong
            }
        }

        private void mnu_DonViTinh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;

            // Kiểm tra nếu form đã có trong panel
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is DanhMucDonViTinh)
            {
                return; // Nếu form đã mở, không làm gì nữa
            }

            // Xóa nội dung panel trước khi hiển thị form mới
            pnlContainer.Controls.Clear();

            // Tạo instance của DanhMucSachForm
            DanhMucDonViTinh frmDanhMucDonViTinh = new DanhMucDonViTinh();
            frmDanhMucDonViTinh.TopLevel = false; // Quan trọng để nhúng vào Panel
            frmDanhMucDonViTinh.FormBorderStyle = FormBorderStyle.None; // Bỏ viền cửa sổ
            frmDanhMucDonViTinh.Dock = DockStyle.Fill; // Mở rộng form để lấp đầy panel

            // Thêm form vào panel và hiển thị
            pnlContainer.Controls.Add(frmDanhMucDonViTinh);
            frmDanhMucDonViTinh.Show();
        }

        private void mnu_LoaiSanPham_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;

            // Kiểm tra nếu form DanhMucTheLoai đã có trong panel
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is DanhMucTheLoai)
            {
                return; // Nếu form đã mở, không làm gì nữa
            }

            pnlContainer.Controls.Clear();

            DanhMucTheLoai frmDanhMucTheLoai = new DanhMucTheLoai();
            frmDanhMucTheLoai.TopLevel = false;
            frmDanhMucTheLoai.FormBorderStyle = FormBorderStyle.None;
            frmDanhMucTheLoai.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(frmDanhMucTheLoai);
            frmDanhMucTheLoai.Show();
        }

        private void mnu_BanHangLe_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu form DanhMucTheLoai đã có trong panel
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is BanHangLe)
            {
                return; // Nếu form đã mở, không làm gì nữa
            }

            pnlContainer.Controls.Clear();

            BanHangLe frmBanHangLe = new BanHangLe();
            frmBanHangLe.TopLevel = false;
            frmBanHangLe.FormBorderStyle = FormBorderStyle.None;
            frmBanHangLe.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(frmBanHangLe);
            frmBanHangLe.Show();
        }
        private bool CheckIfCurrentFormIsDirty()
        {
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is Form currentForm)
            {
                var method = currentForm.GetType().GetMethod("IsDirty");
                if (method != null)
                {
                    bool isDirty = (bool)method.Invoke(currentForm, null);
                    Console.WriteLine("IsDirty() trả về: " + isDirty);
                    if (isDirty)
                    {
                        DialogResult result = MessageBox.Show(
                            "Dữ liệu chưa được lưu. Bạn có muốn tiếp tục mà không lưu?",
                            "Cảnh báo",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        return result == DialogResult.No; // Nếu chọn "No", không chuyển form
                    }
                }
            }
            return false;
        }


        private void mnnu_TimKiemBanHang_Click(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is TimKiemBanHang)
            {
                return;
            }

            pnlContainer.Controls.Clear();

            TimKiemBanHang frmTimKiemBanHang = new TimKiemBanHang();
            frmTimKiemBanHang.TopLevel = false;
            frmTimKiemBanHang.FormBorderStyle = FormBorderStyle.None;
            frmTimKiemBanHang.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(frmTimKiemBanHang);
            frmTimKiemBanHang.Show();
        }

        private void mnu_ThongKeBanHang_Click(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is ThongKeBanHang)
            {
                return;
            }

            pnlContainer.Controls.Clear();

            ThongKeBanHang frmThongKeBanHang = new ThongKeBanHang();
            frmThongKeBanHang.TopLevel = false;
            frmThongKeBanHang.FormBorderStyle = FormBorderStyle.None;
            frmThongKeBanHang.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(frmThongKeBanHang);
            frmThongKeBanHang.Show();
        }

        private void mnu_diemDanh_Click(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0 && pnlContainer.Controls[0] is DiemDanh)
            {
                return;
            }

            pnlContainer.Controls.Clear();

            DiemDanh frmDiemDanh = new DiemDanh();
            frmDiemDanh.TopLevel = false;
            frmDiemDanh.FormBorderStyle = FormBorderStyle.None;
            frmDiemDanh.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(frmDiemDanh);
            frmDiemDanh.Show();
        }
    }
}
