using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.GUI.Auth;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Main
{
    public partial class FormMain : Form
    {
        public class MenuConfigItem
        {
            public string Nhom { get; }
            public string TenMuc { get; }
            public string TenDayDuKieu { get; }
            public string[] ChucVuChoPhep { get; }
            public bool Modal { get; }

            public MenuConfigItem(string nhom, string tenMuc, string tenDayDuKieu, string[] chucVuChoPhep, bool modal = false)
            {
                Nhom = nhom;
                TenMuc = tenMuc;
                TenDayDuKieu = tenDayDuKieu;
                ChucVuChoPhep = chucVuChoPhep;
                Modal = modal;
            }
        }

        private static readonly MenuConfigItem[] DanhSachMenu = new[]
        {
            new MenuConfigItem("Bán hàng", "Bán hàng", "QuanLyQuanCafe.GUI.BanHang.FormBanHang", new[] { "Quản lý", "Phục vụ", "Thu ngân" }),
            new MenuConfigItem("Khách hàng", "Khách hàng", "QuanLyQuanCafe.GUI.Khach.FormKhach", new[] { "Quản lý", "Phục vụ", "Thu ngân" }),
            new MenuConfigItem("Kho", "Nguyên liệu", "QuanLyQuanCafe.GUI.Kho.FormNguyenLieu", new[] { "Quản lý", "Thủ kho" }),
            new MenuConfigItem("Kho", "Nhà cung cấp", "QuanLyQuanCafe.GUI.Kho.FormNhaCungCap", new[] { "Quản lý", "Thủ kho" }),
            new MenuConfigItem("Kho", "Nhập kho", "QuanLyQuanCafe.GUI.Kho.FormNhapKho", new[] { "Quản lý", "Thủ kho" }),
            new MenuConfigItem("Kho", "Công thức pha chế", "QuanLyQuanCafe.GUI.DanhMuc.FormCongThuc", new[] { "Quản lý", "Thủ kho" }),
            new MenuConfigItem("Danh mục", "Thức uống", "QuanLyQuanCafe.GUI.DanhMuc.FormThucUong", new[] { "Quản lý" }),
            new MenuConfigItem("Danh mục", "Bàn và khu vực", "QuanLyQuanCafe.GUI.Ban.FormBan", new[] { "Quản lý" }),
            new MenuConfigItem("Báo cáo", "Báo cáo doanh thu", "QuanLyQuanCafe.GUI.BaoCao.FormBaoCao", new[] { "Quản lý", "Kế toán" }),
            new MenuConfigItem("Báo cáo", "Chi tiền nhà cung cấp", "QuanLyQuanCafe.GUI.BaoCao.FormChiTien", new[] { "Quản lý", "Kế toán" }),
            new MenuConfigItem("Hệ thống", "Nhân viên", "QuanLyQuanCafe.GUI.NhanVien.FormNhanVien", new[] { "Quản lý" }),
            new MenuConfigItem("Hệ thống", "Đổi mật khẩu", "QuanLyQuanCafe.GUI.Auth.FormDoiMatKhau", new[] { "Quản lý", "Phục vụ", "Thu ngân", "Thủ kho", "Kế toán" }, modal: true)
        };

        private static readonly string[] ThuTuNhom = { "Bán hàng", "Khách hàng", "Kho", "Danh mục", "Báo cáo", "Hệ thống" };

        public bool DangXuat { get; private set; }

        public FormMain()
        {
            InitializeComponent();

            lblTrangThai.Text = $"Xin chào: {CurrentUser.TenNV} ({CurrentUser.ChucVu})";

            this.Load += FormMain_Load;

            KhoiTaoMenu();
            PhanQuyenMenu();
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            lblTrangThai.Text = $"Xin chào: {CurrentUser.TenNV} ({CurrentUser.ChucVu})";
            PhanQuyenMenu();
        }

        public void KhoiTaoMenu()
        {
            mnuMain.Items.Clear();

            foreach (string nhom in ThuTuNhom)
            {
                var topItem = new ToolStripMenuItem(nhom);

                var itemsTrongNhom = DanhSachMenu.Where(m => m.Nhom == nhom);
                foreach (var cfg in itemsTrongNhom)
                {
                    var subItem = new ToolStripMenuItem(cfg.TenMuc)
                    {
                        Tag = cfg
                    };

                    subItem.Click += (s, e) =>
                    {
                        if (cfg.TenDayDuKieu == "QuanLyQuanCafe.GUI.Auth.FormDoiMatKhau")
                        {
                            using var f = new FormDoiMatKhau();
                            f.ShowDialog(this);
                        }
                        else
                        {
                            FormLauncher.Mo(this, cfg.TenDayDuKieu, cfg.TenMuc, cfg.Modal);
                        }
                    };

                    topItem.DropDownItems.Add(subItem);
                }

                if (nhom == "Hệ thống")
                {
                    topItem.DropDownItems.Add(new ToolStripSeparator());

                    var mnuDangXuat = new ToolStripMenuItem("Đăng xuất");
                    mnuDangXuat.Click += MnuDangXuat_Click;
                    topItem.DropDownItems.Add(mnuDangXuat);

                    var mnuThoat = new ToolStripMenuItem("Thoát");
                    mnuThoat.Click += MnuThoat_Click;
                    topItem.DropDownItems.Add(mnuThoat);
                }

                mnuMain.Items.Add(topItem);
            }
        }

        public void PhanQuyenMenu()
        {
            string chucVuHienTai = CurrentUser.ChucVu?.Trim() ?? "";

            foreach (ToolStripItem item in mnuMain.Items)
            {
                if (item is ToolStripMenuItem topMenu)
                {
                    int visibleItemCount = 0;
                    foreach (ToolStripItem subItem in topMenu.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem subMenuItem)
                        {
                            if (subMenuItem.Tag is MenuConfigItem config)
                            {
                                bool duocPhep = config.ChucVuChoPhep.Any(cv => string.Equals(cv, chucVuHienTai, StringComparison.OrdinalIgnoreCase));
                                subMenuItem.Visible = duocPhep;
                                if (duocPhep)
                                    visibleItemCount++;
                            }
                            else
                            {
                                // Các mục cố định: Đăng xuất, Thoát
                                subMenuItem.Visible = true;
                                visibleItemCount++;
                            }
                        }
                    }
                    topMenu.Visible = (visibleItemCount > 0);
                }
            }
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

