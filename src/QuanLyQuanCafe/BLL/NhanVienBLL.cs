using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _dal = new();
        private static readonly string[] ChucVuHopLe = { "Quản lý", "Phục vụ", "Thu ngân", "Thủ kho", "Kế toán" };

        public List<NhanVienDTO> LayDanhSach()
        {
            return _dal.LayDanhSach();
        }

        public void Them(NhanVienDTO nv, string matKhau)
        {
            nv.MaNV = nv.MaNV.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(nv.MaNV, "NV", "Mã nhân viên");
            ValidationHelper.BatBuocNhap(nv.TenNV, "Tên nhân viên");

            if (!ChucVuHopLe.Contains(nv.ChucVu?.Trim()))
                throw new ArgumentException("Chức vụ không hợp lệ. Chỉ chấp nhận: Quản lý, Phục vụ, Thu ngân, Thủ kho, Kế toán.");

            ValidationHelper.BatBuocSdt(nv.SoDienThoai);
            ValidationHelper.BatBuocNhap(nv.CaLamViec, "Ca làm việc");
            ValidationHelper.BatBuocMatKhau(matKhau);

            if (!string.IsNullOrWhiteSpace(nv.MaQL) && string.Equals(nv.MaQL.Trim(), nv.MaNV, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Quản lý trực tiếp không thể là chính nhân viên đó.");

            _dal.Them(nv, matKhau);
        }

        public void Sua(NhanVienDTO nv)
        {
            nv.MaNV = nv.MaNV.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(nv.MaNV, "NV", "Mã nhân viên");
            ValidationHelper.BatBuocNhap(nv.TenNV, "Tên nhân viên");

            if (!ChucVuHopLe.Contains(nv.ChucVu?.Trim()))
                throw new ArgumentException("Chức vụ không hợp lệ. Chỉ chấp nhận: Quản lý, Phục vụ, Thu ngân, Thủ kho, Kế toán.");

            ValidationHelper.BatBuocSdt(nv.SoDienThoai);
            ValidationHelper.BatBuocNhap(nv.CaLamViec, "Ca làm việc");

            if (!string.IsNullOrWhiteSpace(nv.MaQL) && string.Equals(nv.MaQL.Trim(), nv.MaNV, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Quản lý trực tiếp không thể là chính nhân viên đó.");

            // Không cho Quản lý tự đổi chức vụ của chính mình sang chức vụ khác Quản lý
            if (string.Equals(nv.MaNV, CurrentUser.MaNV, StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(nv.ChucVu?.Trim(), "Quản lý", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Không thể tự đổi chức vụ của chính mình.");
            }

            _dal.Sua(nv);
        }

        public void DatLaiMatKhau(string maNV, string matKhauMoi)
        {
            ValidationHelper.BatBuocNhap(maNV, "Mã nhân viên");
            ValidationHelper.BatBuocMatKhau(matKhauMoi);

            _dal.DatLaiMatKhau(maNV.Trim().ToUpper(), matKhauMoi);
        }

        public string GoiYMaMoi(List<NhanVienDTO> ds)
        {
            int maxSo = 0;
            foreach (var nv in ds)
            {
                if (nv.MaNV.StartsWith("NV", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(nv.MaNV.Substring(2), out int so))
                {
                    if (so > maxSo) maxSo = so;
                }
            }
            return $"NV{(maxSo + 1):D3}";
        }
    }
}
