namespace QuanLyQuanCafe.GUI.NhanVien
{
    partial class FormNhanVien
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
            this.pnlTop = new Panel();
            this.lblTieuDeTrang = new Label();
            this.pnlSearch = new Panel();
            this.lblTimKiem = new Label();
            this.txtTimKiem = new TextBox();
            this.pnlRight = new Panel();
            this.grbThongTin = new GroupBox();
            this.tlpInput = new TableLayoutPanel();
            this.lblMaNV = new Label();
            this.txtMaNV = new TextBox();
            this.lblTenNV = new Label();
            this.txtTenNV = new TextBox();
            this.lblChucVu = new Label();
            this.cboChucVu = new ComboBox();
            this.lblSoDienThoai = new Label();
            this.txtSoDienThoai = new TextBox();
            this.lblCaLamViec = new Label();
            this.cboCaLamViec = new ComboBox();
            this.lblQuanLy = new Label();
            this.cboQuanLy = new ComboBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.flpButtons = new TableLayoutPanel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnDatLaiMatKhau = new Button();
            this.btnLamMoi = new Button();
            this.pnlLeft = new Panel();
            this.grbDanhSach = new GroupBox();
            this.dgvNhanVien = new DataGridView();
            this.colMaNV = new DataGridViewTextBoxColumn();
            this.colTenNV = new DataGridViewTextBoxColumn();
            this.colChucVu = new DataGridViewTextBoxColumn();
            this.colSoDienThoai = new DataGridViewTextBoxColumn();
            this.colCaLamViec = new DataGridViewTextBoxColumn();
            this.colQuanLy = new DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.lblTieuDeTrang);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 50;
            this.pnlTop.Location = new Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new Padding(4, 4, 4, 8);
            this.pnlTop.Size = new Size(976, 50);
            this.pnlTop.TabIndex = 0;

            // lblTieuDeTrang
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Dock = DockStyle.Left;
            this.lblTieuDeTrang.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDeTrang.ForeColor = Color.White;
            this.lblTieuDeTrang.Location = new Point(4, 4);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new Size(250, 37);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý nhân viên";
            this.lblTieuDeTrang.TextAlign = ContentAlignment.MiddleLeft;

            // pnlSearch
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Dock = DockStyle.Right;
            this.pnlSearch.Location = new Point(576, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new Padding(0, 4, 0, 4);
            this.pnlSearch.Size = new Size(396, 38);
            this.pnlSearch.TabIndex = 1;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Dock = DockStyle.Left;
            this.lblTimKiem.Font = new Font("Segoe UI", 10F);
            this.lblTimKiem.Location = new Point(0, 4);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Padding = new Padding(0, 5, 8, 0);
            this.lblTimKiem.Size = new Size(116, 28);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Tag = "phu";
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            this.lblTimKiem.TextAlign = ContentAlignment.MiddleRight;

            // txtTimKiem
            this.txtTimKiem.Dock = DockStyle.Right;
            this.txtTimKiem.Font = new Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new Point(116, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tên, SĐT, chức vụ, mã NV...";
            this.txtTimKiem.Size = new Size(280, 31);
            this.txtTimKiem.TabIndex = 1;

            // pnlRight
            this.pnlRight.Controls.Add(this.grbThongTin);
            this.pnlRight.Dock = DockStyle.Right;
            this.pnlRight.Location = new Point(588, 62);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new Padding(8, 0, 0, 0);
            this.pnlRight.Size = new Size(400, 486);
            this.pnlRight.TabIndex = 2;

            // grbThongTin
            this.grbThongTin.Controls.Add(this.tlpInput);
            this.grbThongTin.Controls.Add(this.flpButtons);
            this.grbThongTin.Dock = DockStyle.Fill;
            this.grbThongTin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbThongTin.Location = new Point(8, 0);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new Padding(14, 38, 14, 12);
            this.grbThongTin.Size = new Size(392, 486);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin nhân viên";

            // tlpInput
            this.tlpInput.ColumnCount = 2;
            this.tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpInput.Controls.Add(this.lblMaNV, 0, 0);
            this.tlpInput.Controls.Add(this.txtMaNV, 1, 0);
            this.tlpInput.Controls.Add(this.lblTenNV, 0, 1);
            this.tlpInput.Controls.Add(this.txtTenNV, 1, 1);
            this.tlpInput.Controls.Add(this.lblChucVu, 0, 2);
            this.tlpInput.Controls.Add(this.cboChucVu, 1, 2);
            this.tlpInput.Controls.Add(this.lblSoDienThoai, 0, 3);
            this.tlpInput.Controls.Add(this.txtSoDienThoai, 1, 3);
            this.tlpInput.Controls.Add(this.lblCaLamViec, 0, 4);
            this.tlpInput.Controls.Add(this.cboCaLamViec, 1, 4);
            this.tlpInput.Controls.Add(this.lblQuanLy, 0, 5);
            this.tlpInput.Controls.Add(this.cboQuanLy, 1, 5);
            this.tlpInput.Controls.Add(this.lblMatKhau, 0, 6);
            this.tlpInput.Controls.Add(this.txtMatKhau, 1, 6);
            this.tlpInput.Dock = DockStyle.Top;
            this.tlpInput.Font = new Font("Segoe UI", 10F);
            this.tlpInput.Location = new Point(14, 38);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 7;
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.Size = new Size(364, 280);
            this.tlpInput.TabIndex = 0;

            // lblMaNV
            this.lblMaNV.Dock = DockStyle.Fill;
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Text = "Mã NV (*):";
            this.lblMaNV.TextAlign = ContentAlignment.MiddleLeft;

            // txtMaNV
            this.txtMaNV.Dock = DockStyle.Fill;
            this.txtMaNV.Font = new Font("Segoe UI", 10.5F);
            this.txtMaNV.MaxLength = 20;
            this.txtMaNV.Name = "txtMaNV";

            // lblTenNV
            this.lblTenNV.Dock = DockStyle.Fill;
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Text = "Họ tên (*):";
            this.lblTenNV.TextAlign = ContentAlignment.MiddleLeft;

            // txtTenNV
            this.txtTenNV.Dock = DockStyle.Fill;
            this.txtTenNV.Font = new Font("Segoe UI", 10.5F);
            this.txtTenNV.MaxLength = 100;
            this.txtTenNV.Name = "txtTenNV";

            // lblChucVu
            this.lblChucVu.Dock = DockStyle.Fill;
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Text = "Chức vụ (*):";
            this.lblChucVu.TextAlign = ContentAlignment.MiddleLeft;

            // cboChucVu
            this.cboChucVu.Dock = DockStyle.Fill;
            this.cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboChucVu.Font = new Font("Segoe UI", 10F);
            this.cboChucVu.Name = "cboChucVu";

            // lblSoDienThoai
            this.lblSoDienThoai.Dock = DockStyle.Fill;
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "SĐT (*):";
            this.lblSoDienThoai.TextAlign = ContentAlignment.MiddleLeft;

            // txtSoDienThoai
            this.txtSoDienThoai.Dock = DockStyle.Fill;
            this.txtSoDienThoai.Font = new Font("Segoe UI", 10.5F);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";

            // lblCaLamViec
            this.lblCaLamViec.Dock = DockStyle.Fill;
            this.lblCaLamViec.Name = "lblCaLamViec";
            this.lblCaLamViec.Text = "Ca làm việc:";
            this.lblCaLamViec.TextAlign = ContentAlignment.MiddleLeft;

            // cboCaLamViec
            this.cboCaLamViec.Dock = DockStyle.Fill;
            this.cboCaLamViec.Font = new Font("Segoe UI", 10F);
            this.cboCaLamViec.Name = "cboCaLamViec";

            // lblQuanLy
            this.lblQuanLy.Dock = DockStyle.Fill;
            this.lblQuanLy.Name = "lblQuanLy";
            this.lblQuanLy.Text = "Quản lý:";
            this.lblQuanLy.TextAlign = ContentAlignment.MiddleLeft;

            // cboQuanLy
            this.cboQuanLy.Dock = DockStyle.Fill;
            this.cboQuanLy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboQuanLy.Font = new Font("Segoe UI", 10F);
            this.cboQuanLy.Name = "cboQuanLy";

            // lblMatKhau
            this.lblMatKhau.Dock = DockStyle.Fill;
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu (*):";
            this.lblMatKhau.TextAlign = ContentAlignment.MiddleLeft;

            // txtMatKhau
            this.txtMatKhau.Dock = DockStyle.Fill;
            this.txtMatKhau.Font = new Font("Segoe UI", 10.5F);
            this.txtMatKhau.MaxLength = 255;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.UseSystemPasswordChar = true;

            // flpButtons
            this.flpButtons.ColumnCount = 2;
            this.flpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtons.Controls.Add(this.btnThem, 0, 0);
            this.flpButtons.Controls.Add(this.btnSua, 1, 0);
            this.flpButtons.Controls.Add(this.btnDatLaiMatKhau, 0, 1);
            this.flpButtons.Controls.Add(this.btnLamMoi, 1, 1);
            this.flpButtons.Dock = DockStyle.Bottom;
            this.flpButtons.Location = new Point(14, 386);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.RowCount = 2;
            this.flpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtons.Size = new Size(364, 88);
            this.flpButtons.TabIndex = 1;

            // btnThem
            this.btnThem.Cursor = Cursors.Hand;
            this.btnThem.Dock = DockStyle.Fill;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Margin = new Padding(0, 0, 5, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(177, 39);
            this.btnThem.TabIndex = 0;
            this.btnThem.Tag = "success";
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            // btnSua
            this.btnSua.Cursor = Cursors.Hand;
            this.btnSua.Dock = DockStyle.Fill;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSua.ForeColor = Color.White;
            this.btnSua.Margin = new Padding(5, 0, 0, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(177, 39);
            this.btnSua.TabIndex = 1;
            this.btnSua.Tag = "primary";
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            // btnDatLaiMatKhau
            this.btnDatLaiMatKhau.Cursor = Cursors.Hand;
            this.btnDatLaiMatKhau.Dock = DockStyle.Fill;
            this.btnDatLaiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDatLaiMatKhau.FlatStyle = FlatStyle.Flat;
            this.btnDatLaiMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDatLaiMatKhau.ForeColor = Color.White;
            this.btnDatLaiMatKhau.Margin = new Padding(0, 5, 5, 0);
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new Size(177, 39);
            this.btnDatLaiMatKhau.TabIndex = 2;
            this.btnDatLaiMatKhau.Tag = "info";
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.UseVisualStyleBackColor = true;

            // btnLamMoi
            this.btnLamMoi.Cursor = Cursors.Hand;
            this.btnLamMoi.Dock = DockStyle.Fill;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.Margin = new Padding(5, 5, 0, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new Size(177, 39);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Tag = "neutral";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;

            // pnlLeft
            this.pnlLeft.Controls.Add(this.grbDanhSach);
            this.pnlLeft.Dock = DockStyle.Fill;
            this.pnlLeft.Location = new Point(12, 62);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new Padding(0, 0, 8, 0);
            this.pnlLeft.Size = new Size(576, 486);
            this.pnlLeft.TabIndex = 1;

            // grbDanhSach
            this.grbDanhSach.Controls.Add(this.dgvNhanVien);
            this.grbDanhSach.Dock = DockStyle.Fill;
            this.grbDanhSach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbDanhSach.Location = new Point(0, 0);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new Padding(12, 38, 12, 12);
            this.grbDanhSach.Size = new Size(568, 486);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách nhân viên";

            // dgvNhanVien
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = SystemColors.Window;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] {
                this.colMaNV,
                this.colTenNV,
                this.colChucVu,
                this.colSoDienThoai,
                this.colCaLamViec,
                this.colQuanLy
            });
            this.dgvNhanVien.Dock = DockStyle.Fill;
            this.dgvNhanVien.Font = new Font("Segoe UI", 10F);
            this.dgvNhanVien.Location = new Point(12, 38);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new Size(544, 436);
            this.dgvNhanVien.TabIndex = 0;

            // colMaNV
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.FillWeight = 80F;
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;

            // colTenNV
            this.colTenNV.DataPropertyName = "TenNV";
            this.colTenNV.FillWeight = 140F;
            this.colTenNV.HeaderText = "Họ tên";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.ReadOnly = true;

            // colChucVu
            this.colChucVu.DataPropertyName = "ChucVu";
            this.colChucVu.FillWeight = 90F;
            this.colChucVu.HeaderText = "Chức vụ";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.ReadOnly = true;

            // colSoDienThoai
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.FillWeight = 100F;
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;

            // colCaLamViec
            this.colCaLamViec.DataPropertyName = "CaLamViec";
            this.colCaLamViec.FillWeight = 90F;
            this.colCaLamViec.HeaderText = "Ca làm việc";
            this.colCaLamViec.Name = "colCaLamViec";
            this.colCaLamViec.ReadOnly = true;

            // colQuanLy
            this.colQuanLy.FillWeight = 120F;
            this.colQuanLy.HeaderText = "Quản lý trực tiếp";
            this.colQuanLy.Name = "colQuanLy";
            this.colQuanLy.ReadOnly = true;

            // FormNhanVien
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 560);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "FormNhanVien";
            this.Padding = new Padding(12);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên";

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTieuDeTrang;
        private Panel pnlSearch;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Panel pnlRight;
        private GroupBox grbThongTin;
        private TableLayoutPanel tlpInput;
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblTenNV;
        private TextBox txtTenNV;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblCaLamViec;
        private ComboBox cboCaLamViec;
        private Label lblQuanLy;
        private ComboBox cboQuanLy;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private TableLayoutPanel flpButtons;
        private Button btnLamMoi;
        private Button btnThem;
        private Button btnSua;
        private Button btnDatLaiMatKhau;
        private Panel pnlLeft;
        private GroupBox grbDanhSach;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colTenNV;
        private DataGridViewTextBoxColumn colChucVu;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colCaLamViec;
        private DataGridViewTextBoxColumn colQuanLy;
    }
}