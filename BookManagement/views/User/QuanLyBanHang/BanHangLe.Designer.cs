namespace BookManagement.views.User.QuanLyBanHang
{
    partial class BanHangLe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_order_id = new System.Windows.Forms.TextBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_detail_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_order_date = new System.Windows.Forms.TextBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.txt_total_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(684, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 39);
            this.label8.TabIndex = 20;
            this.label8.Text = "QUẢN LÝ BÁN LẺ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1108, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Chi tiết bán hàng";
            // 
            // txt_order_id
            // 
            this.txt_order_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_order_id.Location = new System.Drawing.Point(1257, 134);
            this.txt_order_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_order_id.Name = "txt_order_id";
            this.txt_order_id.ReadOnly = true;
            this.txt_order_id.Size = new System.Drawing.Size(332, 30);
            this.txt_order_id.TabIndex = 23;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.product_name,
            this.quantity,
            this.unit_name,
            this.price,
            this.total_price,
            this.product_id,
            this.order_detail_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrder.Location = new System.Drawing.Point(33, 338);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 62;
            this.dgvOrder.RowTemplate.Height = 28;
            this.dgvOrder.Size = new System.Drawing.Size(1608, 331);
            this.dgvOrder.TabIndex = 24;
            this.dgvOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellEndEdit);
            this.dgvOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellValueChanged);
            this.dgvOrder.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrder_RowHeaderMouseClick);
            this.dgvOrder.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrder_RowPostPaint);
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 8;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // product_name
            // 
            this.product_name.DataPropertyName = "product_name";
            this.product_name.HeaderText = "Tên sản phẩm";
            this.product_name.MinimumWidth = 8;
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Số lượng";
            this.quantity.MinimumWidth = 8;
            this.quantity.Name = "quantity";
            // 
            // unit_name
            // 
            this.unit_name.DataPropertyName = "unit_name";
            this.unit_name.HeaderText = "Đơn vị tính";
            this.unit_name.MinimumWidth = 8;
            this.unit_name.Name = "unit_name";
            this.unit_name.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Đơn giá";
            this.price.MinimumWidth = 8;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // total_price
            // 
            this.total_price.HeaderText = "Thành tiền";
            this.total_price.MinimumWidth = 8;
            this.total_price.Name = "total_price";
            this.total_price.ReadOnly = true;
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "Mã sản phẩm";
            this.product_id.MinimumWidth = 8;
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            this.product_id.Visible = false;
            // 
            // order_detail_id
            // 
            this.order_detail_id.DataPropertyName = "order_detail_id";
            this.order_detail_id.HeaderText = "Mã chi tiết sản phẩm";
            this.order_detail_id.MinimumWidth = 8;
            this.order_detail_id.Name = "order_detail_id";
            this.order_detail_id.ReadOnly = true;
            this.order_detail_id.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1108, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ngày bán:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tìm kiếm sản phẩm:";
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(283, 106);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(272, 30);
            this.txt_Search.TabIndex = 27;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // lvProducts
            // 
            this.lvProducts.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(283, 148);
            this.lvProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvProducts.MultiSelect = false;
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.OwnerDraw = true;
            this.lvProducts.Size = new System.Drawing.Size(456, 136);
            this.lvProducts.TabIndex = 28;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvProducts_DrawColumnHeader);
            this.lvProducts.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvProducts_DrawItem);
            this.lvProducts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvProducts_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sản phẩm";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Đơn vị tính";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // txt_order_date
            // 
            this.txt_order_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_order_date.Location = new System.Drawing.Point(1257, 186);
            this.txt_order_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_order_date.Name = "txt_order_date";
            this.txt_order_date.ReadOnly = true;
            this.txt_order_date.Size = new System.Drawing.Size(332, 30);
            this.txt_order_date.TabIndex = 29;
            // 
            // btn_Luu
            // 
            this.btn_Luu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.ForeColor = System.Drawing.Color.Crimson;
            this.btn_Luu.Location = new System.Drawing.Point(196, 686);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(199, 39);
            this.btn_Luu.TabIndex = 30;
            this.btn_Luu.Text = "Lưu (Ctrl + S)";
            this.btn_Luu.UseVisualStyleBackColor = false;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // txt_total_price
            // 
            this.txt_total_price.BackColor = System.Drawing.SystemColors.Info;
            this.txt_total_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total_price.ForeColor = System.Drawing.Color.Red;
            this.txt_total_price.Location = new System.Drawing.Point(1114, 691);
            this.txt_total_price.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_total_price.Name = "txt_total_price";
            this.txt_total_price.Size = new System.Drawing.Size(332, 34);
            this.txt_total_price.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(964, 693);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 29);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tổng tiền:";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_Xoa.Location = new System.Drawing.Point(482, 686);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(270, 39);
            this.btn_Xoa.TabIndex = 33;
            this.btn_Xoa.Text = "Làm trống danh sách";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // BanHangLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1691, 763);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.txt_total_price);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.txt_order_date);
            this.Controls.Add(this.lvProducts);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.txt_order_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BanHangLe";
            this.Text = "BanHangLe";
            this.Load += new System.EventHandler(this.BanHangLe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BanHangLe_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_order_id;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.TextBox txt_order_date;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txt_total_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_detail_id;
        private System.Windows.Forms.Button btn_Xoa;
    }
}