# Nhóm 06 - Hệ Thống Quản Lý Quán Cà Phê

Đồ án cuối kỳ môn Hệ quản trị Cơ sở dữ liệu (DBMS330284).  
Ứng dụng C# WinForms (.NET 10) theo kiến trúc 3 tầng (`GUI` - `BLL` - `DAL` - `DTO`) kết nối Microsoft SQL Server để quản lý quán cà phê: bán hàng tại quán & mang về, kho, nhập hàng, khách hàng, báo cáo, phân quyền theo vai trò (RBAC).

## 👥 Thành viên nhóm & Phân công công việc

| STT | Họ và tên | MSSV | Vai trò | Module & Nghiệp vụ phụ trách |
| :---: | :--- | :---: | :---: | :--- |
| 1 | **Hoàng Anh Kiệt** | 24110264 | Trưởng nhóm | Thiết kế CSDL & ERD, Nền tảng Frontend (`Theme.cs`) & Backend (`FormDangNhap`, `FormMain`, `FormNhanVien`, `FormBan`), Đơn mang về, API VietQR, Bảo mật RBAC, Backup/Restore (Quản lý) |
| 2 | **Lê Anh Duy** | 24110180 | Thành viên | Bán hàng tại quán & mang về (POS), hóa đơn, thanh toán (`frmBanHang`, `frmThanhToan`, `frmXemHoaDon`), Giao dịch bán hàng & Xử lý tranh chấp đồng thời (Phục vụ, Thu ngân) |
| 3 | **Võ Lê Ngọc Hưng** | 24110233 | Thành viên | Kho nguyên liệu, nhập kho, nhà cung cấp, thức uống, công thức (`FormNguyenLieu`, `FormNhapKho`, `FormNhaCungCap`, `FormThucUong`, `FormCongThuc`), Ràng buộc, Trigger & Index (Thủ kho) |
| 4 | **Nguyễn Đặng Khánh Sơn** | 24110318 | Thành viên | Khách hàng, chi tiền, báo cáo thống kê, đổi mật khẩu (`FormBaoCao`, `FormChiTien`, `FormKhach`, `FormDoiMatKhau`), View, Function & Tầng tiện ích DAL (Kế toán) |

## 🛠 Công nghệ sử dụng
- **Ứng dụng:** C# WinForms (.NET 10 - `net10.0-windows`), ADO.NET (`Microsoft.Data.SqlClient`).
- **Cơ sở dữ liệu:** Microsoft SQL Server (Stored Procedures, Triggers, Views, Functions, Nonclustered Indexes, Transactions, RBAC).

## 🚀 Cách cài đặt và chạy chương trình

### Bước 1: Chuẩn bị Cơ sở dữ liệu (SQL Server)
1. Cài đặt SQL Server, bật chế độ **Mixed Mode** (*SQL Server and Windows Authentication*) rồi Restart dịch vụ SQL Server.
2. Sao chép file mẫu `database/00_init_local_logins.sql.example` thành `database/00_init_local_logins.sql` và cấu hình mật khẩu cho 5 SQL Login:
   - `login_auth`: `AuthLogin@123`
   - `login_quantri`: `QuanTri@123`
   - `login_phucvu`: `PhucVu@123`
   - `login_thukho`: `ThuKho@123`
   - `login_ketoan`: `KeToan@123`
3. Mở **SSMS** và chạy lần lượt các script theo thứ tự:
   - `database/00_init_local_logins.sql` *(Tạo 5 Login cấp Server)*
   - `database/01_schema_full.sql` *(Tạo CSDL, 16 bảng, ràng buộc, Trigger, View, Function, SP, Index & Role)*
   - `database/02_du_lieu_mau.sql` *(Nạp dữ liệu mẫu và hình ảnh thức uống)*
   - `database/03_backup_recovery_concurrency.sql` *(Kịch bản Backup/Restore, Concurrency & Kiểm thử phân quyền)*

### Bước 2: Cấu hình kết nối ứng dụng (`App.config`)
Sao chép `src/QuanLyQuanCafe/App.config.example` thành `src/QuanLyQuanCafe/App.config`, điền tên Server (ví dụ `localhost` hoặc `.\SQLEXPRESS`) và mật khẩu khớp với 5 SQL Login ở Bước 1.

*(Hoặc chạy nhanh lệnh tạo 2 file cấu hình trong PowerShell tại thư mục gốc dự án):*
```powershell
Copy-Item database/00_init_local_logins.sql.example database/00_init_local_logins.sql
Copy-Item src/QuanLyQuanCafe/App.config.example src/QuanLyQuanCafe/App.config
