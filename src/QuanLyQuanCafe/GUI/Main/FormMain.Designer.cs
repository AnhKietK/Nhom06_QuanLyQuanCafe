namespace QuanLyQuanCafe.GUI.Main
{
    partial class FormMain
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
            this.pnlHeader = new Panel();
            this.lblThuongHieu = new Label();
            this.mnuMain = new MenuStrip();
            this.tlpNguoiDung = new TableLayoutPanel();
            this.lblNguoiDung = new Label();
            this.btnDangXuat = new Button();
            this.stsMain = new StatusStrip();
            this.lblTrangThai = new ToolStripStatusLabel();

            this.pnlHeader.SuspendLayout();
            this.tlpNguoiDung.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.mnuMain);
            this.pnlHeader.Controls.Add(this.tlpNguoiDung);
            this.pnlHeader.Controls.Add(this.lblThuongHieu);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(900, 68);
            this.pnlHeader.TabIndex = 0;

            // lblThuongHieu
            this.lblThuongHieu.AutoSize = true;
            this.lblThuongHieu.BackColor = Color.Transparent;
            this.lblThuongHieu.Dock = DockStyle.Left;
            this.lblThuongHieu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblThuongHieu.ForeColor = Color.White;
            this.lblThuongHieu.Location = new Point(0, 0);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Padding = new Padding(20, 0, 16, 0);
            this.lblThuongHieu.Size = new Size(272, 68);
            this.lblThuongHieu.TabIndex = 2;
            this.lblThuongHieu.Text = "Quản lý quán cà phê";
            this.lblThuongHieu.TextAlign = ContentAlignment.MiddleLeft;

            // tlpNguoiDung
            this.tlpNguoiDung.AutoSize = true;
            this.tlpNguoiDung.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tlpNguoiDung.BackColor = Color.Transparent;
            this.tlpNguoiDung.ColumnCount = 2;
            this.tlpNguoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.tlpNguoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.tlpNguoiDung.Controls.Add(this.lblNguoiDung, 0, 0);
            this.tlpNguoiDung.Controls.Add(this.btnDangXuat, 1, 0);
            this.tlpNguoiDung.Dock = DockStyle.Right;
            this.tlpNguoiDung.Location = new Point(660, 0);
            this.tlpNguoiDung.Name = "tlpNguoiDung";
            this.tlpNguoiDung.Padding = new Padding(10, 0, 16, 0);
            this.tlpNguoiDung.RowCount = 1;
            this.tlpNguoiDung.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpNguoiDung.Size = new Size(240, 68);
            this.tlpNguoiDung.TabIndex = 1;

            // lblNguoiDung
            this.lblNguoiDung.Anchor = AnchorStyles.Right;
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.BackColor = Color.Transparent;
            this.lblNguoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblNguoiDung.ForeColor = Color.White;
            this.lblNguoiDung.Margin = new Padding(0, 0, 12, 0);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new Size(62, 23);
            this.lblNguoiDung.TabIndex = 0;
            this.lblNguoiDung.Text = "Xin chào";
            this.lblNguoiDung.TextAlign = ContentAlignment.MiddleRight;

            // btnDangXuat
            this.btnDangXuat.Anchor = AnchorStyles.Right;
            this.btnDangXuat.Cursor = Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = FlatStyle.Flat;
            this.btnDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDangXuat.ForeColor = Color.White;
            this.btnDangXuat.Margin = new Padding(0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new Size(100, 36);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Tag = "primary";
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;

            // mnuMain
            this.mnuMain.AutoSize = false;
            this.mnuMain.BackColor = Color.Transparent;
            this.mnuMain.Dock = DockStyle.Fill;
            this.mnuMain.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.mnuMain.GripStyle = ToolStripGripStyle.Hidden;
            this.mnuMain.Location = new Point(272, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new Padding(10, 18, 10, 0);
            this.mnuMain.RenderMode = ToolStripRenderMode.Professional;
            this.mnuMain.Size = new Size(388, 68);
            this.mnuMain.TabIndex = 0;

            // stsMain
            this.stsMain.Font = new Font("Segoe UI", 10F);
            this.stsMain.Items.AddRange(new ToolStripItem[] { this.lblTrangThai });
            this.stsMain.Location = new Point(0, 524);
            this.stsMain.Name = "stsMain";
            this.stsMain.RenderMode = ToolStripRenderMode.Professional;
            this.stsMain.Size = new Size(900, 26);
            this.stsMain.TabIndex = 2;

            // lblTrangThai
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Xin chào";

            // FormMain
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 10F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán cà phê";
            this.WindowState = FormWindowState.Maximized;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpNguoiDung.ResumeLayout(false);
            this.tlpNguoiDung.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblThuongHieu;
        private TableLayoutPanel tlpNguoiDung;
        private Label lblNguoiDung;
        private Button btnDangXuat;
        private MenuStrip mnuMain;
        private StatusStrip stsMain;
        private ToolStripStatusLabel lblTrangThai;
    }
}

