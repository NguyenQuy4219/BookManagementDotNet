using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Utils
{
    public static class UserSession
    {
        public static int UserId { get; private set; }
        public static string FullName { get; private set; }
        public static string PhoneNumber { get; private set; }
        public static string Role { get; private set; }

        // login mặc định là false nghĩa là người dùng chưa đăng nhập
        public static bool IsLoggedIn { get; private set; } = false;

        // Lưu thông tin khi đăng nhập
        public static void Login(int userId, string fullName, string phoneNumber, string role)
        {
            UserId = userId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Role = role;
            IsLoggedIn = true; // Đã đăng nhập
        }

        public static void Logout()
        {
            UserId = 0;
            FullName = null;
            PhoneNumber = null;
            Role = null;
            IsLoggedIn = false; // Đã đăng xuất
        }
    }
}