using System;
using System.Windows.Forms;

namespace BookManagement.views.Admin
{
    partial class AdminForm : Form
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
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvStaffShow = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstbRole = new System.Windows.Forms.ListBox();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.radOther = new System.Windows.Forms.RadioButton();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.txtPersonalID = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dgvStaffShow);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1012, 645);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(515, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tìm kiếm:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // dgvStaffShow
            // 
            this.dgvStaffShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffShow.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaffShow.Location = new System.Drawing.Point(6, 67);
            this.dgvStaffShow.Name = "dgvStaffShow";
            this.dgvStaffShow.RowHeadersWidth = 51;
            this.dgvStaffShow.RowTemplate.Height = 28;
            this.dgvStaffShow.Size = new System.Drawing.Size(989, 572);
            this.dgvStaffShow.TabIndex = 5;
            this.dgvStaffShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffShow_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearch.Location = new System.Drawing.Point(661, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Orange;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnSave.Location = new System.Drawing.Point(1256, 571);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(117, 42);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Lưu";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(1407, 571);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 42);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstbRole);
            this.groupBox2.Controls.Add(this.dtpCreateDate);
            this.groupBox2.Controls.Add(this.radOther);
            this.groupBox2.Controls.Add(this.radMale);
            this.groupBox2.Controls.Add(this.radFemale);
            this.groupBox2.Controls.Add(this.txtPersonalID);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1043, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 524);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhân viên";
            // 
            // lstbRole
            // 
            this.lstbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstbRole.FormattingEnabled = true;
            this.lstbRole.ItemHeight = 25;
            this.lstbRole.Location = new System.Drawing.Point(168, 374);
            this.lstbRole.Name = "lstbRole";
            this.lstbRole.Size = new System.Drawing.Size(116, 29);
            this.lstbRole.TabIndex = 15;
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCreateDate.Enabled = false;
            this.dtpCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDate.Location = new System.Drawing.Point(168, 435);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(253, 30);
            this.dtpCreateDate.TabIndex = 14;
            // 
            // radOther
            // 
            this.radOther.AutoSize = true;
            this.radOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radOther.Location = new System.Drawing.Point(402, 306);
            this.radOther.Name = "radOther";
            this.radOther.Size = new System.Drawing.Size(79, 29);
            this.radOther.TabIndex = 13;
            this.radOther.TabStop = true;
            this.radOther.Text = "Khác";
            this.radOther.UseVisualStyleBackColor = true;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radMale.Location = new System.Drawing.Point(168, 306);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(74, 29);
            this.radMale.TabIndex = 12;
            this.radMale.TabStop = true;
            this.radMale.Text = "Nam";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radFemale.Location = new System.Drawing.Point(293, 306);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(58, 29);
            this.radFemale.TabIndex = 11;
            this.radFemale.TabStop = true;
            this.radFemale.Text = "Nữ";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // txtPersonalID
            // 
            this.txtPersonalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPersonalID.Location = new System.Drawing.Point(168, 243);
            this.txtPersonalID.Name = "txtPersonalID";
            this.txtPersonalID.Size = new System.Drawing.Size(279, 30);
            this.txtPersonalID.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAddress.Location = new System.Drawing.Point(168, 179);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(279, 30);
            this.txtAddress.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPhone.Location = new System.Drawing.Point(168, 115);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(279, 30);
            this.txtPhone.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(25, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Giới tính:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(25, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vai trò:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(25, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày tạo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(25, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "CCCD:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(25, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(25, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(168, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 30);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đầy đủ:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGreen;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClear.Location = new System.Drawing.Point(1083, 571);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 42);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1691, 763);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPersonalID;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.RadioButton radOther;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.ListBox lstbRole;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private Button btnClear;
        private TextBox txtSearch;
        private DataGridView dgvStaffShow;
        private Label label8;
    }
}