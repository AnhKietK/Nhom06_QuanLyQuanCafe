using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class BanBLL
    {
        private readonly BanDAL _dal = new();

        #region Nghiệp vụ Bàn

        public List<BanDTO> LayDanhSachBan()
        {
            return _dal.LayDanhSachBan();
        }

        public void ThemBan(BanDTO ban)
        {
            ban.MaBan = ban.MaBan.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(ban.MaBan, "B", "Mã bàn");
            ValidationHelper.BatBuocSoDuong(ban.SoBan, "Số bàn");
            ValidationHelper.BatBuocSoDuong(ban.SoChoNgoi, "Số chỗ ngồi");
            ValidationHelper.BatBuocNhap(ban.MaViTri, "Khu vực");

            _dal.ThemBan(ban);
        }

        public void SuaBan(BanDTO ban)
        {
            ban.MaBan = ban.MaBan.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(ban.MaBan, "B", "Mã bàn");
            ValidationHelper.BatBuocSoDuong(ban.SoBan, "Số bàn");
            ValidationHelper.BatBuocSoDuong(ban.SoChoNgoi, "Số chỗ ngồi");
            ValidationHelper.BatBuocNhap(ban.MaViTri, "Khu vực");

            // Không cho sửa bàn có trạng thái khác TRONG
            var banHienTai = _dal.LayDanhSachBan().FirstOrDefault(b => b.MaBan == ban.MaBan);
            if (banHienTai != null && !string.Equals(banHienTai.TrangThai, "TRONG", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Bàn đang có khách hoặc đã được đặt, không thể thay đổi.");
            }

            _dal.SuaBan(ban);
        }

        public void XoaBan(string maBan)
        {
            maBan = maBan.Trim().ToUpper();
            ValidationHelper.BatBuocNhap(maBan, "Mã bàn");

            // Không cho xóa bàn có trạng thái khác TRONG
            var banHienTai = _dal.LayDanhSachBan().FirstOrDefault(b => b.MaBan == maBan);
            if (banHienTai != null && !string.Equals(banHienTai.TrangThai, "TRONG", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Bàn đang có khách hoặc đã được đặt, không thể thay đổi.");
            }

            _dal.XoaBan(maBan);
        }

        public string GoiYMaBan(List<BanDTO> ds)
        {
            int maxSo = 0;
            foreach (var b in ds)
            {
                if (b.MaBan.StartsWith("B", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(b.MaBan.Substring(1), out int so))
                {
                    if (so > maxSo) maxSo = so;
                }
                if (b.SoBan > maxSo) maxSo = b.SoBan;
            }
            return $"B{(maxSo + 1):D2}";
        }

        #endregion

        #region Nghiệp vụ Khu vực / Vị trí

        public List<ViTriBanDTO> LayDanhSachViTri()
        {
            return _dal.LayDanhSachViTri();
        }

        public void ThemViTri(ViTriBanDTO vt)
        {
            vt.MaViTri = vt.MaViTri.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(vt.MaViTri, "VT", "Mã khu vực");
            ValidationHelper.BatBuocNhap(vt.TenViTri, "Tên khu vực");

            _dal.ThemViTri(vt);
        }

        public void SuaViTri(ViTriBanDTO vt)
        {
            vt.MaViTri = vt.MaViTri.Trim().ToUpper();

            ValidationHelper.BatBuocTienTo(vt.MaViTri, "VT", "Mã khu vực");
            ValidationHelper.BatBuocNhap(vt.TenViTri, "Tên khu vực");

            _dal.SuaViTri(vt);
        }

        public void XoaViTri(string maViTri)
        {
            maViTri = maViTri.Trim().ToUpper();
            ValidationHelper.BatBuocNhap(maViTri, "Mã khu vực");

            _dal.XoaViTri(maViTri);
        }

        public string GoiYMaViTri(List<ViTriBanDTO> ds)
        {
            int maxSo = 0;
            foreach (var vt in ds)
            {
                if (vt.MaViTri.StartsWith("VT", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(vt.MaViTri.Substring(2), out int so))
                {
                    if (so > maxSo) maxSo = so;
                }
            }
            return $"VT{(maxSo + 1):D2}";
        }

        #endregion
    }
}
