using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagement.Data;
using BookManagement.Utils;

namespace BookManagement.views.User.QuanLyBanHang
{
    public partial class ThongKeBanHang : Form
    {
        private int currentUserId = -1;
        public ThongKeBanHang()
        {
            InitializeComponent();
            currentUserId = GetCurrentUserId(); // Lấy user_id từ session hoặc đăng nhập
        }

        private int GetCurrentUserId()
        {
            if (UserSession.IsLoggedIn)
            {
                return UserSession.UserId; // Lấy UserId từ phiên đăng nhập
            }
            else
            {
                MessageBox.Show("Người dùng chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1; // Trả về -1 nếu chưa đăng nhập
            }
        }

        private void ThongKeBanHang_Load(object sender, EventArgs e)
        {
            // Gán giá trị mặc định: từ đầu tháng đến hôm nay
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if (currentUserId == -1)
                return;

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        o.order_id AS [Mã đơn],
                        p.product_name AS [Sản phẩm],
                        od.quantity AS [Số lượng],
                        CONVERT(DATE, o.order_date) AS [Ngày bán]
                    FROM Orders o
                    JOIN Order_Details od ON o.order_id = od.order_id
                    JOIN Products p ON od.product_id = p.product_id
                    WHERE o.user_id = @userId
                      AND o.order_date >= @tuNgay
                      AND o.order_date < DATEADD(DAY, 1, @denNgay)  -- bao gồm cả ngày kết thúc
                    ORDER BY o.order_date, o.order_id;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUserId);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvThongKe.DataSource = dt;

                // Đếm tổng đơn (duy nhất theo order_id)
                var totalOrders = new HashSet<string>();
                foreach (DataRow row in dt.Rows)
                {
                    totalOrders.Add(row["Mã đơn"].ToString());
                }
                lblTongDon.Text = $"Tổng số đơn hàng: {totalOrders.Count}";
            }
        }
    }
}
