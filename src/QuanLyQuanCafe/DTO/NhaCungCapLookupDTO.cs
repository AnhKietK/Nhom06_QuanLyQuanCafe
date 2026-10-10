namespace QuanLyQuanCafe.DTO
{
    public class NhaCungCapLookupDTO
    {
        public string? MaNCC { get; set; }
        public string TenNCC { get; set; } = "";
        public string? SoDienThoai { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(MaNCC))
                return TenNCC;
            return $"{TenNCC} ({MaNCC})";
        }
    }
}

