create database quanlyquancafe;
go

use quanlyquancafe;
go

-- =====================================================================
-- CSDL_HQT_FULL.SQL — FILE CSDL HOÀN CHỈNH ĐÃ FIX LỖI VÀ BỔ SUNG CRUD
-- =====================================================================

-- ############### PHẦN A: 16 BẢNG GỐC + 2 VIEW BAN ĐẦU ###############

CREATE TABLE LoaiKhach (
    MaLoaiKH VARCHAR(20) PRIMARY KEY CHECK (MaLoaiKH LIKE 'LKH%'),
    TenLoai NVARCHAR(100) NOT NULL,
    ChietKhau DECIMAL(5, 2) DEFAULT 0 CHECK (ChietKhau >= 0 AND ChietKhau <= 100) 
);

CREATE TABLE NhanVien (
    MaNV VARCHAR(20) PRIMARY KEY CHECK (MaNV LIKE 'NV%'),
    TenNV NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    CONSTRAINT CK_NhanVien_ChucVu CHECK (ChucVu IN (N'Quản lý', N'Phục vụ', N'Thu ngân', N'Thủ kho', N'Kế toán')),
    SoDienThoai VARCHAR(15) UNIQUE,
    CaLamViec NVARCHAR(50),
    MatKhau VARCHAR(255) NOT NULL,
    MaQL VARCHAR(20) NULL,
    CONSTRAINT FK_NhanVien_QuanLy FOREIGN KEY (MaQL)
        REFERENCES NhanVien(MaNV)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT CK_NhanVien_MaQL CHECK (MaQL IS NULL OR MaQL <> MaNV)
);

CREATE TABLE ViTriBan (
    MaViTri VARCHAR(20) PRIMARY KEY CHECK (MaViTri LIKE 'VT%'),
    TenViTri NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE LoaiThucUong (
    MaLoaiTU VARCHAR(20) PRIMARY KEY CHECK (MaLoaiTU LIKE 'LTU%'),
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE LoaiNguyenLieu (
    MaLoaiNL VARCHAR(20) PRIMARY KEY CHECK (MaLoaiNL LIKE 'LNL%'),
    TenLoai NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(50) NOT NULL
);

CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(20) PRIMARY KEY CHECK (MaNCC LIKE 'NCC%'),
    TenNCC NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100)
);

