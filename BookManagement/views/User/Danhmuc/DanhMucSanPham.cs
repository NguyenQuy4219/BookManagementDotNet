using BookManagement.Data;
using BookManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookManagement.views
{
    public partial class DanhMucSanPham : Form
    {
        private int currentUserId = -1;
        private bool isEditing = false;  // Cờ đang ở chế độ Sửa?
        private bool isAdding = false;   // Cờ đang ở chế độ Thêm?
        private bool isDataChanged = false; // Cờ dữ liệu đã thay đổi?
        public DanhMucSanPham()
        {
            InitializeComponent();
            currentUserId = GetCurrentUserId(); // Lấy user_id từ session hoặc đăng nhập
            LoadCategories();      // Nạp danh mục vào ComboBox
            LoadProductData();     // Nạp danh sách sản phẩm vào DataGridView  
        }

        // Lấy thông tin người dùng từ session đăng nhập
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

        //=====================================================
        // 1) NẠP DANH MỤC (Categories)
        //=====================================================
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

                    // Thêm mục "Tất cả"
                    cbx_TheLoai.Items.Add(new KeyValuePair<int, string>(-1, "Tất cả"));

                    // Duyệt từng dòng để đưa vào ComboBox
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = Convert.ToInt32(row["category_id"]);
                        string name = row["category_name"].ToString();

                        var categoryItem = new KeyValuePair<int, string>(id, name);
                        cbo_category.Items.Add(categoryItem);
                        cbx_TheLoai.Items.Add(categoryItem);
                    }

                    // Đặt thuộc tính hiển thị
                    cbo_category.DisplayMember = "Value";
                    cbo_category.ValueMember = "Key";
                    cbx_TheLoai.DisplayMember = "Value";
                    cbx_TheLoai.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chỉ nạp Units đã gắn với Category
        private void LoadUnitsByCategory(int categoryId)
        {
            try
            {
                DataTable dtUnits = new DataTable();
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Lấy trực tiếp unit từ Units
                    string query = @"
                SELECT unit_id, unit_name
                FROM Units
                WHERE category_id = @CategoryId
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtUnits);
                        }
                    }
                }

                // Nếu không có đơn vị nào => thêm 1 dòng "Không có đơn vị"
                if (dtUnits.Rows.Count == 0)
                {
                    dtUnits.Rows.Add(-1, "");
                }

                cbo_unit.DataSource = dtUnits;
                cbo_unit.DisplayMember = "unit_name";
                cbo_unit.ValueMember = "unit_id";
                cbo_unit.SelectedIndex = -1;  // chưa chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc đơn vị tính: " + ex.Message);
            }
        }


        // Khi thay đổi category trong ComboBox => lọc lại đơn vị tính
        private void cbo_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1) Nếu chưa chọn => xóa đơn vị
            if (cbo_category.SelectedIndex == -1)
            {
                cbo_unit.DataSource = null;
                cbo_unit.Items.Clear();
                cbo_unit.SelectedIndex = -1;
                return;
            }

            // 2) Lấy category_id
            int selectedCategoryId = ((KeyValuePair<int, string>)cbo_category.SelectedItem).Key;

            // 3) Nếu = -1 => cũng xóa đơn vị
            if (selectedCategoryId == -1)
            {
                cbo_unit.DataSource = null;
                cbo_unit.Items.Clear();
                cbo_unit.SelectedIndex = -1;
            }
            else
            {
                // 4) Gọi LoadUnitsByCategory() -> nạp đơn vị
                LoadUnitsByCategory(selectedCategoryId);
            }
        }


        //=====================================================
        // 3) NẠP DỮ LIỆU SẢN PHẨM LÊN DGV
        //=====================================================
        private void LoadProductData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.product_id     AS ProductId,
                            p.product_name   AS ProductName,
                            p.price          AS Price,
                            p.stock_quantity AS StockQuantity,
                            p.category_id    AS CatId,
                            c.category_name  AS CategoryName,
                            p.unit_id        AS UnitId,
                            u.unit_name      AS UnitName
                        FROM Products p
                        JOIN Categories c ON p.category_id = c.category_id
                        JOIN Units u      ON p.unit_id = u.unit_id
                        ORDER BY p.product_id ASC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Ngăn DataGridView tự thêm cột
                        dgvProducts.AutoGenerateColumns = false;
                        dgvProducts.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        //private void LoadProductData()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = DatabaseHelper.GetConnection())
        //        {
        //            conn.Open();
        //            string query = @"
        //                            SELECT 
        //                                p.product_id     AS ProductId,
        //                                p.product_name   AS ProductName,
        //                                p.price          AS Price,
        //                                p.stock_quantity AS StockQuantity,
        //                                p.category_id    AS CatId,
        //                                c.category_name  AS CategoryName
        //                            FROM Products p
        //                            JOIN Categories c ON p.category_id = c.category_id
        //                        ";

        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);

        //                dgvProducts.DataSource = dt;
        //                dgvProducts.Columns["CatId"].Visible = false;

        //                // Đổi tiêu đề cột
        //                dgvProducts.Columns["ProductId"].HeaderText = "Mã sản phẩm";
        //                dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
        //                dgvProducts.Columns["CategoryName"].HeaderText = "Loại sản phẩm";
        //                dgvProducts.Columns["Price"].HeaderText = "Giá tiền";
        //                dgvProducts.Columns["StockQuantity"].HeaderText = "Tồn kho";

        //                // Sắp xếp thứ tự cột bằng DisplayIndex
        //                dgvProducts.Columns["ProductId"].DisplayIndex = 0;
        //                dgvProducts.Columns["ProductName"].DisplayIndex = 1;
        //                dgvProducts.Columns["CategoryName"].DisplayIndex = 2;
        //                dgvProducts.Columns["Price"].DisplayIndex = 3;
        //                dgvProducts.Columns["StockQuantity"].DisplayIndex = 4;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //=====================================================
        // 4) CHỈNH CHẾ ĐỘ CHO PHÉP SỬA HAY KHÔNG
        //=====================================================
        private void SetEditMode(bool canEdit)
        {
           
            txt_product_id.Enabled = false; // Không cho sửa ID dù đang Thêm


            // Các ô khác
            txt_product_name.Enabled = canEdit;
            txt_price.Enabled = canEdit;
            txt_stock_quantity.Enabled = canEdit;
            cbo_category.Enabled = canEdit;
            cbo_unit.Enabled = canEdit;
        }

        //=====================================================
        // 5) FORM LOAD
        //=====================================================
        private void DanhMucSach_Load(object sender, EventArgs e)
        {
            // Vừa mở form => ở chế độ xem
            SetEditMode(false);
        }

        //=====================================================
        // 6) CLICK CHỌN DÒNG TRÊN DGV
        //=====================================================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu đang ở chế độ Thêm, hỏi người dùng hủy chế độ Thêm
            if (isAdding)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn đang ở chế độ Thêm. Muốn chọn sản phẩm, cần hủy chế độ Thêm.\n" +
                    "Bạn có muốn hủy chế độ Thêm không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    isAdding = false;
                    SetEditMode(false);
                    ClearInputFields();
                }
                return;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                // Lấy dữ liệu từ dòng
                txt_product_id.Text = row.Cells["ProductId"].Value?.ToString() ?? "";
                txt_product_name.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                txt_price.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txt_stock_quantity.Text = row.Cells["StockQuantity"].Value?.ToString() ?? "";

                // Gán Category
                string selectedCategoryName = row.Cells["CategoryName"].Value?.ToString() ?? "";
                for (int i = 0; i < cbo_category.Items.Count; i++)
                {
                    var item = (KeyValuePair<int, string>)cbo_category.Items[i];
                    if (item.Value == selectedCategoryName)
                    {
                        cbo_category.SelectedIndex = i;
                        break;
                    }
                }

                // Gán Unit
                object unitIdObj = row.Cells["UnitId"].Value;
                if (unitIdObj != null)
                {
                    int unitId = Convert.ToInt32(unitIdObj);
                    cbo_unit.SelectedValue = unitId;
                }
                else
                {
                    cbo_unit.SelectedIndex = -1;
                }

                // Chuyển về chế độ xem
                isEditing = false;
                isAdding = false;
                SetEditMode(false); // Vô hiệu hóa các ô nhập

                // Cập nhật trạng thái nút:
                // Vô hiệu hóa nút "Lưu"
                btn_Luu.Enabled = false;
                
                // Bật nút "Sửa" và "Xóa"
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
                // Đảm bảo nút "Thêm" luôn bật
                btn_Them.Enabled = true;
            }
        }


        //=====================================================
        // 7) NÚT THÊM
        //=====================================================
        private void btn_Them_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu user chưa đăng nhập (phòng ngừa)
            if (currentUserId == -1)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isEditing = false;
            isAdding = true;
            SetEditMode(true); // Bật chế độ nhập

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Lấy ID lớn nhất +1
                    string getNewIdQuery = "SELECT ISNULL(MAX(product_id), 0) + 1 FROM Products";
                    using (SqlCommand cmd = new SqlCommand(getNewIdQuery, conn))
                    {
                        int newProductId = Convert.ToInt32(cmd.ExecuteScalar());
                        txt_product_id.Text = newProductId.ToString(); // Hiển thị ID mới
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reset dữ liệu nhập
            txt_product_name.Text = "";
            cbo_category.SelectedIndex = -1;
            cbo_unit.SelectedIndex = -1;
            txt_price.Text = "";
            txt_stock_quantity.Text = "";

            // Bật ô nhập nhưng KHÔNG bật nút "Lưu" ngay
            txt_product_name.Enabled = true;
            cbo_category.Enabled = true;
            cbo_unit.Enabled = true;
            txt_price.Enabled = true;
            txt_stock_quantity.Enabled = true;

            btn_Them.Enabled = false; // Ẩn "Thêm"
            txt_product_name.Focus();
        }



        // Hàm xóa trắng input
        private void ClearInputFields()
        {
            txt_product_id.Text = "";
            txt_product_name.Text = "";
            cbo_category.SelectedIndex = -1;
            cbo_unit.SelectedIndex = -1;
            txt_price.Text = "";
            txt_stock_quantity.Text = "";
        }

        //=====================================================
        // 8) NÚT SỬA
        //=====================================================
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_product_id.Text))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để sửa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Bật chế độ sửa
            isEditing = true;
            isAdding = false;

            // Cho phép chỉnh sửa các ô nhập, đồng thời bật nút "Lưu" và "Hủy"
            SetEditMode(true);
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;

            // Không cho phép sửa mã sản phẩm (nếu muốn)
            txt_product_id.Enabled = false;

            // Đưa con trỏ vào ô tên sản phẩm
            txt_product_name.Focus();
        }


        //=====================================================
        // 9) NÚT LƯU
        //=====================================================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txt_product_id.Text) ||
                string.IsNullOrWhiteSpace(txt_product_name.Text) ||
                cbo_category.SelectedItem == null ||
                cbo_unit.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txt_price.Text) ||
                string.IsNullOrWhiteSpace(txt_stock_quantity.Text))
            {
                MessageBox.Show("Vui lòng nhập/chọn đủ các thông tin!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra user_id đã đăng nhập
            if (currentUserId == -1)
            {
                MessageBox.Show("Không xác định được người dùng. Vui lòng đăng nhập lại!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Lấy dữ liệu nhập
                    int productId = int.Parse(txt_product_id.Text);
                    string productName = txt_product_name.Text.Trim();
                    int categoryId = ((KeyValuePair<int, string>)cbo_category.SelectedItem).Key;
                    int unitId = Convert.ToInt32(cbo_unit.SelectedValue);
                    decimal price = decimal.Parse(txt_price.Text);
                    int stockQty = int.Parse(txt_stock_quantity.Text);

                    // Kiểm tra sản phẩm đã tồn tại chưa
                    bool productExists = false;
                    string checkQuery = "SELECT COUNT(*) FROM Products WHERE product_id = @product_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@product_id", productId);
                        int count = (int)checkCmd.ExecuteScalar();
                        productExists = (count > 0);
                    }

                    if (isAdding)
                    {
                        // THÊM
                        if (productExists)
                        {
                            MessageBox.Show("Đã có sản phẩm với mã này. Hãy chọn mã khác hoặc bấm Sửa!",
                                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string insertQuery = @"
                    INSERT INTO Products (product_id, product_name, category_id, user_id, unit_id, price, stock_quantity)
                    VALUES (@product_id, @product_name, @category_id, @user_id, @unit_id, @price, @stock_quantity);
                ";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@product_id", productId);
                            insertCmd.Parameters.AddWithValue("@product_name", productName);
                            insertCmd.Parameters.AddWithValue("@category_id", categoryId);
                            insertCmd.Parameters.AddWithValue("@user_id", currentUserId);
                            insertCmd.Parameters.AddWithValue("@unit_id", unitId);
                            insertCmd.Parameters.AddWithValue("@price", price);
                            insertCmd.Parameters.AddWithValue("@stock_quantity", stockQty);

                            int rowsInserted = insertCmd.ExecuteNonQuery();
                            if (rowsInserted > 0)
                            {
                                MessageBox.Show("Thêm sản phẩm thành công!",
                                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Thêm sản phẩm thất bại!",
                                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (isEditing)
                    {
                        // SỬA
                        if (!productExists)
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm để sửa! Hãy kiểm tra mã sản phẩm.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string updateQuery = @"
                    UPDATE Products
                    SET product_name   = @product_name,
                        category_id    = @category_id,
                        user_id        = @user_id,
                        unit_id        = @unit_id,
                        price          = @price,
                        stock_quantity = @stock_quantity
                    WHERE product_id   = @product_id;
                ";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@product_id", productId);
                            updateCmd.Parameters.AddWithValue("@product_name", productName);
                            updateCmd.Parameters.AddWithValue("@category_id", categoryId);
                            updateCmd.Parameters.AddWithValue("@user_id", currentUserId);
                            updateCmd.Parameters.AddWithValue("@unit_id", unitId);
                            updateCmd.Parameters.AddWithValue("@price", price);
                            updateCmd.Parameters.AddWithValue("@stock_quantity", stockQty);

                            int rowsUpdated = updateCmd.ExecuteNonQuery();
                            if (rowsUpdated > 0)
                            {
                                MessageBox.Show("Sửa sản phẩm thành công!",
                                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Sửa sản phẩm thất bại!",
                                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn Thêm hoặc Sửa!",
                                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Sau khi Thêm/Sửa xong:
                    isEditing = false;
                    isAdding = false;
                    SetEditMode(false);
                    ClearInputFields();
                    LoadProductData();

                    // Bật lại nút Thêm sau khi lưu xong
                    btn_Them.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //=====================================================
        // 10) NÚT XÓA
        //=====================================================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_product_id.Text))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = int.Parse(txt_product_id.Text);

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Kiểm tra sản phẩm có tồn tại trong đơn hàng không
                    string checkUsageQuery = "SELECT COUNT(*) FROM Order_Details WHERE product_id = @product_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkUsageQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@product_id", productId);
                        int usageCount = (int)checkCmd.ExecuteScalar();

                        if (usageCount > 0)
                        {
                            MessageBox.Show("Không thể xóa sản phẩm này vì đã tồn tại trong đơn hàng!",
                                            "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Nếu chưa được dùng => hỏi xác nhận và xóa
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc muốn xóa sản phẩm này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM Products WHERE product_id = @product_id";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@product_id", productId);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa sản phẩm thành công!",
                                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearInputFields();
                                LoadProductData();
                            }
                            else
                            {
                                MessageBox.Show("Xóa sản phẩm thất bại!",
                                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //=====================================================
        // 11) NÚT HỦY
        //=====================================================
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            // Hủy
            isEditing = false;
            isAdding = false;
            SetEditMode(false);
            ClearInputFields();
            isDataChanged = false;
        }

        //=====================================================
        // 12) TÌM KIẾM THEO TÊN SẢN PHẨM
        //=====================================================
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.product_id     AS ProductId,
                            p.product_name   AS ProductName,
                            p.price          AS Price,
                            p.stock_quantity AS StockQuantity,
                            c.category_name  AS CategoryName,
                            p.unit_id        AS UnitId
                        FROM Products p
                        JOIN Categories c ON p.category_id = c.category_id
                        WHERE p.product_name LIKE @ProductName
                        ORDER BY p.product_id DESC;
                    ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName",
                            "%" + txt_Search.Text.Trim() + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dgvProducts.DataSource = dt;
                            }
                            else
                            {
                                dgvProducts.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //=====================================================
        // 13) LỌC THEO THỂ LOẠI
        //=====================================================
        private void cbx_TheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu không chọn gì hoặc chọn lại ô trống => Hiển thị tất cả sản phẩm
            if (cbx_TheLoai.SelectedIndex == -1 || ((KeyValuePair<int, string>)cbx_TheLoai.SelectedItem).Key == -1)
            {
                LoadProductData(); // Hiển thị lại toàn bộ sản phẩm
                return;
            }

            try
            {
                int selectedCategoryId = ((KeyValuePair<int, string>)cbx_TheLoai.SelectedItem).Key;
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.product_id     AS ProductId,
                    p.product_name   AS ProductName,
                    p.price          AS Price,
                    p.stock_quantity AS StockQuantity,
                    c.category_name  AS CategoryName,
                    p.unit_id        AS UnitId
                FROM Products p
                JOIN Categories c ON p.category_id = c.category_id
                WHERE p.category_id = @CategoryId
                ORDER BY p.product_id ASC;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", selectedCategoryId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvProducts.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //=====================================================
        // Các handler trống khác (nếu có)
        //=====================================================
        private void txt_product_id_TextChanged(object sender, EventArgs e) {
            isDataChanged = true;
        }
        private void txt_product_name_TextChanged(object sender, EventArgs e) { }
        private void txt_price_TextChanged(object sender, EventArgs e) {
            isDataChanged = true;
        }
        private void txt_stock_quantity_TextChanged(object sender, EventArgs e) {
            isDataChanged = true;
        }

        private void txt_category_SelectedIndexChanged(object sender, EventArgs e) {
            isDataChanged = true;
        }

        // Kiểm tra dữ liệu thay đổi
        private void cbo_unit_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        private void cbo_category_TextChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
        }

        public bool IsDirty()
        {
            return isDataChanged; // Trả về true nếu dữ liệu đã thay đổi
        }
    }
}
