-- =====================================================================
-- 02_du_lieu_mau.sql  -  DỮ LIỆU MẪU CHO CSDL quanlyquancafe
-- Chạy SAU khi đã chạy xong file tạo CSDL (scripts-hqt-csdl.sql).
-- Chạy bằng tài khoản quản trị (sa / Windows Authentication) trong SSMS.
--
-- CẢNH BÁO: PHẦN 0 XÓA SẠCH DỮ LIỆU CŨ của mọi bảng và đặt lại các SEQUENCE,
--           để có thể chạy lại script nhiều lần. Nếu đã nhập dữ liệu thật, hãy
--           bỏ phần 0 (comment lại).
--
-- Tài khoản ứng dụng (mật khẩu chung: 123456):
--   0901000001 Quản lý | 0901000002, 0901000003 Phục vụ | 0901000004 Thu ngân
--   0901000005 Thủ kho | 0901000006 Kế toán
-- =====================================================================
USE quanlyquancafe;
GO
SET NOCOUNT ON;
GO

-- =====================================================================
-- PHẦN 0: XÓA DỮ LIỆU CŨ (theo thứ tự khóa ngoại) VÀ ĐẶT LẠI SEQUENCE
-- =====================================================================
UPDATE NhanVien SET MaQL = NULL;
DELETE FROM ChiTietHoaDon;
DELETE FROM HoaDon;
DELETE FROM ChiTietPhieuNhap;
DELETE FROM PhieuNhap;
DELETE FROM PhieuChi;
DELETE FROM CongThuc;
DELETE FROM ThucUong;
DELETE FROM NguyenLieu;
DELETE FROM Khach;
DELETE FROM Ban;
DELETE FROM ViTriBan;
DELETE FROM LoaiThucUong;
DELETE FROM LoaiNguyenLieu;
DELETE FROM NhaCungCap;
DELETE FROM LoaiKhach;
DELETE FROM NhanVien;

ALTER SEQUENCE Seq_HoaDon   RESTART WITH 1;
ALTER SEQUENCE Seq_PhieuNhap RESTART WITH 1;
ALTER SEQUENCE Seq_Khach    RESTART WITH 1;
ALTER SEQUENCE Seq_PhieuChi RESTART WITH 1;
GO

-- =====================================================================
-- PHẦN 1: DANH MỤC CƠ BẢN
-- =====================================================================

-- 1.1 Loại khách (sp_ThemKhachHang mặc định dùng LKH01 nên bắt buộc phải có)
INSERT INTO LoaiKhach (MaLoaiKH, TenLoai, ChietKhau) VALUES
('LKH01', N'Thường',     0),
('LKH02', N'Thân thiết', 5),
('LKH03', N'VIP',        10);

-- 1.2 Nhân viên (mật khẩu 123456 được băm SHA2_256, khớp với sp_DangNhap)
INSERT INTO NhanVien (MaNV, TenNV, ChucVu, SoDienThoai, CaLamViec, MatKhau, MaQL)
VALUES ('NV001', N'Nguyễn Văn An', N'Quản lý', '0901000001', N'Hành chính',
        CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), NULL);

INSERT INTO NhanVien (MaNV, TenNV, ChucVu, SoDienThoai, CaLamViec, MatKhau, MaQL) VALUES
('NV002', N'Trần Thị Bình',   N'Phục vụ', '0901000002', N'Sáng',       CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'NV001'),
('NV003', N'Lê Hoàng Cường',  N'Phục vụ', '0901000003', N'Chiều',      CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'NV001'),
('NV004', N'Phạm Thu Dung',   N'Thu ngân',  '0901000004', N'Sáng',       CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'NV001'),
('NV005', N'Vũ Quốc Huy',     N'Thủ kho', '0901000005', N'Hành chính', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'NV001'),
('NV006', N'Đặng Ngọc Lan',   N'Kế toán', '0901000006', N'Hành chính', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), 'NV001');

-- 1.3 Vị trí bàn và bàn
INSERT INTO ViTriBan (MaViTri, TenViTri, MoTa) VALUES
('VT01', N'Tầng trệt', N'Gần quầy pha chế và cửa ra vào'),
('VT02', N'Tầng 1',    N'Không gian yên tĩnh, có điều hòa'),
('VT03', N'Sân vườn',  N'Khu ngoài trời thoáng mát');

