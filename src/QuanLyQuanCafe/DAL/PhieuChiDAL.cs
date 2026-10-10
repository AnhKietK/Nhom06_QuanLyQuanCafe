using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class PhieuChiDAL
    {
        public List<NhaCungCapLookupDTO> LayDanhSachNCC()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachNCC");
            var list = new List<NhaCungCapLookupDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NhaCungCapLookupDTO
                {
                    MaNCC = r["MaNCC"]?.ToString() ?? "",
                    TenNCC = r["TenNCC"]?.ToString() ?? "",
                    SoDienThoai = r.Table.Columns.Contains("SoDienThoai") ? r["SoDienThoai"]?.ToString() : null
                });
            }

            return list;
        }

        public string ChiTienNCC(decimal soTien, string lyDo, string maNV, string? maNCC)
        {
            SqlParameter pMaPC = DbParam.Tao("@MaPC", null);
            SqlParameter pSoTien = new SqlParameter("@SoTienChi", SqlDbType.Decimal)
            {
                Precision = 12,
                Scale = 2,
                Value = soTien
            };
            SqlParameter pLyDo = new SqlParameter("@LyDoChi", lyDo ?? "");
            SqlParameter pMaNV = new SqlParameter("@MaNV", maNV ?? "");
            SqlParameter pMaNCC = DbParam.Tao("@MaNCC", maNCC);

            DataTable dt = DbHelper.ExecSP("sp_ChiTienNCC", pMaPC, pSoTien, pLyDo, pMaNV, pMaNCC);
            if (dt.Rows.Count > 0)
            {
                if (dt.Columns.Contains("MaPC") && dt.Rows[0]["MaPC"] != DBNull.Value)
                    return dt.Rows[0]["MaPC"]?.ToString() ?? "";
                if (dt.Columns.Count > 1 && dt.Rows[0][1] != DBNull.Value)
                    return dt.Rows[0][1]?.ToString() ?? "";
                return dt.Rows[0][0]?.ToString() ?? "";
            }

            return "";
        }

        public List<PhieuChiDTO> LayDanhSachPhieuChi(DateTime? tuNgay, DateTime? denNgay)
        {
            SqlParameter pTuNgay = DbParam.Tao("@TuNgay", tuNgay.HasValue ? tuNgay.Value.Date : null);
            SqlParameter pDenNgay = DbParam.Tao("@DenNgay", denNgay.HasValue ? denNgay.Value.Date : null);

            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachPhieuChi", pTuNgay, pDenNgay);
            var list = new List<PhieuChiDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new PhieuChiDTO
                {
                    MaPC = r["MaPC"]?.ToString() ?? "",
                    NgayChi = r["NgayChi"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgayChi"]),
                    SoTienChi = r["SoTienChi"] == DBNull.Value ? 0m : Convert.ToDecimal(r["SoTienChi"]),
                    LyDoChi = r["LyDoChi"]?.ToString() ?? "",
                    MaNV = r["MaNV"]?.ToString() ?? "",
                    TenNV = r.Table.Columns.Contains("TenNV") ? (r["TenNV"]?.ToString() ?? "") : "",
                    MaNCC = r["MaNCC"] == DBNull.Value ? null : r["MaNCC"]?.ToString(),
                    TenNCC = r.Table.Columns.Contains("TenNCC") ? (r["TenNCC"]?.ToString() ?? "") : ""
                });
            }

            return list;
        }
    }
}

