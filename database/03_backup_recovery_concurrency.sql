USE quanlyquancafe;
GO

/*
PHẦN 1: CƠ SỞ LÝ THUYẾT PHỤC HỒI (RECOVERY) VÀ ĐỐI CHIẾU VỚI SQL SERVER
(Dùng đưa vào Chương 4 báo cáo đồ án)

1.1. Lịch trình khả phục hồi (Recoverable Schedules)
- Định nghĩa: Một lịch trình S được gọi là khả phục hồi nếu với mọi cặp giao dịch Ti và Tj, nếu Tj đọc dữ liệu do Ti ghi, thì commit của Ti phải diễn ra trước commit của Tj.
- Tránh phục hồi dây chuyền (Cascading Rollback): Chỉ đọc dữ liệu từ các giao dịch đã commit.
- Trong SQL Server: Mức cô lập mặc định READ COMMITTED và kĩ thuật khóa Shared Lock đảm bảo lịch trình khả phục hồi.

1.2. Tổng quan về phục hồi
- Đảm bảo tính Bền vững (Durability) và Toàn vẹn (Atomicity) theo chuẩn ACID. Khi gặp sự cố hệ thống (System Crash) hoặc Rollback, DBMS đưa CSDL về trạng thái nhất quán.

1.3. Kỹ thuật Write-Ahead Logging (WAL)
- Mọi thay đổi dữ liệu trên bộ nhớ đệm (Buffer Pool) phải ghi vào Transaction Log trên đĩa trước khi các trang dữ liệu (Data Pages) được ghi xuống tệp MDF/NDF.
- SQL Server thực hiện WAL thông qua LSN (Log Sequence Number) và tiến trình Checkpoint.

1.4. Phục hồi dựa trên Hoãn cập nhật (Deferred Update - NO-UNDO / REDO)
- Các cập nhật chỉ ghi vào CSDL sau khi giao dịch commit thành công. Khi gặp sự cố, chỉ cần REDO các giao dịch đã commit, không cần UNDO giao dịch chưa commit.

1.5. Phục hồi dựa trên Cập nhật ngay (Immediate Update - UNDO / REDO)
- Dữ liệu sửa đổi có thể được ghi xuống đĩa trước khi commit. SQL Server dùng cơ chế này kết hợp giải thuật ARIES: UNDO các giao dịch chưa commit và REDO các giao dịch đã commit.

1.6. Kỹ thuật Shadow Paging (Trang bóng)
- Duy trì 2 bảng trang: Current Page Table (phục vụ giao dịch hiện hành) và Shadow Page Table (trỏ đến khối dữ liệu cũ). Khi commit, con trỏ gốc chuyển sang trang mới. Nếu crash, con trỏ vẫn trỏ về trang bóng cũ.
*/

-- PHẦN 2: KỊCH BẢN BACKUP VÀ RESTORE CSDL TRÊN SQL SERVER

-- 2.1. Cấu hình CSDL sang chế độ FULL Recovery Model
USE master;
GO
ALTER DATABASE quanlyquancafe SET RECOVERY FULL;
GO

-- 2.2. Minh họa quy trình Backup định kỳ
-- Bước 1: Sao lưu toàn phần (Full Backup) cuối tuần
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Full Database Backup',
     DESCRIPTION = N'Sao lưu toàn phần hệ thống quán cà phê';
GO

-- Bước 2: Sao lưu vi sai (Differential Backup) cuối ngày
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Differential Backup',
     DESCRIPTION = N'Sao lưu vi sai các thay đổi trong ngày';
GO

-- Bước 3: Sao lưu nhật ký giao dịch (Transaction Log Backup) định kỳ 15-30 phút
BACKUP LOG quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Log Backup',
     DESCRIPTION = N'Sao lưu nhật ký giao dịch';
GO

-- 2.3. Quy trình Restore khi gặp sự cố (tham khảo)
/*
USE master;
ALTER DATABASE quanlyquancafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

-- 1. Restore bản Full gần nhất
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH NORECOVERY, REPLACE;

-- 2. Restore bản Differential gần nhất
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH NORECOVERY;

-- 3. Restore chuỗi Log Backup và mở lại CSDL
RESTORE LOG quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH RECOVERY;

ALTER DATABASE quanlyquancafe SET MULTI_USER;
*/
GO