INSERT INTO Ban (MaBan, SoBan, SoChoNgoi, MaViTri) VALUES
('B01', 1, 2, 'VT01'), ('B02', 2, 2, 'VT01'), ('B03', 3, 4, 'VT01'), ('B04', 4, 4, 'VT01'),
('B05', 5, 4, 'VT02'), ('B06', 6, 4, 'VT02'), ('B07', 7, 6, 'VT02'), ('B08', 8, 2, 'VT02'),
('B09', 9, 4, 'VT03'), ('B10', 10, 6, 'VT03');

-- 1.4 Loại thức uống, loại nguyên liệu (đơn vị tính theo loại)
INSERT INTO LoaiThucUong (MaLoaiTU, TenLoai, MoTa) VALUES
('LTU01', N'Cà phê',            N'Các món cà phê pha máy và pha phin'),
('LTU02', N'Trà & trà sữa',     N'Trà trái cây, trà sữa, matcha'),
('LTU03', N'Sinh tố & nước ép', N'Đồ uống trái cây tươi'),
('LTU04', N'Đá xay',            N'Đồ uống xay lạnh phủ kem');

INSERT INTO LoaiNguyenLieu (MaLoaiNL, TenLoai, DonViTinh) VALUES
('LNL01', N'Cà phê & trà',       N'gram'),
('LNL02', N'Sữa & kem',          N'ml'),
('LNL03', N'Siro',               N'ml'),
('LNL04', N'Đường & bột',        N'gram'),
('LNL05', N'Trái cây & topping', N'gram'),
('LNL06', N'Vật dụng',           N'cái');

-- 1.5 Nhà cung cấp
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email) VALUES
('NCC01', N'Công ty TNHH Cà phê Tây Nguyên',       N'12 Nguyễn Tất Thành, Buôn Ma Thuột, Đắk Lắk', '0262100001', 'lienhe@cafetaynguyen.vn'),
('NCC02', N'Đại lý Sữa & Kem Sài Gòn',             N'45 Lê Văn Việt, TP. Thủ Đức, TP.HCM',         '0283100002', 'kinhdoanh@suakemsaigon.vn'),
('NCC03', N'Cửa hàng Trái cây Sạch Ba Miền',       N'Chợ đầu mối Thủ Đức, TP.HCM',                 '0283100003', 'baomien@traicaysach.vn'),
('NCC04', N'Công ty Bao bì Nhựa Minh Phát',        N'88 Quốc lộ 1A, Bình Tân, TP.HCM',             '0283100004', 'sales@minhphatpack.vn'),
('NCC05', N'Công ty Nguyên liệu Pha chế Việt',     N'101 Tô Hiến Thành, Quận 10, TP.HCM',          '0283100005', 'order@phachevietvn.vn');

-- 1.6 Nguyên liệu (tồn kho = 0, sẽ được cộng qua phiếu nhập ở phần 2)
INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTonKho, MucToiThieu, MaLoaiNL) VALUES
('NL01', N'Cà phê Robusta rang xay', 0, 2000, 'LNL01'),
('NL02', N'Cà phê Arabica rang xay', 0, 1000, 'LNL01'),
('NL03', N'Trà đen',                 0,  500, 'LNL01'),
('NL04', N'Bột matcha',              0,  300, 'LNL01'),
('NL05', N'Sữa đặc',                 0, 3000, 'LNL02'),
('NL06', N'Sữa tươi không đường',    0, 5000, 'LNL02'),
('NL07', N'Kem béo (whipping cream)',0, 1000, 'LNL02'),
('NL08', N'Siro đào',                0,  500, 'LNL03'),
('NL09', N'Siro caramel',            0,  500, 'LNL03'),
('NL10', N'Đường cát',               0, 2000, 'LNL04'),
('NL11', N'Bột kem béo',             0, 1000, 'LNL04'),
('NL12', N'Trân châu đen',           0, 1000, 'LNL05'),
('NL13', N'Đào ngâm',                0, 1000, 'LNL05'),
('NL14', N'Cam tươi',                0, 3000, 'LNL05'),
('NL15', N'Xoài chín',               0, 2000, 'LNL05'),
('NL16', N'Dâu tây',                 0, 2000, 'LNL05'),
('NL17', N'Chanh tươi',              0, 1000, 'LNL05'),
('NL18', N'Ly nhựa',                 0,  200, 'LNL06'),
('NL19', N'Ống hút',                 0,  200, 'LNL06');

