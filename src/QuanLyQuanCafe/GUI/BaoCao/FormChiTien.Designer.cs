namespace QuanLyQuanCafe.GUI.BaoCao
{
    partial class FormChiTien
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabLapPhieu = new System.Windows.Forms.TabPage();
            this.pnlLapPhieuContent = new System.Windows.Forms.Panel();
            this.grbThongTinChi = new System.Windows.Forms.GroupBox();
            this.tlpLapPhieu = new System.Windows.Forms.TableLayoutPanel();
            this.lblNguoiLapTieuDe = new System.Windows.Forms.Label();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.numSoTienChi = new System.Windows.Forms.NumericUpDown();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDoChi = new System.Windows.Forms.TextBox();
            this.pnlLapButtons = new System.Windows.Forms.Panel();
            this.btnChiTien = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.dgvPhieuChi = new System.Windows.Forms.DataGridView();
            this.colMaPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTienChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLyDoChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguoiChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.lblTongTienChi = new System.Windows.Forms.Label();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabLapPhieu.SuspendLayout();
            this.pnlLapPhieuContent.SuspendLayout();
            this.grbThongTinChi.SuspendLayout();
            this.tlpLapPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienChi)).BeginInit();
            this.pnlLapButtons.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).BeginInit();
            this.pnlTongKet.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
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
            this.lblTieuDeTrang.Size = new System.Drawing.Size(360, 37);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý chi tiền nhà cung cấp";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabLapPhieu);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(150, 36);
            this.tabMain.Location = new System.Drawing.Point(12, 62);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1076, 576);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;
            // 
            // tabLapPhieu
            // 
            this.tabLapPhieu.Controls.Add(this.pnlLapPhieuContent);
            this.tabLapPhieu.Location = new System.Drawing.Point(4, 40);
            this.tabLapPhieu.Name = "tabLapPhieu";
            this.tabLapPhieu.Padding = new System.Windows.Forms.Padding(16);
            this.tabLapPhieu.Size = new System.Drawing.Size(1068, 532);
            this.tabLapPhieu.TabIndex = 0;
            this.tabLapPhieu.Text = "Lập phiếu chi";
            this.tabLapPhieu.UseVisualStyleBackColor = true;
            // 
            // pnlLapPhieuContent
            // 
            this.pnlLapPhieuContent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLapPhieuContent.Controls.Add(this.grbThongTinChi);
            this.pnlLapPhieuContent.Location = new System.Drawing.Point(134, 20);
            this.pnlLapPhieuContent.Name = "pnlLapPhieuContent";
            this.pnlLapPhieuContent.Size = new System.Drawing.Size(800, 480);
            this.pnlLapPhieuContent.TabIndex = 0;
            // 
            // grbThongTinChi
            // 
            this.grbThongTinChi.Controls.Add(this.tlpLapPhieu);
            this.grbThongTinChi.Controls.Add(this.pnlLapButtons);
            this.grbThongTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTinChi.Location = new System.Drawing.Point(0, 0);
            this.grbThongTinChi.Name = "grbThongTinChi";
            this.grbThongTinChi.Padding = new System.Windows.Forms.Padding(16);
            this.grbThongTinChi.Size = new System.Drawing.Size(800, 480);
            this.grbThongTinChi.TabIndex = 0;
            this.grbThongTinChi.TabStop = false;
            this.grbThongTinChi.Text = "Thông tin phiếu chi tiền";
            // 
            // tlpLapPhieu
            // 
            this.tlpLapPhieu.ColumnCount = 2;
            this.tlpLapPhieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpLapPhieu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLapPhieu.Controls.Add(this.lblNguoiLapTieuDe, 0, 0);
            this.tlpLapPhieu.Controls.Add(this.lblNguoiLap, 1, 0);
            this.tlpLapPhieu.Controls.Add(this.lblNhaCungCap, 0, 1);
            this.tlpLapPhieu.Controls.Add(this.cboNhaCungCap, 1, 1);
            this.tlpLapPhieu.Controls.Add(this.lblSoTien, 0, 2);
            this.tlpLapPhieu.Controls.Add(this.numSoTienChi, 1, 2);
            this.tlpLapPhieu.Controls.Add(this.lblLyDo, 0, 3);
            this.tlpLapPhieu.Controls.Add(this.txtLyDoChi, 1, 3);
            this.tlpLapPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLapPhieu.Location = new System.Drawing.Point(16, 36);
            this.tlpLapPhieu.Name = "tlpLapPhieu";
            this.tlpLapPhieu.RowCount = 4;
            this.tlpLapPhieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpLapPhieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpLapPhieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpLapPhieu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLapPhieu.Size = new System.Drawing.Size(768, 368);
            this.tlpLapPhieu.TabIndex = 0;
            // 
            // lblNguoiLapTieuDe
            // 
            this.lblNguoiLapTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNguoiLapTieuDe.AutoSize = true;
            this.lblNguoiLapTieuDe.Location = new System.Drawing.Point(3, 12);
            this.lblNguoiLapTieuDe.Name = "lblNguoiLapTieuDe";
            this.lblNguoiLapTieuDe.Size = new System.Drawing.Size(107, 20);
            this.lblNguoiLapTieuDe.TabIndex = 0;
            this.lblNguoiLapTieuDe.Text = "Người lập chi:";
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNguoiLap.Location = new System.Drawing.Point(163, 11);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(144, 23);
            this.lblNguoiLap.TabIndex = 1;
            this.lblNguoiLap.Tag = "nhanmanh";
            this.lblNguoiLap.Text = "Chưa đăng nhập";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(3, 57);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(126, 20);
            this.lblNhaCungCap.TabIndex = 2;
            this.lblNhaCungCap.Text = "Nhà cung cấp (*):";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(163, 48);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(602, 28);
            this.cboNhaCungCap.TabIndex = 3;
            // 
            // lblSoTien
            // 
            this.lblSoTien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(3, 102);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(134, 20);
            this.lblSoTien.TabIndex = 4;
            this.lblSoTien.Text = "Số tiền chi (đ) (*):";
            // 
            // numSoTienChi
            // 
            this.numSoTienChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSoTienChi.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoTienChi.Location = new System.Drawing.Point(163, 93);
            this.numSoTienChi.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numSoTienChi.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoTienChi.Name = "numSoTienChi";
            this.numSoTienChi.Size = new System.Drawing.Size(602, 27);
            this.numSoTienChi.TabIndex = 5;
            this.numSoTienChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSoTienChi.ThousandsSeparator = true;
            this.numSoTienChi.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(3, 143);
            this.lblLyDo.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(120, 20);
            this.lblLyDo.TabIndex = 6;
            this.lblLyDo.Text = "Lý do chi tiền (*):";
            // 
            // txtLyDoChi
            // 
            this.txtLyDoChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLyDoChi.Location = new System.Drawing.Point(163, 138);
            this.txtLyDoChi.Multiline = true;
            this.txtLyDoChi.Name = "txtLyDoChi";
            this.txtLyDoChi.PlaceholderText = "Nhập nội dung hoặc mục đích chi tiền...";
            this.txtLyDoChi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDoChi.Size = new System.Drawing.Size(602, 227);
            this.txtLyDoChi.TabIndex = 7;
            // 
            // pnlLapButtons
            // 
            this.pnlLapButtons.Controls.Add(this.btnChiTien);
            this.pnlLapButtons.Controls.Add(this.btnLamMoi);
            this.pnlLapButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLapButtons.Location = new System.Drawing.Point(16, 404);
            this.pnlLapButtons.Name = "pnlLapButtons";
            this.pnlLapButtons.Size = new System.Drawing.Size(768, 60);
            this.pnlLapButtons.TabIndex = 1;
            // 
            // btnChiTien
            // 
            this.btnChiTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiTien.Location = new System.Drawing.Point(628, 12);
            this.btnChiTien.Name = "btnChiTien";
            this.btnChiTien.Size = new System.Drawing.Size(140, 38);
            this.btnChiTien.TabIndex = 1;
            this.btnChiTien.Tag = "success";
            this.btnChiTien.Text = "Xác nhận chi tiền";
            this.btnChiTien.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Location = new System.Drawing.Point(512, 12);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Tag = "neutral";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.dgvPhieuChi);
            this.tabLichSu.Controls.Add(this.pnlTongKet);
            this.tabLichSu.Controls.Add(this.pnlBoLoc);
            this.tabLichSu.Location = new System.Drawing.Point(4, 40);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(8);
            this.tabLichSu.Size = new System.Drawing.Size(1068, 532);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "Lịch sử chi tiền";
            this.tabLichSu.UseVisualStyleBackColor = true;
            // 
            // dgvPhieuChi
            // 
            this.dgvPhieuChi.AllowUserToAddRows = false;
            this.dgvPhieuChi.AllowUserToDeleteRows = false;
            this.dgvPhieuChi.AllowUserToResizeRows = false;
            this.dgvPhieuChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPC,
            this.colNgayChi,
            this.colSoTienChi,
            this.colLyDoChi,
            this.colTenNCC,
            this.colNguoiChi});
            this.dgvPhieuChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuChi.Location = new System.Drawing.Point(8, 62);
            this.dgvPhieuChi.MultiSelect = false;
            this.dgvPhieuChi.Name = "dgvPhieuChi";
            this.dgvPhieuChi.ReadOnly = true;
            this.dgvPhieuChi.RowHeadersVisible = false;
            this.dgvPhieuChi.RowHeadersWidth = 51;
            this.dgvPhieuChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuChi.Size = new System.Drawing.Size(1052, 417);
            this.dgvPhieuChi.TabIndex = 1;
            // 
            // colMaPC
            // 
            this.colMaPC.DataPropertyName = "MaPC";
            this.colMaPC.FillWeight = 80F;
            this.colMaPC.HeaderText = "Mã phiếu chi";
            this.colMaPC.MinimumWidth = 85;
            this.colMaPC.Name = "colMaPC";
            this.colMaPC.ReadOnly = true;
            // 
            // colNgayChi
            // 
            this.colNgayChi.DataPropertyName = "NgayChi";
            this.colNgayChi.FillWeight = 110F;
            this.colNgayChi.HeaderText = "Ngày chi";
            this.colNgayChi.MinimumWidth = 100;
            this.colNgayChi.Name = "colNgayChi";
            this.colNgayChi.ReadOnly = true;
            // 
            // colSoTienChi
            // 
            this.colSoTienChi.DataPropertyName = "SoTienChi";
            this.colSoTienChi.FillWeight = 100F;
            this.colSoTienChi.HeaderText = "Số tiền chi";
            this.colSoTienChi.MinimumWidth = 95;
            this.colSoTienChi.Name = "colSoTienChi";
            this.colSoTienChi.ReadOnly = true;
            // 
            // colLyDoChi
            // 
            this.colLyDoChi.DataPropertyName = "LyDoChi";
            this.colLyDoChi.FillWeight = 180F;
            this.colLyDoChi.HeaderText = "Lý do chi";
            this.colLyDoChi.MinimumWidth = 140;
            this.colLyDoChi.Name = "colLyDoChi";
            this.colLyDoChi.ReadOnly = true;
            // 
            // colTenNCC
            // 
            this.colTenNCC.DataPropertyName = "TenNCC";
            this.colTenNCC.FillWeight = 120F;
            this.colTenNCC.HeaderText = "Nhà cung cấp";
            this.colTenNCC.MinimumWidth = 110;
            this.colTenNCC.Name = "colTenNCC";
            this.colTenNCC.ReadOnly = true;
            // 
            // colNguoiChi
            // 
            this.colNguoiChi.DataPropertyName = "TenNV";
            this.colNguoiChi.FillWeight = 90F;
            this.colNguoiChi.HeaderText = "Người chi";
            this.colNguoiChi.MinimumWidth = 90;
            this.colNguoiChi.Name = "colNguoiChi";
            this.colNguoiChi.ReadOnly = true;
            // 
            // pnlTongKet
            // 
            this.pnlTongKet.Controls.Add(this.lblTongTienChi);
            this.pnlTongKet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTongKet.Location = new System.Drawing.Point(8, 479);
            this.pnlTongKet.Name = "pnlTongKet";
            this.pnlTongKet.Padding = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.pnlTongKet.Size = new System.Drawing.Size(1052, 45);
            this.pnlTongKet.TabIndex = 2;
            // 
            // lblTongTienChi
            // 
            this.lblTongTienChi.AutoSize = true;
            this.lblTongTienChi.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTongTienChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTienChi.Location = new System.Drawing.Point(836, 10);
            this.lblTongTienChi.Name = "lblTongTienChi";
            this.lblTongTienChi.Size = new System.Drawing.Size(208, 25);
            this.lblTongTienChi.TabIndex = 0;
            this.lblTongTienChi.Tag = "nhanmanh";
            this.lblTongTienChi.Text = "Tổng số tiền đã chi: 0 đ";
            this.lblTongTienChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.Controls.Add(this.btnLoc);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoLoc.Location = new System.Drawing.Point(8, 8);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Padding = new System.Windows.Forms.Padding(4, 8, 4, 10);
            this.pnlBoLoc.Size = new System.Drawing.Size(1052, 54);
            this.pnlBoLoc.TabIndex = 0;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(495, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 32);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Tag = "primary";
            this.btnLoc.Text = "Lọc dữ liệu";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(335, 12);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(140, 27);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(255, 16);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(75, 20);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(85, 12);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(140, 27);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(12, 16);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(65, 20);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // FormChiTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "FormChiTien";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Chi tiền nhà cung cấp";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabLapPhieu.ResumeLayout(false);
            this.pnlLapPhieuContent.ResumeLayout(false);
            this.grbThongTinChi.ResumeLayout(false);
            this.tlpLapPhieu.ResumeLayout(false);
            this.tlpLapPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienChi)).EndInit();
            this.pnlLapButtons.ResumeLayout(false);
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).EndInit();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabLapPhieu;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.Panel pnlLapPhieuContent;
        private System.Windows.Forms.GroupBox grbThongTinChi;
        private System.Windows.Forms.TableLayoutPanel tlpLapPhieu;
        private System.Windows.Forms.Label lblNguoiLapTieuDe;
        private System.Windows.Forms.Label lblNguoiLap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown numSoTienChi;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDoChi;
        private System.Windows.Forms.Panel pnlLapButtons;
        private System.Windows.Forms.Button btnChiTien;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DataGridView dgvPhieuChi;
        private System.Windows.Forms.Panel pnlTongKet;
        private System.Windows.Forms.Label lblTongTienChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTienChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLyDoChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiChi;
    }
}

