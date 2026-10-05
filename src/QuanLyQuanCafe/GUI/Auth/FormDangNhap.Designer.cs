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
            this.tlpMain = new TableLayoutPanel();
            this.lblSoDienThoai = new Label();
            this.lblMatKhau = new Label();
            this.txtSoDienThoai = new TextBox();
            this.txtMatKhau = new TextBox();
            this.chkHienMatKhau = new CheckBox();
            this.tlpButtons = new FlowLayoutPanel();
            this.btnDangNhap = new Button();
            this.btnThoat = new Button();
            this.lblTieuDe = new Label();

            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();

            // lblTieuDe
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Dock = DockStyle.Top;
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.Text = "☕ Quản lý quán cà phê";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTieuDe.Height = 60;

            // tlpMain
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tlpMain.Dock = DockStyle.Fill;
            this.tlpMain.Padding = new Padding(20, 10, 20, 10);

            // lblSoDienThoai
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Text = "Số điện thoại:";
            this.lblSoDienThoai.Dock = DockStyle.Fill;
            this.lblSoDienThoai.TextAlign = ContentAlignment.MiddleLeft;

            // txtSoDienThoai
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Dock = DockStyle.Fill;
            this.txtSoDienThoai.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.TabIndex = 0;

            // lblMatKhau
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.Dock = DockStyle.Fill;
            this.lblMatKhau.TextAlign = ContentAlignment.MiddleLeft;

            // txtMatKhau
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Dock = DockStyle.Fill;
            this.txtMatKhau.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.MaxLength = 255;
            this.txtMatKhau.TabIndex = 1;

            // chkHienMatKhau
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.Dock = DockStyle.Fill;
            this.chkHienMatKhau.TabIndex = 2;

            // tlpButtons
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.FlowDirection = FlowDirection.RightToLeft;
            this.tlpButtons.Dock = DockStyle.Fill;

            // btnDangNhap
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Size = new Size(110, 35);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.UseVisualStyleBackColor = true;

            // btnThoat
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Size = new Size(90, 35);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.UseVisualStyleBackColor = true;

            // Thêm control vào layout
            this.tlpMain.Controls.Add(this.lblSoDienThoai, 0, 0);
            this.tlpMain.Controls.Add(this.txtSoDienThoai, 1, 0);
            this.tlpMain.Controls.Add(this.lblMatKhau, 0, 1);
            this.tlpMain.Controls.Add(this.txtMatKhau, 1, 1);
            this.tlpMain.Controls.Add(this.chkHienMatKhau, 1, 2);
            this.tlpMain.Controls.Add(this.tlpButtons, 1, 3);

            this.tlpButtons.Controls.Add(this.btnDangNhap);
            this.tlpButtons.Controls.Add(this.btnThoat);

            // FormDangNhap
            this.AcceptButton = this.btnDangNhap;
            this.CancelButton = this.btnThoat;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(420, 280);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDangNhap";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý quán cà phê";

            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Label lblTieuDe;
        private Label lblSoDienThoai;
        private Label lblMatKhau;
        private TextBox txtSoDienThoai;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private FlowLayoutPanel tlpButtons;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}
