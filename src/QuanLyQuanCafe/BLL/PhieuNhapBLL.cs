using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class PhieuNhapBLL
    {
        private readonly PhieuNhapDAL _dal = new();
        private readonly NhaCungCapDAL _nccDal = new();
        private readonly NguyenLieuDAL _nlDal = new();

        public string LuuPhieu(string maNCC, string? ghiChu, List<ChiTietPhieuNhapDTO> dong)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
                throw new ArgumentException("Vui lòng chọn nhà cung cấp.");

            if (dong == null || dong.Count == 0)
                throw new InvalidOperationException("Phiếu nhập phải có ít nhất một nguyên liệu.");

            var seenMaNL = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            DateTime today = DateTime.Today;

            foreach (var d in dong)
            {
                string tenHienThi = !string.IsNullOrWhiteSpace(d.TenNL) ? d.TenNL : d.MaNL;

                ValidationHelper.BatBuocNhap(d.MaNL, "Mã nguyên liệu");
                ValidationHelper.BatBuocSoDuong(d.SoLuongNhap, $"Số lượng nhập của {tenHienThi}");
                ValidationHelper.BatBuocSoDuong(d.DonGiaNhap, $"Đơn giá nhập của {tenHienThi}");

                if (d.HanSuDung.HasValue && d.HanSuDung.Value.Date < today)
                {
                    throw new ArgumentException($"Hạn sử dụng của {tenHienThi} đã quá hạn.");
                }

                if (!seenMaNL.Add(d.MaNL))
                {
                    throw new InvalidOperationException($"Nguyên liệu {tenHienThi} đã có trong phiếu, hãy sửa số lượng ở dòng đó.");
                }
            }

            string maNV = CurrentUser.MaNV;
            if (string.IsNullOrWhiteSpace(maNV))
                throw new InvalidOperationException("Chưa đăng nhập. Không thể tạo phiếu nhập.");

            return _dal.LuuPhieuTronGoi(maNCC, maNV, ghiChu, dong);
        }

        public List<PhieuNhapDTO> LayLichSu(DateTime tuNgay, DateTime denNgay)
        {
            ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay);

            var ds = _dal.LayLichSu(tuNgay, denNgay);

            // Điền TenNCC bằng cách đối chiếu MaNCC với danh sách nhà cung cấp của TV3
            var dsNCC = _nccDal.LayDanhSach().ToDictionary(x => x.MaNCC, x => x.TenNCC, StringComparer.OrdinalIgnoreCase);
            foreach (var pn in ds)
            {
                if (dsNCC.TryGetValue(pn.MaNCC, out string? tenNCC))
                    pn.TenNCC = tenNCC;
                else
                    pn.TenNCC = pn.MaNCC;
            }

            return ds.OrderByDescending(x => x.NgayNhap).ThenByDescending(x => x.MaPN).ToList();
        }

        public List<ChiTietPhieuNhapDTO> LayChiTiet(string maPN)
        {
            ValidationHelper.BatBuocNhap(maPN, "Mã phiếu nhập");
            return _dal.LayChiTiet(maPN);
        }

        public List<NhaCungCapDTO> LayDanhSachNhaCungCap()
        {
            return _nccDal.LayDanhSach();
        }

        public List<NguyenLieuDTO> LayDanhSachNguyenLieu()
        {
            return _nlDal.LayDanhSach();
        }
    }
}

