using BookManagement.Helper; // <-- Adjust namespace if needed
using BookManagement.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement.Data
{
    // Make this class public so other parts of the app can call it
    public class DatabaseHelper
    {
        // Kết nối database
        // Update with your own server or instance name
        //private static string connectionString = "Server=DESKTOP-PFOUT99\\SQLEXPRESS01;" +
        //    "Database=BookManagement_db;Integrated Security=True;";
        //private static string connectionString = "Server=DESKTOP-ASO531B;" +
        //    "Database=BookManagement_db;Integrated Security=True;";
        private static string connectionString = "Server=localhost;" +
    "Database=BookManagement_db;Integrated Security=True;";


        // Creates and returns a new SqlConnection using the project’s connection string
        // Hàm lấy kết nối
        public static SqlConnection GetConnection()
        {
            // Tạo đối tượng SqlConnection mới sử dụng chuỗi kết nối connectionString
            return new SqlConnection(connectionString);
        }

        // ----------------------------------------------------------------
        // 1) Insert a new user (Registration)
        // ----------------------------------------------------------------
        public static bool InsertUser(string fullName, string phoneNumber, string password,
                                      string address, string gender, string personalID)
        {
            try
            {
                // conn nhận giá trị là đối tượng SqlConnection mới
                using (SqlConnection conn = GetConnection())
                {
                    // mở kết nối đến Sql server
                    conn.Open();

                    // Hash the password before storing
                    // gọi hàm HashPassword từ SecurityHelper để mã hóa mật khẩu
                    string hashedPassword = SecurityHelper.HashPassword(password);

                    // Insert statement
                    string query = @"INSERT INTO Users (full_name, phone_number, password, address, gender, personal_id, role)
                                     VALUES (@fullName, @phoneNumber, @password, @address, @gender, @personalID, 'staff')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@personalID", personalID);

                        // Thực thi INSERT, trả về true nếu thêm thành công, false nếu thất bại 
                        // Sử dụng ở form đăng kí xem có đăng kí thành công không để hiển thị messagebox
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while registering: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ----------------------------------------------------------------
        // 2) Validate user login by comparing hashed passwords
        // ----------------------------------------------------------------
        public static bool ValidateLogin(string phoneNumber, string password)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id, full_name, role, password FROM Users WHERE phone_number = @phone";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phoneNumber);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if a user with this phone number exists
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader["password"].ToString();
                                string hashedPassword = SecurityHelper.HashPassword(password);

                                // So sánh hashpass được lưu trong csdl và hashpass được nhập vào
                                if (storedHashedPassword == hashedPassword)
                                {
                                    // Store user session after successful login
                                    UserSession.Login(
                                        Convert.ToInt32(reader["user_id"]),
                                        reader["full_name"].ToString(),
                                        phoneNumber, // Use the phone number from the parameter nên không cần reader
                                        reader["role"].ToString()
                                    );
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false; // Login failed
        }



        // ----------------------------------------------------------------
        // 3) Change password (requires old password to match)
        // ----------------------------------------------------------------
        public static bool ChangePassword(string phoneNumber, string oldPassword, string newPassword)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // 1) Get the stored hashed password for this phone number
                    string query = @"SELECT password
                                     FROM Users
                                     WHERE phone_number = @phone";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phoneNumber);

                        // ExecuteScalar luôn trả về object để có thể chứa bất kì kiểu dữ liệu nào
                        object result = cmd.ExecuteScalar();

                        // If no user found for this phone number
                        if (result == null)
                        {
                            MessageBox.Show("Số điện thoại không tồn tại.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        // 2) Compare old password hashes
                        string storedHashedPassword = result.ToString();
                        string hashedOldPassword = SecurityHelper.HashPassword(oldPassword);

                        if (storedHashedPassword != hashedOldPassword)
                        {
                            MessageBox.Show("Mật khẩu cũ không đúng.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // 3) If old password is correct, update to the new password
                    string hashedNewPassword = SecurityHelper.HashPassword(newPassword);
                    string updateQuery = @"UPDATE Users
                                           SET password = @newPassword
                                           WHERE phone_number = @phone";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@phone", phoneNumber);
                        updateCmd.Parameters.AddWithValue("@newPassword", hashedNewPassword);

                        // > 0 kiểm tra xem câu lệnh đã update thành công hay chưa
                        return updateCmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ----------------------------------------------------------------
        // 4) (Optional) Reset password without old password (Forgot Password)
        //    If you need it, add it here:
        // ----------------------------------------------------------------
        // public static bool ResetPassword(string phoneNumber, string newPassword)
        // {
        //     // Example logic:
        //     // 1) Check if phoneNumber exists
        //     // 2) Update the password to newPassword (hashed)
        // }

        // ----------------------------------------------------------------
        // 5) Test the database connection
        // ----------------------------------------------------------------
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Database Connection Successful!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable GetStaffData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id, full_name, phone_number, address, gender, personal_id, role, created_at FROM Users";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching staff data: " + ex.Message);
            }
            return dt;
        }

        public static bool UpdateStaff(int user_id, string full_name, string phone_number, string address, string gender, string personal_id, string role)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"
                 UPDATE Users 
                 SET full_name = @full_name, 
                     phone_number = @phone_number, 
                     address = @address, 
                     gender = @gender, 
                     personal_id = @personal_id, 
                     role = @role 
                 WHERE user_id = @user_id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@full_name", full_name);
                    cmd.Parameters.AddWithValue("@phone_number", phone_number);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@personal_id", personal_id);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@user_id", user_id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating staff: " + ex.Message);
            }
            return false;
        }

        public static bool DeleteStaff(int user_id)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // Kiểm tra vai trò của nhân viên trước khi xóa
                    string checkRoleQuery = "SELECT role FROM Users WHERE user_id = @user_id";
                    SqlCommand checkRoleCmd = new SqlCommand(checkRoleQuery, conn);
                    checkRoleCmd.Parameters.AddWithValue("@user_id", user_id);
                    string role = checkRoleCmd.ExecuteScalar()?.ToString();

                    // Nếu vai trò là "admin", không cho phép xóa
                    if (role == "admin")
                    {
                        throw new InvalidOperationException("Không thể xóa nhân viên có vai trò admin.");
                    }

                    // Nếu không phải admin, tiến hành xóa
                    string deleteQuery = "DELETE FROM Users WHERE user_id = @user_id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@user_id", user_id);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex) when (ex.Message.Contains("REFERENCE constraint"))
            {
                throw new InvalidOperationException("Không thể xóa nhân viên này vì đang có đơn hàng liên quan.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        public static DataTable SearchStaff(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"
                 SELECT user_id, full_name, phone_number, address, gender, personal_id, role, created_at 
                 FROM Users 
                 WHERE full_name LIKE @keyword 
                    OR phone_number LIKE @keyword 
                    OR personal_id LIKE @keyword";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public static DataSet GetAllStaffSales()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // Query to get staff with total sales
                    string staffSalesQuery = @"
                SELECT 
                    u.user_id, 
                    u.full_name, 
                    u.phone_number, 
                    u.role 
                FROM Users u
                LEFT JOIN Orders o ON u.user_id = o.user_id
                WHERE u.role = 'staff' 
                GROUP BY u.user_id, u.full_name, u.phone_number, u.role
                ORDER BY u.user_id ASC"; // Highest sales first

                    // Query to get all sales details
                    string salesDetailsQuery = @"
                SELECT 
                    o.order_id, 
                    o.order_date, 
                    o.total_price, 
                    u.full_name AS staff_name
                FROM Orders o
                INNER JOIN Users u ON o.user_id = u.user_id
                WHERE u.role = 'staff'
                ORDER BY o.order_date DESC"; // Recent sales first

                    using (SqlCommand staffCmd = new SqlCommand(staffSalesQuery, conn))
                    using (SqlCommand salesCmd = new SqlCommand(salesDetailsQuery, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            // Load staff with total sales
                            da.SelectCommand = staffCmd;
                            da.Fill(ds, "StaffSales");

                            // Load all sales details
                            da.SelectCommand = salesCmd;
                            da.Fill(ds, "SalesDetails");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu bán hàng: " + ex.Message);
            }
            return ds;
        }

        public static DataSet GetReportData(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // Ensure full-day coverage for date range
                    DateTime startDateTime = startDate.Date;
                    DateTime endDateTime = endDate.Date.AddDays(1).AddSeconds(-1);

                    string staffQuery = @"
                        SELECT DISTINCT u.user_id, u.full_name, u.phone_number, u.role
                        FROM Users u
                        INNER JOIN Orders o ON u.user_id = o.user_id
                        WHERE o.order_date BETWEEN @startDate AND @endDate";

                    string salesQuery = @"
                        SELECT o.order_id, o.order_date, o.total_price, u.full_name AS staff_name
                        FROM Orders o
                        INNER JOIN Users u ON o.user_id = u.user_id
                        WHERE o.order_date BETWEEN @startDate AND @endDate";


                    using (SqlCommand staffCmd = new SqlCommand(staffQuery, conn))
                    using (SqlCommand salesCmd = new SqlCommand(salesQuery, conn))
                    {
                        // Add parameters to prevent SQL injection
                        staffCmd.Parameters.AddWithValue("@startDate", startDateTime);
                        staffCmd.Parameters.AddWithValue("@endDate", endDateTime);

                        salesCmd.Parameters.AddWithValue("@startDate", startDateTime);
                        salesCmd.Parameters.AddWithValue("@endDate", endDateTime);

                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            // Load staff data
                            da.SelectCommand = staffCmd;
                            da.Fill(ds, "Staff");

                            // Load sales data
                            da.SelectCommand = salesCmd;
                            da.Fill(ds, "Sales");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu báo cáo: " + ex.Message + "\n" + ex.StackTrace);
            }
            return ds;
        }
        public static DataTable GetOrderDetails(string orderId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            p.product_id, 
                            p.product_name, 
                            od.quantity,
				  od.unit_price,
                            (od.quantity * od.unit_price) AS total_cost
                        FROM Order_Details od
                        INNER JOIN Products p ON od.product_id = p.product_id
                        WHERE od.order_id = @orderId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}