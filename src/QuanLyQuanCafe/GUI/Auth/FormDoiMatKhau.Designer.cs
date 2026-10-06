namespace QuanLyQuanCafe.GUI.Auth
{
    partial class FormDoiMatKhau
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
            this.pnlCard = new Panel();
            this.tlpMain = new TableLayoutPanel();
            this.lblMatKhauCu = new Label();
            this.txtMatKhauCu = new TextBox();
            this.lblMatKhauMoi = new Label();
            this.txtMatKhauMoi = new TextBox();
            this.lblXacNhan = new Label();
            this.txtXacNhan = new TextBox();
            this.tlpButtons = new TableLayoutPanel();
            this.btnLuu = new Button();
            this.btnHuy = new Button();

            this.pnlCard.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();

            // pnlCard
            this.pnlCard.Controls.Add(this.tlpMain);
            this.pnlCard.Dock = DockStyle.Fill;
            this.pnlCard.Location = new Point(20, 16);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new Padding(24, 20, 24, 20);
            this.pnlCard.Size = new Size(380, 318);
            this.pnlCard.TabIndex = 0;

            // tlpMain
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblMatKhauCu, 0, 0);
            this.tlpMain.Controls.Add(this.txtMatKhauCu, 0, 1);
            this.tlpMain.Controls.Add(this.lblMatKhauMoi, 0, 2);
            this.tlpMain.Controls.Add(this.txtMatKhauMoi, 0, 3);
            this.tlpMain.Controls.Add(this.lblXacNhan, 0, 4);
            this.tlpMain.Controls.Add(this.txtXacNhan, 0, 5);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 6);
            this.tlpMain.Dock = DockStyle.Fill;
            this.tlpMain.Location = new Point(24, 20);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            this.tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tlpMain.Size = new Size(332, 278);
            this.tlpMain.TabIndex = 0;

            // lblMatKhauCu
            this.lblMatKhauCu.Dock = DockStyle.Fill;
            this.lblMatKhauCu.Font = new Font("Segoe UI", 10F);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Text = "Mật khẩu cũ:";
            this.lblMatKhauCu.TextAlign = ContentAlignment.BottomLeft;

            // txtMatKhauCu
            this.txtMatKhauCu.Dock = DockStyle.Fill;
            this.txtMatKhauCu.Font = new Font("Segoe UI", 11F);
            this.txtMatKhauCu.MaxLength = 255;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.TabIndex = 0;
            this.txtMatKhauCu.UseSystemPasswordChar = true;

            // lblMatKhauMoi
            this.lblMatKhauMoi.Dock = DockStyle.Fill;
            this.lblMatKhauMoi.Font = new Font("Segoe UI", 10F);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            this.lblMatKhauMoi.TextAlign = ContentAlignment.BottomLeft;

            // txtMatKhauMoi
            this.txtMatKhauMoi.Dock = DockStyle.Fill;
            this.txtMatKhauMoi.Font = new Font("Segoe UI", 11F);
            this.txtMatKhauMoi.MaxLength = 255;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;

            // lblXacNhan
            this.lblXacNhan.Dock = DockStyle.Fill;
            this.lblXacNhan.Font = new Font("Segoe UI", 10F);
            this.lblXacNhan.Name = "lblXacNhan";
            this.lblXacNhan.Text = "Xác nhận mật khẩu:";
            this.lblXacNhan.TextAlign = ContentAlignment.BottomLeft;

            // txtXacNhan
            this.txtXacNhan.Dock = DockStyle.Fill;
            this.txtXacNhan.Font = new Font("Segoe UI", 11F);
            this.txtXacNhan.MaxLength = 255;
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.TabIndex = 2;
            this.txtXacNhan.UseSystemPasswordChar = true;

            // tlpButtons
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnLuu, 0, 0);
            this.tlpButtons.Controls.Add(this.btnHuy, 1, 0);
            this.tlpButtons.Dock = DockStyle.Fill;
            this.tlpButtons.Location = new Point(0, 230);
            this.tlpButtons.Margin = new Padding(0, 10, 0, 0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpButtons.Size = new Size(332, 48);
            this.tlpButtons.TabIndex = 3;

            // btnLuu
            this.btnLuu.Cursor = Cursors.Hand;
            this.btnLuu.Dock = DockStyle.Fill;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = FlatStyle.Flat;
            this.btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLuu.ForeColor = Color.White;
            this.btnLuu.Margin = new Padding(0, 0, 6, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new Size(160, 48);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Tag = "success";
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;

            // btnHuy
            this.btnHuy.Cursor = Cursors.Hand;
            this.btnHuy.Dock = DockStyle.Fill;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.Margin = new Padding(6, 0, 0, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(160, 48);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Tag = "neutral";
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;

            // FormDoiMatKhau
            this.AcceptButton = this.btnLuu;
            this.CancelButton = this.btnHuy;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(420, 350);
            this.Controls.Add(this.pnlCard);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoiMatKhau";
            this.Padding = new Padding(20, 16, 20, 16);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";

            this.pnlCard.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private TableLayoutPanel tlpMain;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblXacNhan;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhan;
        private TableLayoutPanel tlpButtons;
        private Button btnLuu;
        private Button btnHuy;
    }
}