-- 1.7 Thức uống (HinhAnh để NULL: giao diện phải xử lý được giá trị NULL)
INSERT INTO ThucUong (MaThucUong, TenThucUong, DonGiaBan, HinhAnh, MaLoaiTU) VALUES
('TU01', N'Cà phê đen đá',   25000, NULL, 'LTU01'),
('TU02', N'Cà phê sữa đá',   29000, NULL, 'LTU01'),
('TU03', N'Bạc xỉu',         32000, NULL, 'LTU01'),
('TU04', N'Cappuccino',      45000, NULL, 'LTU01'),
('TU05', N'Latte caramel',   49000, NULL, 'LTU01'),
('TU06', N'Trà đào cam',     39000, NULL, 'LTU02'),
('TU07', N'Trà chanh',       25000, NULL, 'LTU02'),
('TU08', N'Trà sữa trân châu', 39000, NULL, 'LTU02'),
('TU09', N'Matcha latte',    49000, NULL, 'LTU02'),
('TU10', N'Sinh tố xoài',    45000, NULL, 'LTU03'),
('TU11', N'Sinh tố dâu',     49000, NULL, 'LTU03'),
('TU12', N'Nước cam ép',     35000, NULL, 'LTU03'),
('TU13', N'Cà phê đá xay',   49000, NULL, 'LTU04'),
('TU14', N'Matcha đá xay',   52000, NULL, 'LTU04'),
('TU15', N'Dâu đá xay',      52000, NULL, 'LTU04'),
('TU16', N'Xoài đá xay',     52000, NULL, 'LTU04');

-- 1.8 Công thức (lượng nguyên liệu cho 1 ly, đơn vị theo loại nguyên liệu)
INSERT INTO CongThuc (MaThucUong, MaNL, SoLuongQuyDinh) VALUES
    -- Cà phê đen đá
    ('TU01','NL01',20), ('TU01','NL10',10), ('TU01','NL18',1), ('TU01','NL19',1),
    -- Cà phê sữa đá
    ('TU02','NL01',20), ('TU02','NL05',30), ('TU02','NL18',1), ('TU02','NL19',1),
    -- Bạc xỉu
    ('TU03','NL01',15), ('TU03','NL05',25), ('TU03','NL06',60), ('TU03','NL18',1), ('TU03','NL19',1),
    -- Cappuccino
    ('TU04','NL02',18), ('TU04','NL06',120), ('TU04','NL18',1),
    -- Latte caramel
    ('TU05','NL02',18), ('TU05','NL06',150), ('TU05','NL09',20), ('TU05','NL18',1),
    -- Trà đào cam
    ('TU06','NL03',5), ('TU06','NL08',20), ('TU06','NL13',40), ('TU06','NL14',30), ('TU06','NL10',10), ('TU06','NL18',1), ('TU06','NL19',1),
    -- Trà chanh
    ('TU07','NL03',5), ('TU07','NL17',40), ('TU07','NL10',15), ('TU07','NL18',1), ('TU07','NL19',1),
    -- Trà sữa trân châu
    ('TU08','NL03',6), ('TU08','NL11',25), ('TU08','NL05',20), ('TU08','NL12',50), ('TU08','NL18',1), ('TU08','NL19',1),
    -- Matcha latte
    ('TU09','NL04',8), ('TU09','NL06',150), ('TU09','NL10',10), ('TU09','NL18',1), ('TU09','NL19',1),
    -- Sinh tố xoài
    ('TU10','NL15',150), ('TU10','NL05',30), ('TU10','NL10',10), ('TU10','NL18',1), ('TU10','NL19',1),
    -- Sinh tố dâu
    ('TU11','NL16',150), ('TU11','NL05',30), ('TU11','NL10',10), ('TU11','NL18',1), ('TU11','NL19',1),
    -- Nước cam ép
    ('TU12','NL14',250), ('TU12','NL10',10), ('TU12','NL18',1), ('TU12','NL19',1),
    -- Cà phê đá xay
    ('TU13','NL01',20), ('TU13','NL05',30), ('TU13','NL07',40), ('TU13','NL10',20), ('TU13','NL18',1), ('TU13','NL19',1),
    -- Matcha đá xay
    ('TU14','NL04',10), ('TU14','NL06',100), ('TU14','NL07',40), ('TU14','NL10',25), ('TU14','NL18',1), ('TU14','NL19',1),
    -- Dâu đá xay
    ('TU15','NL16',120), ('TU15','NL06',100), ('TU15','NL07',40), ('TU15','NL10',20), ('TU15','NL18',1), ('TU15','NL19',1),
    -- Xoài đá xay
    ('TU16','NL15',150), ('TU16','NL06',100), ('TU16','NL07',40), ('TU16','NL10',20), ('TU16','NL18',1), ('TU16','NL19',1);

