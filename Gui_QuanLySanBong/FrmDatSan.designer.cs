
namespace GUI_QuanLySanBong
{
    partial class FrmDatSan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatSan));
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thueSanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.sanTableAdapter = new GUI_QuanLySanBong.QuanLySanBongDataSetTableAdapters.SanTableAdapter();
            this.khachHangTableAdapter = new GUI_QuanLySanBong.QuanLySanBongDataSetTableAdapters.KhachHangTableAdapter();
            this.thuesanTableAdapter = new GUI_QuanLySanBong.QuanLySanBongDataSetTableAdapters.ThueSanTableAdapter();
            this.thuesanTableAdapter1 = new GUI_QuanLySanBong.QuanLySanBongDataSetTableAdapters.ThueSanTableAdapter();
            this.quanLySanBongDataSet1 = new GUI_QuanLySanBong.QuanLySanBongDataSet();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateBD = new System.Windows.Forms.DateTimePicker();
            this.cbbsan = new System.Windows.Forms.ComboBox();
            this.btnDatSan = new System.Windows.Forms.Button();
            this.dtGioBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtGioKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnHuySan = new System.Windows.Forms.Button();
            this.btnSuaSan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbmakh = new System.Windows.Forms.ComboBox();
            this.dateKT = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nbDonGia = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbLoaiThue = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thueSanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanBongDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbDonGia)).BeginInit();
            this.SuspendLayout();
            // 
            // sanBindingSource
            // 
            this.sanBindingSource.CurrentChanged += new System.EventHandler(this.sanBindingSource_CurrentChanged);
            // 
            // thueSanBindingSource
            // 
            this.thueSanBindingSource.CurrentChanged += new System.EventHandler(this.thueSanBindingSource_CurrentChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // sanTableAdapter
            // 
            this.sanTableAdapter.ClearBeforeFill = true;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // thuesanTableAdapter
            // 
            this.thuesanTableAdapter.ClearBeforeFill = true;
            // 
            // thuesanTableAdapter1
            // 
            this.thuesanTableAdapter1.ClearBeforeFill = true;
            // 
            // quanLySanBongDataSet1
            // 
            this.quanLySanBongDataSet1.DataSetName = "QuanLySanBongDataSet";
            this.quanLySanBongDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 48);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Mã sân:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(562, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Mã khách hàng:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(51, 91);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Bắt đầu:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 152);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 16;
            this.label15.Text = "Kết thúc:";
            // 
            // dateBD
            // 
            this.dateBD.CustomFormat = "dd/MM/yyyy";
            this.dateBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBD.Location = new System.Drawing.Point(133, 91);
            this.dateBD.Margin = new System.Windows.Forms.Padding(4);
            this.dateBD.Name = "dateBD";
            this.dateBD.Size = new System.Drawing.Size(208, 22);
            this.dateBD.TabIndex = 4;
            // 
            // cbbsan
            // 
            this.cbbsan.DataSource = this.sanBindingSource;
            this.cbbsan.DisplayMember = "Ten_San";
            this.cbbsan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbsan.FormattingEnabled = true;
            this.cbbsan.Location = new System.Drawing.Point(133, 40);
            this.cbbsan.Margin = new System.Windows.Forms.Padding(4);
            this.cbbsan.Name = "cbbsan";
            this.cbbsan.Size = new System.Drawing.Size(329, 24);
            this.cbbsan.TabIndex = 5;
            this.cbbsan.ValueMember = "Ma_San";
            this.cbbsan.SelectedIndexChanged += new System.EventHandler(this.cbbsan_SelectedIndexChanged);
            // 
            // btnDatSan
            // 
            this.btnDatSan.BackColor = System.Drawing.Color.Green;
            this.btnDatSan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatSan.ForeColor = System.Drawing.Color.White;
            this.btnDatSan.Location = new System.Drawing.Point(133, 212);
            this.btnDatSan.Name = "btnDatSan";
            this.btnDatSan.Size = new System.Drawing.Size(137, 40);
            this.btnDatSan.TabIndex = 28;
            this.btnDatSan.Text = "ĐẶT SÂN";
            this.btnDatSan.UseVisualStyleBackColor = false;
            this.btnDatSan.Click += new System.EventHandler(this.btnDatSan_Click);
            // 
            // dtGioBatDau
            // 
            this.dtGioBatDau.CustomFormat = "HH:mm";
            this.dtGioBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGioBatDau.Location = new System.Drawing.Point(377, 91);
            this.dtGioBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.dtGioBatDau.Name = "dtGioBatDau";
            this.dtGioBatDau.ShowUpDown = true;
            this.dtGioBatDau.Size = new System.Drawing.Size(75, 22);
            this.dtGioBatDau.TabIndex = 29;
            // 
            // dtGioKetThuc
            // 
            this.dtGioKetThuc.CustomFormat = "HH:mm";
            this.dtGioKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGioKetThuc.Location = new System.Drawing.Point(377, 152);
            this.dtGioKetThuc.Margin = new System.Windows.Forms.Padding(4);
            this.dtGioKetThuc.Name = "dtGioKetThuc";
            this.dtGioKetThuc.ShowUpDown = true;
            this.dtGioKetThuc.Size = new System.Drawing.Size(75, 22);
            this.dtGioKetThuc.TabIndex = 30;
            // 
            // btnHuySan
            // 
            this.btnHuySan.BackColor = System.Drawing.Color.Green;
            this.btnHuySan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuySan.ForeColor = System.Drawing.Color.White;
            this.btnHuySan.Location = new System.Drawing.Point(315, 212);
            this.btnHuySan.Name = "btnHuySan";
            this.btnHuySan.Size = new System.Drawing.Size(137, 40);
            this.btnHuySan.TabIndex = 32;
            this.btnHuySan.Text = "TRẢ SÂN";
            this.btnHuySan.UseVisualStyleBackColor = false;
            this.btnHuySan.Click += new System.EventHandler(this.btnHuySan_Click);
            // 
            // btnSuaSan
            // 
            this.btnSuaSan.BackColor = System.Drawing.Color.Green;
            this.btnSuaSan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaSan.ForeColor = System.Drawing.Color.White;
            this.btnSuaSan.Location = new System.Drawing.Point(682, 212);
            this.btnSuaSan.Name = "btnSuaSan";
            this.btnSuaSan.Size = new System.Drawing.Size(137, 40);
            this.btnSuaSan.TabIndex = 33;
            this.btnSuaSan.Text = "XOÁ";
            this.btnSuaSan.UseVisualStyleBackColor = false;
            this.btnSuaSan.Click += new System.EventHandler(this.btnSuaSan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(1, 295);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1208, 383);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã sân";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã khách hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Thời gian bắt đầu";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Thời gian kết thúc";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Loại thuế";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Đơn giá";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Thành Tiền";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // cbbmakh
            // 
            this.cbbmakh.DataSource = this.khachHangBindingSource;
            this.cbbmakh.DisplayMember = "Ten_KhachHang";
            this.cbbmakh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbmakh.FormattingEnabled = true;
            this.cbbmakh.Location = new System.Drawing.Point(682, 40);
            this.cbbmakh.Margin = new System.Windows.Forms.Padding(4);
            this.cbbmakh.Name = "cbbmakh";
            this.cbbmakh.Size = new System.Drawing.Size(323, 24);
            this.cbbmakh.TabIndex = 35;
            this.cbbmakh.ValueMember = "Ma_KhachHang";
            // 
            // dateKT
            // 
            this.dateKT.CustomFormat = "dd/MM/yyyy";
            this.dateKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKT.Location = new System.Drawing.Point(133, 152);
            this.dateKT.Margin = new System.Windows.Forms.Padding(4);
            this.dateKT.Name = "dateKT";
            this.dateKT.Size = new System.Drawing.Size(208, 22);
            this.dateKT.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Đơn giá";
            // 
            // nbDonGia
            // 
            this.nbDonGia.Location = new System.Drawing.Point(682, 157);
            this.nbDonGia.Margin = new System.Windows.Forms.Padding(4);
            this.nbDonGia.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nbDonGia.Name = "nbDonGia";
            this.nbDonGia.Size = new System.Drawing.Size(160, 22);
            this.nbDonGia.TabIndex = 38;
            this.nbDonGia.ThousandsSeparator = true;
            this.nbDonGia.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(850, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "(VNĐ / giờ)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Loại thuê:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbbLoaiThue
            // 
            this.cbbLoaiThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiThue.FormattingEnabled = true;
            this.cbbLoaiThue.Items.AddRange(new object[] {
            "Trực tiếp",
            "Đặt trước"});
            this.cbbLoaiThue.Location = new System.Drawing.Point(682, 97);
            this.cbbLoaiThue.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLoaiThue.Name = "cbbLoaiThue";
            this.cbbLoaiThue.Size = new System.Drawing.Size(328, 24);
            this.cbbLoaiThue.TabIndex = 45;
            this.cbbLoaiThue.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiThue_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1057, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // FrmDatSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1208, 677);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbLoaiThue);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbbmakh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbsan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nbDonGia);
            this.Controls.Add(this.dateBD);
            this.Controls.Add(this.dtGioBatDau);
            this.Controls.Add(this.dateKT);
            this.Controls.Add(this.btnSuaSan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtGioKetThuc);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnHuySan);
            this.Controls.Add(this.btnDatSan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDatSan";
            this.Text = "Đặt Sân";
            this.Load += new System.EventHandler(this.FrmDatSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thueSanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLySanBongDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbDonGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QuanLySanBongDataSetTableAdapters.SanTableAdapter sanTableAdapter;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        private System.Windows.Forms.BindingSource thueSanBindingSource;
        private QuanLySanBongDataSetTableAdapters.ThueSanTableAdapter thuesanTableAdapter;
        private GUI_QuanLySanBong.QuanLySanBongDataSetTableAdapters.ThueSanTableAdapter thuesanTableAdapter1;
        private QuanLySanBongDataSet quanLySanBongDataSet1;
        private System.Windows.Forms.BindingSource sanBindingSource;
        private QuanLySanBongDataSetTableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private System.Windows.Forms.ComboBox cbbLoaiThue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbmakh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbsan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nbDonGia;
        private System.Windows.Forms.DateTimePicker dateBD;
        private System.Windows.Forms.DateTimePicker dtGioBatDau;
        private System.Windows.Forms.DateTimePicker dateKT;
        private System.Windows.Forms.Button btnSuaSan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DateTimePicker dtGioKetThuc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnHuySan;
        private System.Windows.Forms.Button btnDatSan;
        private System.Windows.Forms.Label label4;
    }
}