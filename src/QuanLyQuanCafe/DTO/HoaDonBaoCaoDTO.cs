namespace QuanLyQuanCafe.DTO
{
    public class HoaDonBaoCaoDTO
    {
        public string MaHD { get; set; } = "";
        public DateTime NgayTao { get; set; }
        public string TenBan { get; set; } = "";
        public string TenNV { get; set; } = "";
        public string TenKH { get; set; } = "";
        public decimal TongTienHang { get; set; }
        public decimal TienGiamGia { get; set; }
        public decimal TongThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; } = "";
        public string TrangThai { get; set; } = "";
    }
}

