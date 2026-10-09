namespace QuanLyQuanCafe.GUI.DanhMuc
{
    partial class FormThucUong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (picHinhAnh?.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = null;
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaThucUong = new System.Windows.Forms.Label();
            this.txtMaThucUong = new System.Windows.Forms.TextBox();
            this.lblTenThucUong = new System.Windows.Forms.Label();
            this.txtTenThucUong = new System.Windows.Forms.TextBox();
            this.lblLoaiThucUong = new System.Windows.Forms.Label();
            this.cboLoaiThucUong = new System.Windows.Forms.ComboBox();
            this.lblDonGiaBan = new System.Windows.Forms.Label();
            this.numDonGiaBan = new System.Windows.Forms.NumericUpDown();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.pnlAnhChucNang = new System.Windows.Forms.Panel();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.pnlAnhButtons = new System.Windows.Forms.Panel();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.lblXemTruoc = new System.Windows.Forms.Label();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvThucUong = new System.Windows.Forms.DataGridView();
            this.colMaThucUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenThucUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLoaiTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaBan)).BeginInit();
            this.pnlAnhChucNang.SuspendLayout();
            this.pnlAnhButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.pnlSearch);
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
            this.lblTieuDeTrang.Size = new System.Drawing.Size(252, 40);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý thức uống";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlSearch
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Controls.Add(this.cboLocLoai);
            this.pnlSearch.Controls.Add(this.lblLocLoai);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSearch.Location = new System.Drawing.Point(546, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlSearch.Size = new System.Drawing.Size(526, 40);
            this.pnlSearch.TabIndex = 1;

            // lblLocLoai
            this.lblLocLoai.AutoSize = true;
            this.lblLocLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLocLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocLoai.Location = new System.Drawing.Point(0, 4);
            this.lblLocLoai.Name = "lblLocLoai";
            this.lblLocLoai.Padding = new System.Windows.Forms.Padding(0, 5, 6, 0);
            this.lblLocLoai.Size = new System.Drawing.Size(51, 28);
            this.lblLocLoai.TabIndex = 0;
            this.lblLocLoai.Tag = "phu";
            this.lblLocLoai.Text = "Loại:";
            this.lblLocLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // cboLocLoai
            this.cboLocLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocLoai.Location = new System.Drawing.Point(51, 4);
            this.cboLocLoai.Name = "cboLocLoai";
            this.cboLocLoai.Size = new System.Drawing.Size(160, 29);
            this.cboLocLoai.TabIndex = 1;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Location = new System.Drawing.Point(211, 4);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Padding = new System.Windows.Forms.Padding(12, 5, 6, 0);
            this.lblTimKiem.Size = new System.Drawing.Size(116, 28);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Tag = "phu";
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtTimKiem
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(327, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Mã hoặc tên món...";
            this.txtTimKiem.Size = new System.Drawing.Size(199, 31);
            this.txtTimKiem.TabIndex = 3;

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
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(14, 34, 14, 14);
            this.grbThongTin.Size = new System.Drawing.Size(392, 574);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin thức uống";

            // tlpInput
            this.tlpInput.ColumnCount = 2;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInput.Controls.Add(this.lblMaThucUong, 0, 0);
            this.tlpInput.Controls.Add(this.txtMaThucUong, 1, 0);
            this.tlpInput.Controls.Add(this.lblTenThucUong, 0, 1);
            this.tlpInput.Controls.Add(this.txtTenThucUong, 1, 1);
            this.tlpInput.Controls.Add(this.lblLoaiThucUong, 0, 2);
            this.tlpInput.Controls.Add(this.cboLoaiThucUong, 1, 2);
            this.tlpInput.Controls.Add(this.lblDonGiaBan, 0, 3);
            this.tlpInput.Controls.Add(this.numDonGiaBan, 1, 3);
            this.tlpInput.Controls.Add(this.lblHinhAnh, 0, 4);
            this.tlpInput.Controls.Add(this.pnlAnhChucNang, 1, 4);
            this.tlpInput.Controls.Add(this.lblXemTruoc, 0, 5);
            this.tlpInput.Controls.Add(this.picHinhAnh, 1, 5);
            this.tlpInput.Controls.Add(this.lblGhiChu, 0, 6);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpInput.Location = new System.Drawing.Point(14, 34);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 7;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInput.Size = new System.Drawing.Size(364, 385);
            this.tlpInput.TabIndex = 0;

            // lblMaThucUong
            this.lblMaThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaThucUong.Name = "lblMaThucUong";
            this.lblMaThucUong.Text = "Mã món (*):";
            this.lblMaThucUong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtMaThucUong
            this.txtMaThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaThucUong.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtMaThucUong.MaxLength = 20;
            this.txtMaThucUong.Name = "txtMaThucUong";

            // lblTenThucUong
            this.lblTenThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenThucUong.Name = "lblTenThucUong";
            this.lblTenThucUong.Text = "Tên món (*):";
            this.lblTenThucUong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtTenThucUong
            this.txtTenThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenThucUong.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTenThucUong.MaxLength = 150;
            this.txtTenThucUong.Name = "txtTenThucUong";

            // lblLoaiThucUong
            this.lblLoaiThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiThucUong.Name = "lblLoaiThucUong";
            this.lblLoaiThucUong.Text = "Loại món (*):";
            this.lblLoaiThucUong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // cboLoaiThucUong
            this.cboLoaiThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLoaiThucUong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThucUong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiThucUong.Name = "cboLoaiThucUong";

            // lblDonGiaBan
            this.lblDonGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonGiaBan.Name = "lblDonGiaBan";
            this.lblDonGiaBan.Text = "Đơn giá bán (*):";
            this.lblDonGiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // numDonGiaBan
            this.numDonGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDonGiaBan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.numDonGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numDonGiaBan.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numDonGiaBan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDonGiaBan.Name = "numDonGiaBan";
            this.numDonGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDonGiaBan.ThousandsSeparator = true;
            this.numDonGiaBan.Value = new decimal(new int[] { 25000, 0, 0, 0 });

            // lblHinhAnh
            this.lblHinhAnh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Text = "Hình ảnh:";
            this.lblHinhAnh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlAnhChucNang
            this.pnlAnhChucNang.Controls.Add(this.pnlAnhButtons);
            this.pnlAnhChucNang.Controls.Add(this.txtHinhAnh);
            this.pnlAnhChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnhChucNang.Location = new System.Drawing.Point(118, 155);
            this.pnlAnhChucNang.Name = "pnlAnhChucNang";
            this.pnlAnhChucNang.Size = new System.Drawing.Size(243, 62);
            this.pnlAnhChucNang.TabIndex = 4;

            // txtHinhAnh
            this.txtHinhAnh.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHinhAnh.Location = new System.Drawing.Point(0, 0);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.PlaceholderText = "(Chưa chọn ảnh)";
            this.txtHinhAnh.ReadOnly = true;
            this.txtHinhAnh.Size = new System.Drawing.Size(243, 27);
            this.txtHinhAnh.TabIndex = 0;

            // pnlAnhButtons
            this.pnlAnhButtons.Controls.Add(this.btnXoaAnh);
            this.pnlAnhButtons.Controls.Add(this.btnChonAnh);
            this.pnlAnhButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAnhButtons.Location = new System.Drawing.Point(0, 32);
            this.pnlAnhButtons.Name = "pnlAnhButtons";
            this.pnlAnhButtons.Size = new System.Drawing.Size(243, 30);
            this.pnlAnhButtons.TabIndex = 1;

            // btnChonAnh
            this.btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonAnh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(0, 0);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(115, 30);
            this.btnChonAnh.TabIndex = 0;
            this.btnChonAnh.Tag = "neutral";
            this.btnChonAnh.Text = "📁 Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = true;

            // btnXoaAnh
            this.btnXoaAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaAnh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoaAnh.FlatAppearance.BorderSize = 0;
            this.btnXoaAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaAnh.ForeColor = System.Drawing.Color.White;
            this.btnXoaAnh.Location = new System.Drawing.Point(125, 0);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(118, 30);
            this.btnXoaAnh.TabIndex = 1;
            this.btnXoaAnh.Tag = "danger";
            this.btnXoaAnh.Text = "✖ Xóa ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = true;

            // lblXemTruoc
            this.lblXemTruoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblXemTruoc.Name = "lblXemTruoc";
            this.lblXemTruoc.Text = "Xem trước:";
            this.lblXemTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // picHinhAnh
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHinhAnh.Location = new System.Drawing.Point(118, 223);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(243, 109);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 5;
            this.picHinhAnh.TabStop = false;

            // lblGhiChu
            this.tlpInput.SetColumnSpan(this.lblGhiChu, 2);
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Tag = "phu";
            this.lblGhiChu.Text = "💡 Sau khi thêm món, hãy cấu hình công thức pha chế ở menu Kho, Công thức pha chế.";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

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
            this.grbDanhSach.Controls.Add(this.dgvThucUong);
            this.grbDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDanhSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grbDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(12, 28, 12, 12);
            this.grbDanhSach.Size = new System.Drawing.Size(668, 574);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách thức uống";

            // dgvThucUong
            this.dgvThucUong.AllowUserToAddRows = false;
            this.dgvThucUong.AllowUserToDeleteRows = false;
            this.dgvThucUong.AllowUserToResizeRows = false;
            this.dgvThucUong.AutoGenerateColumns = false;
            this.dgvThucUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvThucUong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaThucUong,
                this.colTenThucUong,
                this.colTenLoaiTU,
                this.colDonGiaBan
            });
            this.dgvThucUong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucUong.Location = new System.Drawing.Point(12, 28);
            this.dgvThucUong.MultiSelect = false;
            this.dgvThucUong.Name = "dgvThucUong";
            this.dgvThucUong.ReadOnly = true;
            this.dgvThucUong.RowHeadersVisible = false;
            this.dgvThucUong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucUong.Size = new System.Drawing.Size(644, 534);
            this.dgvThucUong.TabIndex = 0;

            // colMaThucUong
            this.colMaThucUong.DataPropertyName = "MaThucUong";
            this.colMaThucUong.HeaderText = "Mã món";
            this.colMaThucUong.Name = "colMaThucUong";
            this.colMaThucUong.ReadOnly = true;
            this.colMaThucUong.Width = 90;

            // colTenThucUong
            this.colTenThucUong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenThucUong.DataPropertyName = "TenThucUong";
            this.colTenThucUong.HeaderText = "Tên thức uống";
            this.colTenThucUong.MinimumWidth = 150;
            this.colTenThucUong.Name = "colTenThucUong";
            this.colTenThucUong.ReadOnly = true;

            // colTenLoaiTU
            this.colTenLoaiTU.DataPropertyName = "TenLoaiTU";
            this.colTenLoaiTU.HeaderText = "Loại thức uống";
            this.colTenLoaiTU.Name = "colTenLoaiTU";
            this.colTenLoaiTU.ReadOnly = true;
            this.colTenLoaiTU.Width = 130;

            // colDonGiaBan
            this.colDonGiaBan.DataPropertyName = "DonGiaBan";
            this.colDonGiaBan.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGiaBan.DefaultCellStyle.Format = "N0";
            this.colDonGiaBan.HeaderText = "Đơn giá bán";
            this.colDonGiaBan.Name = "colDonGiaBan";
            this.colDonGiaBan.ReadOnly = true;
            this.colDonGiaBan.Width = 120;

            // FormThucUong
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormThucUong";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Quản lý thức uống";

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaBan)).EndInit();
            this.pnlAnhChucNang.ResumeLayout(false);
            this.pnlAnhChucNang.PerformLayout();
            this.pnlAnhButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucUong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Label lblMaThucUong;
        private System.Windows.Forms.TextBox txtMaThucUong;
        private System.Windows.Forms.Label lblTenThucUong;
        private System.Windows.Forms.TextBox txtTenThucUong;
        private System.Windows.Forms.Label lblLoaiThucUong;
        private System.Windows.Forms.ComboBox cboLoaiThucUong;
        private System.Windows.Forms.Label lblDonGiaBan;
        private System.Windows.Forms.NumericUpDown numDonGiaBan;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.Panel pnlAnhChucNang;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.Panel pnlAnhButtons;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Label lblXemTruoc;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TableLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThucUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaBan;
    }
}

