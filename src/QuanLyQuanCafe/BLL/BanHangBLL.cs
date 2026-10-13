using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class BanHangBLL
    {
        private readonly BanHangDAL _dal = new();
        private static readonly string[] PhuongThucHopLe = { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" };

        #region 1. Nghiệp vụ Quản lý Bàn

        public List<BanDTO> LayDanhSachBan()
        {
            return _dal.LayDanhSachBan();
        }

        public HoaDonDTO? LayHoaDonDangMoTheoBan(string maBan)
        {
            ValidationHelper.BatBuocNhap(maBan, "Mã bàn");
            return _dal.LayHoaDonDangMoTheoBan(maBan.Trim());
        }

        /// <summary>
        /// Mở bàn mới: Kiểm tra trạng thái bàn và tạo hóa đơn cho bàn
        /// </summary>
        public string MoBan(string maBan, string? maKH = null, string phuongThucThanhToan = "Tiền mặt")
        {
            ValidationHelper.BatBuocNhap(maBan, "Mã bàn");

            if (string.IsNullOrWhiteSpace(CurrentUser.MaNV))
                throw new InvalidOperationException("Chưa xác định thông tin nhân viên đăng nhập.");

            // Kiểm tra trạng thái bàn trước khi mở
            var dsBan = _dal.LayDanhSachBan();
            var ban = dsBan.FirstOrDefault(b => b.MaBan.Equals(maBan.Trim(), StringComparison.OrdinalIgnoreCase));
            if (ban == null)
                throw new ArgumentException("Bàn không tồn tại trong hệ thống.");

            if (!ban.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Bàn {ban.SoBan} đang ở trạng thái '{ban.TrangThai}', không thể mở đơn mới.");

            return _dal.TaoHoaDon(
                string.IsNullOrWhiteSpace(maKH) ? null : maKH.Trim(),
                CurrentUser.MaNV,
                maBan.Trim(),
                string.IsNullOrWhiteSpace(phuongThucThanhToan) ? "Tiền mặt" : phuongThucThanhToan.Trim()
            );
        }

        public string MoHoaDon(string maBan, string? maKH = null, string phuongThucThanhToan = "Tiền mặt")
        {
            return MoBan(maBan, maKH, phuongThucThanhToan);
        }

        /// <summary>
        /// Chuyển bàn: Chuyển hóa đơn đang mở từ bàn cũ sang bàn mới (phải đang trống)
        /// </summary>
        public void ChuyenBan(string maHD, string maBanCu, string maBanMoi)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            ValidationHelper.BatBuocNhap(maBanCu, "Mã bàn hiện tại");
            ValidationHelper.BatBuocNhap(maBanMoi, "Mã bàn đích");

            if (maBanCu.Trim().Equals(maBanMoi.Trim(), StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Bàn đích phải khác bàn hiện tại.");

            var dsBan = _dal.LayDanhSachBan();
            var banMoi = dsBan.FirstOrDefault(b => b.MaBan.Equals(maBanMoi.Trim(), StringComparison.OrdinalIgnoreCase));
            if (banMoi == null)
                throw new ArgumentException("Bàn đích không tồn tại.");

            if (!banMoi.TrangThai.Equals("TRONG", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Bàn {banMoi.SoBan} đang có khách hoặc đặt trước, không thể chuyển tới.");

            _dal.ChuyenBan(maHD.Trim(), maBanCu.Trim(), maBanMoi.Trim());
        }

        #endregion

        #region 2. Nghiệp vụ Gọi món & Chi tiết Hóa đơn

        public List<ChiTietHoaDonDTO> LayChiTietHoaDon(string maHD)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            return _dal.LayChiTietHoaDon(maHD.Trim());
        }

        /// <summary>
        /// Thêm món vào hóa đơn: Kiểm tra đủ nguyên liệu trước khi gọi món
        /// </summary>
        public void ThemMonVaoHoaDon(string maHD, string maThucUong, int soLuong)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            ValidationHelper.BatBuocNhap(maThucUong, "Món thức uống");

            if (soLuong <= 0)
                throw new ArgumentException("Số lượng món phải lớn hơn 0.");

            // Kiểm tra trước kho nguyên liệu qua hàm SQL
            if (!_dal.KiemTraDuNguyenLieu(maThucUong.Trim(), soLuong))
                throw new InvalidOperationException("Kho không đủ nguyên liệu để pha chế số lượng món này.");

            _dal.ThemMonVaoHoaDon(maHD.Trim(), maThucUong.Trim(), soLuong);
        }

        public void CapNhatSoLuongMon(string maHD, string maThucUong, int soLuongMoi)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            ValidationHelper.BatBuocNhap(maThucUong, "Món thức uống");

            _dal.CapNhatSoLuongMon(maHD.Trim(), maThucUong.Trim(), soLuongMoi);
        }

        public void XoaMonKhoiHoaDon(string maHD, string maThucUong)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            ValidationHelper.BatBuocNhap(maThucUong, "Món thức uống");

            // SP sp_CapNhatSoLuongMon tự xóa khi số lượng <= 0
            _dal.CapNhatSoLuongMon(maHD.Trim(), maThucUong.Trim(), 0);
        }

        public void HuyHoaDon(string maHD)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            _dal.HuyHoaDon(maHD.Trim());
        }

        #endregion

        #region 3. Nghiệp vụ Tính tiền & Thanh toán

        /// <summary>
        /// Tính toán tiền hàng, chiết khấu và tổng thanh toán của hóa đơn
        /// </summary>
        public (decimal TienHang, decimal TienGiamGia, decimal TongThanhToan) TinhTienHoaDon(string maHD, string? maKH = null)
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");

            var chiTietList = _dal.LayChiTietHoaDon(maHD.Trim());
            decimal tienHang = chiTietList.Sum(c => c.ThanhTien);

            decimal phanTramGiam = 0;
            if (!string.IsNullOrWhiteSpace(maKH))
            {
                phanTramGiam = _dal.LayChietKhauTheoKhach(maKH.Trim());
            }

            decimal tienGiamGia = Math.Round(tienHang * phanTramGiam / 100m, 0);
            decimal tongThanhToan = Math.Max(0, tienHang - tienGiamGia);

            return (tienHang, tienGiamGia, tongThanhToan);
        }

        /// <summary>
        /// Thanh toán hóa đơn: Cập nhật trạng thái 'Đã thanh toán', tính điểm và giải phóng bàn
        /// </summary>
        public decimal ThanhToanHoaDon(string maHD, decimal? tienGiamGia, string phuongThucThanhToan = "Tiền mặt")
        {
            ValidationHelper.BatBuocNhap(maHD, "Mã hóa đơn");
            ValidationHelper.BatBuocNhap(phuongThucThanhToan, "Phương thức thanh toán");

            string pt = phuongThucThanhToan.Trim();
            if (!PhuongThucHopLe.Contains(pt))
                throw new ArgumentException("Phương thức thanh toán không hợp lệ. Chỉ chấp nhận: Tiền mặt, Chuyển khoản, Thẻ, Ví điện tử.");

            if (tienGiamGia.HasValue && tienGiamGia.Value < 0)
                throw new ArgumentException("Tiền giảm giá không được âm.");

            return _dal.ThanhToanHoaDon(maHD.Trim(), tienGiamGia, pt);
        }

        #endregion

        #region 4. Nghiệp vụ Thực đơn & Khách hàng

        public List<LoaiThucUongDTO> LayDanhSachLoaiThucUong()
        {
            return _dal.LayDanhSachLoaiThucUong();
        }

        public List<ThucUongDTO> LayDanhSachThucUong(string? maLoaiTU = null)
        {
            return _dal.LayDanhSachThucUong(string.IsNullOrWhiteSpace(maLoaiTU) ? null : maLoaiTU.Trim());
        }

        public List<ThucUongDTO> TimKiemThucUong(string? tuKhoa, string? maLoaiTU = null)
        {
            return _dal.TimKiemThucUong(
                string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim(),
                string.IsNullOrWhiteSpace(maLoaiTU) ? null : maLoaiTU.Trim()
            );
        }

        public bool KiemTraDuNguyenLieu(string maThucUong, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(maThucUong) || soLuong <= 0)
                return false;

            return _dal.KiemTraDuNguyenLieu(maThucUong.Trim(), soLuong);
        }

        public bool KiemTraTonKhoMonNuoc(string maThucUong, int soLuong)
        {
            return KiemTraDuNguyenLieu(maThucUong, soLuong);
        }

        public decimal LayChietKhauTheoKhach(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return 0;

            return _dal.LayChietKhauTheoKhach(maKH.Trim());
        }

        public List<KhachHangDTO> TimKiemKhach(string tuKhoa)
        {
            return _dal.TimKiemKhach(tuKhoa ?? "");
        }

        public List<KhachHangDTO> TimKiemKhachHang(string tuKhoa)
        {
            return TimKiemKhach(tuKhoa);
        }

        public string ThemKhachHangNhanh(string tenKH, string sdt)
        {
            ValidationHelper.BatBuocNhap(tenKH, "Tên khách hàng");
            ValidationHelper.BatBuocSdt(sdt);

            return _dal.ThemKhachHang(tenKH.Trim(), sdt.Trim());
        }

        #endregion
    }
}
