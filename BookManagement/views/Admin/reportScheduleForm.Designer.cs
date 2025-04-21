namespace BookManagement.views.Admin
{
    partial class reportScheduleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_NhanVien = new System.Windows.Forms.ComboBox();
            this.dgv_BaoCaoDiemDanh = new System.Windows.Forms.DataGridView();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_XemBaoCao = new System.Windows.Forms.Button();
            this.lblTongCa = new System.Windows.Forms.Label();
            this.lblCoMat = new System.Windows.Forms.Label();
            this.lblVang = new System.Windows.Forms.Label();
            this.lblTre = new System.Windows.Forms.Label();
            this.lblChuaDiemDanh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCaoDiemDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(650, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(391, 39);
            this.label8.TabIndex = 21;
            this.label8.Text = "BÁO CÁO ĐIỂM DANH";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(276, 174);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(264, 29);
            this.dtpDenNgay.TabIndex = 38;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(276, 123);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(264, 29);
            this.dtpTuNgay.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(731, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Nhân viên:";
            // 
            // cbo_NhanVien
            // 
            this.cbo_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhanVien.FormattingEnabled = true;
            this.cbo_NhanVien.Location = new System.Drawing.Point(858, 122);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(274, 30);
            this.cbo_NhanVien.TabIndex = 40;
            // 
            // dgv_BaoCaoDiemDanh
            // 
            this.dgv_BaoCaoDiemDanh.AllowUserToAddRows = false;
            this.dgv_BaoCaoDiemDanh.AllowUserToDeleteRows = false;
            this.dgv_BaoCaoDiemDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_BaoCaoDiemDanh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BaoCaoDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_BaoCaoDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BaoCaoDiemDanh.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_BaoCaoDiemDanh.Location = new System.Drawing.Point(184, 247);
            this.dgv_BaoCaoDiemDanh.Name = "dgv_BaoCaoDiemDanh";
            this.dgv_BaoCaoDiemDanh.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BaoCaoDiemDanh.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_BaoCaoDiemDanh.RowHeadersWidth = 51;
            this.dgv_BaoCaoDiemDanh.RowTemplate.Height = 28;
            this.dgv_BaoCaoDiemDanh.Size = new System.Drawing.Size(1375, 378);
            this.dgv_BaoCaoDiemDanh.TabIndex = 41;
            this.dgv_BaoCaoDiemDanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BaoCaoDiemDanh_CellContentClick);
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(1287, 122);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(203, 30);
            this.cbo_TrangThai.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1160, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 42;
            this.label3.Text = "Trạng thái:";
            // 
            // btn_XemBaoCao
            // 
            this.btn_XemBaoCao.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_XemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XemBaoCao.Location = new System.Drawing.Point(736, 175);
            this.btn_XemBaoCao.Name = "btn_XemBaoCao";
            this.btn_XemBaoCao.Size = new System.Drawing.Size(158, 50);
            this.btn_XemBaoCao.TabIndex = 44;
            this.btn_XemBaoCao.Text = "Xem báo cáo";
            this.btn_XemBaoCao.UseVisualStyleBackColor = false;
            this.btn_XemBaoCao.Click += new System.EventHandler(this.btn_XemBaoCao_Click);
            // 
            // lblTongCa
            // 
            this.lblTongCa.AutoSize = true;
            this.lblTongCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCa.Location = new System.Drawing.Point(226, 658);
            this.lblTongCa.Name = "lblTongCa";
            this.lblTongCa.Size = new System.Drawing.Size(90, 25);
            this.lblTongCa.TabIndex = 45;
            this.lblTongCa.Text = "Tổng ca:";
            // 
            // lblCoMat
            // 
            this.lblCoMat.AutoSize = true;
            this.lblCoMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoMat.Location = new System.Drawing.Point(486, 658);
            this.lblCoMat.Name = "lblCoMat";
            this.lblCoMat.Size = new System.Drawing.Size(81, 25);
            this.lblCoMat.TabIndex = 46;
            this.lblCoMat.Text = "Có mặt:";
            // 
            // lblVang
            // 
            this.lblVang.AutoSize = true;
            this.lblVang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVang.Location = new System.Drawing.Point(955, 658);
            this.lblVang.Name = "lblVang";
            this.lblVang.Size = new System.Drawing.Size(65, 25);
            this.lblVang.TabIndex = 48;
            this.lblVang.Text = "Vắng:";
            // 
            // lblTre
            // 
            this.lblTre.AutoSize = true;
            this.lblTre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTre.Location = new System.Drawing.Point(737, 658);
            this.lblTre.Name = "lblTre";
            this.lblTre.Size = new System.Drawing.Size(48, 25);
            this.lblTre.TabIndex = 47;
            this.lblTre.Text = "Trễ:";
            // 
            // lblChuaDiemDanh
            // 
            this.lblChuaDiemDanh.AutoSize = true;
            this.lblChuaDiemDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuaDiemDanh.Location = new System.Drawing.Point(1190, 658);
            this.lblChuaDiemDanh.Name = "lblChuaDiemDanh";
            this.lblChuaDiemDanh.Size = new System.Drawing.Size(162, 25);
            this.lblChuaDiemDanh.TabIndex = 49;
            this.lblChuaDiemDanh.Text = "Chưa điểm danh:";
            // 
            // reportScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1710, 844);
            this.Controls.Add(this.lblChuaDiemDanh);
            this.Controls.Add(this.lblVang);
            this.Controls.Add(this.lblTre);
            this.Controls.Add(this.lblCoMat);
            this.Controls.Add(this.lblTongCa);
            this.Controls.Add(this.btn_XemBaoCao);
            this.Controls.Add(this.cbo_TrangThai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_BaoCaoDiemDanh);
            this.Controls.Add(this.cbo_NhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "reportScheduleForm";
            this.Text = "reportScheduleForm";
            this.Load += new System.EventHandler(this.reportScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaoCaoDiemDanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_NhanVien;
        private System.Windows.Forms.DataGridView dgv_BaoCaoDiemDanh;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_XemBaoCao;
        private System.Windows.Forms.Label lblTongCa;
        private System.Windows.Forms.Label lblCoMat;
        private System.Windows.Forms.Label lblVang;
        private System.Windows.Forms.Label lblTre;
        private System.Windows.Forms.Label lblChuaDiemDanh;
    }
}