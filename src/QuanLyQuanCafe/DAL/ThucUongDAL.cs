using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class ThucUongDAL
    {
        public List<ThucUongQuanLyDTO> LayDanhSach(string? maLoaiTU = null)
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachThucUongTheoLoai",
                DbParam.Tao("@MaLoaiTU", maLoaiTU));

            var list = new List<ThucUongQuanLyDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ThucUongQuanLyDTO
                {
                    MaThucUong = r["MaThucUong"]?.ToString() ?? "",
                    TenThucUong = r["TenThucUong"]?.ToString() ?? "",
                    DonGiaBan = r["DonGiaBan"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DonGiaBan"]),
                    HinhAnh = r["HinhAnh"] == DBNull.Value ? null : r["HinhAnh"].ToString(),
                    MaLoaiTU = r["MaLoaiTU"]?.ToString() ?? "",
                    TenLoaiTU = r["TenLoaiTU"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public List<LoaiThucUongDTO> LayDanhSachLoai()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachLoaiThucUong");

            var list = new List<LoaiThucUongDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new LoaiThucUongDTO
                {
                    MaLoaiTU = r["MaLoaiTU"]?.ToString() ?? "",
                    TenLoai = r["TenLoai"]?.ToString() ?? "",
                    MoTa = r["MoTa"] == DBNull.Value ? null : r["MoTa"].ToString()
                });
            }

            return list;
        }

        public void Them(ThucUongQuanLyDTO tu)
        {
            DbHelper.ExecSP("sp_ThemThucUong",
                new SqlParameter("@MaThucUong", tu.MaThucUong),
                new SqlParameter("@TenThucUong", tu.TenThucUong),
                new SqlParameter("@DonGiaBan", SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = tu.DonGiaBan },
                new SqlParameter("@MaLoaiTU", tu.MaLoaiTU),
                DbParam.Tao("@HinhAnh", tu.HinhAnh));
        }

        public void Sua(ThucUongQuanLyDTO tu)
        {
            DbHelper.ExecSP("sp_SuaThucUong",
                new SqlParameter("@MaThucUong", tu.MaThucUong),
                new SqlParameter("@TenThucUong", tu.TenThucUong),
                new SqlParameter("@DonGiaBan", SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = tu.DonGiaBan },
                new SqlParameter("@MaLoaiTU", tu.MaLoaiTU),
                DbParam.Tao("@HinhAnh", tu.HinhAnh));
        }

        public void Xoa(string maThucUong)
        {
            DbHelper.ExecSP("sp_XoaThucUong",
                new SqlParameter("@MaThucUong", maThucUong));
        }
    }
}

