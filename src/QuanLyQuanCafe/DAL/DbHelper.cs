using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.Session;

namespace QuanLyQuanCafe.DAL
{
    public static class DbHelper
    {
        // Lõi chung: mở kết nối, chạy lệnh, dịch SqlException thành DbException
        private static T Run<T>(string connStr, string text, CommandType type,
                                SqlParameter[] p, Func<SqlCommand, T> action)
        {
            if (string.IsNullOrEmpty(connStr))
                throw new InvalidOperationException("Chưa đăng nhập.");
            try
            {
                using var cn = new SqlConnection(connStr);
                using var cmd = new SqlCommand(text, cn) { CommandType = type, CommandTimeout = 15 };
                if (p != null) cmd.Parameters.AddRange(p);
                cn.Open();
                return action(cmd);
            }
            catch (SqlException ex)
            {
                throw new DbException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        private static DataTable Fill(SqlCommand cmd)
        {
            var dt = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }

        private static string Args(SqlParameter[] p) =>
            string.Join(",", p.Select(x => x.ParameterName));

        // ---- Stored Procedure ----
        public static DataTable ExecSP(string sp, params SqlParameter[] p) =>
            ExecSPWith(CurrentUser.ActiveConnectionString, sp, p);

        // Dùng cho đăng nhập (AuthConn) khi chưa có phiên làm việc
        public static DataTable ExecSPWith(string connStr, string sp, params SqlParameter[] p) =>
            Run(connStr, sp, CommandType.StoredProcedure, p, Fill);

        public static int ExecSPNonQuery(string sp, params SqlParameter[] p) =>
            Run(CurrentUser.ActiveConnectionString, sp, CommandType.StoredProcedure, p,
                cmd => cmd.ExecuteNonQuery());   

        // ---- Function ----
        public static object? ExecScalarFn(string fn, params SqlParameter[] p) =>
            Run(CurrentUser.ActiveConnectionString, $"SELECT dbo.{fn}({Args(p)})",
                CommandType.Text, p, cmd => cmd.ExecuteScalar());

        // Table-valued function: fn_MonBanChayNhat, fn_LichSuMuaHang
        public static DataTable ExecTableFn(string fn, params SqlParameter[] p) =>
            Run(CurrentUser.ActiveConnectionString, $"SELECT * FROM dbo.{fn}({Args(p)})",
                CommandType.Text, p, Fill);

        // ---- View ----  (giá trị lọc đi qua tham số, không nối chuỗi)
        public static DataTable SelectView(string view, string? where = null, params SqlParameter[] p) =>
            Run(CurrentUser.ActiveConnectionString,
                $"SELECT * FROM {view}" + (string.IsNullOrWhiteSpace(where) ? "" : " WHERE " + where),
                CommandType.Text, p, Fill);
    }
}