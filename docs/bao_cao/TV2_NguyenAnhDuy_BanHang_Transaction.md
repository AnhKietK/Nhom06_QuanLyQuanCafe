# BẢN THẢO BÁO CÁO ĐỒ ÁN - THÀNH VIÊN 2
**HỌ VÀ TÊN:** NGUYỄN ANH DUY (TV2)  
**VAI TRÒ TRONG DỰ ÁN:** Phân hệ Bán hàng (POS), Thiết kế CSDL & Quản lý Giao dịch  
**PHẠM VI ĐÓNG GÓP:** Chương 2 (Thiết kế CSDL, ERD, 3NF, 16 Bảng đặc tả), Chương 4 (Giao dịch Bán hàng & Tranh chấp đồng thời), Chương 5 (Giao diện Bán hàng POS, Thanh toán, Xem hóa đơn, Quản lý Bàn)  

---

# CHƯƠNG 2: PHÂN TÍCH VÀ THIẾT KẾ CƠ SỞ DỮ LIỆU

## 2.1. Phân tích thực thể và mô hình liên kết thực thể (ERD)

### 2.1.1. Danh sách và ý nghĩa 16 thực thể trong hệ thống
Để đáp ứng bài toán quản lý toàn diện quy trình vận hành quán cà phê, cơ sở dữ liệu `quanlyquancafe` được thiết kế gồm 16 thực thể liên kết chặt chẽ:
1. **LoaiKhach:** Phân loại khách hàng (Thường, Thân thiết, VIP) gắn liền với mức phần trăm chiết khấu tự động (`ChietKhau`).
2. **Khach:** Quản lý thông tin khách hàng, số điện thoại, điểm tích lũy (`DiemTichLuy`) và liên kết đến loại khách hàng.
3. **NhanVien:** Lưu trữ thông tin nhân viên, số điện thoại, ca làm việc, chức vụ, mật khẩu băm một chiều SHA2_256 và quan hệ đệ quy người quản lý trực tiếp (`MaQL`).
4. **ViTriBan:** Khu vực bố trí bàn trong quán (Tầng trệt, Tầng 1, Sân vườn và vị trí quy ước `VT_MANGVE`).
5. **Ban:** Danh sách các bàn vật lý kèm số bàn, số chỗ ngồi, trạng thái bàn (`TRONG`, `COKHACH`, `DATTRUOC`) và bàn quy ước `B_MANGVE`.
6. **LoaiThucUong:** Nhóm phân loại menu (Cà phê, Trà & Trà sữa, Sinh tố & Nước ép, Đá xay).
7. **ThucUong:** Danh mục món bán, đơn giá bán niêm yết, tên tệp hình ảnh minh họa (`HinhAnh`) và mã loại thức uống.
8. **LoaiNguyenLieu:** Phân loại nguyên liệu kèm đơn vị tính chuẩn hóa (gram, ml, cái).
9. **NguyenLieu:** Danh mục nguyên liệu trong kho, số lượng tồn kho khả dụng và ngưỡng định mức cảnh báo tối thiểu (`MucToiThieu`).
10. **CongThuc:** Thực thể kết hợp (N-N) định lượng nguyên liệu cần thiết (`SoLuongQuyDinh`) để pha chế một ly thức uống.
11. **NhaCungCap:** Thông tin đối tác cung ứng nguyên liệu (Tên, địa chỉ, số điện thoại, email).
12. **PhieuNhap:** Hóa đơn nhập hàng từ nhà cung cấp do thủ kho tiếp nhận.
13. **ChiTietPhieuNhap:** Chi tiết các mặt hàng nguyên liệu trong mỗi lần nhập kho, gồm số lượng nhập, đơn giá nhập, thành tiền và hạn sử dụng (`HanSuDung`).
14. **HoaDon:** Đơn hàng phục vụ khách, lưu trữ thời gian tạo, thời gian thanh toán, bàn ngồi, nhân viên phụ trách, khách hàng, tiền giảm giá, điểm tích lũy và trạng thái đơn.
15. **ChiTietHoaDon:** Chi tiết các món thức uống trong hóa đơn, số lượng gọi, đơn giá tại thời điểm bán và cột tính toán thành tiền.
16. **PhieuChi:** Quản lý dòng tiền chi ra thanh toán công nợ cho nhà cung cấp hoặc chi phí vận hành quán (mặt bằng, điện nước, thiết bị).

### 2.1.2. Mối quan hệ giữa các thực thể và xử lý quan hệ nhiều - nhiều (N-N)
Trong hệ thống có 3 mối quan hệ nhiều - nhiều kinh điển được giải quyết bằng các bảng trung gian:
- **Thức uống và Nguyên liệu ($N-N$):** Một thức uống được cấu thành từ nhiều nguyên liệu, và một nguyên liệu có thể dùng cho nhiều thức uống khác nhau. Quan hệ này được tách thành bảng trung gian `CongThuc(MaThucUong, MaNL)` với thuộc tính số lượng quy định `SoLuongQuyDinh`.
- **Hóa đơn và Thức uống ($N-N$):** Một hóa đơn có thể có nhiều món, và một món có thể xuất hiện trong nhiều hóa đơn. Quan hệ được chuẩn hóa thành bảng `ChiTietHoaDon(MaHD, MaThucUong)` kèm `SoLuong`, `DonGia` và thuộc tính dẫn xuất `ThanhTien`.
- **Phiếu nhập và Nguyên liệu ($N-N$):** Một phiếu nhập có thể nhập nhiều loại nguyên liệu, và một loại nguyên liệu được nhập qua nhiều đợt. Được tách thành bảng `ChiTietPhieuNhap(MaPN, MaNL)` kèm `SoLuongNhap`, `DonGiaNhap`, `HanSuDung`.

### 2.1.3. Lược đồ cơ sở dữ liệu quan hệ (Relational Schema)
Dưới đây là lược đồ cơ sở dữ liệu quan hệ hoàn chỉnh của hệ thống (trong đó các thuộc tính gạch chân là Khóa chính - PK, các thuộc tính in nghiêng có ký hiệu `(FK)` là Khóa ngoại):

