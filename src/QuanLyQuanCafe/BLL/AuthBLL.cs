using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.BLL
{
    public class AuthBLL
    {
        private readonly AuthDAL _dal = new();

        /// <summary>
        /// Đăng nhập: kiểm tra đầu vào, gọi DAL, thiết lập phiên làm việc.
        /// </summary>
        public NhanVienDTO DangNhap(string sdt, string matKhau)
        {
            ValidationHelper.BatBuocSdt(sdt);
            ValidationHelper.BatBuocNhap(matKhau, "Mật khẩu");

            NhanVienDTO? nv = _dal.DangNhap(sdt, matKhau);
            if (nv == null)
                throw new InvalidOperationException("Số điện thoại hoặc mật khẩu không chính xác.");

            string conn = AppConfig.ConnectionForRole(nv.ChucVu);
            CurrentUser.Set(nv.MaNV, nv.TenNV, nv.ChucVu, conn);

            return nv;
        }

        /// <summary>
        /// Đăng xuất: xóa phiên làm việc hiện tại.
        /// </summary>
        public void DangXuat()
        {
            CurrentUser.Clear();
        }
    }
}
