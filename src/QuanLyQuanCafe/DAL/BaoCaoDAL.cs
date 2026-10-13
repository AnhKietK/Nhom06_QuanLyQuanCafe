using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAL
{
    public class BaoCaoDAL
    {
        public List<DoanhThuNgayDTO> ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = DbHelper.ExecSP(
                "sp_ThongKeDoanhThu",
                new SqlParameter("@TuNgay", tuNgay.Date),
                new SqlParameter("@DenNgay", denNgay.Date)
            );

            var list = new List<DoanhThuNgayDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new DoanhThuNgayDTO
                {
                    Ngay = r["Ngay"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["Ngay"]),
                    SoHoaDon = r["SoHoaDon"] == DBNull.Value ? 0 : Convert.ToInt32(r["SoHoaDon"]),
                    TongDoanhThu = r["TongDoanhThu"] == DBNull.Value ? 0m : Convert.ToDecimal(r["TongDoanhThu"])
                });
            }

            return list;
        }

        public List<MonBanChayDTO> ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = DbHelper.ExecTableFn(
                "fn_MonBanChayNhat",
                new SqlParameter("@TuNgay", tuNgay.Date),
                new SqlParameter("@DenNgay", denNgay.Date)
            );

            var list = new List<MonBanChayDTO>();
            foreach (DataRow r in dt.Rows)
            {
                int soLuong = 0;
                if (r.Table.Columns.Contains("TongSoLuongBan") && r["TongSoLuongBan"] != DBNull.Value)
                    soLuong = Convert.ToInt32(r["TongSoLuongBan"]);
                else if (r.Table.Columns.Contains("SoLuongDaBan") && r["SoLuongDaBan"] != DBNull.Value)
                    soLuong = Convert.ToInt32(r["SoLuongDaBan"]);
                else if (r.Table.Columns.Contains("SoLuongBan") && r["SoLuongBan"] != DBNull.Value)
                    soLuong = Convert.ToInt32(r["SoLuongBan"]);

                decimal doanhThu = 0m;
                if (r.Table.Columns.Contains("TongDoanhThu") && r["TongDoanhThu"] != DBNull.Value)
                    doanhThu = Convert.ToDecimal(r["TongDoanhThu"]);
                else if (r.Table.Columns.Contains("TongTien") && r["TongTien"] != DBNull.Value)
                    doanhThu = Convert.ToDecimal(r["TongTien"]);

                list.Add(new MonBanChayDTO
                {
                    MaThucUong = r["MaThucUong"]?.ToString() ?? "",
                    TenThucUong = r["TenThucUong"]?.ToString() ?? "",
                    SoLuongBan = soLuong,
                    TongDoanhThu = doanhThu
                });
            }

            return list;
        }

        public List<MonBanChayDTO> LayTopMonBanChayToanThoiGian()
        {
            DataTable dt = DbHelper.SelectView("v_MonBanChay");
            var list = new List<MonBanChayDTO>();

            foreach (DataRow r in dt.Rows)
            {
                int soLuong = 0;
                if (r.Table.Columns.Contains("TongSoLuongBan") && r["TongSoLuongBan"] != DBNull.Value)
                    soLuong = Convert.ToInt32(r["TongSoLuongBan"]);
                else if (r.Table.Columns.Contains("SoLuongBan") && r["SoLuongBan"] != DBNull.Value)
                    soLuong = Convert.ToInt32(r["SoLuongBan"]);

                decimal doanhThu = 0m;
                if (r.Table.Columns.Contains("TongDoanhThu") && r["TongDoanhThu"] != DBNull.Value)
                    doanhThu = Convert.ToDecimal(r["TongDoanhThu"]);

                list.Add(new MonBanChayDTO
                {
                    MaThucUong = r["MaThucUong"]?.ToString() ?? "",
                    TenThucUong = r["TenThucUong"]?.ToString() ?? "",
                    SoLuongBan = soLuong,
                    TongDoanhThu = doanhThu
                });
            }

            return list;
        }

        public List<HoaDonBaoCaoDTO> LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = DbHelper.SelectView(
                "v_HoaDon",
                "NgayLap >= @tu AND NgayLap < @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date.AddDays(1))
            );

            var list = new List<HoaDonBaoCaoDTO>();
            foreach (DataRow r in dt.Rows)
            {
                DateTime ngay = DateTime.MinValue;
                if (r.Table.Columns.Contains("NgayLap") && r["NgayLap"] != DBNull.Value)
                    ngay = Convert.ToDateTime(r["NgayLap"]);
                else if (r.Table.Columns.Contains("NgayTao") && r["NgayTao"] != DBNull.Value)
                    ngay = Convert.ToDateTime(r["NgayTao"]);

                decimal tongTienHang = r.Table.Columns.Contains("TongTienHang") && r["TongTienHang"] != DBNull.Value
                    ? Convert.ToDecimal(r["TongTienHang"])
                    : 0m;

                decimal tienGiamGia = r.Table.Columns.Contains("TienGiamGia") && r["TienGiamGia"] != DBNull.Value
                    ? Convert.ToDecimal(r["TienGiamGia"])
                    : 0m;

                decimal tongThanhToan = 0m;
                if (r.Table.Columns.Contains("TongTienThanhToan") && r["TongTienThanhToan"] != DBNull.Value)
                    tongThanhToan = Convert.ToDecimal(r["TongTienThanhToan"]);
                else if (r.Table.Columns.Contains("TongThanhToan") && r["TongThanhToan"] != DBNull.Value)
                    tongThanhToan = Convert.ToDecimal(r["TongThanhToan"]);

                string tenKH = "(Khách vãng lai)";
                if (r.Table.Columns.Contains("TenKH") && !string.IsNullOrWhiteSpace(r["TenKH"]?.ToString()))
                    tenKH = r["TenKH"]?.ToString() ?? "";
                else if (r.Table.Columns.Contains("MaKH") && !string.IsNullOrWhiteSpace(r["MaKH"]?.ToString()))
                    tenKH = r["MaKH"]?.ToString() ?? "";

                list.Add(new HoaDonBaoCaoDTO
                {
                    MaHD = r["MaHD"]?.ToString() ?? "",
                    NgayTao = ngay,
                    TenBan = r.Table.Columns.Contains("TenBan")
                        ? (r["TenBan"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("MaBan") ? (r["MaBan"]?.ToString() ?? "") : ""),
                    TenNV = r.Table.Columns.Contains("TenNV")
                        ? (r["TenNV"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("MaNV") ? (r["MaNV"]?.ToString() ?? "") : ""),
                    TenKH = tenKH,
                    TongTienHang = tongTienHang,
                    TienGiamGia = tienGiamGia,
                    TongThanhToan = tongThanhToan,
                    PhuongThucThanhToan = r.Table.Columns.Contains("PhuongThucThanhToan")
                        ? (r["PhuongThucThanhToan"]?.ToString() ?? "")
                        : "",
                    TrangThai = r.Table.Columns.Contains("TrangThai")
                        ? (r["TrangThai"]?.ToString() ?? "")
                        : ""
                });
            }

            return list;
        }
    }
}