1. **LoaiKhach** (<u>MaLoaiKH</u>, TenLoai, ChietKhau)
2. **NhanVien** (<u>MaNV</u>, TenNV, ChucVu, SoDienThoai, CaLamViec, MatKhau, *MaQL* (FK))
3. **ViTriBan** (<u>MaViTri</u>, TenViTri, MoTa)
4. **LoaiThucUong** (<u>MaLoaiTU</u>, TenLoai, MoTa)
5. **LoaiNguyenLieu** (<u>MaLoaiNL</u>, TenLoai, DonViTinh)
6. **NhaCungCap** (<u>MaNCC</u>, TenNCC, DiaChi, SoDienThoai, Email)
7. **Khach** (<u>MaKH</u>, TenKH, SoDienThoai, DiemTichLuy, *MaLoaiKH* (FK))
8. **Ban** (<u>MaBan</u>, SoBan, SoChoNgoi, TrangThai, *MaViTri* (FK))
9. **ThucUong** (<u>MaThucUong</u>, TenThucUong, DonGiaBan, HinhAnh, *MaLoaiTU* (FK))
10. **NguyenLieu** (<u>MaNL</u>, TenNL, SoLuongTonKho, MucToiThieu, *MaLoaiNL* (FK))
11. **PhieuChi** (<u>MaPC</u>, NgayChi, SoTienChi, LyDoChi, *MaNCC* (FK), *MaNV* (FK))
12. **PhieuNhap** (<u>MaPN</u>, NgayNhap, GhiChu, *MaNCC* (FK), *MaNV* (FK))
13. **HoaDon** (<u>MaHD</u>, NgayLap, NgayThanhToan, TienGiamGia, DiemTichLuyCong, *MaKH* (FK), *MaNV* (FK), *MaBan* (FK), TrangThai, PhuongThucThanhToan)
14. **ChiTietHoaDon** (<u>*MaHD* (FK), *MaThucUong* (FK)</u>, SoLuong, DonGia, ThanhTien)
15. **CongThuc** (<u>*MaThucUong* (FK), *MaNL* (FK)</u>, SoLuongQuyDinh)
16. **ChiTietPhieuNhap** (<u>*MaPN* (FK), *MaNL* (FK)</u>, SoLuongNhap, DonGiaNhap, ThanhTien, HanSuDung)

### 2.1.4. Hướng dẫn xuất sơ đồ ERD từ SQL Server Management Studio (SSMS)
Để phục vụ việc chèn sơ đồ ERD chuẩn xác vào báo cáo bản in, thành viên thực hiện theo các bước sau trong SSMS:
1. Mở SSMS, kết nối máy chủ SQL Server và chọn cơ sở dữ liệu `quanlyquancafe`.
2. Mở rộng cây thư mục CSDL, nhấp chuột phải vào mục **Database Diagrams** $\rightarrow$ Chọn **New Database Diagram**.
3. Trong hộp thoại *Add Table*, nhấn `Ctrl + A` để chọn toàn bộ 16 bảng $\rightarrow$ Bấm nút **Add** $\rightarrow$ Bấm **Close**.
4. Sắp xếp các bảng logic theo phân hệ: Cụm Bán hàng (`HoaDon`, `ChiTietHoaDon`, `Ban`, `ViTriBan`, `Khach`, `LoaiKhach`) nằm ở trung tâm và bên trái; Cụm Kho & Thực đơn (`ThucUong`, `CongThuc`, `NguyenLieu`, `PhieuNhap`, `ChiTietPhieuNhap`, `NhaCungCap`) nằm ở bên phải; Cụm Nhân sự & Chi tiền (`NhanVien`, `PhieuChi`) nằm ở phía dưới.
5. Nhấp chuột phải vào khoảng trống diagram $\rightarrow$ Chọn **View Page Breaks** để căn chỉnh vừa trang in A4 $\rightarrow$ Chọn **Copy Diagram to Clipboard** để dán ảnh chất lượng cao vào tài liệu.

[CHÈN HÌNH: Sơ đồ ERD 16 bảng kết nối hoàn chỉnh với đầy đủ các đường liên kết khóa ngoại (Foreign Key) xuất từ công cụ SSMS Database Diagram]

---

## 2.2. Phân tích quá trình chuẩn hóa CSDL đạt chuẩn 3NF

Quá trình thiết kế dữ liệu của Nhóm 06 trải qua các giai đoạn phân tích phụ thuộc hàm và chuẩn hóa nghiêm ngặt, đưa toàn bộ 16 quan hệ về Dạng chuẩn 3 (3NF) nhằm triệt tiêu hoàn toàn sự dư thừa dữ liệu và ngăn ngừa các bất thường khi thao tác (Insert, Update, Delete Anomaly):

### 2.2.1. Đạt Dạng chuẩn 1 (1NF - First Normal Form)
- **Định nghĩa:** Một quan hệ đạt 1NF nếu và chỉ nếu toàn bộ các thuộc tính trong quan hệ đều có miền giá trị nguyên tố (Atomic values), không chứa thuộc tính đa trị (Multi-valued) hay thuộc tính lặp/phức hợp.
- **Thực tế áp dụng trong dự án:**
  - Trong hóa đơn bán hàng, danh sách các món gọi không được lưu gộp thành chuỗi `"Cà phê sữa (2), Bạc xỉu (1)"` bên trong bảng `HoaDon`. Thay vào đó, mỗi món gọi được tách thành một bản ghi riêng biệt trong bảng `ChiTietHoaDon`.
  - Trong phiếu nhập hàng, danh sách nguyên liệu nhập được tách hoàn toàn sang bảng `ChiTietPhieuNhap`.
  - Mọi cột dữ liệu (như `SoDienThoai`, `CaLamViec`, `TrangThai`) đều lưu trữ giá trị đơn nhất, kích thước xác định. Do đó, toàn bộ 16 bảng đều thỏa mãn 1NF.

### 2.2.2. Đạt Dạng chuẩn 2 (2NF - Second Normal Form)
- **Định nghĩa:** Một quan hệ đạt 2NF nếu nó đã đạt 1NF và mọi thuộc tính không khóa đều **phụ thuộc hàm đầy đủ** vào khóa chính (không phụ thuộc vào một phần của khóa chính). Điều này đặc biệt áp dụng cho các bảng có khóa chính phức hợp gồm nhiều thuộc tính.
- **Phân tích các bảng có khóa phức hợp:**
  - Xét bảng `ChiTietHoaDon(MaHD, MaThucUong)`:
    - Khóa chính là tập hợp: `(MaHD, MaThucUong)`.
    - Phụ thuộc hàm đầy đủ: `(MaHD, MaThucUong) -> SoLuong, DonGia`.
    - Thuộc tính `SoLuong` và `DonGia` chỉ được xác định khi biết rõ cả mã hóa đơn và mã thức uống.
    - Tên thức uống (`TenThucUong`) không được lưu ở bảng này vì chỉ phụ thuộc vào `MaThucUong` (phụ thuộc bộ phận); do đó `TenThucUong` được tách riêng sang bảng `ThucUong`.
  - Xét bảng `CongThuc(MaThucUong, MaNL)`:
    - Khóa chính: `(MaThucUong, MaNL)`.
    - Phụ thuộc hàm đầy đủ: `(MaThucUong, MaNL) -> SoLuongQuyDinh`. Định lượng nguyên liệu phụ thuộc đồng thời vào loại thức uống và loại nguyên liệu.
    - Đơn vị tính (`DonViTinh`) chỉ phụ thuộc vào `MaNL`, do đó được tách sang bảng `LoaiNguyenLieu`.
  - Xét bảng `ChiTietPhieuNhap(MaPN, MaNL)`:
    - Khóa chính: `(MaPN, MaNL)`.
    - Phụ thuộc hàm đầy đủ: `(MaPN, MaNL) -> SoLuongNhap, DonGiaNhap, HanSuDung`.
  - Các bảng còn lại (`HoaDon`, `ThucUong`, `NguyenLieu`, `Khach`...) đều có khóa chính đơn thuộc tính (1 cột) nên hiển nhiên thỏa mãn 2NF.

