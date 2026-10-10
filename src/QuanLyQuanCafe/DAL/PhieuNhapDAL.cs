using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class PhieuNhapDAL
    {
        public string LuuPhieuTronGoi(string maNCC, string maNV, string? ghiChu, List<ChiTietPhieuNhapDTO> dong)
        {
            var danhSachJsonObj = dong.Select(d => new
            {
                MaNL = d.MaNL,
                SoLuongNhap = d.SoLuongNhap,
                DonGiaNhap = d.DonGiaNhap,
                HanSuDung = d.HanSuDung?.ToString("yyyy-MM-dd")
            }).ToList();

            string json = JsonSerializer.Serialize(danhSachJsonObj);

            DataTable dt = DbHelper.ExecSP("sp_NhapKhoTronGoi",
                new SqlParameter("@MaNCC", maNCC),
                new SqlParameter("@MaNV", maNV),
                DbParam.Tao("@GhiChu", ghiChu),
                new SqlParameter("@DanhSachJson", json));

            if (dt.Rows.Count > 0 && dt.Columns.Contains("MaPN"))
            {
                return dt.Rows[0]["MaPN"]?.ToString() ?? "";
            }

            throw new InvalidOperationException("Không nhận được mã phiếu nhập từ máy chủ CSDL.");
        }

        public List<PhieuNhapDTO> LayLichSu(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = DbHelper.SelectView(
                "v_PhieuNhap",
                "NgayNhap >= @tu AND NgayNhap < @den",
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgay.Date.AddDays(1)));

            var list = new List<PhieuNhapDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuNhapDTO
                {
                    MaPN = r["MaPN"]?.ToString() ?? "",
                    NgayNhap = r["NgayNhap"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayNhap"]),
                    GhiChu = r["GhiChu"] == DBNull.Value ? null : r["GhiChu"].ToString(),
                    MaNCC = r["MaNCC"]?.ToString() ?? "",
                    MaNV = r["MaNV"]?.ToString() ?? "",
                    TongTien = r["TongTien"] == DBNull.Value ? 0m : Convert.ToDecimal(r["TongTien"])
                });
            }

            return list;
        }

        public List<ChiTietPhieuNhapDTO> LayChiTiet(string maPN)
        {
            DataTable dt = DbHelper.ExecSP("sp_LayChiTietPhieuNhap",
                new SqlParameter("@MaPN", maPN));

            var list = new List<ChiTietPhieuNhapDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ChiTietPhieuNhapDTO
                {
                    MaPN = r["MaPN"]?.ToString() ?? "",
                    MaNL = r["MaNL"]?.ToString() ?? "",
                    TenNL = r["TenNL"]?.ToString() ?? "",
                    DonViTinh = r["DonViTinh"]?.ToString() ?? "",
                    SoLuongNhap = r["SoLuongNhap"] == DBNull.Value ? 0m : Convert.ToDecimal(r["SoLuongNhap"]),
                    DonGiaNhap = r["DonGiaNhap"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DonGiaNhap"]),
                    HanSuDung = r["HanSuDung"] == DBNull.Value ? null : Convert.ToDateTime(r["HanSuDung"])
                });
            }

            return list;
        }
    }
}

