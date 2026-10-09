using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class NhaCungCapDAL
    {
        public List<NhaCungCapDTO> LayDanhSach()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachNCC");
            var list = new List<NhaCungCapDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NhaCungCapDTO
                {
                    MaNCC = r["MaNCC"]?.ToString() ?? "",
                    TenNCC = r["TenNCC"]?.ToString() ?? "",
                    DiaChi = r["DiaChi"] == DBNull.Value ? null : r["DiaChi"].ToString(),
                    SoDienThoai = r["SoDienThoai"] == DBNull.Value ? null : r["SoDienThoai"].ToString(),
                    Email = r["Email"] == DBNull.Value ? null : r["Email"].ToString()
                });
            }

            return list;
        }

        public void Them(NhaCungCapDTO ncc)
        {
            DbHelper.ExecSP("sp_ThemNCC",
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                DbParam.Tao("@DiaChi", ncc.DiaChi),
                DbParam.Tao("@SoDienThoai", ncc.SoDienThoai),
                DbParam.Tao("@Email", ncc.Email));
        }

        public void Sua(NhaCungCapDTO ncc)
        {
            DbHelper.ExecSP("sp_SuaNCC",
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                DbParam.Tao("@DiaChi", ncc.DiaChi),
                DbParam.Tao("@SoDienThoai", ncc.SoDienThoai),
                DbParam.Tao("@Email", ncc.Email));
        }

        public void Xoa(string maNCC)
        {
            DbHelper.ExecSP("sp_XoaNCC",
                new SqlParameter("@MaNCC", maNCC));
        }
    }
}

