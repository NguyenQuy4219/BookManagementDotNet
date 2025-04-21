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
    public partial class reportRevenue : Form
    {
        public reportRevenue()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            DataSet reportData = DatabaseHelper.GetReportData(startDate, endDate);

            dgvStaff.DataSource = reportData.Tables["Staff"];
            dgvSalesDetails.DataSource = reportData.Tables["Sales"];

            // Debugging: Show the count of returned rows
            int staffCount = reportData.Tables["Staff"]?.Rows.Count ?? 0;
            int salesCount = reportData.Tables["Sales"]?.Rows.Count ?? 0;

            if (staffCount == 0 && salesCount == 0)
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian đã chọn.");
                txtTotal.Text = "0";
                return;
            }

            // Refresh DataGridViews
            dgvStaff.ClearSelection();
            dgvSalesDetails.ClearSelection();
            dgvStaff.CurrentCell = null;
            dgvSalesDetails.CurrentCell = null;

            // Calculate total revenue
            decimal totalRevenue = 0;

            // Ensure "Sales" table exists and has rows before summing
            if (reportData.Tables["Sales"] != null && reportData.Tables["Sales"].Rows.Count > 0)
            {
                totalRevenue = reportData.Tables["Sales"].AsEnumerable()
                    .Sum(row => row.Field<decimal>("total_price"));
            }

            txtTotal.Text = totalRevenue.ToString("N0"); // Format number
        }

        private void LoadAllStaffSales()
        {
            DataSet data = DatabaseHelper.GetAllStaffSales();

            dgvStaff.DataSource = data.Tables["StaffSales"];
            dgvSalesDetails.DataSource = data.Tables["SalesDetails"];


            // Refresh DataGridViews
            dgvStaff.ClearSelection();
            dgvSalesDetails.ClearSelection();
            dgvStaff.CurrentCell = null;
            dgvSalesDetails.CurrentCell = null;


            // Ensure there is data before calculating total
            decimal totalRevenue = 0;
            if (data.Tables["SalesDetails"] != null && data.Tables["SalesDetails"].Rows.Count > 0)
            {
                totalRevenue = data.Tables["SalesDetails"].AsEnumerable()
                    .Sum(row => row.Field<decimal>("total_price"));
            }

            txtTotal.Text = totalRevenue.ToString("N0"); // Format total revenue
        }
        private void SetColumnHeaders()
        {  
            // Đổi tiêu đề cột cho dgvStaff
            dgvStaff.Columns["user_id"].HeaderText = "Mã nhân viên";
            dgvStaff.Columns["full_name"].HeaderText = "Họ và tên";
            dgvStaff.Columns["phone_number"].HeaderText = "Số điện thoại";


            // Đổi tiêu đề cột cho dgvSalesDetails
            dgvSalesDetails.Columns["order_id"].HeaderText = "Mã đơn hàng";
            dgvSalesDetails.Columns["order_date"].HeaderText = "Ngày đặt hàng";
            dgvSalesDetails.Columns["staff_name"].HeaderText = "Nhân viên";
            dgvSalesDetails.Columns["total_price"].HeaderText = "Tổng tiền";

            dgvStaff.Columns["user_id"].Visible = false; // Ẩn cột ID

            if (dgvOrderDetail.DataSource != null)
            {
                if (dgvOrderDetail.Columns.Contains("product_id"))
                    dgvOrderDetail.Columns["product_id"].HeaderText = "Mã sản phẩm";

                if (dgvOrderDetail.Columns.Contains("product_name"))
                    dgvOrderDetail.Columns["product_name"].HeaderText = "Tên sản phẩm";

                if (dgvOrderDetail.Columns.Contains("quantity"))
                    dgvOrderDetail.Columns["quantity"].HeaderText = "Số lượng";

                if (dgvOrderDetail.Columns.Contains("unit_price"))
                    dgvOrderDetail.Columns["unit_price"].HeaderText = "Số lượng";

                if (dgvOrderDetail.Columns.Contains("total_cost"))
                    dgvOrderDetail.Columns["total_cost"].HeaderText = "Thành tiền";
            }

        }

        
        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {

            LoadAllStaffSales();
            SetColumnHeaders(); // Đặt lại tiêu đề cột

        }

        private void Ngày_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvSalesDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                string orderId = dgvSalesDetails.Rows[e.RowIndex].Cells["order_id"].Value.ToString();
                LoadOrderDetails(orderId);
            }
        }

        private void LoadOrderDetails(string orderId)
        {
            DataTable orderDetails = DatabaseHelper.GetOrderDetails(orderId);

            dgvOrderDetail.DataSource = orderDetails;

            dgvOrderDetail.Refresh();
            SetColumnHeaders();
        }



        // Lấy danh sách sản phẩm trong đơn hàng

        private int lastSelectedRowIndex = -1; // Track last selected row

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (lastSelectedRowIndex == e.RowIndex)
                {
                    // If the same row is clicked again, deselect it and load all sales
                    dgvStaff.ClearSelection();
                    dgvStaff.CurrentCell = null;
                    lastSelectedRowIndex = -1; // Reset selection

                    LoadAllStaffSales(); // Load all sales when deselected
                }
                else
                {
                    // Store new selection
                    lastSelectedRowIndex = e.RowIndex;

                    // Get selected staff name
                    string selectedStaffName = dgvStaff.Rows[e.RowIndex].Cells["full_name"].Value.ToString();

                    if (dgvSalesDetails.DataSource != null)
                    {
                        DataView dv;
                        if (dgvSalesDetails.DataSource is DataTable)
                        {
                            dv = new DataView((DataTable)dgvSalesDetails.DataSource);
                        }
                        else
                        {
                            dv = (DataView)dgvSalesDetails.DataSource;
                        }

                        // Apply filter based on staff_name
                        dv.RowFilter = $"staff_name = '{selectedStaffName}'";
                        dgvSalesDetails.DataSource = dv;

                        // Calculate total revenue
                        decimal totalRevenue = dv.ToTable().AsEnumerable()
                            .Sum(row => row.Field<decimal>("total_price"));

                        txtTotal.Text = totalRevenue.ToString("N0"); // Format number
                    }
                }
            }
        }
    }
}

