using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class CongThucBLL
    {
        private readonly CongThucDAL _congThucDal = new();
        private readonly ThucUongDAL _thucUongDal = new();
        private readonly NguyenLieuDAL _nguyenLieuDal = new();

        public List<ThucUongQuanLyDTO> LayDanhSachThucUong(string? maLoaiTU = null)
        {
            return _thucUongDal.LayDanhSach(maLoaiTU);
        }

        public List<LoaiThucUongDTO> LayDanhSachLoaiThucUong()
        {
            return _thucUongDal.LayDanhSachLoai();
        }

        public List<NguyenLieuDTO> LayDanhSachNguyenLieu()
        {
            return _nguyenLieuDal.LayDanhSach();
        }

        public List<CongThucDTO> LayCongThuc(string maThucUong)
        {
            ValidationHelper.BatBuocNhap(maThucUong, "Mã thức uống");
            return _congThucDal.LayCongThuc(maThucUong.Trim().ToUpper());
        }

        public void LuuDong(string maThucUong, string maNL, decimal soLuong)
        {
            ValidationHelper.BatBuocNhap(maThucUong, "Mã thức uống");
            ValidationHelper.BatBuocNhap(maNL, "Mã nguyên liệu");
            ValidationHelper.BatBuocSoDuong(soLuong, "Số lượng quy định");

            _congThucDal.LuuDong(maThucUong.Trim().ToUpper(), maNL.Trim().ToUpper(), soLuong);
        }

        public void XoaDong(string maThucUong, string maNL)
        {
            ValidationHelper.BatBuocNhap(maThucUong, "Mã thức uống");
            ValidationHelper.BatBuocNhap(maNL, "Mã nguyên liệu");

            _congThucDal.XoaDong(maThucUong.Trim().ToUpper(), maNL.Trim().ToUpper());
        }
    }
}

