namespace BookManagement.views.Admin.Danhmuc
{
    partial class DonViTinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_unit_name = new System.Windows.Forms.TextBox();
            this.txt_unit_id = new System.Windows.Forms.TextBox();
            this.cbo_category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.unit_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(635, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(439, 39);
            this.label8.TabIndex = 20;
            this.label8.Text = "DANH MỤC ĐƠN VỊ TÍNH";
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.LightGreen;
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(1166, 462);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(107, 39);
            this.btn_Them.TabIndex = 27;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.Location = new System.Drawing.Point(1431, 554);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(107, 39);
            this.btn_Huy.TabIndex = 35;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.Location = new System.Drawing.Point(1269, 554);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(107, 39);
            this.btn_Luu.TabIndex = 29;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.Tomato;
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(1543, 462);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Xoa.Size = new System.Drawing.Size(107, 39);
            this.btn_Xoa.TabIndex = 31;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.Yellow;
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Location = new System.Drawing.Point(1355, 462);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(107, 39);
            this.btn_Sua.TabIndex = 33;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1077, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tên đơn vị:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1077, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 28;
            this.label1.Text = "Mã đơn vị:";
            // 
            // txt_unit_name
            // 
            this.txt_unit_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_unit_name.Location = new System.Drawing.Point(1277, 274);
            this.txt_unit_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_unit_name.Name = "txt_unit_name";
            this.txt_unit_name.Size = new System.Drawing.Size(374, 34);
            this.txt_unit_name.TabIndex = 23;
            this.txt_unit_name.TextChanged += new System.EventHandler(this.txt_unit_name_TextChanged);
            // 
            // txt_unit_id
            // 
            this.txt_unit_id.BackColor = System.Drawing.Color.Pink;
            this.txt_unit_id.Enabled = false;
            this.txt_unit_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_unit_id.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txt_unit_id.Location = new System.Drawing.Point(1277, 206);
            this.txt_unit_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_unit_id.Name = "txt_unit_id";
            this.txt_unit_id.ReadOnly = true;
            this.txt_unit_id.Size = new System.Drawing.Size(157, 34);
            this.txt_unit_id.TabIndex = 22;
            this.txt_unit_id.TextChanged += new System.EventHandler(this.txt_unit_id_TextChanged);
            // 
            // cbo_category
            // 
            this.cbo_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_category.FormattingEnabled = true;
            this.cbo_category.Location = new System.Drawing.Point(1277, 342);
            this.cbo_category.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_category.Name = "cbo_category";
            this.cbo_category.Size = new System.Drawing.Size(374, 37);
            this.cbo_category.TabIndex = 36;
            this.cbo_category.TextChanged += new System.EventHandler(this.cbo_category_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1077, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 29);
            this.label3.TabIndex = 37;
            this.label3.Text = "Loại sản phẩm:";
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.unit_id,
            this.category_id,
            this.category_name,
            this.unit_name,
            this.lastUpdated});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnits.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUnits.Location = new System.Drawing.Point(60, 187);
            this.dgvUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.RowHeadersWidth = 62;
            this.dgvUnits.RowTemplate.Height = 28;
            this.dgvUnits.Size = new System.Drawing.Size(956, 380);
            this.dgvUnits.TabIndex = 38;
            this.dgvUnits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnits_CellClick);
            // 
            // unit_id
            // 
            this.unit_id.DataPropertyName = "unit_id";
            this.unit_id.FillWeight = 50F;
            this.unit_id.HeaderText = "Mã đơn vị";
            this.unit_id.MinimumWidth = 8;
            this.unit_id.Name = "unit_id";
            this.unit_id.ReadOnly = true;
            // 
            // category_id
            // 
            this.category_id.DataPropertyName = "category_id";
            this.category_id.HeaderText = "Mã loại";
            this.category_id.MinimumWidth = 8;
            this.category_id.Name = "category_id";
            this.category_id.ReadOnly = true;
            this.category_id.Visible = false;
            // 
            // category_name
            // 
            this.category_name.DataPropertyName = "category_name";
            this.category_name.HeaderText = "Tên loại sản phẩm";
            this.category_name.MinimumWidth = 8;
            this.category_name.Name = "category_name";
            this.category_name.ReadOnly = true;
            // 
            // unit_name
            // 
            this.unit_name.DataPropertyName = "unit_name";
            this.unit_name.FillWeight = 90F;
            this.unit_name.HeaderText = "Tên đơn vị";
            this.unit_name.MinimumWidth = 8;
            this.unit_name.Name = "unit_name";
            this.unit_name.ReadOnly = true;
            // 
            // lastUpdated
            // 
            this.lastUpdated.DataPropertyName = "last_updated_at";
            this.lastUpdated.HeaderText = "Cập nhật lần cuối";
            this.lastUpdated.MinimumWidth = 8;
            this.lastUpdated.Name = "lastUpdated";
            this.lastUpdated.ReadOnly = true;
            // 
            // DonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1691, 763);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.cbo_category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_unit_name);
            this.Controls.Add(this.txt_unit_id);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DonViTinh";
            this.Text = "Danh mục đơn vị tính";
            this.Load += new System.EventHandler(this.DonViTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_unit_name;
        private System.Windows.Forms.TextBox txt_unit_id;
        private System.Windows.Forms.ComboBox cbo_category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdated;
    }
}