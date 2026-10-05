using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class BanDAL
    {
        #region Quản lý Bàn

        public List<BanDTO> LayDanhSachBan()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachBan");
            var list = new List<BanDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new BanDTO
                {
                    MaBan = r["MaBan"].ToString() ?? "",
                    SoBan = Convert.ToInt32(r["SoBan"]),
                    SoChoNgoi = Convert.ToInt32(r["SoChoNgoi"]),
                    TrangThai = r["TrangThai"].ToString() ?? "",
                    MaViTri = r["MaViTri"].ToString() ?? "",
                    TenViTri = r["TenViTri"].ToString() ?? ""
                });
            }

            return list;
        }

        public void ThemBan(BanDTO ban)
        {
            DbHelper.ExecSP("sp_ThemBan",
                new SqlParameter("@MaBan", ban.MaBan),
                new SqlParameter("@SoBan", ban.SoBan),
                new SqlParameter("@SoChoNgoi", ban.SoChoNgoi),
                new SqlParameter("@MaViTri", ban.MaViTri));
        }

        public void SuaBan(BanDTO ban)
        {
            DbHelper.ExecSP("sp_SuaBan",
                new SqlParameter("@MaBan", ban.MaBan),
                new SqlParameter("@SoBan", ban.SoBan),
                new SqlParameter("@SoChoNgoi", ban.SoChoNgoi),
                new SqlParameter("@MaViTri", ban.MaViTri),
                new SqlParameter("@TrangThai", DBNull.Value)); // Luôn truyền @TrangThai = NULL
        }

        public void XoaBan(string maBan)
        {
            DbHelper.ExecSP("sp_XoaBan",
                new SqlParameter("@MaBan", maBan));
        }

        #endregion

        #region Quản lý Vị trí / Khu vực

        public List<ViTriBanDTO> LayDanhSachViTri()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachViTriBan");
            var list = new List<ViTriBanDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ViTriBanDTO
                {
                    MaViTri = r["MaViTri"].ToString() ?? "",
                    TenViTri = r["TenViTri"].ToString() ?? "",
                    MoTa = r["MoTa"] == DBNull.Value ? null : r["MoTa"].ToString()
                });
            }

            return list;
        }

        public void ThemViTri(ViTriBanDTO vt)
        {
            DbHelper.ExecSP("sp_ThemViTriBan",
                new SqlParameter("@MaViTri", vt.MaViTri),
                new SqlParameter("@TenViTri", vt.TenViTri),
                DbParam.Tao("@MoTa", vt.MoTa));
        }

        public void SuaViTri(ViTriBanDTO vt)
        {
            DbHelper.ExecSP("sp_SuaViTriBan",
                new SqlParameter("@MaViTri", vt.MaViTri),
                new SqlParameter("@TenViTri", vt.TenViTri),
                DbParam.Tao("@MoTa", vt.MoTa));
        }

        public void XoaViTri(string maViTri)
        {
            DbHelper.ExecSP("sp_XoaViTriBan",
                new SqlParameter("@MaViTri", maViTri));
        }

        #endregion
    }
}
