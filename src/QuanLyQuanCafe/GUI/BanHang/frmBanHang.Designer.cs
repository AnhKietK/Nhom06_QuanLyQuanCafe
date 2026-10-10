namespace QuanLyQuanCafe.GUI.BanHang
{
    partial class frmBanHang
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
            this.components = new System.ComponentModel.Container();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);

            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.btnHuongDan = new System.Windows.Forms.Button();
            this.btnLamMoiToanBo = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();

            // Cột 1: Sơ đồ bàn
            this.grpSoDoBan = new System.Windows.Forms.GroupBox();
            this.pnlFilterBan = new System.Windows.Forms.Panel();
            this.lblLocKhuVuc = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThaiBan = new System.Windows.Forms.ComboBox();
            this.lblTimKiemBan = new System.Windows.Forms.Label();
            this.txtTimKiemBan = new System.Windows.Forms.TextBox();
            this.pnlThongKeBan = new System.Windows.Forms.Panel();
            this.lblThongKeBan = new System.Windows.Forms.Label();
            this.flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlActionBan = new System.Windows.Forms.Panel();
            this.btnMoBanNhanh = new System.Windows.Forms.Button();
            this.btnChuyenBanNhanh = new System.Windows.Forms.Button();

            // Cột 2: Thực đơn
            this.grpThucDon = new System.Windows.Forms.GroupBox();
            this.pnlFilterMon = new System.Windows.Forms.Panel();
            this.lblTimMon = new System.Windows.Forms.Label();
            this.txtTimKiemMon = new System.Windows.Forms.TextBox();
            this.lblLoaiMon = new System.Windows.Forms.Label();
            this.cboLoaiMon = new System.Windows.Forms.ComboBox();
            this.dgvThucUong = new System.Windows.Forms.DataGridView();
            this.colMaTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlActionMon = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuongMon = new System.Windows.Forms.NumericUpDown();
            this.btnSL1 = new System.Windows.Forms.Button();
            this.btnSL2 = new System.Windows.Forms.Button();
            this.btnSL5 = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnKiemTraKho = new System.Windows.Forms.Button();

            // Cột 3: Hóa đơn & Thanh toán
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.pnlThongTinBanHienTai = new System.Windows.Forms.Panel();
            this.lblBanDangChon = new System.Windows.Forms.Label();
            this.lblMaHDHienTai = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.pnlKhachHang = new System.Windows.Forms.Panel();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtTimKhach = new System.Windows.Forms.TextBox();
            this.btnTimKhach = new System.Windows.Forms.Button();
            this.btnThemKhachNhanh = new System.Windows.Forms.Button();
            this.btnBoChonKhach = new System.Windows.Forms.Button();
            this.lblThongTinKhach = new System.Windows.Forms.Label();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.colCT_TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDieuChinhCT = new System.Windows.Forms.Panel();
            this.btnTangSL = new System.Windows.Forms.Button();
            this.btnGiamSL = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.pnlTinhTien = new System.Windows.Forms.Panel();
            this.tlpTinhTien = new System.Windows.Forms.TableLayoutPanel();
            this.lblTienHangTieuDe = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblGiamGiaTieuDe = new System.Windows.Forms.Label();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblTongThanhToanTieuDe = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.lblPhuongThucTieuDe = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblTienKhachDuaTieuDe = new System.Windows.Forms.Label();
            this.numTienKhachDua = new System.Windows.Forms.NumericUpDown();
            this.lblTienThoiTieuDe = new System.Windows.Forms.Label();
            this.lblTienThoi = new System.Windows.Forms.Label();
            this.pnlTienNhanh = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTienVuaDu = new System.Windows.Forms.Button();
            this.btnTien20k = new System.Windows.Forms.Button();
            this.btnTien50k = new System.Windows.Forms.Button();
            this.btnTien100k = new System.Windows.Forms.Button();
            this.btnTien200k = new System.Windows.Forms.Button();
            this.btnTien500k = new System.Windows.Forms.Button();
            this.pnlActionHD = new System.Windows.Forms.Panel();
            this.btnMoBan = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInTamTinh = new System.Windows.Forms.Button();

            this.pnlTopHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpSoDoBan.SuspendLayout();
            this.pnlFilterBan.SuspendLayout();
            this.pnlThongKeBan.SuspendLayout();
            this.pnlActionBan.SuspendLayout();
            this.grpThucDon.SuspendLayout();
            this.pnlFilterMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).BeginInit();
            this.pnlActionMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongMon)).BeginInit();
            this.grpHoaDon.SuspendLayout();
            this.pnlThongTinBanHienTai.SuspendLayout();
            this.pnlKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.pnlDieuChinhCT.SuspendLayout();
            this.pnlTinhTien.SuspendLayout();
            this.tlpTinhTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).BeginInit();
            this.pnlTienNhanh.SuspendLayout();
            this.pnlActionHD.SuspendLayout();
            this.SuspendLayout();

            // 
            // timerDongHo
            // 
            this.timerDongHo.Interval = 1000;

            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTopHeader.Controls.Add(this.btnLamMoiToanBo);
            this.pnlTopHeader.Controls.Add(this.btnHuongDan);
            this.pnlTopHeader.Controls.Add(this.lblClock);
            this.pnlTopHeader.Controls.Add(this.lblSubtitle);
            this.pnlTopHeader.Controls.Add(this.lblTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Height = 62;
            this.pnlTopHeader.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 6);
            this.lblTitle.Text = "☕ QUẢN LÝ BÁN HÀNG & GỌI MÓN (POS)";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSubtitle.Location = new System.Drawing.Point(16, 36);
            this.lblSubtitle.Text = "Nhân viên: Trần Thị Bình (Phục vụ) | Quán Cafe Nhóm 06";

            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblClock.Location = new System.Drawing.Point(740, 16);
            this.lblClock.Size = new System.Drawing.Size(200, 28);
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClock.Text = "00:00:00 - 01/01/2026";

            // 
            // btnHuongDan
            // 
            this.btnHuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuongDan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnHuongDan.FlatAppearance.BorderSize = 0;
            this.btnHuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuongDan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuongDan.ForeColor = System.Drawing.Color.White;
            this.btnHuongDan.Location = new System.Drawing.Point(950, 12);
            this.btnHuongDan.Size = new System.Drawing.Size(120, 36);
            this.btnHuongDan.Text = "⌨️ Phím tắt (F1)";
            this.btnHuongDan.UseVisualStyleBackColor = false;

            // 
            // btnLamMoiToanBo
            // 
            this.btnLamMoiToanBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoiToanBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLamMoiToanBo.FlatAppearance.BorderSize = 0;
            this.btnLamMoiToanBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiToanBo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiToanBo.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiToanBo.Location = new System.Drawing.Point(1078, 12);
            this.btnLamMoiToanBo.Size = new System.Drawing.Size(108, 36);
            this.btnLamMoiToanBo.Text = "🔄 Làm mới (F5)";
            this.btnLamMoiToanBo.UseVisualStyleBackColor = false;

            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 3;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.pnlMain.Controls.Add(this.grpSoDoBan, 0, 0);
            this.pnlMain.Controls.Add(this.grpThucDon, 1, 0);
            this.pnlMain.Controls.Add(this.grpHoaDon, 2, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);

            // ==========================================
            // CỘT 1: SƠ ĐỒ BÀN
            // ==========================================
            this.grpSoDoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSoDoBan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpSoDoBan.Padding = new System.Windows.Forms.Padding(8);
            this.grpSoDoBan.Text = "🪑 SƠ ĐỒ BÀN";
            this.grpSoDoBan.Controls.Add(this.flpDanhSachBan);
            this.grpSoDoBan.Controls.Add(this.pnlActionBan);
            this.grpSoDoBan.Controls.Add(this.pnlThongKeBan);
            this.grpSoDoBan.Controls.Add(this.pnlFilterBan);

            // pnlFilterBan
            this.pnlFilterBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBan.Height = 100;
            this.pnlFilterBan.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilterBan.Controls.Add(this.cboKhuVuc);
            this.pnlFilterBan.Controls.Add(this.lblLocTrangThai);
            this.pnlFilterBan.Controls.Add(this.cboTrangThaiBan);
            this.pnlFilterBan.Controls.Add(this.lblTimKiemBan);
            this.pnlFilterBan.Controls.Add(this.txtTimKiemBan);

            this.lblLocKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocKhuVuc.Location = new System.Drawing.Point(4, 6);
            this.lblLocKhuVuc.Size = new System.Drawing.Size(72, 24);
            this.lblLocKhuVuc.Text = "Khu vực:";

            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboKhuVuc.Location = new System.Drawing.Point(80, 4);
            this.cboKhuVuc.Size = new System.Drawing.Size(250, 29);

            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(4, 38);
            this.lblLocTrangThai.Size = new System.Drawing.Size(72, 24);
            this.lblLocTrangThai.Text = "Trạng thái:";

            this.cboTrangThaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTrangThaiBan.Location = new System.Drawing.Point(80, 35);
            this.cboTrangThaiBan.Size = new System.Drawing.Size(250, 29);

            this.lblTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiemBan.Location = new System.Drawing.Point(4, 70);
            this.lblTimKiemBan.Size = new System.Drawing.Size(72, 24);
            this.lblTimKiemBan.Text = "Tìm bàn:";

            this.txtTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemBan.Location = new System.Drawing.Point(80, 67);
            this.txtTimKiemBan.Size = new System.Drawing.Size(250, 27);
            this.txtTimKiemBan.PlaceholderText = "Nhập số bàn để chọn nhanh...";

            // pnlThongKeBan
            this.pnlThongKeBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKeBan.Height = 32;
            this.pnlThongKeBan.Controls.Add(this.lblThongKeBan);

            this.lblThongKeBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongKeBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThongKeBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblThongKeBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThongKeBan.Text = "Tổng: 0 | 🟢 Trống: 0 | 🔴 Có khách: 0";

            // flpDanhSachBan
            this.flpDanhSachBan.AutoScroll = true;
            this.flpDanhSachBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.flpDanhSachBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDanhSachBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDanhSachBan.Padding = new System.Windows.Forms.Padding(6);

            // pnlActionBan
            this.pnlActionBan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBan.Height = 44;
            this.pnlActionBan.Controls.Add(this.btnMoBanNhanh);
            this.pnlActionBan.Controls.Add(this.btnChuyenBanNhanh);

            this.btnMoBanNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMoBanNhanh.FlatAppearance.BorderSize = 0;
            this.btnMoBanNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBanNhanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoBanNhanh.ForeColor = System.Drawing.Color.White;
            this.btnMoBanNhanh.Location = new System.Drawing.Point(4, 6);
            this.btnMoBanNhanh.Size = new System.Drawing.Size(155, 32);
            this.btnMoBanNhanh.Text = "🟢 Mở bàn mới";
            this.btnMoBanNhanh.UseVisualStyleBackColor = false;

            this.btnChuyenBanNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChuyenBanNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnChuyenBanNhanh.FlatAppearance.BorderSize = 0;
            this.btnChuyenBanNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBanNhanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChuyenBanNhanh.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBanNhanh.Location = new System.Drawing.Point(170, 6);
            this.btnChuyenBanNhanh.Size = new System.Drawing.Size(155, 32);
            this.btnChuyenBanNhanh.Text = "🔄 Chuyển bàn (F4)";
            this.btnChuyenBanNhanh.UseVisualStyleBackColor = false;

            // ==========================================
            // CỘT 2: THỰC ĐƠN MÓN NƯỚC
            // ==========================================
            this.grpThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThucDon.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpThucDon.Padding = new System.Windows.Forms.Padding(8);
            this.grpThucDon.Text = "☕ THỰC ĐƠN THỨC UỐNG";
            this.grpThucDon.Controls.Add(this.dgvThucUong);
            this.grpThucDon.Controls.Add(this.pnlActionMon);
            this.grpThucDon.Controls.Add(this.pnlFilterMon);

            // pnlFilterMon
            this.pnlFilterMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterMon.Height = 72;
            this.pnlFilterMon.Controls.Add(this.lblTimMon);
            this.pnlFilterMon.Controls.Add(this.txtTimKiemMon);
            this.pnlFilterMon.Controls.Add(this.lblLoaiMon);
            this.pnlFilterMon.Controls.Add(this.cboLoaiMon);

            this.lblTimMon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimMon.Location = new System.Drawing.Point(4, 6);
            this.lblTimMon.Size = new System.Drawing.Size(70, 24);
            this.lblTimMon.Text = "Tìm món:";

            this.txtTimKiemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiemMon.Location = new System.Drawing.Point(76, 4);
            this.txtTimKiemMon.Size = new System.Drawing.Size(280, 29);
            this.txtTimKiemMon.PlaceholderText = "🔍 Tìm kiếm theo tên hoặc mã món...";

            this.lblLoaiMon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiMon.Location = new System.Drawing.Point(4, 40);
            this.lblLoaiMon.Size = new System.Drawing.Size(70, 24);
            this.lblLoaiMon.Text = "Loại món:";

            this.cboLoaiMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLoaiMon.Location = new System.Drawing.Point(76, 36);
            this.cboLoaiMon.Size = new System.Drawing.Size(280, 29);

            // dgvThucUong
            this.dgvThucUong.AllowUserToAddRows = false;
            this.dgvThucUong.AllowUserToDeleteRows = false;
            this.dgvThucUong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThucUong.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucUong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThucUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvThucUong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaTU, this.colTenTU, this.colLoaiTU, this.colDonGia
            });
            this.dgvThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucUong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvThucUong.ReadOnly = true;
            this.dgvThucUong.RowHeadersVisible = false;
            this.dgvThucUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colMaTU.DataPropertyName = "MaThucUong";
            this.colMaTU.HeaderText = "Mã";
            this.colMaTU.FillWeight = 40F;

            this.colTenTU.DataPropertyName = "TenThucUong";
            this.colTenTU.HeaderText = "Tên thức uống";
            this.colTenTU.FillWeight = 110F;

            this.colLoaiTU.DataPropertyName = "TenLoaiTU";
            this.colLoaiTU.HeaderText = "Loại";
            this.colLoaiTU.FillWeight = 65F;

            this.colDonGia.DataPropertyName = "DonGiaBan";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.DefaultCellStyle.Format = "N0";
            this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.FillWeight = 65F;

            // pnlActionMon
            this.pnlActionMon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionMon.Height = 84;
            this.pnlActionMon.Controls.Add(this.lblSoLuong);
            this.pnlActionMon.Controls.Add(this.numSoLuongMon);
            this.pnlActionMon.Controls.Add(this.btnSL1);
            this.pnlActionMon.Controls.Add(this.btnSL2);
            this.pnlActionMon.Controls.Add(this.btnSL5);
            this.pnlActionMon.Controls.Add(this.btnThemMon);
            this.pnlActionMon.Controls.Add(this.btnKiemTraKho);

            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoLuong.Location = new System.Drawing.Point(4, 10);
            this.lblSoLuong.Size = new System.Drawing.Size(65, 26);
            this.lblSoLuong.Text = "Số lượng:";

            this.numSoLuongMon.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.numSoLuongMon.Location = new System.Drawing.Point(74, 8);
            this.numSoLuongMon.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuongMon.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numSoLuongMon.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuongMon.Size = new System.Drawing.Size(60, 31);

            this.btnSL1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSL1.Location = new System.Drawing.Point(140, 8);
            this.btnSL1.Size = new System.Drawing.Size(38, 30);
            this.btnSL1.Text = "+1";

            this.btnSL2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSL2.Location = new System.Drawing.Point(182, 8);
            this.btnSL2.Size = new System.Drawing.Size(38, 30);
            this.btnSL2.Text = "+2";

            this.btnSL5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSL5.Location = new System.Drawing.Point(224, 8);
            this.btnSL5.Size = new System.Drawing.Size(38, 30);
            this.btnSL5.Text = "+5";

            this.btnThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Location = new System.Drawing.Point(4, 44);
            this.btnThemMon.Size = new System.Drawing.Size(258, 36);
            this.btnThemMon.Text = "➕ THÊM VÀO ĐƠN (Enter)";
            this.btnThemMon.UseVisualStyleBackColor = false;

            this.btnKiemTraKho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKiemTraKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnKiemTraKho.FlatAppearance.BorderSize = 0;
            this.btnKiemTraKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKiemTraKho.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraKho.Location = new System.Drawing.Point(268, 44);
            this.btnKiemTraKho.Size = new System.Drawing.Size(100, 36);
            this.btnKiemTraKho.Text = "📦 Tồn kho";
            this.btnKiemTraKho.UseVisualStyleBackColor = false;

            // ==========================================
            // CỘT 3: HÓA ĐƠN & THANH TOÁN BÀN
            // ==========================================
            this.grpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpHoaDon.Padding = new System.Windows.Forms.Padding(8);
            this.grpHoaDon.Text = "🧾 HÓA ĐƠN HIỆN TẠI";
            this.grpHoaDon.Controls.Add(this.dgvChiTietHD);
            this.grpHoaDon.Controls.Add(this.pnlDieuChinhCT);
            this.grpHoaDon.Controls.Add(this.pnlTinhTien);
            this.grpHoaDon.Controls.Add(this.pnlActionHD);
            this.grpHoaDon.Controls.Add(this.pnlKhachHang);
            this.grpHoaDon.Controls.Add(this.pnlThongTinBanHienTai);

            // pnlThongTinBanHienTai
            this.pnlThongTinBanHienTai.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinBanHienTai.Height = 52;
            this.pnlThongTinBanHienTai.Controls.Add(this.lblBanDangChon);
            this.pnlThongTinBanHienTai.Controls.Add(this.lblMaHDHienTai);
            this.pnlThongTinBanHienTai.Controls.Add(this.lblGioVao);

            this.lblBanDangChon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBanDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblBanDangChon.Location = new System.Drawing.Point(4, 4);
            this.lblBanDangChon.Size = new System.Drawing.Size(220, 24);
            this.lblBanDangChon.Text = "BÀN: Chưa chọn";

            this.lblMaHDHienTai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaHDHienTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMaHDHienTai.Location = new System.Drawing.Point(4, 28);
            this.lblMaHDHienTai.Size = new System.Drawing.Size(180, 20);
            this.lblMaHDHienTai.Text = "Mã HĐ: --";

            this.lblGioVao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGioVao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGioVao.Location = new System.Drawing.Point(190, 28);
            this.lblGioVao.Size = new System.Drawing.Size(190, 20);
            this.lblGioVao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGioVao.Text = "Giờ vào: --";

            // pnlKhachHang
            this.pnlKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhachHang.Height = 64;
            this.pnlKhachHang.Controls.Add(this.lblKhachHang);
            this.pnlKhachHang.Controls.Add(this.txtTimKhach);
            this.pnlKhachHang.Controls.Add(this.btnTimKhach);
            this.pnlKhachHang.Controls.Add(this.btnThemKhachNhanh);
            this.pnlKhachHang.Controls.Add(this.btnBoChonKhach);
            this.pnlKhachHang.Controls.Add(this.lblThongTinKhach);

            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachHang.Location = new System.Drawing.Point(4, 6);
            this.lblKhachHang.Size = new System.Drawing.Size(55, 24);
            this.lblKhachHang.Text = "Khách:";

            this.txtTimKhach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKhach.Location = new System.Drawing.Point(60, 4);
            this.txtTimKhach.Size = new System.Drawing.Size(130, 29);
            this.txtTimKhach.PlaceholderText = "SĐT / Tên...";

            this.btnTimKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnTimKhach.FlatAppearance.BorderSize = 0;
            this.btnTimKhach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKhach.ForeColor = System.Drawing.Color.White;
            this.btnTimKhach.Location = new System.Drawing.Point(194, 4);
            this.btnTimKhach.Size = new System.Drawing.Size(52, 29);
            this.btnTimKhach.Text = "Tìm";
            this.btnTimKhach.UseVisualStyleBackColor = false;

            this.btnThemKhachNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemKhachNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnThemKhachNhanh.FlatAppearance.BorderSize = 0;
            this.btnThemKhachNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKhachNhanh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemKhachNhanh.ForeColor = System.Drawing.Color.White;
            this.btnThemKhachNhanh.Location = new System.Drawing.Point(252, 4);
            this.btnThemKhachNhanh.Size = new System.Drawing.Size(70, 29);
            this.btnThemKhachNhanh.Text = "+ Mới";
            this.btnThemKhachNhanh.UseVisualStyleBackColor = false;

            this.btnBoChonKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoChonKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnBoChonKhach.FlatAppearance.BorderSize = 0;
            this.btnBoChonKhach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoChonKhach.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnBoChonKhach.ForeColor = System.Drawing.Color.White;
            this.btnBoChonKhach.Location = new System.Drawing.Point(326, 4);
            this.btnBoChonKhach.Size = new System.Drawing.Size(54, 29);
            this.btnBoChonKhach.Text = "Hủy";
            this.btnBoChonKhach.UseVisualStyleBackColor = false;

            this.lblThongTinKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblThongTinKhach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblThongTinKhach.Location = new System.Drawing.Point(4, 38);
            this.lblThongTinKhach.Size = new System.Drawing.Size(374, 22);
            this.lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";

            // dgvChiTietHD
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTietHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCT_TenMon, this.colCT_SoLuong, this.colCT_DonGia, this.colCT_ThanhTien
            });
            this.dgvChiTietHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietHD.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvChiTietHD.ReadOnly = true;
            this.dgvChiTietHD.RowHeadersVisible = false;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colCT_TenMon.DataPropertyName = "TenThucUong";
            this.colCT_TenMon.HeaderText = "Tên món";
            this.colCT_TenMon.FillWeight = 110F;

            this.colCT_SoLuong.DataPropertyName = "SoLuong";
            this.colCT_SoLuong.HeaderText = "SL";
            this.colCT_SoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCT_SoLuong.FillWeight = 35F;

            this.colCT_DonGia.DataPropertyName = "DonGia";
            this.colCT_DonGia.HeaderText = "Đơn giá";
            this.colCT_DonGia.DefaultCellStyle.Format = "N0";
            this.colCT_DonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCT_DonGia.FillWeight = 60F;

            this.colCT_ThanhTien.DataPropertyName = "ThanhTien";
            this.colCT_ThanhTien.HeaderText = "Thành tiền";
            this.colCT_ThanhTien.DefaultCellStyle.Format = "N0";
            this.colCT_ThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCT_ThanhTien.FillWeight = 75F;

            // pnlDieuChinhCT
            this.pnlDieuChinhCT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDieuChinhCT.Height = 40;
            this.pnlDieuChinhCT.Controls.Add(this.btnTangSL);
            this.pnlDieuChinhCT.Controls.Add(this.btnGiamSL);
            this.pnlDieuChinhCT.Controls.Add(this.btnXoaMon);

            this.btnTangSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnTangSL.FlatAppearance.BorderSize = 0;
            this.btnTangSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTangSL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTangSL.ForeColor = System.Drawing.Color.White;
            this.btnTangSL.Location = new System.Drawing.Point(4, 5);
            this.btnTangSL.Size = new System.Drawing.Size(95, 30);
            this.btnTangSL.Text = "➕ Tăng SL";
            this.btnTangSL.UseVisualStyleBackColor = false;

            this.btnGiamSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnGiamSL.FlatAppearance.BorderSize = 0;
            this.btnGiamSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiamSL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGiamSL.ForeColor = System.Drawing.Color.White;
            this.btnGiamSL.Location = new System.Drawing.Point(105, 5);
            this.btnGiamSL.Size = new System.Drawing.Size(95, 30);
            this.btnGiamSL.Text = "➖ Giảm SL";
            this.btnGiamSL.UseVisualStyleBackColor = false;

            this.btnXoaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnXoaMon.FlatAppearance.BorderSize = 0;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Location = new System.Drawing.Point(260, 5);
            this.btnXoaMon.Size = new System.Drawing.Size(120, 30);
            this.btnXoaMon.Text = "🗑️ Xóa món (Del)";
            this.btnXoaMon.UseVisualStyleBackColor = false;

            // ==========================================
            // Ô TÍNH TIỀN & THANH TOÁN
            // ==========================================
            this.pnlTinhTien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTinhTien.Height = 224;
            this.pnlTinhTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTinhTien.Controls.Add(this.tlpTinhTien);

            this.tlpTinhTien.ColumnCount = 2;
            this.tlpTinhTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpTinhTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpTinhTien.Controls.Add(this.lblTienHangTieuDe, 0, 0);
            this.tlpTinhTien.Controls.Add(this.lblTienHang, 1, 0);
            this.tlpTinhTien.Controls.Add(this.lblGiamGiaTieuDe, 0, 1);
            this.tlpTinhTien.Controls.Add(this.numGiamGia, 1, 1);
            this.tlpTinhTien.Controls.Add(this.lblTongThanhToanTieuDe, 0, 2);
            this.tlpTinhTien.Controls.Add(this.lblTongThanhToan, 1, 2);
            this.tlpTinhTien.Controls.Add(this.lblPhuongThucTieuDe, 0, 3);
            this.tlpTinhTien.Controls.Add(this.cboPhuongThuc, 1, 3);
            this.tlpTinhTien.Controls.Add(this.lblTienKhachDuaTieuDe, 0, 4);
            this.tlpTinhTien.Controls.Add(this.numTienKhachDua, 1, 4);
            this.tlpTinhTien.Controls.Add(this.pnlTienNhanh, 1, 5);
            this.tlpTinhTien.Controls.Add(this.lblTienThoiTieuDe, 0, 6);
            this.tlpTinhTien.Controls.Add(this.lblTienThoi, 1, 6);
            this.tlpTinhTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTinhTien.RowCount = 7;
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));

            // lblTienHangTieuDe
            this.lblTienHangTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienHangTieuDe.Location = new System.Drawing.Point(4, 2);
            this.lblTienHangTieuDe.Text = "Tổng tiền hàng:";

            // lblTienHang
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.Location = new System.Drawing.Point(140, 2);
            this.lblTienHang.Size = new System.Drawing.Size(230, 22);
            this.lblTienHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienHang.Text = "0 đ";

            // lblGiamGiaTieuDe
            this.lblGiamGiaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiamGiaTieuDe.Location = new System.Drawing.Point(4, 29);
            this.lblGiamGiaTieuDe.Text = "Giảm giá:";

            // numGiamGia
            this.numGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numGiamGia.Location = new System.Drawing.Point(140, 29);
            this.numGiamGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiamGia.Size = new System.Drawing.Size(230, 29);
            this.numGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiamGia.ThousandsSeparator = true;

            // lblTongThanhToanTieuDe
            this.lblTongThanhToanTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToanTieuDe.Location = new System.Drawing.Point(4, 59);
            this.lblTongThanhToanTieuDe.Text = "TỔNG CỘNG:";

            // lblTongThanhToan
            this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTongThanhToan.Location = new System.Drawing.Point(140, 59);
            this.lblTongThanhToan.Size = new System.Drawing.Size(230, 28);
            this.lblTongThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongThanhToan.Text = "0 đ";

            // lblPhuongThucTieuDe
            this.lblPhuongThucTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhuongThucTieuDe.Location = new System.Drawing.Point(4, 93);
            this.lblPhuongThucTieuDe.Text = "Phương thức:";

            // cboPhuongThuc
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPhuongThuc.Location = new System.Drawing.Point(140, 93);
            this.cboPhuongThuc.Size = new System.Drawing.Size(230, 29);

            // lblTienKhachDuaTieuDe
            this.lblTienKhachDuaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienKhachDuaTieuDe.Location = new System.Drawing.Point(4, 123);
            this.lblTienKhachDuaTieuDe.Text = "Tiền khách đưa:";

            // numTienKhachDua
            this.numTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.numTienKhachDua.Location = new System.Drawing.Point(140, 123);
            this.numTienKhachDua.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTienKhachDua.Size = new System.Drawing.Size(230, 30);
            this.numTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTienKhachDua.ThousandsSeparator = true;

            // pnlTienNhanh
            this.pnlTienNhanh.Controls.Add(this.btnTienVuaDu);
            this.pnlTienNhanh.Controls.Add(this.btnTien20k);
            this.pnlTienNhanh.Controls.Add(this.btnTien50k);
            this.pnlTienNhanh.Controls.Add(this.btnTien100k);
            this.pnlTienNhanh.Controls.Add(this.btnTien200k);
            this.pnlTienNhanh.Controls.Add(this.btnTien500k);
            this.pnlTienNhanh.Location = new System.Drawing.Point(140, 153);
            this.pnlTienNhanh.Size = new System.Drawing.Size(240, 32);

            this.btnTienVuaDu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTienVuaDu.Size = new System.Drawing.Size(52, 26);
            this.btnTienVuaDu.Text = "Vừa đủ";

            this.btnTien20k.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTien20k.Size = new System.Drawing.Size(34, 26);
            this.btnTien20k.Text = "20k";

            this.btnTien50k.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTien50k.Size = new System.Drawing.Size(34, 26);
            this.btnTien50k.Text = "50k";

            this.btnTien100k.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTien100k.Size = new System.Drawing.Size(36, 26);
            this.btnTien100k.Text = "100k";

            this.btnTien200k.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTien200k.Size = new System.Drawing.Size(36, 26);
            this.btnTien200k.Text = "200k";

            this.btnTien500k.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTien500k.Size = new System.Drawing.Size(36, 26);
            this.btnTien500k.Text = "500k";

            // lblTienThoiTieuDe
            this.lblTienThoiTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienThoiTieuDe.Location = new System.Drawing.Point(4, 187);
            this.lblTienThoiTieuDe.Text = "Tiền thối lại:";

            // lblTienThoi
            this.lblTienThoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTienThoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblTienThoi.Location = new System.Drawing.Point(140, 187);
            this.lblTienThoi.Size = new System.Drawing.Size(230, 24);
            this.lblTienThoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienThoi.Text = "0 đ";

            // pnlActionHD
            this.pnlActionHD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionHD.Height = 90;
            this.pnlActionHD.Controls.Add(this.btnMoBan);
            this.pnlActionHD.Controls.Add(this.btnChuyenBan);
            this.pnlActionHD.Controls.Add(this.btnHuyDon);
            this.pnlActionHD.Controls.Add(this.btnThanhToan);
            this.pnlActionHD.Controls.Add(this.btnInTamTinh);

            this.btnMoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMoBan.FlatAppearance.BorderSize = 0;
            this.btnMoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMoBan.ForeColor = System.Drawing.Color.White;
            this.btnMoBan.Location = new System.Drawing.Point(4, 6);
            this.btnMoBan.Size = new System.Drawing.Size(115, 34);
            this.btnMoBan.Text = "🟢 Mở bàn";
            this.btnMoBan.UseVisualStyleBackColor = false;

            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnChuyenBan.FlatAppearance.BorderSize = 0;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBan.Location = new System.Drawing.Point(125, 6);
            this.btnChuyenBan.Size = new System.Drawing.Size(125, 34);
            this.btnChuyenBan.Text = "🔄 Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;

            this.btnHuyDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnHuyDon.FlatAppearance.BorderSize = 0;
            this.btnHuyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuyDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyDon.Location = new System.Drawing.Point(256, 6);
            this.btnHuyDon.Size = new System.Drawing.Size(120, 34);
            this.btnHuyDon.Text = "❌ Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = false;

            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(4, 44);
            this.btnThanhToan.Size = new System.Drawing.Size(246, 40);
            this.btnThanhToan.Text = "💳 THANH TOÁN (F9)";
            this.btnThanhToan.UseVisualStyleBackColor = false;

            this.btnInTamTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInTamTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnInTamTinh.FlatAppearance.BorderSize = 0;
            this.btnInTamTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTamTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInTamTinh.ForeColor = System.Drawing.Color.White;
            this.btnInTamTinh.Location = new System.Drawing.Point(256, 44);
            this.btnInTamTinh.Size = new System.Drawing.Size(120, 40);
            this.btnInTamTinh.Text = "🧾 Tạm tính (F8)";
            this.btnInTamTinh.UseVisualStyleBackColor = false;

            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Quản lý Bán hàng & Gọi món";

            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpSoDoBan.ResumeLayout(false);
            this.pnlFilterBan.ResumeLayout(false);
            this.pnlFilterBan.PerformLayout();
            this.pnlThongKeBan.ResumeLayout(false);
            this.pnlActionBan.ResumeLayout(false);
            this.grpThucDon.ResumeLayout(false);
            this.pnlFilterMon.ResumeLayout(false);
            this.pnlFilterMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).EndInit();
            this.pnlActionMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongMon)).EndInit();
            this.grpHoaDon.ResumeLayout(false);
            this.pnlThongTinBanHienTai.ResumeLayout(false);
            this.pnlKhachHang.ResumeLayout(false);
            this.pnlKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.pnlDieuChinhCT.ResumeLayout(false);
            this.pnlTinhTien.ResumeLayout(false);
            this.tlpTinhTien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).EndInit();
            this.pnlTienNhanh.ResumeLayout(false);
            this.pnlActionHD.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerDongHo;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnHuongDan;
        private System.Windows.Forms.Button btnLamMoiToanBo;
        private System.Windows.Forms.TableLayoutPanel pnlMain;
        private System.Windows.Forms.GroupBox grpSoDoBan;
        private System.Windows.Forms.Panel pnlFilterBan;
        private System.Windows.Forms.Label lblLocKhuVuc;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThaiBan;
        private System.Windows.Forms.Label lblTimKiemBan;
        private System.Windows.Forms.TextBox txtTimKiemBan;
        private System.Windows.Forms.Panel pnlThongKeBan;
        private System.Windows.Forms.Label lblThongKeBan;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
        private System.Windows.Forms.Panel pnlActionBan;
        private System.Windows.Forms.Button btnMoBanNhanh;
        private System.Windows.Forms.Button btnChuyenBanNhanh;
        private System.Windows.Forms.GroupBox grpThucDon;
        private System.Windows.Forms.Panel pnlFilterMon;
        private System.Windows.Forms.Label lblTimMon;
        private System.Windows.Forms.TextBox txtTimKiemMon;
        private System.Windows.Forms.Label lblLoaiMon;
        private System.Windows.Forms.ComboBox cboLoaiMon;
        private System.Windows.Forms.DataGridView dgvThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.Panel pnlActionMon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuongMon;
        private System.Windows.Forms.Button btnSL1;
        private System.Windows.Forms.Button btnSL2;
        private System.Windows.Forms.Button btnSL5;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnKiemTraKho;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Panel pnlThongTinBanHienTai;
        private System.Windows.Forms.Label lblBanDangChon;
        private System.Windows.Forms.Label lblMaHDHienTai;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Panel pnlKhachHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TextBox txtTimKhach;
        private System.Windows.Forms.Button btnTimKhach;
        private System.Windows.Forms.Button btnThemKhachNhanh;
        private System.Windows.Forms.Button btnBoChonKhach;
        private System.Windows.Forms.Label lblThongTinKhach;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_ThanhTien;
        private System.Windows.Forms.Panel pnlDieuChinhCT;
        private System.Windows.Forms.Button btnTangSL;
        private System.Windows.Forms.Button btnGiamSL;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Panel pnlTinhTien;
        private System.Windows.Forms.TableLayoutPanel tlpTinhTien;
        private System.Windows.Forms.Label lblTienHangTieuDe;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Label lblGiamGiaTieuDe;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Label lblTongThanhToanTieuDe;
        private System.Windows.Forms.Label lblTongThanhToan;
        private System.Windows.Forms.Label lblPhuongThucTieuDe;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Label lblTienKhachDuaTieuDe;
        private System.Windows.Forms.NumericUpDown numTienKhachDua;
        private System.Windows.Forms.FlowLayoutPanel pnlTienNhanh;
        private System.Windows.Forms.Button btnTienVuaDu;
        private System.Windows.Forms.Button btnTien20k;
        private System.Windows.Forms.Button btnTien50k;
        private System.Windows.Forms.Button btnTien100k;
        private System.Windows.Forms.Button btnTien200k;
        private System.Windows.Forms.Button btnTien500k;
        private System.Windows.Forms.Label lblTienThoiTieuDe;
        private System.Windows.Forms.Label lblTienThoi;
        private System.Windows.Forms.Panel pnlActionHD;
        private System.Windows.Forms.Button btnMoBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnInTamTinh;
    }
}
