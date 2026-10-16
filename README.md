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

---

## 🔑 Tài khoản đăng nhập ứng dụng (App Login Demo)

Khi mở phần mềm, sử dụng các tài khoản nhân viên dưới đây để đăng nhập trên màn hình **Đăng nhập** và kiểm thử phân quyền theo từng vai trò:

| Tài khoản (SĐT) | Mật khẩu | Họ và tên | Vai trò (Role) | Các chức năng được phép sử dụng trên phần mềm |
| :---: | :---: | :--- | :---: | :--- |
| `0901000001` | `123456` | Nguyễn Văn An | **Quản lý** | Toàn quyền hệ thống: Bán hàng, Quản lý Nhân viên, Bàn, Thực đơn, Công thức, Kho, Khách hàng, Chi tiền, Báo cáo thống kê |
| `0901000002` | `123456` | Trần Thị Bích | **Phục vụ** | Bán hàng tại quán & mang về (POS), mở bàn, thêm món, chuyển bàn, quản lý thông tin Khách hàng |
| `0901000004` | `123456` | Phạm Minh Duy | **Thu ngân** | Bán hàng (POS), áp dụng chiết khấu thành viên, thanh toán hóa đơn (Tiền mặt / Thẻ / VietQR), xem hóa đơn |
| `0901000005` | `123456` | Lê Hoàng Long | **Thủ kho** | Quản lý Nguyên liệu, Nhà cung cấp, lập Phiếu nhập kho trọn gói, quản lý Thức uống & Công thức định lượng |
| `0901000006` | `123456` | Vũ Thu Thảo | **Kế toán** | Xem Báo cáo doanh thu theo ngày, thống kê món bán chạy, nhật ký hóa đơn, lập Phiếu chi tiền nhà cung cấp & vận hành |

---

## 🔒 Tài khoản phân quyền cấp Cơ sở dữ liệu (SQL Server RBAC)

Sau khi nhân viên đăng nhập thành công trên giao diện, ứng dụng sẽ tự động chuyển đổi chuỗi kết nối sang đúng **SQL Server Login** tương ứng với vai trò của nhân viên đó:

| SQL Server Login | Mật khẩu SQL | Database User | Database Role | Chuỗi kết nối (`App.config`) | Quyền hạn dưới SQL Server |
| :--- | :---: | :--- | :---: | :---: | :--- |
| `login_auth` | `AuthLogin@123` | `user_auth` | *(Không có)* | `AuthConn` | Chỉ có duy nhất quyền `EXECUTE` trên `sp_DangNhap` để kiểm tra đăng nhập ban đầu |
| `login_quantri` | `QuanTri@123` | `user_quantri` | `db_owner` | `QuanLyConn` | Toàn quyền quản trị CSDL (`db_owner`) |
| `login_phucvu` | `PhucVu@123` | `user_phucvu` | `NhanVienPhucVu` | `PhucVuConn` | Thực thi các SP bán hàng/thanh toán/khách hàng; bị `DENY` xóa `HoaDon` và xem bảng `NhanVien` |
| `login_thukho` | `ThuKho@123` | `user_thukho` | `ThuKho` | `ThuKhoConn` | Thao tác bảng kho, nguyên liệu, nhà cung cấp, công thức; thực thi `sp_NhapKhoTronGoi` |
| `login_ketoan` | `KeToan@123` | `user_ketoan` | `KeToan` | `KeToanConn` | Truy vấn các View thống kê (`v_DoanhThuTheoNgay`, `v_MonBanChay`, `v_HoaDon`) và thực thi `sp_ChiTienNCC` |

---

## 🚀 Cách cài đặt và chạy chương trình

### Bước 1: Chuẩn bị Cơ sở dữ liệu (SQL Server)
1. Cài đặt SQL Server, bật chế độ **Mixed Mode** (*SQL Server and Windows Authentication*) rồi Restart dịch vụ SQL Server.
2. Sao chép file mẫu `database/00_init_local_logins.sql.example` thành `database/00_init_local_logins.sql` và điền mật khẩu cho 5 SQL Login khớp với bảng trên (`AuthLogin@123`, `QuanTri@123`, `PhucVu@123`, `ThuKho@123`, `KeToan@123`).
3. Mở **SSMS** và chạy lần lượt các script theo thứ tự:
   - `database/00_init_local_logins.sql` *(Tạo 5 Login cấp Server)*
   - `database/01_schema_full.sql` *(Tạo CSDL, 16 bảng, ràng buộc, Trigger, View, Function, SP, Index & Role)*
   - `database/02_du_lieu_mau.sql` *(Nạp dữ liệu mẫu và hình ảnh thức uống)*
   - `database/03_backup_recovery_concurrency.sql` *(Kịch bản Backup/Restore, Concurrency & Kiểm thử phân quyền)*

### Bước 2: Cấu hình kết nối ứng dụng (`App.config`)
1. Sao chép `src/QuanLyQuanCafe/App.config.example` thành `src/QuanLyQuanCafe/App.config` (lệnh PowerShell tại thư mục gốc dự án):
   ```powershell
   Copy-Item database/00_init_local_logins.sql.example database/00_init_local_logins.sql
   Copy-Item src/QuanLyQuanCafe/App.config.example src/QuanLyQuanCafe/App.config
   ```
2. Mở `src/QuanLyQuanCafe/App.config`, kiểm tra tên `Server=localhost` (hoặc `.\SQLEXPRESS`) và mật khẩu của 5 chuỗi kết nối khớp với Bước 1.

### Bước 3: Biên dịch và khởi chạy ứng dụng

#### Cách A: Chạy trên Visual Studio Code (VS Code)
1. Cài đặt **.NET 10 SDK** và tiện ích mở rộng **C# Dev Kit** trong VS Code.
2. Mở thư mục gốc `Nhom06_QuanLyQuanCafe` bằng VS Code.
3. Mở Terminal tích hợp (`Ctrl + ~`) và chạy các lệnh sau:
   ```powershell
   dotnet restore
   dotnet build src/QuanLyQuanCafe/QuanLyQuanCafe.csproj
   dotnet run --project src/QuanLyQuanCafe/QuanLyQuanCafe.csproj
   ```
   *(Hoặc nhấn phím **F5** trong VS Code và chọn project `QuanLyQuanCafe` để chạy Debug).*

#### Cách B: Chạy trên Visual Studio 2022
1. Mở file Solution (`.sln`) hoặc `src/QuanLyQuanCafe/QuanLyQuanCafe.csproj` bằng **Visual Studio 2022** (v17.12+ hỗ trợ .NET 10).
2. Nhấn **Ctrl + Shift + B** để Build Solution, sau đó nhấn **F5** để chạy chương trình.
