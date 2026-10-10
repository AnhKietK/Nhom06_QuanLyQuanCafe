namespace QuanLyQuanCafe.GUI.Kho
{
    partial class FormNhaCungCap
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvNhaCungCap = new System.Windows.Forms.DataGridView();
            this.colMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
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
            this.lblTieuDeTrang.Size = new System.Drawing.Size(285, 40);
            this.lblTieuDeTrang.TabIndex = 0;
            this.lblTieuDeTrang.Tag = "tieude";
            this.lblTieuDeTrang.Text = "Quản lý nhà cung cấp";
            this.lblTieuDeTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlSearch
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSearch.Location = new System.Drawing.Point(676, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.pnlSearch.Size = new System.Drawing.Size(396, 40);
            this.pnlSearch.TabIndex = 1;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Location = new System.Drawing.Point(0, 4);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Padding = new System.Windows.Forms.Padding(0, 5, 8, 0);
            this.lblTimKiem.Size = new System.Drawing.Size(116, 32);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Tag = "phu";
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // txtTimKiem
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(116, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Mã, tên, số điện thoại...";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 31);
            this.txtTimKiem.TabIndex = 1;

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
            this.grbThongTin.Text = "Thông tin nhà cung cấp";

            // tlpInput
            this.tlpInput.ColumnCount = 2;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInput.Controls.Add(this.lblMaNCC, 0, 0);
            this.tlpInput.Controls.Add(this.txtMaNCC, 1, 0);
            this.tlpInput.Controls.Add(this.lblTenNCC, 0, 1);
            this.tlpInput.Controls.Add(this.txtTenNCC, 1, 1);
            this.tlpInput.Controls.Add(this.lblSoDienThoai, 0, 2);
            this.tlpInput.Controls.Add(this.txtSoDienThoai, 1, 2);
            this.tlpInput.Controls.Add(this.lblEmail, 0, 3);
            this.tlpInput.Controls.Add(this.txtEmail, 1, 3);
            this.tlpInput.Controls.Add(this.lblDiaChi, 0, 4);
            this.tlpInput.Controls.Add(this.txtDiaChi, 1, 4);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tlpInput.Location = new System.Drawing.Point(14, 38);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 5;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpInput.Size = new System.Drawing.Size(364, 238);
            this.tlpInput.TabIndex = 0;

            // lblMaNCC
            this.lblMaNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Text = "Mã NCC (*):";
            this.lblMaNCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtMaNCC
            this.txtMaNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNCC.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtMaNCC.MaxLength = 20;
            this.txtMaNCC.Name = "txtMaNCC";

            // lblTenNCC
            this.lblTenNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Text = "Tên NCC (*):";
            this.lblTenNCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtTenNCC
            this.txtTenNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNCC.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTenNCC.MaxLength = 150;
            this.txtTenNCC.Name = "txtTenNCC";

            // lblSoDienThoai
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Số điện thoại:";
            this.lblSoDienThoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtSoDienThoai
            this.txtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";

            // lblEmail
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // txtEmail
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";

            // lblDiaChi
            this.lblDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblDiaChi.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            // txtDiaChi
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtDiaChi.MaxLength = 255;
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

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
            this.grbDanhSach.Controls.Add(this.dgvNhaCungCap);
            this.grbDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDanhSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grbDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(12, 28, 12, 12);
            this.grbDanhSach.Size = new System.Drawing.Size(668, 574);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách nhà cung cấp";

            // dgvNhaCungCap
            this.dgvNhaCungCap.AllowUserToAddRows = false;
            this.dgvNhaCungCap.AllowUserToDeleteRows = false;
            this.dgvNhaCungCap.AllowUserToResizeRows = false;
            this.dgvNhaCungCap.AutoGenerateColumns = false;
            this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaNCC,
                this.colTenNCC,
                this.colSoDienThoai,
                this.colEmail,
                this.colDiaChi
            });
            this.dgvNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhaCungCap.Location = new System.Drawing.Point(12, 28);
            this.dgvNhaCungCap.MultiSelect = false;
            this.dgvNhaCungCap.Name = "dgvNhaCungCap";
            this.dgvNhaCungCap.ReadOnly = true;
            this.dgvNhaCungCap.RowHeadersVisible = false;
            this.dgvNhaCungCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhaCungCap.Size = new System.Drawing.Size(644, 534);
            this.dgvNhaCungCap.TabIndex = 0;

            // colMaNCC
            this.colMaNCC.DataPropertyName = "MaNCC";
            this.colMaNCC.HeaderText = "Mã NCC";
            this.colMaNCC.Name = "colMaNCC";
            this.colMaNCC.ReadOnly = true;
            this.colMaNCC.Width = 95;

            // colTenNCC
            this.colTenNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNCC.DataPropertyName = "TenNCC";
            this.colTenNCC.HeaderText = "Tên nhà cung cấp";
            this.colTenNCC.MinimumWidth = 150;
            this.colTenNCC.Name = "colTenNCC";
            this.colTenNCC.ReadOnly = true;

            // colSoDienThoai
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoDienThoai.HeaderText = "Số điện thoại";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            this.colSoDienThoai.Width = 115;

            // colEmail
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 150;

            // colDiaChi
            this.colDiaChi.DataPropertyName = "DiaChi";
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            this.colDiaChi.Width = 180;

            // FormNhaCungCap
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhaCungCap";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Quản lý nhà cung cấp";

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
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TableLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
    }
}

