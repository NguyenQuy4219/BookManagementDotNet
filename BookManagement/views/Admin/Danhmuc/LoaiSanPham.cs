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

namespace BookManagement.views.Admin.Danhmuc
{
    public partial class LoaiSanPham: Form
    {
        public LoaiSanPham()
        {
            InitializeComponent();
            // Disable editing by default.
            txt_category_name.Enabled = false;
            // Optionally, ensure the txt_category_id is disabled.
            txt_category_id.Enabled = false;
        }

        private void LoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private bool isNew = false;   // true when user clicks "Thêm"
        private bool isEdit = false;  // true when user clicks "Sửa"
        private bool isDataChanged = false; // Cờ dữ liệu đã thay đổi?


        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT category_id, category_name, last_updated_at FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCategory.AutoGenerateColumns = false;

                        // Map manually created columns to the DataTable fields.
                        dgvCategory.Columns["category_id"].DataPropertyName = "category_id";
                        dgvCategory.Columns["category_name"].DataPropertyName = "category_name";
                        dgvCategory.Columns["last_updated_at"].DataPropertyName = "last_updated_at";

                        dgvCategory.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];

                txt_category_id.Text = row.Cells["category_id"].Value.ToString();
                txt_category_name.Text = row.Cells["category_name"].Value.ToString();
                txt_lastUpdatedAt.Text = row.Cells["last_updated_at"].Value.ToString();

                // Disable editing when a row is simply selected.
                txt_category_name.Enabled = false;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            isNew = true;
            isEdit = false;

            // Clear fields for new entry.
            int nextId = GetNextCategoryId();
            txt_category_id.Text = nextId.ToString();
            txt_category_name.Text = "";
            txt_lastUpdatedAt.Text = "";

            // Enable editing for adding a new category.
            txt_category_name.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_category_id.Text))
            {
                MessageBox.Show("Vui lòng chọn một thể loại để sửa.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isNew = false;
            isEdit = true;
            // Enable editing of the category name.
            txt_category_name.Enabled = true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                InsertCategory();
            }
            else if (isEdit)
            {
                UpdateCategory();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn Thêm hoặc Sửa.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable editing after saving.
            txt_category_name.Enabled = false;

            // Refresh the grid.
            LoadCategories();
        }

        private void InsertCategory()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1) Get the current max ID (or 0 if table is empty)
                    int newId = 1;
                    string maxIdQuery = "SELECT ISNULL(MAX(category_id), 0) FROM Categories";
                    using (SqlCommand maxCmd = new SqlCommand(maxIdQuery, conn))
                    {
                        object result = maxCmd.ExecuteScalar();
                        newId = Convert.ToInt32(result) + 1;
                    }

                    // 2) Insert using the new ID.
                    string insertQuery = @"
                        INSERT INTO Categories (category_id, category_name, last_updated_at)
                        VALUES (@Id, @Name,GETDATE())";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Id", newId);
                        insertCmd.Parameters.AddWithValue("@Name", txt_category_name.Text.Trim());
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm thể loại thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thể loại: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCategory()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                                    UPDATE Categories
                                    SET category_name = @Name,
                                        last_updated_at = GETDATE()
                                    WHERE category_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", txt_category_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txt_category_name.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Sửa thể loại thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thể loại: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextCategoryId()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT ISNULL(MAX(category_id), 0) FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int currentMax = Convert.ToInt32(cmd.ExecuteScalar());
                        return currentMax + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy ID mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_category_id.Text))
            {
                MessageBox.Show("Vui lòng chọn thể loại để xóa.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa thể loại này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                DeleteCategory();
                LoadCategories();
            }
        }

        private void DeleteCategory()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Categories WHERE category_id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", txt_category_id.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa thể loại thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thể loại: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            isNew = false;
            isEdit = false;

            // Clear fields or revert to previously selected row.
            txt_category_id.Text = "";
            txt_category_name.Text = "";
            txt_lastUpdatedAt.Text = "";

            // Disable editing.
            txt_category_name.Enabled = false;
            isDataChanged = false;
        }

        private void txt_category_name_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void txt_category_id_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        // Kiểm tra xem dữ liệu đã thay đổi chưa
        public bool IsDirty()
        {
            return isDataChanged; // Trả về true nếu dữ liệu đã thay đổi
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