-- 1.9 Khách hàng (mã nhập tay, sau đó đặt lại Seq_Khach để app tự sinh mã tiếp theo)
INSERT INTO Khach (MaKH, TenKH, SoDienThoai, MaLoaiKH) VALUES
('KH000001', N'Nguyễn Thị Hoa',   '0912000001', 'LKH03'),
('KH000002', N'Trần Quốc Bảo',    '0912000002', 'LKH03'),
('KH000003', N'Lê Thanh Tùng',    '0912000003', 'LKH02'),
('KH000004', N'Phạm Ngọc Anh',    '0912000004', 'LKH02'),
('KH000005', N'Hoàng Minh Khôi',  '0912000005', 'LKH02'),
('KH000006', N'Đỗ Thùy Linh',     '0912000006', 'LKH01'),
('KH000007', N'Vũ Đức Thắng',     '0912000007', 'LKH01'),
('KH000008', N'Bùi Khánh Vy',     '0912000008', 'LKH01'),
('KH000009', N'Ngô Gia Huy',      '0912000009', 'LKH01'),
('KH000010', N'Đặng Mai Phương',  '0912000010', 'LKH01');
ALTER SEQUENCE Seq_Khach RESTART WITH 11;
GO

-- =====================================================================
-- PHẦN 2: NHẬP KHO VÀ CHI TIỀN
-- Trigger trg_CTPN_CongKho tự cộng tồn kho khi chèn ChiTietPhieuNhap.
-- Tổng nhập mỗi nguyên liệu đã được tính lớn hơn tổng tiêu hao của 60 hóa đơn mẫu.
-- =====================================================================
DECLARE @Hom DATE = CAST(GETDATE() AS DATE);

INSERT INTO PhieuNhap (MaPN, NgayNhap, GhiChu, MaNCC, MaNV) VALUES
('PN000001', DATEADD(DAY, -32, GETDATE()), N'Nhập đầu kỳ - cà phê, trà',      'NCC01', 'NV005'),
('PN000002', DATEADD(DAY, -32, GETDATE()), N'Nhập đầu kỳ - sữa, kem',         'NCC02', 'NV005'),
('PN000003', DATEADD(DAY, -32, GETDATE()), N'Nhập đầu kỳ - trái cây',         'NCC03', 'NV005'),
('PN000004', DATEADD(DAY, -32, GETDATE()), N'Nhập đầu kỳ - ly, ống hút',      'NCC04', 'NV005'),
('PN000005', DATEADD(DAY, -32, GETDATE()), N'Nhập đầu kỳ - siro, đường, bột', 'NCC05', 'NV005'),
('PN000006', DATEADD(DAY, -15, GETDATE()), N'Bổ sung sữa, kem',               'NCC02', 'NV005'),
('PN000007', DATEADD(DAY, -15, GETDATE()), N'Bổ sung trái cây',               'NCC03', 'NV005'),
('PN000008', DATEADD(DAY,  -7, GETDATE()), N'Bổ sung cà phê, trà',            'NCC01', 'NV005'),
('PN000009', DATEADD(DAY,  -7, GETDATE()), N'Bổ sung đường, bột, trân châu',  'NCC05', 'NV005'),
('PN000010', DATEADD(DAY,  -7, GETDATE()), N'Bổ sung ly, ống hút',            'NCC04', 'NV005');

