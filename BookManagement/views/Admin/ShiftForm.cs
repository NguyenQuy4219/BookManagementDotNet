using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookManagement.Data;

namespace BookManagement
{
    public partial class ShiftForm : Form
    {
        private int selectedShiftId = -1;

        public ShiftForm()
        {
            InitializeComponent();
            dgvShift.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShift.MultiSelect = false;
            dgvShift.SelectionChanged += dgvShift_SelectionChanged;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            LoadShifts();
            SetColumnHeaders();
        }

        private void LoadShifts()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Shifts", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShift.DataSource = dt;
            }
        }

        private void SetColumnHeaders()
        {
            if (dgvShift.Columns.Count > 0)
            {
                dgvShift.Columns["shift_id"].HeaderText = "Mã ca làm";
                dgvShift.Columns["shift_name"].HeaderText = "Tên ca";
                dgvShift.Columns["start_time"].HeaderText = "Thời gian bắt đầu";
                dgvShift.Columns["end_time"].HeaderText = "Thời gian kết thúc";
                dgvShift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvShift_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShift.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvShift.SelectedRows[0];

            if (row.Cells["shift_id"].Value == DBNull.Value) return;
            if (row.Cells["start_time"].Value == DBNull.Value || row.Cells["end_time"].Value == DBNull.Value) return;

            selectedShiftId = Convert.ToInt32(row.Cells["shift_id"].Value);
            txtShiftName.Text = row.Cells["shift_name"].Value.ToString();
            dtpShiftStart.Value = DateTime.Today.Add((TimeSpan)row.Cells["start_time"].Value);
            dtpShiftEnd.Value = DateTime.Today.Add((TimeSpan)row.Cells["end_time"].Value);
        }

        private void btnShiftAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShiftName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ca làm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Shifts (shift_name, start_time, end_time) VALUES (@name, @start, @end)", conn);
                cmd.Parameters.AddWithValue("@name", txtShiftName.Text);
                cmd.Parameters.AddWithValue("@start", dtpShiftStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@end", dtpShiftEnd.Value.TimeOfDay);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể thêm ca làm. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadShifts();
        }


        private void btnShiftUpdate_Click(object sender, EventArgs e)
        {
            if (selectedShiftId == -1)
            {
                MessageBox.Show("Vui lòng chọn một ca làm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtShiftName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên ca làm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn cập nhật ca làm này?",
                                                   "Xác nhận",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Shifts SET shift_name=@name, start_time=@start, end_time=@end WHERE shift_id=@id", conn);
                cmd.Parameters.AddWithValue("@name", txtShiftName.Text);
                cmd.Parameters.AddWithValue("@start", dtpShiftStart.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@end", dtpShiftEnd.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@id", selectedShiftId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật ca làm. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadShifts();
        }


        private void btnShiftDelete_Click(object sender, EventArgs e)
        {
            if (selectedShiftId == -1)
            {
                MessageBox.Show("Vui lòng chọn một ca để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa ca làm này?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Shifts WHERE shift_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedShiftId);
                    cmd.ExecuteNonQuery();
                }
                LoadShifts();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchShifts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchShifts();
        }

        private void SearchShifts()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Shifts WHERE shift_name LIKE @search", conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShift.DataSource = dt;
            }
        }

        private void btnShiftLoad_Click(object sender, EventArgs e)
        {
            txtShiftName.Clear();
            dtpShiftStart.Value = DateTime.Now;
            dtpShiftEnd.Value = DateTime.Now;
            selectedShiftId = -1; // Đặt lại ID ca làm để tránh cập nhật nhầm

            MessageBox.Show("Form đã được đặt lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
