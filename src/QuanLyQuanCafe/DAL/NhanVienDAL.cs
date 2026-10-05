using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVienDTO> LayDanhSach()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachNhanVien");
            var list = new List<NhanVienDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NhanVienDTO
                {
                    MaNV = r["MaNV"].ToString() ?? "",
                    TenNV = r["TenNV"].ToString() ?? "",
                    ChucVu = r["ChucVu"].ToString() ?? "",
                    SoDienThoai = r["SoDienThoai"].ToString() ?? "",
                    CaLamViec = r["CaLamViec"].ToString() ?? "",
                    MaQL = r["MaQL"] == DBNull.Value ? null : r["MaQL"].ToString()
                });
            }

            return list;
        }

        public void Them(NhanVienDTO nv, string matKhau)
        {
            DbHelper.ExecSP("sp_ThemNhanVien",
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.TenNV),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai),
                new SqlParameter("@CaLamViec", nv.CaLamViec),
                new SqlParameter("@MatKhau", matKhau),
                DbParam.Tao("@MaQL", nv.MaQL));
        }

        public void Sua(NhanVienDTO nv)
        {
            DbHelper.ExecSP("sp_SuaNhanVien",
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.TenNV),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai),
                new SqlParameter("@CaLamViec", nv.CaLamViec),
                DbParam.Tao("@MaQL", nv.MaQL));
        }

        public void DatLaiMatKhau(string maNV, string matKhauMoi)
        {
            DbHelper.ExecSP("sp_DatLaiMatKhau",
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MatKhauMoi", matKhauMoi));
        }
    }
}
