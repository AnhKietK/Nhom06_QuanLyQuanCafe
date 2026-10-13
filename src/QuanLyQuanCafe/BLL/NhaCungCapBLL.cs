using System.Text.RegularExpressions;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class NhaCungCapBLL
    {
        private readonly NhaCungCapDAL _dal = new();

        public List<NhaCungCapDTO> LayDanhSach()
        {
            return _dal.LayDanhSach();
        }

        public void Them(NhaCungCapDTO ncc)
        {
            if (ncc == null)
                throw new ArgumentNullException(nameof(ncc));

            ncc.MaNCC = (ncc.MaNCC ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(ncc.MaNCC, "NCC", "Mã nhà cung cấp");
            ValidationHelper.BatBuocNhap(ncc.TenNCC, "Tên nhà cung cấp");

            if (!string.IsNullOrWhiteSpace(ncc.SoDienThoai))
            {
                ValidationHelper.BatBuocSdt(ncc.SoDienThoai);
            }

            if (!string.IsNullOrWhiteSpace(ncc.Email))
            {
                if (!Regex.IsMatch(ncc.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("Email không hợp lệ.");
            }

            var dsHienTai = _dal.LayDanhSach();
            if (dsHienTai.Any(x => string.Equals(x.MaNCC, ncc.MaNCC, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Mã nhà cung cấp đã tồn tại.");

            _dal.Them(ncc);
        }

        public void Sua(NhaCungCapDTO ncc)
        {
            if (ncc == null)
                throw new ArgumentNullException(nameof(ncc));

            ncc.MaNCC = (ncc.MaNCC ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(ncc.MaNCC, "NCC", "Mã nhà cung cấp");
            ValidationHelper.BatBuocNhap(ncc.TenNCC, "Tên nhà cung cấp");

            if (!string.IsNullOrWhiteSpace(ncc.SoDienThoai))
            {
                ValidationHelper.BatBuocSdt(ncc.SoDienThoai);
            }

            if (!string.IsNullOrWhiteSpace(ncc.Email))
            {
                if (!Regex.IsMatch(ncc.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("Email không hợp lệ.");
            }

            _dal.Sua(ncc);
        }

        public void Xoa(string maNCC)
        {
            ValidationHelper.BatBuocNhap(maNCC, "Mã nhà cung cấp");
            _dal.Xoa(maNCC.Trim().ToUpper());
        }

        public string GoiYMaMoi(List<NhaCungCapDTO> ds)
        {
            int maxSo = 0;
            if (ds != null)
            {
                foreach (var ncc in ds)
                {
                    if (ncc.MaNCC.StartsWith("NCC", StringComparison.OrdinalIgnoreCase) &&
                        int.TryParse(ncc.MaNCC.Substring(3), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }
            }

            return $"NCC{(maxSo + 1):D2}";
        }
    }
}

