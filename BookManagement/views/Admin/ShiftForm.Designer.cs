namespace BookManagement
{
    partial class ShiftForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxShift = new System.Windows.Forms.GroupBox();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.dtpShiftStart = new System.Windows.Forms.DateTimePicker();
            this.dtpShiftEnd = new System.Windows.Forms.DateTimePicker();
            this.btnShiftUpdate = new System.Windows.Forms.Button();
            this.btnShiftDelete = new System.Windows.Forms.Button();
            this.btnShiftLoad = new System.Windows.Forms.Button();
            this.btnShiftAdd = new System.Windows.Forms.Button();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBoxShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBoxShift);
            this.panel1.Controls.Add(this.dgvShift);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1709, 810);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(833, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tìm kiếm";
            // 
            // groupBoxShift
            // 
            this.groupBoxShift.Controls.Add(this.txtShiftName);
            this.groupBoxShift.Controls.Add(this.dtpShiftStart);
            this.groupBoxShift.Controls.Add(this.dtpShiftEnd);
            this.groupBoxShift.Controls.Add(this.btnShiftUpdate);
            this.groupBoxShift.Controls.Add(this.btnShiftDelete);
            this.groupBoxShift.Controls.Add(this.btnShiftLoad);
            this.groupBoxShift.Controls.Add(this.btnShiftAdd);
            this.groupBoxShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxShift.Location = new System.Drawing.Point(12, 12);
            this.groupBoxShift.Name = "groupBoxShift";
            this.groupBoxShift.Size = new System.Drawing.Size(478, 257);
            this.groupBoxShift.TabIndex = 0;
            this.groupBoxShift.TabStop = false;
            this.groupBoxShift.Text = "Thông tin ca làm";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtShiftName.Location = new System.Drawing.Point(6, 34);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(450, 30);
            this.txtShiftName.TabIndex = 0;
            // 
            // dtpShiftStart
            // 
            this.dtpShiftStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpShiftStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpShiftStart.Location = new System.Drawing.Point(19, 82);
            this.dtpShiftStart.Name = "dtpShiftStart";
            this.dtpShiftStart.ShowUpDown = true;
            this.dtpShiftStart.Size = new System.Drawing.Size(157, 30);
            this.dtpShiftStart.TabIndex = 1;
            // 
            // dtpShiftEnd
            // 
            this.dtpShiftEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpShiftEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpShiftEnd.Location = new System.Drawing.Point(308, 82);
            this.dtpShiftEnd.Name = "dtpShiftEnd";
            this.dtpShiftEnd.ShowUpDown = true;
            this.dtpShiftEnd.Size = new System.Drawing.Size(148, 30);
            this.dtpShiftEnd.TabIndex = 2;
            // 
            // btnShiftUpdate
            // 
            this.btnShiftUpdate.BackColor = System.Drawing.Color.OldLace;
            this.btnShiftUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftUpdate.Location = new System.Drawing.Point(328, 143);
            this.btnShiftUpdate.Name = "btnShiftUpdate";
            this.btnShiftUpdate.Size = new System.Drawing.Size(128, 44);
            this.btnShiftUpdate.TabIndex = 4;
            this.btnShiftUpdate.Text = "Cập nhật";
            this.btnShiftUpdate.UseVisualStyleBackColor = false;
            this.btnShiftUpdate.Click += new System.EventHandler(this.btnShiftUpdate_Click);
            // 
            // btnShiftDelete
            // 
            this.btnShiftDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnShiftDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftDelete.Location = new System.Drawing.Point(115, 143);
            this.btnShiftDelete.Name = "btnShiftDelete";
            this.btnShiftDelete.Size = new System.Drawing.Size(85, 44);
            this.btnShiftDelete.TabIndex = 5;
            this.btnShiftDelete.Text = "Xóa";
            this.btnShiftDelete.UseVisualStyleBackColor = false;
            this.btnShiftDelete.Click += new System.EventHandler(this.btnShiftDelete_Click);
            // 
            // btnShiftLoad
            // 
            this.btnShiftLoad.BackColor = System.Drawing.Color.Orange;
            this.btnShiftLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnShiftLoad.Location = new System.Drawing.Point(219, 143);
            this.btnShiftLoad.Name = "btnShiftLoad";
            this.btnShiftLoad.Size = new System.Drawing.Size(103, 44);
            this.btnShiftLoad.TabIndex = 6;
            this.btnShiftLoad.Text = "Làm mới";
            this.btnShiftLoad.UseVisualStyleBackColor = false;
            this.btnShiftLoad.Click += new System.EventHandler(this.btnShiftLoad_Click);
            // 
            // btnShiftAdd
            // 
            this.btnShiftAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnShiftAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftAdd.Location = new System.Drawing.Point(6, 143);
            this.btnShiftAdd.Name = "btnShiftAdd";
            this.btnShiftAdd.Size = new System.Drawing.Size(85, 44);
            this.btnShiftAdd.TabIndex = 3;
            this.btnShiftAdd.Text = "Thêm";
            this.btnShiftAdd.UseVisualStyleBackColor = false;
            this.btnShiftAdd.Click += new System.EventHandler(this.btnShiftAdd_Click);
            // 
            // dgvShift
            // 
            this.dgvShift.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShift.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShift.ColumnHeadersHeight = 29;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShift.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShift.Location = new System.Drawing.Point(496, 59);
            this.dgvShift.MultiSelect = false;
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.ReadOnly = true;
            this.dgvShift.RowHeadersWidth = 51;
            this.dgvShift.RowTemplate.Height = 28;
            this.dgvShift.Size = new System.Drawing.Size(763, 523);
            this.dgvShift.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearch.Location = new System.Drawing.Point(960, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ShiftForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1691, 763);
            this.Controls.Add(this.panel1);
            this.Name = "ShiftForm";
            this.Text = "Shift Management";
            this.Load += new System.EventHandler(this.ShiftForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxShift.ResumeLayout(false);
            this.groupBoxShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxShift;
        private System.Windows.Forms.DataGridView dgvShift;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.DateTimePicker dtpShiftEnd;
        private System.Windows.Forms.DateTimePicker dtpShiftStart;
        private System.Windows.Forms.Button btnShiftLoad;
        private System.Windows.Forms.Button btnShiftDelete;
        private System.Windows.Forms.Button btnShiftAdd;
        private System.Windows.Forms.Button btnShiftUpdate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}
