# Nhóm 06 - Hệ Thống Quản Lý Quán Cà Phê

Đồ án cuối kỳ môn Hệ quản trị Cơ sở dữ liệu (DBMS330284).
Ứng dụng C# WinForms (.NET 10) theo kiến trúc 3 tầng (GUI - BLL - DAL - DTO) kết nối Microsoft SQL Server để quản lý quán cà phê: bán hàng tại quán & mang về, kho, nhập hàng, khách hàng, báo cáo, phân quyền theo vai trò (RBAC).

## Thành viên nhóm
| STT | Thành viên | MSSV | Phụ trách |
| :---: | :--- | :---: | :--- |
| 1 | Hoàng Anh Kiệt *(Trưởng nhóm)* | 24110264 | Nền tảng, kiến trúc 3 tầng, bảo mật RBAC, quản trị (Quản lý) |
| 2 | Nguyễn Anh Duy | 24110196 | Bán hàng tại quán & mang về, hóa đơn, thanh toán VietQR (Phục vụ, Thu ngân) |
| 3 | Võ Lê Ngọc Hưng | 24110233 | Kho nguyên liệu, nhà cung cấp, công thức, Trigger & Index (Thủ kho) |
| 4 | Nguyễn Thái Sơn | 24110278 | Khách hàng, danh mục, chi tiền, báo cáo thống kê, View & Function (Kế toán) |

## Công nghệ sử dụng
* **Ứng dụng:** C# WinForms (.NET 10 - `net10.0-windows`), ADO.NET (`Microsoft.Data.SqlClient`).
* **Cơ sở dữ liệu:** Microsoft SQL Server (Stored Procedures, Triggers, Views, Functions, Nonclustered Indexes, Transactions, RBAC).

## Cách cài đặt và chạy chương trình
1. Cài đặt SQL Server, bật chế độ **Mixed Mode** (*SQL Server and Windows Authentication*).
2. Sao chép `database/00_init_local_logins.sql.example` thành `database/00_init_local_logins.sql` và cấu hình mật khẩu cho 5 SQL Login (`AuthLogin@123`, `QuanTri@123`, `PhucVu@123`, `ThuKho@123`, `KeToan@123`).
3. Mở SSMS và chạy lần lượt theo thứ tự:
   * `database/00_init_local_logins.sql` (Tạo 5 Login cấp Server)
   * `database/01_schema_full.sql` (Tạo CSDL, 16 bảng, ràng buộc, Trigger, View, Function, SP, Index & Role)
   * `database/02_du_lieu_mau.sql` (Nạp dữ liệu mẫu và hình ảnh thức uống)
   * `database/03_backup_recovery_concurrency.sql` (Kịch bản Backup/Restore, Concurrency & Kiểm thử phân quyền)
4. Sao chép `src/QuanLyQuanCafe/App.config.example` thành `src/QuanLyQuanCafe/App.config`, điền tên Server và mật khẩu tương ứng.
5. Mở Solution bằng Visual Studio 2022, nhấn **F5** (hoặc chạy `dotnet run --project src/QuanLyQuanCafe/QuanLyQuanCafe.csproj`).

## Tài khoản nhân viên demo (Mật khẩu chung: `123456`)
| Số điện thoại | Vai trò | SQL Login tương ứng |
| :---: | :--- | :--- |
| `0901000001` | Quản lý | `login_quantri` |
| `0901000002` | Phục vụ | `login_phucvu` |
| `0901000004` | Thu ngân | `login_phucvu` |
| `0901000005` | Thủ kho | `login_thukho` |
| `0901000006` | Kế toán | `login_ketoan` |