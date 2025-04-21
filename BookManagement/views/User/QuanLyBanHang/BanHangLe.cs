using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagement.Data;
using BookManagement.Utils;

namespace BookManagement.views.User.QuanLyBanHang
{
    public partial class BanHangLe : Form
    {
        private int EnterCount = 0; // Biến đếm số lần nhấn ENTER
        private bool isDataChanged = false; // Cờ dữ liệu đã thay đổi?

        public BanHangLe()
        {
            InitializeComponent();
        }

        private void BanHangLe_Load(object sender, EventArgs e)
        {
            GenerateOrderID(); // Tạo mã đơn hàng mới khi mở form
            LoadProducts(""); // Load dữ liệu ngay khi mở form
            txt_order_date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Hiển thị ngày hiện tại
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text.Trim(); // Lấy nội dung ô tìm kiếm
            LoadProducts(keyword); // Gọi hàm tìm kiếm
        }

        private void LoadProducts(string keyword)
        {
            lvProducts.Items.Clear(); // Xóa dữ liệu cũ trong ListView

            string query = @"SELECT p.product_id, p.product_name, u.unit_name 
                     FROM Products p
                     JOIN Units u ON p.unit_id = u.unit_id
                     WHERE p.product_name LIKE @keyword";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["product_id"]); // Lấy product_id
                                string productName = reader["product_name"].ToString();
                                string unitName = reader["unit_name"].ToString();

                                // Tạo ListViewItem với product_name
                                ListViewItem item = new ListViewItem(productName);
                                item.SubItems.Add(unitName);

                                // Gán product_id vào Tag của ListViewItem
                                // tức là không cần tạo cột productId, chỉ cần lấy từ Tag
                                item.Tag = productId;

                                // Thêm vào ListView
                                lvProducts.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lvProducts_DoubleClick(object sender, EventArgs e)
        {
            InsertProductToOrder(); // Gọi hàm thêm sản phẩm vào dgvOrder
        }

        private void lvProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Nếu nhấn ENTER
            {
                EnterCount++; // Tăng biến đếm

                if (EnterCount == 2) // Nếu nhấn ENTER lần thứ hai
                {
                    InsertProductToOrder(); // Gọi hàm thêm sản phẩm vào dgvOrder
                    EnterCount = 0; // Reset bộ đếm
                }
            }
            else
            {
                EnterCount = 0; // Nếu nhấn phím khác, reset bộ đếm
            }
        }

        private void InsertProductToOrder()
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvProducts.SelectedItems[0];

                int productId = Convert.ToInt32(selectedItem.Tag); // Lấy product_id từ Tag

                string productName = selectedItem.SubItems[0].Text; // Cột 0 - Tên sản phẩm
                string unitName = selectedItem.SubItems[1].Text; // Cột 1 - Đơn vị tính
                                                                 
                // Truy vấn giá sản phẩm từ CSDL
                decimal price = GetProductPrice(productName);

                // Mặc định số lượng là 1
                int quantity = 1;
                decimal totalPrice = price * quantity;

                // Kiểm tra dữ liệu trước khi thêm vào DataGridView
                Console.WriteLine($"STT: {dgvOrder.Rows.Count + 1}, Sản phẩm: {productName}, Số lượng: {quantity}, Đơn vị: {unitName}, Giá: {price}, Thành tiền: {totalPrice}");

                // Thêm vào DataGridView với đúng thứ tự cột
                dgvOrder.Rows.Add(dgvOrder.Rows.Count + 1, productName, quantity, unitName, price, totalPrice, productId);

                // Cập nhật trạng thái thay đổi dữ liệu ngay khi thêm sản phẩm
                isDataChanged = true;

                // Cập nhật tổng tiền
                CalculateTotalPrice();

