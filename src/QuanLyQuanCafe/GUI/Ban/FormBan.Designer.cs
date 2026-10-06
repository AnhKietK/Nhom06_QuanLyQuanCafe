namespace QuanLyQuanCafe.GUI.Ban
{
    partial class FormBan
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
            this.tabMain = new TabControl();
            this.tabBan = new TabPage();
            this.pnlRightBan = new Panel();
            this.grbThongTinBan = new GroupBox();
            this.tlpBan = new TableLayoutPanel();
            this.lblMaBan = new Label();
            this.txtMaBan = new TextBox();
            this.lblSoBan = new Label();
            this.numSoBan = new NumericUpDown();
            this.lblSoChoNgoi = new Label();
            this.numSoChoNgoi = new NumericUpDown();
            this.lblViTri = new Label();
            this.cboViTri = new ComboBox();
            this.lblTrangThaiTitle = new Label();
            this.lblHienTrangThai = new Label();
            this.flpButtonsBan = new TableLayoutPanel();
            this.btnThemBan = new Button();
            this.btnSuaBan = new Button();
            this.btnXoaBan = new Button();
            this.btnLamMoiBan = new Button();
            this.pnlLeftBan = new Panel();
            this.grbDanhSachBan = new GroupBox();
            this.dgvBan = new DataGridView();
            this.colMaBan = new DataGridViewTextBoxColumn();
            this.colSoBan = new DataGridViewTextBoxColumn();
            this.colSoChoNgoi = new DataGridViewTextBoxColumn();
            this.colTrangThai = new DataGridViewTextBoxColumn();
            this.colKhuVuc = new DataGridViewTextBoxColumn();
            this.tabKhuVuc = new TabPage();
            this.pnlRightViTri = new Panel();
            this.grbThongTinViTri = new GroupBox();
            this.tlpViTri = new TableLayoutPanel();
            this.lblMaViTri = new Label();
            this.txtMaViTri = new TextBox();
            this.lblTenViTri = new Label();
            this.txtTenViTri = new TextBox();
            this.lblMoTa = new Label();
            this.txtMoTa = new TextBox();
            this.flpButtonsViTri = new TableLayoutPanel();
            this.btnThemViTri = new Button();
            this.btnSuaViTri = new Button();
            this.btnXoaViTri = new Button();
            this.btnLamMoiViTri = new Button();
            this.pnlLeftViTri = new Panel();
            this.grbDanhSachViTri = new GroupBox();
            this.dgvViTri = new DataGridView();
            this.colMaViTri = new DataGridViewTextBoxColumn();
            this.colTenViTri = new DataGridViewTextBoxColumn();
            this.colMoTa = new DataGridViewTextBoxColumn();

            this.tabMain.SuspendLayout();
            this.tabBan.SuspendLayout();
            this.pnlRightBan.SuspendLayout();
            this.grbThongTinBan.SuspendLayout();
            this.tlpBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoChoNgoi)).BeginInit();
            this.flpButtonsBan.SuspendLayout();
            this.pnlLeftBan.SuspendLayout();
            this.grbDanhSachBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.tabKhuVuc.SuspendLayout();
            this.pnlRightViTri.SuspendLayout();
            this.grbThongTinViTri.SuspendLayout();
            this.tlpViTri.SuspendLayout();
            this.flpButtonsViTri.SuspendLayout();
            this.pnlLeftViTri.SuspendLayout();
            this.grbDanhSachViTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTri)).BeginInit();
            this.SuspendLayout();

            // tabMain
            this.tabMain.Controls.Add(this.tabBan);
            this.tabMain.Controls.Add(this.tabKhuVuc);
            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Font = new Font("Segoe UI", 10F);
            this.tabMain.Location = new Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new Size(976, 556);
            this.tabMain.TabIndex = 0;

            // tabBan
            this.tabBan.Controls.Add(this.pnlLeftBan);
            this.tabBan.Controls.Add(this.pnlRightBan);
            this.tabBan.Location = new Point(4, 32);
            this.tabBan.Name = "tabBan";
            this.tabBan.Padding = new Padding(8);
            this.tabBan.Size = new Size(968, 520);
            this.tabBan.Text = "Bàn";
            this.tabBan.UseVisualStyleBackColor = true;

            // pnlRightBan
            this.pnlRightBan.Controls.Add(this.grbThongTinBan);
            this.pnlRightBan.Dock = DockStyle.Right;
            this.pnlRightBan.Location = new Point(570, 8);
            this.pnlRightBan.Name = "pnlRightBan";
            this.pnlRightBan.Padding = new Padding(8, 0, 0, 0);
            this.pnlRightBan.Size = new Size(390, 504);
            this.pnlRightBan.TabIndex = 1;

            // grbThongTinBan
            this.grbThongTinBan.Controls.Add(this.tlpBan);
            this.grbThongTinBan.Controls.Add(this.flpButtonsBan);
            this.grbThongTinBan.Dock = DockStyle.Fill;
            this.grbThongTinBan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbThongTinBan.Location = new Point(8, 0);
            this.grbThongTinBan.Name = "grbThongTinBan";
            this.grbThongTinBan.Padding = new Padding(14, 38, 14, 12);
            this.grbThongTinBan.Size = new Size(382, 504);
            this.grbThongTinBan.TabIndex = 0;
            this.grbThongTinBan.TabStop = false;
            this.grbThongTinBan.Text = "Thông tin bàn";

            // tlpBan
            this.tlpBan.ColumnCount = 2;
            this.tlpBan.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpBan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpBan.Controls.Add(this.lblMaBan, 0, 0);
            this.tlpBan.Controls.Add(this.txtMaBan, 1, 0);
            this.tlpBan.Controls.Add(this.lblSoBan, 0, 1);
            this.tlpBan.Controls.Add(this.numSoBan, 1, 1);
            this.tlpBan.Controls.Add(this.lblSoChoNgoi, 0, 2);
            this.tlpBan.Controls.Add(this.numSoChoNgoi, 1, 2);
            this.tlpBan.Controls.Add(this.lblViTri, 0, 3);
            this.tlpBan.Controls.Add(this.cboViTri, 1, 3);
            this.tlpBan.Controls.Add(this.lblTrangThaiTitle, 0, 4);
            this.tlpBan.Controls.Add(this.lblHienTrangThai, 1, 4);
            this.tlpBan.Dock = DockStyle.Top;
            this.tlpBan.Font = new Font("Segoe UI", 10F);
            this.tlpBan.Location = new Point(14, 38);
            this.tlpBan.Name = "tlpBan";
            this.tlpBan.RowCount = 5;
            this.tlpBan.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpBan.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpBan.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpBan.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpBan.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpBan.Size = new Size(354, 210);
            this.tlpBan.TabIndex = 0;

            // lblMaBan
            this.lblMaBan.Dock = DockStyle.Fill;
            this.lblMaBan.Name = "lblMaBan";
            this.lblMaBan.Text = "Mã bàn (*):";
            this.lblMaBan.TextAlign = ContentAlignment.MiddleLeft;

            // txtMaBan
            this.txtMaBan.Dock = DockStyle.Fill;
            this.txtMaBan.Font = new Font("Segoe UI", 10.5F);
            this.txtMaBan.MaxLength = 20;
            this.txtMaBan.Name = "txtMaBan";

            // lblSoBan
            this.lblSoBan.Dock = DockStyle.Fill;
            this.lblSoBan.Name = "lblSoBan";
            this.lblSoBan.Text = "Số bàn (*):";
            this.lblSoBan.TextAlign = ContentAlignment.MiddleLeft;

            // numSoBan
            this.numSoBan.Dock = DockStyle.Fill;
            this.numSoBan.Font = new Font("Segoe UI", 10.5F);
            this.numSoBan.Location = new Point(113, 43);
            this.numSoBan.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numSoBan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoBan.Name = "numSoBan";
            this.numSoBan.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // lblSoChoNgoi
            this.lblSoChoNgoi.Dock = DockStyle.Fill;
            this.lblSoChoNgoi.Name = "lblSoChoNgoi";
            this.lblSoChoNgoi.Text = "Số chỗ ngồi (*):";
            this.lblSoChoNgoi.TextAlign = ContentAlignment.MiddleLeft;

            // numSoChoNgoi
            this.numSoChoNgoi.Dock = DockStyle.Fill;
            this.numSoChoNgoi.Font = new Font("Segoe UI", 10.5F);
            this.numSoChoNgoi.Location = new Point(113, 83);
            this.numSoChoNgoi.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numSoChoNgoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoChoNgoi.Name = "numSoChoNgoi";
            this.numSoChoNgoi.Value = new decimal(new int[] { 4, 0, 0, 0 });

            // lblViTri
            this.lblViTri.Dock = DockStyle.Fill;
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Text = "Khu vực (*):";
            this.lblViTri.TextAlign = ContentAlignment.MiddleLeft;

            // cboViTri
            this.cboViTri.Dock = DockStyle.Fill;
            this.cboViTri.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViTri.Font = new Font("Segoe UI", 10F);
            this.cboViTri.Name = "cboViTri";

            // lblTrangThaiTitle
            this.lblTrangThaiTitle.Dock = DockStyle.Fill;
            this.lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            this.lblTrangThaiTitle.Text = "Trạng thái:";
            this.lblTrangThaiTitle.TextAlign = ContentAlignment.MiddleLeft;

            // lblHienTrangThai
            this.lblHienTrangThai.Dock = DockStyle.Fill;
            this.lblHienTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblHienTrangThai.Name = "lblHienTrangThai";
            this.lblHienTrangThai.Text = "TRONG";
            this.lblHienTrangThai.TextAlign = ContentAlignment.MiddleLeft;

            // flpButtonsBan
            this.flpButtonsBan.ColumnCount = 2;
            this.flpButtonsBan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtonsBan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtonsBan.Controls.Add(this.btnThemBan, 0, 0);
            this.flpButtonsBan.Controls.Add(this.btnSuaBan, 1, 0);
            this.flpButtonsBan.Controls.Add(this.btnXoaBan, 0, 1);
            this.flpButtonsBan.Controls.Add(this.btnLamMoiBan, 1, 1);
            this.flpButtonsBan.Dock = DockStyle.Bottom;
            this.flpButtonsBan.Location = new Point(14, 404);
            this.flpButtonsBan.Name = "flpButtonsBan";
            this.flpButtonsBan.RowCount = 2;
            this.flpButtonsBan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtonsBan.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtonsBan.Size = new Size(354, 88);
            this.flpButtonsBan.TabIndex = 1;

            // btnThemBan
            this.btnThemBan.Cursor = Cursors.Hand;
            this.btnThemBan.Dock = DockStyle.Fill;
            this.btnThemBan.FlatAppearance.BorderSize = 0;
            this.btnThemBan.FlatStyle = FlatStyle.Flat;
            this.btnThemBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnThemBan.ForeColor = Color.White;
            this.btnThemBan.Margin = new Padding(0, 0, 5, 5);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new Size(172, 39);
            this.btnThemBan.TabIndex = 0;
            this.btnThemBan.Tag = "success";
            this.btnThemBan.Text = "Thêm";
            this.btnThemBan.UseVisualStyleBackColor = true;

            // btnSuaBan
            this.btnSuaBan.Cursor = Cursors.Hand;
            this.btnSuaBan.Dock = DockStyle.Fill;
            this.btnSuaBan.FlatAppearance.BorderSize = 0;
            this.btnSuaBan.FlatStyle = FlatStyle.Flat;
            this.btnSuaBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSuaBan.ForeColor = Color.White;
            this.btnSuaBan.Margin = new Padding(5, 0, 0, 5);
            this.btnSuaBan.Name = "btnSuaBan";
            this.btnSuaBan.Size = new Size(172, 39);
            this.btnSuaBan.TabIndex = 1;
            this.btnSuaBan.Tag = "primary";
            this.btnSuaBan.Text = "Sửa";
            this.btnSuaBan.UseVisualStyleBackColor = true;

            // btnXoaBan
            this.btnXoaBan.Cursor = Cursors.Hand;
            this.btnXoaBan.Dock = DockStyle.Fill;
            this.btnXoaBan.FlatAppearance.BorderSize = 0;
            this.btnXoaBan.FlatStyle = FlatStyle.Flat;
            this.btnXoaBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnXoaBan.ForeColor = Color.White;
            this.btnXoaBan.Margin = new Padding(0, 5, 5, 0);
            this.btnXoaBan.Name = "btnXoaBan";
            this.btnXoaBan.Size = new Size(172, 39);
            this.btnXoaBan.TabIndex = 2;
            this.btnXoaBan.Tag = "danger";
            this.btnXoaBan.Text = "Xóa";
            this.btnXoaBan.UseVisualStyleBackColor = true;

            // btnLamMoiBan
            this.btnLamMoiBan.Cursor = Cursors.Hand;
            this.btnLamMoiBan.Dock = DockStyle.Fill;
            this.btnLamMoiBan.FlatAppearance.BorderSize = 0;
            this.btnLamMoiBan.FlatStyle = FlatStyle.Flat;
            this.btnLamMoiBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLamMoiBan.ForeColor = Color.White;
            this.btnLamMoiBan.Margin = new Padding(5, 5, 0, 0);
            this.btnLamMoiBan.Name = "btnLamMoiBan";
            this.btnLamMoiBan.Size = new Size(172, 39);
            this.btnLamMoiBan.TabIndex = 3;
            this.btnLamMoiBan.Tag = "neutral";
            this.btnLamMoiBan.Text = "Làm mới";
            this.btnLamMoiBan.UseVisualStyleBackColor = true;

            // pnlLeftBan
            this.pnlLeftBan.Controls.Add(this.grbDanhSachBan);
            this.pnlLeftBan.Dock = DockStyle.Fill;
            this.pnlLeftBan.Location = new Point(8, 8);
            this.pnlLeftBan.Name = "pnlLeftBan";
            this.pnlLeftBan.Padding = new Padding(0, 0, 8, 0);
            this.pnlLeftBan.Size = new Size(562, 504);
            this.pnlLeftBan.TabIndex = 0;

            // grbDanhSachBan
            this.grbDanhSachBan.Controls.Add(this.dgvBan);
            this.grbDanhSachBan.Dock = DockStyle.Fill;
            this.grbDanhSachBan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbDanhSachBan.Location = new Point(0, 0);
            this.grbDanhSachBan.Name = "grbDanhSachBan";
            this.grbDanhSachBan.Padding = new Padding(12, 38, 12, 12);
            this.grbDanhSachBan.Size = new Size(554, 504);
            this.grbDanhSachBan.TabIndex = 0;
            this.grbDanhSachBan.TabStop = false;
            this.grbDanhSachBan.Text = "Danh sách bàn";

            // dgvBan
            this.dgvBan.AllowUserToAddRows = false;
            this.dgvBan.AllowUserToDeleteRows = false;
            this.dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBan.BackgroundColor = SystemColors.Window;
            this.dgvBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBan.Columns.AddRange(new DataGridViewColumn[] {
                this.colMaBan,
                this.colSoBan,
                this.colSoChoNgoi,
                this.colTrangThai,
                this.colKhuVuc
            });
            this.dgvBan.Dock = DockStyle.Fill;
            this.dgvBan.Font = new Font("Segoe UI", 10F);
            this.dgvBan.Location = new Point(12, 38);
            this.dgvBan.MultiSelect = false;
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.ReadOnly = true;
            this.dgvBan.RowHeadersVisible = false;
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBan.Size = new Size(530, 454);
            this.dgvBan.TabIndex = 0;

            // colMaBan
            this.colMaBan.DataPropertyName = "MaBan";
            this.colMaBan.FillWeight = 80F;
            this.colMaBan.HeaderText = "Mã bàn";
            this.colMaBan.Name = "colMaBan";
            this.colMaBan.ReadOnly = true;

            // colSoBan
            this.colSoBan.DataPropertyName = "SoBan";
            this.colSoBan.FillWeight = 80F;
            this.colSoBan.HeaderText = "Số bàn";
            this.colSoBan.Name = "colSoBan";
            this.colSoBan.ReadOnly = true;

            // colSoChoNgoi
            this.colSoChoNgoi.DataPropertyName = "SoChoNgoi";
            this.colSoChoNgoi.FillWeight = 85F;
            this.colSoChoNgoi.HeaderText = "Số chỗ";
            this.colSoChoNgoi.Name = "colSoChoNgoi";
            this.colSoChoNgoi.ReadOnly = true;

            // colTrangThai
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.FillWeight = 110F;
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;

            // colKhuVuc
            this.colKhuVuc.DataPropertyName = "TenViTri";
            this.colKhuVuc.FillWeight = 130F;
            this.colKhuVuc.HeaderText = "Khu vực";
            this.colKhuVuc.Name = "colKhuVuc";
            this.colKhuVuc.ReadOnly = true;

            // tabKhuVuc
            this.tabKhuVuc.Controls.Add(this.pnlLeftViTri);
            this.tabKhuVuc.Controls.Add(this.pnlRightViTri);
            this.tabKhuVuc.Location = new Point(4, 32);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Padding = new Padding(8);
            this.tabKhuVuc.Size = new Size(968, 520);
            this.tabKhuVuc.Text = "Khu vực";
            this.tabKhuVuc.UseVisualStyleBackColor = true;

            // pnlRightViTri
            this.pnlRightViTri.Controls.Add(this.grbThongTinViTri);
            this.pnlRightViTri.Dock = DockStyle.Right;
            this.pnlRightViTri.Location = new Point(570, 8);
            this.pnlRightViTri.Name = "pnlRightViTri";
            this.pnlRightViTri.Padding = new Padding(8, 0, 0, 0);
            this.pnlRightViTri.Size = new Size(390, 504);
            this.pnlRightViTri.TabIndex = 1;

            // grbThongTinViTri
            this.grbThongTinViTri.Controls.Add(this.tlpViTri);
            this.grbThongTinViTri.Controls.Add(this.flpButtonsViTri);
            this.grbThongTinViTri.Dock = DockStyle.Fill;
            this.grbThongTinViTri.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbThongTinViTri.Location = new Point(8, 0);
            this.grbThongTinViTri.Name = "grbThongTinViTri";
            this.grbThongTinViTri.Padding = new Padding(14, 38, 14, 12);
            this.grbThongTinViTri.Size = new Size(382, 504);
            this.grbThongTinViTri.TabIndex = 0;
            this.grbThongTinViTri.TabStop = false;
            this.grbThongTinViTri.Text = "Thông tin khu vực";

            // tlpViTri
            this.tlpViTri.ColumnCount = 2;
            this.tlpViTri.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            this.tlpViTri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpViTri.Controls.Add(this.lblMaViTri, 0, 0);
            this.tlpViTri.Controls.Add(this.txtMaViTri, 1, 0);
            this.tlpViTri.Controls.Add(this.lblTenViTri, 0, 1);
            this.tlpViTri.Controls.Add(this.txtTenViTri, 1, 1);
            this.tlpViTri.Controls.Add(this.lblMoTa, 0, 2);
            this.tlpViTri.Controls.Add(this.txtMoTa, 1, 2);
            this.tlpViTri.Dock = DockStyle.Top;
            this.tlpViTri.Font = new Font("Segoe UI", 10F);
            this.tlpViTri.Location = new Point(14, 38);
            this.tlpViTri.Name = "tlpViTri";
            this.tlpViTri.RowCount = 3;
            this.tlpViTri.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpViTri.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpViTri.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            this.tlpViTri.Size = new Size(354, 190);
            this.tlpViTri.TabIndex = 0;

            // lblMaViTri
            this.lblMaViTri.Dock = DockStyle.Fill;
            this.lblMaViTri.Name = "lblMaViTri";
            this.lblMaViTri.Text = "Mã KV (*):";
            this.lblMaViTri.TextAlign = ContentAlignment.MiddleLeft;

            // txtMaViTri
            this.txtMaViTri.Dock = DockStyle.Fill;
            this.txtMaViTri.Font = new Font("Segoe UI", 10.5F);
            this.txtMaViTri.MaxLength = 20;
            this.txtMaViTri.Name = "txtMaViTri";

            // lblTenViTri
            this.lblTenViTri.Dock = DockStyle.Fill;
            this.lblTenViTri.Name = "lblTenViTri";
            this.lblTenViTri.Text = "Tên KV (*):";
            this.lblTenViTri.TextAlign = ContentAlignment.MiddleLeft;

            // txtTenViTri
            this.txtTenViTri.Dock = DockStyle.Fill;
            this.txtTenViTri.Font = new Font("Segoe UI", 10.5F);
            this.txtTenViTri.MaxLength = 100;
            this.txtTenViTri.Name = "txtTenViTri";

            // lblMoTa
            this.lblMoTa.Dock = DockStyle.Fill;
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.TextAlign = ContentAlignment.TopLeft;

            // txtMoTa
            this.txtMoTa.Dock = DockStyle.Fill;
            this.txtMoTa.Font = new Font("Segoe UI", 10F);
            this.txtMoTa.MaxLength = 255;
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = ScrollBars.Vertical;

            // flpButtonsViTri
            this.flpButtonsViTri.ColumnCount = 2;
            this.flpButtonsViTri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtonsViTri.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.flpButtonsViTri.Controls.Add(this.btnThemViTri, 0, 0);
            this.flpButtonsViTri.Controls.Add(this.btnSuaViTri, 1, 0);
            this.flpButtonsViTri.Controls.Add(this.btnXoaViTri, 0, 1);
            this.flpButtonsViTri.Controls.Add(this.btnLamMoiViTri, 1, 1);
            this.flpButtonsViTri.Dock = DockStyle.Bottom;
            this.flpButtonsViTri.Location = new Point(14, 404);
            this.flpButtonsViTri.Name = "flpButtonsViTri";
            this.flpButtonsViTri.RowCount = 2;
            this.flpButtonsViTri.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtonsViTri.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.flpButtonsViTri.Size = new Size(354, 88);
            this.flpButtonsViTri.TabIndex = 1;

            // btnThemViTri
            this.btnThemViTri.Cursor = Cursors.Hand;
            this.btnThemViTri.Dock = DockStyle.Fill;
            this.btnThemViTri.FlatAppearance.BorderSize = 0;
            this.btnThemViTri.FlatStyle = FlatStyle.Flat;
            this.btnThemViTri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnThemViTri.ForeColor = Color.White;
            this.btnThemViTri.Margin = new Padding(0, 0, 5, 5);
            this.btnThemViTri.Name = "btnThemViTri";
            this.btnThemViTri.Size = new Size(172, 39);
            this.btnThemViTri.TabIndex = 0;
            this.btnThemViTri.Tag = "success";
            this.btnThemViTri.Text = "Thêm";
            this.btnThemViTri.UseVisualStyleBackColor = true;

            // btnSuaViTri
            this.btnSuaViTri.Cursor = Cursors.Hand;
            this.btnSuaViTri.Dock = DockStyle.Fill;
            this.btnSuaViTri.FlatAppearance.BorderSize = 0;
            this.btnSuaViTri.FlatStyle = FlatStyle.Flat;
            this.btnSuaViTri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSuaViTri.ForeColor = Color.White;
            this.btnSuaViTri.Margin = new Padding(5, 0, 0, 5);
            this.btnSuaViTri.Name = "btnSuaViTri";
            this.btnSuaViTri.Size = new Size(172, 39);
            this.btnSuaViTri.TabIndex = 1;
            this.btnSuaViTri.Tag = "primary";
            this.btnSuaViTri.Text = "Sửa";
            this.btnSuaViTri.UseVisualStyleBackColor = true;

            // btnXoaViTri
            this.btnXoaViTri.Cursor = Cursors.Hand;
            this.btnXoaViTri.Dock = DockStyle.Fill;
            this.btnXoaViTri.FlatAppearance.BorderSize = 0;
            this.btnXoaViTri.FlatStyle = FlatStyle.Flat;
            this.btnXoaViTri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnXoaViTri.ForeColor = Color.White;
            this.btnXoaViTri.Margin = new Padding(0, 5, 5, 0);
            this.btnXoaViTri.Name = "btnXoaViTri";
            this.btnXoaViTri.Size = new Size(172, 39);
            this.btnXoaViTri.TabIndex = 2;
            this.btnXoaViTri.Tag = "danger";
            this.btnXoaViTri.Text = "Xóa";
            this.btnXoaViTri.UseVisualStyleBackColor = true;

            // btnLamMoiViTri
            this.btnLamMoiViTri.Cursor = Cursors.Hand;
            this.btnLamMoiViTri.Dock = DockStyle.Fill;
            this.btnLamMoiViTri.FlatAppearance.BorderSize = 0;
            this.btnLamMoiViTri.FlatStyle = FlatStyle.Flat;
            this.btnLamMoiViTri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLamMoiViTri.ForeColor = Color.White;
            this.btnLamMoiViTri.Margin = new Padding(5, 5, 0, 0);
            this.btnLamMoiViTri.Name = "btnLamMoiViTri";
            this.btnLamMoiViTri.Size = new Size(172, 39);
            this.btnLamMoiViTri.TabIndex = 3;
            this.btnLamMoiViTri.Tag = "neutral";
            this.btnLamMoiViTri.Text = "Làm mới";
            this.btnLamMoiViTri.UseVisualStyleBackColor = true;

            // pnlLeftViTri
            this.pnlLeftViTri.Controls.Add(this.grbDanhSachViTri);
            this.pnlLeftViTri.Dock = DockStyle.Fill;
            this.pnlLeftViTri.Location = new Point(8, 8);
            this.pnlLeftViTri.Name = "pnlLeftViTri";
            this.pnlLeftViTri.Padding = new Padding(0, 0, 8, 0);
            this.pnlLeftViTri.Size = new Size(562, 504);
            this.pnlLeftViTri.TabIndex = 0;

            // grbDanhSachViTri
            this.grbDanhSachViTri.Controls.Add(this.dgvViTri);
            this.grbDanhSachViTri.Dock = DockStyle.Fill;
            this.grbDanhSachViTri.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.grbDanhSachViTri.Location = new Point(0, 0);
            this.grbDanhSachViTri.Name = "grbDanhSachViTri";
            this.grbDanhSachViTri.Padding = new Padding(12, 38, 12, 12);
            this.grbDanhSachViTri.Size = new Size(554, 504);
            this.grbDanhSachViTri.TabIndex = 0;
            this.grbDanhSachViTri.TabStop = false;
            this.grbDanhSachViTri.Text = "Danh sách khu vực / vị trí";

            // dgvViTri
            this.dgvViTri.AllowUserToAddRows = false;
            this.dgvViTri.AllowUserToDeleteRows = false;
            this.dgvViTri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViTri.BackgroundColor = SystemColors.Window;
            this.dgvViTri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViTri.Columns.AddRange(new DataGridViewColumn[] {
                this.colMaViTri,
                this.colTenViTri,
                this.colMoTa
            });
            this.dgvViTri.Dock = DockStyle.Fill;
            this.dgvViTri.Font = new Font("Segoe UI", 10F);
            this.dgvViTri.Location = new Point(12, 38);
            this.dgvViTri.MultiSelect = false;
            this.dgvViTri.Name = "dgvViTri";
            this.dgvViTri.ReadOnly = true;
            this.dgvViTri.RowHeadersVisible = false;
            this.dgvViTri.RowHeadersWidth = 51;
            this.dgvViTri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvViTri.Size = new Size(530, 454);
            this.dgvViTri.TabIndex = 0;

            // colMaViTri
            this.colMaViTri.DataPropertyName = "MaViTri";
            this.colMaViTri.FillWeight = 80F;
            this.colMaViTri.HeaderText = "Mã KV";
            this.colMaViTri.Name = "colMaViTri";
            this.colMaViTri.ReadOnly = true;

            // colTenViTri
            this.colTenViTri.DataPropertyName = "TenViTri";
            this.colTenViTri.FillWeight = 120F;
            this.colTenViTri.HeaderText = "Tên khu vực";
            this.colTenViTri.Name = "colTenViTri";
            this.colTenViTri.ReadOnly = true;

            // colMoTa
            this.colMoTa.DataPropertyName = "MoTa";
            this.colMoTa.FillWeight = 180F;
            this.colMoTa.HeaderText = "Mô tả";
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.ReadOnly = true;

            // FormBan
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 580);
            this.Controls.Add(this.tabMain);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "FormBan";
            this.Padding = new Padding(12);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn và khu vực";

            this.tabMain.ResumeLayout(false);
            this.tabBan.ResumeLayout(false);
            this.pnlRightBan.ResumeLayout(false);
            this.grbThongTinBan.ResumeLayout(false);
            this.tlpBan.ResumeLayout(false);
            this.tlpBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoChoNgoi)).EndInit();
            this.flpButtonsBan.ResumeLayout(false);
            this.pnlLeftBan.ResumeLayout(false);
            this.grbDanhSachBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.tabKhuVuc.ResumeLayout(false);
            this.pnlRightViTri.ResumeLayout(false);
            this.grbThongTinViTri.ResumeLayout(false);
            this.tlpViTri.ResumeLayout(false);
            this.tlpViTri.PerformLayout();
            this.flpButtonsViTri.ResumeLayout(false);
            this.pnlLeftViTri.ResumeLayout(false);
            this.grbDanhSachViTri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTri)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabBan;
        private TabPage tabKhuVuc;
        private Panel pnlLeftBan;
        private GroupBox grbThongTinBan;
        private TableLayoutPanel tlpBan;
        private Label lblMaBan;
        private TextBox txtMaBan;
        private Label lblSoBan;
        private NumericUpDown numSoBan;
        private Label lblSoChoNgoi;
        private NumericUpDown numSoChoNgoi;
        private Label lblViTri;
        private ComboBox cboViTri;
        private Label lblTrangThaiTitle;
        private Label lblHienTrangThai;
        private TableLayoutPanel flpButtonsBan;
        private Button btnLamMoiBan;
        private Button btnThemBan;
        private Button btnSuaBan;
        private Button btnXoaBan;
        private Panel pnlRightBan;
        private GroupBox grbDanhSachBan;
        private DataGridView dgvBan;
        private DataGridViewTextBoxColumn colMaBan;
        private DataGridViewTextBoxColumn colSoBan;
        private DataGridViewTextBoxColumn colSoChoNgoi;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colKhuVuc;
        private Panel pnlLeftViTri;
        private GroupBox grbThongTinViTri;
        private TableLayoutPanel tlpViTri;
        private Label lblMaViTri;
        private TextBox txtMaViTri;
        private Label lblTenViTri;
        private TextBox txtTenViTri;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private TableLayoutPanel flpButtonsViTri;
        private Button btnLamMoiViTri;
        private Button btnThemViTri;
        private Button btnSuaViTri;
        private Button btnXoaViTri;
        private Panel pnlRightViTri;
        private GroupBox grbDanhSachViTri;
        private DataGridView dgvViTri;
        private DataGridViewTextBoxColumn colMaViTri;
        private DataGridViewTextBoxColumn colTenViTri;
        private DataGridViewTextBoxColumn colMoTa;
    }
}

