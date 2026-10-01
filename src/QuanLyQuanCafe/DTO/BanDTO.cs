namespace QuanLyQuanCafe.DTO
{
    public class BanDTO
    {
        public string MaBan { get; set; } = "";
        public int SoBan { get; set; }
        public int SoChoNgoi { get; set; }
        public string TrangThai { get; set; } = "";   // TRONG / COKHACH / DATTRUOC
        public string MaViTri { get; set; } = "";
        public string TenViTri { get; set; } = "";
    }
}