-- PHẦN 3: MINH HỌA VÀ XỬ LÝ TRANH CHẤP TRUY CẬP ĐỒNG THỜI (CONCURRENCY CONTROL)
-- Nghiệp vụ: Tránh xung đột Lost Update và Dirty Read khi hai nhân viên cùng gọi món
-- Sử dụng mức cô lập REPEATABLE READ kết hợp khóa UPDLOCK, HOLDLOCK
USE quanlyquancafe;
GO

CREATE OR ALTER PROCEDURE sp_KiemTraVaGiuNguyenLieuPhaChe
    @MaThucUong VARCHAR(20),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Khóa dữ liệu kiểm tra tồn kho bằng UPDLOCK và HOLDLOCK
        IF EXISTS (
            SELECT 1
            FROM CongThuc ct WITH (UPDLOCK, HOLDLOCK)
            JOIN NguyenLieu nl WITH (UPDLOCK, HOLDLOCK) ON nl.MaNL = ct.MaNL
            WHERE ct.MaThucUong = @MaThucUong
              AND nl.SoLuongTonKho < (ct.SoLuongQuyDinh * @SoLuong)
        )
        BEGIN
            THROW 50001, N'Xung đột tồn kho: Không đủ nguyên liệu trong kho tại thời điểm yêu cầu.', 1;
        END

        -- Trừ kho nguyên liệu tức thời
        UPDATE nl
        SET nl.SoLuongTonKho = nl.SoLuongTonKho - (ct.SoLuongQuyDinh * @SoLuong)
        FROM NguyenLieu nl
        JOIN CongThuc ct ON ct.MaNL = nl.MaNL
        WHERE ct.MaThucUong = @MaThucUong;

        COMMIT TRANSACTION;
        SELECT N'Thành công: Đã giữ và trừ nguyên liệu an toàn tránh tranh chấp' AS KetQua;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- PHẦN 4: BẢO MẬT VÀ PHÂN QUYỀN - MINH HỌA GRANT / REVOKE / DENY

-- 4.1. Thiết lập DENY rào chắn các quyền nhạy cảm
DENY DELETE ON dbo.HoaDon TO NhanVienPhucVu, ThuKho, KeToan;            -- Hóa đơn chỉ được hủy, không được xóa
DENY SELECT ON dbo.NhanVien TO NhanVienPhucVu, ThuKho, KeToan;          -- Không xem trực tiếp bảng nhân viên có mật khẩu băm
DENY INSERT, UPDATE, DELETE ON dbo.PhieuChi TO NhanVienPhucVu, ThuKho;  -- Chỉ vai trò kế toán lập phiếu chi
GO

-- 4.2. Kiểm tra hiệu lực quyền (nếu đã tạo user_phucvu)
IF DATABASE_PRINCIPAL_ID('user_phucvu') IS NOT NULL
BEGIN
    EXECUTE AS USER = 'user_phucvu';
    BEGIN TRY
        SELECT * FROM dbo.NhanVien; -- Bị chặn bởi lệnh DENY (lỗi 229)
    END TRY
    BEGIN CATCH
        SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
    END CATCH
    EXEC dbo.sp_LayDanhSachBan;     -- Thực thi bình thường nhờ quyền EXECUTE
    REVERT;
END
GO

-- 4.3. Minh họa GRANT -> REVOKE -> DENY trên role tạm thời
IF DATABASE_PRINCIPAL_ID('user_demo_quyen') IS NOT NULL DROP USER user_demo_quyen;
IF DATABASE_PRINCIPAL_ID('RoleDemoQuyen')   IS NOT NULL DROP ROLE RoleDemoQuyen;
GO
CREATE ROLE RoleDemoQuyen;
CREATE USER user_demo_quyen WITHOUT LOGIN;
ALTER ROLE RoleDemoQuyen ADD MEMBER user_demo_quyen;
GO

-- (a) GRANT: Cho phép đọc dữ liệu
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;
EXECUTE AS USER = 'user_demo_quyen';
SELECT COUNT(*) AS SoKhach_SauGRANT FROM dbo.Khach;
REVERT;
GO

