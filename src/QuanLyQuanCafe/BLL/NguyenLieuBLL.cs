using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class NguyenLieuBLL
    {
        private readonly NguyenLieuDAL _dal = new();

        public List<NguyenLieuDTO> LayDanhSach()
        {
            return _dal.LayDanhSach();
        }

        public List<LoaiNguyenLieuDTO> LayDanhSachLoai()
        {
            return _dal.LayDanhSachLoai();
        }

        public List<NguyenLieuDTO> LayCanhBao()
        {
            var dsCanhBao = _dal.LayCanhBao();
            var dsTatCa = _dal.LayDanhSach();

            var mapTatCa = dsTatCa.ToDictionary(x => x.MaNL, StringComparer.OrdinalIgnoreCase);
            foreach (var item in dsCanhBao)
            {
                if (mapTatCa.TryGetValue(item.MaNL, out var full))
                {
                    item.DonViTinh = full.DonViTinh;
                    item.MaLoaiNL = full.MaLoaiNL;
                }
            }

            return dsCanhBao;
        }

        public void Them(NguyenLieuDTO nl)
        {
            if (nl == null)
                throw new ArgumentNullException(nameof(nl));

            nl.MaNL = (nl.MaNL ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(nl.MaNL, "NL", "Mã nguyên liệu");
            ValidationHelper.BatBuocNhap(nl.TenNL, "Tên nguyên liệu");

            if (string.IsNullOrWhiteSpace(nl.MaLoaiNL))
                throw new ArgumentException("Vui lòng chọn loại nguyên liệu.");

            if (nl.MucToiThieu < 0)
                throw new ArgumentException("Mức tối thiểu phải lớn hơn hoặc bằng 0.");

            var dsHienTai = _dal.LayDanhSach();
            if (dsHienTai.Any(x => string.Equals(x.MaNL, nl.MaNL, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Mã nguyên liệu đã tồn tại.");

            _dal.Them(nl);
        }

        public void Sua(NguyenLieuDTO nl)
        {
            if (nl == null)
                throw new ArgumentNullException(nameof(nl));

            nl.MaNL = (nl.MaNL ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(nl.MaNL, "NL", "Mã nguyên liệu");
            ValidationHelper.BatBuocNhap(nl.TenNL, "Tên nguyên liệu");

            if (string.IsNullOrWhiteSpace(nl.MaLoaiNL))
                throw new ArgumentException("Vui lòng chọn loại nguyên liệu.");

            if (nl.MucToiThieu < 0)
                throw new ArgumentException("Mức tối thiểu phải lớn hơn hoặc bằng 0.");

            _dal.Sua(nl);
        }

        public void Xoa(string maNL)
        {
            ValidationHelper.BatBuocNhap(maNL, "Mã nguyên liệu");
            _dal.Xoa(maNL.Trim().ToUpper());
        }

        public string GoiYMaMoi(List<NguyenLieuDTO> ds)
        {
            int maxSo = 0;
            if (ds != null)
            {
                foreach (var nl in ds)
                {
                    if (nl.MaNL.StartsWith("NL", StringComparison.OrdinalIgnoreCase) &&
                        int.TryParse(nl.MaNL.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }
            }

            return $"NL{(maxSo + 1):D2}";
        }
    }
}

