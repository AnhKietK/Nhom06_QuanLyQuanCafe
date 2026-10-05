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

        /// <summary>
        /// Đổi mật khẩu: kiểm tra đầu vào rồi gọi DAL.
        /// </summary>
        public void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhan)
        {
            ValidationHelper.BatBuocNhap(matKhauCu, "Mật khẩu cũ");
            ValidationHelper.BatBuocMatKhau(matKhauMoi);

            if (matKhauMoi == matKhauCu)
                throw new ArgumentException("Mật khẩu mới phải khác mật khẩu cũ.");

            if (xacNhan != matKhauMoi)
                throw new ArgumentException("Mật khẩu xác nhận không khớp.");

            _dal.DoiMatKhau(CurrentUser.MaNV, matKhauCu, matKhauMoi);
        }
    }
}
