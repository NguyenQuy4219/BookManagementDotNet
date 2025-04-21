using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookManagement.Helper
{
    public class SecurityHelper
    {
        // Tạo hàm HashPassword để mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create()) // Tạo đối tượng SHA-256
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password); // Chuyển mật khẩu thành mảng byte
                byte[] hash = sha256.ComputeHash(bytes); // Tính toán giá trị băm
                return BitConverter.ToString(hash).Replace("-", "").ToLower(); // Chuyển đổi hash thành chuỗi hex
            }
        }

        // Kiểm tra mật khẩu có hợp lệ không (ít nhất 4 ký tự, không được để trống)
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 4;
        }

        // Kiểm tra số điện thoại có đúng định dạng không (bắt đầu bằng 0, tổng cộng 10 chữ số)
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$"); // Regex kiểm tra số điện thoại hợp lệ
        }

        // Kiểm tra số CCCD có hợp lệ không (chỉ chứa 12 chữ số)
        public static bool IsValidCCCD(string personalID)
        {
            return Regex.IsMatch(personalID, @"^\d{12}$"); // Regex kiểm tra số CCCD hợp lệ
        }
    }
}
