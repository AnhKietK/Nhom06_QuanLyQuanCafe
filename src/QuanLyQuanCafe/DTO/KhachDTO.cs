namespace QuanLyQuanCafe.DTO
{
    public class KhachDTO
    {
        public string MaKH { get; set; } = "";
        public string TenKH { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public int DiemTichLuy { get; set; }
        public string MaLoaiKH { get; set; } = "";
        public string TenLoaiKH { get; set; } = "";
        public decimal PhanTramGiam { get; set; }

        public string HienThiChietKhau => $"{TenLoaiKH} (Giảm {PhanTramGiam:N0}%)";
    }
}