### 2.2.3. Đạt Dạng chuẩn 3 (3NF - Third Normal Form)
- **Định nghĩa:** Một quan hệ đạt 3NF nếu nó đã đạt 2NF và không tồn tại **phụ thuộc bắc cầu** giữa các thuộc tính không khóa (nghĩa là không có trường hợp thuộc tính không khóa $X$ phụ thuộc vào thuộc tính không khóa $Y$, và $Y$ phụ thuộc vào Khóa chính).
- **Phân tích loại bỏ phụ thuộc bắc cầu trong dự án:**
  - *Trường hợp Khách hàng và Mức chiết khấu:*
    - Nếu lưu trực tiếp: `MaKH -> MaLoaiKH` và `MaLoaiKH -> ChietKhau`, dẫn đến phụ thuộc bắc cầu `MaKH -> ChietKhau`. Khi cập nhật tỷ lệ chiết khấu của hạng thẻ VIP, hệ thống phải cập nhật hàng ngàn dòng khách hàng (Dị thường cập nhật).
    - Giải pháp 3NF: Tách thành bảng riêng `LoaiKhach(MaLoaiKH, TenLoai, ChietKhau)`. Bảng `Khach` chỉ lưu khóa ngoại `MaLoaiKH`.
  - *Trường hợp Thức uống và Nhóm loại:*
    - Tách thuộc tính mô tả loại món sang bảng `LoaiThucUong(MaLoaiTU, TenLoai, MoTa)`, loại bỏ bắc cầu `MaThucUong -> MaLoaiTU -> MoTa`.
  - *Trường hợp Nguyên liệu và Đơn vị tính:*
    - Tách đơn vị tính sang bảng `LoaiNguyenLieu(MaLoaiNL, TenLoai, DonViTinh)`, loại bỏ bắc cầu `MaNL -> MaLoaiNL -> DonViTinh`.
  - *Trường hợp Bàn và Khu vực:*
    - Tách bảng `ViTriBan(MaViTri, TenViTri, MoTa)`, loại bỏ phụ thuộc bắc cầu `MaBan -> MaViTri -> TenViTri`.
  - *Trường hợp Thành tiền:*
    - Cột `ThanhTien` trong `ChiTietHoaDon` và `ChiTietPhieuNhap` được khai báo dưới dạng **Computed Column** (`AS (SoLuong * DonGia)`), không lưu trữ tĩnh, đảm bảo dữ liệu luôn luôn nhất quán với đơn giá và số lượng thực tế.

Kết luận: Toàn bộ 16 bảng của cơ sở dữ liệu đều đạt chuẩn 3NF, đảm bảo tối ưu hóa lưu trữ, tính toàn vẹn và hiệu suất vận hành cao.

---

## 2.3. Bảng đặc tả chi tiết 16 bảng trong Cơ sở dữ liệu

Dưới đây là 16 bảng đặc tả chi tiết khớp chính xác 100% với định nghĩa schema trong tệp `database/01_schema_full.sql`:

*Bảng 2.1: Đặc tả cấu trúc bảng LoaiKhach (Loại khách hàng)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaLoaiKH` | `VARCHAR(20)` | **PK** | `CHECK (MaLoaiKH LIKE 'LKH%')` | Mã loại khách hàng (Tiền tố LKH) |
| 2 | `TenLoai` | `NVARCHAR(100)` | | `NOT NULL` | Tên phân loại (Thường, Thân thiết, VIP) |
| 3 | `ChietKhau` | `DECIMAL(5,2)` | | `DEFAULT 0`, `CHECK (>= 0 AND <= 100)` | Tỷ lệ phần trăm giảm giá tự động |

*Bảng 2.2: Đặc tả cấu trúc bảng NhanVien (Nhân viên)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaNV` | `VARCHAR(20)` | **PK** | `CHECK (MaNV LIKE 'NV%')` | Mã định danh nhân viên |
| 2 | `TenNV` | `NVARCHAR(100)` | | `NOT NULL` | Họ và tên nhân viên |
| 3 | `ChucVu` | `NVARCHAR(50)` | | `CHECK (ChucVu IN (N'Quản lý', N'Phục vụ', N'Thu ngân', N'Thủ kho', N'Kế toán'))` | Chức vụ công tác |
| 4 | `SoDienThoai` | `VARCHAR(15)` | | `UNIQUE` | Số điện thoại liên hệ (Duy nhất) |
| 5 | `CaLamViec` | `NVARCHAR(50)` | | | Ca làm việc (Sáng, Chiều, Hành chính) |
| 6 | `MatKhau` | `VARCHAR(255)` | | `NOT NULL` | Mật khẩu tài khoản băm SHA2_256 |
| 7 | `MaQL` | `VARCHAR(20)` | **FK** | Tham chiếu `NhanVien(MaNV)`, `CHECK (MaQL IS NULL OR MaQL <> MaNV)` | Mã nhân viên quản lý trực tiếp |

