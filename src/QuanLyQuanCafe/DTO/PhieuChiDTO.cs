namespace QuanLyQuanCafe.DTO
{
    public class PhieuChiDTO
    {
        public string MaPC { get; set; } = "";
        public DateTime NgayChi { get; set; }
        public decimal SoTienChi { get; set; }
        public string LyDoChi { get; set; } = "";
        public string MaNV { get; set; } = "";
        public string TenNV { get; set; } = "";
        public string? MaNCC { get; set; }
        public string TenNCC { get; set; } = "";
    }
}

