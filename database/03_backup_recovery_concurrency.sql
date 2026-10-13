USE quanlyquancafe;
GO

/* ====================================================================================
   PHẦN 1: CƠ SỞ LÝ THUYẾT VỀ PHỤC HỒI (RECOVERY) VÀ ĐỐI CHIẾU VỚI SQL SERVER
   (Phần này dùng để đưa trực tiếp vào Chương 4 của Báo cáo đồ án)
   
   1.1. Lịch trình khả phục hồi (Recoverable Schedules)
        - Định nghĩa: Một lịch trình S được gọi là khả phục hồi nếu với mọi cặp giao dịch
          Ti và Tj, nếu Tj đọc một giá trị dữ liệu do Ti ghi (Dirty Read potential), 
          thì thao tác Commit của Ti PHẢI diễn ra TRƯỚC thao tác Commit của Tj.
        - Tránh phục hồi dây chuyền (Cascading Rollback): Nếu giao dịch chỉ đọc dữ liệu
          từ các giao dịch đã commit (Commit Read), hệ thống sẽ ngăn ngừa hoàn toàn tình
          trạng một giao dịch rollback kéo theo hàng loạt giao dịch khác phải hủy theo.
        - Trong SQL Server: Mức cô lập mặc định READ COMMITTED và kĩ thuật khóa Shared Lock
          giúp hệ thống luôn đảm bảo lịch trình khả phục hồi và tránh Cascading Rollback.

   1.2. Tổng quan về phục hồi (Recovery Overview)
        - Đảm bảo tính Bền vững (Durability) và Toàn vẹn (Atomicity) theo chuẩn ACID.
        - Khi gặp sự cố sập nguồn (System Crash), hỏng phần cứng hoặc Rollback do logic,
          DBMS phải đưa CSDL về trạng thái nhất quán gần nhất.

   1.3. Kỹ thuật Write-Ahead Logging (WAL)
        - Nguyên tắc vàng: Mọi thay đổi dữ liệu trên bộ nhớ đệm (Buffer Pool) phải được ghi
          vào Transaction Log trên đĩa cứng TRƯỚC KHI các trang dữ liệu (Data Pages)
          tương ứng được ghi cố định xuống tệp MDF/NDF.
        - SQL Server hiện thực WAL thông qua LSN (Log Sequence Number) và tiến trình Checkpoint.

   1.4. Phục hồi dựa trên Hoãn cập nhật (Deferred Update - NO-UNDO / REDO)
        - Cơ chế: Mọi thao tác cập nhật không ghi trực tiếp vào CSDL vật lý cho đến khi
          giao dịch đã COMMIT thành công. Trong log chỉ cần ghi REDO.
        - Khi crash:
          + Giao dịch đã Commit trước crash: Thực hiện REDO từ log.
          + Giao dịch chưa Commit trước crash: Không cần UNDO (vì chưa ghi xuống đĩa).

   1.5. Phục hồi dựa trên Cập nhật ngay (Immediate Update - UNDO / REDO)
        - Cơ chế: Dữ liệu sửa đổi có thể được flush xuống đĩa trước khi transaction commit.
        - SQL Server sử dụng cơ chế này (kết hợp thuật toán ARIES):
          + UNDO: Hủy bỏ các thay đổi của transaction chưa commit tại thời điểm gặp sự cố.
          + REDO: Áp dụng lại các thay đổi của transaction đã commit nhưng chưa kịp ghi vào file data.

   1.6. Kỹ thuật Phục hồi dựa trên Shadow Paging (Trang bóng)
        - Không phụ thuộc nhiều vào log để khôi phục: Duy trì 2 bảng chỉ mục trang:
          + Bảng trang hiện hành (Current Page Table): phục vụ giao dịch đang thực hiện.
          + Bảng trang bóng (Shadow Page Table): trỏ đến các khối dữ liệu cũ trên đĩa.
        - Khi commit: Con trỏ gốc chuyển sang trỏ vào trang mới. Nếu crash: con trỏ vẫn
          trỏ vào trang bóng cũ, dữ liệu được bảo toàn mà không cần Undo.
   ==================================================================================== */

-- ====================================================================================
-- PHẦN 2: KỊCH BẢN BACKUP VÀ RESTORE CSDL THỰC TẾ TRÊN SQL SERVER
-- ====================================================================================

