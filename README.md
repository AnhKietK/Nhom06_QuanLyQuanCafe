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
2. (Tùy chọn) Copy `database/00_init_local_logins.sql.example` thành `database/00_init_local_logins.sql`, đổi mật khẩu cho các login rồi chạy trên SQL Server.
3. Trong SSMS chạy lần lượt `database/01_schema_full.sql`, rồi `database/02_du_lieu_mau.sql`.
4. (Tùy chọn) Chạy `database/03_backup_recovery_concurrency.sql` để kiểm tra phân quyền, đo hiệu năng chỉ mục và chạy bộ kiểm thử tự động.
5. Copy `src/QuanLyQuanCafe/App.config.example` thành `App.config`, điền tên server và mật khẩu khớp với bước trên.
6. Mở solution bằng Visual Studio 2022, nhấn F5.

## Tài khoản demo (mật khẩu chung: 123456)
| SĐT | Vai trò |
| --- | --- |
| 0901000001 | Quản lý |
| 0901000002 | Phục vụ |
| 0901000004 | Thu ngân |
| 0901000005 | Thủ kho |
| 0901000006 | Kế toán |

## Chuyển khoản VietQR và ảnh thức uống
- Chọn **Chuyển khoản** để tải mã VietQR cho Vietcombank (VCB), STK **1050243586**, số tiền sau giảm giá và nội dung "TT <mã hóa đơn>". Cần Internet để tải QR; có nút tải lại khi lỗi mạng. Thu ngân kiểm tra tiền đã nhận trước khi xác nhận.
- Ảnh trong "src/QuanLyQuanCafe/Resources/Images/ThucUong" được tự sao chép khi build/publish. CSDL chỉ lưu tên file, không dùng đường dẫn ổ D: của một máy. Khi chia sẻ bản build, gửi toàn bộ thư mục đầu ra, bao gồm Resources.
- Dữ liệu mẫu trong `database/02_du_lieu_mau.sql` đã gắn sẵn tên file ảnh chuẩn cho toàn bộ 16 món.
- API ảnh dùng VietQR Quick Link: https://www.vietqr.io/qr-dong . PNG hiện được hỗ trợ; VietQR đã thông báo kế hoạch ngừng hỗ trợ PNG/JPEG trong năm 2027: https://www.vietqr.io/thong-bao-cap-nhat .

## Bán tại quán và mang về
- Toàn bộ logic bán tại quán và mang về đã được tích hợp hoàn chỉnh trong `database/01_schema_full.sql`.
- Trong màn hình bán hàng, chọn **Tại quán** để chọn bàn, hoặc **Mang về** để xem các đơn mang về đang mở. Bấm **Tạo đơn mới** rồi thêm món; cũng có thể thêm món trực tiếp để tự tạo đơn mang về.
- Có thể mở nhiều đơn mang về, chuyển sang đơn khác hoặc quay lại sau khi đóng màn hình. Chọn đúng mã hóa đơn trong danh sách để thêm món, thanh toán, hủy hoặc in tạm tính.
- Mã bàn `B_MANGVE` và vị trí `VT_MANGVE` là dữ liệu quy ước, được tự tạo trong SP khi tạo đơn mang về đầu tiên và ẩn khỏi danh sách bàn. Đơn mang về vẫn trừ/hoàn kho, cộng điểm, giảm giá và dùng VietQR như đơn tại quán.
- Kịch bản kiểm thử quy trình bán tại quán và mang về được tích hợp ở Phần 6 trong `database/03_backup_recovery_concurrency.sql` (chạy bằng giao dịch rollback tự động dọn dẹp, không để lại dữ liệu rác).
