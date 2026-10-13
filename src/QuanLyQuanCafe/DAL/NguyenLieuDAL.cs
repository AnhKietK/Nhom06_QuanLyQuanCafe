using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAL
{
    public class NguyenLieuDAL
    {
        public List<NguyenLieuDTO> LayDanhSach()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachNguyenLieu");
            var list = new List<NguyenLieuDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NguyenLieuDTO
                {
                    MaNL = r["MaNL"]?.ToString() ?? "",
                    TenNL = r["TenNL"]?.ToString() ?? "",
                    SoLuongTonKho = r["SoLuongTonKho"] == DBNull.Value ? 0m : Convert.ToDecimal(r["SoLuongTonKho"]),
                    MucToiThieu = r["MucToiThieu"] == DBNull.Value ? 0m : Convert.ToDecimal(r["MucToiThieu"]),
                    MaLoaiNL = r["MaLoaiNL"]?.ToString() ?? "",
                    TenLoai = r["TenLoai"]?.ToString() ?? "",
                    DonViTinh = r["DonViTinh"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public List<NguyenLieuDTO> LayCanhBao()
        {
            DataTable dt = DbHelper.SelectView("v_TonKhoCanhBao");
            var list = new List<NguyenLieuDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NguyenLieuDTO
                {
                    MaNL = r["MaNL"]?.ToString() ?? "",
                    TenNL = r["TenNL"]?.ToString() ?? "",
                    SoLuongTonKho = r["SoLuongTonKho"] == DBNull.Value ? 0m : Convert.ToDecimal(r["SoLuongTonKho"]),
                    MucToiThieu = r["MucToiThieu"] == DBNull.Value ? 0m : Convert.ToDecimal(r["MucToiThieu"]),
                    TenLoai = r["LoaiNguyenLieu"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public List<LoaiNguyenLieuDTO> LayDanhSachLoai()
        {
            DataTable dt = DbHelper.ExecSP("sp_LayDanhSachLoaiNguyenLieu");
            var list = new List<LoaiNguyenLieuDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new LoaiNguyenLieuDTO
                {
                    MaLoaiNL = r["MaLoaiNL"]?.ToString() ?? "",
                    TenLoai = r["TenLoai"]?.ToString() ?? "",
                    DonViTinh = r["DonViTinh"]?.ToString() ?? ""
                });
            }

            return list;
        }

        public void Them(NguyenLieuDTO nl)
        {
            DbHelper.ExecSP("sp_ThemNguyenLieu",
                new SqlParameter("@MaNL", nl.MaNL),
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@SoLuongTonKho", SqlDbType.Decimal) { Precision = 12, Scale = 3, Value = 0m },
                new SqlParameter("@MucToiThieu", SqlDbType.Decimal) { Precision = 12, Scale = 3, Value = nl.MucToiThieu },
                new SqlParameter("@MaLoaiNL", nl.MaLoaiNL));
        }

        public void Sua(NguyenLieuDTO nl)
        {
            DbHelper.ExecSP("sp_SuaNguyenLieu",
                new SqlParameter("@MaNL", nl.MaNL),
                new SqlParameter("@TenNL", nl.TenNL),
                new SqlParameter("@MucToiThieu", SqlDbType.Decimal) { Precision = 12, Scale = 3, Value = nl.MucToiThieu },
                new SqlParameter("@MaLoaiNL", nl.MaLoaiNL));
        }

        public void Xoa(string maNL)
        {
            DbHelper.ExecSP("sp_XoaNguyenLieu",
                new SqlParameter("@MaNL", maNL));
        }
    }
}

