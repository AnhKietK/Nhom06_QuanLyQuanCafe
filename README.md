# Nhóm 06 - Quản lý quán cà phê

Đồ án cuối kỳ môn Hệ quản trị Cơ sở dữ liệu (DBMS330284).
Ứng dụng C# WinForms (.NET 8) kết nối SQL Server để quản lý quán cà phê:
bán hàng, kho, nhập hàng, khách hàng, báo cáo, phân quyền theo vai trò.

## Thành viên
| Thành viên | MSSV | Phụ trách |
| --- | --- | --- |
| ... | ... | Nền tảng, bảo mật, quản trị (Quản lý) |
| ... | ... | Bán hàng (Phục vụ, Thu ngân) |
| ... | ... | Kho và nhà cung cấp (Thủ kho) |
| ... | ... | Khách hàng, danh mục, báo cáo (Kế toán) |

## Công nghệ
C# WinForms (.NET 8), ADO.NET (Microsoft.Data.SqlClient), Microsoft SQL Server.

## Cách cài đặt và chạy
1. Cài SQL Server, bật Mixed Mode (SQL Server and Windows Authentication).
2. Trong SSMS chạy lần lượt `database/01_schema_full.sql`, rồi `database/02_du_lieu_mau.sql`.
3. Copy `src/QuanLyQuanCafe/App.config.example` thành `App.config`, điền tên server và mật khẩu.
4. Mở solution bằng Visual Studio 2022, nhấn F5.

## Tài khoản demo (mật khẩu chung: 123456)
| SĐT | Vai trò |
| --- | --- |
| 0901000001 | Quản lý |
| 0901000002 | Phục vụ |
| 0901000004 | Thu ngân |
| 0901000005 | Thủ kho |
| 0901000006 | Kế toán |

## Quy ước làm việc
- Không commit trực tiếp vào `main`. Làm trên nhánh `feature/...`, xong mở Pull Request.
- Mỗi Pull Request do một thành viên khác duyệt.
- Mỗi file chỉ một người sở hữu, xem `docs/phan-cong.md`.