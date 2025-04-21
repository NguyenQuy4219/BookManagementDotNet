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

namespace BookManagement.views.User.Danhmuc
{
    public partial class DanhMucDonViTinh : Form
    {

        private bool isEditing = false;  // Cờ đang ở chế độ Sửa?
        private bool isAdding = false;   // Cờ đang ở chế độ Thêm?
        private bool isDataChanged = false; // Cờ dữ liệu đã thay đổi?
        public DanhMucDonViTinh()
        {
            InitializeComponent();
        }

        private void DanhMucDonViTinh_Load(object sender, EventArgs e)
        {
            LoadUnits(); // Gọi hàm tải dữ liệu
            LoadCategories(); // Gọi hàm tải danh mục
        }

        private void LoadUnits()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    u.unit_id, 
                    u.unit_name, 
                    c.category_name, 
                    u.last_updated_at
                FROM Units u
                JOIN Categories c ON u.category_id = c.category_id";  // JOIN để lấy tên loại sản phẩm

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán dữ liệu vào DataGridView
                        dgvUnits.AutoGenerateColumns = false; // Không cho tự động tạo cột
                        dgvUnits.DataSource = dt;

                        // Định dạng ngày tháng
                        dgvUnits.Columns["lastUpdated"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đơn vị tính: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT category_id, category_name FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dt = GetCategories();
                if (dt.Rows.Count > 0)
                {
                    // Xóa item cũ
                    cbo_category.Items.Clear();

                    // Duyệt từng dòng để đưa vào ComboBox
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = Convert.ToInt32(row["category_id"]);
                        string name = row["category_name"].ToString();

                        var categoryItem = new KeyValuePair<int, string>(id, name);
                        cbo_category.Items.Add(categoryItem);
                    }

                    // Đặt thuộc tính hiển thị
                    cbo_category.DisplayMember = "Value";
                    cbo_category.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string getMaxIdQuery = "SELECT ISNULL(MAX(unit_id), 0) + 1 FROM Units";
                    using (SqlCommand getMaxCmd = new SqlCommand(getMaxIdQuery, conn))
                    {
                        int newUnitId = Convert.ToInt32(getMaxCmd.ExecuteScalar());
                        txt_unit_id.Text = newUnitId.ToString(); // Gán ID mới vào textbox
                    }
                }

                // Đánh dấu đang ở chế độ Thêm
                isAdding = true;
                isEditing = false;

                // Bật chế độ nhập liệu
                SetEditMode(true);
                btn_Luu.Enabled = true;
                btn_Them.Enabled = false; // Ẩn nút Thêm

                // Xóa dữ liệu cũ trong ô nhập
                txt_unit_name.Clear();
                cbo_category.SelectedIndex = -1;
                txt_unit_name.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã đơn vị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    int unitId = int.Parse(txt_unit_id.Text);
                    string unitName = txt_unit_name.Text.Trim();
                    int categoryId = ((KeyValuePair<int, string>)cbo_category.SelectedItem).Key;

