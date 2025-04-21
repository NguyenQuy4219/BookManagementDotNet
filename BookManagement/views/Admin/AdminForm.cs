using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookManagement.Data;

namespace BookManagement.views.Admin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.Load += AdminForm_Load;
            dgvStaffShow.SelectionChanged += dgvStaffShow_SelectionChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView
            dgvStaffShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaffShow.MultiSelect = false;
            dgvStaffShow.AutoGenerateColumns = false;

            // Thêm các cột vào DataGridView
            dgvStaffShow.Columns.Add("user_id", "User ID");
            dgvStaffShow.Columns.Add("full_name", "Full Name");
            dgvStaffShow.Columns.Add("phone_number", "Phone Number");
            dgvStaffShow.Columns.Add("address", "Address");
            dgvStaffShow.Columns.Add("gender", "Gender");
            dgvStaffShow.Columns.Add("personal_id", "Personal ID");
            dgvStaffShow.Columns.Add("role", "Role");
            dgvStaffShow.Columns.Add("created_at", "Created At");

            dgvStaffShow.Columns["user_id"].Visible = false; // Ẩn cột ID

            // Thêm giá trị vào ListBox vai trò
            lstbRole.Items.Add("admin");
            lstbRole.Items.Add("staff");

            LoadStaffData();
            SetColumnHeaders();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadStaffData(); // Nếu ô tìm kiếm trống, hiển thị toàn bộ dữ liệu
            }
            else
            {
                SearchStaff(keyword); // Tìm kiếm và hiển thị kết quả
            }
        }
        private void LoadStaffData()
        {
            dgvStaffShow.Rows.Clear();
            DataTable dt = DatabaseHelper.GetStaffData();
            foreach (DataRow row in dt.Rows)
            {
                dgvStaffShow.Rows.Add(
                    row["user_id"],
                    row["full_name"],
                    row["phone_number"],
                    row["address"],
                    row["gender"],
                    row["personal_id"],
                    row["role"],
                    row["created_at"]
                );
            }
        }

        private void dgvStaffShow_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStaffShow.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvStaffShow.SelectedRows[0];

                // Kiểm tra null trước khi truy xuất giá trị
                txtName.Text = row.Cells["full_name"].Value != null ? row.Cells["full_name"].Value.ToString() : "";
                txtPhone.Text = row.Cells["phone_number"].Value != null ? row.Cells["phone_number"].Value.ToString() : "";
                txtAddress.Text = row.Cells["address"].Value != null ? row.Cells["address"].Value.ToString() : "";
                txtPersonalID.Text = row.Cells["personal_id"].Value != null ? row.Cells["personal_id"].Value.ToString() : "";

                string gender = row.Cells["gender"].Value != null ? row.Cells["gender"].Value.ToString() : "";
                radMale.Checked = gender == "M";
                radFemale.Checked = gender == "F";
                radOther.Checked = gender == "O";

                lstbRole.SelectedItem = row.Cells["role"].Value != null ? row.Cells["role"].Value.ToString() : "";

                dtpCreateDate.Value = row.Cells["created_at"].Value != null
                    ? DateTime.Parse(row.Cells["created_at"].Value.ToString())
                    : DateTime.Now; // Nếu NULL, gán ngày hiện tại
            }
        }


        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            if (dgvStaffShow.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int user_id = Convert.ToInt32(dgvStaffShow.SelectedRows[0].Cells["user_id"].Value);
            string full_name = txtName.Text;
            string phone_number = txtPhone.Text;
            string address = txtAddress.Text;
            string personal_id = txtPersonalID.Text;
            string gender = radMale.Checked ? "M" : (radFemale.Checked ? "F" : "O");
            string role = lstbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(full_name) || string.IsNullOrEmpty(phone_number) || string.IsNullOrEmpty(personal_id))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = DatabaseHelper.UpdateStaff(user_id, full_name, phone_number, address, gender, personal_id, role);
            if (success)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvStaffShow.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int user_id = Convert.ToInt32(dgvStaffShow.SelectedRows[0].Cells["user_id"].Value);

            DialogResult confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool success = DatabaseHelper.DeleteStaff(user_id);

                    if (success)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaffData();
                        ClearStaffInfo();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void ClearStaffInfo()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPersonalID.Clear();
            radMale.Checked = false;
            radFemale.Checked = false;
            radOther.Checked = false;
            lstbRole.SelectedItem = null;
            dtpCreateDate.Value = DateTime.Now;
        }



        private void SearchStaff(string keyword)
        {
            dgvStaffShow.Rows.Clear();
            DataTable dt = DatabaseHelper.SearchStaff(keyword);
            foreach (DataRow row in dt.Rows)
            {
                dgvStaffShow.Rows.Add(
                    row["user_id"],
                    row["full_name"],
                    row["phone_number"],
                    row["address"],
                    row["gender"],
                    row["personal_id"],
                    row["role"],
                    row["created_at"]
                );
            }
        }
        private void SetColumnHeaders()
        {
            // Đổi tiêu đề cột cho dgvStaff
            dgvStaffShow.Columns["full_name"].HeaderText = "Họ tên";
            dgvStaffShow.Columns["phone_number"].HeaderText = "Số điện thoại";
            dgvStaffShow.Columns["address"].HeaderText = "Địa chỉ";
            dgvStaffShow.Columns["gender"].HeaderText = "Giới tính";
            dgvStaffShow.Columns["personal_id"].HeaderText = "CCCD";
            dgvStaffShow.Columns["role"].HeaderText = "Vai trò";
            dgvStaffShow.Columns["created_at"].HeaderText = "Ngày tạo";
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearStaffInfo();
        }

        private void dgvStaffShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}