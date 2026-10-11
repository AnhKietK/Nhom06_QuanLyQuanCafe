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
            this.flpTrangThaiBanChips = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlThongKeBan = new System.Windows.Forms.Panel();
            this.lblThongKeBan = new System.Windows.Forms.Label();
            this.flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlActionBan = new System.Windows.Forms.Panel();
            this.tlpActionBan = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoBanNhanh = new System.Windows.Forms.Button();
            this.btnChuyenBanNhanh = new System.Windows.Forms.Button();

            // Cột 2: Thực đơn
            this.grpThucDon = new System.Windows.Forms.GroupBox();
            this.pnlThucDonHeader = new System.Windows.Forms.Panel();
            this.lblTieuDeThucDon = new System.Windows.Forms.Label();
            this.btnDoiCheDoXem = new System.Windows.Forms.Button();
            this.pnlFilterMon = new System.Windows.Forms.Panel();
            this.lblTimMon = new System.Windows.Forms.Label();
            this.txtTimKiemMon = new System.Windows.Forms.TextBox();
            this.flpLoaiMonChips = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLoaiMon = new System.Windows.Forms.Label();
            this.cboLoaiMon = new System.Windows.Forms.ComboBox();
            this.pnlThucDonContent = new System.Windows.Forms.Panel();
            this.flpThucDonCards = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvThucUong = new System.Windows.Forms.DataGridView();
            this.colMaTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlActionMon = new System.Windows.Forms.Panel();
            this.pnlStepperMon = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.btnGiamSLMon = new System.Windows.Forms.Button();
            this.numSoLuongMon = new System.Windows.Forms.NumericUpDown();
            this.btnTangSLMon = new System.Windows.Forms.Button();
            this.btnSL1 = new System.Windows.Forms.Button();
            this.btnSL2 = new System.Windows.Forms.Button();
            this.btnSL5 = new System.Windows.Forms.Button();
            this.tlpActionMonButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnKiemTraKho = new System.Windows.Forms.Button();

            // Cột 3: Hóa đơn & Thanh toán
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.pnlThongTinBanHienTai = new System.Windows.Forms.Panel();
            this.tlpThongTinBan = new System.Windows.Forms.TableLayoutPanel();
            this.lblBanDangChon = new System.Windows.Forms.Label();
            this.lblMaHDHienTai = new System.Windows.Forms.Label();
            this.lblGioVao = new System.Windows.Forms.Label();
            this.pnlKhachHang = new System.Windows.Forms.Panel();
            this.tlpTimKhach = new System.Windows.Forms.TableLayoutPanel();
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
            this.tlpDieuChinhCT = new System.Windows.Forms.TableLayoutPanel();
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
            this.pnlTienNhanh = new System.Windows.Forms.TableLayoutPanel();
            this.btnTienVuaDu = new System.Windows.Forms.Button();
            this.btnTien20k = new System.Windows.Forms.Button();
            this.btnTien50k = new System.Windows.Forms.Button();
            this.btnTien100k = new System.Windows.Forms.Button();
            this.btnTien200k = new System.Windows.Forms.Button();
            this.btnTien500k = new System.Windows.Forms.Button();
            this.pnlActionHD = new System.Windows.Forms.Panel();
            this.tlpActionHD = new System.Windows.Forms.TableLayoutPanel();
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
            this.tlpActionBan.SuspendLayout();
            this.grpThucDon.SuspendLayout();
            this.pnlThucDonHeader.SuspendLayout();
            this.pnlFilterMon.SuspendLayout();
            this.pnlThucDonContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).BeginInit();
            this.pnlActionMon.SuspendLayout();
            this.pnlStepperMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongMon)).BeginInit();
            this.tlpActionMonButtons.SuspendLayout();
            this.grpHoaDon.SuspendLayout();
            this.pnlThongTinBanHienTai.SuspendLayout();
            this.tlpThongTinBan.SuspendLayout();
            this.pnlKhachHang.SuspendLayout();
            this.tlpTimKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.pnlDieuChinhCT.SuspendLayout();
            this.tlpDieuChinhCT.SuspendLayout();
            this.pnlTinhTien.SuspendLayout();
            this.tlpTinhTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).BeginInit();
            this.pnlTienNhanh.SuspendLayout();
            this.pnlActionHD.SuspendLayout();
            this.tlpActionHD.SuspendLayout();
            this.SuspendLayout();

            // 
            // timerDongHo
            // 
            this.timerDongHo.Interval = 1000;

            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(29)))));
            this.pnlTopHeader.Controls.Add(this.btnLamMoiToanBo);
            this.pnlTopHeader.Controls.Add(this.btnHuongDan);
            this.pnlTopHeader.Controls.Add(this.lblClock);
            this.pnlTopHeader.Controls.Add(this.lblSubtitle);
            this.pnlTopHeader.Controls.Add(this.lblTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Height = 58;
            this.pnlTopHeader.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 5);
            this.lblTitle.Text = "☕ QUẢN LÝ BÁN HÀNG & GỌI MÓN (POS)";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(200)))), ((int)(((byte)(188)))));
            this.lblSubtitle.Location = new System.Drawing.Point(16, 33);
            this.lblSubtitle.Text = "Nhân viên: Trần Thị Bình (Phục vụ) | Quán Cafe Nhóm 06";

            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(184)))), ((int)(((byte)(120)))));
            this.lblClock.Location = new System.Drawing.Point(740, 14);
            this.lblClock.Size = new System.Drawing.Size(200, 28);
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClock.Text = "00:00:00 - 01/01/2026";

            // 
            // btnHuongDan
            // 
            this.btnHuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuongDan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.btnHuongDan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(73)))), ((int)(((byte)(64)))));
            this.btnHuongDan.FlatAppearance.BorderSize = 1;
            this.btnHuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuongDan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnHuongDan.Location = new System.Drawing.Point(950, 12);
            this.btnHuongDan.Size = new System.Drawing.Size(120, 34);
            this.btnHuongDan.Text = "⌨ Phím tắt (F1)";
            this.btnHuongDan.UseVisualStyleBackColor = false;

            // 
            // btnLamMoiToanBo
            // 
            this.btnLamMoiToanBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoiToanBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnLamMoiToanBo.FlatAppearance.BorderSize = 0;
            this.btnLamMoiToanBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiToanBo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoiToanBo.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiToanBo.Location = new System.Drawing.Point(1078, 12);
            this.btnLamMoiToanBo.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoiToanBo.Text = "🔄 Làm mới (F5)";
            this.btnLamMoiToanBo.UseVisualStyleBackColor = false;

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.pnlMain.ColumnCount = 3;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.pnlMain.Controls.Add(this.grpSoDoBan, 0, 0);
            this.pnlMain.Controls.Add(this.grpThucDon, 1, 0);
            this.pnlMain.Controls.Add(this.grpHoaDon, 2, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(8);

            // ==========================================
            // CỘT 1: SƠ ĐỒ BÀN
            // ==========================================
            this.grpSoDoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSoDoBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSoDoBan.BackColor = System.Drawing.Color.White;
            this.grpSoDoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.grpSoDoBan.Padding = new System.Windows.Forms.Padding(8);
            this.grpSoDoBan.Text = "SƠ ĐỒ BÀN";
            this.grpSoDoBan.Controls.Add(this.flpDanhSachBan);
            this.grpSoDoBan.Controls.Add(this.pnlActionBan);
            this.grpSoDoBan.Controls.Add(this.pnlThongKeBan);
            this.grpSoDoBan.Controls.Add(this.pnlFilterBan);
            this.flpDanhSachBan.SendToBack();

            // pnlFilterBan
            this.pnlFilterBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBan.Height = 126;
            this.pnlFilterBan.Controls.Add(this.flpTrangThaiBanChips);
            this.pnlFilterBan.Controls.Add(this.cboKhuVuc);
            this.pnlFilterBan.Controls.Add(this.lblLocKhuVuc);
            this.pnlFilterBan.Controls.Add(this.txtTimKiemBan);
            this.pnlFilterBan.Controls.Add(this.lblTimKiemBan);
            this.pnlFilterBan.Controls.Add(this.cboTrangThaiBan);
            this.pnlFilterBan.Controls.Add(this.lblLocTrangThai);

            this.lblTimKiemBan.Visible = false;

            this.txtTimKiemBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiemBan.Location = new System.Drawing.Point(4, 4);
            this.txtTimKiemBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemBan.Size = new System.Drawing.Size(326, 29);
            this.txtTimKiemBan.PlaceholderText = "🔍 Tìm nhanh theo số bàn hoặc khu vực...";

            this.lblLocKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocKhuVuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblLocKhuVuc.Location = new System.Drawing.Point(4, 40);
            this.lblLocKhuVuc.Size = new System.Drawing.Size(64, 24);
            this.lblLocKhuVuc.Text = "Khu vực:";

            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhuVuc.Location = new System.Drawing.Point(70, 37);
            this.cboKhuVuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhuVuc.Size = new System.Drawing.Size(260, 28);

            this.lblLocTrangThai.Visible = false;
            this.cboTrangThaiBan.Visible = false;

            this.flpTrangThaiBanChips.Location = new System.Drawing.Point(4, 70);
            this.flpTrangThaiBanChips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTrangThaiBanChips.Size = new System.Drawing.Size(326, 50);
            this.flpTrangThaiBanChips.WrapContents = false;
            this.flpTrangThaiBanChips.AutoScroll = true;
            this.flpTrangThaiBanChips.Tag = "NoTheme";

            // pnlThongKeBan
            this.pnlThongKeBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongKeBan.Height = 30;
            this.pnlThongKeBan.Controls.Add(this.lblThongKeBan);

            this.lblThongKeBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongKeBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.lblThongKeBan.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblThongKeBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblThongKeBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongKeBan.Text = "Tổng: 0 | 🟢 Trống: 0 | 🔴 Có khách: 0";

            // flpDanhSachBan
            this.flpDanhSachBan.AutoScroll = true;
            this.flpDanhSachBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.flpDanhSachBan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flpDanhSachBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDanhSachBan.Padding = new System.Windows.Forms.Padding(8, 12, 8, 8);
            this.flpDanhSachBan.Tag = "NoTheme";

            // pnlActionBan
            this.pnlActionBan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBan.Height = 46;
            this.pnlActionBan.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlActionBan.Controls.Add(this.tlpActionBan);

            // tlpActionBan
            this.tlpActionBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActionBan.ColumnCount = 2;
            this.tlpActionBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpActionBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpActionBan.Controls.Add(this.btnMoBanNhanh, 0, 0);
            this.tlpActionBan.Controls.Add(this.btnChuyenBanNhanh, 1, 0);

            this.btnMoBanNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoBanNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(125)))), ((int)(((byte)(91)))));
            this.btnMoBanNhanh.FlatAppearance.BorderSize = 0;
            this.btnMoBanNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBanNhanh.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnMoBanNhanh.ForeColor = System.Drawing.Color.White;
            this.btnMoBanNhanh.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.btnMoBanNhanh.Text = "🟢 Mở bàn mới";
            this.btnMoBanNhanh.UseVisualStyleBackColor = false;

            this.btnChuyenBanNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenBanNhanh.BackColor = System.Drawing.Color.White;
            this.btnChuyenBanNhanh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnChuyenBanNhanh.FlatAppearance.BorderSize = 1;
            this.btnChuyenBanNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBanNhanh.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnChuyenBanNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnChuyenBanNhanh.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.btnChuyenBanNhanh.Text = "🔄 Chuyển bàn (F4)";
            this.btnChuyenBanNhanh.UseVisualStyleBackColor = false;

            // ==========================================
            // CỘT 2: THỰC ĐƠN MÓN NƯỚC
            // ==========================================
            this.grpThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThucDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThucDon.BackColor = System.Drawing.Color.White;
            this.grpThucDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.grpThucDon.Padding = new System.Windows.Forms.Padding(8);
            this.grpThucDon.Text = "THỰC ĐƠN THỨC UỐNG";
            this.grpThucDon.Controls.Add(this.pnlThucDonContent);
            this.grpThucDon.Controls.Add(this.pnlActionMon);
            this.grpThucDon.Controls.Add(this.pnlFilterMon);
            this.grpThucDon.Controls.Add(this.pnlThucDonHeader);
            this.pnlThucDonContent.SendToBack();

            // pnlThucDonHeader
            this.pnlThucDonHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThucDonHeader.Height = 32;
            this.pnlThucDonHeader.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlThucDonHeader.Controls.Add(this.btnDoiCheDoXem);
            this.pnlThucDonHeader.Controls.Add(this.lblTieuDeThucDon);

            this.lblTieuDeThucDon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTieuDeThucDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeThucDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.lblTieuDeThucDon.Location = new System.Drawing.Point(2, 2);
            this.lblTieuDeThucDon.Size = new System.Drawing.Size(200, 28);
            this.lblTieuDeThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTieuDeThucDon.Text = "☕ DANH SÁCH MÓN";

            this.btnDoiCheDoXem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDoiCheDoXem.BackColor = System.Drawing.Color.White;
            this.btnDoiCheDoXem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(200)))), ((int)(((byte)(188)))));
            this.btnDoiCheDoXem.FlatAppearance.BorderSize = 1;
            this.btnDoiCheDoXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiCheDoXem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDoiCheDoXem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.btnDoiCheDoXem.Location = new System.Drawing.Point(310, 2);
            this.btnDoiCheDoXem.Size = new System.Drawing.Size(96, 28);
            this.btnDoiCheDoXem.Text = "☰ Dạng bảng";
            this.btnDoiCheDoXem.UseVisualStyleBackColor = false;

            // pnlFilterMon
            this.pnlFilterMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterMon.Height = 92;
            this.pnlFilterMon.Controls.Add(this.flpLoaiMonChips);
            this.pnlFilterMon.Controls.Add(this.txtTimKiemMon);
            this.pnlFilterMon.Controls.Add(this.lblTimMon);
            this.pnlFilterMon.Controls.Add(this.lblLoaiMon);
            this.pnlFilterMon.Controls.Add(this.cboLoaiMon);

            this.lblTimMon.Visible = false;
            this.lblLoaiMon.Visible = false;
            this.cboLoaiMon.Visible = false;

            this.txtTimKiemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiemMon.Location = new System.Drawing.Point(4, 4);
            this.txtTimKiemMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemMon.Size = new System.Drawing.Size(400, 29);
            this.txtTimKiemMon.PlaceholderText = "🔍 Tìm kiếm theo tên hoặc mã món...";

            this.flpLoaiMonChips.Location = new System.Drawing.Point(4, 38);
            this.flpLoaiMonChips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flpLoaiMonChips.Size = new System.Drawing.Size(400, 50);
            this.flpLoaiMonChips.WrapContents = false;
            this.flpLoaiMonChips.AutoScroll = true;
            this.flpLoaiMonChips.Tag = "NoTheme";

            // pnlThucDonContent
            this.pnlThucDonContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThucDonContent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlThucDonContent.Controls.Add(this.flpThucDonCards);
            this.pnlThucDonContent.Controls.Add(this.dgvThucUong);

            // flpThucDonCards
            this.flpThucDonCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThucDonCards.AutoScroll = true;
            this.flpThucDonCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.flpThucDonCards.Padding = new System.Windows.Forms.Padding(6);
            this.flpThucDonCards.Tag = "NoTheme";

            // dgvThucUong
            this.dgvThucUong.AllowUserToAddRows = false;
            this.dgvThucUong.AllowUserToDeleteRows = false;
            this.dgvThucUong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThucUong.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucUong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThucUong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThucUong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.dgvThucUong.EnableHeadersVisualStyles = false;
            this.dgvThucUong.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.dgvThucUong.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.dgvThucUong.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.dgvThucUong.ColumnHeadersHeight = 36;
            this.dgvThucUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvThucUong.RowTemplate.Height = 36;
            this.dgvThucUong.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(230)))));
            this.dgvThucUong.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.dgvThucUong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaTU, this.colTenTU, this.colLoaiTU, this.colDonGia
            });
            this.dgvThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucUong.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.dgvThucUong.ReadOnly = true;
            this.dgvThucUong.RowHeadersVisible = false;
            this.dgvThucUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucUong.Visible = false;
            this.dgvThucUong.Tag = "NoTheme";

            this.colMaTU.DataPropertyName = "MaThucUong";
            this.colMaTU.HeaderText = "Mã";
            this.colMaTU.FillWeight = 40F;

            this.colTenTU.DataPropertyName = "TenThucUong";
            this.colTenTU.HeaderText = "Tên món";
            this.colTenTU.FillWeight = 110F;

            this.colLoaiTU.DataPropertyName = "TenLoaiTU";
            this.colLoaiTU.HeaderText = "Nhóm";
            this.colLoaiTU.FillWeight = 65F;

            this.colDonGia.DataPropertyName = "DonGiaBan";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.DefaultCellStyle.Format = "N0";
            this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.FillWeight = 65F;

            // pnlActionMon
            this.pnlActionMon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionMon.Height = 88;
            this.pnlActionMon.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlActionMon.Controls.Add(this.tlpActionMonButtons);
            this.pnlActionMon.Controls.Add(this.pnlStepperMon);

            // pnlStepperMon
            this.pnlStepperMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStepperMon.Height = 36;
            this.pnlStepperMon.Controls.Add(this.lblSoLuong);
            this.pnlStepperMon.Controls.Add(this.btnGiamSLMon);
            this.pnlStepperMon.Controls.Add(this.numSoLuongMon);
            this.pnlStepperMon.Controls.Add(this.btnTangSLMon);
            this.pnlStepperMon.Controls.Add(this.btnSL1);
            this.pnlStepperMon.Controls.Add(this.btnSL2);
            this.pnlStepperMon.Controls.Add(this.btnSL5);

            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.lblSoLuong.Location = new System.Drawing.Point(4, 7);
            this.lblSoLuong.Size = new System.Drawing.Size(65, 22);
            this.lblSoLuong.Text = "Số lượng:";

            this.btnGiamSLMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGiamSLMon.Location = new System.Drawing.Point(72, 3);
            this.btnGiamSLMon.Size = new System.Drawing.Size(30, 28);
            this.btnGiamSLMon.Text = "－";
            this.btnGiamSLMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.btnGiamSLMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiamSLMon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));

            this.numSoLuongMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.numSoLuongMon.Location = new System.Drawing.Point(104, 3);
            this.numSoLuongMon.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuongMon.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numSoLuongMon.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuongMon.Size = new System.Drawing.Size(50, 28);
            this.numSoLuongMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.btnTangSLMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTangSLMon.Location = new System.Drawing.Point(156, 3);
            this.btnTangSLMon.Size = new System.Drawing.Size(30, 28);
            this.btnTangSLMon.Text = "＋";
            this.btnTangSLMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.btnTangSLMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTangSLMon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));

            this.btnSL1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSL1.Location = new System.Drawing.Point(196, 3);
            this.btnSL1.Size = new System.Drawing.Size(36, 28);
            this.btnSL1.Text = "+1";
            this.btnSL1.BackColor = System.Drawing.Color.White;
            this.btnSL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSL1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));

            this.btnSL2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSL2.Location = new System.Drawing.Point(234, 3);
            this.btnSL2.Size = new System.Drawing.Size(36, 28);
            this.btnSL2.Text = "+2";
            this.btnSL2.BackColor = System.Drawing.Color.White;
            this.btnSL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSL2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));

            this.btnSL5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSL5.Location = new System.Drawing.Point(272, 3);
            this.btnSL5.Size = new System.Drawing.Size(36, 28);
            this.btnSL5.Text = "+5";
            this.btnSL5.BackColor = System.Drawing.Color.White;
            this.btnSL5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSL5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));

            // tlpActionMonButtons
            this.tlpActionMonButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpActionMonButtons.Height = 44;
            this.tlpActionMonButtons.ColumnCount = 2;
            this.tlpActionMonButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tlpActionMonButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpActionMonButtons.Controls.Add(this.btnThemMon, 0, 0);
            this.tlpActionMonButtons.Controls.Add(this.btnKiemTraKho, 1, 0);

            this.btnThemMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnThemMon.FlatAppearance.BorderSize = 0;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemMon.ForeColor = System.Drawing.Color.White;
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.btnThemMon.Text = "➕ THÊM VÀO ĐƠN (Enter)";
            this.btnThemMon.UseVisualStyleBackColor = false;

            this.btnKiemTraKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKiemTraKho.BackColor = System.Drawing.Color.White;
            this.btnKiemTraKho.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(200)))), ((int)(((byte)(188)))));
            this.btnKiemTraKho.FlatAppearance.BorderSize = 1;
            this.btnKiemTraKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKiemTraKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.btnKiemTraKho.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.btnKiemTraKho.Text = "📦 Tồn kho";
            this.btnKiemTraKho.UseVisualStyleBackColor = false;

            // ==========================================
            // CỘT 3: HÓA ĐƠN & THANH TOÁN BÀN
            // ==========================================
            this.grpHoaDon.BackColor = System.Drawing.Color.White;
            this.grpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.grpHoaDon.Padding = new System.Windows.Forms.Padding(6);
            this.grpHoaDon.Text = "🧾 HÓA ĐƠN & THANH TOÁN";
            this.grpHoaDon.Controls.Add(this.dgvChiTietHD);
            this.grpHoaDon.Controls.Add(this.pnlDieuChinhCT);
            this.grpHoaDon.Controls.Add(this.pnlTinhTien);
            this.grpHoaDon.Controls.Add(this.pnlActionHD);
            this.grpHoaDon.Controls.Add(this.pnlKhachHang);
            this.grpHoaDon.Controls.Add(this.pnlThongTinBanHienTai);

            // ------------------------------------------
            // 3.1 THÔNG TIN BÀN HIỆN TẠI (Header Card)
            // ------------------------------------------
            this.pnlThongTinBanHienTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.pnlThongTinBanHienTai.Controls.Add(this.tlpThongTinBan);
            this.pnlThongTinBanHienTai.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinBanHienTai.Height = 48;
            this.pnlThongTinBanHienTai.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

            this.tlpThongTinBan.ColumnCount = 3;
            this.tlpThongTinBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpThongTinBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpThongTinBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpThongTinBan.Controls.Add(this.lblBanDangChon, 0, 0);
            this.tlpThongTinBan.Controls.Add(this.lblMaHDHienTai, 1, 0);
            this.tlpThongTinBan.Controls.Add(this.lblGioVao, 2, 0);
            this.tlpThongTinBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTinBan.RowCount = 1;
            this.tlpThongTinBan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblBanDangChon.AutoEllipsis = true;
            this.lblBanDangChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanDangChon.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblBanDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.lblBanDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBanDangChon.Text = "BÀN: Chưa chọn";

            this.lblMaHDHienTai.AutoEllipsis = true;
            this.lblMaHDHienTai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHDHienTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHDHienTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblMaHDHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaHDHienTai.Text = "Mã HĐ: --";

            this.lblGioVao.AutoEllipsis = true;
            this.lblGioVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioVao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGioVao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblGioVao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGioVao.Text = "Giờ vào: --";

            // ------------------------------------------
            // 3.2 KHÁCH HÀNG & THÀNH VIÊN
            // ------------------------------------------
            this.pnlKhachHang.BackColor = System.Drawing.Color.White;
            this.pnlKhachHang.Controls.Add(this.lblThongTinKhach);
            this.pnlKhachHang.Controls.Add(this.tlpTimKhach);
            this.pnlKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhachHang.Height = 68;
            this.pnlKhachHang.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);

            this.tlpTimKhach.ColumnCount = 5;
            this.tlpTimKhach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpTimKhach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimKhach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpTimKhach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTimKhach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlpTimKhach.Controls.Add(this.lblKhachHang, 0, 0);
            this.tlpTimKhach.Controls.Add(this.txtTimKhach, 1, 0);
            this.tlpTimKhach.Controls.Add(this.btnTimKhach, 2, 0);
            this.tlpTimKhach.Controls.Add(this.btnThemKhachNhanh, 3, 0);
            this.tlpTimKhach.Controls.Add(this.btnBoChonKhach, 4, 0);
            this.tlpTimKhach.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTimKhach.Height = 32;
            this.tlpTimKhach.RowCount = 1;
            this.tlpTimKhach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKhachHang.Text = "Khách:";

            this.txtTimKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTimKhach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKhach.Margin = new System.Windows.Forms.Padding(0, 1, 4, 1);
            this.txtTimKhach.PlaceholderText = "SĐT / Tên...";

            this.btnTimKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTimKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTimKhach.FlatAppearance.BorderSize = 0;
            this.btnTimKhach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKhach.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKhach.ForeColor = System.Drawing.Color.White;
            this.btnTimKhach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnTimKhach.Text = "🔍 Tìm";
            this.btnTimKhach.UseVisualStyleBackColor = false;

            this.btnThemKhachNhanh.BackColor = System.Drawing.Color.White;
            this.btnThemKhachNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemKhachNhanh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnThemKhachNhanh.FlatAppearance.BorderSize = 1;
            this.btnThemKhachNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKhachNhanh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThemKhachNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnThemKhachNhanh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnThemKhachNhanh.Text = "+ Mới";
            this.btnThemKhachNhanh.UseVisualStyleBackColor = false;

            this.btnBoChonKhach.BackColor = System.Drawing.Color.White;
            this.btnBoChonKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoChonKhach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnBoChonKhach.FlatAppearance.BorderSize = 1;
            this.btnBoChonKhach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoChonKhach.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnBoChonKhach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.btnBoChonKhach.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnBoChonKhach.Text = "Bỏ chọn";
            this.btnBoChonKhach.UseVisualStyleBackColor = false;

            this.lblThongTinKhach.AutoEllipsis = true;
            this.lblThongTinKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.lblThongTinKhach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblThongTinKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKhach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.lblThongTinKhach.Height = 26;
            this.lblThongTinKhach.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblThongTinKhach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";

            // ------------------------------------------
            // 3.3 BẢNG CHI TIẾT HÓA ĐƠN
            // ------------------------------------------
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.AllowUserToResizeRows = false;
            this.dgvChiTietHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietHD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTietHD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTietHD.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.dgvChiTietHD.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.dgvChiTietHD.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvChiTietHD.ColumnHeadersHeight = 32;
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTietHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCT_TenMon, this.colCT_SoLuong, this.colCT_DonGia, this.colCT_ThanhTien
            });
            this.dgvChiTietHD.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietHD.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.dgvChiTietHD.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvChiTietHD.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(238)))), ((int)(((byte)(230)))));
            this.dgvChiTietHD.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.dgvChiTietHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietHD.EnableHeadersVisualStyles = false;
            this.dgvChiTietHD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.dgvChiTietHD.ReadOnly = true;
            this.dgvChiTietHD.RowHeadersVisible = false;
            this.dgvChiTietHD.RowTemplate.Height = 34;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHD.Tag = "NoTheme";

            this.colCT_TenMon.DataPropertyName = "TenThucUong";
            this.colCT_TenMon.HeaderText = "Tên món";
            this.colCT_TenMon.FillWeight = 112F;

            this.colCT_SoLuong.DataPropertyName = "SoLuong";
            this.colCT_SoLuong.HeaderText = "SL";
            this.colCT_SoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCT_SoLuong.FillWeight = 32F;

            this.colCT_DonGia.DataPropertyName = "DonGia";
            this.colCT_DonGia.HeaderText = "Đơn giá";
            this.colCT_DonGia.DefaultCellStyle.Format = "N0";
            this.colCT_DonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCT_DonGia.FillWeight = 56F;

            this.colCT_ThanhTien.DataPropertyName = "ThanhTien";
            this.colCT_ThanhTien.HeaderText = "Thành tiền";
            this.colCT_ThanhTien.DefaultCellStyle.Format = "N0";
            this.colCT_ThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCT_ThanhTien.FillWeight = 70F;

            // ------------------------------------------
            // 3.4 THANH ĐIỀU CHỈNH SỐ LƯỢNG MÓN
            // ------------------------------------------
            this.pnlDieuChinhCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlDieuChinhCT.Controls.Add(this.tlpDieuChinhCT);
            this.pnlDieuChinhCT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDieuChinhCT.Height = 38;
            this.pnlDieuChinhCT.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);

            this.tlpDieuChinhCT.ColumnCount = 3;
            this.tlpDieuChinhCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpDieuChinhCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpDieuChinhCT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpDieuChinhCT.Controls.Add(this.btnTangSL, 0, 0);
            this.tlpDieuChinhCT.Controls.Add(this.btnGiamSL, 1, 0);
            this.tlpDieuChinhCT.Controls.Add(this.btnXoaMon, 2, 0);
            this.tlpDieuChinhCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDieuChinhCT.RowCount = 1;
            this.tlpDieuChinhCT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.btnTangSL.BackColor = System.Drawing.Color.White;
            this.btnTangSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTangSL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTangSL.FlatAppearance.BorderSize = 1;
            this.btnTangSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTangSL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTangSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTangSL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnTangSL.Text = "➕ Tăng SL";
            this.btnTangSL.UseVisualStyleBackColor = false;

            this.btnGiamSL.BackColor = System.Drawing.Color.White;
            this.btnGiamSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiamSL.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(199)))), ((int)(((byte)(189)))));
            this.btnGiamSL.FlatAppearance.BorderSize = 1;
            this.btnGiamSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiamSL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGiamSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.btnGiamSL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnGiamSL.Text = "➖ Giảm SL";
            this.btnGiamSL.UseVisualStyleBackColor = false;

            this.btnXoaMon.BackColor = System.Drawing.Color.White;
            this.btnXoaMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoaMon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(154)))));
            this.btnXoaMon.FlatAppearance.BorderSize = 1;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.btnXoaMon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnXoaMon.Text = "🗑 Xóa món (Del)";
            this.btnXoaMon.UseVisualStyleBackColor = false;

            // ------------------------------------------
            // 3.5 BẢNG TÍNH TIỀN & PHƯƠNG THỨC
            // ------------------------------------------
            this.pnlTinhTien.BackColor = System.Drawing.Color.White;
            this.pnlTinhTien.Controls.Add(this.tlpTinhTien);
            this.pnlTinhTien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTinhTien.Height = 248;
            this.pnlTinhTien.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);

            this.tlpTinhTien.ColumnCount = 2;
            this.tlpTinhTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpTinhTien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
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
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTinhTien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));

            // Row 0: Tiền hàng
            this.lblTienHangTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienHangTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienHangTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblTienHangTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTienHangTieuDe.Text = "Tiền hàng:";

            this.lblTienHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.lblTienHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienHang.Text = "0 đ";

            // Row 1: Giảm giá
            this.lblGiamGiaTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGiamGiaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiamGiaTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblGiamGiaTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGiamGiaTieuDe.Text = "Giảm giá:";

            this.numGiamGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numGiamGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiamGia.ThousandsSeparator = true;

            // Row 2: Tổng cộng
            this.lblTongThanhToanTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongThanhToanTieuDe.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToanTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(36)))), ((int)(((byte)(32)))));
            this.lblTongThanhToanTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTongThanhToanTieuDe.Text = "TỔNG CỘNG:";

            this.lblTongThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.lblTongThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongThanhToan.Text = "0 đ";

            // Row 3: Phương thức
            this.lblPhuongThucTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuongThucTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhuongThucTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblPhuongThucTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhuongThucTieuDe.Text = "Phương thức:";

            this.cboPhuongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // Row 4: Tiền khách đưa
            this.lblTienKhachDuaTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienKhachDuaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienKhachDuaTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblTienKhachDuaTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTienKhachDuaTieuDe.Text = "Tiền khách đưa:";

            this.numTienKhachDua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numTienKhachDua.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTienKhachDua.ThousandsSeparator = true;

            // Row 5: Gợi ý tiền nhanh (TableLayoutPanel 6 cột đều nhau - ZERO OVERLAP)
            this.pnlTienNhanh.ColumnCount = 6;
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666F));
            this.pnlTienNhanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.pnlTienNhanh.Controls.Add(this.btnTienVuaDu, 0, 0);
            this.pnlTienNhanh.Controls.Add(this.btnTien20k, 1, 0);
            this.pnlTienNhanh.Controls.Add(this.btnTien50k, 2, 0);
            this.pnlTienNhanh.Controls.Add(this.btnTien100k, 3, 0);
            this.pnlTienNhanh.Controls.Add(this.btnTien200k, 4, 0);
            this.pnlTienNhanh.Controls.Add(this.btnTien500k, 5, 0);
            this.pnlTienNhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTienNhanh.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.pnlTienNhanh.RowCount = 1;
            this.pnlTienNhanh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.btnTienVuaDu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTienVuaDu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTienVuaDu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTienVuaDu.FlatAppearance.BorderSize = 1;
            this.btnTienVuaDu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienVuaDu.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTienVuaDu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTienVuaDu.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTienVuaDu.Text = "Đủ";
            this.btnTienVuaDu.UseVisualStyleBackColor = false;

            this.btnTien20k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTien20k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTien20k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTien20k.FlatAppearance.BorderSize = 1;
            this.btnTien20k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTien20k.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTien20k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTien20k.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTien20k.Text = "20k";
            this.btnTien20k.UseVisualStyleBackColor = false;

            this.btnTien50k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTien50k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTien50k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTien50k.FlatAppearance.BorderSize = 1;
            this.btnTien50k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTien50k.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTien50k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTien50k.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTien50k.Text = "50k";
            this.btnTien50k.UseVisualStyleBackColor = false;

            this.btnTien100k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTien100k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTien100k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTien100k.FlatAppearance.BorderSize = 1;
            this.btnTien100k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTien100k.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTien100k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTien100k.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTien100k.Text = "100k";
            this.btnTien100k.UseVisualStyleBackColor = false;

            this.btnTien200k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTien200k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTien200k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTien200k.FlatAppearance.BorderSize = 1;
            this.btnTien200k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTien200k.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTien200k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTien200k.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTien200k.Text = "200k";
            this.btnTien200k.UseVisualStyleBackColor = false;

            this.btnTien500k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnTien500k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTien500k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(226)))), ((int)(((byte)(217)))));
            this.btnTien500k.FlatAppearance.BorderSize = 1;
            this.btnTien500k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTien500k.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.btnTien500k.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnTien500k.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.btnTien500k.Text = "500k";
            this.btnTien500k.UseVisualStyleBackColor = false;

            // Row 6: Tiền thối
            this.lblTienThoiTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienThoiTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienThoiTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.lblTienThoiTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTienThoiTieuDe.Text = "Tiền thối lại:";

            this.lblTienThoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienThoi.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTienThoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(125)))), ((int)(((byte)(91)))));
            this.lblTienThoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienThoi.Text = "0 đ";

            // ------------------------------------------
            // 3.6 THANH THAO TÁC HÓA ĐƠN & NÚT THANH TOÁN
            // ------------------------------------------
            this.pnlActionHD.BackColor = System.Drawing.Color.White;
            this.pnlActionHD.Controls.Add(this.tlpActionHD);
            this.pnlActionHD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionHD.Height = 104;
            this.pnlActionHD.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);

            this.tlpActionHD.ColumnCount = 4;
            this.tlpActionHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActionHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActionHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActionHD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpActionHD.Controls.Add(this.btnMoBan, 0, 0);
            this.tlpActionHD.Controls.Add(this.btnChuyenBan, 1, 0);
            this.tlpActionHD.Controls.Add(this.btnInTamTinh, 2, 0);
            this.tlpActionHD.Controls.Add(this.btnHuyDon, 3, 0);
            this.tlpActionHD.Controls.Add(this.btnThanhToan, 0, 1);
            this.tlpActionHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActionHD.RowCount = 2;
            this.tlpActionHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpActionHD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpActionHD.SetColumnSpan(this.btnThanhToan, 4);

            this.btnMoBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(245)))), ((int)(((byte)(238)))));
            this.btnMoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoBan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(211)))), ((int)(((byte)(181)))));
            this.btnMoBan.FlatAppearance.BorderSize = 1;
            this.btnMoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMoBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.btnMoBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMoBan.Text = "🟢 Mở bàn";
            this.btnMoBan.UseVisualStyleBackColor = false;

            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnChuyenBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenBan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(199)))), ((int)(((byte)(189)))));
            this.btnChuyenBan.FlatAppearance.BorderSize = 1;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChuyenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(94)))), ((int)(((byte)(60)))));
            this.btnChuyenBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChuyenBan.Text = "🔄 Đổi bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;

            this.btnInTamTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.btnInTamTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInTamTinh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(199)))), ((int)(((byte)(189)))));
            this.btnInTamTinh.FlatAppearance.BorderSize = 1;
            this.btnInTamTinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInTamTinh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnInTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(111)))), ((int)(((byte)(102)))));
            this.btnInTamTinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInTamTinh.Text = "🧾 In tạm (F8)";
            this.btnInTamTinh.UseVisualStyleBackColor = false;

            this.btnHuyDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(231)))));
            this.btnHuyDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuyDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(154)))));
            this.btnHuyDon.FlatAppearance.BorderSize = 1;
            this.btnHuyDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuyDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(64)))), ((int)(((byte)(44)))));
            this.btnHuyDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuyDon.Text = "❌ Hủy đơn";
            this.btnHuyDon.UseVisualStyleBackColor = false;

            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(125)))), ((int)(((byte)(91)))));
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.btnThanhToan.Text = "💳 THANH TOÁN (F9)";
            this.btnThanhToan.UseVisualStyleBackColor = false;

            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Tag = "NoTheme";
            this.Text = "Quản lý Bán hàng & Gọi món";

            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpSoDoBan.ResumeLayout(false);
            this.pnlFilterBan.ResumeLayout(false);
            this.pnlFilterBan.PerformLayout();
            this.pnlThongKeBan.ResumeLayout(false);
            this.pnlActionBan.ResumeLayout(false);
            this.tlpActionBan.ResumeLayout(false);
            this.grpThucDon.ResumeLayout(false);
            this.pnlThucDonHeader.ResumeLayout(false);
            this.pnlFilterMon.ResumeLayout(false);
            this.pnlFilterMon.PerformLayout();
            this.pnlThucDonContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).EndInit();
            this.pnlActionMon.ResumeLayout(false);
            this.pnlStepperMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongMon)).EndInit();
            this.tlpActionMonButtons.ResumeLayout(false);
            this.grpHoaDon.ResumeLayout(false);
            this.pnlThongTinBanHienTai.ResumeLayout(false);
            this.tlpThongTinBan.ResumeLayout(false);
            this.pnlKhachHang.ResumeLayout(false);
            this.pnlKhachHang.PerformLayout();
            this.tlpTimKhach.ResumeLayout(false);
            this.tlpTimKhach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.pnlDieuChinhCT.ResumeLayout(false);
            this.tlpDieuChinhCT.ResumeLayout(false);
            this.pnlTinhTien.ResumeLayout(false);
            this.tlpTinhTien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).EndInit();
            this.pnlTienNhanh.ResumeLayout(false);
            this.pnlActionHD.ResumeLayout(false);
            this.tlpActionHD.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel flpTrangThaiBanChips;
        private System.Windows.Forms.Panel pnlThongKeBan;
        private System.Windows.Forms.Label lblThongKeBan;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
        private System.Windows.Forms.Panel pnlActionBan;
        private System.Windows.Forms.TableLayoutPanel tlpActionBan;
        private System.Windows.Forms.Button btnMoBanNhanh;
        private System.Windows.Forms.Button btnChuyenBanNhanh;
        private System.Windows.Forms.GroupBox grpThucDon;
        private System.Windows.Forms.Panel pnlThucDonHeader;
        private System.Windows.Forms.Label lblTieuDeThucDon;
        private System.Windows.Forms.Button btnDoiCheDoXem;
        private System.Windows.Forms.Panel pnlFilterMon;
        private System.Windows.Forms.Label lblTimMon;
        private System.Windows.Forms.TextBox txtTimKiemMon;
        private System.Windows.Forms.FlowLayoutPanel flpLoaiMonChips;
        private System.Windows.Forms.Label lblLoaiMon;
        private System.Windows.Forms.ComboBox cboLoaiMon;
        private System.Windows.Forms.Panel pnlThucDonContent;
        private System.Windows.Forms.FlowLayoutPanel flpThucDonCards;
        private System.Windows.Forms.DataGridView dgvThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.Panel pnlActionMon;
        private System.Windows.Forms.Panel pnlStepperMon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnGiamSLMon;
        private System.Windows.Forms.NumericUpDown numSoLuongMon;
        private System.Windows.Forms.Button btnTangSLMon;
        private System.Windows.Forms.Button btnSL1;
        private System.Windows.Forms.Button btnSL2;
        private System.Windows.Forms.Button btnSL5;
        private System.Windows.Forms.TableLayoutPanel tlpActionMonButtons;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnKiemTraKho;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Panel pnlThongTinBanHienTai;
        private System.Windows.Forms.TableLayoutPanel tlpThongTinBan;
        private System.Windows.Forms.Label lblBanDangChon;
        private System.Windows.Forms.Label lblMaHDHienTai;
        private System.Windows.Forms.Label lblGioVao;
        private System.Windows.Forms.Panel pnlKhachHang;
        private System.Windows.Forms.TableLayoutPanel tlpTimKhach;
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
        private System.Windows.Forms.TableLayoutPanel tlpDieuChinhCT;
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
        private System.Windows.Forms.TableLayoutPanel pnlTienNhanh;
        private System.Windows.Forms.Button btnTienVuaDu;
        private System.Windows.Forms.Button btnTien20k;
        private System.Windows.Forms.Button btnTien50k;
        private System.Windows.Forms.Button btnTien100k;
        private System.Windows.Forms.Button btnTien200k;
        private System.Windows.Forms.Button btnTien500k;
        private System.Windows.Forms.Label lblTienThoiTieuDe;
        private System.Windows.Forms.Label lblTienThoi;
        private System.Windows.Forms.Panel pnlActionHD;
        private System.Windows.Forms.TableLayoutPanel tlpActionHD;
        private System.Windows.Forms.Button btnMoBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnInTamTinh;
    }
}