                    if (isEditing)
                    {
                        if (!ConfirmUpdateIfUsed(conn, unitId))
                            return;

                        UpdateUnit(conn, unitId, unitName, categoryId);
                        UpdateProductsUnit(conn, unitId);

                        MessageBox.Show("Sửa đơn vị thành công và cập nhật tất cả sản phẩm liên quan!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (isAdding)
                    {
                        InsertUnit(conn, unitId, unitName, categoryId);

                        MessageBox.Show("Thêm đơn vị thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txt_unit_id.Text) ||
                string.IsNullOrWhiteSpace(txt_unit_name.Text) ||
                cbo_category.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập/chọn đầy đủ thông tin!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ConfirmUpdateIfUsed(SqlConnection conn, int unitId)
        {
            string checkQuery = "SELECT COUNT(*) FROM Products WHERE unit_id = @unit_id";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@unit_id", unitId);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        $"Đơn vị tính này đang được sử dụng trong {count} sản phẩm.\nBạn có muốn cập nhật không?",
                        "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    return result == DialogResult.Yes;
                }
            }
            return true;
        }

        private void UpdateUnit(SqlConnection conn, int unitId, string unitName, int categoryId)
        {
            string updateUnitQuery = @"
        UPDATE Units
        SET unit_name = @unit_name, 
            category_id = @category_id,
            last_updated_at = GETDATE()
        WHERE unit_id = @unit_id";

            using (SqlCommand updateCmd = new SqlCommand(updateUnitQuery, conn))
            {
                updateCmd.Parameters.AddWithValue("@unit_id", unitId);
                updateCmd.Parameters.AddWithValue("@unit_name", unitName);
                updateCmd.Parameters.AddWithValue("@category_id", categoryId);
                updateCmd.ExecuteNonQuery();
            }
        }

        private void UpdateProductsUnit(SqlConnection conn, int unitId)
        {
            string updateProductQuery = @"
        UPDATE Products
        SET unit_id = @unit_id
        WHERE unit_id = @unit_id";

            using (SqlCommand updateProductCmd = new SqlCommand(updateProductQuery, conn))
            {
                updateProductCmd.Parameters.AddWithValue("@unit_id", unitId);
                updateProductCmd.ExecuteNonQuery();
            }
        }

        private void InsertUnit(SqlConnection conn, int unitId, string unitName, int categoryId)
        {
            string insertQuery = @"
        INSERT INTO Units (unit_id, unit_name, category_id, last_updated_at)
        VALUES (@unit_id, @unit_name, @category_id, GETDATE())";

            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@unit_id", unitId);
                insertCmd.Parameters.AddWithValue("@unit_name", unitName);
                insertCmd.Parameters.AddWithValue("@category_id", categoryId);
                insertCmd.ExecuteNonQuery();
            }
        }

        private void ResetForm()
        {
            isEditing = false;
            isAdding = false;
            SetEditMode(false);
            ClearInputFields();
            LoadUnits();
        }





        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề
            {
                DataGridViewRow row = dgvUnits.Rows[e.RowIndex];

                txt_unit_id.Text = row.Cells["unit_id"].Value?.ToString() ?? "";
                txt_unit_name.Text = row.Cells["unit_name"].Value?.ToString() ?? "";

                // Gán giá trị category_name vào cbo_category
                if (row.Cells["category_name"].Value != null)
                {
                    string categoryName = row.Cells["category_name"].Value.ToString();

                    for (int i = 0; i < cbo_category.Items.Count; i++)
                    {
                        var item = (KeyValuePair<int, string>)cbo_category.Items[i];
                        if (item.Value == categoryName)
                        {
                            cbo_category.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // Ngay khi click vào dòng -> vô hiệu hóa các ô nhập
                SetEditMode(false);

                // Bật nút Xóa khi có dòng được chọn**
                btn_Xoa.Enabled = true;
            }
        }



        private void SetEditMode(bool canEdit)
        {
            txt_unit_name.Enabled = canEdit;
            cbo_category.Enabled = canEdit;

            btn_Luu.Enabled = canEdit;
            btn_Huy.Enabled = canEdit || !string.IsNullOrWhiteSpace(txt_unit_id.Text); 


            // Giữ nguyên nút "Thêm" luôn hoạt động
            btn_Them.Enabled = true;

            // Chỉ vô hiệu hóa nút Xóa nếu đang ở chế độ Thêm, còn lại luôn bật nếu có đơn vị được chọn
            btn_Xoa.Enabled = !isAdding && !string.IsNullOrWhiteSpace(txt_unit_id.Text);
        }



        
        private void ClearInputFields()
        {
            txt_unit_id.Text = "";
            txt_unit_name.Text = "";
            cbo_category.SelectedIndex = -1;
            txt_unit_name.Enabled = false;
            cbo_category.Enabled = false;
            btn_Xoa.Enabled = false;  // Vô hiệu hóa nút Xóa
        }

        
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_unit_id.Text))
            {
                MessageBox.Show("Bạn chưa chọn đơn vị để xóa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int unitId = int.Parse(txt_unit_id.Text);

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra xem đơn vị này có sản phẩm nào không
                    string checkQuery = "SELECT COUNT(*) FROM Products WHERE unit_id = @unit_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@unit_id", unitId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Không thể xóa! Đơn vị này đang được sử dụng trong sản phẩm.\nVui lòng cập nhật lại sản phẩm trước khi xóa.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Hỏi lại người dùng trước khi xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị này?",
                                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Tiến hành xóa đơn vị
                        string deleteQuery = "DELETE FROM Units WHERE unit_id = @unit_id";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@unit_id", unitId);
                            int rowsDeleted = deleteCmd.ExecuteNonQuery();

                            if (rowsDeleted > 0)
                            {
                                MessageBox.Show("Xóa đơn vị thành công!", "Thông báo",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUnits(); // Cập nhật lại danh sách đơn vị
                                ClearInputFields();
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn vị: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_unit_id.Text))
            {
                MessageBox.Show("Bạn chưa chọn đơn vị để sửa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bật chế độ sửa
            isEditing = true;
            isAdding = false;
            SetEditMode(true);

            // Không cho sửa Mã đơn vị (unit_id)
            txt_unit_id.Enabled = false;
            txt_unit_name.Focus();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            isEditing = false;
            isAdding = false;
            SetEditMode(false);
            ClearInputFields();
            btn_Them.Enabled = true;  // Cho phép nhấn "Thêm"
            btn_Luu.Enabled = false;  // Vô hiệu hóa "Lưu"
            isDataChanged = false;
        }

        private void txt_unit_id_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        // Kiểm tra xem dữ liệu đã thay đổi chưa
        public bool IsDirty()
        {
            return isDataChanged; // Trả về true nếu dữ liệu đã thay đổi
        }

        private void txt_unit_name_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void cbo_category_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }
    }
}
