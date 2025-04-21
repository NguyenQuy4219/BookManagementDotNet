using BookManagement.Data;
using BookManagement.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement.views.Authentication
{
    public partial class DangKi: Form
    {
        public DangKi()
        {
            InitializeComponent();
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            string fullName = txt_HovaTen.Text.Trim();
            string phoneNumber = txt_SDT.Text.Trim();
            string password = txt_MatKhau.Text.Trim();
            string confirmPassword = txt_PasswordConfirm.Text.Trim();
            string address = txt_DiaChi.Text.Trim();
            string personalID = txt_CCCD.Text.Trim();
            string gender = rad_Nam.Checked ? "M" : rad_Nu.Checked ? "F" : "O";

            // Use centralized validation
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(personalID))
            {
                MessageBox.Show("Vui lòng nhập tất cả các trường bắt buộc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SecurityHelper.IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SecurityHelper.IsValidCCCD(personalID))
            {
                MessageBox.Show("CCCD phải có 12 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SecurityHelper.IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 4 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Attempt to register user
            bool isRegistered = DatabaseHelper.InsertUser(fullName, phoneNumber, password, address, gender, personalID);

            if (isRegistered)
            {
                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại. Số điện thoại hoặc CCCD có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đăng nhập đã mở chưa
            foreach (Form form in Application.OpenForms)
            {
                if (form is DangNhap)
                {
                    form.Show();  // Hiển thị lại nếu đã tồn tại
                    this.Close(); // Đóng Form đăng ký
                    return;
                }
            }

            // Nếu Form đăng nhập chưa tồn tại, tạo mới
            DangNhap loginForm = new DangNhap();
            loginForm.Show();
            this.Close();
        }
    }
}
