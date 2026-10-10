namespace QuanLyQuanCafe.GUI.Kho
{
    partial class FormNguyenLieu
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
            this.lblTongCanhBao = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.chkChiCanhBao = new System.Windows.Forms.CheckBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNL = new System.Windows.Forms.Label();
            this.txtMaNL = new System.Windows.Forms.TextBox();
            this.lblTenNL = new System.Windows.Forms.Label();
            this.txtTenNL = new System.Windows.Forms.TextBox();
            this.lblLoaiNL = new System.Windows.Forms.Label();
            this.cboLoaiNL = new System.Windows.Forms.ComboBox();
            this.lblDonViTinhTieuDe = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.lblMucToiThieu = new System.Windows.Forms.Label();
            this.numMucToiThieu = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChuTonKho = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.colMaNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMucToiThieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMucToiThieu)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.lblTongCanhBao);
            this.pnlTop.Controls.Add(this.lblTieuDeTrang);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 52;
            this.pnlTop.Location = new System.Drawing.Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.pnlTop.Size = new System.Drawing.Size(1076, 52);
            this.pnlTop.TabIndex = 0;

            // lblTieuDeTrang
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTrang.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeTrang.Location = new System.Drawing.Point(4, 4);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(260, 40);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý nguyên liệu";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblTongCanhBao
            this.lblTongCanhBao.AutoSize = true;
            this.lblTongCanhBao.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTongCanhBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongCanhBao.Location = new System.Drawing.Point(264, 4);
            this.lblTongCanhBao.Name = "lblTongCanhBao";
            this.lblTongCanhBao.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblTongCanhBao.Size = new System.Drawing.Size(240, 40);
            this.lblTongCanhBao.TabIndex = 1;
            this.lblTongCanhBao.Tag = "nhanmanh";
            this.lblTongCanhBao.Text = "Có 0 nguyên liệu dưới mức tối thiểu";
            this.lblTongCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlSearch
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Controls.Add(this.chkChiCanhBao);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSearch.Location = new System.Drawing.Point(546, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlSearch.Size = new System.Drawing.Size(526, 40);
            this.pnlSearch.TabIndex = 2;

            // chkChiCanhBao
            this.chkChiCanhBao.AutoSize = true;
            this.chkChiCanhBao.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkChiCanhBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkChiCanhBao.Location = new System.Drawing.Point(0, 4);
            this.chkChiCanhBao.Name = "chkChiCanhBao";
            this.chkChiCanhBao.Padding = new System.Windows.Forms.Padding(0, 2, 12, 0);
            this.chkChiCanhBao.Size = new System.Drawing.Size(220, 32);
            this.chkChiCanhBao.TabIndex = 0;
            this.chkChiCanhBao.Text = "Chỉ hiện nguyên liệu sắp hết";
            this.chkChiCanhBao.UseVisualStyleBackColor = true;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Location = new System.Drawing.Point(220, 4);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Padding = new System.Windows.Forms.Padding(0, 5, 8, 0);
            this.lblTimKiem.Size = new System.Drawing.Size(100, 32);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Tag = "phu";
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtTimKiem
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(320, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Mã, tên, loại nguyên liệu...";
            this.txtTimKiem.Size = new System.Drawing.Size(206, 31);
            this.txtTimKiem.TabIndex = 2;

            // pnlRight
            this.pnlRight.Controls.Add(this.grbThongTin);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(688, 64);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(400, 574);
            this.pnlRight.TabIndex = 2;

            // grbThongTin
            this.grbThongTin.Controls.Add(this.tlpInput);
            this.grbThongTin.Controls.Add(this.flpButtons);
            this.grbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grbThongTin.Location = new System.Drawing.Point(8, 0);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(14, 38, 14, 14);
            this.grbThongTin.Size = new System.Drawing.Size(392, 574);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin nguyên liệu";

            // tlpInput
            this.tlpInput.ColumnCount = 2;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInput.Controls.Add(this.lblMaNL, 0, 0);
            this.tlpInput.Controls.Add(this.txtMaNL, 1, 0);
            this.tlpInput.Controls.Add(this.lblTenNL, 0, 1);
            this.tlpInput.Controls.Add(this.txtTenNL, 1, 1);
            this.tlpInput.Controls.Add(this.lblLoaiNL, 0, 2);
            this.tlpInput.Controls.Add(this.cboLoaiNL, 1, 2);
            this.tlpInput.Controls.Add(this.lblDonViTinhTieuDe, 0, 3);
            this.tlpInput.Controls.Add(this.lblDonViTinh, 1, 3);
            this.tlpInput.Controls.Add(this.lblMucToiThieu, 0, 4);
            this.tlpInput.Controls.Add(this.numMucToiThieu, 1, 4);
            this.tlpInput.Controls.Add(this.lblGhiChuTonKho, 0, 5);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpInput.Location = new System.Drawing.Point(14, 38);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 6;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpInput.Size = new System.Drawing.Size(364, 255);
            this.tlpInput.TabIndex = 0;

            // lblMaNL
            this.lblMaNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNL.Name = "lblMaNL";
            this.lblMaNL.Text = "Mã NL (*):";
            this.lblMaNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtMaNL
            this.txtMaNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNL.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtMaNL.MaxLength = 20;
            this.txtMaNL.Name = "txtMaNL";

            // lblTenNL
            this.lblTenNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNL.Name = "lblTenNL";
            this.lblTenNL.Text = "Tên NL (*):";
            this.lblTenNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtTenNL
            this.txtTenNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNL.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTenNL.MaxLength = 150;
            this.txtTenNL.Name = "txtTenNL";

            // lblLoaiNL
            this.lblLoaiNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiNL.Name = "lblLoaiNL";
            this.lblLoaiNL.Text = "Loại NL (*):";
            this.lblLoaiNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // cboLoaiNL
            this.cboLoaiNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiNL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiNL.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiNL.Name = "cboLoaiNL";

            // lblDonViTinhTieuDe
            this.lblDonViTinhTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonViTinhTieuDe.Name = "lblDonViTinhTieuDe";
            this.lblDonViTinhTieuDe.Text = "Đơn vị tính:";
            this.lblDonViTinhTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblDonViTinh
            this.lblDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Tag = "nhanphu";
            this.lblDonViTinh.Text = "(Theo loại)";
            this.lblDonViTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblMucToiThieu
            this.lblMucToiThieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMucToiThieu.Name = "lblMucToiThieu";
            this.lblMucToiThieu.Text = "Mức tối thiểu (*):";
            this.lblMucToiThieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // numMucToiThieu
            this.numMucToiThieu.DecimalPlaces = 3;
            this.numMucToiThieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numMucToiThieu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.numMucToiThieu.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numMucToiThieu.Name = "numMucToiThieu";
            this.numMucToiThieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblGhiChuTonKho
            this.tlpInput.SetColumnSpan(this.lblGhiChuTonKho, 2);
            this.lblGhiChuTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChuTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuTonKho.Name = "lblGhiChuTonKho";
            this.lblGhiChuTonKho.Tag = "phu";
            this.lblGhiChuTonKho.Text = "💡 Tồn kho tăng khi lập phiếu nhập kho";
            this.lblGhiChuTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // flpButtons
            this.flpButtons.ColumnCount = 2;
            this.flpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flpButtons.Controls.Add(this.btnThem, 0, 0);
            this.flpButtons.Controls.Add(this.btnSua, 1, 0);
            this.flpButtons.Controls.Add(this.btnXoa, 0, 1);
            this.flpButtons.Controls.Add(this.btnLamMoi, 1, 1);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.Location = new System.Drawing.Point(14, 468);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.RowCount = 2;
            this.flpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flpButtons.Size = new System.Drawing.Size(364, 92);
            this.flpButtons.TabIndex = 1;

            // btnThem
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(177, 41);
            this.btnThem.TabIndex = 0;
            this.btnThem.Tag = "success";
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            // btnSua
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Margin = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(177, 41);
            this.btnSua.TabIndex = 1;
            this.btnSua.Tag = "primary";
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            // btnXoa
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(177, 41);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Tag = "danger";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;

            // btnLamMoi
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(177, 41);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Tag = "neutral";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;

            // pnlLeft
            this.pnlLeft.Controls.Add(this.grbDanhSach);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(12, 64);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.pnlLeft.Size = new System.Drawing.Size(676, 574);
            this.pnlLeft.TabIndex = 1;

            // grbDanhSach
            this.grbDanhSach.Controls.Add(this.dgvNguyenLieu);
            this.grbDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDanhSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grbDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(12, 28, 12, 12);
            this.grbDanhSach.Size = new System.Drawing.Size(668, 574);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách nguyên liệu";

            // dgvNguyenLieu
            this.dgvNguyenLieu.AllowUserToAddRows = false;
            this.dgvNguyenLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenLieu.AllowUserToResizeRows = false;
            this.dgvNguyenLieu.AutoGenerateColumns = false;
            this.dgvNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNguyenLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaNL,
                this.colTenNL,
                this.colLoaiNL,
                this.colDonViTinh,
                this.colTonKho,
                this.colMucToiThieu,
                this.colTinhTrang
            });
            this.dgvNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(12, 28);
            this.dgvNguyenLieu.MultiSelect = false;
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.ReadOnly = true;
            this.dgvNguyenLieu.RowHeadersVisible = false;
            this.dgvNguyenLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenLieu.Size = new System.Drawing.Size(644, 534);
            this.dgvNguyenLieu.TabIndex = 0;

            // colMaNL
            this.colMaNL.DataPropertyName = "MaNL";
            this.colMaNL.HeaderText = "Mã NL";
            this.colMaNL.Name = "colMaNL";
            this.colMaNL.ReadOnly = true;
            this.colMaNL.Width = 85;

            // colTenNL
            this.colTenNL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNL.DataPropertyName = "TenNL";
            this.colTenNL.HeaderText = "Tên nguyên liệu";
            this.colTenNL.MinimumWidth = 140;
            this.colTenNL.Name = "colTenNL";
            this.colTenNL.ReadOnly = true;

            // colLoaiNL
            this.colLoaiNL.DataPropertyName = "TenLoai";
            this.colLoaiNL.HeaderText = "Loại";
            this.colLoaiNL.Name = "colLoaiNL";
            this.colLoaiNL.ReadOnly = true;
            this.colLoaiNL.Width = 100;

            // colDonViTinh
            this.colDonViTinh.DataPropertyName = "DonViTinh";
            this.colDonViTinh.HeaderText = "Đơn vị";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            this.colDonViTinh.Width = 75;

            // colTonKho
            this.colTonKho.DataPropertyName = "SoLuongTonKho";
            this.colTonKho.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTonKho.DefaultCellStyle.Format = "N3";
            this.colTonKho.HeaderText = "Tồn kho";
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            this.colTonKho.Width = 90;

            // colMucToiThieu
            this.colMucToiThieu.DataPropertyName = "MucToiThieu";
            this.colMucToiThieu.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMucToiThieu.DefaultCellStyle.Format = "N3";
            this.colMucToiThieu.HeaderText = "Tối thiểu";
            this.colMucToiThieu.Name = "colMucToiThieu";
            this.colMucToiThieu.ReadOnly = true;
            this.colMucToiThieu.Width = 90;

            // colTinhTrang
            this.colTinhTrang.DataPropertyName = "TinhTrang";
            this.colTinhTrang.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTinhTrang.HeaderText = "Tình trạng";
            this.colTinhTrang.Name = "colTinhTrang";
            this.colTinhTrang.ReadOnly = true;
            this.colTinhTrang.Width = 95;

            // FormNguyenLieu
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNguyenLieu";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Quản lý nguyên liệu";

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMucToiThieu)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Label lblTongCanhBao;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.CheckBox chkChiCanhBao;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Label lblMaNL;
        private System.Windows.Forms.TextBox txtMaNL;
        private System.Windows.Forms.Label lblTenNL;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.Label lblLoaiNL;
        private System.Windows.Forms.ComboBox cboLoaiNL;
        private System.Windows.Forms.Label lblDonViTinhTieuDe;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label lblMucToiThieu;
        private System.Windows.Forms.NumericUpDown numMucToiThieu;
        private System.Windows.Forms.Label lblGhiChuTonKho;
        private System.Windows.Forms.TableLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMucToiThieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrang;
    }
}