-- Đơn giá tính theo đơn vị của nguyên liệu (đồng/gram, đồng/ml, đồng/cái)
INSERT INTO ChiTietPhieuNhap (MaPN, MaNL, SoLuongNhap, DonGiaNhap, HanSuDung) VALUES
('PN000001', 'NL01', 4000,  95, DATEADD(DAY, 180, @Hom)),
('PN000001', 'NL02', 2000, 180, DATEADD(DAY, 180, @Hom)),
('PN000001', 'NL03', 1000, 120, DATEADD(DAY, 300, @Hom)),
('PN000001', 'NL04',  600, 650, DATEADD(DAY, 240, @Hom)),
('PN000002', 'NL05', 6000,  30, DATEADD(DAY, 120, @Hom)),
('PN000002', 'NL06', 20000, 28, DATEADD(DAY,  25, @Hom)),
('PN000002', 'NL07', 3000, 120, DATEADD(DAY,  20, @Hom)),
('PN000003', 'NL13', 3000,  45, DATEADD(DAY,  90, @Hom)),
('PN000003', 'NL14', 9000,  30, DATEADD(DAY,  10, @Hom)),
('PN000003', 'NL15', 8000,  35, DATEADD(DAY,   8, @Hom)),
('PN000003', 'NL16', 5000,  90, DATEADD(DAY,   7, @Hom)),
('PN000003', 'NL17', 2000,  25, DATEADD(DAY,  12, @Hom)),
('PN000004', 'NL18', 1000, 600, NULL),
('PN000004', 'NL19', 1000, 150, NULL),
('PN000005', 'NL08', 2000,  80, DATEADD(DAY, 200, @Hom)),
('PN000005', 'NL09', 1500,  90, DATEADD(DAY, 200, @Hom)),
('PN000005', 'NL10', 6000,  22, DATEADD(DAY, 365, @Hom)),
('PN000005', 'NL11', 2000,  70, DATEADD(DAY, 150, @Hom)),
('PN000005', 'NL12', 3000,  60, DATEADD(DAY,  45, @Hom)),
('PN000006', 'NL05', 4000,  30, DATEADD(DAY, 120, @Hom)),
('PN000006', 'NL06', 10000, 28, DATEADD(DAY,  20, @Hom)),
('PN000006', 'NL07', 2000, 120, DATEADD(DAY,  18, @Hom)),
('PN000007', 'NL14', 6000,  30, DATEADD(DAY,   9, @Hom)),
('PN000007', 'NL15', 6000,  35, DATEADD(DAY,   7, @Hom)),
('PN000007', 'NL16', 4000,  90, DATEADD(DAY,   6, @Hom)),
('PN000008', 'NL01', 2000,  95, DATEADD(DAY, 170, @Hom)),
('PN000008', 'NL02', 1000, 180, DATEADD(DAY, 170, @Hom)),
('PN000008', 'NL03',  500, 120, DATEADD(DAY, 290, @Hom)),
('PN000008', 'NL04',  400, 650, DATEADD(DAY, 230, @Hom)),
('PN000009', 'NL10', 4000,  22, DATEADD(DAY, 360, @Hom)),
('PN000009', 'NL11', 1000,  70, DATEADD(DAY, 140, @Hom)),
('PN000009', 'NL12', 1000,  60, DATEADD(DAY,  40, @Hom)),
('PN000010', 'NL18',  500, 600, NULL),
('PN000010', 'NL19',  500, 150, NULL);
ALTER SEQUENCE Seq_PhieuNhap RESTART WITH 11;

-- Phiếu chi thanh toán NCC cho từng phiếu nhập (số tiền lấy từ view v_PhieuNhap), do kế toán NV006 lập
INSERT INTO PhieuChi (MaPC, NgayChi, SoTienChi, LyDoChi, MaNCC, MaNV)
SELECT 'PC' + RIGHT('000000' + CAST(ROW_NUMBER() OVER (ORDER BY MaPN) AS VARCHAR(10)), 6),
       DATEADD(DAY, 1, NgayNhap),
       TongTien,
       N'Thanh toán phiếu nhập ' + MaPN,
       MaNCC,
       'NV006'
FROM v_PhieuNhap;

-- Các khoản chi khác (không thuộc NCC nào nên MaNCC = NULL)
INSERT INTO PhieuChi (MaPC, NgayChi, SoTienChi, LyDoChi, MaNCC, MaNV) VALUES
('PC000011', DATEADD(DAY, -25, GETDATE()), 15000000, N'Tiền thuê mặt bằng',             NULL, 'NV006'),
('PC000012', DATEADD(DAY, -20, GETDATE()),  3200000, N'Tiền điện nước tháng trước',     NULL, 'NV006'),
('PC000013', DATEADD(DAY, -10, GETDATE()),   850000, N'Sửa chữa máy xay sinh tố',       NULL, 'NV006');
ALTER SEQUENCE Seq_PhieuChi RESTART WITH 14;
GO

