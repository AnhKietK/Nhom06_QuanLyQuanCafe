using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class KhachBLL
    {
        private readonly KhachDAL _dal = new();

        public List<KhachDTO> LayDanhSach()
        {
            return _dal.TimKiem("");
        }

        public List<KhachDTO> TimKiem(string tuKhoa)
        {
            return _dal.TimKiem(tuKhoa?.Trim() ?? "");
        }

        public List<LoaiKhachDTO> LayDanhSachLoaiKhach()
        {
            return _dal.LayDanhSachLoaiKhach();
        }

        public List<KhachDTO> LayDanhSachKhachThanThiet()
        {
            return _dal.LayDanhSachKhachThanThiet();
        }

        public List<LichSuMuaHangDTO> LayLichSuMuaHang(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return new List<LichSuMuaHangDTO>();

            return _dal.LayLichSuMuaHang(maKH.Trim());
        }

        public string Them(KhachDTO kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh));

            ValidationHelper.BatBuocNhap(kh.TenKH, "Tên khách hàng");
            ValidationHelper.BatBuocSdt(kh.SoDienThoai);
            ValidationHelper.BatBuocNhap(kh.MaLoaiKH, "Loại khách hàng");

            string sdt = kh.SoDienThoai.Trim();
            var dsHienTai = _dal.TimKiem(sdt);
            if (dsHienTai.Any(x => string.Equals(x.SoDienThoai?.Trim(), sdt, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Số điện thoại này đã được đăng ký cho khách hàng khác.");
            }

            kh.TenKH = kh.TenKH.Trim();
            kh.SoDienThoai = sdt;
            kh.MaLoaiKH = kh.MaLoaiKH.Trim();

            return _dal.Them(kh);
        }

        public void Sua(KhachDTO kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh));

            ValidationHelper.BatBuocNhap(kh.MaKH, "Mã khách hàng");
            ValidationHelper.BatBuocNhap(kh.TenKH, "Tên khách hàng");
            ValidationHelper.BatBuocSdt(kh.SoDienThoai);
            ValidationHelper.BatBuocNhap(kh.MaLoaiKH, "Loại khách hàng");

            string maKH = kh.MaKH.Trim();
            string sdt = kh.SoDienThoai.Trim();

            var dsHienTai = _dal.TimKiem(sdt);
            if (dsHienTai.Any(x => !string.Equals(x.MaKH?.Trim(), maKH, StringComparison.OrdinalIgnoreCase) &&
                                   string.Equals(x.SoDienThoai?.Trim(), sdt, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Số điện thoại này đã được đăng ký cho khách hàng khác.");
            }

            kh.MaKH = maKH;
            kh.TenKH = kh.TenKH.Trim();
            kh.SoDienThoai = sdt;
            kh.MaLoaiKH = kh.MaLoaiKH.Trim();

            _dal.Sua(kh);
        }

        public void Xoa(string maKH)
        {
            ValidationHelper.BatBuocNhap(maKH, "Mã khách hàng");

            if (!string.Equals(CurrentUser.ChucVu, "Quản lý", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Chỉ Quản lý mới có quyền xóa khách hàng.");
            }

            _dal.Xoa(maKH.Trim());
        }
    }
}

