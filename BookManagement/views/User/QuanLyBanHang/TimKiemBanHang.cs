using BookManagement.Data;
using BookManagement.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YourNamespace
{
    public partial class TimKiemBanHang : Form
    {
        public TimKiemBanHang()
        {
            InitializeComponent();
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";
            // Wire up DataGridView events
            dgvCategory.CellClick += dgvCategory_CellClick;
            dgvProduct.CellClick += dgvProduct_CellClick;
            dgvOrder.CellClick += dgvOrder_CellClick;

            // Wire up DateTimePicker events
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
        }

        private void TimKiemBanHang_Load(object sender, EventArgs e)
        {
            // Default date range
            //dtpFrom.Value = DateTime.Today.AddDays(-7);
            // Default date range
            //dtpFrom.Value = DateTime.Today.AddDays(-7); //  7 ngày trước hôm nay
            //dtpFrom.Value = new DateTime(2025, 1, 1); // Ngày bắt đầu từ đầu năm 2025
            DateTime now = DateTime.Today;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1); // ngày đầu tháng
            dtpTo.Value = DateTime.Today;

            // Load categories & products as usual
            LoadCategories();
            LoadProducts(-1);

            // Now load orders with no filter (null) for category/product
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            // categoryId = null, productId = null => all orders for the user
            LoadOrders(null, null, fromDate, toDate);
        }


        // ---------------------------------------------------------
        // 1) Load Categories
        // ---------------------------------------------------------
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT category_id, category_name FROM Categories";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCategory.DataSource = dt;

                        // Rename columns
                        if (dgvCategory.Columns["category_id"] != null)
                            dgvCategory.Columns["category_id"].Visible = false;
                        if (dgvCategory.Columns["category_name"] != null)
                            dgvCategory.Columns["category_name"].HeaderText = "Tên loại";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 2) When Category is selected -> Load Products
        // ---------------------------------------------------------
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // Bỏ qua nếu bấm vào header

            DataGridViewRow row = dgvCategory.Rows[e.RowIndex];

            // Kiểm tra giá trị category_id có tồn tại không
            if (row.Cells["category_id"].Value != null)
            {
                int categoryId = Convert.ToInt32(row.Cells["category_id"].Value);

                // Load sản phẩm thuộc loại đó
                LoadProducts(categoryId);

                // Load đơn hàng theo loại
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
                LoadOrders(categoryId, null, fromDate, toDate);
            }
        }



        // ---------------------------------------------------------
        // 3) Load Products (with optional category filter)
        // ---------------------------------------------------------
        private void LoadProducts(int categoryId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query;
                    if (categoryId <= 0)
                    {
                        // Load all products
                        query = @"SELECT product_id, product_name, price, stock_quantity
                                FROM Products
                                WHERE user_id = @UserId
                                ORDER BY product_name;
                                ";
                    }
                    else
                    {
                        // Load products for selected category
                        query = @"SELECT product_id, product_name, price, stock_quantity
                                  FROM Products
                                  WHERE category_id = @CategoryId
                                  ORDER BY product_name";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (categoryId <= 0)
                            cmd.Parameters.AddWithValue("@UserId", UserSession.UserId);
                        if (categoryId > 0)
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvProduct.DataSource = dt;

                            // Rename columns
                            if (dgvProduct.Columns["product_id"] != null)
                                dgvProduct.Columns["product_id"].Visible = false;
                            if (dgvProduct.Columns["product_name"] != null)
                                dgvProduct.Columns["product_name"].HeaderText = "Tên sản phẩm";
                            if (dgvProduct.Columns["price"] != null)
                                dgvProduct.Columns["price"].HeaderText = "Giá";
                            if (dgvProduct.Columns["stock_quantity"] != null)
                                dgvProduct.Columns["stock_quantity"].HeaderText = "Tồn kho";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 4) When Product is selected -> Load Orders
        // ---------------------------------------------------------
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                int productId = Convert.ToInt32(row.Cells["product_id"].Value);

                // Re-filter orders for that product
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // If you also had a category selected, you can store that somewhere
                // Or re-check if a category is selected in dgvCategory
                // But for simplicity:
                LoadOrders(null, productId, fromDate, toDate);
            }
        }


        // ---------------------------------------------------------
        // 5) Load Orders from the Orders table
        // ---------------------------------------------------------
        private void LoadOrders(int? categoryId, int? productId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Build a base query that ALWAYS filters by user and date range
                    string query = @"
                SELECT DISTINCT 
                       o.order_id,
                       o.order_date,
                       o.total_price,
                       u.full_name AS StaffName
                FROM Orders o
                JOIN Users u ON o.user_id = u.user_id
                JOIN Order_Details od ON o.order_id = od.order_id
                JOIN Products p ON od.product_id = p.product_id
                WHERE o.user_id = @UserId
                  AND o.order_date >= @FromDate
                  AND o.order_date <= @ToDate
            ";

                    // If categoryId is given, add a condition
                    if (categoryId.HasValue && categoryId.Value > 0)
                    {
                        query += " AND p.category_id = @CategoryId";
                    }

                    // If productId is given, add a condition
                    if (productId.HasValue && productId.Value > 0)
                    {
                        query += " AND od.product_id = @ProductId";
                    }

                    // Finally, sort by date
                    query += " ORDER BY o.order_date DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Required params
                        cmd.Parameters.AddWithValue("@UserId", UserSession.UserId);
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);

                        // Only add these if they’re not null
                        if (categoryId.HasValue && categoryId.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                        }
                        if (productId.HasValue && productId.Value > 0)
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId.Value);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvOrder.DataSource = dt;

                            // rename columns
                            if (dgvOrder.Columns["order_id"] != null)
                                dgvOrder.Columns["order_id"].HeaderText = "Mã hóa đơn";

                            if (dgvOrder.Columns["order_date"] != null)
                                dgvOrder.Columns["order_date"].HeaderText = "Ngày lập";

                            if (dgvOrder.Columns["total_price"] != null)
                                dgvOrder.Columns["total_price"].HeaderText = "Tổng tiền";

                            if (dgvOrder.Columns["StaffName"] != null)
                                dgvOrder.Columns["StaffName"].HeaderText = "Nhân viên lập đơn";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ---------------------------------------------------------
        // 6) When Order is selected -> Load Order Details
        // ---------------------------------------------------------
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return; // bỏ qua nếu click vào tiêu đề cột

            DataGridViewRow row = dgvOrder.Rows[e.RowIndex];

            if (row.Cells["order_id"].Value != null)
            {
                string orderId = row.Cells["order_id"].Value.ToString();
                LoadOrderDetail(orderId);
            }
        }


        private void LoadOrderDetail(string orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Show line items from Order_Details
                    // including product name, etc.
                    string query = @"
                        SELECT od.order_detail_id,
                               p.product_name,
                               od.quantity,
                               od.unit_price,
                               od.total_price
                        FROM Order_Details od
                        JOIN Products p ON od.product_id = p.product_id
                        WHERE od.order_id = @OrderId
                        ORDER BY p.product_name;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvOrderDetail.DataSource = dt;

                            // Rename columns & format
                            if (dgvOrderDetail.Columns["order_detail_id"] != null)
                                dgvOrderDetail.Columns["order_detail_id"].HeaderText = "Mã dòng đơn";

                            if (dgvOrderDetail.Columns["product_name"] != null)
                                dgvOrderDetail.Columns["product_name"].HeaderText = "Sản phẩm";

                            if (dgvOrderDetail.Columns["quantity"] != null)
                                dgvOrderDetail.Columns["quantity"].HeaderText = "Số lượng";

                            if (dgvOrderDetail.Columns["unit_price"] != null)
                                dgvOrderDetail.Columns["unit_price"].HeaderText = "Đơn giá";

                            if (dgvOrderDetail.Columns["total_price"] != null)
                                dgvOrderDetail.Columns["total_price"].HeaderText = "Thành tiền";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------
        // 7) Auto-Refresh when dtpFrom or dtpTo changes
        // ---------------------------------------------------------
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ReFilterOrders();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ReFilterOrders();
        }

        private void ReFilterOrders()
        {
            // If user has selected a category, store it
            int? categoryId = GetSelectedCategoryId(); // or null
            int? productId = GetSelectedProductId();  // or null

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            LoadOrders(categoryId, productId, fromDate, toDate);
        }


        // ---------------------------------------------------------
        // 8) A "Search" button for date filtering
        // ---------------------------------------------------------
        private void btn_Search_Click(object sender, EventArgs e)
        {
            ReFilterOrders();
        }

        private int? GetSelectedCategoryId()
        {
            // If there’s at least one selected row in dgvCategory...
            if (dgvCategory.SelectedRows.Count > 0)
            {
                var row = dgvCategory.SelectedRows[0];
                return Convert.ToInt32(row.Cells["category_id"].Value);
            }
            // If no selection, return null => means "no category filter"
            return null;
        }

        private int? GetSelectedProductId()
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                var row = dgvProduct.SelectedRows[0];
                return Convert.ToInt32(row.Cells["product_id"].Value);
            }
            return null;
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}