CREATE TABLE Khach (
    MaKH VARCHAR(20) PRIMARY KEY CHECK (MaKH LIKE 'KH%'),
    TenKH NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    DiemTichLuy INT DEFAULT 0 CHECK (DiemTichLuy >= 0),
    MaLoaiKH VARCHAR(20) NOT NULL,
    CONSTRAINT FK_Khach_LoaiKhach FOREIGN KEY (MaLoaiKH) 
        REFERENCES LoaiKhach(MaLoaiKH)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE Ban (
    MaBan VARCHAR(20) PRIMARY KEY CHECK (MaBan LIKE 'B%'),
    SoBan INT NOT NULL,
    SoChoNgoi INT NOT NULL CHECK (SoChoNgoi > 0),
    TrangThai NVARCHAR(50) DEFAULT N'TRONG' CHECK (TrangThai IN (N'TRONG', N'COKHACH', N'DATTRUOC')),
    MaViTri VARCHAR(20) NOT NULL,
    CONSTRAINT UQ_Ban_SoBan UNIQUE (SoBan),
    CONSTRAINT FK_Ban_ViTriBan FOREIGN KEY (MaViTri) 
        REFERENCES ViTriBan(MaViTri)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE ThucUong (
    MaThucUong VARCHAR(20) PRIMARY KEY CHECK (MaThucUong LIKE 'TU%'),
    TenThucUong NVARCHAR(150) NOT NULL,
    DonGiaBan DECIMAL(12, 2) NOT NULL CHECK (DonGiaBan > 0),
    HinhAnh VARCHAR(255),
    MaLoaiTU VARCHAR(20) NOT NULL,
    CONSTRAINT FK_ThucUong_LoaiThucUong FOREIGN KEY (MaLoaiTU) 
        REFERENCES LoaiThucUong(MaLoaiTU)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE NguyenLieu (
    MaNL VARCHAR(20) PRIMARY KEY CHECK (MaNL LIKE 'NL%'),
    TenNL NVARCHAR(150) NOT NULL,
    SoLuongTonKho DECIMAL(12, 3) DEFAULT 0 CHECK (SoLuongTonKho >= 0),
    MucToiThieu DECIMAL(12, 3) DEFAULT 5.0 CHECK (MucToiThieu >= 0),
    MaLoaiNL VARCHAR(20) NOT NULL,
    CONSTRAINT FK_NguyenLieu_LoaiNguyenLieu FOREIGN KEY (MaLoaiNL) 
        REFERENCES LoaiNguyenLieu(MaLoaiNL)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE PhieuChi (
    MaPC VARCHAR(20) PRIMARY KEY CHECK (MaPC LIKE 'PC%'),
    NgayChi DATETIME NOT NULL DEFAULT GETDATE(),
    SoTienChi DECIMAL(12, 2) NOT NULL CHECK (SoTienChi > 0),
    LyDoChi NVARCHAR(255),
    MaNCC VARCHAR(20) NULL,
    MaNV VARCHAR(20) NOT NULL,
    CONSTRAINT FK_PhieuChi_NhaCungCap FOREIGN KEY (MaNCC) 
        REFERENCES NhaCungCap(MaNCC)
        ON UPDATE CASCADE
        ON DELETE SET NULL,
    CONSTRAINT FK_PhieuChi_NhanVien FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE PhieuNhap (
    MaPN VARCHAR(20) PRIMARY KEY CHECK (MaPN LIKE 'PN%'),
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    GhiChu NVARCHAR(255),
    MaNCC VARCHAR(20) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY (MaNCC) 
        REFERENCES NhaCungCap(MaNCC)
        ON UPDATE CASCADE
        ON DELETE NO ACTION,
    CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE HoaDon (
    MaHD VARCHAR(20) PRIMARY KEY CHECK (MaHD LIKE 'HD%'),
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    NgayThanhToan DATETIME NULL,
    TienGiamGia DECIMAL(12, 2) DEFAULT 0 CHECK (TienGiamGia >= 0),
    DiemTichLuyCong INT DEFAULT 0 CHECK (DiemTichLuyCong >= 0),
    MaKH VARCHAR(20) NULL,
    MaNV VARCHAR(20) NOT NULL,
    MaBan VARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Chưa thanh toán' 
        CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy')), 
    PhuongThucThanhToan NVARCHAR(50) DEFAULT N'Tiền mặt'
        CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử')), 
    CONSTRAINT FK_HoaDon_Khach FOREIGN KEY (MaKH) 
        REFERENCES Khach(MaKH)
        ON UPDATE CASCADE
        ON DELETE SET NULL,
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) 
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
        ON DELETE NO ACTION,
    CONSTRAINT FK_HoaDon_Ban FOREIGN KEY (MaBan) 
        REFERENCES Ban(MaBan)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE ChiTietHoaDon (
    MaHD VARCHAR(20),
    MaThucUong VARCHAR(20),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(12, 2) NOT NULL CHECK (DonGia > 0),
    ThanhTien AS (SoLuong * DonGia),
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaThucUong),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHD) 
        REFERENCES HoaDon(MaHD)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    CONSTRAINT FK_CTHD_ThucUong FOREIGN KEY (MaThucUong) 
        REFERENCES ThucUong(MaThucUong)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE CongThuc (
    MaThucUong VARCHAR(20),
    MaNL VARCHAR(20),
    SoLuongQuyDinh DECIMAL(12, 3) NOT NULL CHECK (SoLuongQuyDinh > 0), 
    CONSTRAINT PK_CongThuc PRIMARY KEY (MaThucUong, MaNL),
    CONSTRAINT FK_CongThuc_ThucUong FOREIGN KEY (MaThucUong) 
        REFERENCES ThucUong(MaThucUong)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    CONSTRAINT FK_CongThuc_NguyenLieu FOREIGN KEY (MaNL) 
        REFERENCES NguyenLieu(MaNL)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);

CREATE TABLE ChiTietPhieuNhap (
    MaPN VARCHAR(20),
    MaNL VARCHAR(20),
    SoLuongNhap DECIMAL(12, 3) NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(12, 2) NOT NULL CHECK (DonGiaNhap > 0),
    ThanhTien AS (SoLuongNhap * DonGiaNhap),
    HanSuDung DATE,
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPN, MaNL),
    CONSTRAINT FK_CTPN_PhieuNhap FOREIGN KEY (MaPN) 
        REFERENCES PhieuNhap(MaPN)
        ON UPDATE CASCADE
        ON DELETE CASCADE,
    CONSTRAINT FK_CTPN_NguyenLieu FOREIGN KEY (MaNL) 
        REFERENCES NguyenLieu(MaNL)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- =====================================================================
-- SEQUENCES: CHỐNG XUNG ĐỘT TRÙNG MÃ KHI TẠO ĐƠN ĐỒNG THỜI
-- =====================================================================

CREATE SEQUENCE Seq_HoaDon
    START WITH 1
    INCREMENT BY 1
    NO CYCLE;
GO

CREATE SEQUENCE Seq_PhieuNhap
    START WITH 1
    INCREMENT BY 1
    NO CYCLE;
GO

CREATE SEQUENCE Seq_Khach
    START WITH 1
    INCREMENT BY 1
    NO CYCLE;
GO

CREATE SEQUENCE Seq_PhieuChi
    START WITH 1
    INCREMENT BY 1
    NO CYCLE;
GO

-- =====================================================================
-- PHẦN B: VIEWS
-- =====================================================================

CREATE OR ALTER VIEW v_PhieuNhap AS
SELECT 
    pn.MaPN,
    pn.NgayNhap,
    pn.GhiChu,
    pn.MaNCC,
    pn.MaNV,
    COALESCE(SUM(ct.ThanhTien), 0) AS TongTien
FROM PhieuNhap pn
LEFT JOIN ChiTietPhieuNhap ct ON pn.MaPN = ct.MaPN
GROUP BY pn.MaPN, pn.NgayNhap, pn.GhiChu, pn.MaNCC, pn.MaNV;
GO

CREATE OR ALTER VIEW v_HoaDon AS
SELECT 
    hd.MaHD,
    hd.NgayLap,
    hd.NgayThanhToan,
    hd.MaKH,
    hd.MaNV,
    hd.MaBan,
    hd.TrangThai,
    hd.PhuongThucThanhToan,
    COALESCE(SUM(ct.ThanhTien), 0) AS TongTienHang,
    hd.TienGiamGia,
    CASE 
        WHEN COALESCE(SUM(ct.ThanhTien), 0) - hd.TienGiamGia < 0 THEN 0
        ELSE COALESCE(SUM(ct.ThanhTien), 0) - hd.TienGiamGia 
    END AS TongTienThanhToan,
    hd.DiemTichLuyCong
FROM HoaDon hd
LEFT JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
GROUP BY 
    hd.MaHD, hd.NgayLap, hd.NgayThanhToan, hd.MaKH, 
    hd.MaNV, hd.MaBan, hd.TrangThai, hd.PhuongThucThanhToan, 
    hd.TienGiamGia, hd.DiemTichLuyCong;
GO

CREATE OR ALTER VIEW v_MonBanChay AS
SELECT
    tu.MaThucUong,
    tu.TenThucUong,
    SUM(ct.SoLuong)   AS TongSoLuongBan,
    SUM(ct.ThanhTien) AS TongDoanhThu
FROM ChiTietHoaDon ct
JOIN ThucUong tu ON tu.MaThucUong = ct.MaThucUong
JOIN HoaDon hd   ON hd.MaHD = ct.MaHD
WHERE hd.TrangThai = N'Đã thanh toán'
GROUP BY tu.MaThucUong, tu.TenThucUong;
GO

CREATE OR ALTER VIEW v_TonKhoCanhBao AS
SELECT
    nl.MaNL,
    nl.TenNL,
    nl.SoLuongTonKho,
    nl.MucToiThieu,
    lnl.TenLoai AS LoaiNguyenLieu
FROM NguyenLieu nl
JOIN LoaiNguyenLieu lnl ON lnl.MaLoaiNL = nl.MaLoaiNL
WHERE nl.SoLuongTonKho < nl.MucToiThieu;
GO

CREATE OR ALTER VIEW v_DoanhThuTheoNgay AS
SELECT
    CAST(hd.NgayLap AS DATE) AS Ngay,
    COUNT(DISTINCT hd.MaHD)  AS SoHoaDon,
    SUM(ct.ThanhTien)        AS TongDoanhThu
FROM HoaDon hd
JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
WHERE hd.TrangThai = N'Đã thanh toán'
GROUP BY CAST(hd.NgayLap AS DATE);
GO

CREATE OR ALTER VIEW v_KhachHangThanThiet AS
SELECT
    kh.MaKH,
    kh.TenKH,
    kh.DiemTichLuy,
    lkh.TenLoai AS LoaiKhachHang,
    lkh.ChietKhau
FROM Khach kh
JOIN LoaiKhach lkh ON lkh.MaLoaiKH = kh.MaLoaiKH;
GO

-- =====================================================================
-- PHẦN C: TRIGGERS
-- =====================================================================

CREATE OR ALTER TRIGGER trg_CTHD_TruKho
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN CongThuc ct ON ct.MaThucUong = i.MaThucUong
        JOIN NguyenLieu nl ON nl.MaNL = ct.MaNL
        GROUP BY nl.MaNL, nl.SoLuongTonKho
        HAVING nl.SoLuongTonKho < SUM(ct.SoLuongQuyDinh * i.SoLuong)
    )
    BEGIN
        RAISERROR(N'Không đủ nguyên liệu tồn kho để pha chế món đã chọn.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE nl
    SET nl.SoLuongTonKho = nl.SoLuongTonKho - x.SoLuongCan
    FROM NguyenLieu nl
    JOIN (
        SELECT ct.MaNL, SUM(ct.SoLuongQuyDinh * i.SoLuong) AS SoLuongCan
        FROM inserted i
        JOIN CongThuc ct ON ct.MaThucUong = i.MaThucUong
        GROUP BY ct.MaNL
    ) x ON x.MaNL = nl.MaNL;
END
GO

CREATE OR ALTER TRIGGER trg_CTPN_CongKho
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE nl
    SET nl.SoLuongTonKho = nl.SoLuongTonKho + x.TongNhap
    FROM NguyenLieu nl
    JOIN (
        SELECT MaNL, SUM(SoLuongNhap) AS TongNhap
        FROM inserted
        GROUP BY MaNL
    ) x ON x.MaNL = nl.MaNL;
END
GO

CREATE OR ALTER TRIGGER trg_HoaDon_TaoDon_CapNhatBan
ON HoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE b
    SET b.TrangThai = N'COKHACH'
    FROM Ban b
    JOIN inserted i ON i.MaBan = b.MaBan
    WHERE b.TrangThai = N'TRONG';
END
GO

CREATE OR ALTER TRIGGER trg_HoaDon_ThanhToan_CapNhatBanVaDiem
ON HoaDon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TrangThai)
    BEGIN
        UPDATE b
        SET b.TrangThai = N'TRONG'
        FROM Ban b
        JOIN inserted i ON i.MaBan = b.MaBan
        JOIN deleted d ON d.MaHD = i.MaHD
        WHERE i.TrangThai = N'Đã thanh toán'
          AND d.TrangThai <> N'Đã thanh toán';

        UPDATE kh
        SET kh.DiemTichLuy = kh.DiemTichLuy + i.DiemTichLuyCong
        FROM Khach kh
        JOIN inserted i ON i.MaKH = kh.MaKH
        JOIN deleted d ON d.MaHD = i.MaHD
        WHERE i.TrangThai = N'Đã thanh toán'
          AND d.TrangThai <> N'Đã thanh toán'
          AND i.MaKH IS NOT NULL;
    END
END
GO

CREATE OR ALTER TRIGGER trg_HoaDon_Huy_HoanKho
ON HoaDon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TrangThai)
    BEGIN
        UPDATE nl
        SET nl.SoLuongTonKho = nl.SoLuongTonKho + x.SoLuongHoan
        FROM NguyenLieu nl
        JOIN (
            SELECT congthuc.MaNL, SUM(congthuc.SoLuongQuyDinh * cthd.SoLuong) AS SoLuongHoan
            FROM inserted i
            JOIN deleted d ON d.MaHD = i.MaHD
            JOIN ChiTietHoaDon cthd ON cthd.MaHD = i.MaHD
            JOIN CongThuc congthuc ON congthuc.MaThucUong = cthd.MaThucUong
            WHERE i.TrangThai = N'Đã hủy' AND d.TrangThai <> N'Đã hủy'
            GROUP BY congthuc.MaNL
        ) x ON x.MaNL = nl.MaNL;

        UPDATE b
        SET b.TrangThai = N'TRONG'
        FROM Ban b
        JOIN inserted i ON i.MaBan = b.MaBan
        JOIN deleted d ON d.MaHD = i.MaHD
        WHERE i.TrangThai = N'Đã hủy' AND d.TrangThai <> N'Đã hủy';
    END
END
GO

CREATE OR ALTER TRIGGER trg_CTHD_DieuChinhKho
ON ChiTietHoaDon
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE nl
        SET nl.SoLuongTonKho = nl.SoLuongTonKho + x.SoLuongHoan
        FROM NguyenLieu nl
        JOIN (
            SELECT ct.MaNL, SUM(ct.SoLuongQuyDinh * d.SoLuong) AS SoLuongHoan
            FROM deleted d
            JOIN CongThuc ct ON ct.MaThucUong = d.MaThucUong
            JOIN HoaDon hd ON hd.MaHD = d.MaHD
            WHERE hd.TrangThai = N'Chưa thanh toán'
            GROUP BY ct.MaNL
        ) x ON x.MaNL = nl.MaNL;
    END

    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE nl
        SET nl.SoLuongTonKho = nl.SoLuongTonKho - x.ChenhLech
        FROM NguyenLieu nl
        JOIN (
            SELECT ct.MaNL, SUM(ct.SoLuongQuyDinh * (i.SoLuong - d.SoLuong)) AS ChenhLech
            FROM inserted i
            JOIN deleted d ON i.MaHD = d.MaHD AND i.MaThucUong = d.MaThucUong
            JOIN CongThuc ct ON ct.MaThucUong = i.MaThucUong
            JOIN HoaDon hd ON hd.MaHD = i.MaHD
            WHERE hd.TrangThai = N'Chưa thanh toán'
            GROUP BY ct.MaNL
        ) x ON x.MaNL = nl.MaNL;
    END
END
GO

-- =====================================================================
-- PHẦN D: INDEX
-- =====================================================================

CREATE INDEX IX_HoaDon_NgayLap ON HoaDon(NgayLap);
GO

CREATE INDEX IX_HoaDon_MaKH ON HoaDon(MaKH);
GO

CREATE INDEX IX_CTHD_MaThucUong ON ChiTietHoaDon(MaThucUong);
GO

CREATE INDEX IX_NguyenLieu_TonKho ON NguyenLieu(SoLuongTonKho);
GO

CREATE INDEX IX_CTPN_HanSuDung ON ChiTietPhieuNhap(HanSuDung);
GO

-- =====================================================================
-- PHẦN E: FUNCTIONS
-- =====================================================================

CREATE OR ALTER FUNCTION fn_TinhThanhTienHoaDon (@MaHD VARCHAR(20))
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(12,2);
    SELECT @TongTien = SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHD = @MaHD;
    RETURN ISNULL(@TongTien, 0);
END
GO

CREATE OR ALTER FUNCTION fn_KiemTraDuNguyenLieu (@MaThucUong VARCHAR(20), @SoLuong INT)
RETURNS BIT
AS
BEGIN
    DECLARE @KetQua BIT = 1;

    IF EXISTS (
        SELECT 1
        FROM CongThuc ct
        JOIN NguyenLieu nl ON nl.MaNL = ct.MaNL
        WHERE ct.MaThucUong = @MaThucUong
          AND nl.SoLuongTonKho < ct.SoLuongQuyDinh * @SoLuong
    )
        SET @KetQua = 0;

    RETURN @KetQua;
END
GO

CREATE OR ALTER FUNCTION fn_ChietKhauTheoLoaiKH (@MaKH VARCHAR(20))
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @ChietKhau DECIMAL(5,2);
    SELECT @ChietKhau = lkh.ChietKhau
    FROM Khach kh
    JOIN LoaiKhach lkh ON lkh.MaLoaiKH = kh.MaLoaiKH
    WHERE kh.MaKH = @MaKH;
    RETURN ISNULL(@ChietKhau, 0);
END
GO

CREATE OR ALTER FUNCTION fn_MonBanChayNhat (@TuNgay DATE, @DenNgay DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 10
        tu.MaThucUong,
        tu.TenThucUong,
        SUM(ct.SoLuong) AS TongSoLuongBan
    FROM ChiTietHoaDon ct
    JOIN HoaDon hd ON hd.MaHD = ct.MaHD
    JOIN ThucUong tu ON tu.MaThucUong = ct.MaThucUong
    WHERE hd.TrangThai = N'Đã thanh toán'
      AND CAST(hd.NgayLap AS DATE) BETWEEN @TuNgay AND @DenNgay
    GROUP BY tu.MaThucUong, tu.TenThucUong
);
GO

CREATE OR ALTER FUNCTION fn_LichSuMuaHang (@MaKH VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT
        hd.MaHD,
        hd.NgayLap,
        hd.TrangThai,
        dbo.fn_TinhThanhTienHoaDon(hd.MaHD) AS TongTien
    FROM HoaDon hd
    WHERE hd.MaKH = @MaKH
);
GO

CREATE OR ALTER FUNCTION fn_SinhMaTuDong (@TienTo VARCHAR(5))
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @MaMoi VARCHAR(20);
    DECLARE @MaxID INT = 0;

    IF @TienTo = 'HD'
        SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaHD, 3, 10) AS INT)), 0) FROM HoaDon;
    ELSE IF @TienTo = 'PN'
        SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaPN, 3, 10) AS INT)), 0) FROM PhieuNhap;
    ELSE IF @TienTo = 'KH'
        SELECT @MaxID = ISNULL(MAX(CAST(SUBSTRING(MaKH, 3, 10) AS INT)), 0) FROM Khach;

    SET @MaMoi = @TienTo + RIGHT('000000' + CAST(@MaxID + 1 AS VARCHAR(10)), 6);
    RETURN @MaMoi;
