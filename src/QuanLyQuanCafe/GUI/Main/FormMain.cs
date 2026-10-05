using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Main
{
    public partial class FormMain : Form
    {
        public bool DangXuat { get; private set; }

        public FormMain()
        {
            InitializeComponent();

            lblTrangThai.Text = $"Xin chào: {CurrentUser.TenNV} ({CurrentUser.ChucVu})";

            mnuDangXuat.Click += MnuDangXuat_Click;
            mnuThoat.Click += MnuThoat_Click;
        }

        private void MnuDangXuat_Click(object? sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Bạn có muốn đăng xuất không?"))
                return;

            new AuthBLL().DangXuat();
            DangXuat = true;
            Close();
        }

        private void MnuThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
