namespace QuanLyQuanCafe.GUI.Auth
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblPhuDe = new Label();
            this.lblTieuDe = new Label();
            this.lblIcon = new Label();
            this.pnlContainer = new Panel();
            this.pnlCard = new Panel();
            this.tlpMain = new TableLayoutPanel();
            this.lblSoDienThoai = new Label();
            this.txtSoDienThoai = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.chkHienMatKhau = new CheckBox();
            this.tlpButtons = new FlowLayoutPanel();
            this.btnDangNhap = new Button();
            this.btnThoat = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblPhuDe);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 145;
            this.pnlHeader.Name = "pnlHeader";

            // lblIcon
            this.lblIcon.Dock = DockStyle.Top;
            this.lblIcon.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            this.lblIcon.ForeColor = Color.White;
            this.lblIcon.Height = 52;
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Text = "☕";
            this.lblIcon.TextAlign = ContentAlignment.BottomCenter;

            // lblTieuDe
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.White;
            this.lblTieuDe.Height = 40;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Quản lý quán cà phê";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // lblPhuDe
            this.lblPhuDe.Dock = DockStyle.Top;
            this.lblPhuDe.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.lblPhuDe.ForeColor = Color.FromArgb(220, 225, 240);
            this.lblPhuDe.Height = 26;
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.lblPhuDe.TextAlign = ContentAlignment.TopCenter;

            // pnlContainer
            this.pnlContainer.Controls.Add(this.pnlCard);
            this.pnlContainer.Dock = DockStyle.Fill;
            this.pnlContainer.Location = new Point(0, 145);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new Padding(32, 20, 32, 24);
            this.pnlContainer.Size = new Size(460, 415);
            this.pnlContainer.TabIndex = 0;

            // pnlCard
            this.pnlCard.Controls.Add(this.tlpMain);
            this.pnlCard.Dock = DockStyle.Fill;
            this.pnlCard.Location = new Point(32, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new Padding(24, 20, 24, 20);
            this.pnlCard.Size = new Size(396, 371);
            this.pnlCard.TabIndex = 0;

            // tlpMain
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblSoDienThoai, 0, 0);
            this.tlpMain.Controls.Add(this.txtSoDienThoai, 0, 1);
            this.tlpMain.Controls.Add(this.lblMatKhau, 0, 2);
            this.tlpMain.Controls.Add(this.txtMatKhau, 0, 3);
            this.tlpMain.Controls.Add(this.chkHienMatKhau, 0, 4);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 5);
            this.tlpMain.Dock = DockStyle.Fill;
            this.tlpMain.Location = new Point(24, 20);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpMain.Size = new Size(348, 331);
            this.tlpMain.TabIndex = 0;

            // lblSoDienThoai
            this.lblSoDienThoai.Dock = DockStyle.Fill;
            this.lblSoDienThoai.Font = new Font("Segoe UI", 10F);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Số điện thoại:";
            this.lblSoDienThoai.TextAlign = ContentAlignment.BottomLeft;

            // txtSoDienThoai
            this.txtSoDienThoai.Dock = DockStyle.Fill;
            this.txtSoDienThoai.Font = new Font("Segoe UI", 11F);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.TabIndex = 0;

            // lblMatKhau
            this.lblMatKhau.Dock = DockStyle.Fill;
            this.lblMatKhau.Font = new Font("Segoe UI", 10F);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.TextAlign = ContentAlignment.BottomLeft;

            // txtMatKhau
            this.txtMatKhau.Dock = DockStyle.Fill;
            this.txtMatKhau.Font = new Font("Segoe UI", 11F);
            this.txtMatKhau.MaxLength = 255;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;

            // chkHienMatKhau
            this.chkHienMatKhau.Dock = DockStyle.Fill;
            this.chkHienMatKhau.Font = new Font("Segoe UI", 10F);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.TabIndex = 2;

            // tlpButtons
            this.tlpButtons.Controls.Add(this.btnDangNhap);
            this.tlpButtons.Controls.Add(this.btnThoat);
            this.tlpButtons.Dock = DockStyle.Fill;
            this.tlpButtons.FlowDirection = FlowDirection.TopDown;
            this.tlpButtons.Location = new Point(0, 166);
            this.tlpButtons.Margin = new Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.Size = new Size(348, 165);
            this.tlpButtons.TabIndex = 3;

            // btnDangNhap
            this.btnDangNhap.Cursor = Cursors.Hand;
            this.btnDangNhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnDangNhap.Margin = new Padding(0, 10, 0, 8);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new Size(348, 44);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Tag = "primary";
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;

            // btnThoat
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Font = new Font("Segoe UI", 10F);
            this.btnThoat.Margin = new Padding(0, 4, 0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new Size(348, 38);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Tag = "neutral";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;

            // FormDangNhap
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new Size(460, 560);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDangNhap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý quán cà phê";

            this.pnlHeader.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblIcon;
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Panel pnlContainer;
        private Panel pnlCard;
        private TableLayoutPanel tlpMain;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private FlowLayoutPanel tlpButtons;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}