-- (b) REVOKE: Thu hồi quyền đã cấp
REVOKE SELECT ON dbo.Khach FROM RoleDemoQuyen;
BEGIN TRY
    EXECUTE AS USER = 'user_demo_quyen';
    SELECT COUNT(*) AS SoKhach_SauREVOKE FROM dbo.Khach;
    REVERT;
END TRY
BEGIN CATCH
    REVERT;
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH
GO

-- (c) DENY thắng GRANT: Gán DENY trực tiếp cho user dù role có quyền
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;
DENY  SELECT ON dbo.Khach TO user_demo_quyen;
BEGIN TRY
    EXECUTE AS USER = 'user_demo_quyen';
    SELECT COUNT(*) AS SoKhach_SauDENY FROM dbo.Khach;
    REVERT;
END TRY
BEGIN CATCH
    REVERT;
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS ThongBaoLoi;
END CATCH
GO

-- Dọn dẹp đối tượng thử nghiệm
DROP USER user_demo_quyen;
DROP ROLE RoleDemoQuyen;
GO

-- 4.4. Truy vấn báo cáo quyền hạn hiện hành của các vai trò
SELECT pr.name AS Principal, pe.state_desc AS TrangThai, pe.permission_name AS Quyen,
       OBJECT_NAME(pe.major_id) AS DoiTuong
FROM sys.database_permissions pe
JOIN sys.database_principals pr ON pr.principal_id = pe.grantee_principal_id
WHERE pr.name IN (N'NhanVienPhucVu', N'ThuKho', N'KeToan') AND pe.class_desc = 'OBJECT_OR_COLUMN'
ORDER BY pr.name, pe.state_desc, DoiTuong;
GO

-- PHẦN 5: ĐÁNH GIÁ HIỆU NĂNG CHỈ MỤC (INDEX PERFORMANCE)
-- Minh họa sử dụng SET STATISTICS IO ON và SET STATISTICS TIME ON để phân tích hiệu năng truy vấn có chỉ mục
USE quanlyquancafe;
GO

SET STATISTICS IO ON;
SET STATISTICS TIME ON;
GO

-- Truy vấn 1: Tìm kiếm hóa đơn theo ngày lập (sử dụng chỉ mục IX_HoaDon_NgayLap)
SELECT MaHD, NgayLap, MaNV, MaBan, TrangThai
FROM HoaDon
WHERE NgayLap >= DATEADD(DAY, -15, GETDATE());
GO

-- Truy vấn 2: Tra cứu lịch sử mua hàng theo mã khách hàng (sử dụng chỉ mục IX_HoaDon_MaKH)
SELECT MaHD, NgayLap, TienGiamGia, DiemTichLuyCong, TrangThai
FROM HoaDon
WHERE MaKH = 'KH000001';
GO

-- Truy vấn 3: Lọc nguyên liệu dưới ngưỡng an toàn (sử dụng chỉ mục IX_NguyenLieu_TonKho)
SELECT MaNL, TenNL, SoLuongTonKho, MucToiThieu
FROM NguyenLieu
WHERE SoLuongTonKho <= MucToiThieu;
GO

-- Truy vấn 4: Thống kê chi tiết món theo thức uống (sử dụng chỉ mục IX_CTHD_MaThucUong)
SELECT MaThucUong, SUM(SoLuong) AS TongSoLuong, SUM(ThanhTien) AS TongTien
FROM ChiTietHoaDon
WHERE MaThucUong = 'TU01'
GROUP BY MaThucUong;
GO

SET STATISTICS IO OFF;
SET STATISTICS TIME OFF;
GO

-- PHẦN 6: KỊCH BẢN KIỂM THỬ NGHIỆP VỤ BÁN HÀNG VÀ ĐƠN MANG VỀ
-- Kiểm thử toàn diện bằng giao dịch tự rollback, không làm sai lệch dữ liệu kho và điểm tích lũy
USE quanlyquancafe;
GO

SET XACT_ABORT ON;
BEGIN TRANSACTION;

