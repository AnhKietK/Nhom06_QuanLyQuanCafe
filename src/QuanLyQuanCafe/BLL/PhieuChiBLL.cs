using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class PhieuChiBLL
    {
        private readonly PhieuChiDAL _dal = new();

        public List<NhaCungCapLookupDTO> LayDanhSachNCC()
        {
            var ds = _dal.LayDanhSachNCC();
            ds.Insert(0, new NhaCungCapLookupDTO
            {
                MaNCC = null,
                TenNCC = "(Chi phí vận hành / Không theo NCC)"
            });
            return ds;
        }

        public string LapPhieuChi(decimal soTien, string lyDo, string? maNCC)
        {
            ValidationHelper.BatBuocSoDuong(soTien, "Số tiền chi");
            ValidationHelper.BatBuocNhap(lyDo, "Lý do chi");

            string maNV = CurrentUser.MaNV;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                throw new InvalidOperationException("Phiên làm việc hết hạn hoặc chưa đăng nhập.");
            }

            string? ncc = string.IsNullOrWhiteSpace(maNCC) ? null : maNCC.Trim();
            return _dal.ChiTienNCC(soTien, lyDo.Trim(), maNV, ncc);
        }

        public List<PhieuChiDTO> LayLichSuChiTien(DateTime tuNgay, DateTime denNgay)
        {
            ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay);
            return _dal.LayDanhSachPhieuChi(tuNgay.Date, denNgay.Date);
        }
    }
}