END
GO

-- =====================================================================
-- PHẦN F: STORED PROCEDURES (BỔ SUNG VÀ HOÀN CHỈNH)
-- =====================================================================

-- 1. Tạo hóa đơn (Dùng sequence tự sinh mã chống race condition)
CREATE OR ALTER PROCEDURE sp_TaoHoaDon
    @MaHD  VARCHAR(20) = NULL OUTPUT,
    @MaKH  VARCHAR(20) = NULL,
    @MaNV  VARCHAR(20),
    @MaBan VARCHAR(20),
    @PhuongThucThanhToan NVARCHAR(50) = N'Tiền mặt'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM Ban WHERE MaBan = @MaBan AND TrangThai <> N'TRONG')
        BEGIN
            THROW 50000, N'Bàn đang có khách hoặc đã được đặt trước.', 1;
        END

        IF @MaHD IS NULL OR LTRIM(RTRIM(@MaHD)) = ''
        BEGIN
            DECLARE @SeqVal BIGINT = NEXT VALUE FOR Seq_HoaDon;
            SET @MaHD = 'HD' + RIGHT('000000' + CAST(@SeqVal AS VARCHAR(10)), 6);
        END

        INSERT INTO HoaDon (MaHD, MaKH, MaNV, MaBan, PhuongThucThanhToan)
        VALUES (@MaHD, @MaKH, @MaNV, @MaBan, @PhuongThucThanhToan);

        COMMIT TRANSACTION;
        SELECT N'Tạo hóa đơn thành công' AS KetQua, @MaHD AS MaHD;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 2. Thêm món vào hóa đơn
