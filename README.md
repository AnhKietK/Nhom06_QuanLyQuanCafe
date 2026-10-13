# Nhóm 06 - Hệ Thống Quản Lý Quán Cà Phê

> **Đồ án cuối kỳ môn:** Hệ quản trị Cơ sở dữ liệu (DBMS330284)  
> **Ứng dụng:** Desktop Application kết nối Microsoft SQL Server  
> **Kiến trúc:** 3-tier Architecture (GUI - BLL - DAL - DTO)

---

## 👥 Thành viên nhóm & Phân công công việc

| STT | Họ và tên | MSSV | Vai trò | Module & Nghiệp vụ phụ trách |
| :---: | :--- | :---: | :---: | :--- |
| 1 | **Hoàng Anh Kiệt** | 24110264 | Trưởng nhóm | Kiến trúc 3 tầng, Base BLL/DAL, Theme Dark/Light, Bảo mật & Phân quyền RBAC, Quản trị hệ thống, Hóa đơn |
| 2 | **Lê Anh Duy** | 24110180 | Thành viên | Bán hàng (POS), Sơ đồ bàn, Đặt món, Chuyển bàn, Giao diện phục vụ & thu ngân |
| 3 | **Võ Lê Ngọc Hưng** | 24110233 | Thành viên | Quản lý kho, Nguyên liệu, Nhà cung cấp, Phiếu nhập kho, Công thức định lượng |
| 4 | **Nguyễn Đặng Khánh Sơn Sơn** | 24110318 | Thành viên | Quản lý khách hàng (CRM), Thẻ thành viên, Phiếu chi, Báo cáo & Thống kê doanh thu |

---

## 🛠 Công nghệ sử dụng

* **Nền tảng ứng dụng:** C# WinForms (.NET 10 - `net10.0-windows`)
* **Hệ quản trị CSDL:** Microsoft SQL Server 2022
* **Thư viện kết nối:** ADO.NET (`Microsoft.Data.SqlClient`)
* **Giao diện:** Tùy biến Dark/Light Theme (`Theme.cs`), bố cục tối ưu co giãn, tự động làm mới dữ liệu (`Form_Activated`)
* **Bảo mật CSDL:** Role-Based Access Control (RBAC), Stored Procedures với tham số an toàn (Parameterization), `BEGIN TRY...BEGIN CATCH` và Transaction Control

---

## 🚀 Hướng dẫn cài đặt & Khởi chạy

### 1. Chuẩn bị Cơ sở dữ liệu (SQL Server)
1. Mở **SQL Server Management Studio (SSMS)** và đăng nhập bằng quyền Windows Authentication.
2. Bật chế độ xác thực kép:
   * Chuột phải vào tên Server $\rightarrow$ chọn **Properties** $\rightarrow$ chọn tab **Security**.
   * Chọn **SQL Server and Windows Authentication mode** $\rightarrow$ nhấn **OK**.
   * Chuột phải vào Server $\rightarrow$ chọn **Restart**.
3. Chạy lần lượt các script trong thư mục `database/`:
   * `01_schema_full.sql`: Khởi tạo database, bảng, ràng buộc 3NF, view, function, SP và phân quyền RBAC.
   * `02_du_lieu_mau.sql`: Nạp dữ liệu mẫu ban đầu (danh mục, đồ uống, bàn, nhân viên, nguyên liệu).
   * `03_backup_recovery_concurrency.sql`: Kịch bản kiểm thử phục hồi, sao lưu (Full/Diff/Log) và minh chứng xử lý tranh chấp đồng thời (Concurrency).

### 2. Cấu hình kết nối ứng dụng
1. Vào thư mục `src/QuanLyQuanCafe/`.
2. Sao chép file `App.config.example` thành file `App.config`:
   ```powershell
   Copy-Item src/QuanLyQuanCafe/App.config.example src/QuanLyQuanCafe/App.config
