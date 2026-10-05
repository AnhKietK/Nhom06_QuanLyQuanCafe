using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Auth
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();

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