CREATE OR ALTER PROCEDURE sp_ThemMonVaoHoaDon
    @MaHD VARCHAR(20),
    @MaThucUong VARCHAR(20),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = @MaHD AND TrangThai = N'Chưa thanh toán')
            THROW 50000, N'Hóa đơn không tồn tại hoặc không ở trạng thái chưa thanh toán.', 1;

        DECLARE @DonGia DECIMAL(12,2);
        SELECT @DonGia = DonGiaBan FROM ThucUong WHERE MaThucUong = @MaThucUong;

        IF @DonGia IS NULL
            THROW 50000, N'Thức uống không tồn tại.', 1;

        IF EXISTS (
            SELECT 1
            FROM CongThuc ct WITH (UPDLOCK, HOLDLOCK)
            JOIN NguyenLieu nl WITH (UPDLOCK, HOLDLOCK) ON nl.MaNL = ct.MaNL
            WHERE ct.MaThucUong = @MaThucUong
              AND nl.SoLuongTonKho < (ct.SoLuongQuyDinh * @SoLuong)
        )
            THROW 50000, N'Không đủ nguyên liệu để pha chế món này.', 1;

        IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaThucUong = @MaThucUong)
        BEGIN
            UPDATE ChiTietHoaDon
            SET SoLuong = SoLuong + @SoLuong
            WHERE MaHD = @MaHD AND MaThucUong = @MaThucUong;
        END
        ELSE
        BEGIN
            INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, DonGia)
            VALUES (@MaHD, @MaThucUong, @SoLuong, @DonGia);
        END

        COMMIT TRANSACTION;
        SELECT N'Thêm món thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 3. Thanh toán hóa đơn (Đã fix kiểm tra trạng thái và nhận phương thức thanh toán)
CREATE OR ALTER PROCEDURE sp_ThanhToanHoaDon
    @MaHD VARCHAR(20),
    @TienGiamGia DECIMAL(12,2) = NULL,
    @PhuongThucThanhToan NVARCHAR(50) = N'Tiền mặt'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @TrangThaiHienTai NVARCHAR(50);
        DECLARE @MaKH VARCHAR(20);
        DECLARE @TongTienHang DECIMAL(12,2) = 0;
        DECLARE @ChietKhau DECIMAL(5,2) = 0;
        DECLARE @TongThanhToan DECIMAL(12,2);
        DECLARE @DiemCong INT;

        SELECT @TrangThaiHienTai = TrangThai, @MaKH = MaKH
        FROM HoaDon WITH (UPDLOCK, HOLDLOCK)
        WHERE MaHD = @MaHD;

        IF @TrangThaiHienTai IS NULL
            THROW 50000, N'Hóa đơn không tồn tại.', 1;

        IF @TrangThaiHienTai <> N'Chưa thanh toán'
            THROW 50000, N'Hóa đơn này đã được thanh toán hoặc đã bị hủy trước đó.', 1;

        IF @PhuongThucThanhToan NOT IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử')
            THROW 50000, N'Phương thức thanh toán không hợp lệ.', 1;

        SELECT @TongTienHang = dbo.fn_TinhThanhTienHoaDon(@MaHD);

        IF @MaKH IS NOT NULL
            SET @ChietKhau = dbo.fn_ChietKhauTheoLoaiKH(@MaKH);

        IF @TienGiamGia IS NULL
            SET @TienGiamGia = ROUND(@TongTienHang * @ChietKhau / 100.0, 0);

        SET @TongThanhToan = @TongTienHang - @TienGiamGia;
        IF @TongThanhToan < 0 SET @TongThanhToan = 0;

        SET @DiemCong = CAST(@TongThanhToan / 10000 AS INT);

        UPDATE HoaDon
        SET TrangThai = N'Đã thanh toán',
            NgayThanhToan = GETDATE(),
            TienGiamGia = @TienGiamGia,
            DiemTichLuyCong = @DiemCong,
            PhuongThucThanhToan = @PhuongThucThanhToan
        WHERE MaHD = @MaHD;

        COMMIT TRANSACTION;
        SELECT N'Thanh toán thành công' AS KetQua, @TongThanhToan AS TongTienThanhToan;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 4. Hủy hóa đơn
CREATE OR ALTER PROCEDURE sp_HuyHoaDon
    @MaHD VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = @MaHD AND TrangThai = N'Chưa thanh toán')
        BEGIN
            THROW 50000, N'Chỉ có thể hủy hóa đơn đang ở trạng thái chưa thanh toán.', 1;
        END

        UPDATE HoaDon SET TrangThai = N'Đã hủy' WHERE MaHD = @MaHD;

        COMMIT TRANSACTION;
        SELECT N'Hủy hóa đơn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 5. Tạo phiếu nhập kho (Dùng sequence tự sinh mã nếu rỗng)