                // Cập nhật UI nếu cần
                dgvOrder.Refresh();
            }
        }

        private decimal GetProductPrice(string productName)
        {
            decimal price = 0;
            string query = "SELECT price FROM Products WHERE product_name = @productName";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productName", productName);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return price;
        }

        // Xử lý sự kiện khi chỉnh sửa ô số lượng trong DataGridView
        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉnh sửa cột "Số lượng"
            if (e.ColumnIndex == dgvOrder.Columns["quantity"].Index)
            {
                try
                {
                    // Lấy số lượng mới từ ô nhập
                    string input = dgvOrder.Rows[e.RowIndex].Cells["quantity"].Value?.ToString() ?? "1";

                    // Kiểm tra nếu nhập không phải số -> giữ nguyên giá trị cũ
                    if (!int.TryParse(input, out int newQuantity) || newQuantity < 1)
                    {
                        MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvOrder.Rows[e.RowIndex].Cells["quantity"].Value = 1; // Đặt lại 1 nếu nhập sai
                        return;
                    }

                    // Lấy giá sản phẩm
                    decimal price = Convert.ToDecimal(dgvOrder.Rows[e.RowIndex].Cells["price"].Value);

                    // Tính lại thành tiền
                    decimal totalPrice = newQuantity * price;

                    // Cập nhật lại ô "Thành tiền"
                    dgvOrder.Rows[e.RowIndex].Cells["total_price"].Value = totalPrice.ToString("N0"); // Hiển thị có dấu chấm

                    // Cập nhật tổng tiền
                    CalculateTotalPrice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật số lượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void GenerateOrderID()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd"); // Lấy ngày hiện tại (YYYYMMDD)
            int nextNumber = 1; // Mặc định số thứ tự nếu chưa có đơn nào trong ngày

            string query = "SELECT MAX(order_id) FROM Orders WHERE order_id LIKE @datePattern";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@datePattern", $"BH{datePart}_%");

                        object result = cmd.ExecuteScalar(); // Lấy giá trị lớn nhất

                        if (result != null && result != DBNull.Value)
                        {
                            // Tách số thứ tự từ chuỗi "BHYYYYMMDD_X"
                            string lastOrderID = result.ToString();
                            string[] parts = lastOrderID.Split('_');

                            if (parts.Length == 2 && int.TryParse(parts[1], out int lastNumber))
                            {
                                nextNumber = lastNumber + 1; // Tăng số thứ tự
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Tạo mã đơn hàng mới
            string newOrderID = $"BH{datePart}_{nextNumber}";

            // Gán vào ô txt_order_id
            txt_order_id.Text = newOrderID;
        }

        // Lưu thông tin dặt hàng
        private void SaveOrder()
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderId = txt_order_id.Text.Trim(); // Mã đơn hàng
            int userId = GetCurrentUserId(); // Lấy user_id từ session hoặc đăng nhập
            decimal totalPrice = CalculateTotalPrice(); // Tính tổng tiền đơn hàng
            DateTime orderDate = DateTime.Now; // Ngày hiện tại

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // **1. Lưu đơn hàng vào bảng Orders**
                        string insertOrderQuery = @"INSERT INTO Orders (order_id, user_id, total_price, order_date) 
                                            VALUES (@order_id, @user_id, @total_price, @order_date)";
                        using (SqlCommand cmd = new SqlCommand(insertOrderQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@order_id", orderId);
                            cmd.Parameters.AddWithValue("@user_id", userId);
                            cmd.Parameters.AddWithValue("@total_price", totalPrice);
                            cmd.Parameters.AddWithValue("@order_date", orderDate);
                            cmd.ExecuteNonQuery();
                        }

                        // **2. Lưu sản phẩm vào Order_Details (Gộp sản phẩm trùng)**
                        Dictionary<int, int> productQuantityMap = new Dictionary<int, int>(); // Lưu product_id và số lượng

                        foreach (DataGridViewRow row in dgvOrder.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                int productId = Convert.ToInt32(row.Cells["product_id"].Value);
                                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);

                                if (productQuantityMap.ContainsKey(productId))
                                {
                                    productQuantityMap[productId] += quantity; // Nếu đã có, cộng dồn số lượng
                                }
                                else
                                {
                                    productQuantityMap.Add(productId, quantity);
                                }
                            }
                        }

                        // **3. Thêm dữ liệu đã gộp vào Order_Details & trừ tồn kho**
                        foreach (var item in productQuantityMap)
                        {
                            int productId = item.Key;
                            int quantity = item.Value;

                            // Thêm vào Order_Details
                            string insertDetailQuery = @"INSERT INTO Order_Details (order_id, product_id, quantity, unit_price)
                                                 VALUES (@order_id, @product_id, @quantity, 
                                                         (SELECT price FROM Products WHERE product_id = @product_id))";

                            using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@order_id", orderId);
                                cmd.Parameters.AddWithValue("@product_id", productId);
                                cmd.Parameters.AddWithValue("@quantity", quantity);
                                cmd.ExecuteNonQuery();
                            }

                            // **Cập nhật số lượng tồn kho trong bảng Products**
                            string updateStockQuery = @"UPDATE Products 
                                                SET stock_quantity = stock_quantity - @quantity
                                                WHERE product_id = @product_id AND stock_quantity >= @quantity";

                            using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@product_id", productId);
                                cmd.Parameters.AddWithValue("@quantity", quantity);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    // 👉 Lấy tên sản phẩm để báo lỗi
                                    string productName = GetProductNameById(productId, conn, transaction);

                                    throw new Exception($"Sản phẩm {productName} không đủ số lượng trong kho.");
                                }
                            }
                        }

                        transaction.Commit(); // Lưu thay đổi vào CSDL

                        // Xóa DataGridView sau khi lưu
                        dgvOrder.Rows.Clear();
                        txt_total_price.Text = "0"; // Reset tổng tiền
                        GenerateOrderID(); // Tạo mã đơn hàng mới

                        // **Đặt lại trạng thái dữ liệu**
                        isDataChanged = false;

                        MessageBox.Show("Lưu đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Hoàn tác nếu có lỗi
                        MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string GetProductNameById(int productId, SqlConnection conn, SqlTransaction transaction)
        {
            string name = "Không xác định";

            string query = "SELECT product_name FROM Products WHERE product_id = @product_id";
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@product_id", productId);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    name = result.ToString();
                }
            }

            return name;
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

        // Tính tổng tiền từ DataGridView
        private decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (!row.IsNewRow)
                {
                    total += Convert.ToDecimal(row.Cells["total_price"].Value);
                }
            }

            // Hiển thị tổng tiền vào ô txt_total_price
            txt_total_price.Text = total.ToString("N0"); // Định dạng số có dấu chấm phân cách

            return total; // Trả về tổng tiền
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            SaveOrder();
        }

        // bấm Ctrl+S lưu đơn hàng
        private void BanHangLe_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn Ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "beep" mặc định
                SaveOrder(); // Gọi hàm lưu đơn hàng
            }
        }

        // Chỉnh font header của ListView
        private void lvProducts_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("Microsoft Sans Serif", 12.25f, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds); // Nền tiêu đề
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black, TextFormatFlags.Left);
            }
        }
        // Chỉnh font nội dung của ListView
        private void lvProducts_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true; // Giữ nguyên font mặc định cho nội dung
        }

        private void dgvOrder_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không bấm ngoài phạm vi
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvOrder.Rows.RemoveAt(e.RowIndex); // Xóa dòng được chọn
                    CalculateTotalPrice(); // Cập nhật tổng tiền

                    // Nếu không còn dòng nào, đặt lại cờ isDataChanged
                    if (dgvOrder.Rows.Count == 0)
                    {
                        isDataChanged = false;
                    }
                }
            }
        }


        // Vẽ nút Xóa trên cột đầu tiên của DataGridView
        private void dgvOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(dgvOrder.RowHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center; // Căn giữa theo chiều ngang
                format.LineAlignment = StringAlignment.Center; // Căn giữa theo chiều dọc

                Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvOrder.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString("Xóa", dgvOrder.Font, brush, headerBounds, format);
            }
        }

        // Khi thay đổi dữ liệu trong DataGridView cập nhật isDataChanged = true
        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                isDataChanged = false; // Nếu không còn dòng nào, không đánh dấu thay đổi
            }
            else
            {
                isDataChanged = true; // Nếu còn dòng, đánh dấu thay đổi
            }
        }

        public bool IsDirty()
        {
            return isDataChanged; // Trả về true nếu dữ liệu đã thay đổi
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ sản phẩm đã thêm?",
                "Xác nhận xóa toàn bộ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                dgvOrder.Rows.Clear(); // Xóa toàn bộ dòng
                txt_total_price.Text = "0"; // Reset tổng tiền
                isDataChanged = false; // Reset cờ thay đổi
            }
        }
    }
}
