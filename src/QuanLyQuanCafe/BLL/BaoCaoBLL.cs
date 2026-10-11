using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _dal = new();

        public List<DoanhThuNgayDTO> ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay);
            var ds = _dal.ThongKeDoanhThu(tuNgay.Date, denNgay.Date);
            return ds.OrderBy(x => x.Ngay).ToList();
        }

        public decimal TinhTongDoanhThu(List<DoanhThuNgayDTO> ds)
        {
            return ds?.Sum(x => x.TongDoanhThu) ?? 0m;
        }

        public int TinhTongHoaDon(List<DoanhThuNgayDTO> ds)
        {
            return ds?.Sum(x => x.SoHoaDon) ?? 0;
        }

        public decimal TinhDoanhThuTrungBinhMoiDon(List<DoanhThuNgayDTO> ds)
        {
            int tongDon = TinhTongHoaDon(ds);
            if (tongDon == 0) return 0m;
            return TinhTongDoanhThu(ds) / tongDon;
        }

        public List<MonBanChayDTO> ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay);
            var ds = _dal.ThongKeMonBanChay(tuNgay.Date, denNgay.Date);
            return ds.OrderByDescending(x => x.SoLuongBan).ToList();
        }

        public List<MonBanChayDTO> LayTopMonBanChayToanThoiGian()
        {
            var ds = _dal.LayTopMonBanChayToanThoiGian();
            return ds.OrderByDescending(x => x.SoLuongBan).ToList();
        }

        public List<HoaDonBaoCaoDTO> LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay);
            var ds = _dal.LayDanhSachHoaDon(tuNgay.Date, denNgay.Date);
            return ds.OrderByDescending(x => x.NgayTao).ToList();
        }
    }
}

