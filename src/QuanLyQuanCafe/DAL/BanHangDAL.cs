using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.DAL
{
    public class BanHangDAL
    {
        /// <summary>
        /// Lấy chuỗi kết nối ưu tiên PhucVuConn từ AppConfig, hoặc phiên đăng nhập hiện tại
        /// </summary>
        private string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentUser.ActiveConnectionString))
                    return CurrentUser.ActiveConnectionString;

                return AppConfig.Get("PhucVuConn");
            }
        }

        #region 1. Quản lý Bàn

        public List<BanDTO> LayDanhSachBan()
        {
            var list = new List<BanDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_LayDanhSachBan", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BanDTO
                    {
                        MaBan = reader["MaBan"].ToString() ?? "",
                        SoBan = Convert.ToInt32(reader["SoBan"]),
                        SoChoNgoi = Convert.ToInt32(reader["SoChoNgoi"]),
                        TrangThai = reader["TrangThai"].ToString() ?? "",
                        MaViTri = reader["MaViTri"].ToString() ?? "",
                        TenViTri = reader["TenViTri"].ToString() ?? ""
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public void ChuyenBan(string maHD, string maBanCu, string maBanMoi)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand(@"
                    BEGIN TRANSACTION;
                    UPDATE HoaDon SET MaBan = @MaBanMoi WHERE MaHD = @MaHD;
                    UPDATE Ban SET TrangThai = N'TRONG' WHERE MaBan = @MaBanCu;
                    UPDATE Ban SET TrangThai = N'COKHACH' WHERE MaBan = @MaBanMoi;
                    COMMIT TRANSACTION;", conn)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));
                cmd.Parameters.Add(new SqlParameter("@MaBanCu", maBanCu));
                cmd.Parameters.Add(new SqlParameter("@MaBanMoi", maBanMoi));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        #endregion

        #region 2. Thực đơn thức uống

        public List<LoaiThucUongDTO> LayDanhSachLoaiThucUong()
        {
            var list = new List<LoaiThucUongDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_LayDanhSachLoaiThucUong", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LoaiThucUongDTO
                    {
                        MaLoaiTU = reader["MaLoaiTU"].ToString() ?? "",
                        TenLoai = reader["TenLoai"].ToString() ?? "",
                        MoTa = reader["MoTa"] == DBNull.Value ? null : reader["MoTa"].ToString()
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public List<ThucUongDTO> LayDanhSachThucUong(string? maLoaiTU = null)
        {
            var list = new List<ThucUongDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_LayDanhSachThucUongTheoLoai", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaLoaiTU", string.IsNullOrWhiteSpace(maLoaiTU) ? DBNull.Value : maLoaiTU));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenLoaiTU = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string col = reader.GetName(i);
                        if (col.Equals("TenLoaiTU", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("LoaiThucUong", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("TenLoai", StringComparison.OrdinalIgnoreCase))
                        {
                            if (reader[i] != DBNull.Value) tenLoaiTU = reader[i].ToString() ?? "";
                            break;
                        }
                    }

                    list.Add(new ThucUongDTO
                    {
                        MaThucUong = reader["MaThucUong"].ToString() ?? "",
                        TenThucUong = reader["TenThucUong"].ToString() ?? "",
                        DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                        HinhAnh = reader["HinhAnh"] == DBNull.Value ? null : reader["HinhAnh"].ToString(),
                        MaLoaiTU = reader["MaLoaiTU"].ToString() ?? "",
                        TenLoaiTU = tenLoaiTU
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public List<ThucUongDTO> TimKiemThucUong(string? tuKhoa, string? maLoaiTU = null)
        {
            var list = new List<ThucUongDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_TimKiemThucUong", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@TuKhoa", string.IsNullOrWhiteSpace(tuKhoa) ? DBNull.Value : tuKhoa));
                cmd.Parameters.Add(new SqlParameter("@MaLoaiTU", string.IsNullOrWhiteSpace(maLoaiTU) ? DBNull.Value : maLoaiTU));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenLoaiTU = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string col = reader.GetName(i);
                        if (col.Equals("TenLoaiTU", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("LoaiThucUong", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("TenLoai", StringComparison.OrdinalIgnoreCase))
                        {
                            if (reader[i] != DBNull.Value) tenLoaiTU = reader[i].ToString() ?? "";
                            break;
                        }
                    }

                    list.Add(new ThucUongDTO
                    {
                        MaThucUong = reader["MaThucUong"].ToString() ?? "",
                        TenThucUong = reader["TenThucUong"].ToString() ?? "",
                        DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                        HinhAnh = reader["HinhAnh"] == DBNull.Value ? null : reader["HinhAnh"].ToString(),
                        MaLoaiTU = reader["MaLoaiTU"].ToString() ?? "",
                        TenLoaiTU = tenLoaiTU
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public bool KiemTraDuNguyenLieu(string maThucUong, int soLuong)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("SELECT dbo.fn_KiemTraDuNguyenLieu(@MaThucUong, @SoLuong)", conn)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaThucUong", maThucUong));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", soLuong));

                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToBoolean(result);
                }

                return true;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        #endregion

        #region 3. Hóa đơn & Gọi món

        // MANG VE: chọn hóa đơn theo MaHD, không dùng TOP 1 theo bàn quy ước.
        public List<HoaDonDTO> LayDanhSachDonMangVe()
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand("sp_LayDanhSachDonMangVe", conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 15
            };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            var result = new List<HoaDonDTO>();
            while (reader.Read())
                result.Add(new HoaDonDTO
                {
                    MaHD = reader["MaHD"].ToString() ?? "",
                    NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                    MaNV = reader["MaNV"].ToString() ?? "",
                    MaKH = reader["MaKH"] == DBNull.Value ? null : reader["MaKH"].ToString(),
                    MaBan = "B_MANGVE",
                    TienGiamGia = reader["TienGiamGia"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TienGiamGia"]),
                    PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString() ?? "Tiền mặt"
                });
            return result;
        }

        public HoaDonDTO? LayHoaDonDangMoTheoBan(string maBan)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_LayHoaDonDangMoTheoBan", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaBan", maBan));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new HoaDonDTO
                    {
                        MaHD = reader["MaHD"].ToString() ?? "",
                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                        MaNV = reader["MaNV"].ToString() ?? "",
                        MaKH = reader["MaKH"] == DBNull.Value ? null : reader["MaKH"].ToString(),
                        TienGiamGia = reader["TienGiamGia"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TienGiamGia"]),
                        PhuongThucThanhToan = reader["PhuongThucThanhToan"].ToString() ?? "Tiền mặt",
                        MaBan = maBan,
                        TrangThai = "Chưa thanh toán"
                    };
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public List<ChiTietHoaDonDTO> LayChiTietHoaDon(string maHD)
        {
            var list = new List<ChiTietHoaDonDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_LayChiTietHoaDon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ChiTietHoaDonDTO
                    {
                        MaHD = maHD,
                        MaThucUong = reader["MaThucUong"].ToString() ?? "",
                        TenThucUong = reader["TenThucUong"].ToString() ?? "",
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        DonGia = Convert.ToDecimal(reader["DonGia"]),
                        ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public string TaoHoaDon(string? maKH, string maNV, string maBan, string phuongThucThanhToan = "Tiền mặt")
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_TaoHoaDon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                var pMaHD = new SqlParameter("@MaHD", SqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.InputOutput,
                    Value = DBNull.Value
                };
                cmd.Parameters.Add(pMaHD);
                cmd.Parameters.Add(new SqlParameter("@MaKH", string.IsNullOrWhiteSpace(maKH) ? DBNull.Value : maKH));
                cmd.Parameters.Add(new SqlParameter("@MaNV", maNV));
                cmd.Parameters.Add(new SqlParameter("@MaBan", maBan));
                cmd.Parameters.Add(new SqlParameter("@PhuongThucThanhToan", phuongThucThanhToan));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetName(i).Equals("MaHD", StringComparison.OrdinalIgnoreCase) && reader[i] != DBNull.Value)
                        {
                            return reader[i].ToString() ?? "";
                        }
                    }
                }

                if (pMaHD.Value != null && pMaHD.Value != DBNull.Value)
                {
                    return pMaHD.Value.ToString() ?? "";
                }

                return "";
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public void ThemMonVaoHoaDon(string maHD, string maThucUong, int soLuong)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_ThemMonVaoHoaDon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));
                cmd.Parameters.Add(new SqlParameter("@MaThucUong", maThucUong));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", soLuong));

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 2812) // Không tìm thấy sp_ThemMonVaoHoaDon thì thử sp_ThemMonVaoHD
                {
                    cmd.CommandText = "sp_ThemMonVaoHD";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public void CapNhatSoLuongMon(string maHD, string maThucUong, int soLuongMoi)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_CapNhatSoLuongMon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));
                cmd.Parameters.Add(new SqlParameter("@MaThucUong", maThucUong));
                cmd.Parameters.Add(new SqlParameter("@SoLuongMoi", soLuongMoi));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public void HuyHoaDon(string maHD)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_HuyHoaDon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public decimal ThanhToanHoaDon(string maHD, decimal? tienGiamGia, string phuongThucThanhToan = "Tiền mặt")
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_ThanhToanHoaDon", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));
                cmd.Parameters.Add(new SqlParameter("@TienGiamGia", tienGiamGia.HasValue ? tienGiamGia.Value : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@PhuongThucThanhToan", phuongThucThanhToan));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read() && reader["TongTienThanhToan"] != DBNull.Value)
                {
                    return Convert.ToDecimal(reader["TongTienThanhToan"]);
                }

                return 0;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public decimal TinhThanhTienHoaDon(string maHD)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("SELECT dbo.fn_TinhThanhTienHoaDon(@MaHD)", conn)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaHD", maHD));

                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }

                return 0;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        #endregion

        #region 4. Khách hàng & Chiết khấu

        public decimal LayChietKhauTheoKhach(string maKH)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("SELECT dbo.fn_ChietKhauTheoLoaiKH(@MaKH)", conn)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@MaKH", maKH));

                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }

                return 0;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        public List<KhachHangDTO> TimKiemKhach(string tuKhoa)
        {
            var list = new List<KhachHangDTO>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_TimKiemKhach", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                cmd.Parameters.Add(new SqlParameter("@TuKhoa", tuKhoa ?? ""));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenLoai = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string col = reader.GetName(i);
                        if (col.Equals("TenLoai", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("TenLoaiKhach", StringComparison.OrdinalIgnoreCase) ||
                            col.Equals("TenLoaiKH", StringComparison.OrdinalIgnoreCase))
                        {
                            if (reader[i] != DBNull.Value) tenLoai = reader[i].ToString() ?? "";
                            break;
                        }
                    }

                    list.Add(new KhachHangDTO
                    {
                        MaKH = reader["MaKH"].ToString() ?? "",
                        TenKH = reader["TenKH"].ToString() ?? "",
                        SoDienThoai = reader["SoDienThoai"].ToString() ?? "",
                        DiemTichLuy = reader["DiemTichLuy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DiemTichLuy"]),
                        MaLoaiKH = reader["MaLoaiKH"].ToString() ?? "",
                        TenLoai = tenLoai,
                        ChietKhau = reader["ChietKhau"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ChietKhau"])
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }

            return list;
        }

        public string ThemKhachHang(string tenKH, string sdt)
        {
            try
            {
                using var conn = new SqlConnection(ConnectionString);
                using var cmd = new SqlCommand("sp_ThemKhachHang", conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 15
                };

                var pMaKH = new SqlParameter("@MaKH", SqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.InputOutput,
                    Value = DBNull.Value
                };
                cmd.Parameters.Add(pMaKH);
                cmd.Parameters.Add(new SqlParameter("@TenKH", tenKH));
                cmd.Parameters.Add(new SqlParameter("@SoDienThoai", sdt));
                cmd.Parameters.Add(new SqlParameter("@MaLoaiKH", "LKH01"));

                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string col = reader.GetName(i);
                        if ((col.Equals("MaKHMoi", StringComparison.OrdinalIgnoreCase) ||
                             col.Equals("MaKH", StringComparison.OrdinalIgnoreCase)) &&
                            reader[i] != DBNull.Value)
                        {
                            return reader[i].ToString() ?? "";
                        }
                    }
                }

                if (pMaKH.Value != null && pMaKH.Value != DBNull.Value)
                {
                    return pMaKH.Value.ToString() ?? "";
                }

                return "";
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException(CustomSqlExceptionHandler.Translate(ex), ex);
            }
        }

        #endregion
    }
}
