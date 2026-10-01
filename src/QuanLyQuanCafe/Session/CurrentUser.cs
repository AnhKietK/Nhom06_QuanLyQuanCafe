namespace QuanLyQuanCafe.Session
{
    public static class CurrentUser
    {
        public static string MaNV { get; private set; } = "";
        public static string TenNV { get; private set; } = "";
        public static string ChucVu { get; private set; } = "";
        public static string ActiveConnectionString { get; private set; } = "";
        public static bool IsLoggedIn => MaNV != "";

        public static void Set(string maNV, string tenNV, string chucVu, string conn)
        {
            MaNV = maNV; TenNV = tenNV; ChucVu = chucVu; ActiveConnectionString = conn;
        }

        public static void Clear() => Set("", "", "", "");
    }
}