USE quanlyquancafe;
GO

-- 1. Danh sách loại nguyên liệu (đổ ComboBox)
CREATE OR ALTER PROCEDURE sp_LayDanhSachLoaiNguyenLieu
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiNL, TenLoai, DonViTinh FROM LoaiNguyenLieu ORDER BY TenLoai;
END
GO

-- 2. Công thức pha chế của một thức uống
CREATE OR ALTER PROCEDURE sp_LayCongThuc
    @MaThucUong VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ct.MaThucUong, ct.MaNL, nl.TenNL, lnl.DonViTinh, ct.SoLuongQuyDinh
    FROM CongThuc ct
    JOIN NguyenLieu nl ON nl.MaNL = ct.MaNL
    JOIN LoaiNguyenLieu lnl ON lnl.MaLoaiNL = nl.MaLoaiNL
    WHERE ct.MaThucUong = @MaThucUong
    ORDER BY nl.TenNL;
END
GO

-- 3. Chi tiết (từng dòng) của một phiếu nhập
CREATE OR ALTER PROCEDURE sp_LayChiTietPhieuNhap
    @MaPN VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ct.MaPN, ct.MaNL, nl.TenNL, lnl.DonViTinh,
           ct.SoLuongNhap, ct.DonGiaNhap, ct.ThanhTien, ct.HanSuDung
    FROM ChiTietPhieuNhap ct
    JOIN NguyenLieu nl ON nl.MaNL = ct.MaNL
    JOIN LoaiNguyenLieu lnl ON lnl.MaLoaiNL = nl.MaLoaiNL
    WHERE ct.MaPN = @MaPN
    ORDER BY nl.TenNL;
END
GO

-- 4. Xóa nguyên liệu (chỉ khi chưa được dùng ở đâu)
CREATE OR ALTER PROCEDURE sp_XoaNguyenLieu
    @MaNL VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM NguyenLieu WHERE MaNL = @MaNL)
            THROW 50000, N'Nguyên liệu không tồn tại.', 1;
        IF EXISTS (SELECT 1 FROM CongThuc WHERE MaNL = @MaNL)
            THROW 50000, N'Không thể xóa nguyên liệu đang được dùng trong công thức pha chế.', 1;
        IF EXISTS (SELECT 1 FROM ChiTietPhieuNhap WHERE MaNL = @MaNL)
            THROW 50000, N'Không thể xóa nguyên liệu đã có phiếu nhập.', 1;
        DELETE FROM NguyenLieu WHERE MaNL = @MaNL;
        SELECT N'Xóa nguyên liệu thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 5. Xóa nhà cung cấp (chỉ khi chưa có phiếu nhập hoặc phiếu chi)
CREATE OR ALTER PROCEDURE sp_XoaNCC
    @MaNCC VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM NhaCungCap WHERE MaNCC = @MaNCC)
            THROW 50000, N'Nhà cung cấp không tồn tại.', 1;
        IF EXISTS (SELECT 1 FROM PhieuNhap WHERE MaNCC = @MaNCC)
            THROW 50000, N'Không thể xóa nhà cung cấp đã có phiếu nhập.', 1;
        IF EXISTS (SELECT 1 FROM PhieuChi WHERE MaNCC = @MaNCC)
            THROW 50000, N'Không thể xóa nhà cung cấp đã có phiếu chi.', 1;
        DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC;
        SELECT N'Xóa nhà cung cấp thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 6. Nhập kho trọn gói: tạo phiếu và TẤT CẢ dòng trong MỘT transaction
