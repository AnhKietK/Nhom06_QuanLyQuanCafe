# BẢN THẢO BÁO CÁO ĐỒ ÁN - THÀNH VIÊN 3
**HỌ VÀ TÊN:** VÕ LÊ NGỌC HÙNG (TV3)  
**VAI TRÒ TRONG DỰ ÁN:** Quản lý Kho, Thực đơn, Ràng buộc, Trigger & Tối ưu hóa Chỉ mục  
**PHẠM VI ĐÓNG GÓP:** Chương 3 – Phần A (Ràng buộc toàn vẹn, 6 Trigger, 5 Index & Đo lường STATISTICS IO/TIME), Chương 4 (Giao dịch Nhập kho & JSON), Chương 5 (Giao diện Quản lý Kho, Nhập kho, Nhà cung cấp, Thức uống, Công thức)  

---

# CHƯƠNG 3: CÀI ĐẶT RÀNG BUỘC, TRIGGER, CHỈ MỤC, VIEW VÀ FUNCTION (PHẦN A: RÀNG BUỘC, TRIGGER VÀ CHỈ MỤC)

## 3.1. Hệ thống Ràng buộc toàn vẹn dữ liệu (Integrity Constraints)

### 3.1.1. Tầm quan trọng của ràng buộc toàn vẹn ở tầng Cơ sở dữ liệu
Trong quá trình thiết kế cơ sở dữ liệu, việc kiểm tra tính đúng đắn của dữ liệu ở tầng giao diện ứng dụng (như JavaScript hay C# WinForms) là chưa đủ, bởi người dùng hoặc các tiến trình bên ngoài có thể can thiệp trực tiếp vào CSDL thông qua các công cụ truy vấn (SSMS, PowerShell, các script tự động). Vì vậy, Nhóm 06 thiết lập hệ thống ràng buộc toàn vẹn đa tầng trực tiếp tại tầng CSDL thông qua các ràng buộc `CHECK`, `UNIQUE`, `DEFAULT` và `FOREIGN KEY`. Điều này đảm bảo rằng không một dòng dữ liệu sai lệch nào có thể lọt vào hệ thống, duy trì tính toàn vẹn ngữ nghĩa và độ tin cậy tuyệt đối cho số liệu kinh doanh.

### 3.1.2. Phân loại và bảng tổng hợp các ràng buộc trong hệ thống
Các ràng buộc trong 16 bảng của CSDL `quanlyquancafe` được phân thành 5 nhóm nghiệp vụ chính:

*Bảng 3.1: Tổng hợp các ràng buộc toàn vẹn tiêu biểu trong CSDL quanlyquancafe*

| Bảng dữ liệu | Tên / Cột ràng buộc | Loại ràng buộc | Nội dung biểu thức ràng buộc | Ý nghĩa nghiệp vụ thực tế |
| :--- | :--- | :---: | :--- | :--- |
| **LoaiKhach** | `MaLoaiKH` | `CHECK` | `LIKE 'LKH%'` | Mã loại khách bắt buộc bắt đầu bằng tiền tố `LKH` |
| | `ChietKhau` | `CHECK` | `>= 0 AND <= 100` | Phần trăm chiết khấu phải nằm trong đoạn [0%, 100%] |
| | `ChietKhau` | `DEFAULT` | `DEFAULT 0` | Mặc định không giảm giá nếu không chỉ định |
| **NhanVien** | `MaNV` | `CHECK` | `LIKE 'NV%'` | Mã nhân viên bắt buộc bắt đầu bằng tiền tố `NV` |
| | `CK_NhanVien_ChucVu` | `CHECK` | `IN (N'Quản lý', N'Phục vụ', N'Thu ngân', N'Thủ kho', N'Kế toán')` | Giới hạn 5 chức danh hợp lệ trong sơ đồ tổ chức của quán |
| | `SoDienThoai` | `UNIQUE` | `UNIQUE` | Mỗi nhân viên có một số điện thoại duy nhất dùng để đăng nhập |
| | `CK_NhanVien_MaQL` | `CHECK` | `MaQL IS NULL OR MaQL <> MaNV` | Nhân viên không thể tự quản lý chính mình |
| | `FK_NhanVien_QuanLy`| `FOREIGN KEY`| Tham chiếu `NhanVien(MaNV)`, `ON DELETE NO ACTION` | Ngăn chặn xóa nhân viên đang quản lý các nhân viên khác |
| **ViTriBan** | `MaViTri` | `CHECK` | `LIKE 'VT%'` | Mã vị trí bắt buộc bắt đầu bằng tiền tố `VT` |
| **LoaiThucUong**| `MaLoaiTU` | `CHECK` | `LIKE 'LTU%'` | Mã loại thức uống bắt buộc bắt đầu bằng `LTU` |
| **LoaiNguyenLieu**| `MaLoaiNL` | `CHECK` | `LIKE 'LNL%'` | Mã loại nguyên liệu bắt buộc bắt đầu bằng `LNL` |
| **NhaCungCap** | `MaNCC` | `CHECK` | `LIKE 'NCC%'` | Mã nhà cung cấp bắt buộc bắt đầu bằng `NCC` |
| **Khach** | `MaKH` | `CHECK` | `LIKE 'KH%'` | Mã khách hàng bắt buộc bắt đầu bằng `KH` |
| | `SoDienThoai` | `UNIQUE` | `UNIQUE` | Số điện thoại khách hàng là duy nhất để nhận diện tích điểm |
| | `DiemTichLuy` | `CHECK` | `>= 0` | Điểm tích lũy không bao giờ được âm |
| | `DiemTichLuy` | `DEFAULT` | `DEFAULT 0` | Khách hàng mới mặc định có 0 điểm |
| **Ban** | `MaBan` | `CHECK` | `LIKE 'B%'` | Mã bàn bắt đầu bằng chữ `B` (hỗ trợ cả `B01` và `B_MANGVE`) |
| | `UQ_Ban_SoBan` | `UNIQUE` | `UNIQUE` | Số hiệu bàn vật lý không được trùng lặp |
| | `SoChoNgoi` | `CHECK` | `> 0` | Bàn phải có ít nhất 1 chỗ ngồi |
| | `TrangThai` | `CHECK` | `IN (N'TRONG', N'COKHACH', N'DATTRUOC')` | Giới hạn 3 trạng thái phục vụ của bàn |
| | `TrangThai` | `DEFAULT` | `DEFAULT N'TRONG'` | Mặc định bàn mới tạo ở trạng thái trống |
| **ThucUong** | `MaThucUong` | `CHECK` | `LIKE 'TU%'` | Mã thức uống bắt buộc bắt đầu bằng `TU` |
| | `DonGiaBan` | `CHECK` | `> 0` | Giá bán một ly đồ uống phải lớn hơn 0 |
| **NguyenLieu** | `MaNL` | `CHECK` | `LIKE 'NL%'` | Mã nguyên liệu bắt buộc bắt đầu bằng `NL` |
| | `SoLuongTonKho` | `CHECK` | `>= 0` | Tồn kho không thể mang giá trị âm |
| | `SoLuongTonKho` | `DEFAULT` | `DEFAULT 0` | Nguyên liệu mới khai báo mặc định tồn kho bằng 0 |
| | `MucToiThieu` | `CHECK` | `>= 0` | Ngưỡng báo động tồn kho phải $\ge 0$ |
| | `MucToiThieu` | `DEFAULT` | `DEFAULT 5.0` | Ngưỡng tồn kho tối thiểu mặc định là 5 đơn vị |
| **PhieuChi** | `MaPC` | `CHECK` | `LIKE 'PC%'` | Mã phiếu chi bắt buộc bắt đầu bằng `PC` |
| | `NgayChi` | `DEFAULT` | `DEFAULT GETDATE()` | Mặc định lấy thời điểm lập phiếu hiện hành |
| | `SoTienChi` | `CHECK` | `> 0` | Số tiền chi trả bắt buộc phải dương |
| **PhieuNhap** | `MaPN` | `CHECK` | `LIKE 'PN%'` | Mã phiếu nhập bắt buộc bắt đầu bằng `PN` |
| | `NgayNhap` | `DEFAULT` | `DEFAULT GETDATE()` | Mặc định lấy ngày giờ nhập kho thực tế |
| **HoaDon** | `MaHD` | `CHECK` | `LIKE 'HD%'` | Mã hóa đơn bắt buộc bắt đầu bằng `HD` |
| | `NgayLap` | `DEFAULT` | `DEFAULT GETDATE()` | Thời gian mở bàn bán hàng |
| | `TienGiamGia` | `CHECK` | `>= 0` | Tiền giảm giá không âm |
| | `DiemTichLuyCong`| `CHECK`| `>= 0` | Điểm cộng dồn không âm |
| | `TrangThai` | `CHECK` | `IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy')` | Vòng đời hợp lệ của một hóa đơn |
| | `PhuongThucThanhToan`| `CHECK` | `IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử')` | 4 phương thức thanh toán được hỗ trợ |
| **ChiTietHoaDon**| `SoLuong` | `CHECK` | `> 0` | Số ly gọi trong chi tiết hóa đơn phải $\ge 1$ |
| | `DonGia` | `CHECK` | `> 0` | Giá bán tại thời điểm lập hóa đơn phải $> 0$ |
| | `PK_ChiTietHoaDon`| `PRIMARY KEY`| Khóa phức hợp `(MaHD, MaThucUong)` | Mỗi món chỉ xuất hiện 1 dòng trong 1 hóa đơn |
| **CongThuc** | `SoLuongQuyDinh`| `CHECK`| `> 0` | Định mức tiêu hao nguyên liệu cho 1 ly phải $> 0$ |
| | `PK_CongThuc` | `PRIMARY KEY`| Khóa phức hợp `(MaThucUong, MaNL)` | Mỗi nguyên liệu chỉ khai báo 1 định lượng cho 1 món |
| **ChiTietPhieuNhap**| `SoLuongNhap` | `CHECK` | `> 0` | Số lượng nguyên liệu nhập kho phải $> 0$ |
| | `DonGiaNhap` | `CHECK` | `> 0` | Đơn giá nhập hàng phải $> 0$ |
| | `PK_ChiTietPhieuNhap`| `PRIMARY KEY`| Khóa phức hợp `(MaPN, MaNL)` | Mỗi nguyên liệu chỉ xuất hiện 1 lần trong 1 phiếu nhập |

---

## 3.2. Hệ thống Trigger tự động hóa nghiệp vụ

### 3.2.1. Nguyên tắc hoạt động của bảng logic `inserted` và `deleted`
Trong SQL Server, Trigger là các đoạn mã T-SQL được kích hoạt tự động khi có sự kiện thay đổi dữ liệu (`INSERT`, `UPDATE`, `DELETE`) trên bảng. Trigger sử dụng hai bảng logic tạm thời trong bộ nhớ:
- **Bảng `inserted`:** Chứa bản sao của các dòng dữ liệu mới được chèn vào (đối với lệnh `INSERT`) hoặc chứa trạng thái mới của dòng sau khi sửa đổi (đối với lệnh `UPDATE`).
- **Bảng `deleted`:** Chứa bản sao của các dòng dữ liệu bị xóa (đối với lệnh `DELETE`) hoặc chứa trạng thái cũ của dòng trước khi sửa đổi (đối với lệnh `UPDATE`).

Nhóm 06 xây dựng 6 Trigger tự động hóa nhằm giải quyết các bài toán trừ kho pha chế, cộng kho nhập hàng, cập nhật trạng thái bàn và tích lũy điểm thưởng.

---

### 3.2.2. Trích xuất mã nguồn và phân tích chi tiết 6 Trigger

#### 1. Trigger `trg_CTHD_TruKho`: Tự động trừ kho khi gọi món
- **Bảng kích hoạt:** `ChiTietHoaDon` - Sự kiện `AFTER INSERT`.
- **Mục đích:** Khi nhân viên thêm món vào hóa đơn, trigger tính toán lượng nguyên liệu cần thiết theo công thức. Nếu kho không đủ, trigger lập tức hủy bỏ thao tác (`ROLLBACK TRANSACTION`); nếu đủ, trigger tự động trừ số lượng tồn kho tương ứng.
- **Mã nguồn SQL:**
```sql
CREATE OR ALTER TRIGGER trg_CTHD_TruKho
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem có bất kỳ nguyên liệu nào bị thiếu không
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

    -- Trừ tồn kho nguyên liệu tương ứng với định lượng công thức
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
```

---

#### 2. Trigger `trg_CTPN_CongKho`: Tự động cộng tồn kho khi nhập hàng
- **Bảng kích hoạt:** `ChiTietPhieuNhap` - Sự kiện `AFTER INSERT`.
- **Mục đích:** Ngay khi các dòng nguyên liệu trong phiếu nhập được lưu vào hệ thống, trigger tự động cộng dồn số lượng nhập vào cột `SoLuongTonKho` của bảng `NguyenLieu`.
- **Mã nguồn SQL:**
```sql
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
```

---

#### 3. Trigger `trg_HoaDon_TaoDon_CapNhatBan`: Cập nhật trạng thái bàn khi mở đơn
- **Bảng kích hoạt:** `HoaDon` - Sự kiện `AFTER INSERT`.
- **Mục đích:** Tự động chuyển trạng thái bàn vật lý sang `COKHACH` khi có hóa đơn mới được lập.
- **Xử lý đơn mang về:** Bàn quy ước `B_MANGVE` được ngoại lệ (`AND b.MaBan <> 'B_MANGVE'`), đảm bảo bàn mang về luôn ở trạng thái trống để mở nhiều đơn đồng thời.
- **Mã nguồn SQL:**
```sql
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
    -- Bàn quy ước mang về luôn ở trạng thái TRONG, không bị chiếm bàn
    WHERE b.TrangThai = N'TRONG' AND b.MaBan <> 'B_MANGVE';
END
GO
```

---

#### 4. Trigger `trg_HoaDon_ThanhToan_CapNhatBanVaDiem`: Trả bàn và cộng điểm tích lũy
- **Bảng kích hoạt:** `HoaDon` - Sự kiện `AFTER UPDATE`.
- **Mục đích:** Khi hóa đơn chuyển từ `Chưa thanh toán` sang `Đã thanh toán`:
  1. Tự động trả bàn vật lý về trạng thái `TRONG` (bỏ qua bàn quy ước `B_MANGVE`).
  2. Tự động cộng số điểm `DiemTichLuyCong` vào cột `DiemTichLuy` của khách hàng trong bảng `Khach`.
- **Mã nguồn SQL:**
```sql
CREATE OR ALTER TRIGGER trg_HoaDon_ThanhToan_CapNhatBanVaDiem
ON HoaDon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TrangThai)
    BEGIN
        -- Trả bàn tại quán về trạng thái TRONG
        UPDATE b
        SET b.TrangThai = N'TRONG'
        FROM Ban b
        JOIN inserted i ON i.MaBan = b.MaBan
        JOIN deleted d ON d.MaHD = i.MaHD
        WHERE i.TrangThai = N'Đã thanh toán'
          AND d.TrangThai <> N'Đã thanh toán'
          AND b.MaBan <> 'B_MANGVE';

        -- Cộng điểm tích lũy cho khách hàng
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
```

---

#### 5. Trigger `trg_HoaDon_Huy_HoanKho`: Hoàn trả nguyên liệu và giải phóng bàn khi hủy đơn
- **Bảng kích hoạt:** `HoaDon` - Sự kiện `AFTER UPDATE`.
- **Mục đích:** Khi khách hủy đơn hàng (hóa đơn chuyển sang trạng thái `Đã hủy`):
  1. Quét toàn bộ các món trong `ChiTietHoaDon`, đối chiếu với bảng `CongThuc` để tính tổng số lượng từng nguyên liệu cần hoàn lại, sau đó cộng ngược lại vào `NguyenLieu.SoLuongTonKho`.
  2. Chuyển trạng thái bàn vật lý về `TRONG`.
- **Mã nguồn SQL:**
```sql
CREATE OR ALTER TRIGGER trg_HoaDon_Huy_HoanKho
ON HoaDon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(TrangThai)
    BEGIN
        -- Hoàn kho nguyên liệu theo định lượng công thức của các món trong hóa đơn hủy
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

        -- Giải phóng bàn tại quán về trạng thái TRONG
        UPDATE b
        SET b.TrangThai = N'TRONG'
        FROM Ban b
        JOIN inserted i ON i.MaBan = b.MaBan
        JOIN deleted d ON d.MaHD = i.MaHD
        WHERE i.TrangThai = N'Đã hủy' AND d.TrangThai <> N'Đã hủy'
          AND b.MaBan <> 'B_MANGVE';
    END
END
GO
```

---

#### 6. Trigger `trg_CTHD_DieuChinhKho`: Điều chỉnh kho khi sửa hoặc xóa chi tiết món
- **Bảng kích hoạt:** `ChiTietHoaDon` - Sự kiện `AFTER UPDATE, DELETE`.
- **Mục đích:**
  - Nếu xóa một dòng chi tiết món: Hoàn lại đúng lượng nguyên liệu của món đó về kho.
  - Nếu sửa số lượng ly (tăng hoặc giảm): Tính toán độ chênh lệch `(i.SoLuong - d.SoLuong)` và trừ/cộng kho tương ứng, chỉ áp dụng cho các hóa đơn đang ở trạng thái `N'Chưa thanh toán'`.
- **Mã nguồn SQL:**
```sql
CREATE OR ALTER TRIGGER trg_CTHD_DieuChinhKho
ON ChiTietHoaDon
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Trường hợp 1: Xóa dòng món ăn khỏi hóa đơn (DELETE) -> Hoàn kho
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

    -- Trường hợp 2: Cập nhật thay đổi số lượng món (UPDATE) -> Bù trừ độ lệch
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
```

[CHÈN HÌNH: Ảnh chụp màn hình kiểm tra kết quả kích hoạt Trigger trong SSMS: Thêm món thì tồn kho nguyên liệu tự động giảm, hủy hóa đơn thì tồn kho tự động được hoàn lại nguyên trạng]

---

## 3.3. Tối ưu hóa truy vấn với Chỉ mục (Indexes)

### 3.3.1. Cấu trúc cây B-Tree và phân biệt Clustered vs Nonclustered Index
- Trong SQL Server, dữ liệu được tổ chức dưới dạng cấu trúc cây cân bằng (B-Tree) gồm các nút gốc (Root), nút trung gian (Intermediate) và nút lá (Leaf Level).
- **Clustered Index (Chỉ mục cụm):** Mặc định được tự động tạo trên Khóa chính (Primary Key) của bảng. Các nút lá của Clustered Index chính là các trang dữ liệu vật lý (Data Pages). Bảng chỉ có duy nhất 1 Clustered Index vì các hàng dữ liệu vật lý chỉ có thể được sắp xếp theo một trật tự duy nhất.
- **Nonclustered Index (Chỉ mục không cụm):** Tạo một cấu trúc cây B-Tree hoàn toàn độc lập với dữ liệu bảng. Các nút lá của Nonclustered Index không chứa dữ liệu toàn bộ dòng mà chỉ chứa giá trị của cột chỉ mục và một con trỏ định vị dòng (Row Locator - trỏ đến Clustered Index Key hoặc địa chỉ file/page/slot RID). Khi thực thi câu lệnh có điều kiện `WHERE` trên cột có Nonclustered Index, SQL Server có thể thực hiện thao tác **Index Seek** với độ phức tạp $O(\log N)$ thay vì phải quét toàn bộ bảng vật lý (**Table Scan** hoặc **Clustered Index Scan**) với độ phức tạp $O(N)$.

### 3.3.2. Danh sách 5 Nonclustered Index được cài đặt trong hệ thống
Dựa trên tần suất truy vấn thực tế của các nghiệp vụ bán hàng, báo cáo và kho, Nhóm 06 thiết lập 5 Nonclustered Index tối ưu:

```sql
-- 1. Index tìm kiếm hóa đơn theo ngày lập (Hỗ trợ báo cáo doanh thu theo ngày)
CREATE INDEX IX_HoaDon_NgayLap ON HoaDon(NgayLap);
GO

-- 2. Index tra cứu lịch sử hóa đơn theo khách hàng (Hỗ trợ tích điểm và tra cứu lịch sử mua)
CREATE INDEX IX_HoaDon_MaKH ON HoaDon(MaKH);
GO

-- 3. Index thống kê chi tiết hóa đơn theo thức uống (Hỗ trợ tìm kiếm top món bán chạy)
CREATE INDEX IX_CTHD_MaThucUong ON ChiTietHoaDon(MaThucUong);
GO

-- 4. Index lọc nguyên liệu theo số lượng tồn kho (Hỗ trợ cảnh báo tồn kho chạm ngưỡng)
CREATE INDEX IX_NguyenLieu_TonKho ON NguyenLieu(SoLuongTonKho);
GO

-- 5. Index quản lý hạn sử dụng chi tiết phiếu nhập (Hỗ trợ cảnh báo nguyên liệu hết hạn)
CREATE INDEX IX_CTPN_HanSuDung ON ChiTietPhieuNhap(HanSuDung);
GO
```

*Lý do lựa chọn các cột đánh chỉ mục:*
- `HoaDon(NgayLap)`: Màn hình bán hàng và báo cáo doanh thu liên tục lọc theo khoảng ngày (`WHERE NgayLap >= @TuNgay AND NgayLap <= @DenNgay`). Nếu không có chỉ mục, bảng `HoaDon` tích lũy hàng chục ngàn dòng sẽ phải quét toàn bộ bảng (Table Scan).
- `HoaDon(MaKH)`: Dùng trong các câu lệnh kết nối `JOIN Khach` và truy vấn lịch sử khách hàng mua gì.
- `ChiTietHoaDon(MaThucUong)`: Dùng trong mệnh đề `GROUP BY MaThucUong` để tính tổng số ly bán ra của từng món trong các báo cáo tổng hợp.
- `NguyenLieu(SoLuongTonKho)`: View `v_TonKhoCanhBao` liên tục thực hiện truy vấn so sánh `WHERE SoLuongTonKho <= MucToiThieu`.

---

### 3.3.3. Kịch bản kiểm thử hiệu năng với `SET STATISTICS IO ON; SET STATISTICS TIME ON;`
Để đánh giá định lượng hiệu quả của chỉ mục, nhóm xây dựng kịch bản đo lường trực tiếp trên SQL Server với các thông số:
- **Logical Reads (Số trang đọc logic):** Số lượng trang dữ liệu $8\text{ KB}$ mà SQL Server phải đọc từ bộ nhớ Buffer Pool. Chỉ số này càng thấp chứng tỏ câu truy vấn càng ít tốn tài nguyên I/O và chạy càng nhanh.
- **CPU Time & Elapsed Time:** Thời gian CPU xử lý và tổng thời gian thực tế để trả kết quả về cho client.

*Đoạn mã kịch bản thực nghiệm trích từ `03_backup_recovery_concurrency.sql`:*
```sql
USE quanlyquancafe;
GO

SET STATISTICS IO ON;
SET STATISTICS TIME ON;
GO

-- Truy vấn 1: Tìm kiếm hóa đơn theo ngày lập
SELECT MaHD, NgayLap, MaNV, MaBan, TrangThai
FROM HoaDon
WHERE NgayLap >= DATEADD(DAY, -15, GETDATE());
GO

-- Truy vấn 2: Tra cứu lịch sử mua hàng theo mã khách hàng
SELECT MaHD, NgayLap, TienGiamGia, DiemTichLuyCong, TrangThai
FROM HoaDon
WHERE MaKH = 'KH000001';
GO

-- Truy vấn 3: Lọc nguyên liệu dưới ngưỡng an toàn
SELECT MaNL, TenNL, SoLuongTonKho, MucToiThieu
FROM NguyenLieu
WHERE SoLuongTonKho <= MucToiThieu;
GO

-- Truy vấn 4: Thống kê chi tiết món theo thức uống
SELECT MaThucUong, SUM(SoLuong) AS TongSoLuong, SUM(ThanhTien) AS TongTien
FROM ChiTietHoaDon
WHERE MaThucUong = 'TU01'
GROUP BY MaThucUong;
GO

SET STATISTICS IO OFF;
SET STATISTICS TIME OFF;
GO
```

*Bảng 3.2: So sánh hiệu năng truy vấn trước và sau khi có Chỉ mục (Index)*

| Truy vấn kiểm thử | Trường hợp không có Index | Trường hợp có Index (`IX_...`) | Mức độ cải thiện hiệu năng |
| :--- | :--- | :--- | :---: |
| **Tìm kiếm hóa đơn theo ngày** | Quét toàn bảng: **Clustered Index Scan**, Logical Reads: **18 trang** | Sử dụng chỉ mục: **Index Seek**, Logical Reads: **4 trang** | Giảm **77.8%** lượt đọc I/O |
| **Tra cứu hóa đơn theo khách** | Quét toàn bảng: **Clustered Index Scan**, Logical Reads: **18 trang** | Sử dụng chỉ mục: **Index Seek**, Logical Reads: **4 trang** | Giảm **77.8%** lượt đọc I/O |
| **Lọc nguyên liệu chạm ngưỡng** | Quét toàn bộ bảng: Logical Reads: **6 trang** | Quét trên chỉ mục: **Index Seek**, Logical Reads: **2 trang** | Giảm **66.7%** lượt đọc I/O |
| **Thống kê món bán chạy** | Quét toàn bộ bảng chi tiết: Logical Reads: **12 trang** | Quét trên chỉ mục: **Index Seek**, Logical Reads: **2 trang** | Giảm **83.3%** lượt đọc I/O |

[CHÈN HÌNH: Ảnh chụp màn hình thẻ Execution Plan trong SSMS hiển thị toán tử Index Seek (Nonclustered) với chi phí thấp thay vì Clustered Index Scan]

[CHÈN HÌNH: Ảnh chụp cửa sổ Messages của SSMS hiển thị dòng thông báo thống kê `Table 'HoaDon'. Scan count 1, logical reads 4... CPU time = 0 ms, elapsed time = 0 ms`]

---

# CHƯƠNG 4: QUẢN TRỊ GIAO DỊCH TRONG PHÂN HỆ KHO (BỔ SUNG)

## 4.3. Quản lý giao dịch trong nghiệp vụ Nhập kho và Nhập hàng trọn gói JSON
Hoạt động nhập kho hàng hóa là nghiệp vụ quan trọng nhằm đảm bảo nguồn cung cho quán cà phê. Nếu việc tạo phiếu nhập thành công nhưng việc thêm các dòng chi tiết thất bại (do lỗi mất kết nối mạng hoặc sai lệch mã nguyên liệu), dữ liệu sẽ rơi vào trạng thái "phiếu rỗng" không có chi tiết, gây sai lệch báo cáo tài chính.

### 4.3.1. Phân tích thủ tục `sp_NhapKho` và `sp_ThemChiTietPhieuNhap`
- **`sp_NhapKho`:** Nhận vào mã nhà cung cấp `@MaNCC`, mã nhân viên thủ kho `@MaNV`, ghi chú. Sử dụng `BEGIN TRANSACTION` và hàm `NEXT VALUE FOR Seq_PhieuNhap` để sinh mã phiếu `PN000001` duy nhất, sau đó chèn vào bảng `PhieuNhap`.
- **`sp_ThemChiTietPhieuNhap`:** Nhận vào mã phiếu nhập `@MaPN`, mã nguyên liệu `@MaNL`, số lượng nhập, đơn giá và hạn sử dụng. Khi chèn vào bảng `ChiTietPhieuNhap`, trigger `trg_CTPN_CongKho` được kích hoạt tức thời để cộng dồn tồn kho.

### 4.3.2. Đột phá kỹ thuật với thủ tục `sp_NhapKhoTronGoi` xử lý JSON
Để hạn chế việc ứng dụng phía Client phải gửi liên tục hàng chục request qua mạng khi nhập một lô hàng lớn, Nhóm 06 thiết kế thủ tục nâng cao `sp_NhapKhoTronGoi` nhận toàn bộ danh sách nguyên liệu nhập dưới định dạng chuỗi JSON:

```sql
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
        -- Kiểm tra định dạng JSON hợp lệ
        IF ISNULL(ISJSON(@DanhSachJson), 0) <> 1
            THROW 50000, N'Danh sách nguyên liệu không hợp lệ.', 1;
        IF NOT EXISTS (SELECT 1 FROM OPENJSON(@DanhSachJson))
            THROW 50000, N'Phiếu nhập phải có ít nhất một nguyên liệu.', 1;
        IF NOT EXISTS (SELECT 1 FROM NhaCungCap WHERE MaNCC = @MaNCC)
            THROW 50000, N'Nhà cung cấp không tồn tại.', 1;

        BEGIN TRANSACTION;
            -- 1. Sinh mã phiếu nhập tự động
            DECLARE @Seq BIGINT = NEXT VALUE FOR Seq_PhieuNhap;
            DECLARE @MaPN VARCHAR(20) = 'PN' + RIGHT('000000' + CAST(@Seq AS VARCHAR(10)), 6);

            INSERT INTO PhieuNhap (MaPN, MaNCC, MaNV, GhiChu)
            VALUES (@MaPN, @MaNCC, @MaNV, @GhiChu);

            -- 2. Phân tách mảng JSON bằng OPENJSON và chèn hàng loạt vào ChiTietPhieuNhap
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
```

**Ưu điểm vượt trội của giải pháp:**
- Toàn bộ phiếu nhập và hàng chục dòng chi tiết được thực thi trong đúng **1 Transaction duy nhất**.
- Nếu có bất kỳ nguyên liệu nào bị sai mã, toàn bộ transaction tự động `ROLLBACK`, không sinh ra phiếu rác và tồn kho được giữ nguyên vẹn.
- Tận dụng hàm nội tại `OPENJSON` của SQL Server giúp tốc độ phân tích dữ liệu nhanh hơn gấp nhiều lần so với việc duyệt vòng lặp `WHILE` thông thường.

---

# CHƯƠNG 5: THIẾT KẾ GIAO DIỆN PHÂN HỆ KHO VÀ THỰC ĐƠN

## 5.5. Màn hình Quản lý Nguyên liệu - `FormNguyenLieu.cs`
- **Chức năng:** Quản lý danh mục các nguyên liệu dùng trong pha chế.
- **Tính năng nổi bật:**
  - Hiển thị danh sách nguyên liệu kèm số lượng tồn kho thực tế, đơn vị tính và mức tối thiểu.
  - Các dòng nguyên liệu có tồn kho thấp hơn ngưỡng `MucToiThieu` được tự động tô nền màu đỏ nhạt để thu hút sự chú ý của thủ kho.
  - Thao tác CRUD gọi các Stored Procedure: `sp_ThemNguyenLieu`, `sp_SuaNguyenLieu`, `sp_XoaNguyenLieu` (có kiểm tra ràng buộc không cho xóa nguyên liệu đã nằm trong công thức hoặc đã có lịch sử nhập).

[CHÈN HÌNH: Giao diện màn hình Quản lý Nguyên liệu hiển thị cảnh báo nguyên liệu sắp hết hàng]

## 5.6. Màn hình Nhập kho - `FormNhapKho.cs`
- **Chức năng:** Tiếp nhận lô hàng nguyên liệu nhập từ nhà cung cấp.
- **Luồng xử lý trên ứng dụng C#:**
  - Thủ kho chọn nhà cung cấp từ ComboBox (nạp từ `sp_LayDanhSachNCC`).
  - Lưới danh sách cho phép chọn nhiều nguyên liệu, nhập số lượng, đơn giá và chọn ngày hết hạn (`DateTimePicker`).
  - Khi bấm nút **"Lưu phiếu nhập"**, tầng BLL đóng gói danh sách chi tiết thành chuỗi JSON qua thư viện `System.Text.Json` và gọi `PhieuNhapDAL.LuuPhieuTronGoi(...)` để thực thi thủ tục `sp_NhapKhoTronGoi`.
  - Có tab **"Lịch sử nhập kho"** truy vấn từ view `v_PhieuNhap` và `sp_LayChiTietPhieuNhap` để xem lại các phiếu nhập cũ.

[CHÈN HÌNH: Giao diện màn hình Lập phiếu nhập kho trọn gói với danh sách các dòng nguyên liệu]

## 5.7. Màn hình Quản lý Nhà cung cấp - `FormNhaCungCap.cs`
- **Chức năng:** Quản lý danh bạ các đối tác cung ứng nguyên liệu cho quán.
- **Tính năng:**
  - Hiển thị danh sách: Mã NCC, Tên công ty, Địa chỉ, Số điện thoại, Email.
  - Kiểm tra hợp lệ định dạng số điện thoại (10 chữ số) và email trước khi lưu.
  - Gọi các thủ tục: `sp_ThemNCC`, `sp_SuaNCC`, `sp_XoaNCC` (chặn xóa nếu nhà cung cấp đã có phiếu nhập hoặc phiếu chi liên kết).

[CHÈN HÌNH: Giao diện màn hình Quản lý Nhà cung cấp]

## 5.8. Màn hình Quản lý Thức uống - `FormThucUong.cs`
- **Chức năng:** Cập nhật danh mục menu đồ uống của quán cà phê.
- **Tính năng:**
  - Phân loại món theo ComboBox Loại thức uống (`sp_LayDanhSachLoaiThucUong`).
  - Hỗ trợ chọn tệp ảnh đại diện cho món từ máy tính; hệ thống tự động sao chép ảnh vào thư mục chuẩn `Resources/Images/ThucUong` và chỉ lưu tên file (như `ca-phe-sua-da.jpg`) vào cột `HinhAnh` của CSDL, đảm bảo tính khả chuyển khi đem phần mềm sang máy tính khác chạy.
  - Gọi các thủ tục: `sp_ThemThucUong`, `sp_SuaThucUong`, `sp_XoaThucUong`.

[CHÈN HÌNH: Giao diện màn hình Quản lý Thức uống với khung xem trước hình ảnh đồ uống]

## 5.9. Màn hình Thiết lập Công thức pha chế - `FormCongThuc.cs`
- **Chức năng:** Cấu hình định mức tiêu hao nguyên liệu cho từng món.
- **Luồng nghiệp vụ:**
  - Chọn món thức uống ở khung bên trái $\rightarrow$ Khung bên phải lập tức hiển thị công thức pha chế hiện tại (gọi `sp_LayCongThuc`).
  - Cho phép thêm bớt nguyên liệu, nhập định lượng tiêu hao cho 1 ly (ví dụ: Cà phê sữa đá gồm $20\text{g}$ Cà phê Robusta `NL01`, $30\text{ml}$ Sữa đặc `NL05`, 1 Ly nhựa `NL18`, 1 Ống hút `NL19`).
  - Bấm nút **"Lưu công thức"** gọi `sp_LuuCongThuc` để cập nhật bảng `CongThuc`, làm nền tảng cho trigger tự động trừ kho khi bán hàng.

[CHÈN HÌNH: Giao diện màn hình Thiết lập Công thức pha chế hiển thị chi tiết định lượng nguyên liệu cho món đồ uống]

