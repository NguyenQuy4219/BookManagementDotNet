using BookManagement.Data;  // For DatabaseHelper
using BookManagement.Utils; // For UserSession
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace BookManagement.views.User
{
    public partial class DiemDanh : Form
    {
        public DiemDanh()
        {
            InitializeComponent();
            dtp_filterDate.Format = DateTimePickerFormat.Custom;
            dtp_filterDate.CustomFormat = "dd/MM/yyyy";
        }

        private void DiemDanh_Load(object sender, EventArgs e)
        {
            // Display user name and today's date
            lbl_nhanVien.Text = UserSession.FullName;
            lbl_ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_trangThai.Text = "Chưa điểm danh";

            // 1) Show ALL shifts (no filter) by default
            LoadDanhSachCaAll();
        }

        /// <summary>
        /// Loads ALL shifts assigned to the user, no date filter.
        /// </summary>
        private void LoadDanhSachCaAll()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            s.shift_id,
                            s.shift_name,
                            CONVERT(VARCHAR(10), ss.work_date, 103) AS work_date_str,
                            CONVERT(VARCHAR(5), s.start_time, 108) AS start_time_str,
                            CONVERT(VARCHAR(5), s.end_time, 108) AS end_time_str,
                            CONVERT(VARCHAR(16), a.checkin_time, 120) AS checkin_time_str,
                            a.status
                        FROM Shift_Schedule ss
                        JOIN Shifts s ON ss.shift_id = s.shift_id
                        LEFT JOIN Attendance a 
                               ON a.shift_id = ss.shift_id 
                              AND a.user_id = ss.user_id 
                              AND a.work_date = ss.work_date
                        WHERE ss.user_id = @userId
                        ORDER BY ss.work_date DESC, s.start_time";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserSession.UserId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            AdjustGridColumns(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shifts (all): " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads shifts assigned to the user, filtered by selectedDate.
        /// </summary>
        private void LoadDanhSachCaByDate(DateTime selectedDate)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Same query but with a date filter
                    string query = @"
                        SELECT 
                            s.shift_id,
                            s.shift_name,
                            CONVERT(VARCHAR(10), ss.work_date, 103) AS work_date_str,
                            CONVERT(VARCHAR(5), s.start_time, 108) AS start_time_str,
                            CONVERT(VARCHAR(5), s.end_time, 108) AS end_time_str,
                            CONVERT(VARCHAR(16), a.checkin_time, 120) AS checkin_time_str,
                            a.status
                        FROM Shift_Schedule ss
                        JOIN Shifts s ON ss.shift_id = s.shift_id
                        LEFT JOIN Attendance a 
                               ON a.shift_id = ss.shift_id 
                              AND a.user_id = ss.user_id 
                              AND a.work_date = ss.work_date
                        WHERE ss.user_id = @userId
                          AND ss.work_date = @FilterDate
                        ORDER BY ss.work_date DESC, s.start_time";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@FilterDate", selectedDate);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            AdjustGridColumns(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shifts (by date): " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Common method to adjust columns in the grid
        /// </summary>
        private void AdjustGridColumns(DataTable dt)
        {
            // We expect these columns:
            //   shift_id, shift_name, work_date_str, start_time_str, end_time_str, checkin_time_str, status

            // Rename columns to nicer Vietnamese headers
            // (Be sure to check dt.Columns.Count or use the known column aliases.)
            if (dt.Columns.Contains("shift_name")) dt.Columns["shift_name"].ColumnName = "Ca";
            if (dt.Columns.Contains("work_date_str")) dt.Columns["work_date_str"].ColumnName = "Ngày làm";
            if (dt.Columns.Contains("start_time_str")) dt.Columns["start_time_str"].ColumnName = "Giờ bắt đầu";
            if (dt.Columns.Contains("end_time_str")) dt.Columns["end_time_str"].ColumnName = "Giờ kết thúc";
            if (dt.Columns.Contains("checkin_time_str")) dt.Columns["checkin_time_str"].ColumnName = "Giờ điểm danh";

            dgv_danhSachCa.DataSource = dt;
            dgv_danhSachCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hide the shift_id column if present
            if (dgv_danhSachCa.Columns["shift_id"] != null)
                dgv_danhSachCa.Columns["shift_id"].Visible = false;

            // Optionally rename headers:
            if (dgv_danhSachCa.Columns["Ca"] != null)
                dgv_danhSachCa.Columns["Ca"].HeaderText = "Ca làm";
            // etc. for the other columns if needed
        }

        /// <summary>
        /// Button: Filter by date
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtp_filterDate.Value.Date;
            LoadDanhSachCaByDate(selectedDate);
        }

        /// <summary>
        /// Button: Clear Filter => show all again
        /// </summary>
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            LoadDanhSachCaAll();
        }

        /// <summary>
        /// Handles the Điểm danh button click.
        /// </summary>
        private void btn_diemDanh_Click(object sender, EventArgs e)
        {
            // Ensure a shift row is selected.
            if (dgv_danhSachCa.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm để điểm danh.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 1) Retrieve necessary values from the selected row
            int shiftId = Convert.ToInt32(dgv_danhSachCa.CurrentRow.Cells["shift_id"].Value);

            // Parse the date of this shift from the grid
            DateTime shiftDate;
            string rawDateString = dgv_danhSachCa.CurrentRow.Cells["Ngày làm"].Value?.ToString();

            // Attempt to parse "DD/MM/YYYY"
            bool success = DateTime.TryParseExact(
                rawDateString,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out shiftDate
            );

            if (!success)
            {
                MessageBox.Show("Không xác định được ngày của ca làm.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Parse shift start / end times
            string shiftStartStr = dgv_danhSachCa.CurrentRow.Cells["Giờ bắt đầu"].Value?.ToString();
            string shiftEndStr = dgv_danhSachCa.CurrentRow.Cells["Giờ kết thúc"].Value?.ToString();
            DateTime shiftStart, shiftEnd;

            if (!DateTime.TryParse(shiftStartStr, out shiftStart) ||
                !DateTime.TryParse(shiftEndStr, out shiftEnd))
            {
                MessageBox.Show("Không xác định được giờ của ca làm.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 2) Ensure the shift date is "today" if that's your requirement
            //    If you only want them to check in on the actual scheduled date:
            if (shiftDate.Date != DateTime.Today)
            {
                MessageBox.Show("Bạn chỉ có thể điểm danh vào đúng ngày làm việc.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // Combine the shift date with times
            // So if shift was on 26/03/2025, the start time is 08:00, we get 26/03/2025 08:00
            shiftStart = shiftDate.Date.Add(shiftStart.TimeOfDay);
            shiftEnd = shiftDate.Date.Add(shiftEnd.TimeOfDay);

            // 3) Check if the current time is past the shift end time.
            DateTime now = DateTime.Now;
            if (now > shiftEnd)
            {
                MessageBox.Show("Ca làm đã kết thúc, bạn không thể điểm danh.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // 4) Determine status = "Đi trễ" or "Có mặt"
            // Compare now with shiftStart
            string status = (now.TimeOfDay > shiftStart.TimeOfDay) ? "Đi trễ" : "Có mặt";

            // 5) Check if an Attendance record already exists for this user, shift, and SHIFT DATE
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // First, check if there's an existing attendance record for that exact shift date
                string checkQuery = @"
                    SELECT checkin_time
                    FROM Attendance
                    WHERE user_id = @userId
                      AND shift_id = @shiftId
                      AND work_date = @workDate";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@userId", UserSession.UserId);
                    checkCmd.Parameters.AddWithValue("@shiftId", shiftId);
                    checkCmd.Parameters.AddWithValue("@workDate", shiftDate.Date);

                    object result = checkCmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Means there's an existing record with a checkin_time
                        // If you want to allow updating, you can do it here.
                        // If you want to block repeated check-in, just show a message and return.
                        MessageBox.Show("Bạn đã điểm danh cho ca này rồi. Không thể điểm danh lại!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        // No record => Insert new attendance record
                        string insertQuery = @"
                            INSERT INTO Attendance
                            (
                                user_id, shift_id, work_date,
                                checkin_time, status,
                                created_at
                            )
                            VALUES
                            (
                                @userId, @shiftId, @workDate,
                                @checkinTime, @status,
                                GETDATE()
                            )";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@userId", UserSession.UserId);
                            insertCmd.Parameters.AddWithValue("@shiftId", shiftId);
                            insertCmd.Parameters.AddWithValue("@workDate", shiftDate.Date);
                            insertCmd.Parameters.AddWithValue("@checkinTime", now);
                            insertCmd.Parameters.AddWithValue("@status", status);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // 6) Notify success
            MessageBox.Show("Điểm danh thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // 7) Refresh the grid to reflect new attendance info
            //    (Either re-load everything or just call the filtered version if you want.)
            LoadDanhSachCaAll();

            // 8) Update label
            lbl_trangThai.Text = $"Bạn đã điểm danh: {status}";
        }

        private void dgv_danhSachCa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // not used currently
        }
    }
}
