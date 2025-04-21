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

namespace BookManagement.views.Admin
{
    public partial class reportScheduleForm : Form
    {
        public reportScheduleForm()
        {
            InitializeComponent();
        }

        private void reportScheduleForm_Load(object sender, EventArgs e)
        {
            // Thiết lập khoảng thời gian mặc định
            DateTime now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1); // ngày đầu tháng
            dtpDenNgay.Value = now; // hôm nay

            LoadNhanVienToComboBox();
            LoadTrangThaiToComboBox();
            LoadBaoCaoDiemDanh();
        }

        private void LoadNhanVienToComboBox()
        {
            string query = "SELECT user_id, full_name FROM Users WHERE role = 'staff'";
            DataTable dt = new DataTable();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            // Thêm dòng "Tất cả"
            DataRow row = dt.NewRow();
            row["user_id"] = 0; // 0 tượng trưng cho tất cả
            row["full_name"] = "Tất cả";
            dt.Rows.InsertAt(row, 0); // Thêm vào đầu

            // Gán vào ComboBox
            cbo_NhanVien.DataSource = dt;
            cbo_NhanVien.DisplayMember = "full_name";
            cbo_NhanVien.ValueMember = "user_id";

            // Mặc định chọn "Tất cả"
            cbo_NhanVien.SelectedIndex = 0;
        }

        private void LoadTrangThaiToComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("value", typeof(string));
            dt.Columns.Add("text", typeof(string));

            // Thêm dòng "Tất cả"
            dt.Rows.Add("", "Tất cả");

            // Thêm các trạng thái
            dt.Rows.Add("Có mặt", "Có mặt");
            dt.Rows.Add("Vắng", "Vắng");
            dt.Rows.Add("Trễ", "Trễ");
            dt.Rows.Add("Chưa điểm danh", "Chưa điểm danh");

            cbo_TrangThai.DataSource = dt;
            cbo_TrangThai.DisplayMember = "text";
            cbo_TrangThai.ValueMember = "value";
            cbo_TrangThai.SelectedIndex = 0;
        }

        private void LoadBaoCaoDiemDanh()
        {
            // Lấy giá trị từ bộ lọc
            int selectedUserId = Convert.ToInt32(cbo_NhanVien.SelectedValue);
            string selectedStatus = cbo_TrangThai.SelectedValue?.ToString();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            // Câu truy vấn SQL có điều kiện động
            string query = @"
        SELECT 
            A.attendance_id,
            U.full_name AS [Nhân viên],
            A.work_date AS [Ngày làm],
            A.checkin_time AS [Thời gian điểm danh],
            A.status AS [Trạng thái]
        FROM Attendance A
        INNER JOIN Users U ON A.user_id = U.user_id
        WHERE A.work_date BETWEEN @TuNgay AND @DenNgay
    ";

            if (selectedUserId != 0)
                query += " AND A.user_id = @UserId";

            if (!string.IsNullOrEmpty(selectedStatus))
                query += " AND A.status = @Status";

            // Đổ dữ liệu vào DataTable
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                if (selectedUserId != 0)
                    cmd.Parameters.AddWithValue("@UserId", selectedUserId);

                if (!string.IsNullOrEmpty(selectedStatus))
                    cmd.Parameters.AddWithValue("@Status", selectedStatus);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Gán vào DataGridView
            dgv_BaoCaoDiemDanh.DataSource = dt;

            // Ẩn cột attendance_id
            if (dgv_BaoCaoDiemDanh.Columns.Contains("attendance_id"))
            {
                dgv_BaoCaoDiemDanh.Columns["attendance_id"].Visible = false;
            }

            // Format bảng hiển thị
            dgv_BaoCaoDiemDanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BaoCaoDiemDanh.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgv_BaoCaoDiemDanh.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_BaoCaoDiemDanh.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Tính tổng số ca và hiển thị thống kê
            lblTongCa.Text = "Tổng ca: " + dt.Rows.Count.ToString();
            lblCoMat.Text = "Có mặt: " + dt.Select("[Trạng thái] = 'Có mặt'").Length.ToString();
            lblTre.Text = "Đi trễ: " + dt.Select("[Trạng thái] = 'Đi trễ'").Length.ToString();
            lblVang.Text = "Vắng: " + dt.Select("[Trạng thái] = 'Vắng'").Length.ToString();
            lblChuaDiemDanh.Text = "Chưa điểm danh: " + dt.Select("[Trạng thái] = 'Chưa điểm danh'").Length.ToString();
        }

        private void btn_XemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCaoDiemDanh();
        }

        private void dgv_BaoCaoDiemDanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
