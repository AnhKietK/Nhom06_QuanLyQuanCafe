namespace QuanLyQuanCafe.DTO
{
    public class ChiTietPhieuNhapDTO
    {
        public string MaPN { get; set; } = "";
        public string MaNL { get; set; } = "";
        public string TenNL { get; set; } = "";
        public string DonViTinh { get; set; } = "";
        public decimal SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public DateTime? HanSuDung { get; set; }
        public decimal ThanhTien => SoLuongNhap * DonGiaNhap;
    }
}

