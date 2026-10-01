using Microsoft.Data.SqlClient;

namespace QuanLyQuanCafe.DAL
{
    public static class CustomSqlExceptionHandler
    {
        private static readonly int[] ConnErrors = { -2, 2, 53, 64, 121, 233, 4060, 10053, 10054, 10060 };

        public static bool IsConnectionError(int number) => Array.IndexOf(ConnErrors, number) >= 0;

        public static string Translate(SqlException ex)
        {
            if (IsConnectionError(ex.Number))
                return "Mất kết nối tới máy chủ CSDL SQL Server. Vui lòng kiểm tra và thử lại.";

            return ex.Number switch
            {
                50000 => ex.Message,   // lỗi nghiệp vụ từ THROW/RAISERROR trong SP và trigger
                2627 or 2601 => "Dữ liệu hoặc mã này đã tồn tại trong hệ thống.",
                547 => "Dữ liệu vi phạm ràng buộc hoặc đang được sử dụng ở bảng khác (không thể xóa).",
                229 or 230 or 262 => "Bạn không có quyền thực hiện chức năng này.",
                18456 => "Sai tài khoản SQL trong cấu hình kết nối (App.config).",
                _ => "Đã xảy ra lỗi CSDL. Vui lòng thử lại hoặc liên hệ quản trị viên."
            };
        }
    }

    public class DbException : Exception
    {
        public int SqlNumber { get; }
        public bool IsConnectionError { get; }

        public DbException(string message, SqlException inner) : base(message, inner)
        {
            SqlNumber = inner.Number;
            IsConnectionError = CustomSqlExceptionHandler.IsConnectionError(inner.Number);
        }
    }
}