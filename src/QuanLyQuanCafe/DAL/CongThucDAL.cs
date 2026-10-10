using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAL
{
    public class CongThucDAL
    {
        public List<CongThucDTO> LayCongThuc(string maThucUong)
        {
            DataTable dt = DbHelper.ExecSP("sp_LayCongThuc",
                new SqlParameter("@MaThucUong", maThucUong));

            var list = new List<CongThucDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new CongThucDTO
                {
                    MaThucUong = r["MaThucUong"]?.ToString() ?? "",
                    MaNL = r["MaNL"]?.ToString() ?? "",
                    TenNL = r["TenNL"]?.ToString() ?? "",
                    DonViTinh = r["DonViTinh"]?.ToString() ?? "",
                    SoLuongQuyDinh = r["SoLuongQuyDinh"] == DBNull.Value ? 0m : Convert.ToDecimal(r["SoLuongQuyDinh"])
                });
            }

            return list;
        }

        public void LuuDong(string maThucUong, string maNL, decimal soLuong)
        {
            DbHelper.ExecSP("sp_LuuCongThuc",
                new SqlParameter("@MaThucUong", maThucUong),
                new SqlParameter("@MaNL", maNL),
                new SqlParameter("@SoLuongQuyDinh", SqlDbType.Decimal) { Precision = 12, Scale = 3, Value = soLuong });
        }

        public void XoaDong(string maThucUong, string maNL)
        {
            DbHelper.ExecSP("sp_LuuCongThuc",
                new SqlParameter("@MaThucUong", maThucUong),
                new SqlParameter("@MaNL", maNL),
                new SqlParameter("@SoLuongQuyDinh", SqlDbType.Decimal) { Precision = 12, Scale = 3, Value = 0m });
        }
    }
}