-- 2.1. Cấu hình CSDL sang chế độ FULL Recovery Model để hỗ trợ ghi Log chi tiết
USE master;
GO
ALTER DATABASE quanlyquancafe SET RECOVERY FULL;
GO

-- 2.2. Tạo thiết bị Backup / Thư mục backup (Đảm bảo thư mục C:\Backup tồn tại trên ổ cứng)
-- Script minh họa sao lưu:
-- Bước 1: Sao lưu toàn phần (Full Backup) vào cuối tuần
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Full Database Backup',
     DESCRIPTION = N'Sao lưu toàn phần hệ thống quán cà phê';
GO

-- Bước 2: Sao lưu vi sai (Differential Backup) vào cuối ngày làm việc
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Differential Backup',
     DESCRIPTION = N'Sao lưu vi sai các thay đổi trong ngày';
GO

-- Bước 3: Sao lưu nhật ký giao dịch (Transaction Log Backup) định kỳ mỗi 15-30 phút
BACKUP LOG quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Log Backup',
     DESCRIPTION = N'Sao lưu nhật ký giao dịch đảm bảo RPO nhỏ nhất';
GO

-- 2.3. Quy trình Khôi phục hệ thống khi gặp sự cố (Disaster Recovery Simulation)
/*
-- Khi có sự cố hỏng đĩa hoặc mất dữ liệu, quy trình Restore chuẩn:
USE master;
ALTER DATABASE quanlyquancafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

-- 1. Restore bản Full gần nhất (với tùy chọn NORECOVERY để tiếp tục nhận bản sau)
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH NORECOVERY, REPLACE;

-- 2. Restore bản Differential gần nhất
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH NORECOVERY;

-- 3. Restore chuỗi Transaction Log và hoàn tất khôi phục
RESTORE LOG quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH RECOVERY;

ALTER DATABASE quanlyquancafe SET MULTI_USER;
*/
GO


-- ====================================================================================
-- PHẦN 3: MINH HỌA VÀ XỬ LÝ TRANH CHẤP TRUY CẬP ĐỒNG THỜI (CONCURRENCY CONTROL)
-- Nghiệp vụ: Hai nhân viên cùng bấm thanh toán / đặt bàn cùng một thời điểm (Lost Update)
-- Giải pháp: Sử dụng mức cô lập thích hợp và Gợi ý Khóa (Lock Hints: UPDLOCK, HOLDLOCK)
-- ====================================================================================
USE quanlyquancafe;
GO

-- SP Minh họa xử lý đồng thời tránh Dirty Read & Lost Update khi cập nhật tồn kho pha chế
CREATE OR ALTER PROCEDURE sp_KiemTraVaGiuNguyenLieuPhaChe
    @MaThucUong VARCHAR(20),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Sử dụng UPDLOCK và HOLDLOCK để ngăn chặn Transaction khác đọc/ghi đè cùng lúc
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

-- ====================================================================================
-- PHẦN 4: BẢO MẬT VÀ PHÂN QUYỀN - MINH HỌA GRANT / REVOKE / DENY
-- ====================================================================================
/*
   CHÍNH SÁCH PHÂN QUYỀN (đưa vào Chương 4):
   1. Đặc quyền tối thiểu: mỗi vai trò chỉ được quyền cần cho nghiệp vụ của mình.
   2. Ưu tiên cấp EXECUTE trên stored procedure thay vì cấp thẳng quyền trên bảng
      (ownership chaining: thủ tục cùng chủ sở hữu dbo chạy được mà người dùng không cần quyền bảng).
   3. Tách biệt nhiệm vụ: Phục vụ (bán hàng) - Thủ kho (nhập kho) - Kế toán (chi tiền) - Quản trị (db_owner).
   4. GRANT cấp quyền; REVOKE thu hồi quyền đã cấp (về trạng thái "chưa cấp");
      DENY cấm hẳn và LUÔN THẮNG GRANT, kể cả khi quyền được cấp qua role khác.

   Login / Role            | Quyền chính
   ------------------------+------------------------------------------------------------
   login_auth              | Chỉ EXECUTE sp_DangNhap
   login_quantri           | db_owner: toàn quyền
   login_phucvu / NhanVienPhucVu | Bàn, hóa đơn, khách hàng; chỉ xem thực đơn
   login_thukho / ThuKho   | Nguyên liệu, phiếu nhập, nhà cung cấp, công thức
   login_ketoan / KeToan   | Xem báo cáo, lập phiếu chi
*/

