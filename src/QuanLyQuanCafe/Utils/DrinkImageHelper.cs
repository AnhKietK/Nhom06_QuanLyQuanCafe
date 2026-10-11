using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.Utils
{
    public static class DrinkImageHelper
    {
        private static readonly ConcurrentDictionary<string, Image?> _cache = new(StringComparer.OrdinalIgnoreCase);
        private static readonly string[] Extensions = { ".png", ".jpg", ".jpeg", ".webp", ".bmp" };

        public static Image? GetDrinkImage(ThucUongDTO? thucUong)
        {
            if (thucUong == null) return null;

            string key = string.IsNullOrWhiteSpace(thucUong.MaThucUong) ? (thucUong.TenThucUong ?? "") : thucUong.MaThucUong;
            if (string.IsNullOrWhiteSpace(key)) return null;

            return _cache.GetOrAdd(key, _ => LoadDrinkImageInternal(thucUong));
        }

        public static void ClearCache()
        {
            foreach (var kvp in _cache)
            {
                kvp.Value?.Dispose();
            }
            _cache.Clear();
        }

        private static Image? LoadDrinkImageInternal(ThucUongDTO thucUong)
        {
            try
            {
                var candidateDirs = GetCandidateDirectories();

                // 1. Kiểm tra thuộc tính HinhAnh trong database (nếu có)
                if (!string.IsNullOrWhiteSpace(thucUong.HinhAnh))
                {
                    string hinhAnh = thucUong.HinhAnh.Trim();

                    if (File.Exists(hinhAnh))
                    {
                        var img = LoadImageFromFileWithoutLock(hinhAnh);
                        if (img != null) return img;
                    }

                    foreach (var dir in candidateDirs)
                    {
                        string path1 = Path.Combine(dir, hinhAnh);
                        if (File.Exists(path1))
                        {
                            var img = LoadImageFromFileWithoutLock(path1);
                            if (img != null) return img;
                        }

                        string fileNameOnly = Path.GetFileName(hinhAnh);
                        string path2 = Path.Combine(dir, fileNameOnly);
                        if (File.Exists(path2))
                        {
                            var img = LoadImageFromFileWithoutLock(path2);
                            if (img != null) return img;
                        }
                    }
                }

                // 2. Tìm theo MaThucUong (vd: TU01.png, TU01.jpg, TU02.png...)
                if (!string.IsNullOrWhiteSpace(thucUong.MaThucUong))
                {
                    string ma = thucUong.MaThucUong.Trim();
                    foreach (var dir in candidateDirs)
                    {
                        foreach (var ext in Extensions)
                        {
                            string p = Path.Combine(dir, ma + ext);
                            if (File.Exists(p))
                            {
                                var img = LoadImageFromFileWithoutLock(p);
                                if (img != null) return img;
                            }
                        }
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private static List<string> GetCandidateDirectories()
        {
            var list = new List<string>();

            // 1. Thư mục chạy ứng dụng bin/Debug/...
            string appDir = Application.StartupPath;
            list.Add(Path.Combine(appDir, "Resources", "Images", "ThucUong"));
            list.Add(Path.Combine(appDir, "Images", "ThucUong"));
            list.Add(Path.Combine(appDir, "Resources", "ThucUong"));

            // 2. Thư mục mã nguồn dự án khi debug / develop
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string devDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\Resources\Images\ThucUong"));
                if (Directory.Exists(devDir))
                {
                    list.Add(devDir);
                }
            }
            catch
            {
                // Bỏ qua lỗi resolving path
            }

            return list.Where(Directory.Exists).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static Image? LoadImageFromFileWithoutLock(string filePath)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                using var ms = new MemoryStream(bytes);
                using var original = Image.FromStream(ms);
                return new Bitmap(original);
            }
            catch
            {
                return null;
            }
        }
    }
}