CREATE OR ALTER PROCEDURE sp_NhapKho
    @MaPN VARCHAR(20) = NULL OUTPUT,
    @MaNCC VARCHAR(20),
    @MaNV VARCHAR(20),
    @GhiChu NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @MaPN IS NULL OR LTRIM(RTRIM(@MaPN)) = ''
        BEGIN
            DECLARE @SeqVal BIGINT = NEXT VALUE FOR Seq_PhieuNhap;
            SET @MaPN = 'PN' + RIGHT('000000' + CAST(@SeqVal AS VARCHAR(10)), 6);
        END

        INSERT INTO PhieuNhap (MaPN, MaNCC, MaNV, GhiChu)
        VALUES (@MaPN, @MaNCC, @MaNV, @GhiChu);

        COMMIT TRANSACTION;
        SELECT N'Tạo phiếu nhập thành công' AS KetQua, @MaPN AS MaPN;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 6. Thêm chi tiết phiếu nhập
CREATE OR ALTER PROCEDURE sp_ThemChiTietPhieuNhap
    @MaPN VARCHAR(20),
    @MaNL VARCHAR(20),
    @SoLuongNhap DECIMAL(12,3),
    @DonGiaNhap DECIMAL(12,2),
    @HanSuDung DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM PhieuNhap WHERE MaPN = @MaPN)
        BEGIN
            THROW 50000, N'Phiếu nhập không tồn tại.', 1;
        END

        INSERT INTO ChiTietPhieuNhap (MaPN, MaNL, SoLuongNhap, DonGiaNhap, HanSuDung)
        VALUES (@MaPN, @MaNL, @SoLuongNhap, @DonGiaNhap, @HanSuDung);

        COMMIT TRANSACTION;
        SELECT N'Thêm chi tiết phiếu nhập thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 7. Ghi nhận chi tiền
CREATE OR ALTER PROCEDURE sp_ChiTienNCC
    @MaPC VARCHAR(20) = NULL OUTPUT,
    @SoTienChi DECIMAL(12,2),
    @LyDoChi NVARCHAR(255),
    @MaNV VARCHAR(20),
    @MaNCC VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @SoTienChi <= 0
            THROW 50000, N'Số tiền chi phải lớn hơn 0.', 1;

        IF @MaPC IS NULL OR LTRIM(RTRIM(@MaPC)) = ''
        BEGIN
            DECLARE @SeqVal BIGINT = NEXT VALUE FOR Seq_PhieuChi;
            SET @MaPC = 'PC' + RIGHT('000000' + CAST(@SeqVal AS VARCHAR(10)), 6);
        END

        INSERT INTO PhieuChi (MaPC, SoTienChi, LyDoChi, MaNCC, MaNV)
        VALUES (@MaPC, @SoTienChi, @LyDoChi, @MaNCC, @MaNV);

        COMMIT TRANSACTION;
        SELECT N'Ghi nhận chi tiền thành công' AS KetQua, @MaPC AS MaPC;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 8. Tìm kiếm thức uống
CREATE OR ALTER PROCEDURE sp_TimKiemThucUong
    @TuKhoa NVARCHAR(150) = NULL,
    @MaLoaiTU VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tu.MaThucUong, tu.TenThucUong, tu.DonGiaBan, tu.HinhAnh, tu.MaLoaiTU, ltu.TenLoai AS LoaiThucUong
    FROM ThucUong tu
    JOIN LoaiThucUong ltu ON ltu.MaLoaiTU = tu.MaLoaiTU
    WHERE (@TuKhoa IS NULL OR tu.TenThucUong LIKE N'%' + @TuKhoa + '%')
      AND (@MaLoaiTU IS NULL OR tu.MaLoaiTU = @MaLoaiTU);
END
GO

-- 9. Thống kê doanh thu
CREATE OR ALTER PROCEDURE sp_ThongKeDoanhThu
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        CAST(hd.NgayLap AS DATE) AS Ngay,
        COUNT(DISTINCT hd.MaHD)  AS SoHoaDon,
        SUM(ct.ThanhTien)        AS TongDoanhThu
    FROM HoaDon hd
    JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
    WHERE hd.TrangThai = N'Đã thanh toán'
      AND CAST(hd.NgayLap AS DATE) BETWEEN @TuNgay AND @DenNgay
    GROUP BY CAST(hd.NgayLap AS DATE)
    ORDER BY Ngay;
END
GO

-- 10. Đăng nhập nhân viên
CREATE OR ALTER PROCEDURE sp_DangNhap
    @SoDienThoai VARCHAR(15),
    @MatKhau VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV, TenNV, ChucVu
    FROM NhanVien
    WHERE SoDienThoai = @SoDienThoai
      AND MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2);
END
GO

-- 11. Đổi mật khẩu nhân viên
CREATE OR ALTER PROCEDURE sp_DoiMatKhau
    @MaNV VARCHAR(20),
    @MatKhauCu VARCHAR(255),
    @MatKhauMoi VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DECLARE @MKCuHash VARCHAR(64) = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhauCu), 2);
        DECLARE @MKMoiHash VARCHAR(64) = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhauMoi), 2);

        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV AND MatKhau = @MKCuHash)
            THROW 50000, N'Mật khẩu cũ không chính xác.', 1;

        UPDATE NhanVien
        SET MatKhau = @MKMoiHash
        WHERE MaNV = @MaNV;

        SELECT N'Đổi mật khẩu thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 12. Lấy danh sách bàn
CREATE OR ALTER PROCEDURE sp_LayDanhSachBan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT b.MaBan, b.SoBan, b.SoChoNgoi, b.TrangThai, b.MaViTri, vt.TenViTri
    FROM Ban b
    JOIN ViTriBan vt ON vt.MaViTri = b.MaViTri
    ORDER BY b.SoBan;
END
GO

-- 13. Lấy hóa đơn đang mở theo bàn
CREATE OR ALTER PROCEDURE sp_LayHoaDonDangMoTheoBan
    @MaBan VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 MaHD, NgayLap, MaNV, MaKH, TienGiamGia, PhuongThucThanhToan
    FROM HoaDon
    WHERE MaBan = @MaBan AND TrangThai = N'Chưa thanh toán';
END
GO

-- 14. Lấy chi tiết hóa đơn
CREATE OR ALTER PROCEDURE sp_LayChiTietHoaDon
    @MaHD VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        ct.MaThucUong,
        tu.TenThucUong,
        ct.SoLuong,
        ct.DonGia,
        ct.ThanhTien
    FROM ChiTietHoaDon ct
    JOIN ThucUong tu ON tu.MaThucUong = ct.MaThucUong
    WHERE ct.MaHD = @MaHD;
END
GO

-- 15. Cập nhật số lượng món
CREATE OR ALTER PROCEDURE sp_CapNhatSoLuongMon
    @MaHD VARCHAR(20),
    @MaThucUong VARCHAR(20),
    @SoLuongMoi INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM HoaDon WHERE MaHD = @MaHD AND TrangThai = N'Chưa thanh toán')
            THROW 50000, N'Hóa đơn không tồn tại hoặc không ở trạng thái chưa thanh toán.', 1;

        IF NOT EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaThucUong = @MaThucUong)
            THROW 50000, N'Món này chưa có trong hóa đơn.', 1;

        IF @SoLuongMoi <= 0
        BEGIN
            DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaThucUong = @MaThucUong;
        END
        ELSE
        BEGIN
            UPDATE ChiTietHoaDon
            SET SoLuong = @SoLuongMoi
            WHERE MaHD = @MaHD AND MaThucUong = @MaThucUong;
        END

        COMMIT TRANSACTION;
        SELECT N'Cập nhật số lượng thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- 16. Thêm thức uống
