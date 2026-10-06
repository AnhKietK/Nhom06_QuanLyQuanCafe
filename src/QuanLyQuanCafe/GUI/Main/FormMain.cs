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

            Theme.Apply(this);
            Theme.DrawGradientHeader(pnlHeader);

            pnlHeader.Resize += (s, e) => pnlHeader.Invalidate();

            mnuMain.Renderer = new ModernMenuRenderer();
            stsMain.Renderer = new ModernMenuRenderer();
            stsMain.BackColor = Theme.NenStatusStrip;

            CaiDatVungMdi();
            CapNhatThongTinNguoiDung();

            this.ControlAdded += (s, e) =>
            {
                if (e.Control is MdiClient mdi)
                {
                    mdi.BackColor = Theme.Nen;
                }
            };

            this.Load += FormMain_Load;
            this.Resize += (s, e) => CapNhatLayoutHeader();
            btnDangXuat.Click += (s, e) => MnuDangXuat_Click(s, e);
            btnToggleTheme.Click += BtnToggleTheme_Click;

            CapNhatNutTheme();
            KhoiTaoMenu();
            PhanQuyenMenu();
        }

        private void BtnToggleTheme_Click(object? sender, EventArgs e)
        {
            Theme.ToggleTheme(this);
            CapNhatGiaoDienSauKhiDoiTheme();
        }

        private void CapNhatGiaoDienSauKhiDoiTheme()
        {
            pnlHeader.Invalidate();
            stsMain.BackColor = Theme.NenStatusStrip;
            stsMain.Invalidate();
            mnuMain.Invalidate();
            CaiDatVungMdi();
            CapNhatLayoutHeader();
        }

        private void CapNhatNutTheme()
        {
            bool isSmallScreen = this.Width < 1050;
            if (Theme.CurrentMode == ThemeMode.Dark)
            {
                btnToggleTheme.Text = isSmallScreen ? "🌙" : "🌙 Tối";
            }
            else
            {
                btnToggleTheme.Text = isSmallScreen ? "☀️" : "☀️ Sáng";
            }
            btnToggleTheme.Size = isSmallScreen ? new Size(44, 34) : new Size(82, 34);
            Theme.StyleButton(btnToggleTheme, Theme.ButtonKind.Info);
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            CaiDatVungMdi();
            CapNhatLayoutHeader();
            PhanQuyenMenu();
        }

        private void CaiDatVungMdi()
        {
            foreach (Control c in Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Theme.Nen;
                    break;
                }
            }
        }

        private void CapNhatThongTinNguoiDung()
        {
            string ten = string.IsNullOrWhiteSpace(CurrentUser.TenNV) ? "Chưa đăng nhập" : CurrentUser.TenNV;
            string chucVu = string.IsNullOrWhiteSpace(CurrentUser.ChucVu) ? "" : $" ({CurrentUser.ChucVu})";
            string info = $"Xin chào: {ten}{chucVu}";

            lblTrangThai.Text = info;
            lblNguoiDung.Text = this.Width < 1050 ? ten : $"{ten}{chucVu}";
        }

        private void CapNhatLayoutHeader()
        {
            bool isSmallScreen = this.Width < 1050;

            if (isSmallScreen)
            {
                lblThuongHieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                lblThuongHieu.Padding = new Padding(10, 0, 6, 0);
                lblThuongHieu.Text = "Quản lý cafe";
            }
            else
            {
                lblThuongHieu.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
                lblThuongHieu.Padding = new Padding(16, 0, 10, 0);
                lblThuongHieu.Text = "Quản lý quán cà phê";
            }

            lblThuongHieu.ForeColor = Color.White;
            lblNguoiDung.ForeColor = Color.White;

            CapNhatThongTinNguoiDung();
            CapNhatNutTheme();

            Padding itemPadding = isSmallScreen ? new Padding(7, 6, 7, 6) : new Padding(11, 6, 11, 6);
            Font itemFont = isSmallScreen ? new Font("Segoe UI", 9.5F, FontStyle.Bold) : Theme.FontMenu;

            foreach (ToolStripItem item in mnuMain.Items)
            {
                item.Padding = itemPadding;
                item.Font = itemFont;
            }
        }

        public void KhoiTaoMenu()
        {
            mnuMain.Items.Clear();

            bool isSmallScreen = this.Width < 1050;
            Padding defaultPadding = isSmallScreen ? new Padding(7, 6, 7, 6) : new Padding(11, 6, 11, 6);
            Font defaultFont = isSmallScreen ? new Font("Segoe UI", 9.5F, FontStyle.Bold) : Theme.FontMenu;

            foreach (string nhom in ThuTuNhom)
            {
                var topItem = new ToolStripMenuItem(nhom)
                {
                    Font = defaultFont,
                    ForeColor = Theme.Chu,
                    Padding = defaultPadding
                };

                if (topItem.DropDown is ToolStripDropDownMenu dropDownMenu)
                {
                    dropDownMenu.ShowImageMargin = false;
                }

                var itemsTrongNhom = DanhSachMenu.Where(m => m.Nhom == nhom);
                foreach (var cfg in itemsTrongNhom)
                {
                    var subItem = new ToolStripMenuItem(cfg.TenMuc)
                    {
                        Tag = cfg,
                        Font = Theme.FontChinh,
                        ForeColor = Theme.Chu,
                        Padding = new Padding(10, 6, 10, 6)
                    };

                    subItem.Click += (s, e) =>
                    {
                        FormLauncher.Mo(this, cfg.TenDayDuKieu, cfg.TenMuc, cfg.Modal);
                    };

                    topItem.DropDownItems.Add(subItem);
                }

                if (nhom == "Hệ thống")
                {
                    topItem.DropDownItems.Add(new ToolStripSeparator());

                    var mnuDangXuat = new ToolStripMenuItem("Đăng xuất")
                    {
                        Font = Theme.FontChinh,
                        ForeColor = Theme.Chu,
                        Padding = new Padding(10, 6, 10, 6)
                    };
                    mnuDangXuat.Click += MnuDangXuat_Click;
                    topItem.DropDownItems.Add(mnuDangXuat);

                    var mnuThoat = new ToolStripMenuItem("Thoát")
                    {
                        Font = Theme.FontChinh,
                        ForeColor = Theme.Chu,
                        Padding = new Padding(10, 6, 10, 6)
                    };
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

