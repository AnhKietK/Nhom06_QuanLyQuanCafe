using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class ThucUongBLL
    {
        private readonly ThucUongDAL _dal = new();

        public List<ThucUongQuanLyDTO> LayDanhSach(string? maLoaiTU = null)
        {
            return _dal.LayDanhSach(maLoaiTU);
        }

        public List<LoaiThucUongDTO> LayDanhSachLoai()
        {
            return _dal.LayDanhSachLoai();
        }

        public void Them(ThucUongQuanLyDTO tu)
        {
            if (tu == null)
                throw new ArgumentNullException(nameof(tu));

            tu.MaThucUong = (tu.MaThucUong ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(tu.MaThucUong, "TU", "Mã thức uống");
            ValidationHelper.BatBuocNhap(tu.TenThucUong, "Tên thức uống");
            ValidationHelper.BatBuocSoDuong(tu.DonGiaBan, "Đơn giá");

            if (string.IsNullOrWhiteSpace(tu.MaLoaiTU))
                throw new ArgumentException("Vui lòng chọn loại thức uống.");

            var dsHienTai = _dal.LayDanhSach();
            if (dsHienTai.Any(x => string.Equals(x.MaThucUong, tu.MaThucUong, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Mã thức uống đã tồn tại.");

            _dal.Them(tu);
        }

        public void Sua(ThucUongQuanLyDTO tu)
        {
            if (tu == null)
                throw new ArgumentNullException(nameof(tu));

            tu.MaThucUong = (tu.MaThucUong ?? "").Trim().ToUpper();
            ValidationHelper.BatBuocTienTo(tu.MaThucUong, "TU", "Mã thức uống");
            ValidationHelper.BatBuocNhap(tu.TenThucUong, "Tên thức uống");
            ValidationHelper.BatBuocSoDuong(tu.DonGiaBan, "Đơn giá");

            if (string.IsNullOrWhiteSpace(tu.MaLoaiTU))
                throw new ArgumentException("Vui lòng chọn loại thức uống.");

            _dal.Sua(tu);
        }

        public void Xoa(string maThucUong)
        {
            ValidationHelper.BatBuocNhap(maThucUong, "Mã thức uống");
            _dal.Xoa(maThucUong.Trim().ToUpper());
        }

        public string GoiYMaMoi(List<ThucUongQuanLyDTO> ds)
        {
            int maxSo = 0;
            if (ds != null)
            {
                foreach (var tu in ds)
                {
                    if (tu.MaThucUong.StartsWith("TU", StringComparison.OrdinalIgnoreCase) &&
                        int.TryParse(tu.MaThucUong.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }
            }

            return $"TU{(maxSo + 1):D2}";
        }
    }
}