CREATE OR ALTER PROCEDURE sp_ThemThucUong
    @MaThucUong VARCHAR(20),
    @TenThucUong NVARCHAR(150),
    @DonGiaBan DECIMAL(12,2),
    @MaLoaiTU VARCHAR(20),
    @HinhAnh VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO ThucUong (MaThucUong, TenThucUong, DonGiaBan, HinhAnh, MaLoaiTU)
        VALUES (@MaThucUong, @TenThucUong, @DonGiaBan, @HinhAnh, @MaLoaiTU);
        SELECT N'Thêm thức uống thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 17. Sửa thức uống
CREATE OR ALTER PROCEDURE sp_SuaThucUong
    @MaThucUong VARCHAR(20),
    @TenThucUong NVARCHAR(150),
    @DonGiaBan DECIMAL(12,2),
    @MaLoaiTU VARCHAR(20),
    @HinhAnh VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM ThucUong WHERE MaThucUong = @MaThucUong)
            THROW 50000, N'Thức uống không tồn tại.', 1;

        UPDATE ThucUong
        SET TenThucUong = @TenThucUong,
            DonGiaBan = @DonGiaBan,
            MaLoaiTU = @MaLoaiTU,
            HinhAnh = ISNULL(@HinhAnh, HinhAnh)
        WHERE MaThucUong = @MaThucUong;

        SELECT N'Cập nhật thức uống thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 18. Xóa thức uống
CREATE OR ALTER PROCEDURE sp_XoaThucUong
    @MaThucUong VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE MaThucUong = @MaThucUong)
            THROW 50000, N'Không thể xóa thức uống đã có phát sinh giao dịch trong hóa đơn.', 1;

        DELETE FROM CongThuc WHERE MaThucUong = @MaThucUong;
        DELETE FROM ThucUong WHERE MaThucUong = @MaThucUong;

        SELECT N'Xóa thức uống thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 19. Lưu / Cập nhật công thức pha chế
CREATE OR ALTER PROCEDURE sp_LuuCongThuc
    @MaThucUong VARCHAR(20),
    @MaNL VARCHAR(20),
    @SoLuongQuyDinh DECIMAL(12,3)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF @SoLuongQuyDinh <= 0
        BEGIN
            DELETE FROM CongThuc WHERE MaThucUong = @MaThucUong AND MaNL = @MaNL;
            SELECT N'Đã xóa nguyên liệu khỏi công thức' AS KetQua;
            RETURN;
        END

        IF EXISTS (SELECT 1 FROM CongThuc WHERE MaThucUong = @MaThucUong AND MaNL = @MaNL)
        BEGIN
            UPDATE CongThuc
            SET SoLuongQuyDinh = @SoLuongQuyDinh
            WHERE MaThucUong = @MaThucUong AND MaNL = @MaNL;
        END
        ELSE
        BEGIN
            INSERT INTO CongThuc (MaThucUong, MaNL, SoLuongQuyDinh)
            VALUES (@MaThucUong, @MaNL, @SoLuongQuyDinh);
        END

        SELECT N'Lưu công thức thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 20. Thêm khách hàng (Dùng SEQUENCE tránh xung đột đồng thời)
CREATE OR ALTER PROCEDURE sp_ThemKhachHang
    @MaKH VARCHAR(20) = NULL OUTPUT,
    @TenKH NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @MaLoaiKH VARCHAR(20) = 'LKH01'
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF @MaKH IS NULL OR LTRIM(RTRIM(@MaKH)) = ''
        BEGIN
            DECLARE @SeqVal BIGINT = NEXT VALUE FOR Seq_Khach;
            SET @MaKH = 'KH' + RIGHT('000000' + CAST(@SeqVal AS VARCHAR(10)), 6);
        END

        INSERT INTO Khach (MaKH, TenKH, SoDienThoai, MaLoaiKH)
        VALUES (@MaKH, @TenKH, @SoDienThoai, @MaLoaiKH);

        SELECT @MaKH AS MaKHMoi;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 21. Sửa khách hàng
CREATE OR ALTER PROCEDURE sp_SuaKhach
    @MaKH VARCHAR(20),
    @TenKH NVARCHAR(100),
    @SoDienThoai VARCHAR(15),
    @MaLoaiKH VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Khach WHERE MaKH = @MaKH)
            THROW 50000, N'Khách hàng không tồn tại.', 1;

        UPDATE Khach
        SET TenKH = @TenKH,
            SoDienThoai = @SoDienThoai,
            MaLoaiKH = @MaLoaiKH
        WHERE MaKH = @MaKH;

        SELECT N'Cập nhật thông tin khách hàng thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 22. Xóa khách hàng
CREATE OR ALTER PROCEDURE sp_XoaKhach
    @MaKH VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM HoaDon WHERE MaKH = @MaKH)
            THROW 50000, N'Khách hàng đã có lịch sử hóa đơn, không thể xóa.', 1;

        DELETE FROM Khach WHERE MaKH = @MaKH;
        SELECT N'Xóa khách hàng thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 23. Tìm kiếm khách hàng
CREATE OR ALTER PROCEDURE sp_TimKiemKhach
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT k.MaKH, k.TenKH, k.SoDienThoai, k.DiemTichLuy, k.MaLoaiKH, lk.TenLoai AS TenLoaiKhach, lk.ChietKhau
    FROM Khach k
    JOIN LoaiKhach lk ON lk.MaLoaiKH = k.MaLoaiKH
    WHERE k.TenKH LIKE N'%' + @TuKhoa + '%'
       OR k.SoDienThoai LIKE '%' + @TuKhoa + '%';
END
GO

-- 24. Thêm nguyên liệu
CREATE OR ALTER PROCEDURE sp_ThemNguyenLieu
    @MaNL VARCHAR(20),
    @TenNL NVARCHAR(150),
    @SoLuongTonKho DECIMAL(12,3) = 0,
    @MucToiThieu DECIMAL(12,3) = 5.0,
    @MaLoaiNL VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTonKho, MucToiThieu, MaLoaiNL)
        VALUES (@MaNL, @TenNL, @SoLuongTonKho, @MucToiThieu, @MaLoaiNL);

        SELECT N'Thêm nguyên liệu thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 25. Sửa nguyên liệu
CREATE OR ALTER PROCEDURE sp_SuaNguyenLieu
    @MaNL VARCHAR(20),
    @TenNL NVARCHAR(150),
    @MucToiThieu DECIMAL(12,3),
    @MaLoaiNL VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM NguyenLieu WHERE MaNL = @MaNL)
            THROW 50000, N'Nguyên liệu không tồn tại.', 1;

        UPDATE NguyenLieu
        SET TenNL = @TenNL,
            MucToiThieu = @MucToiThieu,
            MaLoaiNL = @MaLoaiNL
        WHERE MaNL = @MaNL;

        SELECT N'Cập nhật nguyên liệu thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 26. Thêm nhà cung cấp
CREATE OR ALTER PROCEDURE sp_ThemNCC
    @MaNCC VARCHAR(20),
    @TenNCC NVARCHAR(150),
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email)
        VALUES (@MaNCC, @TenNCC, @DiaChi, @SoDienThoai, @Email);

        SELECT N'Thêm nhà cung cấp thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 27. Sửa nhà cung cấp
