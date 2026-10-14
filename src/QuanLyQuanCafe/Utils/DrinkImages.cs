namespace QuanLyQuanCafe.Utils
{
    public static class DrinkImages
    {
        public static string Folder => Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "ThucUong");

        public static string? Resolve(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            // Dùng tên file để ảnh vẫn tìm được khi CSDL lưu đường dẫn từ máy cũ.
            string name = Path.GetFileName(fileName);
            string[] candidates =
            {
                Path.Combine(Folder, name),
                Path.Combine(AppContext.BaseDirectory, "Images", name),
                Path.Combine(AppContext.BaseDirectory, "Images", "ThucUong", name),
                Path.Combine(AppContext.BaseDirectory, "Resources", "Images", name),
                Path.IsPathRooted(fileName) ? fileName : Path.Combine(AppContext.BaseDirectory, fileName)
            };
            return candidates.FirstOrDefault(File.Exists);
        }
    }
}
