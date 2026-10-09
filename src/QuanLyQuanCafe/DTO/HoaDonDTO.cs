namespace QuanLyQuanCafe.DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; } = "";
        public DateTime NgayLap { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? MaKH { get; set; }
        public string? TenKH { get; set; }
        public string MaNV { get; set; } = "";
        public string? TenNV { get; set; }
        public string MaBan { get; set; } = "";
        public int? SoBan { get; set; }
        public string TrangThai { get; set; } = "Chưa thanh toán";
        public string PhuongThucThanhToan { get; set; } = "Tiền mặt";
        public decimal TongTienHang { get; set; }
        public decimal TienGiamGia { get; set; }
        public decimal TongTienThanhToan { get; set; }
        public int DiemTichLuyCong { get; set; }
    }
}
