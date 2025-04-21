using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagement.views.Admin;
using BookManagement.views.Admin.Danhmuc;

namespace BookManagement.views
{
    public partial class AdminPageManager : Form
    {
        public AdminPageManager()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.Show();

            // Trì hoãn BringToFront() để tránh lỗi DataGridView
            this.BeginInvoke(new Action(() =>
            {
                childForm.BringToFront();
            }));
        }


        private void staffManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AdminForm()); // Mở form quản lý nhân viên
        }

        private void shiftManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ShiftForm()); // Mở form quản lý ca làm việc
        }

        private void scheduleManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ScheduleForm()); // Mở form quản lý lịch làm việc
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void reportSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new reportScheduleForm()); // Mở form xem báo cáo điểm danh
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new reportRevenue());
        }

        private void mnu_LoaiSanPham_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;
            OpenChildForm(new LoaiSanPham());
        }

        private void mnu_DonViTinh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;
            OpenChildForm(new DonViTinh());
        }

        private void mnu_SanPham_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form hiện tại có dữ liệu chưa lưu không
            if (CheckIfCurrentFormIsDirty()) return;
            OpenChildForm(new SanPham());
        }

        private bool CheckIfCurrentFormIsDirty()
        {
            if (panel1.Controls.Count > 0 && panel1.Controls[0] is Form currentForm)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