-- Chuẩn bị dữ liệu kiểm thử
DECLARE @NV VARCHAR(20) = (SELECT TOP 1 MaNV FROM dbo.NhanVien ORDER BY MaNV);
DECLARE @KH VARCHAR(20) = (SELECT TOP 1 MaKH FROM dbo.Khach ORDER BY MaKH);
DECLARE @Mon VARCHAR(20) = (
    SELECT TOP 1 tu.MaThucUong FROM dbo.ThucUong tu
    WHERE tu.DonGiaBan >= 10000
      AND EXISTS (SELECT 1 FROM dbo.CongThuc ct WHERE ct.MaThucUong = tu.MaThucUong)
      AND NOT EXISTS (
          SELECT 1 FROM dbo.CongThuc ct JOIN dbo.NguyenLieu nl ON nl.MaNL = ct.MaNL
          WHERE ct.MaThucUong = tu.MaThucUong AND nl.SoLuongTonKho < ct.SoLuongQuyDinh * 3
      ) ORDER BY tu.MaThucUong
);

IF @NV IS NULL OR @KH IS NULL OR @Mon IS NULL
    THROW 51000, N'Cần nhân viên, khách hàng và món đủ nguyên liệu để kiểm thử.', 1;

DECLARE @ID1 VARCHAR(20) = 'HD_QA' + LEFT(REPLACE(CONVERT(VARCHAR(36), NEWID()), '-', ''), 12);
DECLARE @ID2 VARCHAR(20) = 'HD_QA' + LEFT(REPLACE(CONVERT(VARCHAR(36), NEWID()), '-', ''), 12);
DECLARE @Diem INT = (SELECT DiemTichLuy FROM dbo.Khach WHERE MaKH = @KH);
DECLARE @Ton TABLE (MaNL VARCHAR(20), SoLuong DECIMAL(18,4));
INSERT INTO @Ton SELECT MaNL, SoLuongTonKho FROM dbo.NguyenLieu;

-- 1. Kiểm tra tạo 2 đơn mang về độc lập trên bàn quy ước B_MANGVE
EXEC dbo.sp_TaoHoaDon @MaHD = @ID1 OUTPUT, @MaKH = @KH, @MaNV = @NV, @MaBan = 'B_MANGVE';
EXEC dbo.sp_TaoHoaDon @MaHD = @ID2 OUTPUT, @MaNV = @NV, @MaBan = 'B_MANGVE';

IF (SELECT COUNT(*) FROM dbo.HoaDon WHERE MaHD IN (@ID1, @ID2) AND TrangThai = N'Chưa thanh toán') <> 2
    THROW 51000, N'Lỗi: Không tạo được hai đơn mang về độc lập.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Ban WHERE MaBan = 'B_MANGVE' AND TrangThai = N'TRONG')
    THROW 51000, N'Lỗi: Bàn mang về bị chiếm sau khi tạo đơn.', 1;

-- 2. Kiểm tra lấy danh sách đơn mang về và tra cứu theo bàn
DECLARE @Don TABLE (
    MaHD VARCHAR(20), NgayLap DATETIME, MaNV VARCHAR(20), MaKH VARCHAR(20),
    TienGiamGia DECIMAL(12,2), PhuongThucThanhToan NVARCHAR(50), MaBan VARCHAR(20), TrangThai NVARCHAR(50)
);
INSERT INTO @Don EXEC dbo.sp_LayDanhSachDonMangVe;
IF (SELECT COUNT(*) FROM @Don WHERE MaHD IN (@ID1, @ID2)) <> 2
    THROW 51000, N'Lỗi: Danh sách đơn mang về thiếu hóa đơn.', 1;

DECLARE @TheoBan TABLE (
    MaHD VARCHAR(20), NgayLap DATETIME, MaNV VARCHAR(20), MaKH VARCHAR(20),
    TienGiamGia DECIMAL(12,2), PhuongThucThanhToan NVARCHAR(50)
);
INSERT INTO @TheoBan EXEC dbo.sp_LayHoaDonDangMoTheoBan @MaBan = 'B_MANGVE';
IF EXISTS (SELECT 1 FROM @TheoBan)
    THROW 51000, N'Lỗi: Tra theo bàn mang về chọn nhầm hóa đơn.', 1;

