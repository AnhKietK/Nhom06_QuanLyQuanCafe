namespace QuanLyQuanCafe.GUI.Khach
{
    partial class FormKhach
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
            System.Windows.Forms.DataGridViewCellStyle dgvKhachHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvLSHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTichLuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhanTramGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLoc = new System.Windows.Forms.Panel();
            this.chkChiKhachThanThiet = new System.Windows.Forms.CheckBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.splRight = new System.Windows.Forms.SplitContainer();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblLoaiKhach = new System.Windows.Forms.Label();
            this.cboLoaiKhach = new System.Windows.Forms.ComboBox();
            this.lblDiemTieuDe = new System.Windows.Forms.Label();
            this.lblDiemTichLuy = new System.Windows.Forms.Label();
            this.lblChietKhauTieuDe = new System.Windows.Forms.Label();
            this.lblHangHienTai = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grbLichSuMua = new System.Windows.Forms.GroupBox();
            this.dgvLichSuMua = new System.Windows.Forms.DataGridView();
            this.colLSMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSPhuongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLSTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splRight)).BeginInit();
            this.splRight.Panel1.SuspendLayout();
            this.splRight.Panel2.SuspendLayout();
            this.splRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.grbLichSuMua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuMua)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTieuDeTrang);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(6, 4, 6, 8);
            this.pnlTop.Size = new System.Drawing.Size(1076, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTieuDeTrang
            // 
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTrang.Location = new System.Drawing.Point(6, 4);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(265, 37);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý khách hàng";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(12, 62);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.grbDanhSach);
            this.splMain.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.splRight);
            this.splMain.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.splMain.Size = new System.Drawing.Size(1076, 576);
            this.splMain.SplitterDistance = 580;
            this.splMain.TabIndex = 1;
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvKhach);
            this.grbDanhSach.Controls.Add(this.pnlLoc);
            this.grbDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grbDanhSach.Size = new System.Drawing.Size(574, 576);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách khách hàng";
            // 
            // dgvKhach
            // 
            this.dgvKhach.AllowUserToAddRows = false;
            this.dgvKhach.AllowUserToDeleteRows = false;
            this.dgvKhach.AllowUserToResizeRows = false;
            this.dgvKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKH,
            this.colTenKH,
            this.colSoDienThoai,
            this.colDiemTichLuy,
            this.colTenLoaiKH,
            this.colPhanTramGiam});
            this.dgvKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhach.Location = new System.Drawing.Point(8, 80);
            this.dgvKhach.MultiSelect = false;
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.ReadOnly = true;
            this.dgvKhach.RowHeadersVisible = false;
            this.dgvKhach.RowHeadersWidth = 51;
            this.dgvKhach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhach.Size = new System.Drawing.Size(558, 488);
            this.dgvKhach.TabIndex = 1;
            // 
            // colMaKH
            // 
            this.colMaKH.DataPropertyName = "MaKH";
            this.colMaKH.FillWeight = 65F;
            this.colMaKH.HeaderText = "Mã KH";
            this.colMaKH.MinimumWidth = 70;
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            this.colTenKH.DataPropertyName = "TenKH";
            this.colTenKH.FillWeight = 120F;
            this.colTenKH.HeaderText = "Họ tên";
            this.colTenKH.MinimumWidth = 110;
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.FillWeight = 90F;
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.MinimumWidth = 95;
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            // 
            // colDiemTichLuy
            // 
            this.colDiemTichLuy.DataPropertyName = "DiemTichLuy";
            this.colDiemTichLuy.FillWeight = 60F;
            this.colDiemTichLuy.HeaderText = "Điểm";
            this.colDiemTichLuy.MinimumWidth = 55;
            this.colDiemTichLuy.Name = "colDiemTichLuy";
            this.colDiemTichLuy.ReadOnly = true;
            // 
            // colTenLoaiKH
            // 
            this.colTenLoaiKH.DataPropertyName = "TenLoaiKH";
            this.colTenLoaiKH.FillWeight = 85F;
            this.colTenLoaiKH.HeaderText = "Hạng TV";
            this.colTenLoaiKH.MinimumWidth = 75;
            this.colTenLoaiKH.Name = "colTenLoaiKH";
            this.colTenLoaiKH.ReadOnly = true;
            // 
            // colPhanTramGiam
            // 
            this.colPhanTramGiam.DataPropertyName = "PhanTramGiam";
            this.colPhanTramGiam.FillWeight = 65F;
            this.colPhanTramGiam.HeaderText = "Chiết khấu";
            this.colPhanTramGiam.MinimumWidth = 70;
            this.colPhanTramGiam.Name = "colPhanTramGiam";
            this.colPhanTramGiam.ReadOnly = true;
            // 
            // pnlLoc
            // 
            this.pnlLoc.Controls.Add(this.chkChiKhachThanThiet);
            this.pnlLoc.Controls.Add(this.txtTimKiem);
            this.pnlLoc.Controls.Add(this.lblTimKiem);
            this.pnlLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLoc.Location = new System.Drawing.Point(8, 26);
            this.pnlLoc.Name = "pnlLoc";
            this.pnlLoc.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.pnlLoc.Size = new System.Drawing.Size(558, 54);
            this.pnlLoc.TabIndex = 0;
            // 
            // chkChiKhachThanThiet
            // 
            this.chkChiKhachThanThiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChiKhachThanThiet.AutoSize = true;
            this.chkChiKhachThanThiet.Location = new System.Drawing.Point(340, 15);
            this.chkChiKhachThanThiet.Name = "chkChiKhachThanThiet";
            this.chkChiKhachThanThiet.Size = new System.Drawing.Size(215, 24);
            this.chkChiKhachThanThiet.TabIndex = 2;
            this.chkChiKhachThanThiet.Text = "Chỉ khách có điểm tích lũy";
            this.chkChiKhachThanThiet.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(75, 13);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên hoặc số điện thoại...";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 27);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(3, 16);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(73, 20);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // splRight
            // 
            this.splRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splRight.Location = new System.Drawing.Point(6, 0);
            this.splRight.Name = "splRight";
            this.splRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splRight.Panel1
            // 
            this.splRight.Panel1.Controls.Add(this.grbThongTin);
            this.splRight.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            // 
            // splRight.Panel2
            // 
            this.splRight.Panel2.Controls.Add(this.grbLichSuMua);
            this.splRight.Panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.splRight.Size = new System.Drawing.Size(486, 576);
            this.splRight.SplitterDistance = 290;
            this.splRight.TabIndex = 0;
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.tlpThongTin);
            this.grbThongTin.Controls.Add(this.pnlButtons);
            this.grbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTin.Location = new System.Drawing.Point(0, 0);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.grbThongTin.Size = new System.Drawing.Size(486, 284);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin khách hàng";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 2;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThongTin.Controls.Add(this.lblMaKH, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaKH, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblTenKH, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtTenKH, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblSoDienThoai, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtSoDienThoai, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblLoaiKhach, 0, 3);
            this.tlpThongTin.Controls.Add(this.cboLoaiKhach, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblDiemTieuDe, 0, 4);
            this.tlpThongTin.Controls.Add(this.lblDiemTichLuy, 1, 4);
            this.tlpThongTin.Controls.Add(this.lblChietKhauTieuDe, 0, 5);
            this.tlpThongTin.Controls.Add(this.lblHangHienTai, 1, 5);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(10, 28);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.RowCount = 6;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpThongTin.Size = new System.Drawing.Size(466, 196);
            this.tlpThongTin.TabIndex = 0;
            // 
            // lblMaKH
            // 
            this.lblMaKH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(3, 6);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(57, 20);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKH.Location = new System.Drawing.Point(133, 3);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(330, 27);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblTenKH
            // 
            this.lblTenKH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(3, 38);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(84, 20);
            this.lblTenKH.TabIndex = 2;
            this.lblTenKH.Text = "Họ tên (*):";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenKH.Location = new System.Drawing.Point(133, 35);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(330, 27);
            this.txtTenKH.TabIndex = 3;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(3, 70);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(126, 20);
            this.lblSoDienThoai.TabIndex = 4;
            this.lblSoDienThoai.Text = "Số điện thoại (*):";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoDienThoai.Location = new System.Drawing.Point(133, 67);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(330, 27);
            this.txtSoDienThoai.TabIndex = 5;
            // 
            // lblLoaiKhach
            // 
            this.lblLoaiKhach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLoaiKhach.AutoSize = true;
            this.lblLoaiKhach.Location = new System.Drawing.Point(3, 102);
            this.lblLoaiKhach.Name = "lblLoaiKhach";
            this.lblLoaiKhach.Size = new System.Drawing.Size(83, 20);
            this.lblLoaiKhach.TabIndex = 6;
            this.lblLoaiKhach.Text = "Loại khách:";
            // 
            // cboLoaiKhach
            // 
            this.cboLoaiKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKhach.FormattingEnabled = true;
            this.cboLoaiKhach.Location = new System.Drawing.Point(133, 99);
            this.cboLoaiKhach.Name = "cboLoaiKhach";
            this.cboLoaiKhach.Size = new System.Drawing.Size(330, 28);
            this.cboLoaiKhach.TabIndex = 7;
            // 
            // lblDiemTieuDe
            // 
            this.lblDiemTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiemTieuDe.AutoSize = true;
            this.lblDiemTieuDe.Location = new System.Drawing.Point(3, 132);
            this.lblDiemTieuDe.Name = "lblDiemTieuDe";
            this.lblDiemTieuDe.Size = new System.Drawing.Size(102, 20);
            this.lblDiemTieuDe.TabIndex = 8;
            this.lblDiemTieuDe.Text = "Điểm tích lũy:";
            // 
            // lblDiemTichLuy
            // 
            this.lblDiemTichLuy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiemTichLuy.AutoSize = true;
            this.lblDiemTichLuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiemTichLuy.Location = new System.Drawing.Point(133, 130);
            this.lblDiemTichLuy.Name = "lblDiemTichLuy";
            this.lblDiemTichLuy.Size = new System.Drawing.Size(65, 23);
            this.lblDiemTichLuy.TabIndex = 9;
            this.lblDiemTichLuy.Tag = "nhanmanh";
            this.lblDiemTichLuy.Text = "0 điểm";
            // 
            // lblChietKhauTieuDe
            // 
            this.lblChietKhauTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblChietKhauTieuDe.AutoSize = true;
            this.lblChietKhauTieuDe.Location = new System.Drawing.Point(3, 166);
            this.lblChietKhauTieuDe.Name = "lblChietKhauTieuDe";
            this.lblChietKhauTieuDe.Size = new System.Drawing.Size(66, 20);
            this.lblChietKhauTieuDe.TabIndex = 10;
            this.lblChietKhauTieuDe.Text = "Ưu đãi:";
            // 
            // lblHangHienTai
            // 
            this.lblHangHienTai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHangHienTai.AutoSize = true;
            this.lblHangHienTai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHangHienTai.Location = new System.Drawing.Point(133, 164);
            this.lblHangHienTai.Name = "lblHangHienTai";
            this.lblHangHienTai.Size = new System.Drawing.Size(161, 23);
            this.lblHangHienTai.TabIndex = 11;
            this.lblHangHienTai.Tag = "nhanmanh";
            this.lblHangHienTai.Text = "Thường (Giảm 0%)";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(10, 224);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(466, 52);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(366, 8);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 36);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(265, 8);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 36);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(164, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 36);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(4, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 36);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // grbLichSuMua
            // 
            this.grbLichSuMua.Controls.Add(this.dgvLichSuMua);
            this.grbLichSuMua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbLichSuMua.Location = new System.Drawing.Point(0, 6);
            this.grbLichSuMua.Name = "grbLichSuMua";
            this.grbLichSuMua.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grbLichSuMua.Size = new System.Drawing.Size(486, 276);
            this.grbLichSuMua.TabIndex = 0;
            this.grbLichSuMua.TabStop = false;
            this.grbLichSuMua.Text = "Lịch sử mua hàng";
            // 
            // dgvLichSuMua
            // 
            this.dgvLichSuMua.AllowUserToAddRows = false;
            this.dgvLichSuMua.AllowUserToDeleteRows = false;
            this.dgvLichSuMua.AllowUserToResizeRows = false;
            this.dgvLichSuMua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuMua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuMua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLSMaHD,
            this.colLSNgayTao,
            this.colLSTongTien,
            this.colLSPhuongThuc,
            this.colLSTenNV,
            this.colLSTrangThai});
            this.dgvLichSuMua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuMua.Location = new System.Drawing.Point(8, 26);
            this.dgvLichSuMua.MultiSelect = false;
            this.dgvLichSuMua.Name = "dgvLichSuMua";
            this.dgvLichSuMua.ReadOnly = true;
            this.dgvLichSuMua.RowHeadersVisible = false;
            this.dgvLichSuMua.RowHeadersWidth = 51;
            this.dgvLichSuMua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuMua.Size = new System.Drawing.Size(470, 242);
            this.dgvLichSuMua.TabIndex = 0;
            // 
            // colLSMaHD
            // 
            this.colLSMaHD.DataPropertyName = "MaHD";
            this.colLSMaHD.FillWeight = 80F;
            this.colLSMaHD.HeaderText = "Mã HĐ";
            this.colLSMaHD.MinimumWidth = 75;
            this.colLSMaHD.Name = "colLSMaHD";
            this.colLSMaHD.ReadOnly = true;
            // 
            // colLSNgayTao
            // 
            this.colLSNgayTao.DataPropertyName = "NgayTao";
            this.colLSNgayTao.FillWeight = 110F;
            this.colLSNgayTao.HeaderText = "Ngày lập";
            this.colLSNgayTao.MinimumWidth = 100;
            this.colLSNgayTao.Name = "colLSNgayTao";
            this.colLSNgayTao.ReadOnly = true;
            // 
            // colLSTongTien
            // 
            this.colLSTongTien.DataPropertyName = "TongTienThanhToan";
            this.colLSTongTien.FillWeight = 95F;
            this.colLSTongTien.HeaderText = "Tổng thanh toán";
            this.colLSTongTien.MinimumWidth = 90;
            this.colLSTongTien.Name = "colLSTongTien";
            this.colLSTongTien.ReadOnly = true;
            // 
            // colLSPhuongThuc
            // 
            this.colLSPhuongThuc.DataPropertyName = "PhuongThucThanhToan";
            this.colLSPhuongThuc.FillWeight = 85F;
            this.colLSPhuongThuc.HeaderText = "Phương thức";
            this.colLSPhuongThuc.MinimumWidth = 80;
            this.colLSPhuongThuc.Name = "colLSPhuongThuc";
            this.colLSPhuongThuc.ReadOnly = true;
            // 
            // colLSTenNV
            // 
            this.colLSTenNV.DataPropertyName = "TenNV";
            this.colLSTenNV.FillWeight = 90F;
            this.colLSTenNV.HeaderText = "Thu ngân";
            this.colLSTenNV.MinimumWidth = 85;
            this.colLSTenNV.Name = "colLSTenNV";
            this.colLSTenNV.ReadOnly = true;
            // 
            // colLSTrangThai
            // 
            this.colLSTrangThai.DataPropertyName = "TrangThai";
            this.colLSTrangThai.FillWeight = 80F;
            this.colLSTrangThai.HeaderText = "Trạng thái";
            this.colLSTrangThai.MinimumWidth = 75;
            this.colLSTrangThai.Name = "colLSTrangThai";
            this.colLSTrangThai.ReadOnly = true;
            // 
            // FormKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormKhach";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Quản lý khách hàng";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            this.splRight.Panel1.ResumeLayout(false);
            this.splRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splRight)).EndInit();
            this.splRight.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.grbLichSuMua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuMua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.Panel pnlLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.CheckBox chkChiKhachThanThiet;
        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.SplitContainer splRight;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblLoaiKhach;
        private System.Windows.Forms.ComboBox cboLoaiKhach;
        private System.Windows.Forms.Label lblDiemTieuDe;
        private System.Windows.Forms.Label lblDiemTichLuy;
        private System.Windows.Forms.Label lblChietKhauTieuDe;
        private System.Windows.Forms.Label lblHangHienTai;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox grbLichSuMua;
        private System.Windows.Forms.DataGridView dgvLichSuMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemTichLuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhanTramGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSPhuongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLSTrangThai;
    }
}

