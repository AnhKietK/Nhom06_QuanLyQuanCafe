using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BanHang
{
    public partial class frmBanHang : Form
    {
        private readonly BanHangBLL _bll = new();
        private List<BanDTO> _dsBan = new();
        private List<ThucUongDTO> _dsThucUong = new();
        private List<LoaiThucUongDTO> _dsLoaiTU = new();

        private BanDTO? _banDangChon = null;
        private HoaDonDTO? _hoaDonHienTai = null;
        private List<ChiTietHoaDonDTO> _dsChiTietHD = new();
        private KhachHangDTO? _khachDangChon = null;

        private decimal _tienHang = 0;
        private decimal _tongThanhToan = 0;

        // Quản lý trạng thái giao diện hiện đại (Lượt 2)
        private PosChipButton? _chipTatCaBan;
        private PosChipButton? _chipBanTrong;
        private PosChipButton? _chipBanCoKhach;
        private PosChipButton? _chipDatTruoc;
        private PosChipButton? _chipTatCaMon;
        private string? _maLoaiMonDangChon = null;
        private ThucUongDTO? _thucUongDangChon = null;
        private bool _isCardModeThucDon = true;
        private readonly Dictionary<string, (decimal TamTinh, int PhutNgoi)> _thongTinHoaDonBan = new();

        public frmBanHang()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += FrmBanHang_KeyDown;

            KhoiTaoSuKien();
        }

        private void FrmBanHang_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                HienThiHuongDanPhimTat();
            }
            else if (e.KeyCode == Keys.F4)
            {
                e.Handled = true;
                BtnChuyenBan_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                RefreshDuLieu();
            }
            else if (e.KeyCode == Keys.F8)
            {
                e.Handled = true;
                BtnInTamTinh_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                e.Handled = true;
                BtnThanhToan_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Delete && !(ActiveControl is TextBoxBase || ActiveControl is NumericUpDown || ActiveControl is ComboBox))
            {
                e.Handled = true;
                BtnXoaMon_Click(sender, e);
            }
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FrmBanHang_Load;

            // Đồng hồ thời gian thực
            timerDongHo.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            };

            // Nút hỗ trợ & Làm mới
            btnHuongDan.Click += (s, e) => HienThiHuongDanPhimTat();
            btnLamMoiToanBo.Click += (s, e) => RefreshDuLieu();

            // Bộ lọc sơ đồ bàn
            cboKhuVuc.SelectedIndexChanged += (s, e) => ApDungBoLocBan();
            cboTrangThaiBan.SelectedIndexChanged += (s, e) => ApDungBoLocBan();
            txtTimKiemBan.TextChanged += (s, e) => ApDungBoLocBan();
            btnMoBanNhanh.Click += BtnMoBan_Click;
            btnChuyenBanNhanh.Click += BtnChuyenBan_Click;

            // Thực đơn thức uống
            txtTimKiemMon.TextChanged += (s, e) => TimKiemMonNuoc();
            cboLoaiMon.SelectedIndexChanged += (s, e) => TimKiemMonNuoc();
            btnThemMon.Click += BtnThemMon_Click;
            btnKiemTraKho.Click += BtnKiemTraKho_Click;
            btnDoiCheDoXem.Click += (s, e) => ToggleCheDoXemThucDon();
            dgvThucUong.CellDoubleClick += (s, e) => BtnThemMon_Click(s, e);
            dgvThucUong.SelectionChanged += (s, e) =>
            {
                if (dgvThucUong.CurrentRow?.DataBoundItem is ThucUongDTO tu)
                {
                    _thucUongDangChon = tu;
                }
            };

            // Nút số lượng nhanh & Stepper
            btnGiamSLMon.Click += (s, e) => { if (numSoLuongMon.Value > 1) numSoLuongMon.Value--; };
            btnTangSLMon.Click += (s, e) => { if (numSoLuongMon.Value < numSoLuongMon.Maximum) numSoLuongMon.Value++; };
            btnSL1.Click += (s, e) => numSoLuongMon.Value = 1;
            btnSL2.Click += (s, e) => numSoLuongMon.Value = 2;
            btnSL5.Click += (s, e) => numSoLuongMon.Value = 5;

            // Điều chỉnh chi tiết hóa đơn
            btnTangSL.Click += BtnTangSL_Click;
            btnGiamSL.Click += BtnGiamSL_Click;
            btnXoaMon.Click += BtnXoaMon_Click;

            // Khách hàng
            btnTimKhach.Click += BtnTimKhach_Click;
            txtTimKhach.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnTimKhach_Click(s, e);
                }
            };
            btnThemKhachNhanh.Click += BtnThemKhachNhanh_Click;
            btnBoChonKhach.Click += BtnBoChonKhach_Click;

            // Tính tiền & Phương thức thanh toán
            numGiamGia.ValueChanged += (s, e) => CapNhatTongCongVaTienThoi();
            numTienKhachDua.ValueChanged += (s, e) => CapNhatTienThoi();
            cboPhuongThuc.SelectedIndexChanged += CboPhuongThuc_SelectedIndexChanged;

            btnTienVuaDu.Click += (s, e) => numTienKhachDua.Value = _tongThanhToan;
            btnTien20k.Click += (s, e) => DatTienNhanh(20000);
            btnTien50k.Click += (s, e) => DatTienNhanh(50000);
            btnTien100k.Click += (s, e) => DatTienNhanh(100000);
            btnTien200k.Click += (s, e) => DatTienNhanh(200000);
            btnTien500k.Click += (s, e) => DatTienNhanh(500000);

            // Chức năng hóa đơn chính
            btnMoBan.Click += BtnMoBan_Click;
            btnChuyenBan.Click += BtnChuyenBan_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            btnHuyDon.Click += BtnHuyDon_Click;
            btnInTamTinh.Click += BtnInTamTinh_Click;
        }

        private void FrmBanHang_Load(object? sender, EventArgs e)
        {
            try
            {
                // Nếu form được khởi chạy độc lập (chưa qua màn hình đăng nhập), thiết lập phiên làm việc mẫu cho Phục vụ
                if (!CurrentUser.IsLoggedIn)
                {
                    CurrentUser.Set("NV002", "Trần Thị Bình", "Phục vụ", AppConfig.Get("PhucVuConn"));
                }

                lblSubtitle.Text = $"Nhân viên: {CurrentUser.TenNV} ({CurrentUser.ChucVu}) | Quán Cafe Nhóm 06";
                lblClock.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
                timerDongHo.Start();

                NapPhuongThucThanhToan();
                NapDanhSachTrangThai();
                KhoiTaoChipsTrangThaiBan();
                RefreshDuLieu();
            }
            catch (SqlException ex)
            {
                CustomSqlExceptionHandler.XuLy(ex);
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void HienThiHuongDanPhimTat()
        {
            string huongDan = "=== BẢNG PHÍM TẮT HỆ THỐNG POS BÁN HÀNG ===\n\n" +
                              "• [F1]      : Mở bảng hướng dẫn phím tắt này\n" +
                              "• [F4]      : Chuyển bàn / Chuyển hóa đơn sang bàn trống\n" +
                              "• [F5]      : Làm mới toàn bộ sơ đồ bàn & thực đơn thức uống\n" +
                              "• [F8]      : In / Xem trước phiếu tạm tính (Hóa đơn kiểm đồ)\n" +
                              "• [F9]      : Mở màn hình Xác nhận thanh toán & In hóa đơn\n" +
                              "• [Enter]   : Thêm món thức uống đang chọn vào hóa đơn bàn\n" +
                              "• [Delete]  : Xóa món đang chọn khỏi hóa đơn\n" +
                              "• [Esc]     : Đóng / Hủy bỏ thao tác hiện tại\n\n" +
                              "Mẹo: Nhấp đúp chuột vào món trong Thực đơn để thêm nhanh 1 ly!";

            UiHelper.ShowInfo(huongDan, "Hướng dẫn phím tắt POS");
        }

        #region 1. Nạp và Làm mới Dữ liệu (Refresh)

        /// <summary>
        /// Hàm nạp lại toàn bộ dữ liệu bàn, thực đơn và hóa đơn hiện tại (Refresh)
        /// </summary>
        public void RefreshDuLieu()
        {
            try
            {
                DrinkImageHelper.ClearCache();
                NapDanhSachBan();
                NapDanhSachLoaiMon();
                NapDanhSachThucUong();

                if (_banDangChon != null)
                {
                    ChonBan(_banDangChon.MaBan);
                }
                else
                {
                    LamMoiHoaDonGiaoDien();
                }
            }
            catch (SqlException ex)
            {
                CustomSqlExceptionHandler.XuLy(ex);
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void NapPhuongThucThanhToan()
        {
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("Tiền mặt");
            cboPhuongThuc.Items.Add("Chuyển khoản");
            cboPhuongThuc.Items.Add("Thẻ");
            cboPhuongThuc.Items.Add("Ví điện tử");
            cboPhuongThuc.SelectedIndex = 0;
        }

        private void NapDanhSachKhuVuc()
        {
            string luaChonCu = cboKhuVuc.SelectedItem?.ToString() ?? "Tất cả khu vực";
            cboKhuVuc.Items.Clear();
            cboKhuVuc.Items.Add("Tất cả khu vực");

            var khuVucList = _dsBan
                .Select(b => b.TenViTri)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            foreach (var kv in khuVucList)
            {
                cboKhuVuc.Items.Add(kv);
            }

            if (cboKhuVuc.Items.Contains(luaChonCu))
                cboKhuVuc.SelectedItem = luaChonCu;
            else if (cboKhuVuc.Items.Count > 0)
                cboKhuVuc.SelectedIndex = 0;
        }

        private void NapDanhSachTrangThai()
        {
            cboTrangThaiBan.Items.Clear();
            cboTrangThaiBan.Items.Add("Tất cả trạng thái");
            cboTrangThaiBan.Items.Add("Trống");
            cboTrangThaiBan.Items.Add("Có khách");
            cboTrangThaiBan.Items.Add("Đặt trước");
            cboTrangThaiBan.SelectedIndex = 0;
        }

        private void KhoiTaoChipsTrangThaiBan()
        {
            flpTrangThaiBanChips.SuspendLayout();
            flpTrangThaiBanChips.Controls.Clear();

            _chipTatCaBan = new PosChipButton("Tất cả", true);
            _chipBanTrong = new PosChipButton("Trống", false);
            _chipBanCoKhach = new PosChipButton("Có khách", false);
            _chipDatTruoc = new PosChipButton("Đặt trước", false);

            _chipTatCaBan.Click += (s, e) => ChonChipTrangThaiBan("Tất cả trạng thái", _chipTatCaBan);
            _chipBanTrong.Click += (s, e) => ChonChipTrangThaiBan("Trống", _chipBanTrong);
            _chipBanCoKhach.Click += (s, e) => ChonChipTrangThaiBan("Có khách", _chipBanCoKhach);
            _chipDatTruoc.Click += (s, e) => ChonChipTrangThaiBan("Đặt trước", _chipDatTruoc);

            flpTrangThaiBanChips.Controls.Add(_chipTatCaBan);
            flpTrangThaiBanChips.Controls.Add(_chipBanTrong);
            flpTrangThaiBanChips.Controls.Add(_chipBanCoKhach);
            flpTrangThaiBanChips.Controls.Add(_chipDatTruoc);
            flpTrangThaiBanChips.ResumeLayout();
        }

        private void ChonChipTrangThaiBan(string trangThai, PosChipButton chipChon)
        {
            if (_chipTatCaBan != null) _chipTatCaBan.IsActive = (chipChon == _chipTatCaBan);
            if (_chipBanTrong != null) _chipBanTrong.IsActive = (chipChon == _chipBanTrong);
            if (_chipBanCoKhach != null) _chipBanCoKhach.IsActive = (chipChon == _chipBanCoKhach);
            if (_chipDatTruoc != null) _chipDatTruoc.IsActive = (chipChon == _chipDatTruoc);

            if (cboTrangThaiBan.Items.Contains(trangThai))
            {
                cboTrangThaiBan.SelectedItem = trangThai;
            }
            ApDungBoLocBan();
        }

        private void NapDanhSachBan()
        {
            _dsBan = _bll.LayDanhSachBan();
            _thongTinHoaDonBan.Clear();

            // Lấy thông tin tạm tính & thời gian vào của các bàn có khách để hiển thị trực quan
            foreach (var b in _dsBan.Where(b => b.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    var hd = _bll.LayHoaDonDangMoTheoBan(b.MaBan);
                    if (hd != null)
                    {
                        int phut = (int)Math.Max(0, (DateTime.Now - hd.NgayLap).TotalMinutes);
                        _thongTinHoaDonBan[b.MaBan] = (hd.TongTienThanhToan, phut);
                    }
                }
                catch
                {
                    // Bỏ qua lỗi đọc đơn tạm
                }
            }

            NapDanhSachKhuVuc();
            ApDungBoLocBan();
        }

        private void ApDungBoLocBan()
        {
            string khuVuc = cboKhuVuc.SelectedItem?.ToString() ?? "Tất cả khu vực";
            string trangThai = cboTrangThaiBan.SelectedItem?.ToString() ?? "Tất cả trạng thái";
            string tuKhoa = txtTimKiemBan.Text.Trim();

            var danhSachLoc = _dsBan.AsEnumerable();

            if (khuVuc != "Tất cả khu vực")
            {
                danhSachLoc = danhSachLoc.Where(b => b.TenViTri.Equals(khuVuc, StringComparison.OrdinalIgnoreCase));
            }

            if (trangThai == "Trống")
            {
                danhSachLoc = danhSachLoc.Where(b => b.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase));
            }
            else if (trangThai == "Có khách")
            {
                danhSachLoc = danhSachLoc.Where(b => b.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase));
            }
            else if (trangThai == "Đặt trước")
            {
                danhSachLoc = danhSachLoc.Where(b => b.TrangThai.Equals("DATTRUOC", StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                danhSachLoc = danhSachLoc.Where(b =>
                    b.SoBan.ToString().Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                    b.MaBan.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                    b.TenViTri.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase));
            }

            HienThiBanLenGiaoDien(danhSachLoc.ToList());
        }

        private void HienThiBanLenGiaoDien(List<BanDTO> danhSach)
        {
            flpDanhSachBan.SuspendLayout();
            flpDanhSachBan.Controls.Clear();

            int tong = _dsBan.Count;
            int trong = _dsBan.Count(b => b.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase));
            int coKhach = _dsBan.Count(b => b.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase));
            int datTruoc = _dsBan.Count(b => b.TrangThai.Equals("DATTRUOC", StringComparison.OrdinalIgnoreCase));

            lblThongKeBan.Text = $"Tổng: {tong}   |   🟢 Trống: {trong}   |   🔴 Có khách: {coKhach}" + (datTruoc > 0 ? $"   |   🟡 Đặt: {datTruoc}" : "");

            // Cập nhật số lượng trên các badge chip lọc
            if (_chipTatCaBan != null) _chipTatCaBan.CountBadge = tong.ToString();
            if (_chipBanTrong != null) _chipBanTrong.CountBadge = trong.ToString();
            if (_chipBanCoKhach != null) _chipBanCoKhach.CountBadge = coKhach.ToString();
            if (_chipDatTruoc != null) _chipDatTruoc.CountBadge = datTruoc.ToString();

            if (danhSach.Count == 0)
            {
                flpDanhSachBan.Controls.Add(new PosEmptyState("Không tìm thấy bàn phù hợp", "Vui lòng chọn bộ lọc khác hoặc kiểm tra lại từ khóa tìm kiếm"));
            }
            else
            {
                foreach (var b in danhSach)
                {
                    var card = new PosTableCard(b);

                    if (_banDangChon != null && _banDangChon.MaBan == b.MaBan)
                    {
                        card.IsSelected = true;
                    }

                    if (_thongTinHoaDonBan.TryGetValue(b.MaBan, out var info))
                    {
                        card.TamTinh = info.TamTinh;
                        card.PhutNgoi = info.PhutNgoi;
                    }

                    card.Click += (s, e) =>
                    {
                        ChonBan(b.MaBan);
                    };

                    flpDanhSachBan.Controls.Add(card);
                }
            }

            flpDanhSachBan.ResumeLayout();
        }

        private void ChonBan(string maBan)
        {
            _banDangChon = _dsBan.FirstOrDefault(b => b.MaBan == maBan);
            if (_banDangChon == null)
                return;

            // Highlight thẻ bàn trên sơ đồ
            foreach (Control c in flpDanhSachBan.Controls)
            {
                if (c is PosTableCard card)
                {
                    card.IsSelected = (card.Ban.MaBan == maBan);
                }
            }

            lblBanDangChon.Text = $"BÀN: {(_banDangChon.SoBan < 10 ? "0" : "")}{_banDangChon.SoBan} ({_banDangChon.TenViTri})";

            // Kiểm tra trạng thái bàn và thiết lập giao diện
            if (_banDangChon.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase))
            {
                NapHoaDonCuaBanHienTai();
                btnMoBan.Enabled = false;
                btnMoBanNhanh.Enabled = false;
                btnChuyenBan.Enabled = true;
                btnChuyenBanNhanh.Enabled = true;
                btnThanhToan.Enabled = true;
                btnHuyDon.Enabled = true;
                btnThemMon.Enabled = true;
                btnInTamTinh.Enabled = true;
            }
            else
            {
                LamMoiHoaDonGiaoDien();
                btnMoBan.Enabled = true;
                btnMoBanNhanh.Enabled = true;
                btnChuyenBan.Enabled = false;
                btnChuyenBanNhanh.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyDon.Enabled = false;
                btnThemMon.Enabled = true; // Cho phép bấm thêm món, hệ thống tự mở đơn
                btnInTamTinh.Enabled = false;
            }

            // Đồng bộ số lượng món đã gọi trong đơn hiện tại lên các card thực đơn
            CapNhatBadgeSoLuongMonTrongDon();
        }

        #endregion

        #region 2. Xử lý Thực đơn thức uống

        private void NapDanhSachLoaiMon()
        {
            _dsLoaiTU = _bll.LayDanhSachLoaiThucUong();
            string luaChonCu = cboLoaiMon.SelectedItem?.ToString() ?? "Tất cả loại món";
            cboLoaiMon.Items.Clear();
            cboLoaiMon.Items.Add("Tất cả loại món");
            foreach (var loai in _dsLoaiTU)
            {
                cboLoaiMon.Items.Add(loai.TenLoai);
            }

            if (cboLoaiMon.Items.Contains(luaChonCu))
                cboLoaiMon.SelectedItem = luaChonCu;
            else if (cboLoaiMon.Items.Count > 0)
                cboLoaiMon.SelectedIndex = 0;

            // Nạp danh sách chips nhóm món nước
            flpLoaiMonChips.SuspendLayout();
            flpLoaiMonChips.Controls.Clear();

            _chipTatCaMon = new PosChipButton("Tất cả", _maLoaiMonDangChon == null, _dsThucUong.Count > 0 ? _dsThucUong.Count.ToString() : "");
            _chipTatCaMon.Click += (s, e) => ChonNhomMon(null);
            flpLoaiMonChips.Controls.Add(_chipTatCaMon);

            foreach (var loai in _dsLoaiTU)
            {
                int count = _dsThucUong.Count(tu => tu.MaLoaiTU == loai.MaLoaiTU);
                var chip = new PosChipButton(loai.TenLoai, _maLoaiMonDangChon == loai.MaLoaiTU, count > 0 ? count.ToString() : "")
                {
                    Tag = loai.MaLoaiTU
                };
                chip.Click += (s, e) => ChonNhomMon(loai.MaLoaiTU);
                flpLoaiMonChips.Controls.Add(chip);
            }

            flpLoaiMonChips.ResumeLayout();
        }

        private void ChonNhomMon(string? maLoaiTU)
        {
            _maLoaiMonDangChon = maLoaiTU;

            if (_chipTatCaMon != null)
                _chipTatCaMon.IsActive = (maLoaiTU == null);

            foreach (Control c in flpLoaiMonChips.Controls)
            {
                if (c is PosChipButton chip && chip.Tag is string id)
                {
                    chip.IsActive = (id == maLoaiTU);
                }
            }

            // Đồng bộ sang cboLoaiMon
            if (maLoaiTU == null)
            {
                cboLoaiMon.SelectedIndex = 0;
            }
            else
            {
                var loai = _dsLoaiTU.FirstOrDefault(x => x.MaLoaiTU == maLoaiTU);
                if (loai != null && cboLoaiMon.Items.Contains(loai.TenLoai))
                {
                    cboLoaiMon.SelectedItem = loai.TenLoai;
                }
            }

            TimKiemMonNuoc();
        }

        private void NapDanhSachThucUong()
        {
            _dsThucUong = _bll.LayDanhSachThucUong();
            TimKiemMonNuoc();
        }

        private void TimKiemMonNuoc()
        {
            string tuKhoa = txtTimKiemMon.Text.Trim();
            string loai = cboLoaiMon.SelectedItem?.ToString() ?? "Tất cả loại món";

            string? maLoai = _maLoaiMonDangChon;
            if (maLoai == null && loai != "Tất cả loại món")
            {
                var l = _dsLoaiTU.FirstOrDefault(x => x.TenLoai == loai);
                if (l != null) maLoai = l.MaLoaiTU;
            }

            try
            {
                var ketQua = _bll.TimKiemThucUong(tuKhoa, maLoai);
                HienThiThucDonLenGiaoDien(ketQua);
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void HienThiThucDonLenGiaoDien(List<ThucUongDTO> danhSach)
        {
            flpThucDonCards.SuspendLayout();
            flpThucDonCards.Controls.Clear();

            dgvThucUong.DataSource = null;
            dgvThucUong.DataSource = danhSach;

            if (danhSach.Count == 0)
            {
                flpThucDonCards.Controls.Add(new PosEmptyState("Không tìm thấy món nước", "Vui lòng nhập từ khóa khác hoặc bấm nhóm món khác"));
            }
            else
            {
                foreach (var tu in danhSach)
                {
                    int slTrongDon = _dsChiTietHD.FirstOrDefault(ct => ct.MaThucUong == tu.MaThucUong)?.SoLuong ?? 0;
                    var card = new PosDrinkCard(tu)
                    {
                        SoLuongTrongDon = slTrongDon
                    };

                    card.DrinkClicked += (s, item) =>
                    {
                        _thucUongDangChon = item;
                        // Đồng bộ dòng chọn trên bảng
                        foreach (DataGridViewRow row in dgvThucUong.Rows)
                        {
                            if (row.DataBoundItem is ThucUongDTO rItem && rItem.MaThucUong == item.MaThucUong)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    };

                    card.QuickPlusClicked += (s, item) =>
                    {
                        ThemNhanhMonVaoDon(item, 1);
                    };

                    flpThucDonCards.Controls.Add(card);
                }
            }

            flpThucDonCards.ResumeLayout();
        }

        private void ToggleCheDoXemThucDon()
        {
            _isCardModeThucDon = !_isCardModeThucDon;
            if (_isCardModeThucDon)
            {
                flpThucDonCards.Visible = true;
                dgvThucUong.Visible = false;
                btnDoiCheDoXem.Text = "☰ Dạng bảng";
            }
            else
            {
                flpThucDonCards.Visible = false;
                dgvThucUong.Visible = true;
                btnDoiCheDoXem.Text = "⊞ Dạng thẻ";
            }
        }

        private void CapNhatBadgeSoLuongMonTrongDon()
        {
            foreach (Control c in flpThucDonCards.Controls)
            {
                if (c is PosDrinkCard card)
                {
                    int sl = _dsChiTietHD.FirstOrDefault(ct => ct.MaThucUong == card.ThucUong.MaThucUong)?.SoLuong ?? 0;
                    card.SoLuongTrongDon = sl;
                }
            }
        }

        private void ThemNhanhMonVaoDon(ThucUongDTO mon, int soLuong)
        {
            if (_banDangChon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn một bàn trước khi thêm món.");
                return;
            }

            try
            {
                if (_hoaDonHienTai == null)
                {
                    if (UiHelper.Confirm($"Bàn {_banDangChon.SoBan} đang trống. Bạn có muốn mở bàn và gọi '{mon.TenThucUong}' không?"))
                    {
                        string? maKH = _khachDangChon?.MaKH;
                        string maHDMoi = _bll.MoBan(_banDangChon.MaBan, maKH);
                        NapDanhSachBan();
                        ChonBan(_banDangChon.MaBan);
                    }
                    else
                    {
                        return;
                    }
                }

                if (_hoaDonHienTai == null)
                    return;

                _bll.ThemMonVaoHoaDon(_hoaDonHienTai.MaHD, mon.MaThucUong, soLuong);
                NapChiTietHoaDon(_hoaDonHienTai.MaHD);

                // Cập nhật thẻ bàn đang chọn
                if (_banDangChon != null)
                {
                    _thongTinHoaDonBan[_banDangChon.MaBan] = (_tongThanhToan, 0);
                    foreach (Control c in flpDanhSachBan.Controls)
                    {
                        if (c is PosTableCard card && card.Ban.MaBan == _banDangChon.MaBan)
                        {
                            card.TamTinh = _tongThanhToan;
                            break;
                        }
                    }
                }

                CapNhatBadgeSoLuongMonTrongDon();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private ThucUongDTO? LayMonDangChon()
        {
            if (_thucUongDangChon != null)
                return _thucUongDangChon;

            if (dgvThucUong.CurrentRow?.DataBoundItem is ThucUongDTO mon)
            {
                return mon;
            }
            return null;
        }

        private void BtnThemMon_Click(object? sender, EventArgs e)
        {
            var mon = LayMonDangChon();
            if (mon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn một món thức uống trong thực đơn.");
                return;
            }

            int soLuong = (int)numSoLuongMon.Value;
            if (soLuong <= 0)
            {
                UiHelper.ShowWarning("Số lượng món phải lớn hơn 0.");
                return;
            }

            if (_banDangChon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn bàn trước khi thêm món.");
                return;
            }

            try
            {
                // Nếu bàn chưa có hóa đơn đang mở, hỏi mở bàn
                if (_hoaDonHienTai == null)
                {
                    if (UiHelper.Confirm($"Bàn {_banDangChon.SoBan} đang trống. Bạn có muốn mở bàn và tạo hóa đơn mới không?"))
                    {
                        string? maKH = _khachDangChon?.MaKH;
                        string maHDMoi = _bll.MoBan(_banDangChon.MaBan, maKH);
                        NapDanhSachBan();
                        ChonBan(_banDangChon.MaBan);
                    }
                    else
                    {
                        return;
                    }
                }

                if (_hoaDonHienTai == null)
                    return;

                // Thêm món vào hóa đơn
                _bll.ThemMonVaoHoaDon(_hoaDonHienTai.MaHD, mon.MaThucUong, soLuong);

                // Nạp lại chi tiết hóa đơn
                NapChiTietHoaDon(_hoaDonHienTai.MaHD);

                // Cập nhật thẻ bàn đang chọn
                if (_banDangChon != null)
                {
                    _thongTinHoaDonBan[_banDangChon.MaBan] = (_tongThanhToan, 0);
                    foreach (Control c in flpDanhSachBan.Controls)
                    {
                        if (c is PosTableCard card && card.Ban.MaBan == _banDangChon.MaBan)
                        {
                            card.TamTinh = _tongThanhToan;
                            break;
                        }
                    }
                }

                CapNhatBadgeSoLuongMonTrongDon();

                // Reset số lượng về 1
                numSoLuongMon.Value = 1;
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnKiemTraKho_Click(object? sender, EventArgs e)
        {
            var mon = LayMonDangChon();
            if (mon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn một món thức uống cần kiểm tra tồn kho.");
                return;
            }

            int soLuong = (int)numSoLuongMon.Value;

            try
            {
                bool duTonKho = _bll.KiemTraTonKhoMonNuoc(mon.MaThucUong, soLuong);
                if (duTonKho)
                {
                    UiHelper.ShowInfo($"Nguyên liệu trong kho ĐỦ để pha chế {soLuong} phần '{mon.TenThucUong}'.", "Kiểm tra tồn kho");
                }
                else
                {
                    UiHelper.ShowWarning($"CẢNH BÁO: Kho KHÔNG ĐỦ nguyên liệu để pha chế {soLuong} phần '{mon.TenThucUong}'. Vui lòng kiểm tra tồn kho hoặc báo Thủ kho nhập thêm!", "Thiếu nguyên liệu");
                }
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        #endregion

        #region 3. Xử lý Chi tiết Hóa đơn & Bán hàng

        private void NapHoaDonCuaBanHienTai()
        {
            if (_banDangChon == null) return;

            try
            {
                _hoaDonHienTai = _bll.LayHoaDonDangMoTheoBan(_banDangChon.MaBan);
                if (_hoaDonHienTai != null)
                {
                    lblMaHDHienTai.Text = $"Mã HĐ: {_hoaDonHienTai.MaHD}";
                    lblGioVao.Text = $"Giờ vào: {_hoaDonHienTai.NgayLap:HH:mm:ss dd/MM}";

                    // Nạp khách hàng nếu có
                    if (!string.IsNullOrWhiteSpace(_hoaDonHienTai.MaKH))
                    {
                        var ds = _bll.TimKiemKhachHang("");
                        _khachDangChon = ds.FirstOrDefault(k => k.MaKH == _hoaDonHienTai.MaKH);
                        if (_khachDangChon != null)
                        {
                            decimal ck = _bll.LayChietKhauTheoKhach(_khachDangChon.MaKH);
                            lblThongTinKhach.Text = $"⭐ {_khachDangChon.TenKH} ({_khachDangChon.TenLoaiKH} - Giảm {ck}%)";
                        }
                    }
                    else
                    {
                        _khachDangChon = null;
                        lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";
                    }

                    NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                }
                else
                {
                    LamMoiHoaDonGiaoDien();
                }
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void NapChiTietHoaDon(string maHD)
        {
            try
            {
                _dsChiTietHD = _bll.LayChiTietHoaDon(maHD);
                dgvChiTietHD.DataSource = null;
                dgvChiTietHD.DataSource = _dsChiTietHD;

                TinhTongTienHoaDon();
                CapNhatBadgeSoLuongMonTrongDon();
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void LamMoiHoaDonGiaoDien()
        {
            _hoaDonHienTai = null;
            lblMaHDHienTai.Text = "Mã HĐ: --";
            lblGioVao.Text = "Giờ vào: --";
            _dsChiTietHD.Clear();
            dgvChiTietHD.DataSource = null;
            _tienHang = 0;
            lblTienHang.Text = "0 đ";
            numGiamGia.Value = 0;
            _tongThanhToan = 0;
            lblTongThanhToan.Text = "0 đ";
            numTienKhachDua.Value = 0;
            lblTienThoi.Text = "0 đ";

            if (_banDangChon == null)
            {
                lblBanDangChon.Text = "BÀN: Chưa chọn";
                btnMoBan.Enabled = false;
                btnMoBanNhanh.Enabled = false;
                btnChuyenBan.Enabled = false;
                btnChuyenBanNhanh.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyDon.Enabled = false;
                btnThemMon.Enabled = false;
                btnInTamTinh.Enabled = false;
            }

            CapNhatBadgeSoLuongMonTrongDon();
        }

        private void TinhTongTienHoaDon()
        {
            _tienHang = _dsChiTietHD.Sum(c => c.ThanhTien);
            lblTienHang.Text = $"{_tienHang:N0} đ";

            // Áp dụng chiết khấu khách hàng tự động
            decimal phanTramGiam = 0;
            if (_khachDangChon != null)
            {
                phanTramGiam = _bll.LayChietKhauTheoKhach(_khachDangChon.MaKH);
            }

            decimal tienGiam = Math.Round(_tienHang * phanTramGiam / 100m, 0);
            numGiamGia.Value = Math.Min(tienGiam, _tienHang);

            CapNhatTongCongVaTienThoi();
        }

        private void CapNhatTongCongVaTienThoi()
        {
            decimal giamGia = numGiamGia.Value;
            _tongThanhToan = Math.Max(0, _tienHang - giamGia);

            lblTongThanhToan.Text = $"{_tongThanhToan:N0} đ";

            if (cboPhuongThuc.SelectedItem?.ToString() == "Tiền mặt" && numTienKhachDua.Value < _tongThanhToan)
            {
                numTienKhachDua.Value = _tongThanhToan;
            }

            CapNhatTienThoi();
        }

        private void CapNhatTienThoi()
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            if (pt != "Tiền mặt")
            {
                lblTienThoi.ForeColor = Color.FromArgb(122, 111, 102);
                lblTienThoi.Text = "0 đ (Điện tử)";
                return;
            }

            decimal tienKhach = numTienKhachDua.Value;
            decimal tienThoi = tienKhach - _tongThanhToan;

            if (tienThoi >= 0)
            {
                lblTienThoi.ForeColor = Color.FromArgb(47, 125, 91); // #2F7D5B Accent Green
                lblTienThoi.Text = $"{tienThoi:N0} đ";
            }
            else
            {
                lblTienThoi.ForeColor = Color.FromArgb(214, 69, 69); // #D64545 Warning Red
                lblTienThoi.Text = $"Thiếu {Math.Abs(tienThoi):N0} đ";
            }
        }

        private void CboPhuongThuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            bool isTienMat = (pt == "Tiền mặt");

            numTienKhachDua.Enabled = isTienMat;
            pnlTienNhanh.Enabled = isTienMat;

            if (!isTienMat)
            {
                numTienKhachDua.Value = _tongThanhToan;
                lblTienThoi.Text = "0 đ (Điện tử)";
                lblTienThoi.ForeColor = Color.FromArgb(122, 111, 102);
            }
            else
            {
                CapNhatTienThoi();
            }
        }

        private void DatTienNhanh(decimal soTien)
        {
            if (numTienKhachDua.Value == 0 || numTienKhachDua.Value == _tongThanhToan)
                numTienKhachDua.Value = soTien;
            else
                numTienKhachDua.Value += soTien;
        }

        private ChiTietHoaDonDTO? LayChiTietDangChon()
        {
            if (dgvChiTietHD.CurrentRow?.DataBoundItem is ChiTietHoaDonDTO ct)
            {
                return ct;
            }
            return null;
        }

        private void BtnTangSL_Click(object? sender, EventArgs e)
        {
            var ct = LayChiTietDangChon();
            if (ct == null || _hoaDonHienTai == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món trên hóa đơn để tăng số lượng.");
                return;
            }

            try
            {
                _bll.CapNhatSoLuongMon(_hoaDonHienTai.MaHD, ct.MaThucUong, ct.SoLuong + 1);
                NapChiTietHoaDon(_hoaDonHienTai.MaHD);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnGiamSL_Click(object? sender, EventArgs e)
        {
            var ct = LayChiTietDangChon();
            if (ct == null || _hoaDonHienTai == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món trên hóa đơn để giảm số lượng.");
                return;
            }

            try
            {
                int slMoi = ct.SoLuong - 1;
                if (slMoi <= 0)
                {
                    if (UiHelper.Confirm($"Số lượng bằng 0. Bạn có muốn xóa món '{ct.TenThucUong}' khỏi hóa đơn không?"))
                    {
                        _bll.XoaMonKhoiHoaDon(_hoaDonHienTai.MaHD, ct.MaThucUong);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    _bll.CapNhatSoLuongMon(_hoaDonHienTai.MaHD, ct.MaThucUong, slMoi);
                }

                NapChiTietHoaDon(_hoaDonHienTai.MaHD);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnXoaMon_Click(object? sender, EventArgs e)
        {
            var ct = LayChiTietDangChon();
            if (ct == null || _hoaDonHienTai == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món cần xóa khỏi hóa đơn.");
                return;
            }

            if (UiHelper.Confirm($"Xác nhận xóa món '{ct.TenThucUong}' khỏi hóa đơn?"))
            {
                try
                {
                    _bll.XoaMonKhoiHoaDon(_hoaDonHienTai.MaHD, ct.MaThucUong);
                    NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                }
                catch (SqlException ex)
                {
                    UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
                }
                catch (Exception ex)
                {
                    XuLyLoi(ex);
                }
            }
        }

        private void BtnTimKhach_Click(object? sender, EventArgs e)
        {
            string tuKhoa = txtTimKhach.Text.Trim();
            try
            {
                var ds = _bll.TimKiemKhachHang(tuKhoa);
                if (ds.Count == 0)
                {
                    UiHelper.ShowWarning("Không tìm thấy khách hàng nào phù hợp.");
                    return;
                }

                _khachDangChon = ds[0];
                decimal ck = _bll.LayChietKhauTheoKhach(_khachDangChon.MaKH);
                lblThongTinKhach.Text = $"⭐ {_khachDangChon.TenKH} ({_khachDangChon.TenLoaiKH} - Giảm {ck}%)";

                TinhTongTienHoaDon();
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnThemKhachNhanh_Click(object? sender, EventArgs e)
        {
            UiHelper.ShowInfo("Chức năng tạo khách hàng mới đang được quản lý tại phân hệ Khách hàng (Thành viên 4). Vui lòng tìm kiếm khách hàng hiện có qua SĐT.", "Thông báo");
        }

        private void BtnBoChonKhach_Click(object? sender, EventArgs e)
        {
            _khachDangChon = null;
            txtTimKhach.Clear();
            lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";
            TinhTongTienHoaDon();
        }

        #endregion

        #region 4. Các nút chức năng chính: Mở bàn, Chuyển bàn, Thanh toán, Hủy đơn, Tạm tính

        private void BtnMoBan_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn bàn cần mở.");
                return;
            }

            if (!_banDangChon.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase))
            {
                UiHelper.ShowWarning($"Bàn {_banDangChon.SoBan} đang có khách hoặc đặt trước, không thể mở đơn mới.");
                return;
            }

            try
            {
                string? maKH = _khachDangChon?.MaKH;
                string maHD = _bll.MoBan(_banDangChon.MaBan, maKH);
                UiHelper.ShowInfo($"Đã mở Bàn {_banDangChon.SoBan} thành công! (Mã HĐ: {maHD})");

                RefreshDuLieu();
                ChonBan(_banDangChon.MaBan);
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnChuyenBan_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null || _hoaDonHienTai == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn bàn đang có khách để thực hiện chuyển bàn.");
                return;
            }

            // Lấy danh sách các bàn đang TRỐNG
            var dsBanTrong = _dsBan.Where(b => b.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase) && b.MaBan != _banDangChon.MaBan).ToList();
            if (dsBanTrong.Count == 0)
            {
                UiHelper.ShowWarning("Hiện tại không còn bàn trống nào trong quán để chuyển bàn!");
                return;
            }

            // Hiển thị Form hộp thoại chọn bàn đích
            using var formChuyen = new Form
            {
                Text = "Chuyển bàn",
                Size = new Size(390, 230),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblTieuDe = new Label
            {
                Text = $"Chuyển Hóa đơn {_hoaDonHienTai.MaHD} từ Bàn {_banDangChon.SoBan} sang:",
                Location = new Point(20, 20),
                Size = new Size(340, 24),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            var cboBanDich = new ComboBox
            {
                Location = new Point(20, 55),
                Size = new Size(335, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };

            foreach (var b in dsBanTrong)
            {
                cboBanDich.Items.Add($"Bàn {b.SoBan} - {b.TenViTri} ({b.SoChoNgoi} chỗ) [{b.MaBan}]");
            }
            cboBanDich.SelectedIndex = 0;

            var btnXacNhanChuyen = new Button
            {
                Text = "Xác nhận chuyển",
                Location = new Point(80, 115),
                Size = new Size(140, 36),
                BackColor = Color.FromArgb(139, 92, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXacNhanChuyen.FlatAppearance.BorderSize = 0;

            var btnHuyChuyen = new Button
            {
                Text = "Hủy",
                Location = new Point(230, 115),
                Size = new Size(85, 36),
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            btnHuyChuyen.FlatAppearance.BorderSize = 0;

            btnXacNhanChuyen.Click += (s, ev) =>
            {
                int idx = cboBanDich.SelectedIndex;
                if (idx < 0 || idx >= dsBanTrong.Count) return;

                var banMoi = dsBanTrong[idx];
                try
                {
                    _bll.ChuyenBan(_hoaDonHienTai.MaHD, _banDangChon.MaBan, banMoi.MaBan);
                    UiHelper.ShowInfo($"Đã chuyển hóa đơn từ Bàn {_banDangChon.SoBan} sang Bàn {banMoi.SoBan} thành công!", "Chuyển bàn thành công");
                    formChuyen.DialogResult = DialogResult.OK;
                    formChuyen.Close();

                    RefreshDuLieu();
                    ChonBan(banMoi.MaBan);
                }
                catch (SqlException sqlEx)
                {
                    UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(sqlEx));
                }
                catch (Exception ex)
                {
                    XuLyLoi(ex);
                }
            };

            btnHuyChuyen.Click += (s, ev) => formChuyen.Close();

            formChuyen.Controls.AddRange(new Control[] { lblTieuDe, cboBanDich, btnXacNhanChuyen, btnHuyChuyen });
            formChuyen.ShowDialog(this);
        }

        private void BtnThanhToan_Click(object? sender, EventArgs e)
        {
            if (_hoaDonHienTai == null || _banDangChon == null)
            {
                UiHelper.ShowWarning("Không có hóa đơn nào đang mở để thanh toán.");
                return;
            }

            if (_dsChiTietHD.Count == 0)
            {
                UiHelper.ShowWarning("Hóa đơn chưa có món thức uống nào. Vui lòng thêm món trước khi thanh toán.");
                return;
            }

            // Mở màn hình xác nhận thanh toán chuyên biệt (frmThanhToan)
            using var frmTT = new frmThanhToan(_hoaDonHienTai.MaHD, _banDangChon.SoBan.ToString(), _khachDangChon?.MaKH);
            if (frmTT.ShowDialog(this) == DialogResult.OK)
            {
                // Sau khi thanh toán thành công, nạp lại toàn bộ dữ liệu (Refresh)
                RefreshDuLieu();
            }
        }

        private void BtnHuyDon_Click(object? sender, EventArgs e)
        {
            if (_hoaDonHienTai == null || _banDangChon == null)
            {
                UiHelper.ShowWarning("Không có hóa đơn đang mở để hủy.");
                return;
            }

            if (UiHelper.Confirm($"Bạn có chắc chắn muốn HỦY Hóa đơn '{_hoaDonHienTai.MaHD}' của Bàn {_banDangChon.SoBan} không?\n" +
                                "Toàn bộ nguyên liệu của các món đã gọi sẽ tự động được hoàn trả về kho."))
            {
                try
                {
                    _bll.HuyHoaDon(_hoaDonHienTai.MaHD);
                    UiHelper.ShowInfo("Đã hủy hóa đơn thành công! Bàn đã trở về trạng thái trống.");
                    RefreshDuLieu();
                }
                catch (SqlException ex)
                {
                    UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
                }
                catch (Exception ex)
                {
                    XuLyLoi(ex);
                }
            }
        }

        private void BtnInTamTinh_Click(object? sender, EventArgs e)
        {
            if (_hoaDonHienTai == null || _banDangChon == null || _dsChiTietHD.Count == 0)
            {
                UiHelper.ShowWarning("Chưa có hóa đơn hoặc chưa có món để in tạm tính.");
                return;
            }

            decimal giamGia = numGiamGia.Value;
            decimal tong = _tongThanhToan;

            var sb = new StringBuilder();
            sb.AppendLine("         CAFE NHÓM 06 - COFFEE & TEA         ");
            sb.AppendLine("     01 Võ Văn Ngân, TP. Thủ Đức, TP. HCM     ");
            sb.AppendLine("             Hotline: 1900 6868              ");
            sb.AppendLine("=============================================");
            sb.AppendLine("             PHIẾU TẠM TÍNH TIỀN             ");
            sb.AppendLine($"Số HĐ   : {_hoaDonHienTai.MaHD}");
            sb.AppendLine($"Bàn     : Bàn {_banDangChon.SoBan} ({_banDangChon.TenViTri})");
            sb.AppendLine($"Giờ vào : {_hoaDonHienTai.NgayLap:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Thu ngân: {CurrentUser.TenNV}");
            sb.AppendLine($"Khách   : {(_khachDangChon != null ? _khachDangChon.TenKH : "Khách vãng lai")}");
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine(string.Format("{0,-20} {1,3} {2,9} {3,10}", "Tên món", "SL", "Đơn giá", "T.Tiền"));
            sb.AppendLine("---------------------------------------------");

            foreach (var ct in _dsChiTietHD)
            {
                string ten = ct.TenThucUong.Length > 20 ? ct.TenThucUong.Substring(0, 19) + "." : ct.TenThucUong;
                sb.AppendLine(string.Format("{0,-20} {1,3} {2,9:N0} {3,10:N0}", ten, ct.SoLuong, ct.DonGia, ct.ThanhTien));
            }

            sb.AppendLine("---------------------------------------------");
            sb.AppendLine($"Tiền hàng      : {_tienHang,28:N0} đ");
            sb.AppendLine($"Chiết khấu     : {giamGia,28:N0} đ");
            sb.AppendLine($"TỔNG CỘNG      : {tong,28:N0} đ");
            sb.AppendLine("=============================================");
            sb.AppendLine("    (Phiếu dùng để đối soát trước khi thanh toán)   ");

            using var preview = new frmXemHoaDon("Phiếu tạm tính", sb.ToString());
            preview.ShowDialog(this);
        }

        private void XuLyLoi(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                CustomSqlExceptionHandler.XuLy(sqlEx);
            }
            else if (ex.InnerException is SqlException innerSqlEx)
            {
                CustomSqlExceptionHandler.XuLy(innerSqlEx);
            }
            else if (ex is ArgumentException or InvalidOperationException)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            else
            {
                UiHelper.HienThongBaoLoi("Lỗi: " + ex.Message + "\nChi tiết: " + ex.StackTrace);
            }
        }

        #endregion
    }

    /// <summary>
    /// Lớp bí danh FormBanHang để tương thích với FormLauncher (MenuConfigItem gọi QuanLyQuanCafe.GUI.BanHang.FormBanHang)
    /// </summary>
    public class FormBanHang : frmBanHang
    {
    }
}

namespace QuanLyQuanCafe.GUI
{
    /// <summary>
    /// Lớp bí danh trong namespace QuanLyQuanCafe.GUI tương thích với đường dẫn gọi ngoài
    /// </summary>
    public class frmBanHang : QuanLyQuanCafe.GUI.BanHang.frmBanHang
    {
    }

    public class FormBanHang : QuanLyQuanCafe.GUI.BanHang.frmBanHang
    {
    }
}
