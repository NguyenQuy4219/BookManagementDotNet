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
    public partial class DoiMatKhau: Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            string phoneNumber = txt_SDT.Text.Trim();
            string oldPassword = txt_MatKhauCu.Text.Trim();
            string newPassword = txt_MatKhauMoi.Text.Trim();
            string confirmPassword = txt_MatKhauMoi_lai.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền tất cả các trường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate phone number format
            if (!SecurityHelper.IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate new password length
            if (!SecurityHelper.IsValidPassword(newPassword))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 4 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Attempt to change password
            bool isChanged = DatabaseHelper.ChangePassword(phoneNumber, oldPassword, newPassword);

            if (isChanged)
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin không chính xác hoặc tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
