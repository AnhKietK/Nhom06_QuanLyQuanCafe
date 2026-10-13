namespace QuanLyQuanCafe.DTO
{
    public class NguyenLieuDTO
    {
        public string MaNL { get; set; } = "";
        public string TenNL { get; set; } = "";
        public decimal SoLuongTonKho { get; set; }
        public decimal MucToiThieu { get; set; }
        public string MaLoaiNL { get; set; } = "";
        public string TenLoai { get; set; } = "";
        public string DonViTinh { get; set; } = "";

        public bool SapHet => SoLuongTonKho < MucToiThieu;
        public string TinhTrang => SapHet ? "Sắp hết" : "Đủ";
    }
}

