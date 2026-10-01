using System.Configuration;

namespace QuanLyQuanCafe.Utils
{
    public static class AppConfig
    {
        public static string Get(string name) =>
            ConfigurationManager.ConnectionStrings[name]?.ConnectionString
            ?? throw new InvalidOperationException($"Thiếu connection string '{name}' trong App.config.");

        // chọn chuỗi kết nối theo chức vụ
        public static string ConnectionForRole(string chucVu) => chucVu switch
        {
            "Quản lý" => Get("QuanLyConn"),
            "Phục vụ" => Get("PhucVuConn"),
            "Thu ngân" => Get("PhucVuConn"),
            "Thủ kho" => Get("ThuKhoConn"),
            "Kế toán" => Get("KeToanConn"),
            _ => throw new InvalidOperationException("Chức vụ không hợp lệ.")
        };
    }
}