-- 3. Kiểm tra thêm món và trừ kho nguyên liệu
EXEC dbo.sp_ThemMonVaoHoaDon @MaHD = @ID1, @MaThucUong = @Mon, @SoLuong = 1;
EXEC dbo.sp_ThemMonVaoHoaDon @MaHD = @ID2, @MaThucUong = @Mon, @SoLuong = 1;

IF EXISTS (
    SELECT 1 FROM dbo.CongThuc ct
    JOIN dbo.NguyenLieu nl ON nl.MaNL = ct.MaNL
    JOIN @Ton t ON t.MaNL = nl.MaNL
    WHERE ct.MaThucUong = @Mon AND nl.SoLuongTonKho <> t.SoLuong - ct.SoLuongQuyDinh * 2
)
    THROW 51000, N'Lỗi: Trừ kho cho đơn mang về không chính xác.', 1;

-- 4. Kiểm tra thanh toán đơn mang về và tích điểm cho khách
EXEC dbo.sp_ThanhToanHoaDon @MaHD = @ID1, @TienGiamGia = 0, @PhuongThucThanhToan = N'Chuyển khoản';

IF NOT EXISTS (SELECT 1 FROM dbo.HoaDon WHERE MaHD = @ID2 AND TrangThai = N'Chưa thanh toán')
    THROW 51000, N'Lỗi: Thanh toán làm ảnh hưởng đến đơn mang về khác.', 1;

IF (SELECT DiemTichLuy FROM dbo.Khach WHERE MaKH = @KH) <> @Diem + (SELECT DiemTichLuyCong FROM dbo.HoaDon WHERE MaHD = @ID1)
    THROW 51000, N'Lỗi: Tích điểm cho khách mua mang về không chính xác.', 1;

-- 5. Kiểm tra hủy đơn mang về và hoàn kho
EXEC dbo.sp_HuyHoaDon @MaHD = @ID2;

IF EXISTS (
    SELECT 1 FROM dbo.CongThuc ct
    JOIN dbo.NguyenLieu nl ON nl.MaNL = ct.MaNL
    JOIN @Ton t ON t.MaNL = nl.MaNL
    WHERE ct.MaThucUong = @Mon AND nl.SoLuongTonKho <> t.SoLuong - ct.SoLuongQuyDinh
)
    THROW 51000, N'Lỗi: Hủy đơn mang về không hoàn đúng nguyên liệu vào kho.', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.Ban WHERE MaBan = 'B_MANGVE' AND TrangThai = N'TRONG')
    THROW 51000, N'Lỗi: Bàn mang về đổi trạng thái sau khi thanh toán hoặc hủy đơn.', 1;

-- 6. Kiểm tra quy trình bàn tại quán (chuyển trạng thái TRONG -> COKHACH -> TRONG)
DECLARE @Ban VARCHAR(20) = (SELECT TOP 1 MaBan FROM dbo.Ban WHERE MaBan <> 'B_MANGVE' AND TrangThai = N'TRONG');
IF @Ban IS NULL THROW 51000, N'Cần một bàn trống để kiểm thử quy trình tại quán.', 1;

DECLARE @ID3 VARCHAR(20) = 'HD_QA' + LEFT(REPLACE(CONVERT(VARCHAR(36), NEWID()), '-', ''), 12);
EXEC dbo.sp_TaoHoaDon @MaHD = @ID3 OUTPUT, @MaNV = @NV, @MaBan = @Ban;

IF NOT EXISTS (SELECT 1 FROM dbo.Ban WHERE MaBan = @Ban AND TrangThai = N'COKHACH')
    THROW 51000, N'Lỗi: Bàn tại quán không chuyển sang COKHACH khi mở đơn.', 1;

EXEC dbo.sp_HuyHoaDon @MaHD = @ID3;

IF NOT EXISTS (SELECT 1 FROM dbo.Ban WHERE MaBan = @Ban AND TrangThai = N'TRONG')
    THROW 51000, N'Lỗi: Bàn tại quán không trả về TRONG sau khi hủy đơn.', 1;

-- Hoàn tác toàn bộ thay đổi sau kiểm thử
ROLLBACK TRANSACTION;
PRINT N'KIỂM THỬ THÀNH CÔNG: Đơn mang về độc lập, trừ/hoàn kho, tích điểm và luồng tại quán hoạt động chính xác.';
GO