--    @DanhSachJson: [{"MaNL":"NL01","SoLuongNhap":10,"DonGiaNhap":95,"HanSuDung":"2026-12-31"}, ...]
--    (HanSuDung có thể là null). Trigger trg_CTPN_CongKho tự cộng tồn kho.
CREATE OR ALTER PROCEDURE sp_NhapKhoTronGoi
    @MaNCC VARCHAR(20),
    @MaNV VARCHAR(20),
    @GhiChu NVARCHAR(255) = NULL,
    @DanhSachJson NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRY
        IF ISNULL(ISJSON(@DanhSachJson), 0) <> 1
            THROW 50000, N'Danh sách nguyên liệu không hợp lệ.', 1;
        IF NOT EXISTS (SELECT 1 FROM OPENJSON(@DanhSachJson))
            THROW 50000, N'Phiếu nhập phải có ít nhất một nguyên liệu.', 1;
        IF NOT EXISTS (SELECT 1 FROM NhaCungCap WHERE MaNCC = @MaNCC)
            THROW 50000, N'Nhà cung cấp không tồn tại.', 1;

        BEGIN TRANSACTION;
            DECLARE @Seq BIGINT = NEXT VALUE FOR Seq_PhieuNhap;
            DECLARE @MaPN VARCHAR(20) = 'PN' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);

            INSERT INTO PhieuNhap (MaPN, MaNCC, MaNV, GhiChu)
            VALUES (@MaPN, @MaNCC, @MaNV, @GhiChu);

            INSERT INTO ChiTietPhieuNhap (MaPN, MaNL, SoLuongNhap, DonGiaNhap, HanSuDung)
            SELECT @MaPN, MaNL, SoLuongNhap, DonGiaNhap, HanSuDung
            FROM OPENJSON(@DanhSachJson)
            WITH (
                MaNL        VARCHAR(20)   '$.MaNL',
                SoLuongNhap DECIMAL(12,3) '$.SoLuongNhap',
                DonGiaNhap  DECIMAL(12,2) '$.DonGiaNhap',
                HanSuDung   DATE          '$.HanSuDung'
            );
        COMMIT TRANSACTION;

        SELECT N'Tạo phiếu nhập thành công' AS KetQua, @MaPN AS MaPN;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 7. Cấp quyền
GRANT EXECUTE ON sp_LayDanhSachLoaiNguyenLieu       TO ThuKho;
GRANT EXECUTE ON sp_LayCongThuc                     TO ThuKho;
GRANT EXECUTE ON sp_LayChiTietPhieuNhap             TO ThuKho;
GRANT EXECUTE ON sp_XoaNguyenLieu                   TO ThuKho;
GRANT EXECUTE ON sp_XoaNCC                          TO ThuKho;
GRANT EXECUTE ON sp_NhapKhoTronGoi                  TO ThuKho;
-- Thủ kho cần danh sách thức uống để mở FormCongThuc
GRANT EXECUTE ON sp_LayDanhSachThucUongTheoLoai     TO ThuKho;
GRANT EXECUTE ON sp_LayDanhSachLoaiThucUong         TO ThuKho;
-- Kế toán cần danh sách NCC để chọn khi chi tiền (TV4 phụ thuộc dòng này)
GRANT EXECUTE ON sp_LayDanhSachNCC                  TO KeToan;
GO

/*
-- =========================================================================
-- CÁC CÂU LỆNH KIỂM TRA (CHẠY TRONG SSMS ĐỂ XÁC MINH PATCH)
-- =========================================================================

EXEC sp_LayDanhSachLoaiNguyenLieu;          -- mong đợi 6 dòng
EXEC sp_LayCongThuc 'TU01';                  -- mong đợi 4 dòng (NL01, NL10, NL18, NL19)
EXEC sp_LayChiTietPhieuNhap 'PN000001';      -- mong đợi 4 dòng (NL01..NL04)

-- Thử transaction trọn gói: nguyên liệu NLXXX không tồn tại nên PHẢI báo lỗi và KHÔNG tạo phiếu, KHÔNG đổi tồn kho
SELECT COUNT(*) AS SoPhieuTruoc FROM PhieuNhap;
EXEC sp_NhapKhoTronGoi @MaNCC='NCC01', @MaNV='NV005', @GhiChu=N'thu loi',
     @DanhSachJson=N'[{"MaNL":"NL01","SoLuongNhap":10,"DonGiaNhap":95},{"MaNL":"NLXXX","SoLuongNhap":5,"DonGiaNhap":10}]';
SELECT COUNT(*) AS SoPhieuSau FROM PhieuNhap;      -- phải bằng SoPhieuTruoc

-- Thử quyền Thủ kho
EXECUTE AS LOGIN = 'login_thukho';
EXEC sp_LayCongThuc 'TU01';
EXEC sp_LayDanhSachLoaiThucUong;
REVERT;
*/