*Bảng 2.3: Đặc tả cấu trúc bảng ViTriBan (Vị trí bàn / Khu vực)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaViTri` | `VARCHAR(20)` | **PK** | `CHECK (MaViTri LIKE 'VT%')` | Mã khu vực vị trí |
| 2 | `TenViTri` | `NVARCHAR(100)` | | `NOT NULL` | Tên khu vực (Tầng trệt, Tầng 1, Sân vườn, Mang về) |
| 3 | `MoTa` | `NVARCHAR(255)` | | | Mô tả chi tiết đặc điểm không gian |

*Bảng 2.4: Đặc tả cấu trúc bảng LoaiThucUong (Loại thức uống)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaLoaiTU` | `VARCHAR(20)` | **PK** | `CHECK (MaLoaiTU LIKE 'LTU%')` | Mã nhóm thức uống |
| 2 | `TenLoai` | `NVARCHAR(100)` | | `NOT NULL` | Tên nhóm menu (Cà phê, Trà, Đá xay...) |
| 3 | `MoTa` | `NVARCHAR(255)` | | | Mô tả nhóm thức uống |

*Bảng 2.5: Đặc tả cấu trúc bảng LoaiNguyenLieu (Loại nguyên liệu)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaLoaiNL` | `VARCHAR(20)` | **PK** | `CHECK (MaLoaiNL LIKE 'LNL%')` | Mã nhóm nguyên liệu |
| 2 | `TenLoai` | `NVARCHAR(100)` | | `NOT NULL` | Tên nhóm nguyên liệu |
| 3 | `DonViTinh` | `NVARCHAR(50)` | | `NOT NULL` | Đơn vị tính định mức chuẩn (gram, ml, cái) |

*Bảng 2.6: Đặc tả cấu trúc bảng NhaCungCap (Nhà cung cấp)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaNCC` | `VARCHAR(20)` | **PK** | `CHECK (MaNCC LIKE 'NCC%')` | Mã nhà cung cấp |
| 2 | `TenNCC` | `NVARCHAR(150)` | | `NOT NULL` | Tên công ty / Đại lý cung cấp |
| 3 | `DiaChi` | `NVARCHAR(255)` | | | Địa chỉ trụ sở nhà cung cấp |
| 4 | `SoDienThoai` | `VARCHAR(15)` | | | Số điện thoại giao dịch |
| 5 | `Email` | `VARCHAR(100)` | | | Email liên hệ nhận đơn đặt hàng |

*Bảng 2.7: Đặc tả cấu trúc bảng Khach (Khách hàng)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaKH` | `VARCHAR(20)` | **PK** | `CHECK (MaKH LIKE 'KH%')` | Mã khách hàng (Tự sinh Seq_Khach) |
| 2 | `TenKH` | `NVARCHAR(100)` | | `NOT NULL` | Tên khách hàng |
| 3 | `SoDienThoai` | `VARCHAR(15)` | | `UNIQUE` | Số điện thoại tra cứu tích điểm |
| 4 | `DiemTichLuy`| `INT` | | `DEFAULT 0`, `CHECK (DiemTichLuy >= 0)` | Điểm tích lũy mua hàng khả dụng |
| 5 | `MaLoaiKH` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `LoaiKhach(MaLoaiKH)` | Hạng thẻ thành viên của khách |

*Bảng 2.8: Đặc tả cấu trúc bảng Ban (Bàn)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaBan` | `VARCHAR(20)` | **PK** | `CHECK (MaBan LIKE 'B%')` | Mã bàn (B01... hoặc B_MANGVE) |
| 2 | `SoBan` | `INT` | | `NOT NULL`, `UNIQUE` | Số hiệu bàn hiển thị trên sơ đồ |
| 3 | `SoChoNgoi` | `INT` | | `NOT NULL`, `CHECK (SoChoNgoi > 0)` | Sức chứa số ghế ngồi của bàn |
| 4 | `TrangThai` | `NVARCHAR(50)` | | `DEFAULT N'TRONG'`, `CHECK (IN (N'TRONG', N'COKHACH', N'DATTRUOC'))` | Trạng thái phục vụ hiện tại |
| 5 | `MaViTri` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `ViTriBan(MaViTri)` | Khu vực không gian đặt bàn |

*Bảng 2.9: Đặc tả cấu trúc bảng ThucUong (Thức uống)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaThucUong` | `VARCHAR(20)` | **PK** | `CHECK (MaThucUong LIKE 'TU%')` | Mã món thức uống |
| 2 | `TenThucUong`| `NVARCHAR(150)`| | `NOT NULL` | Tên món hiển thị trên menu |
| 3 | `DonGiaBan` | `DECIMAL(12,2)`| | `NOT NULL`, `CHECK (DonGiaBan > 0)` | Đơn giá bán niêm yết (VNĐ) |
| 4 | `HinhAnh` | `VARCHAR(255)` | | | Tên file ảnh trong thư mục Resources |
| 5 | `MaLoaiTU` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `LoaiThucUong(MaLoaiTU)` | Thuộc nhóm đồ uống nào |

*Bảng 2.10: Đặc tả cấu trúc bảng NguyenLieu (Nguyên liệu)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaNL` | `VARCHAR(20)` | **PK** | `CHECK (MaNL LIKE 'NL%')` | Mã nguyên liệu pha chế |
| 2 | `TenNL` | `NVARCHAR(150)`| | `NOT NULL` | Tên nguyên liệu (Cà phê, Sữa, Siro...) |
| 3 | `SoLuongTonKho`| `DECIMAL(12,3)`| | `DEFAULT 0`, `CHECK (SoLuongTonKho >= 0)` | Số lượng thực tế còn trong kho |
| 4 | `MucToiThieu` | `DECIMAL(12,3)`| | `DEFAULT 5.0`, `CHECK (MucToiThieu >= 0)` | Ngưỡng báo động cần nhập thêm hàng |
| 5 | `MaLoaiNL` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `LoaiNguyenLieu(MaLoaiNL)` | Loại nguyên liệu và đơn vị tính |

*Bảng 2.11: Đặc tả cấu trúc bảng PhieuChi (Phiếu chi tiền)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaPC` | `VARCHAR(20)` | **PK** | `CHECK (MaPC LIKE 'PC%')` | Mã phiếu chi (Tự sinh Seq_PhieuChi) |
| 2 | `NgayChi` | `DATETIME` | | `NOT NULL`, `DEFAULT GETDATE()` | Thời gian kế toán lập phiếu chi |
| 3 | `SoTienChi` | `DECIMAL(12,2)`| | `NOT NULL`, `CHECK (SoTienChi > 0)` | Số tiền thanh toán (VNĐ) |
| 4 | `LyDoChi` | `NVARCHAR(255)`| | | Mục đích chi tiền (Tiền mặt bằng, NCC...)|
| 5 | `MaNCC` | `VARCHAR(20)` | **FK** | `NULL`, Tham chiếu `NhaCungCap(MaNCC)` | Đối tác thụ hưởng (nếu trả tiền NCC) |
| 6 | `MaNV` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `NhanVien(MaNV)` | Kế toán viên thực hiện chi tiền |

*Bảng 2.12: Đặc tả cấu trúc bảng PhieuNhap (Phiếu nhập kho)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaPN` | `VARCHAR(20)` | **PK** | `CHECK (MaPN LIKE 'PN%')` | Mã phiếu nhập (Tự sinh Seq_PhieuNhap) |
| 2 | `NgayNhap` | `DATETIME` | | `NOT NULL`, `DEFAULT GETDATE()` | Thời điểm thủ kho tiếp nhận hàng |
| 3 | `GhiChu` | `NVARCHAR(255)`| | | Ghi chú đợt giao hàng |
| 4 | `MaNCC` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `NhaCungCap(MaNCC)` | Nhà cung cấp xuất hàng |
| 5 | `MaNV` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `NhanVien(MaNV)` | Nhân viên thủ kho lập phiếu |

