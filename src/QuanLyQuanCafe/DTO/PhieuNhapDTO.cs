namespace QuanLyQuanCafe.DTO
{
    public class PhieuNhapDTO
    {
        public string MaPN { get; set; } = "";
        public DateTime NgayNhap { get; set; }
        public string? GhiChu { get; set; }
        public string MaNCC { get; set; } = "";
        public string TenNCC { get; set; } = "";
        public string MaNV { get; set; } = "";
        public decimal TongTien { get; set; }
        public List<ChiTietPhieuNhapDTO> ChiTiet { get; set; } = new();
    }
}

