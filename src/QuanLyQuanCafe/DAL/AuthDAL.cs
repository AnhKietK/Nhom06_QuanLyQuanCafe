using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class AuthDAL
    {
        /// <summary>
        /// Gọi sp_DangNhap bằng AuthConn (login_auth).
        /// Trả NhanVienDTO nếu đúng tài khoản, null nếu sai.
        /// </summary>
        public NhanVienDTO? DangNhap(string sdt, string matKhau)
        {
            DataTable dt = DbHelper.ExecSPWith(
                AppConfig.Get("AuthConn"),
                "sp_DangNhap",
                new SqlParameter("@SoDienThoai", sdt),
                new SqlParameter("@MatKhau", matKhau));

            if (dt.Rows.Count == 0)
                return null;

            DataRow r = dt.Rows[0];
            return new NhanVienDTO
            {
                MaNV = r["MaNV"].ToString() ?? "",
                TenNV = r["TenNV"].ToString() ?? "",
                ChucVu = r["ChucVu"].ToString() ?? ""
            };
        }

        /// <summary>
        /// Gọi sp_DoiMatKhau bằng kết nối phiên hiện tại.
        /// SP ném lỗi 50000 nếu mật khẩu cũ không đúng.
        /// </summary>
        public void DoiMatKhau(string maNV, string matKhauCu, string matKhauMoi)
        {
            DbHelper.ExecSP("sp_DoiMatKhau",
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MatKhauCu", matKhauCu),
                new SqlParameter("@MatKhauMoi", matKhauMoi));
        }
    }
}
