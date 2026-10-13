using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Auth
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();

            Theme.Apply(this);
            Theme.StyleCard(pnlCard, null, 12);

            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            try
            {
                new AuthBLL().DoiMatKhau(
                    txtMatKhauCu.Text,
                    txtMatKhauMoi.Text,
                    txtXacNhan.Text);

                UiHelper.ShowInfo("Đổi mật khẩu thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

