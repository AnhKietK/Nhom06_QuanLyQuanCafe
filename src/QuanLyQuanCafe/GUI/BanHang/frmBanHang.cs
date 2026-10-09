using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
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

        public frmBanHang()
        {
            InitializeComponent();
            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FrmBanHang_Load;

            // Bộ lọc sơ đồ bàn
            cboKhuVuc.SelectedIndexChanged += (s, e) => ApDungBoLocBan();
            cboTrangThaiBan.SelectedIndexChanged += (s, e) => ApDungBoLocBan();
            btnLamMoiToanBo.Click += (s, e) => RefreshDuLieu();

            // Thực đơn thức uống
            txtTimKiemMon.TextChanged += (s, e) => TimKiemMonNuoc();
            cboLoaiMon.SelectedIndexChanged += (s, e) => TimKiemMonNuoc();
            btnThemMon.Click += BtnThemMon_Click;
            btnKiemTraKho.Click += BtnKiemTraKho_Click;
            dgvThucUong.CellDoubleClick += (s, e) => BtnThemMon_Click(s, e);

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

            // Tính tiền & Phương thức thanh toán
            numGiamGia.ValueChanged += (s, e) => CapNhatTongCongVaTienThoi();
            numTienKhachDua.ValueChanged += (s, e) => CapNhatTienThoi();
            cboPhuongThuc.SelectedIndexChanged += CboPhuongThuc_SelectedIndexChanged;

            btnTienVuaDu.Click += (s, e) => numTienKhachDua.Value = _tongThanhToan;
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
            NapPhuongThucThanhToan();
            NapDanhSachKhuVuc();
            NapDanhSachTrangThai();
            NapDanhSachLoaiMon();
            RefreshDuLieu();
        }

        #region 1. Nạp và Làm mới Dữ liệu (Refresh)

        /// <summary>
        /// Hàm nạp lại toàn bộ dữ liệu bàn, thực đơn và hóa đơn hiện tại (Refresh)
        /// </summary>
        public void RefreshDuLieu()
        {
            try
            {
                NapDanhSachBan();
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
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
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
            try
            {
                cboKhuVuc.Items.Clear();
                cboKhuVuc.Items.Add("Tất cả khu vực");

                var dsBan = _bll.LayDanhSachBan();
                var khuVucList = dsBan.Select(b => b.TenViTri).Distinct().OrderBy(x => x).ToList();
                foreach (var kv in khuVucList)
                {
                    cboKhuVuc.Items.Add(kv);
                }

                cboKhuVuc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
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

        private void NapDanhSachBan()
        {
            try
            {
                _dsBan = _bll.LayDanhSachBan();
                ApDungBoLocBan();
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void ApDungBoLocBan()
        {
            string khuVuc = cboKhuVuc.SelectedItem?.ToString() ?? "Tất cả khu vực";
            string trangThai = cboTrangThaiBan.SelectedItem?.ToString() ?? "Tất cả trạng thái";

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

            lblThongKeBan.Text = $"Tổng: {tong} | 🟢 Trống: {trong} | 🔴 Có khách: {coKhach}" + (datTruoc > 0 ? $" | 🟡 Đặt: {datTruoc}" : "");

            foreach (var b in danhSach)
            {
                var btnBan = new Button
                {
                    Width = 130,
                    Height = 84,
                    Margin = new Padding(6),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = b
                };
                btnBan.FlatAppearance.BorderSize = 2;

                string ttHienThi;
                Color mauNen;
                if (b.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase))
                {
                    ttHienThi = "🔴 CÓ KHÁCH";
                    mauNen = Color.FromArgb(239, 68, 68); // Đỏ Soft Crimson
                }
                else if (b.TrangThai.Equals("DATTRUOC", StringComparison.OrdinalIgnoreCase))
                {
                    ttHienThi = "🟡 ĐẶT TRƯỚC";
                    mauNen = Color.FromArgb(245, 158, 11); // Vàng Amber
                }
                else
                {
                    ttHienThi = "🟢 TRỐNG";
                    mauNen = Color.FromArgb(16, 185, 129); // Xanh Emerald
                }

                btnBan.BackColor = mauNen;
                btnBan.ForeColor = Color.White;
                btnBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                btnBan.Text = $"BÀN {b.SoBan}\n{b.TenViTri} ({b.SoChoNgoi} chỗ)\n{ttHienThi}";

                if (_banDangChon != null && _banDangChon.MaBan == b.MaBan)
                {
                    btnBan.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235); // Viền xanh Blue nổi bật
                    btnBan.FlatAppearance.BorderSize = 3;
                }
                else
                {
                    btnBan.FlatAppearance.BorderColor = Color.Transparent;
                }

                btnBan.Click += (s, e) =>
                {
                    if (s is Button btn && btn.Tag is BanDTO banDTO)
                    {
                        ChonBan(banDTO.MaBan);
                    }
                };

                flpDanhSachBan.Controls.Add(btnBan);
            }

            flpDanhSachBan.ResumeLayout();
        }

        private void ChonBan(string maBan)
        {
            _banDangChon = _dsBan.FirstOrDefault(b => b.MaBan == maBan);
            if (_banDangChon == null)
                return;

            // Highlight button bàn trên sơ đồ
            foreach (Control c in flpDanhSachBan.Controls)
            {
                if (c is Button btn && btn.Tag is BanDTO b)
                {
                    bool isSelected = (b.MaBan == maBan);
                    btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(37, 99, 235) : Color.Transparent;
                    btn.FlatAppearance.BorderSize = isSelected ? 3 : 2;
                }
            }

            lblBanDangChon.Text = $"BÀN: {(_banDangChon.SoBan < 10 ? "0" : "")}{_banDangChon.SoBan} ({_banDangChon.TenViTri})";

            // Kiểm tra trạng thái bàn và thiết lập giao diện
            if (_banDangChon.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase))
            {
                NapHoaDonCuaBanHienTai();
                btnMoBan.Enabled = false;
                btnChuyenBan.Enabled = true;
                btnThanhToan.Enabled = true;
                btnHuyDon.Enabled = true;
                btnThemMon.Enabled = true;
            }
            else
            {
                LamMoiHoaDonGiaoDien();
                btnMoBan.Enabled = true;
                btnChuyenBan.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuyDon.Enabled = false;
                btnThemMon.Enabled = true; // Cho phép bấm thêm món, hệ thống tự mở đơn
            }
        }

        #endregion

        #region 2. Xử lý Thực đơn thức uống

        private void NapDanhSachLoaiMon()
        {
            try
            {
                _dsLoaiTU = _bll.LayDanhSachLoaiThucUong();
                cboLoaiMon.Items.Clear();
                cboLoaiMon.Items.Add("Tất cả loại món");
                foreach (var loai in _dsLoaiTU)
                {
                    cboLoaiMon.Items.Add(loai.TenLoai);
                }
                cboLoaiMon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void NapDanhSachThucUong()
        {
            try
            {
                _dsThucUong = _bll.LayDanhSachThucUong();
                dgvThucUong.DataSource = null;
                dgvThucUong.DataSource = _dsThucUong;
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void TimKiemMonNuoc()
        {
            string tuKhoa = txtTimKiemMon.Text.Trim();
            string loai = cboLoaiMon.SelectedItem?.ToString() ?? "Tất cả loại món";

            string? maLoai = null;
            if (loai != "Tất cả loại món")
            {
                var l = _dsLoaiTU.FirstOrDefault(x => x.TenLoai == loai);
                if (l != null) maLoai = l.MaLoaiTU;
            }

            try
            {
                var ketQua = _bll.TimKiemThucUong(tuKhoa, maLoai);
                dgvThucUong.DataSource = null;
                dgvThucUong.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private ThucUongDTO? LayThucUongDangChon()
        {
            if (dgvThucUong.CurrentRow?.DataBoundItem is ThucUongDTO mon)
                return mon;
            return null;
        }

        private void BtnKiemTraKho_Click(object? sender, EventArgs e)
        {
            var mon = LayThucUongDangChon();
            if (mon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món nước cần kiểm tra tồn kho.");
                return;
            }

            int soLuong = (int)numSoLuongMon.Value;
            try
            {
                bool du = _bll.KiemTraDuNguyenLieu(mon.MaThucUong, soLuong);
                if (du)
                {
                    UiHelper.ShowInfo($"Kho còn đủ nguyên liệu để pha chế {soLuong} ly '{mon.TenThucUong}'.", "Kiểm tra kho");
                }
                else
                {
                    UiHelper.ShowWarning($"Kho KHÔNG đủ nguyên liệu để pha chế {soLuong} ly '{mon.TenThucUong}'!", "Cảnh báo thiếu nguyên liệu");
                }
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void BtnThemMon_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn bàn trước khi gọi món.");
                return;
            }

            var mon = LayThucUongDangChon();
            if (mon == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món thức uống từ danh sách.");
                return;
            }

            int soLuong = (int)numSoLuongMon.Value;
            if (soLuong <= 0)
            {
                UiHelper.ShowWarning("Số lượng món phải lớn hơn 0.");
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
                numSoLuongMon.Value = 1;

                // Refresh lại chi tiết hóa đơn
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

        #endregion

        #region 3. Xử lý Hóa đơn chi tiết & Ô tính tiền

        private void LamMoiHoaDonGiaoDien()
        {
            _hoaDonHienTai = null;
            _dsChiTietHD.Clear();
            dgvChiTietHD.DataSource = null;
            lblMaHDHienTai.Text = "Mã HĐ: --";
            lblGioVao.Text = "Giờ vào: --";
            _tienHang = 0;
            _tongThanhToan = 0;
            lblTienHang.Text = "0 đ";
            numGiamGia.Value = 0;
            lblTongThanhToan.Text = "0 đ";
            numTienKhachDua.Value = 0;
            lblTienThoi.Text = "0 đ";
            _khachDangChon = null;
            lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";
            txtTimKhach.Clear();
        }

        private void NapHoaDonCuaBanHienTai()
        {
            if (_banDangChon == null)
                return;

            try
            {
                _hoaDonHienTai = _bll.LayHoaDonDangMoTheoBan(_banDangChon.MaBan);
                if (_hoaDonHienTai != null)
                {
                    lblMaHDHienTai.Text = $"Mã HĐ: {_hoaDonHienTai.MaHD}";
                    lblGioVao.Text = $"Giờ vào: {_hoaDonHienTai.NgayLap:HH:mm dd/MM}";

                    // Nạp khách hàng nếu hóa đơn có gắn mã khách
                    if (!string.IsNullOrWhiteSpace(_hoaDonHienTai.MaKH))
                    {
                        var dsKH = _bll.TimKiemKhach(_hoaDonHienTai.MaKH);
                        _khachDangChon = dsKH.FirstOrDefault(k => k.MaKH == _hoaDonHienTai.MaKH);
                        if (_khachDangChon != null)
                        {
                            txtTimKhach.Text = _khachDangChon.SoDienThoai;
                            lblThongTinKhach.Text = $"{_khachDangChon.TenKH} ({_khachDangChon.TenLoai} - Giảm {_khachDangChon.ChietKhau}%)";
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

                _tienHang = _dsChiTietHD.Sum(c => c.ThanhTien);
                lblTienHang.Text = $"{_tienHang:N0} đ";

                // Tính tiền giảm giá theo khách hàng nếu có
                decimal chietKhau = _khachDangChon != null ? _khachDangChon.ChietKhau : 0;
                decimal giamGia = Math.Round(_tienHang * chietKhau / 100m, 0);
                numGiamGia.Value = Math.Min(giamGia, _tienHang);

                CapNhatTongCongVaTienThoi();
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void CapNhatTongCongVaTienThoi()
        {
            decimal giamGia = numGiamGia.Value;
            _tongThanhToan = Math.Max(0, _tienHang - giamGia);

            lblTongThanhToan.Text = $"{_tongThanhToan:N0} đ";

            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            if (pt != "Tiền mặt")
            {
                numTienKhachDua.Value = _tongThanhToan;
            }
            else if (numTienKhachDua.Value < _tongThanhToan && numTienKhachDua.Value == 0)
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
                lblTienThoi.ForeColor = Color.FromArgb(100, 116, 139);
                lblTienThoi.Text = "0 đ (Điện tử)";
                return;
            }

            decimal tienKhach = numTienKhachDua.Value;
            decimal tienThoi = tienKhach - _tongThanhToan;

            if (tienThoi >= 0)
            {
                lblTienThoi.ForeColor = Color.FromArgb(22, 163, 74); // Xanh lá
                lblTienThoi.Text = $"{tienThoi:N0} đ";
            }
            else
            {
                lblTienThoi.ForeColor = Color.FromArgb(220, 38, 38); // Đỏ thiếu tiền
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
                lblTienThoi.Text = "0 đ";
            }
            else
            {
                CapNhatTienThoi();
            }
        }

        private void DatTienNhanh(decimal soTien)
        {
            numTienKhachDua.Value = Math.Max(soTien, numTienKhachDua.Value + soTien);
        }

        private ChiTietHoaDonDTO? LayChiTietDangChon()
        {
            if (dgvChiTietHD.CurrentRow?.DataBoundItem is ChiTietHoaDonDTO ct)
                return ct;
            return null;
        }

        private void BtnTangSL_Click(object? sender, EventArgs e)
        {
            var ct = LayChiTietDangChon();
            if (ct == null || _hoaDonHienTai == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn món trong hóa đơn cần tăng số lượng.");
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
                UiHelper.ShowWarning("Vui lòng chọn món trong hóa đơn cần giảm số lượng.");
                return;
            }

            try
            {
                if (ct.SoLuong - 1 <= 0)
                {
                    if (UiHelper.Confirm($"Số lượng sẽ về 0. Bạn có muốn xóa món '{ct.TenThucUong}' khỏi hóa đơn không?"))
                    {
                        _bll.XoaMonKhoiHoaDon(_hoaDonHienTai.MaHD, ct.MaThucUong);
                        NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                    }
                }
                else
                {
                    _bll.CapNhatSoLuongMon(_hoaDonHienTai.MaHD, ct.MaThucUong, ct.SoLuong - 1);
                    NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                }
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

        #endregion

        #region 4. Các nút chức năng chính: Mở bàn, Chuyển bàn, Thanh toán, Hủy đơn

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
                Size = new Size(380, 220),
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
                Size = new Size(330, 24),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            var cboBanDich = new ComboBox
            {
                Location = new Point(20, 55),
                Size = new Size(325, 30),
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
                Size = new Size(130, 36),
                BackColor = Color.FromArgb(139, 92, 246),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnXacNhanChuyen.FlatAppearance.BorderSize = 0;

            var btnHuyChuyen = new Button
            {
                Text = "Hủy",
                Location = new Point(220, 115),
                Size = new Size(85, 36),
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F)
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

            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            if (phuongThuc == "Tiền mặt" && numTienKhachDua.Value < _tongThanhToan)
            {
                UiHelper.ShowWarning($"Tiền khách đưa ({numTienKhachDua.Value:N0} đ) chưa đủ so với tổng thanh toán ({_tongThanhToan:N0} đ).");
                return;
            }

            decimal giamGia = numGiamGia.Value;

            if (!UiHelper.Confirm($"Xác nhận thanh toán Hóa đơn '{_hoaDonHienTai.MaHD}' cho Bàn {_banDangChon.SoBan}?\n" +
                                 $"Tổng tiền hàng: {_tienHang:N0} đ\n" +
                                 $"Giảm giá: {giamGia:N0} đ\n" +
                                 $"TỔNG THANH TOÁN: {_tongThanhToan:N0} đ\n" +
                                 $"Phương thức: {phuongThuc}"))
            {
                return;
            }

            try
            {
                decimal tongThanhToanThucTe = _bll.ThanhToanHoaDon(_hoaDonHienTai.MaHD, giamGia, phuongThuc);
                decimal tienThoi = (phuongThuc == "Tiền mặt") ? (numTienKhachDua.Value - tongThanhToanThucTe) : 0;

                string thongBao = $"Thanh toán Hóa đơn {_hoaDonHienTai.MaHD} thành công!\n" +
                                  $"Bàn {_banDangChon.SoBan} đã được giải phóng về trạng thái Trống.\n" +
                                  $"Phương thức: {phuongThuc}\n" +
                                  $"Tổng thanh toán: {tongThanhToanThucTe:N0} đ";

                if (phuongThuc == "Tiền mặt" && tienThoi > 0)
                {
                    thongBao += $"\nTiền thối lại cho khách: {tienThoi:N0} đ";
                }

                UiHelper.ShowInfo(thongBao, "Thanh toán thành công");

                // Nạp lại toàn bộ dữ liệu (Refresh) sau khi thanh toán
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

            string noiDung = $"=== PHIẾU TẠM TÍNH ===\n" +
                             $"Hóa đơn: {_hoaDonHienTai.MaHD}\n" +
                             $"Bàn: {_banDangChon.SoBan} ({_banDangChon.TenViTri})\n" +
                             $"Giờ vào: {_hoaDonHienTai.NgayLap:dd/MM/yyyy HH:mm}\n" +
                             $"Khách hàng: {(_khachDangChon != null ? _khachDangChon.TenKH : "Khách vãng lai")}\n" +
                             $"----------------------------------------\n";

            foreach (var ct in _dsChiTietHD)
            {
                noiDung += $"{ct.TenThucUong,-20} x{ct.SoLuong,-2} = {ct.ThanhTien:N0} đ\n";
            }

            noiDung += $"----------------------------------------\n" +
                       $"Tiền hàng:      {_tienHang:N0} đ\n" +
                       $"Giảm giá:       {giamGia:N0} đ\n" +
                       $"TỔNG CỘNG:      {tong:N0} đ\n\n" +
                       $"(Phiếu dùng để đối soát trước khi thanh toán)";

            UiHelper.ShowInfo(noiDung, "Phiếu tạm tính");
        }

        #endregion

        #region 5. Xử lý Khách hàng

        private void BtnTimKhach_Click(object? sender, EventArgs e)
        {
            string tuKhoa = txtTimKhach.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                _khachDangChon = null;
                lblThongTinKhach.Text = "Khách vãng lai (Chiết khấu 0%)";
                if (_hoaDonHienTai != null)
                {
                    NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                }
                return;
            }

            try
            {
                var ds = _bll.TimKiemKhach(tuKhoa);
                if (ds.Count > 0)
                {
                    _khachDangChon = ds[0];
                    lblThongTinKhach.Text = $"{_khachDangChon.TenKH} ({_khachDangChon.TenLoai} - Chiết khấu {_khachDangChon.ChietKhau}%)";
                    if (_hoaDonHienTai != null)
                    {
                        NapChiTietHoaDon(_hoaDonHienTai.MaHD);
                    }
                }
                else
                {
                    UiHelper.ShowWarning($"Không tìm thấy khách hàng nào với từ khóa '{tuKhoa}'.");
                }
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

        private void BtnThemKhachNhanh_Click(object? sender, EventArgs e)
        {
            using var formNhap = new Form
            {
                Text = "Thêm nhanh khách hàng",
                Size = new Size(380, 220),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblTen = new Label { Text = "Tên khách hàng:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            var txtTen = new TextBox { Location = new Point(140, 18), Width = 200, Font = new Font("Segoe UI", 9.5F) };

            var lblSdt = new Label { Text = "Số điện thoại:", Location = new Point(20, 60), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            var txtSdt = new TextBox { Location = new Point(140, 58), Width = 200, Font = new Font("Segoe UI", 9.5F), Text = txtTimKhach.Text.Trim() };

            var btnLuu = new Button
            {
                Text = "Lưu",
                Location = new Point(140, 110),
                Width = 95,
                Height = 35,
                BackColor = Color.FromArgb(16, 185, 129),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnLuu.FlatAppearance.BorderSize = 0;

            var btnHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(245, 110),
                Width = 95,
                Height = 35,
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F)
            };
            btnHuy.FlatAppearance.BorderSize = 0;

            btnLuu.Click += (s, ev) =>
            {
                try
                {
                    string maKH = _bll.ThemKhachHangNhanh(txtTen.Text.Trim(), txtSdt.Text.Trim());
                    UiHelper.ShowInfo($"Thêm khách hàng thành công! Mã khách: {maKH}");
                    txtTimKhach.Text = txtSdt.Text.Trim();
                    formNhap.DialogResult = DialogResult.OK;
                    formNhap.Close();
                    BtnTimKhach_Click(sender, e);
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

            btnHuy.Click += (s, ev) => formNhap.Close();

            formNhap.Controls.AddRange(new Control[] { lblTen, txtTen, lblSdt, txtSdt, btnLuu, btnHuy });
            formNhap.ShowDialog(this);
        }

        #endregion

        #region 6. Xử lý lỗi CSDL tập trung với CustomSqlExceptionHandler

        private void XuLyLoi(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(sqlEx));
            }
            else if (ex.InnerException is SqlException innerSqlEx)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(innerSqlEx));
            }
            else if (ex is ArgumentException or InvalidOperationException)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            else
            {
                UiHelper.HienLoi(ex);
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
