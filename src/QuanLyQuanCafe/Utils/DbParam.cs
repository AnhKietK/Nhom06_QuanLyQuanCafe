using Microsoft.Data.SqlClient;

namespace QuanLyQuanCafe.Utils
{
    public static class DbParam
    {
        public static SqlParameter Tao(string ten, object? giaTri)
        {
            if (giaTri is null || (giaTri is string s && string.IsNullOrWhiteSpace(s)))
                return new SqlParameter(ten, DBNull.Value);

            return new SqlParameter(ten, giaTri);
        }
    }
}