-- 4.1. GRANT (đã dùng ở file 01, ví dụ): phục vụ được thao tác hóa đơn, thủ kho được nhập kho
-- GRANT SELECT, INSERT, UPDATE ON HoaDon TO NhanVienPhucVu;
-- GRANT EXECUTE ON sp_NhapKho TO ThuKho;

-- 4.2. DENY: rào chắn các quyền tuyệt đối không được có
DENY DELETE ON dbo.HoaDon TO NhanVienPhucVu, ThuKho, KeToan;            -- hóa đơn chỉ được HỦY, không được xóa
DENY SELECT ON dbo.NhanVien TO NhanVienPhucVu, ThuKho, KeToan;          -- không xem được bảng nhân viên (có mật khẩu băm)
DENY INSERT, UPDATE, DELETE ON dbo.PhieuChi TO NhanVienPhucVu, ThuKho;  -- chỉ kế toán lập phiếu chi
GO

-- Kiểm tra: đóng vai nhân viên phục vụ
EXECUTE AS USER = 'user_phucvu';
BEGIN TRY
    SELECT * FROM dbo.NhanVien;                 -- bị chặn bởi DENY (lỗi 229)
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER() AS Loi, ERROR_MESSAGE() AS ThongBao;
END CATCH
EXEC dbo.sp_LayDanhSachBan;                     -- vẫn chạy được nhờ quyền EXECUTE
REVERT;
GO

-- 4.3. GRANT -> REVOKE -> DENY trên role tạm (không ảnh hưởng role thật)
IF DATABASE_PRINCIPAL_ID('user_demo_quyen') IS NOT NULL DROP USER user_demo_quyen;
IF DATABASE_PRINCIPAL_ID('RoleDemoQuyen')  IS NOT NULL DROP ROLE RoleDemoQuyen;
GO
CREATE ROLE RoleDemoQuyen;
CREATE USER user_demo_quyen WITHOUT LOGIN;
ALTER ROLE RoleDemoQuyen ADD MEMBER user_demo_quyen;
GO

-- (a) GRANT: đọc được
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;
EXECUTE AS USER = 'user_demo_quyen';
SELECT COUNT(*) AS SoKhach_SauGRANT FROM dbo.Khach;
REVERT;
GO

-- (b) REVOKE: thu hồi -> không đọc được nữa
REVOKE SELECT ON dbo.Khach FROM RoleDemoQuyen;
BEGIN TRY
    EXECUTE AS USER = 'user_demo_quyen';
    SELECT COUNT(*) AS SoKhach_SauREVOKE FROM dbo.Khach;
    REVERT;
END TRY
BEGIN CATCH
    REVERT;
    SELECT ERROR_NUMBER() AS Loi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

-- (c) DENY thắng GRANT: role được cấp lại nhưng user bị DENY vẫn bị chặn
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;
DENY  SELECT ON dbo.Khach TO user_demo_quyen;
BEGIN TRY
    EXECUTE AS USER = 'user_demo_quyen';
    SELECT COUNT(*) AS SoKhach_SauDENY FROM dbo.Khach;
    REVERT;
END TRY
BEGIN CATCH
    REVERT;
    SELECT ERROR_NUMBER() AS Loi, ERROR_MESSAGE() AS ThongBao;
END CATCH
GO

DROP USER user_demo_quyen;
DROP ROLE RoleDemoQuyen;
GO

-- 4.4. Báo cáo quyền hiện hành (chụp hình đưa vào báo cáo)
SELECT pr.name AS Principal, pe.state_desc AS TrangThai, pe.permission_name AS Quyen,
       OBJECT_NAME(pe.major_id) AS DoiTuong
FROM sys.database_permissions pe
JOIN sys.database_principals pr ON pr.principal_id = pe.grantee_principal_id
WHERE pr.name IN (N'NhanVienPhucVu', N'ThuKho', N'KeToan') AND pe.class_desc = 'OBJECT_OR_COLUMN'
ORDER BY pr.name, pe.state_desc, DoiTuong;
GO
