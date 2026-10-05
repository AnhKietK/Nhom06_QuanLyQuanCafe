namespace QuanLyQuanCafe.GUI.Auth
{
    partial class FormDoiMatKhau
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
            this.lblMatKhauCu = new Label();
            this.lblMatKhauMoi = new Label();
            this.lblXacNhan = new Label();
            this.txtMatKhauCu = new TextBox();
            this.txtMatKhauMoi = new TextBox();
            this.txtXacNhan = new TextBox();
            this.tlpButtons = new FlowLayoutPanel();
            this.btnLuu = new Button();
            this.btnHuy = new Button();

            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();

            // tlpMain
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tlpMain.Dock = DockStyle.Fill;
            this.tlpMain.Padding = new Padding(20, 15, 20, 10);

            // lblMatKhauCu
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Text = "Mật khẩu cũ:";
            this.lblMatKhauCu.Dock = DockStyle.Fill;
            this.lblMatKhauCu.TextAlign = ContentAlignment.MiddleLeft;

            // txtMatKhauCu
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Dock = DockStyle.Fill;
            this.txtMatKhauCu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            this.txtMatKhauCu.MaxLength = 255;
            this.txtMatKhauCu.TabIndex = 0;

            // lblMatKhauMoi
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            this.lblMatKhauMoi.Dock = DockStyle.Fill;
            this.lblMatKhauMoi.TextAlign = ContentAlignment.MiddleLeft;

            // txtMatKhauMoi
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Dock = DockStyle.Fill;
            this.txtMatKhauMoi.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            this.txtMatKhauMoi.MaxLength = 255;
            this.txtMatKhauMoi.TabIndex = 1;

            // lblXacNhan
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Text = "Xác nhận mật khẩu:";
            this.lblXacNhan.Dock = DockStyle.Fill;
            this.lblXacNhan.TextAlign = ContentAlignment.MiddleLeft;

            // txtXacNhan
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.Dock = DockStyle.Fill;
            this.txtXacNhan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtXacNhan.UseSystemPasswordChar = true;
            this.txtXacNhan.MaxLength = 255;
            this.txtXacNhan.TabIndex = 2;

            // tlpButtons
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.FlowDirection = FlowDirection.RightToLeft;
            this.tlpButtons.Dock = DockStyle.Fill;

            // btnLuu
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Size = new Size(100, 35);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.UseVisualStyleBackColor = true;

            // btnHuy
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Size = new Size(90, 35);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.UseVisualStyleBackColor = true;

            // Thêm control vào layout
            this.tlpMain.Controls.Add(this.lblMatKhauCu, 0, 0);
            this.tlpMain.Controls.Add(this.txtMatKhauCu, 1, 0);
            this.tlpMain.Controls.Add(this.lblMatKhauMoi, 0, 1);
            this.tlpMain.Controls.Add(this.txtMatKhauMoi, 1, 1);
            this.tlpMain.Controls.Add(this.lblXacNhan, 0, 2);
            this.tlpMain.Controls.Add(this.txtXacNhan, 1, 2);
            this.tlpMain.Controls.Add(this.tlpButtons, 1, 3);

            this.tlpButtons.Controls.Add(this.btnLuu);
            this.tlpButtons.Controls.Add(this.btnHuy);

            // FormDoiMatKhau
            this.AcceptButton = this.btnLuu;
            this.CancelButton = this.btnHuy;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(430, 230);
            this.Controls.Add(this.tlpMain);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoiMatKhau";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";

            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblXacNhan;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhan;
        private FlowLayoutPanel tlpButtons;
        private Button btnLuu;
        private Button btnHuy;
    }
}
