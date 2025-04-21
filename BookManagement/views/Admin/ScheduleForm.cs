using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookManagement.Data;

namespace BookManagement
{
    public partial class ScheduleForm : Form
    {
        
        private int selectedScheduleId = -1;

        public ScheduleForm()
        {
            InitializeComponent();
            LoadUsers();
            LoadShifts();
            LoadSchedules();
            dgvSchedule.CellClick += dgvSchedule_CellClick;
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT user_id, full_name FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbUserId.DataSource = dt;
                cmbUserId.DisplayMember = "full_name";
                cmbUserId.ValueMember = "user_id";
            }
        }

        private void LoadShifts()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT shift_id, shift_name FROM Shifts";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbShiftId.DataSource = dt;
                cmbShiftId.DisplayMember = "shift_name";
                cmbShiftId.ValueMember = "shift_id";
            }
        }

        private void LoadSchedules()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    SELECT ss.schedule_id, u.full_name, s.shift_name, ss.work_date 
                    FROM Shift_Schedule ss
                    JOIN Users u ON ss.user_id = u.user_id
                    JOIN Shifts s ON ss.shift_id = s.shift_id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Tắt tự động co giãn
                dgvSchedule.DataSource = dt;
                dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                SetColumnHeaders();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbUserId.SelectedValue == null || cmbShiftId.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và ca làm việc!");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Shift_Schedule (user_id, shift_id, work_date) VALUES (@UserId, @ShiftId, @WorkDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", cmbUserId.SelectedValue);
                cmd.Parameters.AddWithValue("@ShiftId", cmbShiftId.SelectedValue);
                cmd.Parameters.AddWithValue("@WorkDate", dtpSchedule.Value.Date);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadSchedules();
                MessageBox.Show("Thêm lịch làm việc thành công!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedScheduleId == -1)
            {
                MessageBox.Show("Vui lòng chọn lịch làm việc để sửa!");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Shift_Schedule SET user_id = @UserId, shift_id = @ShiftId, work_date = @WorkDate WHERE schedule_id = @ScheduleId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", cmbUserId.SelectedValue);
                cmd.Parameters.AddWithValue("@ShiftId", cmbShiftId.SelectedValue);
                cmd.Parameters.AddWithValue("@WorkDate", dtpSchedule.Value.Date);
                cmd.Parameters.AddWithValue("@ScheduleId", selectedScheduleId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadSchedules();
                MessageBox.Show("Cập nhật lịch làm việc thành công!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedScheduleId == -1)
            {
                MessageBox.Show("Vui lòng chọn lịch làm việc để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lịch làm việc này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Shift_Schedule WHERE schedule_id = @ScheduleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ScheduleId", selectedScheduleId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    LoadSchedules();
                    MessageBox.Show("Xóa lịch làm việc thành công!");
                    selectedScheduleId = -1;
                }
            }
        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];

                    selectedScheduleId = row.Cells["schedule_id"].Value != DBNull.Value
                        ? Convert.ToInt32(row.Cells["schedule_id"].Value)
                        : 0;

                    cmbUserId.SelectedValue = row.Cells["full_name"].Value != DBNull.Value
                        ? GetUserIdByName(row.Cells["full_name"].Value.ToString())
                        : -1;

                    cmbShiftId.SelectedValue = row.Cells["shift_name"].Value != DBNull.Value
                        ? GetShiftIdByName(row.Cells["shift_name"].Value.ToString())
                        : -1;

                    dtpSchedule.Value = row.Cells["work_date"].Value != DBNull.Value
                        ? Convert.ToDateTime(row.Cells["work_date"].Value)
                        : DateTime.Now;
                }
            }));
        }



        private int GetUserIdByName(string fullName)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT user_id FROM Users WHERE full_name = @FullName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private int GetShiftIdByName(string shiftName)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT shift_id FROM Shifts WHERE shift_name = @ShiftName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShiftName", shiftName);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        private void SetColumnHeaders()
        {
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // Đổi tiêu đề cột cho dgvStaff
            dgvSchedule.Columns["schedule_id"].HeaderText = "Mã lịch làm việc";
            dgvSchedule.Columns["full_name"].HeaderText = "Họ và tên";
            dgvSchedule.Columns["shift_name"].HeaderText = "Tên ca";
            dgvSchedule.Columns["work_date"].HeaderText = "Ngày làm việc";

            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            LoadSchedules();  // Gọi đúng phương thức
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
