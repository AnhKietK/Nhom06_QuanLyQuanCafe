namespace QuanLyQuanCafe.DTO
{
    public class LoaiKhachDTO
    {
        public string MaLoaiKH { get; set; } = "";
        public string TenLoaiKH { get; set; } = "";
        public decimal PhanTramGiam { get; set; }
        public int DiemToiThieu { get; set; }

        public override string ToString() => $"{TenLoaiKH} - Giảm {PhanTramGiam:N0}% ({DiemToiThieu} điểm)";
    }
}