*Bảng 2.13: Đặc tả cấu trúc bảng HoaDon (Hóa đơn bán hàng)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaHD` | `VARCHAR(20)` | **PK** | `CHECK (MaHD LIKE 'HD%')` | Mã hóa đơn (Tự sinh Seq_HoaDon) |
| 2 | `NgayLap` | `DATETIME` | | `NOT NULL`, `DEFAULT GETDATE()` | Thời điểm mở bàn / tạo đơn |
| 3 | `NgayThanhToan`| `DATETIME` | | `NULL` | Thời điểm thu ngân chốt thanh toán |
| 4 | `TienGiamGia` | `DECIMAL(12,2)`| | `DEFAULT 0`, `CHECK (TienGiamGia >= 0)` | Số tiền được chiết khấu theo loại khách |
| 5 | `DiemTichLuyCong`| `INT` | | `DEFAULT 0`, `CHECK (>= 0)` | Số điểm cộng dồn cho khách từ đơn này |
| 6 | `MaKH` | `VARCHAR(20)` | **FK** | `NULL`, Tham chiếu `Khach(MaKH)` | Khách hàng mua (nếu có đăng ký) |
| 7 | `MaNV` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `NhanVien(MaNV)` | Nhân viên phục vụ / Thu ngân mở đơn |
| 8 | `MaBan` | `VARCHAR(20)` | **FK** | `NOT NULL`, Tham chiếu `Ban(MaBan)` | Bàn ngồi hoặc bàn mang về B_MANGVE |
| 9 | `TrangThai` | `NVARCHAR(50)` | | `DEFAULT N'Chưa thanh toán'`, `CHECK (IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy'))` | Tiến trình xử lý của đơn hàng |
| 10 | `PhuongThucThanhToan`| `NVARCHAR(50)`| | `DEFAULT N'Tiền mặt'`, `CHECK (IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử'))` | Hình thức trả tiền |

*Bảng 2.14: Đặc tả cấu trúc bảng ChiTietHoaDon (Chi tiết hóa đơn)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaHD` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `HoaDon(MaHD)` | Mã hóa đơn liên kết |
| 2 | `MaThucUong` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `ThucUong(MaThucUong)` | Món thức uống được gọi |
| 3 | `SoLuong` | `INT` | | `NOT NULL`, `CHECK (SoLuong > 0)` | Số lượng ly đặt |
| 4 | `DonGia` | `DECIMAL(12,2)`| | `NOT NULL`, `CHECK (DonGia > 0)` | Đơn giá tại thời điểm gọi món |
| 5 | `ThanhTien` | `DECIMAL(12,2)`| | `AS (SoLuong * DonGia)` | Cột tính toán tự động thành tiền |

*Bảng 2.15: Đặc tả cấu trúc bảng CongThuc (Công thức pha chế)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaThucUong` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `ThucUong(MaThucUong)` | Thức uống áp dụng công thức |
| 2 | `MaNL` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `NguyenLieu(MaNL)` | Nguyên liệu thành phần cấu thành |
| 3 | `SoLuongQuyDinh`| `DECIMAL(12,3)`| | `NOT NULL`, `CHECK (SoLuongQuyDinh > 0)` | Định mức tiêu hao cho 1 ly đồ uống |

*Bảng 2.16: Đặc tả cấu trúc bảng ChiTietPhieuNhap (Chi tiết phiếu nhập kho)*
| STT | Tên thuộc tính | Kiểu dữ liệu | Khóa | Ràng buộc | Diễn giải ý nghĩa |
| :---: | :--- | :--- | :---: | :--- | :--- |
| 1 | `MaPN` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `PhieuNhap(MaPN)` | Mã phiếu nhập kho liên kết |
| 2 | `MaNL` | `VARCHAR(20)` | **PK, FK** | Tham chiếu `NguyenLieu(MaNL)` | Nguyên liệu được nhập |
| 3 | `SoLuongNhap` | `DECIMAL(12,3)`| | `NOT NULL`, `CHECK (SoLuongNhap > 0)` | Khối lượng/Số lượng nhập vào |
| 4 | `DonGiaNhap` | `DECIMAL(12,2)`| | `NOT NULL`, `CHECK (DonGiaNhap > 0)` | Giá nhập trên một đơn vị tính |
| 5 | `ThanhTien` | `DECIMAL(12,2)`| | `AS (SoLuongNhap * DonGiaNhap)` | Cột tính toán tổng tiền dòng nhập |
| 6 | `HanSuDung` | `DATE` | | | Hạn sử dụng của lô nguyên liệu nhập |

---

# CHƯƠNG 4: QUẢN TRỊ GIAO DỊCH VÀ TRANH CHẤP ĐỒNG THỜI (PHÂN HỆ BÁN HÀNG)

## 4.1. Cơ chế quản lý giao dịch trong các thủ tục bán hàng
Mọi thao tác thay đổi trạng thái bán hàng, mở bàn, thêm món và thanh toán đều tác động đến nhiều bảng dữ liệu đồng thời (Hóa đơn, Chi tiết hóa đơn, Bàn, Khách hàng, Tồn kho nguyên liệu). Do đó, việc bao bọc các thao tác này trong một giao dịch tường minh (`BEGIN TRANSACTION ... COMMIT TRANSACTION`) kết hợp khối bẫy lỗi `BEGIN TRY ... BEGIN CATCH` là yêu cầu kỹ thuật bắt buộc để đảm bảo thuộc tính **ACID (Nguyên tử - Nhất quán - Cô lập - Bền vững)**.

### 4.1.1. Phân tích thủ tục `sp_TaoHoaDon`
Thủ tục `sp_TaoHoaDon` chịu trách nhiệm mở bàn tại quán hoặc tạo đơn mang về mới:
- **Cơ chế bẫy lỗi và hoàn tác:** Sử dụng `BEGIN TRY` bao quanh khối giao dịch. Nếu xảy ra bất kỳ lỗi logic hoặc vi phạm ràng buộc, luồng điều khiển lập tức nhảy vào `BEGIN CATCH`:
  ```sql
  BEGIN CATCH
      IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
      THROW;
  END CATCH
  ```
  Hàm hệ thống `XACT_STATE() <> 0` kiểm tra xem giao dịch có đang hoạt động hay không trước khi phát lệnh `ROLLBACK`, ngăn chặn lỗi rollback lồng nhau.
- **Xử lý đơn mang về (Takeaway):**
  Khi `@MaBan = 'B_MANGVE'`, thủ tục sử dụng kỹ thuật kiểm tra và tự động khởi tạo vị trí `VT_MANGVE` và bàn `B_MANGVE` với gợi ý khóa `WITH (UPDLOCK, HOLDLOCK)`. Điều này đảm bảo khi nhiều thu ngân cùng bấm "Tạo đơn mang về" cùng một mili-giây đầu tiên, hệ thống không bị lỗi trùng khóa chính (Duplicate Key) trên bảng `Ban`.
  Đồng thời, đơn mang về được bỏ qua bước kiểm tra chiếm bàn (`TrangThai <> N'TRONG'`), cho phép tạo vô số đơn mang về độc lập trên cùng mã quy ước `B_MANGVE`.
- **Bảo vệ bàn tại quán:** Đối với bàn tại quán thông thường, thủ tục kiểm tra nghiêm ngặt `TrangThai <> N'TRONG'` và ném ngoại lệ lỗi `50000` nếu bàn đang có khách.

### 4.1.2. Phân tích thủ tục `sp_ThemMonVaoHoaDon`
Thủ tục thêm món vào hóa đơn đảm bảo tính nguyên tử khi đưa món ăn vào chi tiết:
- Kiểm tra tính hợp lệ của hóa đơn: Bắt buộc hóa đơn phải tồn tại và đang ở trạng thái `N'Chưa thanh toán'`. Nếu hóa đơn đã thanh toán hoặc đã hủy, thủ tục ném ngoại lệ ngăn chặn thêm món trái phép.
- Lấy đơn giá bán niêm yết từ bảng `ThucUong` tại thời điểm gọi món.
- Nếu món đã có sẵn trong hóa đơn: Cập nhật tăng số lượng `SoLuong = SoLuong + @SoLuong`.
- Nếu là món mới: Thực hiện lệnh `INSERT INTO ChiTietHoaDon`. Thao tác chèn này sẽ kích hoạt trigger `trg_CTHD_TruKho` kiểm tra lượng tồn kho và tự động trừ nguyên liệu. Nếu kho không đủ, trigger sẽ phát lệnh `RAISERROR` và `ROLLBACK TRANSACTION`, giúp thủ tục tự động hủy bỏ giao dịch thêm món một cách an toàn.

### 4.1.3. Phân tích thủ tục `sp_ThanhToanHoaDon`
Đây là thủ tục nghiệp vụ tài chính quan trọng bậc nhất của phân hệ bán hàng:
- Kiểm tra trạng thái hóa đơn: Phải là `N'Chưa thanh toán'` và bắt buộc hóa đơn phải có ít nhất 1 dòng chi tiết trong `ChiTietHoaDon`.
- Tính toán tiền hàng: Sử dụng hàm `dbo.fn_TinhThanhTienHoaDon(@MaHD)` để tính tổng tiền thực tế từ các món gọi.
- Tính toán chiết khấu tự động: Nếu hóa đơn có gắn mã khách hàng (`@MaKH IS NOT NULL`), hệ thống gọi hàm `dbo.fn_ChietKhauTheoLoaiKH(@MaKH)` để lấy tỷ lệ phần trăm giảm giá theo hạng thẻ, sau đó làm tròn thành số tiền giảm giá `TienGiamGia`.
- Tính điểm tích lũy: Tính điểm tích lũy dựa trên số tiền khách thanh toán sau giảm giá theo công thức:
  $$\text{DiemTichLuyCong} = \left\lfloor \frac{\text{TongTien} - \text{TienGiamGia}}{10000} \right\rfloor$$
- Cập nhật hóa đơn: Ghi nhận thời điểm thanh toán `NgayThanhToan = GETDATE()`, phương thức thanh toán (`PhuongThucThanhToan`) và chuyển trạng thái sang `N'Đã thanh toán'`.
- Kích hoạt Trigger liên đới: Lệnh `UPDATE` này tự động kích hoạt trigger `trg_HoaDon_ThanhToan_CapNhatBanVaDiem` để chuyển trạng thái bàn vật lý về `TRONG` và cộng dồn điểm tích lũy vào hồ sơ khách hàng. Toàn bộ tiến trình nằm trọn vẹn trong một giao dịch nhất quán.

### 4.1.4. Phân tích thủ tục `sp_HuyHoaDon` và `sp_CapNhatSoLuongMon`
- **`sp_HuyHoaDon`:** Kiểm tra hóa đơn chưa thanh toán, cập nhật trạng thái sang `N'Đã hủy'`. Lệnh cập nhật này lập tức kích hoạt trigger `trg_HoaDon_Huy_HoanKho`, tính toán tổng lượng nguyên liệu của toàn bộ các ly nước trong hóa đơn dựa trên bảng `CongThuc` để hoàn trả về kho `NguyenLieu`, đồng thời trả bàn về `TRONG`.
- **`sp_CapNhatSoLuongMon`:** Cho phép thu ngân điều chỉnh tăng/giảm số lượng ly hoặc xóa hẳn món nếu số lượng chỉnh về $\le 0$. Thao tác này kích hoạt trigger `trg_CTHD_DieuChinhKho` để tự động bù trừ kho chính xác.

---

## 4.2. Xử lý tranh chấp truy cập đồng thời (Concurrency Control)

### 4.2.1. Phân tích các hiện tượng tranh chấp (Lost Update & Dirty Read)
Trong quán cà phê vào giờ cao điểm, nhiều thu ngân cùng đăng nhập phần mềm trên các máy POS khác nhau. Nếu không có cơ chế kiểm soát đồng thời, hệ thống sẽ gặp các sự cố nghiêm trọng:
1. **Hiện tượng Mất cập nhật (Lost Update):**
   - Giả sử tồn kho của Cà phê Arabica (`NL02`) hiện còn đúng $20\text{ gram}$ (chỉ đủ pha 1 ly Cappuccino).
   - Hai thu ngân A và B cùng mở màn hình bán hàng và cùng bấm gọi món Cappuccino tại cùng một thời điểm $t_1$.
   - Cả hai giao dịch đều đọc thấy tồn kho là $20\text{ gram}$ (thỏa mãn điều kiện $\ge 18\text{ gram}$).
   - Giao dịch của thu ngân A thực hiện trừ $18\text{ gram}$ và ghi xuống đĩa lúc $t_2$.
   - Giao dịch của thu ngân B không biết A đã trừ, tiếp tục trừ $18\text{ gram}$ từ giá trị $20\text{ gram}$ đọc lúc trước và ghi đè xuống đĩa lúc $t_3$.
   - Hậu quả: Quán bán được 2 ly Cappuccino nhưng kho bị âm dữ liệu, hoặc cập nhật của A bị B ghi đè làm mất dấu.
2. **Hiện tượng Đọc dữ liệu rác (Dirty Read):**
   - Thu ngân A đang mở hóa đơn và thêm món (giao dịch chưa `COMMIT`). Tồn kho bị trừ tạm thời.
   - Thu ngân B kiểm tra tồn kho thấy nguyên liệu đã hết và thông báo từ chối khách.
   - Thu ngân A hủy đơn hàng (giao dịch `ROLLBACK`), tồn kho được phục hồi.
   - Hậu quả: Thu ngân B đã đọc dữ liệu chưa được commit của A (Dirty Read), dẫn đến việc từ chối bán hàng sai thực tế.

### 4.2.2. Giải pháp kỹ thuật với `REPEATABLE READ` và Lock Hints `UPDLOCK, HOLDLOCK`
Để giải quyết dứt điểm bài toán trên, Nhóm 06 xây dựng thủ tục chuyên biệt `sp_KiemTraVaGiuNguyenLieuPhaChe` (được trích xuất từ `03_backup_recovery_concurrency.sql`):

```sql
CREATE OR ALTER PROCEDURE sp_KiemTraVaGiuNguyenLieuPhaChe
    @MaThucUong VARCHAR(20),
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Thiết lập mức cô lập ngăn chặn đọc dữ liệu không lặp lại và đọc bẩn
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Sử dụng UPDLOCK kết hợp HOLDLOCK để khóa độc quyền phạm vi kiểm tra
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

        -- Trừ kho nguyên liệu an toàn
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
```

**Nguyên lý hoạt động của các Lock Hints:**
- **`UPDLOCK` (Update Lock):** Khi đọc dữ liệu kiểm tra số lượng tồn, SQL Server không dùng khóa chia sẻ thông thường (Shared Lock - vốn cho phép các transaction khác đọc cùng lúc) mà đặt khóa cập nhật `UPDLOCK`. Chỉ một giao dịch duy nhất được giữ `UPDLOCK` trên bản ghi nguyên liệu tại một thời điểm, ngăn chặn hai transaction cùng đọc rồi cùng giành quyền cập nhật (nguyên nhân gây Deadlock hoặc Lost Update).
- **`HOLDLOCK`:** Yêu cầu SQL Server giữ khóa `UPDLOCK` này kéo dài cho đến khi giao dịch phát lệnh `COMMIT` hoặc `ROLLBACK` kết thúc, chứ không giải phóng ngay sau lệnh `SELECT`.

### 4.2.3. Hướng dẫn thực nghiệm mở 2 Tab Query trên SSMS để chụp màn hình minh chứng
Để có hình ảnh minh chứng thực tế đưa vào báo cáo, thành viên thực hiện theo kịch bản kiểm thử sau:

1. **Chuẩn bị dữ liệu:** Mở 1 tab query đặt số lượng tồn kho của nguyên liệu `NL01` (Cà phê Robusta) về đúng $20\text{ gram}$ (chỉ đủ pha 1 ly Cà phê đen `TU01` tiêu hao $20\text{ gram}$):
   ```sql
   UPDATE NguyenLieu SET SoLuongTonKho = 20 WHERE MaNL = 'NL01';
   ```
2. **Thực hiện trên Tab 1 (Thu ngân 1):**
   Mở Tab Query 1, chạy đoạn script giữ khóa nhưng cố tình chèn lệnh chờ `WAITFOR DELAY` 10 giây trước khi commit:
   ```sql
   BEGIN TRANSACTION;
   EXEC sp_KiemTraVaGiuNguyenLieuPhaChe @MaThucUong = 'TU01', @SoLuong = 1;
   WAITFOR DELAY '00:00:10'; -- Giữ khóa 10 giây để Tab 2 tranh chấp
   COMMIT TRANSACTION;
   ```
3. **Thực hiện trên Tab 2 (Thu ngân 2):**
   Trong vòng 10 giây khi Tab 1 đang chạy, lập tức chuyển sang Tab Query 2 và nhấn F5 thực thi:
   ```sql
   EXEC sp_KiemTraVaGiuNguyenLieuPhaChe @MaThucUong = 'TU01', @SoLuong = 1;
   ```
4. **Quan sát và chụp màn hình:**
   - Tại Tab 2, trạng thái truy vấn hiển thị *"Executing query..."* (Tab 2 bị chặn lại bởi khóa `UPDLOCK, HOLDLOCK` của Tab 1, không được đọc dữ liệu rác).
   - Sau khi Tab 1 hoàn tất sau 10 giây, Tab 2 mới được cấp quyền đọc; lúc này tồn kho của `NL01` đã bị trừ về $0\text{ gram}$, Tab 2 lập tức bắt lỗi ngoại lệ `50001: Xung đột tồn kho: Không đủ nguyên liệu trong kho tại thời điểm yêu cầu`. Hiện tượng Lost Update đã được loại trừ 100%!

[CHÈN HÌNH: Ảnh chụp màn hình 2 cửa sổ SSMS đặt song song: Tab 1 đang giữ transaction và Tab 2 đang bị Blocked chờ khóa giải phóng]

[CHÈN HÌNH: Ảnh chụp màn hình kết quả Tab 2 ném lỗi ngoại lệ 50001 sau khi Tab 1 hoàn tất, chứng minh ngăn chặn thành công Lost Update]

---

# CHƯƠNG 5: THIẾT KẾ KIẾN TRÚC VÀ GIAO DIỆN ỨNG DỤNG (PHÂN HỆ BÁN HÀNG & BÀN)

## 5.1. Màn hình Bán hàng (POS) - `frmBanHang.cs`
- **Mục đích:** Là giao diện trung tâm phục vụ nhân viên thu ngân và phục vụ trong suốt ca làm việc.
- **Đặc điểm giao diện và tính năng:**
  - *Sơ đồ bàn trực quan:* Sử dụng `FlowLayoutPanel` tải động danh sách bàn từ CSDL. Các nút bàn hiển thị số bàn, số chỗ ngồi và màu sắc trạng thái: màu xanh lá cây (`#2ECC71` hoặc `Color.ForestGreen`) biểu thị bàn trống (`TRONG`), màu đỏ (`#E74C3C` hoặc `Color.Firebrick`) biểu thị bàn đang có khách (`COKHACH`).
  - *Phân tách Tại quán và Mang về:* Màn hình thiết kế 2 tab: Tab **"Tại quán"** để tương tác với sơ đồ bàn thực tế; Tab **"Mang về"** hiển thị danh sách các đơn mang về đang mở (`sp_LayDanhSachDonMangVe`). Thu ngân có thể bấm nút **"Tạo đơn mới"** hoặc chọn trực tiếp món để tạo đơn mang về trên bàn quy ước `B_MANGVE`.
  - *Danh mục thức uống và Tìm kiếm:* Danh sách món được gom nhóm theo tab loại đồ uống, có thanh tìm kiếm nhanh theo tên món. Mỗi món hiển thị hình ảnh minh họa lấy từ thư mục `Resources/Images/ThucUong`, tên món và đơn giá bán.
  - *Lưới hóa đơn tạm tính:* Hiển thị chi tiết các món đã gọi của bàn đang chọn: Tên món, Đơn giá, Số lượng, Thành tiền. Các nút thao tác nhanh: Tăng số lượng (`+`), Giảm số lượng (`-`), Xóa món, Chuyển bàn, Hủy hóa đơn, In tạm tính, Thanh toán.
- **Luồng dữ liệu qua các tầng kiến trúc:**
  - `GUI (frmBanHang)` $\rightarrow$ Gọi phương thức `BanHangBLL.LayDanhSachBan()` và `BanHangBLL.LayChiTietHoaDon(maHD)`.
  - `BLL (BanHangBLL)` $\rightarrow$ Kiểm tra nghiệp vụ hợp lệ qua `ValidationHelper` $\rightarrow$ Gọi `BanHangDAL`.
  - `DAL (BanHangDAL)` $\rightarrow$ Gọi `DbHelper.ExecSP("sp_LayDanhSachBan")` và `DbHelper.ExecSP("sp_LayChiTietHoaDon", ...)` để nạp `DataTable` lên giao diện.

[CHÈN HÌNH: Giao diện màn hình Bán hàng (POS) hiển thị sơ đồ bàn với các bàn xanh/đỏ và danh mục thức uống có hình ảnh]

[CHÈN HÌNH: Giao diện tab "Mang về" trên màn hình bán hàng với danh sách các đơn mang về đang chờ thanh toán]

## 5.2. Màn hình Thanh toán - `frmThanhToan.cs`
- **Mục đích:** Xử lý thủ tục tính tiền, áp dụng chiết khấu thành viên và ghi nhận phương thức thanh toán.
- **Đặc điểm giao diện và tính năng:**
  - Hiển thị bảng tóm tắt: Mã hóa đơn, Tên bàn, Tổng tiền hàng, Tỷ lệ giảm giá (%), Tiền giảm giá, Tổng tiền phải thanh toán (`TongTienThanhToan`), Điểm tích lũy cộng dồn cho khách.
  - Tích hợp 4 phương thức thanh toán: Tiền mặt, Thẻ, Ví điện tử và Chuyển khoản VietQR.
  - *Tính năng tạo mã VietQR động:* Khi thu ngân chọn phương thức "Chuyển khoản", phần mềm tự động gọi VietQR Quick Link API để hiển thị hình ảnh mã QR động theo chuẩn Napas247:
    - Ngân hàng thụ hưởng: **Vietcombank (VCB)**.
    - Số tài khoản: **1050243586**.
    - Số tiền: Đúng bằng giá trị `TongTienThanhToan`.
    - Nội dung chuyển khoản: Tự động điền `"TT <MaHD>"` (Ví dụ: `TT HD000015`).
    - Khách hàng chỉ cần mở ứng dụng ngân hàng quét mã là toàn bộ thông tin thanh toán được điền tự động chính xác 100%, loại bỏ sai sót số tiền.
  - Nút **"Xác nhận thanh toán"** gọi `BanHangBLL.ThanhToanHoaDon(...)` để thực thi thủ tục `sp_ThanhToanHoaDon` trên CSDL.

[CHÈN HÌNH: Màn hình Thanh toán hiển thị chi tiết hóa đơn, số tiền giảm giá và khung ảnh mã VietQR tự động sinh]

## 5.3. Màn hình Xem hóa đơn - `frmXemHoaDon.cs`
- **Mục đích:** Cho phép thu ngân xem lại toàn bộ lịch sử hóa đơn trong ngày hoặc in phiếu tạm tính cho khách kiểm tra trước khi quẹt thẻ/chuyển khoản.
- **Tính năng:**
  - Hiển thị danh sách hóa đơn theo ngày lọc, tìm kiếm theo mã hóa đơn hoặc số bàn.
  - Xem chi tiết từng món gọi, đơn giá, thời gian lập, nhân viên phụ trách.
  - Hỗ trợ định dạng in phiếu thanh toán mẫu chuẩn hóa để gửi khách hàng.

[CHÈN HÌNH: Màn hình xem và tra cứu danh sách hóa đơn bán hàng]

## 5.4. Màn hình Quản lý Bàn và Khu vực - `FormBan.cs`
- **Mục đích:** Dành cho quản lý quán cấu hình danh sách bàn vật lý và khu vực không gian quán.
- **Tính năng:**
  - Danh sách bàn được phân theo từng khu vực: Tầng trệt (`VT01`), Tầng 1 (`VT02`), Sân vườn (`VT03`). Bàn quy ước `B_MANGVE` được tự động ẩn khỏi màn hình này để tránh thao tác nhầm lẫn.
  - Thao tác CRUD hoàn chỉnh: Thêm bàn mới (`sp_ThemBan`), Sửa thông tin bàn/số ghế (`sp_SuaBan`), Xóa bàn (`sp_XoaBan` - kiểm tra bàn không có hóa đơn ràng buộc).
  - Quản lý khu vực vị trí: Thêm/Sửa/Xóa khu vực qua `sp_ThemViTriBan`, `sp_SuaViTriBan`, `sp_XoaViTriBan`.

[CHÈN HÌNH: Màn hình quản lý danh sách bàn và khu vực đặt bàn]