-- =====================================================================
-- PHẦN 3: HÓA ĐƠN LỊCH SỬ 30 NGÀY (60 hóa đơn, mỗi ngày 2 hóa đơn)
-- Dữ liệu sinh theo công thức cố định nên chạy lại luôn ra cùng kết quả.
--  - Chèn HoaDon rồi ChiTietHoaDon: trigger tự trừ kho, đặt bàn COKHACH.
--  - Sau đó cập nhật trạng thái: trigger tự trả bàn TRONG và cộng điểm khách.
--  - Hóa đơn thứ 20, 40, 60 bị HỦY để trigger hoàn kho được thể hiện.
-- Mã hóa đơn lấy từ Seq_HoaDon, giống cách sp_TaoHoaDon sinh mã.
-- =====================================================================
DECLARE @Hom DATE = CAST(GETDATE() AS DATE);
DECLARE @i INT = 1, @j INT, @SoDong INT, @Seq BIGINT;
DECLARE @MaHD VARCHAR(20), @MaBan VARCHAR(20), @MaNV VARCHAR(20), @MaKH VARCHAR(20), @MaTU VARCHAR(20);
DECLARE @PT NVARCHAR(50), @NgayLap DATETIME, @Idx INT, @SL INT;
DECLARE @Tong DECIMAL(12,2), @CK DECIMAL(5,2), @Giam DECIMAL(12,2), @Diem INT;

WHILE @i <= 60
BEGIN
    SET @Seq = NEXT VALUE FOR Seq_HoaDon;
    SET @MaHD = 'HD' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);

    -- ngày: từ 30 ngày trước đến hôm qua; giờ: 8h-20h
    SET @NgayLap = DATEADD(MINUTE, (@i * 17) % 60,
                   DATEADD(HOUR, 8 + (@i * 5) % 13,
                   CAST(DATEADD(DAY, -(31 - (@i + 1) / 2), @Hom) AS DATETIME)));

    SET @MaBan = 'B' + RIGHT('0' + CAST(1 + (@i * 3) % 10 AS VARCHAR(2)), 2);
    SET @MaNV  = CASE @i % 3 WHEN 0 THEN 'NV002' WHEN 1 THEN 'NV003' ELSE 'NV004' END;
    SET @MaKH  = CASE WHEN @i % 3 = 0 THEN NULL
                      ELSE 'KH' + RIGHT('000000' + CAST(1 + @i % 10 AS VARCHAR(2)), 6) END;
    SET @PT    = CHOOSE(@i % 4 + 1, N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử');

    INSERT INTO HoaDon (MaHD, NgayLap, MaKH, MaNV, MaBan)
    VALUES (@MaHD, @NgayLap, @MaKH, @MaNV, @MaBan);

    -- 2 đến 4 món khác nhau mỗi hóa đơn, số lượng 1 đến 3
    SET @SoDong = 2 + @i % 3;
    SET @j = 0;
    WHILE @j < @SoDong
    BEGIN
        SET @Idx  = 1 + (@i + @j * 5) % 16;
        SET @SL   = 1 + (@i + @j) % 3;
        SET @MaTU = 'TU' + RIGHT('0' + CAST(@Idx AS VARCHAR(2)), 2);

        INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, DonGia)
        SELECT @MaHD, MaThucUong, @SL, DonGiaBan FROM ThucUong WHERE MaThucUong = @MaTU;

        SET @j += 1;
    END

    IF @i % 20 = 0
    BEGIN
        UPDATE HoaDon SET TrangThai = N'Đã hủy' WHERE MaHD = @MaHD;
    END
    ELSE
    BEGIN
        -- cùng công thức với sp_ThanhToanHoaDon: giảm giá theo loại khách, 10.000đ = 1 điểm
        SET @Tong = dbo.fn_TinhThanhTienHoaDon(@MaHD);
        SET @CK   = 0;
        IF @MaKH IS NOT NULL SET @CK = dbo.fn_ChietKhauTheoLoaiKH(@MaKH);
        SET @Giam = ROUND(@Tong * @CK / 100.0, 0);
        SET @Diem = CAST((@Tong - @Giam) / 10000 AS INT);

        UPDATE HoaDon
        SET TrangThai = N'Đã thanh toán',
            NgayThanhToan = DATEADD(MINUTE, 20 + (@i * 7) % 40, @NgayLap),
            TienGiamGia = @Giam,
            DiemTichLuyCong = @Diem,
            PhuongThucThanhToan = @PT
        WHERE MaHD = @MaHD;
    END

    SET @i += 1;
