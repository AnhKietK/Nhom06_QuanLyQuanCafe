namespace QuanLyQuanCafe.GUI.DanhMuc
{
    partial class FormCongThuc
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
            this.sptMain = new System.Windows.Forms.SplitContainer();
            this.grbThucUong = new System.Windows.Forms.GroupBox();
            this.dgvThucUong = new System.Windows.Forms.DataGridView();
            this.colTuMaTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuTenTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLocThucUong = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboLoaiThucUong = new System.Windows.Forms.ComboBox();
            this.lblLoaiTU = new System.Windows.Forms.Label();
            this.grbCongThuc = new System.Windows.Forms.GroupBox();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.colCtMaNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCtTenNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCtDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCtSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbNhapDong = new System.Windows.Forms.GroupBox();
            this.tlpNhapDong = new System.Windows.Forms.TableLayoutPanel();
            this.lblChonNL = new System.Windows.Forms.Label();
            this.cboNguyenLieu = new System.Windows.Forms.ComboBox();
            this.lblDonViTinhTieuDe = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.lblSoLuongQuyDinh = new System.Windows.Forms.Label();
            this.numSoLuongQuyDinh = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChuDinhMuc = new System.Windows.Forms.Label();
            this.flpNutDong = new System.Windows.Forms.TableLayoutPanel();
            this.btnLuuDong = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlThongTinMon = new System.Windows.Forms.Panel();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.lblTenMon = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.Panel1.SuspendLayout();
            this.sptMain.Panel2.SuspendLayout();
            this.sptMain.SuspendLayout();
            this.grbThucUong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).BeginInit();
            this.pnlLocThucUong.SuspendLayout();
            this.grbCongThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            this.grbNhapDong.SuspendLayout();
            this.tlpNhapDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongQuyDinh)).BeginInit();
            this.flpNutDong.SuspendLayout();
            this.pnlThongTinMon.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.lblTieuDeTrang);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 46;
            this.pnlTop.Location = new System.Drawing.Point(12, 12);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(4, 2, 4, 6);
            this.pnlTop.Size = new System.Drawing.Size(1076, 46);
            this.pnlTop.TabIndex = 0;

            // lblTieuDeTrang
            this.lblTieuDeTrang.AutoSize = true;
            this.lblTieuDeTrang.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTrang.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeTrang.Location = new System.Drawing.Point(4, 2);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(252, 37);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Công thức pha chế";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // sptMain
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(12, 58);
            this.sptMain.Name = "sptMain";

            // sptMain.Panel1 (Trái: Thức uống)
            this.sptMain.Panel1.Controls.Add(this.grbThucUong);
            this.sptMain.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);

            // sptMain.Panel2 (Phải: Công thức)
            this.sptMain.Panel2.Controls.Add(this.grbCongThuc);
            this.sptMain.Panel2.Controls.Add(this.grbNhapDong);
            this.sptMain.Panel2.Controls.Add(this.pnlThongTinMon);
            this.sptMain.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.sptMain.Size = new System.Drawing.Size(1076, 580);
            this.sptMain.SplitterDistance = 490;
            this.sptMain.TabIndex = 1;

            // grbThucUong
            this.grbThucUong.Controls.Add(this.dgvThucUong);
            this.grbThucUong.Controls.Add(this.pnlLocThucUong);
            this.grbThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThucUong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grbThucUong.Location = new System.Drawing.Point(0, 0);
            this.grbThucUong.Name = "grbThucUong";
            this.grbThucUong.Padding = new System.Windows.Forms.Padding(10, 24, 10, 10);
            this.grbThucUong.Size = new System.Drawing.Size(484, 580);
            this.grbThucUong.TabIndex = 0;
            this.grbThucUong.TabStop = false;
            this.grbThucUong.Text = "Danh sách thức uống";

            // pnlLocThucUong
            this.pnlLocThucUong.Controls.Add(this.txtTimKiem);
            this.pnlLocThucUong.Controls.Add(this.lblTimKiem);
            this.pnlLocThucUong.Controls.Add(this.cboLoaiThucUong);
            this.pnlLocThucUong.Controls.Add(this.lblLoaiTU);
            this.pnlLocThucUong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocThucUong.Height = 78;
            this.pnlLocThucUong.Location = new System.Drawing.Point(10, 24);
            this.pnlLocThucUong.Name = "pnlLocThucUong";
            this.pnlLocThucUong.Size = new System.Drawing.Size(464, 78);
            this.pnlLocThucUong.TabIndex = 0;

            // lblLoaiTU
            this.lblLoaiTU.AutoSize = true;
            this.lblLoaiTU.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoaiTU.Location = new System.Drawing.Point(4, 10);
            this.lblLoaiTU.Name = "lblLoaiTU";
            this.lblLoaiTU.Size = new System.Drawing.Size(42, 21);
            this.lblLoaiTU.TabIndex = 0;
            this.lblLoaiTU.Tag = "phu";
            this.lblLoaiTU.Text = "Loại:";

            // cboLoaiThucUong
            this.cboLoaiThucUong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThucUong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLoaiThucUong.Location = new System.Drawing.Point(82, 6);
            this.cboLoaiThucUong.Name = "cboLoaiThucUong";
            this.cboLoaiThucUong.Size = new System.Drawing.Size(378, 29);
            this.cboLoaiThucUong.TabIndex = 1;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(4, 46);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(77, 21);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Tag = "phu";
            this.lblTimKiem.Text = "Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(82, 43);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tên hoặc mã món...";
            this.txtTimKiem.Size = new System.Drawing.Size(378, 29);
            this.txtTimKiem.TabIndex = 3;

            // dgvThucUong
            this.dgvThucUong.AllowUserToAddRows = false;
            this.dgvThucUong.AllowUserToDeleteRows = false;
            this.dgvThucUong.AllowUserToResizeRows = false;
            this.dgvThucUong.AutoGenerateColumns = false;
            this.dgvThucUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvThucUong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTuMaTU,
                this.colTuTenTU,
                this.colTuLoai,
                this.colTuDonGia
            });
            this.dgvThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucUong.Location = new System.Drawing.Point(10, 102);
            this.dgvThucUong.MultiSelect = false;
            this.dgvThucUong.Name = "dgvThucUong";
            this.dgvThucUong.ReadOnly = true;
            this.dgvThucUong.RowHeadersVisible = false;
            this.dgvThucUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucUong.Size = new System.Drawing.Size(464, 468);
            this.dgvThucUong.TabIndex = 1;

            // colTuMaTU
            this.colTuMaTU.DataPropertyName = "MaThucUong";
            this.colTuMaTU.HeaderText = "Mã";
            this.colTuMaTU.Name = "colTuMaTU";
            this.colTuMaTU.ReadOnly = true;
            this.colTuMaTU.Width = 75;

            // colTuTenTU
            this.colTuTenTU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTuTenTU.DataPropertyName = "TenThucUong";
            this.colTuTenTU.HeaderText = "Tên thức uống";
            this.colTuTenTU.MinimumWidth = 130;
            this.colTuTenTU.Name = "colTuTenTU";
            this.colTuTenTU.ReadOnly = true;

            // colTuLoai
            this.colTuLoai.DataPropertyName = "TenLoaiTU";
            this.colTuLoai.HeaderText = "Loại";
            this.colTuLoai.Name = "colTuLoai";
            this.colTuLoai.ReadOnly = true;
            this.colTuLoai.Width = 90;

            // colTuDonGia
            this.colTuDonGia.DataPropertyName = "DonGiaBan";
            this.colTuDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTuDonGia.DefaultCellStyle.Format = "N0";
            this.colTuDonGia.HeaderText = "Giá bán";
            this.colTuDonGia.Name = "colTuDonGia";
            this.colTuDonGia.ReadOnly = true;
            this.colTuDonGia.Width = 95;

            // pnlThongTinMon
            this.pnlThongTinMon.Controls.Add(this.lblCanhBao);
            this.pnlThongTinMon.Controls.Add(this.lblTenMon);
            this.pnlThongTinMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinMon.Height = 58;
            this.pnlThongTinMon.Location = new System.Drawing.Point(6, 0);
            this.pnlThongTinMon.Name = "pnlThongTinMon";
            this.pnlThongTinMon.Padding = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.pnlThongTinMon.Size = new System.Drawing.Size(576, 58);
            this.pnlThongTinMon.TabIndex = 0;

            // lblTenMon
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTenMon.ForeColor = System.Drawing.Color.White;
            this.lblTenMon.Location = new System.Drawing.Point(4, 2);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(262, 30);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Tag = "nhanphu";
            this.lblTenMon.Text = "Chọn thức uống bên trái";

            // lblCanhBao
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblCanhBao.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblCanhBao.Location = new System.Drawing.Point(4, 33);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(471, 21);
            this.lblCanhBao.TabIndex = 1;
            this.lblCanhBao.Tag = "nhanmanh";
            this.lblCanhBao.Text = "⚠️ Món này chưa có công thức, khi bán sẽ không trừ kho nguyên liệu.";
            this.lblCanhBao.Visible = false;

            // grbCongThuc
            this.grbCongThuc.Controls.Add(this.dgvCongThuc);
            this.grbCongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCongThuc.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grbCongThuc.Location = new System.Drawing.Point(6, 58);
            this.grbCongThuc.Name = "grbCongThuc";
            this.grbCongThuc.Padding = new System.Windows.Forms.Padding(10, 24, 10, 10);
            this.grbCongThuc.Size = new System.Drawing.Size(576, 322);
            this.grbCongThuc.TabIndex = 1;
            this.grbCongThuc.TabStop = false;
            this.grbCongThuc.Text = "Bảng thành phần công thức (cho 1 ly)";

            // dgvCongThuc
            this.dgvCongThuc.AllowUserToAddRows = false;
            this.dgvCongThuc.AllowUserToDeleteRows = false;
            this.dgvCongThuc.AllowUserToResizeRows = false;
            this.dgvCongThuc.AutoGenerateColumns = false;
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCongThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCtMaNL,
                this.colCtTenNL,
                this.colCtDonVi,
                this.colCtSoLuong
            });
            this.dgvCongThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongThuc.Location = new System.Drawing.Point(10, 24);
            this.dgvCongThuc.MultiSelect = false;
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.RowHeadersVisible = false;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(556, 288);
            this.dgvCongThuc.TabIndex = 0;

            // colCtMaNL
            this.colCtMaNL.DataPropertyName = "MaNL";
            this.colCtMaNL.HeaderText = "Mã NL";
            this.colCtMaNL.Name = "colCtMaNL";
            this.colCtMaNL.ReadOnly = true;
            this.colCtMaNL.Width = 80;

            // colCtTenNL
            this.colCtTenNL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCtTenNL.DataPropertyName = "TenNL";
            this.colCtTenNL.HeaderText = "Tên nguyên liệu";
            this.colCtTenNL.MinimumWidth = 140;
            this.colCtTenNL.Name = "colCtTenNL";
            this.colCtTenNL.ReadOnly = true;

            // colCtDonVi
            this.colCtDonVi.DataPropertyName = "DonViTinh";
            this.colCtDonVi.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCtDonVi.HeaderText = "Đơn vị";
            this.colCtDonVi.Name = "colCtDonVi";
            this.colCtDonVi.ReadOnly = true;
            this.colCtDonVi.Width = 80;

            // colCtSoLuong
            this.colCtSoLuong.DataPropertyName = "SoLuongQuyDinh";
            this.colCtSoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCtSoLuong.DefaultCellStyle.Format = "N3";
            this.colCtSoLuong.HeaderText = "Định mức (1 ly)";
            this.colCtSoLuong.Name = "colCtSoLuong";
            this.colCtSoLuong.ReadOnly = true;
            this.colCtSoLuong.Width = 135;

            // grbNhapDong
            this.grbNhapDong.Controls.Add(this.tlpNhapDong);
            this.grbNhapDong.Controls.Add(this.flpNutDong);
            this.grbNhapDong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbNhapDong.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grbNhapDong.Height = 200;
            this.grbNhapDong.Location = new System.Drawing.Point(6, 380);
            this.grbNhapDong.Name = "grbNhapDong";
            this.grbNhapDong.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.grbNhapDong.Size = new System.Drawing.Size(576, 200);
            this.grbNhapDong.TabIndex = 2;
            this.grbNhapDong.TabStop = false;
            this.grbNhapDong.Text = "Thành phần định mức";

            // tlpNhapDong
            this.tlpNhapDong.ColumnCount = 2;
            this.tlpNhapDong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpNhapDong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNhapDong.Controls.Add(this.lblChonNL, 0, 0);
            this.tlpNhapDong.Controls.Add(this.cboNguyenLieu, 1, 0);
            this.tlpNhapDong.Controls.Add(this.lblDonViTinhTieuDe, 0, 1);
            this.tlpNhapDong.Controls.Add(this.lblDonViTinh, 1, 1);
            this.tlpNhapDong.Controls.Add(this.lblSoLuongQuyDinh, 0, 2);
            this.tlpNhapDong.Controls.Add(this.numSoLuongQuyDinh, 1, 2);
            this.tlpNhapDong.Controls.Add(this.lblGhiChuDinhMuc, 0, 3);
            this.tlpNhapDong.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpNhapDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tlpNhapDong.Location = new System.Drawing.Point(10, 20);
            this.tlpNhapDong.Name = "tlpNhapDong";
            this.tlpNhapDong.RowCount = 4;
            this.tlpNhapDong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpNhapDong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpNhapDong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpNhapDong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpNhapDong.Size = new System.Drawing.Size(556, 130);
            this.tlpNhapDong.TabIndex = 0;

            // lblChonNL
            this.lblChonNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChonNL.Name = "lblChonNL";
            this.lblChonNL.Text = "Nguyên liệu (*):";
            this.lblChonNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // cboNguyenLieu
            this.cboNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNguyenLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboNguyenLieu.Name = "cboNguyenLieu";

            // lblDonViTinhTieuDe
            this.lblDonViTinhTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonViTinhTieuDe.Name = "lblDonViTinhTieuDe";
            this.lblDonViTinhTieuDe.Text = "Đơn vị tính:";
            this.lblDonViTinhTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblDonViTinh
            this.lblDonViTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Tag = "nhanphu";
            this.lblDonViTinh.Text = "(Theo NL)";
            this.lblDonViTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblSoLuongQuyDinh
            this.lblSoLuongQuyDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuongQuyDinh.Name = "lblSoLuongQuyDinh";
            this.lblSoLuongQuyDinh.Text = "Định mức 1 ly (*):";
            this.lblSoLuongQuyDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // numSoLuongQuyDinh
            this.numSoLuongQuyDinh.DecimalPlaces = 3;
            this.numSoLuongQuyDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSoLuongQuyDinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSoLuongQuyDinh.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numSoLuongQuyDinh.Name = "numSoLuongQuyDinh";
            this.numSoLuongQuyDinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblGhiChuDinhMuc
            this.tlpNhapDong.SetColumnSpan(this.lblGhiChuDinhMuc, 2);
            this.lblGhiChuDinhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChuDinhMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuDinhMuc.Name = "lblGhiChuDinhMuc";
            this.lblGhiChuDinhMuc.Tag = "phu";
            this.lblGhiChuDinhMuc.Text = "💡 Số lượng quy định tính theo đơn vị của nguyên liệu (gram, ml, cái) cho 1 ly.";
            this.lblGhiChuDinhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // flpNutDong
            this.flpNutDong.ColumnCount = 3;
            this.flpNutDong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.flpNutDong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.flpNutDong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.flpNutDong.Controls.Add(this.btnLuuDong, 0, 0);
            this.flpNutDong.Controls.Add(this.btnXoaDong, 1, 0);
            this.flpNutDong.Controls.Add(this.btnLamMoi, 2, 0);
            this.flpNutDong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpNutDong.Height = 40;
            this.flpNutDong.Location = new System.Drawing.Point(10, 150);
            this.flpNutDong.Name = "flpNutDong";
            this.flpNutDong.RowCount = 1;
            this.flpNutDong.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flpNutDong.Size = new System.Drawing.Size(556, 40);
            this.flpNutDong.TabIndex = 1;

            // btnLuuDong
            this.btnLuuDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLuuDong.FlatAppearance.BorderSize = 0;
            this.btnLuuDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuuDong.ForeColor = System.Drawing.Color.White;
            this.btnLuuDong.Location = new System.Drawing.Point(0, 0);
            this.btnLuuDong.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnLuuDong.Name = "btnLuuDong";
            this.btnLuuDong.Size = new System.Drawing.Size(218, 40);
            this.btnLuuDong.TabIndex = 0;
            this.btnLuuDong.Tag = "success";
            this.btnLuuDong.Text = "💾 Thêm / Cập nhật";
            this.btnLuuDong.UseVisualStyleBackColor = true;

            // btnXoaDong
            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(226, 0);
            this.btnXoaDong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(158, 40);
            this.btnXoaDong.TabIndex = 1;
            this.btnXoaDong.Tag = "danger";
            this.btnXoaDong.Text = "🗑️ Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;

            // btnLamMoi
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(392, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(164, 40);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Tag = "neutral";
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;

            // FormCongThuc
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormCongThuc";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Công thức pha chế";

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.sptMain.Panel1.ResumeLayout(false);
            this.sptMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.grbThucUong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).EndInit();
            this.pnlLocThucUong.ResumeLayout(false);
            this.pnlLocThucUong.PerformLayout();
            this.grbCongThuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            this.grbNhapDong.ResumeLayout(false);
            this.tlpNhapDong.ResumeLayout(false);
            this.tlpNhapDong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongQuyDinh)).EndInit();
            this.flpNutDong.ResumeLayout(false);
            this.pnlThongTinMon.ResumeLayout(false);
            this.pnlThongTinMon.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.SplitContainer sptMain;
        private System.Windows.Forms.GroupBox grbThucUong;
        private System.Windows.Forms.Panel pnlLocThucUong;
        private System.Windows.Forms.Label lblLoaiTU;
        private System.Windows.Forms.ComboBox cboLoaiThucUong;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuMaTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuTenTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuDonGia;
        private System.Windows.Forms.Panel pnlThongTinMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.GroupBox grbCongThuc;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCtMaNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCtTenNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCtDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCtSoLuong;
        private System.Windows.Forms.GroupBox grbNhapDong;
        private System.Windows.Forms.TableLayoutPanel tlpNhapDong;
        private System.Windows.Forms.Label lblChonNL;
        private System.Windows.Forms.ComboBox cboNguyenLieu;
        private System.Windows.Forms.Label lblDonViTinhTieuDe;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label lblSoLuongQuyDinh;
        private System.Windows.Forms.NumericUpDown numSoLuongQuyDinh;
        private System.Windows.Forms.Label lblGhiChuDinhMuc;
        private System.Windows.Forms.TableLayoutPanel flpNutDong;
        private System.Windows.Forms.Button btnLuuDong;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnLamMoi;
    }
}