CREATE OR ALTER PROCEDURE sp_SuaNCC
    @MaNCC VARCHAR(20),
    @TenNCC NVARCHAR(150),
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(15) = NULL,
    @Email VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM NhaCungCap WHERE MaNCC = @MaNCC)
            THROW 50000, N'Nhà cung cấp không tồn tại.', 1;

        UPDATE NhaCungCap
        SET TenNCC = @TenNCC,
            DiaChi = @DiaChi,
            SoDienThoai = @SoDienThoai,
            Email = @Email
        WHERE MaNCC = @MaNCC;

        SELECT N'Cập nhật nhà cung cấp thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 28. Thêm nhân viên
CREATE OR ALTER PROCEDURE sp_ThemNhanVien
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(100),
    @ChucVu NVARCHAR(50),
    @SoDienThoai VARCHAR(15),
    @CaLamViec NVARCHAR(50),
    @MatKhau VARCHAR(255),
    @MaQL VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DECLARE @MKHash VARCHAR(64) = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2);

        INSERT INTO NhanVien (MaNV, TenNV, ChucVu, SoDienThoai, CaLamViec, MatKhau, MaQL)
        VALUES (@MaNV, @TenNV, @ChucVu, @SoDienThoai, @CaLamViec, @MKHash, @MaQL);

        SELECT N'Thêm nhân viên thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 29. Sửa nhân viên (không sửa mật khẩu qua SP này)
CREATE OR ALTER PROCEDURE sp_SuaNhanVien
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(100),
    @ChucVu NVARCHAR(50),
    @SoDienThoai VARCHAR(15),
    @CaLamViec NVARCHAR(50),
    @MaQL VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNV = @MaNV)
            THROW 50000, N'Nhân viên không tồn tại.', 1;

        UPDATE NhanVien
        SET TenNV = @TenNV,
            ChucVu = @ChucVu,
            SoDienThoai = @SoDienThoai,
            CaLamViec = @CaLamViec,
            MaQL = @MaQL
        WHERE MaNV = @MaNV;

        SELECT N'Cập nhật nhân viên thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 30. Lấy danh sách thức uống theo loại
CREATE OR ALTER PROCEDURE sp_LayDanhSachThucUongTheoLoai
    @MaLoaiTU VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT tu.MaThucUong, tu.TenThucUong, tu.DonGiaBan, tu.HinhAnh, tu.MaLoaiTU, ltu.TenLoai AS TenLoaiTU
    FROM ThucUong tu
    JOIN LoaiThucUong ltu ON ltu.MaLoaiTU = tu.MaLoaiTU
    WHERE (@MaLoaiTU IS NULL OR tu.MaLoaiTU = @MaLoaiTU)
    ORDER BY tu.TenThucUong;
END
GO

-- 31. Lấy danh mục các loại thức uống
CREATE OR ALTER PROCEDURE sp_LayDanhSachLoaiThucUong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiTU, TenLoai, MoTa FROM LoaiThucUong ORDER BY TenLoai;
END
GO

-- 32. Lấy danh sách nguyên liệu
CREATE OR ALTER PROCEDURE sp_LayDanhSachNguyenLieu
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nl.MaNL, nl.TenNL, nl.SoLuongTonKho, nl.MucToiThieu, nl.MaLoaiNL, lnl.TenLoai, lnl.DonViTinh
    FROM NguyenLieu nl
    JOIN LoaiNguyenLieu lnl ON lnl.MaLoaiNL = nl.MaLoaiNL
    ORDER BY nl.TenNL;
END
GO

-- 33. Lấy danh sách nhà cung cấp
CREATE OR ALTER PROCEDURE sp_LayDanhSachNCC
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNCC, TenNCC, DiaChi, SoDienThoai, Email FROM NhaCungCap ORDER BY TenNCC;
END
GO

-- 34. Lấy danh sách nhân viên
CREATE OR ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.MaNV, nv.TenNV, nv.ChucVu, nv.SoDienThoai, nv.CaLamViec, nv.MaQL, ql.TenNV AS TenQuanLy
    FROM NhanVien nv
    LEFT JOIN NhanVien ql ON nv.MaQL = ql.MaNV
    ORDER BY nv.TenNV;
END
GO

-- 35. Quản lý Bàn: Thêm Bàn
CREATE OR ALTER PROCEDURE sp_ThemBan
    @MaBan VARCHAR(20),
    @SoBan INT,
    @SoChoNgoi INT,
    @MaViTri VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Ban (MaBan, SoBan, SoChoNgoi, TrangThai, MaViTri)
        VALUES (@MaBan, @SoBan, @SoChoNgoi, N'TRONG', @MaViTri);

        SELECT N'Thêm bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 36. Quản lý Bàn: Sửa Bàn
CREATE OR ALTER PROCEDURE sp_SuaBan
    @MaBan VARCHAR(20),
    @SoBan INT,
    @SoChoNgoi INT,
    @MaViTri VARCHAR(20),
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Ban WHERE MaBan = @MaBan)
            THROW 50000, N'Bàn không tồn tại.', 1;

        UPDATE Ban
        SET SoBan = @SoBan,
            SoChoNgoi = @SoChoNgoi,
            MaViTri = @MaViTri,
            TrangThai = ISNULL(@TrangThai, TrangThai)
        WHERE MaBan = @MaBan;

        SELECT N'Cập nhật bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 37. Quản lý Bàn: Xóa Bàn
CREATE OR ALTER PROCEDURE sp_XoaBan
    @MaBan VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Chưa thanh toán')
            THROW 50000, N'Bàn đang có hóa đơn chưa thanh toán, không thể xóa.', 1;

        IF EXISTS (SELECT 1 FROM HoaDon WHERE MaBan = @MaBan)
            THROW 50000, N'Bàn đã có lịch sử giao dịch hóa đơn, không thể xóa.', 1;

        DELETE FROM Ban WHERE MaBan = @MaBan;
        SELECT N'Xóa bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 38. Quản lý Vị trí: Thêm Vị trí bàn
CREATE OR ALTER PROCEDURE sp_ThemViTriBan
    @MaViTri VARCHAR(20),
    @TenViTri NVARCHAR(100),
    @MoTa NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO ViTriBan (MaViTri, TenViTri, MoTa)
        VALUES (@MaViTri, @TenViTri, @MoTa);

        SELECT N'Thêm vị trí bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 39. Quản lý Vị trí: Sửa Vị trí bàn
CREATE OR ALTER PROCEDURE sp_SuaViTriBan
    @MaViTri VARCHAR(20),
    @TenViTri NVARCHAR(100),
    @MoTa NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM ViTriBan WHERE MaViTri = @MaViTri)
            THROW 50000, N'Vị trí không tồn tại.', 1;

        UPDATE ViTriBan
        SET TenViTri = @TenViTri,
            MoTa = @MoTa
        WHERE MaViTri = @MaViTri;

        SELECT N'Cập nhật vị trí bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 40. Quản lý Vị trí: Xóa Vị trí bàn
CREATE OR ALTER PROCEDURE sp_XoaViTriBan
    @MaViTri VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM Ban WHERE MaViTri = @MaViTri)
            THROW 50000, N'Vị trí bàn này đang có bàn trực thuộc, không thể xóa.', 1;

        DELETE FROM ViTriBan WHERE MaViTri = @MaViTri;
        SELECT N'Xóa vị trí bàn thành công' AS KetQua;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO

-- 41. Lấy danh sách Vị trí bàn
CREATE OR ALTER PROCEDURE sp_LayDanhSachViTriBan
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaViTri, TenViTri, MoTa FROM ViTriBan ORDER BY MaViTri;
END
GO