END

-- 3 hóa đơn đang mở (chưa thanh toán) để demo sơ đồ bàn có bàn đỏ
DECLARE @HD1 VARCHAR(20), @HD2 VARCHAR(20), @HD3 VARCHAR(20);
SET @Seq = NEXT VALUE FOR Seq_HoaDon; SET @HD1 = 'HD' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);
SET @Seq = NEXT VALUE FOR Seq_HoaDon; SET @HD2 = 'HD' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);
SET @Seq = NEXT VALUE FOR Seq_HoaDon; SET @HD3 = 'HD' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);

INSERT INTO HoaDon (MaHD, MaKH, MaNV, MaBan) VALUES
(@HD1, NULL,       'NV002', 'B02'),
(@HD2, 'KH000001', 'NV003', 'B05'),
(@HD3, 'KH000003', 'NV004', 'B09');

INSERT INTO ChiTietHoaDon (MaHD, MaThucUong, SoLuong, DonGia)
SELECT v.MaHD, v.MaTU, v.SL, tu.DonGiaBan
FROM (VALUES
    (@HD1, 'TU02', 2), (@HD1, 'TU07', 1),
    (@HD2, 'TU08', 2), (@HD2, 'TU13', 1), (@HD2, 'TU06', 1),
    (@HD3, 'TU03', 1), (@HD3, 'TU10', 2)
) AS v(MaHD, MaTU, SL)
JOIN ThucUong tu ON tu.MaThucUong = v.MaTU;
GO

-- =====================================================================
-- PHẦN 4: CHỈNH TỒN KHO ĐỂ DEMO (chỉnh trực tiếp, không qua nghiệp vụ)
--  - NL16 Dâu tây còn 100g: bán Sinh tố dâu / Dâu đá xay sẽ báo "không đủ nguyên liệu".
--  - NL04, NL07, NL11 dưới mức tối thiểu: v_TonKhoCanhBao hiển thị cảnh báo.
--    Sau khi Thủ kho nhập hàng, cảnh báo sẽ biến mất.
-- =====================================================================
UPDATE NguyenLieu SET SoLuongTonKho = 100 WHERE MaNL = 'NL16';
UPDATE NguyenLieu SET SoLuongTonKho = 250 WHERE MaNL = 'NL04';
UPDATE NguyenLieu SET SoLuongTonKho = 400 WHERE MaNL = 'NL07';
UPDATE NguyenLieu SET SoLuongTonKho = 800 WHERE MaNL = 'NL11';
GO

-- =====================================================================
-- PHẦN 5: KIỂM TRA KẾT QUẢ
-- =====================================================================
SELECT N'NhanVien' AS Bang, COUNT(*) AS SoDong FROM NhanVien
UNION ALL SELECT N'Khach',           COUNT(*) FROM Khach
UNION ALL SELECT N'Ban',             COUNT(*) FROM Ban
UNION ALL SELECT N'ThucUong',        COUNT(*) FROM ThucUong
UNION ALL SELECT N'NguyenLieu',      COUNT(*) FROM NguyenLieu
UNION ALL SELECT N'CongThuc',        COUNT(*) FROM CongThuc
UNION ALL SELECT N'PhieuNhap',       COUNT(*) FROM PhieuNhap
UNION ALL SELECT N'ChiTietPhieuNhap',COUNT(*) FROM ChiTietPhieuNhap
UNION ALL SELECT N'PhieuChi',        COUNT(*) FROM PhieuChi
UNION ALL SELECT N'HoaDon',          COUNT(*) FROM HoaDon
UNION ALL SELECT N'ChiTietHoaDon',   COUNT(*) FROM ChiTietHoaDon;

SELECT TrangThai, COUNT(*) AS SoHoaDon FROM HoaDon GROUP BY TrangThai;
SELECT TrangThai, COUNT(*) AS SoBan FROM Ban GROUP BY TrangThai;      -- mong đợi: 3 COKHACH, 7 TRONG
SELECT * FROM v_TonKhoCanhBao;                                        -- mong đợi: NL04, NL07, NL11, NL16
SELECT TOP 7 * FROM v_DoanhThuTheoNgay ORDER BY Ngay DESC;
SELECT MaKH, TenKH, DiemTichLuy FROM Khach ORDER BY MaKH;
GO
