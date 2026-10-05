using System.Text.RegularExpressions;

namespace QuanLyQuanCafe.Utils
{
    public static class ValidationHelper
    {
        public static void BatBuocNhap(string? giaTri, string tenTruong)
        {
            if (string.IsNullOrWhiteSpace(giaTri))
                throw new ArgumentException($"{tenTruong} không được để trống.");
        }

        public static void BatBuocSdt(string? sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt) || !Regex.IsMatch(sdt, @"^0\d{9}$"))
                throw new ArgumentException("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng 0.");
        }

        public static void BatBuocMatKhau(string? mk)
        {
            if (string.IsNullOrEmpty(mk) || mk.Length < 6)
                throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự.");
        }

        public static void BatBuocSoDuong(decimal giaTri, string tenTruong)
        {
            if (giaTri <= 0)
                throw new ArgumentException($"{tenTruong} phải lớn hơn 0.");
        }

        public static void BatBuocKhoangNgay(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
                throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
        }

        public static void BatBuocTienTo(string? ma, string tienTo, string tenTruong)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                !ma.StartsWith(tienTo, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    $"{tenTruong} phải bắt đầu bằng {tienTo} (ví dụ {tienTo}001).");
        }
    }
}

