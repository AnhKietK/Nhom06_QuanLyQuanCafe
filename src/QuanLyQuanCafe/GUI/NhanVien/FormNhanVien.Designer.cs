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
            this.pnlLeft = new Panel();
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
            this.flpButtons = new FlowLayoutPanel();
            this.btnLamMoi = new Button();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnDatLaiMatKhau = new Button();
            this.pnlRight = new Panel();
            this.grbDanhSach = new GroupBox();
            this.dgvNhanVien = new DataGridView();
            this.colMaNV = new DataGridViewTextBoxColumn();
            this.colTenNV = new DataGridViewTextBoxColumn();
            this.colChucVu = new DataGridViewTextBoxColumn();
            this.colSoDienThoai = new DataGridViewTextBoxColumn();
            this.colCaLamViec = new DataGridViewTextBoxColumn();
            this.colQuanLy = new DataGridViewTextBoxColumn();
            this.pnlSearch = new Panel();
            this.lblTimKiem = new Label();
            this.txtTimKiem = new TextBox();

            this.pnlLeft.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // pnlLeft
            this.pnlLeft.Controls.Add(this.grbThongTin);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new Padding(10);
            this.pnlLeft.Size = new Size(390, 560);
            this.pnlLeft.TabIndex = 0;

            // grbThongTin
            this.grbThongTin.Controls.Add(this.tlpInput);
            this.grbThongTin.Controls.Add(this.flpButtons);
            this.grbThongTin.Dock = DockStyle.Fill;
            this.grbThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grbThongTin.Location = new Point(10, 10);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new Padding(10);
            this.grbThongTin.Size = new Size(370, 540);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin nhân viên";

            // tlpInput
            this.tlpInput.ColumnCount = 2;
            this.tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
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
            this.tlpInput.Location = new Point(10, 33);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 7;
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpInput.Size = new Size(350, 290);
            this.tlpInput.TabIndex = 0;

            // lblMaNV
            this.lblMaNV.Dock = DockStyle.Fill;
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Text = "Mã NV (*):";
            this.lblMaNV.TextAlign = ContentAlignment.MiddleLeft;

            // txtMaNV
            this.txtMaNV.Dock = DockStyle.Fill;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.MaxLength = 20;

            // lblTenNV
            this.lblTenNV.Dock = DockStyle.Fill;
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Text = "Họ tên (*):";
            this.lblTenNV.TextAlign = ContentAlignment.MiddleLeft;

            // txtTenNV
            this.txtTenNV.Dock = DockStyle.Fill;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.MaxLength = 100;

            // lblChucVu
            this.lblChucVu.Dock = DockStyle.Fill;
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Text = "Chức vụ (*):";
            this.lblChucVu.TextAlign = ContentAlignment.MiddleLeft;

            // cboChucVu
            this.cboChucVu.Dock = DockStyle.Fill;
            this.cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboChucVu.Name = "cboChucVu";

            // lblSoDienThoai
            this.lblSoDienThoai.Dock = DockStyle.Fill;
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "SĐT (*):";
            this.lblSoDienThoai.TextAlign = ContentAlignment.MiddleLeft;

            // txtSoDienThoai
            this.txtSoDienThoai.Dock = DockStyle.Fill;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.MaxLength = 15;

            // lblCaLamViec
            this.lblCaLamViec.Dock = DockStyle.Fill;
            this.lblCaLamViec.Name = "lblCaLamViec";
            this.lblCaLamViec.Text = "Ca làm việc:";
            this.lblCaLamViec.TextAlign = ContentAlignment.MiddleLeft;

            // cboCaLamViec
            this.cboCaLamViec.Dock = DockStyle.Fill;
            this.cboCaLamViec.Name = "cboCaLamViec";

            // lblQuanLy
            this.lblQuanLy.Dock = DockStyle.Fill;
            this.lblQuanLy.Name = "lblQuanLy";
            this.lblQuanLy.Text = "Quản lý:";
            this.lblQuanLy.TextAlign = ContentAlignment.MiddleLeft;

            // cboQuanLy
            this.cboQuanLy.Dock = DockStyle.Fill;
            this.cboQuanLy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboQuanLy.Name = "cboQuanLy";

            // lblMatKhau
            this.lblMatKhau.Dock = DockStyle.Fill;
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu (*):";
            this.lblMatKhau.TextAlign = ContentAlignment.MiddleLeft;

            // txtMatKhau
            this.txtMatKhau.Dock = DockStyle.Fill;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.MaxLength = 255;

            // flpButtons
            this.flpButtons.Controls.Add(this.btnLamMoi);
            this.flpButtons.Controls.Add(this.btnThem);
            this.flpButtons.Controls.Add(this.btnSua);
            this.flpButtons.Controls.Add(this.btnDatLaiMatKhau);
            this.flpButtons.Dock = DockStyle.Bottom;
            this.flpButtons.Font = new Font("Segoe UI", 10F);
            this.flpButtons.Location = new Point(10, 430);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new Size(350, 100);
            this.flpButtons.TabIndex = 1;

            // btnLamMoi
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new Size(100, 38);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;

            // btnThem
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(100, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            // btnSua
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(100, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            // btnDatLaiMatKhau
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new Size(150, 38);
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.UseVisualStyleBackColor = true;

            // pnlRight
            this.pnlRight.Controls.Add(this.grbDanhSach);
            this.pnlRight.Controls.Add(this.pnlSearch);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(390, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new Padding(10);
            this.pnlRight.Size = new Size(610, 560);
            this.pnlRight.TabIndex = 1;

            // pnlSearch
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Dock = DockStyle.Top;
            this.pnlSearch.Location = new Point(10, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new Size(590, 45);
            this.pnlSearch.TabIndex = 0;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new Point(5, 12);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Text = "🔍 Tìm kiếm (Tên / SĐT / Mã):";

            // txtTimKiem
            this.txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTimKiem.Location = new Point(230, 8);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(350, 30);
            this.txtTimKiem.TabIndex = 0;

            // grbDanhSach
            this.grbDanhSach.Controls.Add(this.dgvNhanVien);
            this.grbDanhSach.Dock = DockStyle.Fill;
            this.grbDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grbDanhSach.Location = new Point(10, 55);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new Padding(8);
            this.grbDanhSach.Size = new Size(590, 495);
            this.grbDanhSach.TabIndex = 1;
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
            this.dgvNhanVien.Location = new Point(8, 31);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new Size(574, 456);
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
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "FormNhanVien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân viên";

            this.pnlLeft.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
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
        private FlowLayoutPanel flpButtons;
        private Button btnLamMoi;
        private Button btnThem;
        private Button btnSua;
        private Button btnDatLaiMatKhau;
        private Panel pnlRight;
        private Panel pnlSearch;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
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