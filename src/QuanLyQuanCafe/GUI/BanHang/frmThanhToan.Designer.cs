namespace QuanLyQuanCafe.GUI.BanHang
{
    partial class frmThanhToan
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblThongTinDon = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTietTT = new System.Windows.Forms.DataGridView();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.tlpThanhToan = new System.Windows.Forms.TableLayoutPanel();
            this.lblTienHangTieuDe = new System.Windows.Forms.Label();
            this.lblTienHang = new System.Windows.Forms.Label();
            this.lblGiamGiaTieuDe = new System.Windows.Forms.Label();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblTongCongTieuDe = new System.Windows.Forms.Label();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblPhuongThucTieuDe = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblTienKhachDuaTieuDe = new System.Windows.Forms.Label();
            this.numTienKhachDua = new System.Windows.Forms.NumericUpDown();
            this.lblTienThoiTieuDe = new System.Windows.Forms.Label();
            this.lblTienThoi = new System.Windows.Forms.Label();
            this.pnlTienNhanh = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTienVuaDu = new System.Windows.Forms.Button();
            this.btnTien50k = new System.Windows.Forms.Button();
            this.btnTien100k = new System.Windows.Forms.Button();
            this.btnTien200k = new System.Windows.Forms.Button();
            this.btnTien500k = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTT)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            this.tlpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).BeginInit();
            this.pnlTienNhanh.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblThongTinDon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 8);
            this.lblTitle.Text = "XÁC NHẬN THANH TOÁN";

            // 
            // lblThongTinDon
            // 
            this.lblThongTinDon.AutoSize = true;
            this.lblThongTinDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThongTinDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblThongTinDon.Location = new System.Drawing.Point(16, 38);
            this.lblThongTinDon.Text = "Hóa đơn: HD000000 | Bàn: -- | Thu ngân: --";

            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpThanhToan);
            this.pnlMain.Controls.Add(this.grpChiTiet);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);

            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.dgvChiTietTT);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChiTiet.Height = 210;
            this.grpChiTiet.Padding = new System.Windows.Forms.Padding(8);
            this.grpChiTiet.Text = "CHI TIẾT MÓN ĐÃ DÙNG";

            // 
            // dgvChiTietTT
            // 
            this.dgvChiTietTT.AllowUserToAddRows = false;
            this.dgvChiTietTT.AllowUserToDeleteRows = false;
            this.dgvChiTietTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietTT.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChiTietTT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTenMon, this.colSoLuong, this.colDonGia, this.colThanhTien
            });
            this.dgvChiTietTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietTT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvChiTietTT.ReadOnly = true;
            this.dgvChiTietTT.RowHeadersVisible = false;
            this.dgvChiTietTT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colTenMon.DataPropertyName = "TenThucUong";
            this.colTenMon.HeaderText = "Tên thức uống";
            this.colTenMon.FillWeight = 120F;

            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSoLuong.FillWeight = 35F;

            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.DefaultCellStyle.Format = "N0";
            this.colDonGia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDonGia.FillWeight = 60F;

            this.colThanhTien.DataPropertyName = "ThanhTien";
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.DefaultCellStyle.Format = "N0";
            this.colThanhTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThanhTien.FillWeight = 70F;

            // 
            // grpThanhToan
            // 
            this.grpThanhToan.Controls.Add(this.tlpThanhToan);
            this.grpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThanhToan.Padding = new System.Windows.Forms.Padding(10);
            this.grpThanhToan.Text = "TÍNH TOÁN & PHƯƠNG THỨC THANH TOÁN";

            // 
            // tlpThanhToan
            // 
            this.tlpThanhToan.ColumnCount = 2;
            this.tlpThanhToan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpThanhToan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpThanhToan.Controls.Add(this.lblTienHangTieuDe, 0, 0);
            this.tlpThanhToan.Controls.Add(this.lblTienHang, 1, 0);
            this.tlpThanhToan.Controls.Add(this.lblGiamGiaTieuDe, 0, 1);
            this.tlpThanhToan.Controls.Add(this.numGiamGia, 1, 1);
            this.tlpThanhToan.Controls.Add(this.lblTongCongTieuDe, 0, 2);
            this.tlpThanhToan.Controls.Add(this.lblTongCong, 1, 2);
            this.tlpThanhToan.Controls.Add(this.lblPhuongThucTieuDe, 0, 3);
            this.tlpThanhToan.Controls.Add(this.cboPhuongThuc, 1, 3);
            this.tlpThanhToan.Controls.Add(this.lblTienKhachDuaTieuDe, 0, 4);
            this.tlpThanhToan.Controls.Add(this.numTienKhachDua, 1, 4);
            this.tlpThanhToan.Controls.Add(this.pnlTienNhanh, 1, 5);
            this.tlpThanhToan.Controls.Add(this.lblTienThoiTieuDe, 0, 6);
            this.tlpThanhToan.Controls.Add(this.lblTienThoi, 1, 6);
            this.tlpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThanhToan.RowCount = 7;
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));

            // lblTienHangTieuDe
            this.lblTienHangTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienHangTieuDe.Location = new System.Drawing.Point(3, 4);
            this.lblTienHangTieuDe.Text = "Tiền hàng:";

            // lblTienHang
            this.lblTienHang.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTienHang.Location = new System.Drawing.Point(240, 4);
            this.lblTienHang.Text = "0 đ";

            // lblGiamGiaTieuDe
            this.lblGiamGiaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiamGiaTieuDe.Location = new System.Drawing.Point(3, 36);
            this.lblGiamGiaTieuDe.Text = "Tiền giảm giá:";

            // numGiamGia
            this.numGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numGiamGia.Location = new System.Drawing.Point(240, 34);
            this.numGiamGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiamGia.Size = new System.Drawing.Size(260, 29);
            this.numGiamGia.ThousandsSeparator = true;

            // lblTongCongTieuDe
            this.lblTongCongTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTongCongTieuDe.Location = new System.Drawing.Point(3, 70);
            this.lblTongCongTieuDe.Text = "TỔNG THANH TOÁN:";

            // lblTongCong
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTongCong.Location = new System.Drawing.Point(240, 68);
            this.lblTongCong.Text = "0 đ";

            // lblPhuongThucTieuDe
            this.lblPhuongThucTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhuongThucTieuDe.Location = new System.Drawing.Point(3, 108);
            this.lblPhuongThucTieuDe.Text = "Phương thức:";

            // cboPhuongThuc
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPhuongThuc.Location = new System.Drawing.Point(240, 106);
            this.cboPhuongThuc.Size = new System.Drawing.Size(260, 29);

            // lblTienKhachDuaTieuDe
            this.lblTienKhachDuaTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienKhachDuaTieuDe.Location = new System.Drawing.Point(3, 144);
            this.lblTienKhachDuaTieuDe.Text = "Tiền khách đưa:";

            // numTienKhachDua
            this.numTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.numTienKhachDua.Location = new System.Drawing.Point(240, 142);
            this.numTienKhachDua.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTienKhachDua.Size = new System.Drawing.Size(260, 31);
            this.numTienKhachDua.ThousandsSeparator = true;

            // pnlTienNhanh
            this.pnlTienNhanh.Controls.Add(this.btnTienVuaDu);
            this.pnlTienNhanh.Controls.Add(this.btnTien50k);
            this.pnlTienNhanh.Controls.Add(this.btnTien100k);
            this.pnlTienNhanh.Controls.Add(this.btnTien200k);
            this.pnlTienNhanh.Controls.Add(this.btnTien500k);
            this.pnlTienNhanh.Location = new System.Drawing.Point(240, 178);
            this.pnlTienNhanh.Size = new System.Drawing.Size(430, 34);

            this.btnTienVuaDu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTienVuaDu.Size = new System.Drawing.Size(75, 28);
            this.btnTienVuaDu.Text = "Vừa đủ";

            this.btnTien50k.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTien50k.Size = new System.Drawing.Size(60, 28);
            this.btnTien50k.Text = "50k";

            this.btnTien100k.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTien100k.Size = new System.Drawing.Size(60, 28);
            this.btnTien100k.Text = "100k";

            this.btnTien200k.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTien200k.Size = new System.Drawing.Size(60, 28);
            this.btnTien200k.Text = "200k";

            this.btnTien500k.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnTien500k.Size = new System.Drawing.Size(60, 28);
            this.btnTien500k.Text = "500k";

            // lblTienThoiTieuDe
            this.lblTienThoiTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTienThoiTieuDe.Location = new System.Drawing.Point(3, 216);
            this.lblTienThoiTieuDe.Text = "Tiền thối lại:";

            // lblTienThoi
            this.lblTienThoi.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTienThoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblTienThoi.Location = new System.Drawing.Point(240, 214);
            this.lblTienThoi.Text = "0 đ";

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.Controls.Add(this.btnXacNhan);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 65;
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);

            // btnXacNhan
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(180, 12);
            this.btnXacNhan.Size = new System.Drawing.Size(260, 40);
            this.btnXacNhan.Text = "✅ XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.UseVisualStyleBackColor = false;

            // btnDong
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(460, 12);
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;

            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 660);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán hóa đơn";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTT)).EndInit();
            this.grpThanhToan.ResumeLayout(false);
            this.tlpThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienKhachDua)).EndInit();
            this.pnlTienNhanh.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblThongTinDon;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.TableLayoutPanel tlpThanhToan;
        private System.Windows.Forms.Label lblTienHangTieuDe;
        private System.Windows.Forms.Label lblTienHang;
        private System.Windows.Forms.Label lblGiamGiaTieuDe;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Label lblTongCongTieuDe;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label lblPhuongThucTieuDe;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Label lblTienKhachDuaTieuDe;
        private System.Windows.Forms.NumericUpDown numTienKhachDua;
        private System.Windows.Forms.FlowLayoutPanel pnlTienNhanh;
        private System.Windows.Forms.Button btnTienVuaDu;
        private System.Windows.Forms.Button btnTien50k;
        private System.Windows.Forms.Button btnTien100k;
        private System.Windows.Forms.Button btnTien200k;
        private System.Windows.Forms.Button btnTien500k;
        private System.Windows.Forms.Label lblTienThoiTieuDe;
        private System.Windows.Forms.Label lblTienThoi;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnDong;
    }
}
