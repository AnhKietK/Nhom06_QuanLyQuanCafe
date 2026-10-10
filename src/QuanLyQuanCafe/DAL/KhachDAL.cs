using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class KhachDAL
    {
        public List<KhachDTO> TimKiem(string tuKhoa)
        {
            string keyword = string.IsNullOrWhiteSpace(tuKhoa) ? "" : tuKhoa.Trim();
            DataTable dt = DbHelper.ExecSP("sp_TimKiemKhach", new SqlParameter("@TuKhoa", keyword));
            var list = new List<KhachDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new KhachDTO
                {
                    MaKH = r["MaKH"]?.ToString() ?? "",
                    TenKH = r["TenKH"]?.ToString() ?? "",
                    SoDienThoai = r["SoDienThoai"]?.ToString() ?? "",
                    DiemTichLuy = r["DiemTichLuy"] == DBNull.Value ? 0 : Convert.ToInt32(r["DiemTichLuy"]),
                    MaLoaiKH = r["MaLoaiKH"]?.ToString() ?? "",
                    TenLoaiKH = r.Table.Columns.Contains("TenLoaiKH")
                        ? (r["TenLoaiKH"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("TenLoaiKhach")
                            ? (r["TenLoaiKhach"]?.ToString() ?? "")
                            : (r.Table.Columns.Contains("TenLoai") ? (r["TenLoai"]?.ToString() ?? "") : "")),
                    PhanTramGiam = r.Table.Columns.Contains("PhanTramGiam")
                        ? (r["PhanTramGiam"] == DBNull.Value ? 0m : Convert.ToDecimal(r["PhanTramGiam"]))
                        : (r.Table.Columns.Contains("ChietKhau")
                            ? (r["ChietKhau"] == DBNull.Value ? 0m : Convert.ToDecimal(r["ChietKhau"]))
                            : 0m)
                });
            }

            return list;
        }

        public List<LoaiKhachDTO> LayDanhSachLoaiKhach()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachLoaiKhach");
            var list = new List<LoaiKhachDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new LoaiKhachDTO
                {
                    MaLoaiKH = r["MaLoaiKH"]?.ToString() ?? "",
                    TenLoaiKH = r.Table.Columns.Contains("TenLoaiKH")
                        ? (r["TenLoaiKH"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("TenLoai") ? (r["TenLoai"]?.ToString() ?? "") : ""),
                    PhanTramGiam = r.Table.Columns.Contains("PhanTramGiam")
                        ? (r["PhanTramGiam"] == DBNull.Value ? 0m : Convert.ToDecimal(r["PhanTramGiam"]))
                        : (r.Table.Columns.Contains("ChietKhau")
                            ? (r["ChietKhau"] == DBNull.Value ? 0m : Convert.ToDecimal(r["ChietKhau"]))
                            : 0m),
                    DiemToiThieu = r.Table.Columns.Contains("DiemToiThieu") && r["DiemToiThieu"] != DBNull.Value
                        ? Convert.ToInt32(r["DiemToiThieu"])
                        : 0
                });
            }

            return list;
        }

        public List<KhachDTO> LayDanhSachKhachThanThiet()
        {
            DataTable dt = DbHelper.SelectView("v_KhachHangThanThiet");
            var list = new List<KhachDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new KhachDTO
                {
                    MaKH = r["MaKH"]?.ToString() ?? "",
                    TenKH = r["TenKH"]?.ToString() ?? "",
                    SoDienThoai = r.Table.Columns.Contains("SoDienThoai") ? (r["SoDienThoai"]?.ToString() ?? "") : "",
                    DiemTichLuy = r["DiemTichLuy"] == DBNull.Value ? 0 : Convert.ToInt32(r["DiemTichLuy"]),
                    MaLoaiKH = r.Table.Columns.Contains("MaLoaiKH") ? (r["MaLoaiKH"]?.ToString() ?? "") : "",
                    TenLoaiKH = r.Table.Columns.Contains("LoaiKhachHang")
                        ? (r["LoaiKhachHang"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("TenLoaiKH") ? (r["TenLoaiKH"]?.ToString() ?? "") : ""),
                    PhanTramGiam = r.Table.Columns.Contains("ChietKhau")
                        ? (r["ChietKhau"] == DBNull.Value ? 0m : Convert.ToDecimal(r["ChietKhau"]))
                        : (r.Table.Columns.Contains("PhanTramGiam") ? Convert.ToDecimal(r["PhanTramGiam"]) : 0m)
                });
            }

            return list;
        }

        public string Them(KhachDTO kh)
        {
            SqlParameter pMaKH = DbParam.Tao("@MaKH", null);
            SqlParameter pTenKH = new SqlParameter("@TenKH", kh.TenKH ?? "");
            SqlParameter pSDT = new SqlParameter("@SoDienThoai", kh.SoDienThoai ?? "");
            SqlParameter pMaLoai = new SqlParameter("@MaLoaiKH", string.IsNullOrWhiteSpace(kh.MaLoaiKH) ? "LKH01" : kh.MaLoaiKH);

            DataTable dt = DbHelper.ExecSP("sp_ThemKhachHang", pMaKH, pTenKH, pSDT, pMaLoai);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0]?.ToString() ?? "";
            }

            return "";
        }

        public void Sua(KhachDTO kh)
        {
            DbHelper.ExecSP(
                "sp_SuaKhach",
                new SqlParameter("@MaKH", kh.MaKH ?? ""),
                new SqlParameter("@TenKH", kh.TenKH ?? ""),
                new SqlParameter("@SoDienThoai", kh.SoDienThoai ?? ""),
                new SqlParameter("@MaLoaiKH", string.IsNullOrWhiteSpace(kh.MaLoaiKH) ? "LKH01" : kh.MaLoaiKH)
            );
        }

        public void Xoa(string maKH)
        {
            DbHelper.ExecSP("sp_XoaKhach", new SqlParameter("@MaKH", maKH ?? ""));
        }

        public List<LichSuMuaHangDTO> LayLichSuMuaHang(string maKH)
        {
            DataTable dt = DbHelper.ExecTableFn("fn_LichSuMuaHang", new SqlParameter("@MaKH", maKH ?? ""));
            var list = new List<LichSuMuaHangDTO>();

            foreach (DataRow r in dt.Rows)
            {
                DateTime ngay = DateTime.MinValue;
                if (r.Table.Columns.Contains("NgayLap") && r["NgayLap"] != DBNull.Value)
                    ngay = Convert.ToDateTime(r["NgayLap"]);
                else if (r.Table.Columns.Contains("NgayTao") && r["NgayTao"] != DBNull.Value)
                    ngay = Convert.ToDateTime(r["NgayTao"]);

                decimal tongTien = 0m;
                if (r.Table.Columns.Contains("TongTien") && r["TongTien"] != DBNull.Value)
                    tongTien = Convert.ToDecimal(r["TongTien"]);
                else if (r.Table.Columns.Contains("TongTienThanhToan") && r["TongTienThanhToan"] != DBNull.Value)
                    tongTien = Convert.ToDecimal(r["TongTienThanhToan"]);

                list.Add(new LichSuMuaHangDTO
                {
                    MaHD = r["MaHD"]?.ToString() ?? "",
                    NgayTao = ngay,
                    TongTienThanhToan = tongTien,
                    PhuongThucThanhToan = r.Table.Columns.Contains("PhuongThucThanhToan")
                        ? (r["PhuongThucThanhToan"]?.ToString() ?? "")
                        : (r.Table.Columns.Contains("PhuongThuc") ? (r["PhuongThuc"]?.ToString() ?? "") : ""),
                    TenNV = r.Table.Columns.Contains("TenNV") ? (r["TenNV"]?.ToString() ?? "") : "",
                    TrangThai = r.Table.Columns.Contains("TrangThai") ? (r["TrangThai"]?.ToString() ?? "") : ""
                });
            }

            return list;
        }
    }
}

