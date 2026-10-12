using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Auth
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();

            // A spacious sign-in form alongside a dedicated brand panel.
            ClientSize = new Size(880, 560);
            pnlHeader.Dock = DockStyle.Left;
            pnlHeader.Width = 330;
            lblIcon.Height = 142;
            lblTieuDe.Height = 72;
            lblTieuDe.Text = "Quản lý\nquán cà phê";
            lblPhuDe.Height = 54;
            lblPhuDe.Text = "NHÓM 06  •  COFFEE WORKSPACE";
            lblPhuDe.Font = new Font("Segoe UI", 9F);
            var welcome = new Label
            {
                Dock = DockStyle.Bottom, Height = 168,
                Padding = new Padding(32, 0, 32, 28),
                Text = "Một không gian.\nMọi hoạt động của quán.\n\nBán hàng • Kho • Báo cáo",
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.Transparent, ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlHeader.Controls.Add(welcome);
            pnlContainer.Padding = new Padding(28, 32, 28, 32);
            pnlCard.Padding = new Padding(28, 68, 28, 28);
            var title = new Label
            {
                Text = "Chào mừng trở lại", AutoSize = true,
                Location = new Point(26, 22), Font = Theme.FontTieuDeTrang
            };
            pnlCard.Controls.Add(title);
            txtSoDienThoai.PlaceholderText = "Nhập số điện thoại";
            txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            tlpMain.RowStyles[1].Height = 50;
            tlpMain.RowStyles[3].Height = 50;
            tlpMain.RowStyles[4].Height = 44;
            tlpButtons.Resize += (_, _) =>
            {
                btnDangNhap.Width = Math.Max(100, tlpButtons.ClientSize.Width);
                btnThoat.Width = btnDangNhap.Width;
            };

            Theme.Apply(this);
            Theme.DrawGradientHeader(pnlHeader);
            Theme.StyleCard(pnlCard, null, 12);
            var themeButton = new Button
            {
                Text = Theme.CurrentMode == ThemeMode.Dark ? "☀  Chế độ sáng" : "☾  Chế độ tối",
                Dock = DockStyle.Bottom, Height = 36, Tag = "neutral"
            };
            pnlContainer.Controls.Add(themeButton);
            Theme.StyleButton(themeButton, Theme.ButtonKind.Neutral);
            themeButton.Click += (_, _) =>
            {
                Theme.ToggleTheme(this);
                themeButton.Text = Theme.CurrentMode == ThemeMode.Dark ? "☀  Chế độ sáng" : "☾  Chế độ tối";
            };

            chkHienMatKhau.CheckedChanged += ChkHienMatKhau_CheckedChanged;
            btnDangNhap.Click += BtnDangNhap_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void ChkHienMatKhau_CheckedChanged(object? sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void BtnDangNhap_Click(object? sender, EventArgs e)
        {
            btnDangNhap.Enabled = false;
            try
            {
                new AuthBLL().DangNhap(
                    txtSoDienThoai.Text.Trim(),
                    txtMatKhau.Text);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }
        }

        private void BtnThoat_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