-- =====================================================================
-- PHẦN G: SECURITY (LOGIN / USER / ROLE / PERMISSION)
-- =====================================================================

-- ---------- 1. LOGIN DÙNG CHO FORM ĐĂNG NHẬP ----------
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_auth')
    CREATE LOGIN login_auth WITH PASSWORD = 'AuthLogin@123';
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'user_auth')
    CREATE USER user_auth FOR LOGIN login_auth;
GO
GRANT EXECUTE ON sp_DangNhap TO user_auth;
GO

-- ---------- 2. QUẢN TRỊ VIÊN: toàn quyền ----------
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_quantri')
    CREATE LOGIN login_quantri WITH PASSWORD = 'QuanTri@123';
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'user_quantri')
    CREATE USER user_quantri FOR LOGIN login_quantri;
GO
ALTER ROLE db_owner ADD MEMBER user_quantri;
GO

-- ---------- 3. NHÂN VIÊN PHỤC VỤ / THU NGÂN ----------
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_phucvu')
    CREATE LOGIN login_phucvu WITH PASSWORD = 'PhucVu@123';
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'user_phucvu')
    CREATE USER user_phucvu FOR LOGIN login_phucvu;
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'NhanVienPhucVu' AND type = 'R')
    CREATE ROLE NhanVienPhucVu;
GO

-- Phân quyền bảng / view
GRANT SELECT, INSERT, UPDATE ON Ban                   TO NhanVienPhucVu;
GRANT SELECT, INSERT, UPDATE ON HoaDon                TO NhanVienPhucVu;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietHoaDon TO NhanVienPhucVu;
GRANT SELECT, INSERT, UPDATE ON Khach                 TO NhanVienPhucVu;
GRANT SELECT                 ON ThucUong              TO NhanVienPhucVu;
GRANT SELECT                 ON ViTriBan              TO NhanVienPhucVu;
GRANT SELECT                 ON LoaiThucUong          TO NhanVienPhucVu;
GRANT SELECT                 ON LoaiKhach             TO NhanVienPhucVu;
GRANT SELECT                 ON v_KhachHangThanThiet  TO NhanVienPhucVu;
GRANT SELECT                 ON v_HoaDon              TO NhanVienPhucVu;

-- Phân quyền Sequence
GRANT UPDATE ON Seq_HoaDon TO NhanVienPhucVu;
GRANT UPDATE ON Seq_Khach  TO NhanVienPhucVu;

-- Phân quyền Stored Procedures
GRANT EXECUTE ON sp_TaoHoaDon                   TO NhanVienPhucVu;
GRANT EXECUTE ON sp_ThemMonVaoHoaDon            TO NhanVienPhucVu;
GRANT EXECUTE ON sp_ThanhToanHoaDon             TO NhanVienPhucVu;
GRANT EXECUTE ON sp_HuyHoaDon                   TO NhanVienPhucVu;
GRANT EXECUTE ON sp_TimKiemThucUong             TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayDanhSachBan              TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayHoaDonDangMoTheoBan      TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayChiTietHoaDon            TO NhanVienPhucVu;
GRANT EXECUTE ON sp_CapNhatSoLuongMon           TO NhanVienPhucVu;
GRANT EXECUTE ON sp_ThemKhachHang               TO NhanVienPhucVu;
GRANT EXECUTE ON sp_SuaKhach                    TO NhanVienPhucVu;
GRANT EXECUTE ON sp_TimKiemKhach                TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayDanhSachThucUongTheoLoai TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayDanhSachLoaiThucUong     TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayDanhSachViTriBan         TO NhanVienPhucVu;
GRANT EXECUTE ON sp_DoiMatKhau                  TO NhanVienPhucVu;

-- Phân quyền Functions
GRANT EXECUTE ON dbo.fn_SinhMaTuDong       TO NhanVienPhucVu;
GRANT EXECUTE ON dbo.fn_KiemTraDuNguyenLieu TO NhanVienPhucVu;
GRANT EXECUTE ON dbo.fn_TinhThanhTienHoaDon TO NhanVienPhucVu;
GRANT EXECUTE ON dbo.fn_ChietKhauTheoLoaiKH TO NhanVienPhucVu;
GRANT SELECT  ON dbo.fn_LichSuMuaHang      TO NhanVienPhucVu;

ALTER ROLE NhanVienPhucVu ADD MEMBER user_phucvu;
GO

-- ---------- 4. THỦ KHO ----------
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_thukho')
    CREATE LOGIN login_thukho WITH PASSWORD = 'ThuKho@123';
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'user_thukho')
    CREATE USER user_thukho FOR LOGIN login_thukho;
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'ThuKho' AND type = 'R')
    CREATE ROLE ThuKho;
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON NguyenLieu        TO ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON PhieuNhap         TO ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietPhieuNhap  TO ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON NhaCungCap        TO ThuKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON LoaiNguyenLieu    TO ThuKho;
GRANT SELECT ON ThucUong TO ThuKho;
GRANT SELECT ON CongThuc TO ThuKho;
GRANT SELECT ON v_TonKhoCanhBao TO ThuKho;
GRANT SELECT ON v_PhieuNhap     TO ThuKho;

GRANT UPDATE ON Seq_PhieuNhap TO ThuKho;

GRANT EXECUTE ON sp_NhapKho                TO ThuKho;
GRANT EXECUTE ON sp_ThemChiTietPhieuNhap    TO ThuKho;
GRANT EXECUTE ON sp_ThemNguyenLieu         TO ThuKho;
GRANT EXECUTE ON sp_SuaNguyenLieu          TO ThuKho;
GRANT EXECUTE ON sp_ThemNCC                TO ThuKho;
GRANT EXECUTE ON sp_SuaNCC                 TO ThuKho;
GRANT EXECUTE ON sp_LuuCongThuc            TO ThuKho;
GRANT EXECUTE ON sp_LayDanhSachNguyenLieu  TO ThuKho;
GRANT EXECUTE ON sp_LayDanhSachNCC         TO ThuKho;
GRANT EXECUTE ON sp_DoiMatKhau             TO ThuKho;
GRANT EXECUTE ON dbo.fn_SinhMaTuDong        TO ThuKho;

ALTER ROLE ThuKho ADD MEMBER user_thukho;
GO

-- ---------- 5. KẾ TOÁN ----------
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'login_ketoan')
    CREATE LOGIN login_ketoan WITH PASSWORD = 'KeToan@123';
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'user_ketoan')
    CREATE USER user_ketoan FOR LOGIN login_ketoan;
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'KeToan' AND type = 'R')
    CREATE ROLE KeToan;
GO

GRANT SELECT ON v_HoaDon            TO KeToan;
GRANT SELECT ON v_DoanhThuTheoNgay  TO KeToan;
GRANT SELECT ON v_MonBanChay         TO KeToan;
GRANT SELECT ON v_PhieuNhap          TO KeToan;
GRANT SELECT, INSERT ON PhieuChi     TO KeToan;

GRANT UPDATE ON Seq_PhieuChi TO KeToan;

GRANT EXECUTE ON sp_ChiTienNCC       TO KeToan;
GRANT EXECUTE ON sp_ThongKeDoanhThu  TO KeToan;
GRANT EXECUTE ON sp_DoiMatKhau       TO KeToan;
GRANT SELECT  ON dbo.fn_MonBanChayNhat TO KeToan;

ALTER ROLE KeToan ADD MEMBER user_ketoan;
GO