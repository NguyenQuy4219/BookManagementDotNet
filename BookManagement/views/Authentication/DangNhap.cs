using System;
using BookManagement.Data;
using BookManagement.views.Admin;
using BookManagement.views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagement.Utils;
using BookManagement.views.Authentication;

namespace BookManagement
{
    public partial class DangNhap: Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btn_DangNhap; // 👉 Thêm dòng này để Enter = Đăng nhập
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.TestConnection();
        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            DangKi registerForm = new DangKi();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string phoneNumber = txt_SDT.Text.Trim();
            string password = txt_MatKhau.Text.Trim();

            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check login
            if (DatabaseHelper.ValidateLogin(phoneNumber, password))
            {
                MessageBox.Show($"Chào mừng, {UserSession.FullName}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                // Redirect user based on role
                if (UserSession.Role == "staff")
                {
                    UserForm userForm = new UserForm();
                    userForm.Show();
                }
                else
                {
                    // Nếu role là admin thì chuyển sang trang admin
                    AdminPageManager adminForm = new AdminPageManager();
                    adminForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Số điện thoại hoặc mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            this.Hide();
            doiMatKhau.ShowDialog();
            this.Show();
        }

        
    }
}
