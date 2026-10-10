USE quanlyquancafe;
GO

-- 1. SP lấy danh sách loại khách hàng để đổ vào ComboBox
CREATE OR ALTER PROCEDURE sp_LayDanhSachLoaiKhach
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiKH, 
           TenLoai AS TenLoaiKH, 
           ChietKhau AS PhanTramGiam, 
           0 AS DiemToiThieu
    FROM LoaiKhach
    ORDER BY ChietKhau ASC;
END
GO

-- 2. SP lấy danh sách lịch sử phiếu chi tiền
CREATE OR ALTER PROCEDURE sp_LayDanhSachPhieuChi
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pc.MaPC, pc.NgayChi, pc.SoTienChi, pc.LyDoChi,
           pc.MaNV, nv.TenNV,
           pc.MaNCC, ISNULL(ncc.TenNCC, N'(Chi phí khác)') AS TenNCC
    FROM PhieuChi pc
    LEFT JOIN NhanVien nv ON pc.MaNV = nv.MaNV
    LEFT JOIN NhaCungCap ncc ON pc.MaNCC = ncc.MaNCC
    WHERE (@TuNgay IS NULL OR CAST(pc.NgayChi AS DATE) >= @TuNgay)
      AND (@DenNgay IS NULL OR CAST(pc.NgayChi AS DATE) <= @DenNgay)
    ORDER BY pc.NgayChi DESC;
END
GO

-- 3. Phân quyền thực thi và truy vấn cho Phục vụ và Kế toán
-- Phục vụ cần nạp loại khách
GRANT EXECUTE ON sp_LayDanhSachLoaiKhach TO PhucVu;

-- Kế toán cần các chức năng chi tiền và báo cáo
GRANT EXECUTE ON sp_LayDanhSachPhieuChi   TO KeToan;
GRANT EXECUTE ON sp_LayDanhSachNCC        TO KeToan;
GRANT EXECUTE ON sp_ThongKeDoanhThu       TO KeToan;
GRANT SELECT ON fn_MonBanChayNhat         TO KeToan;
GRANT SELECT ON v_DoanhThuTheoNgay        TO KeToan;
GRANT SELECT ON v_MonBanChay              TO KeToan;
GRANT SELECT ON v_HoaDon                  TO KeToan;
GO

/* =========================================================================
   CÂU LỆNH KIỂM TRA CHO NGƯỜI DÙNG CHẠY TRONG SSMS:
   =========================================================================
   EXEC sp_LayDanhSachLoaiKhach;
   EXEC sp_LayDanhSachPhieuChi '2026-01-01', '2026-12-31';

   -- Kiểm tra quyền Kế toán:
   EXECUTE AS LOGIN = 'login_ketoan';
   EXEC sp_LayDanhSachPhieuChi;
   EXEC sp_ThongKeDoanhThu '2026-01-01', '2026-12-31';
   SELECT TOP 5 * FROM v_HoaDon;
   REVERT;

   -- Kiểm tra quyền Phục vụ:
   EXECUTE AS LOGIN = 'login_phucvu';
   EXEC sp_LayDanhSachLoaiKhach;
   EXEC sp_TimKiemKhach '';
   REVERT;
*/
