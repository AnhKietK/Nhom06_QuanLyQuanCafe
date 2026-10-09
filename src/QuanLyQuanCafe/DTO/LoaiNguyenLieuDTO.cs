namespace QuanLyQuanCafe.DTO
{
    public class LoaiNguyenLieuDTO
    {
        public string MaLoaiNL { get; set; } = "";
        public string TenLoai { get; set; } = "";
        public string DonViTinh { get; set; } = "";

        public override string ToString() => $"{TenLoai} ({DonViTinh})";
    }
}

