# BẢN THẢO BÁO CÁO ĐỒ ÁN - THÀNH VIÊN 1
**HỌ VÀ TÊN:** HOÀNG ANH KIỆT (TRƯỞNG NHÓM - TV1)  
**VAI TRÒ TRONG DỰ ÁN:** Quản trị hệ thống, Nền tảng, Bảo mật & Phục hồi  
**PHẠM VI ĐÓNG GÓP:** Phần đầu, Chương 1, Chương 4 (Bảo mật & Phục hồi), Chương 6, Tài liệu tham khảo & Phụ lục  

---

# TRANG BÌA VÀ THÔNG TIN ĐỒ ÁN

```text
               BỘ GIÁO DỤC VÀ ĐÀO TẠO
    TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT THÀNH PHỐ HỒ CHÍ MINH
                KHOA CÔNG NGHỆ THÔNG TIN
             BỘ MÔN HỆ THỐNG THÔNG TIN
                    ***---***

             BÁO CÁO CUỐI KỲ MÔN HỌC
       HỆ QUẢN TRỊ CƠ SỞ DỮ LIỆU (DBMS330284)

                      ĐỀ TÀI:
   XÂY DỰNG HỆ THỐNG QUẢN LÝ QUÁN CÀ PHÊ
         THEO KIẾN TRÚC 3 TẦNG KẾT NỐI
          MICROSOFT SQL SERVER VÀ C# .NET

                     NHÓM THỰC HIỆN: NHÓM 06
       1. Hoàng Anh Kiệt      - MSSV: 24110190 (Trưởng nhóm)
       2. Nguyễn Anh Duy      - MSSV: 24110180
       3. Võ Lê Ngọc Hùng     - MSSV: 24110195
       4. Nguyễn Thái Sơn     - MSSV: 24110210

            GIẢNG VIÊN HƯỚNG DẪN: TS. NGUYỄN VĂN A

              TP. HỒ CHÍ MINH, THÁNG 10 NĂM 2026
```

---

# LỜI CAM ĐOAN
Chúng em xin cam đoan đề tài *"Xây dựng hệ thống quản lý quán cà phê theo kiến trúc 3 tầng kết nối Microsoft SQL Server và C# .NET"* là công trình nghiên cứu và thực nghiệm độc lập của tập thể Nhóm 06 dưới sự định hướng, hướng dẫn khoa học của Giảng viên phụ trách môn học.

Toàn bộ các bảng dữ liệu, ràng buộc toàn vẹn, Trigger, Khung nhìn (View), Hàm (Function), Chỉ mục (Index) và Thủ tục lưu trữ (Stored Procedure) được trình bày trong báo cáo này đều được nhóm trực tiếp thiết kế, cài đặt và kiểm thử thực tế trên hệ quản trị cơ sở dữ liệu Microsoft SQL Server (tệp script `01_schema_full.sql`, `02_du_lieu_mau.sql`, `03_backup_recovery_concurrency.sql`). Mã nguồn phần mềm phía Client được nhóm tự xây dựng trên nền tảng C# WinForms (.NET 10). Mọi trích dẫn lý thuyết và tài liệu tham khảo đều được ghi chú xuất xứ rõ ràng và trung thực.

*TP. Hồ Chí Minh, ngày 14 tháng 10 năm 2026*  
**Đại diện Nhóm thực hiện (Trưởng nhóm)**  
*Hoàng Anh Kiệt*

---

# LỜI CẢM ƠN
Lời đầu tiên, Nhóm 06 xin bày tỏ lòng biết ơn sâu sắc đến Thầy/Cô phụ trách học phần Hệ quản trị Cơ sở dữ liệu (DBMS330284) - Khoa Công nghệ Thông tin, Trường Đại học Sư phạm Kỹ thuật TP. Hồ Chí Minh. Thầy/Cô đã truyền đạt những nền tảng lý thuyết vững chắc về mô hình dữ liệu quan hệ, kỹ thuật chuẩn hóa dữ liệu, cơ chế quản lý giao dịch đồng thời (Concurrency Control), nguyên lý phục hồi hệ thống (Recovery System) và kỹ thuật bảo mật an toàn thông tin trong hệ cơ sở dữ liệu.

Những bài giảng lý thuyết bổ ích và các buổi thực hành chuyên sâu đã tạo tiền đề quyết định giúp nhóm hoàn thiện hệ thống phần mềm quản lý quán cà phê đảm bảo tính toàn vẹn dữ liệu, tối ưu hóa hiệu năng truy vấn và bảo mật nghiêm ngặt.

Do kiến thức thực tế và thời gian thực hiện đồ án có hạn, sản phẩm khó tránh khỏi những thiếu sót nhất định. Nhóm rất mong nhận được những nhận xét, góp ý quý báu của quý Thầy/Cô để đồ án được hoàn thiện hơn trong tương lai.

---

# MỤC LỤC TỔNG THỂ DỰ KIẾN CỦA ĐỒ ÁN

- **LỜI CAM ĐOAN**
- **LỜI CẢM ƠN**
- **MỤC LỤC**
- **DANH MỤC CÁC CHỮ VIẾT TẮT**
- **DANH MỤC BẢNG BIỂU**
- **DANH MỤC HÌNH ẢNH**
- **CHƯƠNG 1: TỔNG QUAN VỀ ĐỀ TÀI**
  - 1.1. Lý do chọn đề tài và bối cảnh thực tiễn
  - 1.2. Phát biểu bài toán quản lý quán cà phê
  - 1.3. Đối tượng và phạm vi ứng dụng của hệ thống
  - 1.4. Ý nghĩa khoa học và thực tiễn của đề tài
- **CHƯƠNG 2: PHÂN TÍCH VÀ THIẾT KẾ CƠ SỞ DỮ LIỆU**
  - 2.1. Phân tích thực thể và mô hình liên kết thực thể (ERD)
  - 2.2. Lược đồ cơ sở dữ liệu quan hệ (Relational Schema)
  - 2.3. Phân tích quá trình chuẩn hóa đạt dạng chuẩn 3NF
  - 2.4. Bảng đặc tả chi tiết 16 bảng dữ liệu của hệ thống
- **CHƯƠNG 3: CÀI ĐẶT RÀNG BUỘC, TRIGGER, CHỈ MỤC, VIEW VÀ FUNCTION**
  - 3.1. Hệ thống ràng buộc toàn vẹn dữ liệu (Integrity Constraints)
  - 3.2. Cài đặt các Trigger tự động hóa nghiệp vụ kho và hóa đơn
  - 3.3. Tối ưu hóa truy vấn với Chỉ mục (Nonclustered Indexes)
  - 3.4. Cài đặt các Khung nhìn (Views) phục vụ báo cáo và vận hành
  - 3.5. Xây dựng các Hàm người dùng định nghĩa (User-Defined Functions)
  - 3.6. Xây dựng các Thủ tục lưu trữ (Stored Procedures) quản lý nghiệp vụ
- **CHƯƠNG 4: QUẢN TRỊ GIAO DỊCH, AN TOÀN DỮ LIỆU VÀ BẢO MẬT**
  - 4.1. Cơ chế quản lý giao dịch trong các nghiệp vụ cốt lõi
  - 4.2. Xử lý tranh chấp truy cập đồng thời (Concurrency Control)
  - 4.3. Chính sách bảo mật và phân quyền vai trò (Role-Based Access Control)
  - 4.4. Cơ sở lý thuyết phục hồi và kịch bản Sao lưu - Khôi phục CSDL
- **CHƯƠNG 5: THIẾT KẾ KIẾN TRÚC VÀ GIAO DIỆN ỨNG DỤNG**
  - 5.1. Kiến trúc tổng thể 3 tầng (3-Tier Architecture) và Lớp tiện ích
  - 5.2. Phân hệ Bán hàng (POS), Thanh toán và Quản lý Bàn
  - 5.3. Phân hệ Quản lý Kho, Nhập hàng và Thực đơn
  - 5.4. Phân hệ Báo cáo Doanh thu, Chi tiền và Quản lý Khách hàng
- **CHƯƠNG 6: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN**
  - 6.1. Đánh giá kết quả đạt được của đề tài
  - 6.2. Những điểm hạn chế còn tồn tại
  - 6.3. Hướng phát triển và mở rộng hệ thống
- **TÀI LIỆU THAM KHẢO**
- **PHỤ LỤC**
  - Phụ lục A: Bảng phân công chi tiết nhiệm vụ và đánh giá đóng góp
  - Phụ lục B: Nhật ký phiên bản và lịch sử commit trên hệ thống Git

---

# DANH MỤC CÁC TỪ VIẾT TẮT

| Viết tắt | Thuật ngữ tiếng Anh | Diễn giải tiếng Việt |
| :--- | :--- | :--- |
| **ACID** | Atomicity, Consistency, Isolation, Durability | Bốn thuộc tính cơ bản của một giao dịch CSDL (Nguyên tử, Nhất quán, Cô lập, Bền vững) |
| **ADO.NET**| ActiveX Data Objects for .NET | Thư viện truy xuất dữ liệu trong nền tảng Microsoft .NET |
| **ARIES** | Algorithms for Recovery and Isolation Exploiting Semantics | Giải thuật phục hồi và cô lập dữ liệu chuẩn trong hệ quản trị CSDL |
| **BLL** | Business Logic Layer | Tầng xử lý logic nghiệp vụ |
| **DAL** | Data Access Layer | Tầng truy xuất và thao tác dữ liệu |
| **DBMS** | Database Management System | Hệ quản trị cơ sở dữ liệu |
| **DTO** | Data Transfer Object | Đối tượng vận chuyển dữ liệu giữa các tầng |
| **ERD** | Entity Relationship Diagram | Sơ đồ liên kết thực thể |
| **GUI** | Graphical User Interface | Giao diện đồ họa người dùng (Tầng hiển thị - Presentation) |
| **LSN** | Log Sequence Number | Số thứ tự định danh bản ghi nhật ký giao dịch |
| **POS** | Point of Sale | Điểm bán hàng / Màn hình thu ngân trực tiếp |
| **RBAC** | Role-Based Access Control | Kiểm soát truy cập dựa trên vai trò |
| **SP** | Stored Procedure | Thủ tục lưu trữ trong CSDL |
| **SSMS** | SQL Server Management Studio | Công cụ quản trị giao diện cho Microsoft SQL Server |
| **UDF** | User-Defined Function | Hàm do người dùng tự định nghĩa |
| **WAL** | Write-Ahead Logging | Kỹ thuật ghi nhật ký giao dịch trước khi ghi dữ liệu xuống đĩa |

---

# CHƯƠNG 1: TỔNG QUAN VỀ ĐỀ TÀI

## 1.1. Lý do chọn đề tài và bối cảnh thực tiễn
Trong nền kinh tế dịch vụ hiện đại, mô hình kinh doanh đồ uống và quán cà phê (Coffee Shop) tại Việt Nam đang phát triển vô cùng mạnh mẽ với sự cạnh tranh khốc liệt. Từ các chuỗi cà phê thương hiệu lớn cho tới các quán cà phê vừa và nhỏ (SME), nhu cầu tối ưu hóa tốc độ phục vụ, kiểm soát chặt chẽ nguyên vật liệu và quản lý doanh thu minh bạch trở thành yếu tố sống còn.

Tuy nhiên, tại nhiều quán cà phê quy mô vừa và nhỏ hiện nay, quy trình quản lý vẫn tồn tại nhiều bất cập:
1. **Ghi chép thủ công hoặc sử dụng phần mềm bảng tính rời rạc (Excel):** Nhân viên phục vụ ghi order bằng giấy, dễ gây thất lạc món, nhầm lẫn bàn và tính sai tiền cho khách vào những khung giờ cao điểm.
2. **Thất thoát nguyên vật liệu pha chế:** Do không có hệ thống tự động trừ kho định lượng dựa trên công thức món, chủ quán không thể kiểm soát được số lượng nguyên liệu thực tế tiêu hao so với lượng bán ra, dẫn đến thất thoát sữa đặc, siro, cà phê hạt hoặc để nguyên liệu hết hạn sử dụng.
3. **Chăm sóc khách hàng thụ động:** Không lưu vết được lịch sử gọi món và tích điểm của khách hàng quen thuộc để áp dụng các chính sách chiết khấu, giảm giá khuyến khích quay lại.
4. **Tranh chấp truy cập và thiếu bảo mật:** Nhiều thu ngân cùng thao tác bán hàng trên một phần mềm dùng chung tài khoản đăng nhập máy chủ CSDL dẫn đến tình trạng mất dữ liệu cập nhật (Lost Update), hoặc nhân viên có thể tò mò xem được dữ liệu tiền lương, mật khẩu của nhân viên khác.

Xuất phát từ thực tế trên, việc nghiên cứu và xây dựng một phần mềm quản lý quán cà phê chuyên nghiệp theo kiến trúc chuẩn 3 tầng (`GUI` - `BLL` - `DAL`), kết nối cơ sở dữ liệu quan hệ mạnh mẽ Microsoft SQL Server là đề tài có tính thực tiễn cao, đáp ứng toàn diện các chuẩn đầu ra của học phần Hệ quản trị Cơ sở dữ liệu.

## 1.2. Phát biểu bài toán quản lý quán cà phê
Hệ thống quản lý quán cà phê của Nhóm 06 giải quyết các bài toán nghiệp vụ trung tâm sau:
- **Nghiệp vụ Bán hàng tại quán và Đơn mang về (Takeaway):**
  - Hiển thị trực quan sơ đồ bàn theo từng khu vực (Tầng trệt, Tầng 1, Sân vườn) với màu sắc phân biệt rõ ràng: Bàn trống (`TRONG` - màu xanh lá cây) và Bàn đang có khách (`COKHACH` - màu đỏ).
  - Cho phép mở bàn mới, thêm món, tùy chỉnh số lượng món, tính tiền tạm tính.
  - Hỗ trợ phân hệ bán mang về độc lập thông qua vị trí quy ước `VT_MANGVE` và bàn quy ước `B_MANGVE`. Thu ngân có thể mở đồng thời nhiều đơn mang về mà không chiếm dụng bàn vật lý tại quán.
  - Tích hợp đa dạng phương thức thanh toán: Tiền mặt, Thẻ, Ví điện tử và đặc biệt là phương thức Chuyển khoản VietQR tự động sinh mã QR Quick Link chuẩn NAPAS247 kèm đúng số tiền và nội dung chuyển khoản.
- **Nghiệp vụ Quản lý Định lượng và Trừ/Hoàn kho tự động:**
  - Mỗi thức uống được liên kết với một bảng công thức (`CongThuc`) quy định số lượng tiêu hao của từng nguyên liệu (gram, ml, cái).
  - Khi thu ngân thêm món vào hóa đơn, hệ thống tự động kiểm tra tồn kho và trừ trực tiếp lượng nguyên liệu tương ứng.
  - Khi hóa đơn bị hủy do khách đổi ý, hệ thống tự động hoàn lại chính xác lượng nguyên liệu đã trừ về kho và giải phóng bàn trở lại trạng thái trống.
- **Nghiệp vụ Quản lý Nhập kho và Kiểm soát Hạn sử dụng:**
  - Thủ kho thực hiện lập phiếu nhập hàng từ nhà cung cấp theo quy trình trọn gói (sử dụng chuỗi JSON để thêm nhiều nguyên liệu trong một giao dịch duy nhất).
  - Tồn kho tự động tăng lên ngay khi phiếu nhập được ghi nhận, đồng thời lưu trữ ngày hết hạn (`HanSuDung`) để cảnh báo nguyên liệu sắp hết hạn.
- **Nghiệp vụ Khách hàng thân thiết và Tích lũy điểm:**
  - Khách hàng được phân loại theo hạng thẻ: Thường (`LKH01` - chiết khấu 0%), Thân thiết (`LKH02` - chiết khấu 5%), VIP (`LKH03` - chiết khấu 10%).
  - Khi thanh toán, hệ thống tự động chiết khấu theo hạng thẻ và cộng dồn điểm tích lũy vào tài khoản khách hàng (mỗi 10.000 VNĐ thanh toán thực tế tương ứng với 1 điểm).
- **Nghiệp vụ Báo cáo Doanh thu và Quản lý Chi tiền:**
  - Kế toán theo dõi biến động doanh thu theo từng ngày, danh sách top các món bán chạy nhất trong tuần/tháng.
  - Lập phiếu chi tiền thanh toán công nợ cho nhà cung cấp hoặc các khoản chi phí vận hành (tiền điện, nước, mặt bằng, sửa chữa thiết bị).
- **Bảo mật và phân quyền hệ thống:**
  - Xác thực nhân viên bằng mật khẩu băm một chiều an toàn (`SHA2_256`).
  - Phân quyền nghiêm ngặt theo vai trò công việc: Quản lý, Phục vụ/Thu ngân, Thủ kho, Kế toán ở cả tầng ứng dụng và tầng cơ sở dữ liệu.

## 1.3. Đối tượng sử dụng và phạm vi thực hiện của hệ thống
- **Đối tượng sử dụng:**
  - *Quản lý quán:* Xem báo cáo doanh thu, quản lý danh sách nhân viên, đặt lại mật khẩu, quản lý danh mục thức uống, cấu hình sơ đồ bàn và nhà cung cấp.
  - *Nhân viên Phục vụ / Thu ngân:* Mở bàn, gọi món cho khách tại quán và khách mang về, áp dụng giảm giá, in hóa đơn và xác nhận thanh toán.
  - *Nhân viên Thủ kho:* Quản lý danh mục nguyên liệu, định mức tồn kho tối thiểu, lập phiếu nhập kho, theo dõi hạn sử dụng của nguyên liệu.
  - *Nhân viên Kế toán:* Theo dõi doanh thu, lập phiếu chi tiền cho nhà cung cấp, chi phí vận hành quán, phân tích món bán chạy.
- **Phạm vi kỹ thuật và môi trường triển khai:**
  - *Hệ quản trị CSDL:* Microsoft SQL Server 2022/2025 Developer Edition.
  - *Nền tảng phần mềm:* Ứng dụng Desktop chạy trên hệ điều hành Windows (C# WinForms trên nền tảng .NET 10 mới nhất).
  - *Mô hình kết nối:* Kiến trúc 3 tầng phân tách độc lập (`GUI` $\rightarrow$ `BLL` $\rightarrow$ `DAL` $\rightarrow$ `SQL Server`).
  - *Bảo mật đường truyền:* Hỗ trợ chuẩn mã hóa kết nối `Microsoft.Data.SqlClient` với `TrustServerCertificate=True`.

## 1.4. Ý nghĩa khoa học và thực tiễn của đề tài
- **Về mặt học thuật:** Vận dụng toàn diện các kỹ thuật nâng cao của môn học Hệ quản trị Cơ sở dữ liệu:
  - Thiết kế chuẩn hóa dữ liệu đạt dạng chuẩn 3NF loại bỏ dư thừa và dị thường.
  - Khai thác sức mạnh của hệ thống Trigger đảm bảo tính toàn vẹn dữ liệu nghiệp vụ phức tạp.
  - Ứng dụng Nonclustered Index tối ưu hóa thời gian thực thi truy vấn.
  - Xử lý tranh chấp truy cập đồng thời (Concurrency Control) bằng các mức cô lập và kỹ thuật khóa phù hợp (`UPDLOCK`, `HOLDLOCK`).
  - Thiết kế chính sách phân quyền vai trò (RBAC) kết hợp kỹ thuật che giấu dữ liệu qua cơ chế Ownership Chaining.
  - Xây dựng chiến lược sao lưu và phục hồi CSDL theo mô hình Full Recovery Model chuẩn công nghiệp.
- **Về mặt thực tiễn:** Mang lại giải pháp số hóa hoàn chỉnh cho các quán cà phê vừa và nhỏ: giao diện thân thiện, thanh toán VietQR thông minh, vận hành mượt mà, bảo vệ số liệu kinh doanh trước sự cố phần cứng hoặc thao tác sai của người dùng.

---

# CHƯƠNG 4: QUẢN TRỊ CSDL, BẢO MẬT VÀ PHỤC HỒI DỮ LIỆU (PHẦN BẢO MẬT & PHỤC HỒI)

## 4.1. Chính sách bảo mật và phân quyền vai trò (Role-Based Access Control - RBAC)

### 4.1.1. Nguyên tắc thiết kế bảo mật đa tầng
Trong các hệ thống thông tin quản lý kinh doanh, bảo mật không chỉ dừng lại ở việc ẩn các nút bấm trên giao diện người dùng (Client GUI), mà bắt buộc phải được thiết lập vững chắc tại tầng Hệ quản trị Cơ sở dữ liệu. Nhóm 06 triển khai mô hình bảo mật RBAC (Role-Based Access Control) tuân theo hai nguyên tắc cốt lõi của an toàn thông tin:
1. **Nguyên tắc đặc quyền tối thiểu (Principle of Least Privilege):** Mỗi người dùng hoặc vai trò chỉ được cấp đúng và đủ các quyền hạn cần thiết để hoàn thành nhiệm vụ công việc, không được sở hữu bất kỳ đặc quyền dư thừa nào.
2. **Nguyên tắc tách biệt nhiệm vụ (Separation of Duties):** Phân chia ranh giới công việc rõ ràng giữa các bộ phận. Thu ngân không thể tự ý sửa đổi tồn kho hoặc xóa dữ liệu nhà cung cấp; Thủ kho không được xem dữ liệu doanh thu bán hàng; Kế toán không được tự ý xóa hóa đơn.

### 4.1.2. Hệ thống Login và Role trong hệ thống
Cơ sở dữ liệu `quanlyquancafe` thiết lập cấu trúc phân quyền gồm 5 SQL Server Login kết hợp với 3 Database Role nghiệp vụ và vai trò quản trị tối cao (`db_owner`):

*Bảng 4.1: Ma trận phân quyền giữa Login, Role và phạm vi nghiệp vụ*

| Login máy chủ | Database User | Database Role gán kèm | Quyền hạn nghiệp vụ chính |
| :--- | :--- | :--- | :--- |
| `login_auth` | `user_auth` | *(Không có role)* | **Chỉ duy nhất** quyền `EXECUTE` trên thủ tục `sp_DangNhap`. Dùng khi khởi động ứng dụng để xác thực tài khoản nhân viên. |
| `login_quantri` | `user_quantri`| `db_owner` | Toàn quyền kiểm soát cơ sở dữ liệu (Toàn quyền quản trị, thêm/xóa/sửa cấu trúc, sao lưu, phục hồi). |
| `login_phucvu` | `user_phucvu`| `NhanVienPhucVu` | Thao tác trên Bàn, Hóa đơn, Khách hàng; xem danh mục thức uống; thực thi các SP bán hàng, mở bàn, thanh toán, hủy đơn. |
| `login_thukho` | `user_thukho` | `ThuKho` | Toàn quyền trên Nguyên liệu, Phiếu nhập, Chi tiết phiếu nhập, Nhà cung cấp, Công thức pha chế; thực thi `sp_NhapKhoTronGoi`. |
| `login_ketoan` | `user_ketoan` | `KeToan` | Xem các khung nhìn thống kê (`v_HoaDon`, `v_DoanhThuTheoNgay`, `v_MonBanChay`); lập phiếu chi tiền (`PhieuChi`); thực thi `sp_ChiTienNCC`. |

### 4.1.3. Cơ chế Ownership Chaining và che giấu dữ liệu
Một ưu điểm bảo mật nổi bật của SQL Server được nhóm áp dụng triệt để là cơ chế **Ownership Chaining** (Chuỗi sở hữu đối tượng):
- Toàn bộ bảng dữ liệu và Stored Procedure đều thuộc quyền sở hữu của schema mặc định `dbo`.
- Khi cấp quyền cho vai trò `NhanVienPhucVu`, hệ thống **chỉ cấp quyền `EXECUTE`** trên các Stored Procedure nghiệp vụ (như `sp_TaoHoaDon`, `sp_ThemMonVaoHoaDon`, `sp_ThanhToanHoaDon`), mà **không cấp quyền `INSERT/UPDATE` trực tiếp** trên các bảng vật lý như `NguyenLieu` hay `Khach`.
- Khi người dùng thực thi Stored Procedure, SQL Server nhận thấy Stored Procedure và các bảng liên quan có cùng chủ sở hữu (`dbo`), nên người dùng có thể gián tiếp trừ tồn kho hoặc tích điểm thành công mà không cần đặc quyền truy cập trực tiếp vào bảng. Điều này ngăn chặn triệt để nguy cơ nhân viên sử dụng các công cụ bên ngoài (như DBeaver hay Excel) kết nối vào CSDL để chỉnh sửa lậu số lượng tồn kho hay điểm số.

### 4.1.4. Trích xuất mã lệnh phân quyền GRANT / REVOKE / DENY
Dưới đây là đoạn mã phân quyền thực tế được trích xuất từ `01_schema_full.sql` và `03_backup_recovery_concurrency.sql`:

```sql
-- 1. Tạo các Role nghiệp vụ
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'NhanVienPhucVu' AND type = 'R')
    CREATE ROLE NhanVienPhucVu;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'ThuKho' AND type = 'R')
    CREATE ROLE ThuKho;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'KeToan' AND type = 'R')
    CREATE ROLE KeToan;
GO

-- 2. Cấp quyền thực thi Stored Procedure và Function cho NhanVienPhucVu
GRANT EXECUTE ON sp_TaoHoaDon            TO NhanVienPhucVu;
GRANT EXECUTE ON sp_ThemMonVaoHoaDon     TO NhanVienPhucVu;
GRANT EXECUTE ON sp_ThanhToanHoaDon      TO NhanVienPhucVu;
GRANT EXECUTE ON sp_HuyHoaDon            TO NhanVienPhucVu;
GRANT EXECUTE ON sp_LayDanhSachDonMangVe TO NhanVienPhucVu;
GRANT EXECUTE ON dbo.fn_TinhThanhTienHoaDon TO NhanVienPhucVu;
GRANT SELECT  ON dbo.fn_LichSuMuaHang       TO NhanVienPhucVu;
GO

-- 3. Thiết lập hàng rào DENY nghiêm ngặt (Luôn thắng GRANT)
-- Hóa đơn chỉ được phép đổi trạng thái sang 'Đã hủy', tuyệt đối không được xóa vật lý
DENY DELETE ON dbo.HoaDon TO NhanVienPhucVu, ThuKho, KeToan;

-- Cấm hoàn toàn mọi role nhân viên đọc trực tiếp bảng NhanVien (chứa chuỗi mật khẩu băm)
DENY SELECT ON dbo.NhanVien TO NhanVienPhucVu, ThuKho, KeToan;

-- Chỉ có kế toán mới được quyền thao tác với phiếu chi tiền
DENY INSERT, UPDATE, DELETE ON dbo.PhieuChi TO NhanVienPhucVu, ThuKho;
GO
```

### 4.1.5. Thực nghiệm kiểm tra cơ chế GRANT -> REVOKE -> DENY
Để minh chứng nguyên lý hoạt động của SQL Server: *"Lệnh DENY luôn có mức ưu tiên cao nhất và luôn chiến thắng lệnh GRANT"*, nhóm thực hiện kịch bản thử nghiệm trên role tạm `RoleDemoQuyen` và user `user_demo_quyen`:

```sql
-- Bước 1: Cấp quyền đọc dữ liệu bảng Khach qua lệnh GRANT
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;
EXECUTE AS USER = 'user_demo_quyen';
SELECT COUNT(*) AS SoKhach_SauGRANT FROM dbo.Khach; -- Thành công!
REVERT;

-- Bước 2: Thu hồi quyền bằng REVOKE (trở về trạng thái chưa cấp)
REVOKE SELECT ON dbo.Khach FROM RoleDemoQuyen;
EXECUTE AS USER = 'user_demo_quyen';
-- Báo lỗi: Quyền SELECT bị từ chối vì chưa được cấp!
REVERT;

-- Bước 3: Minh chứng DENY thắng GRANT
GRANT SELECT ON dbo.Khach TO RoleDemoQuyen;      -- Role được cấp quyền đọc
DENY  SELECT ON dbo.Khach TO user_demo_quyen;    -- Nhưng User trực tiếp bị DENY
EXECUTE AS USER = 'user_demo_quyen';
-- Kết quả: Bị chặn ngay lập tức với mã lỗi 229!
REVERT;
```

[CHÈN HÌNH: Ảnh chụp màn hình kết quả thực thi script phân quyền trong SSMS, hiển thị rõ thông báo lỗi số 229 khi `user_phucvu` cố tình truy vấn `SELECT * FROM dbo.NhanVien`]

[CHÈN HÌNH: Ảnh chụp bảng kết quả truy vấn từ view hệ thống `sys.database_permissions` hiển thị các quyền GRANT và DENY của các Principal `NhanVienPhucVu`, `ThuKho`, `KeToan`]

---

## 4.2. Cơ sở lý thuyết phục hồi và kịch bản Sao lưu - Khôi phục CSDL

### 4.2.1. Khái niệm Lịch trình khả phục hồi (Recoverable Schedules)
Trong môi trường cơ sở dữ liệu đa người dùng, nhiều giao dịch (Transactions) được thực thi đồng thời xen kẽ nhau. Để đảm bảo tính toàn vẹn, lịch trình thực thi bắt buộc phải thỏa mãn tính **khả phục hồi (Recoverable)**:
- **Định nghĩa:** Một lịch trình $S$ được gọi là khả phục hồi nếu với mọi cặp giao dịch $T_i$ và $T_j$, nếu $T_j$ đọc một mục dữ liệu được ghi bởi $T_i$, thì thao tác `COMMIT` của $T_i$ phải diễn ra **TRƯỚC** thao tác `COMMIT` của $T_j$.
- **Hiện tượng phục hồi dây chuyền (Cascading Rollback):** Xảy ra khi một giao dịch $T_i$ bị hủy và rollback, kéo theo tất cả các giao dịch $T_j$ đã đọc dữ liệu chưa commit của $T_i$ cũng phải đồng loạt rollback theo. Điều này gây lãng phí tài nguyên CPU và I/O nghiêm trọng.
- **Giải pháp trên SQL Server:** Với mức cô lập mặc định `READ COMMITTED`, SQL Server sử dụng cơ chế khóa chia sẻ (Shared Lock) để ngăn chặn việc đọc dữ liệu rác (Dirty Read). Do đó, một giao dịch không bao giờ đọc dữ liệu chưa được commit của giao dịch khác, giúp hệ thống luôn đảm bảo lịch trình khả phục hồi và loại bỏ hoàn toàn nguy cơ Cascading Rollback.

### 4.2.2. Kỹ thuật Write-Ahead Logging (WAL)
Kỹ thuật ghi nhật ký trước (Write-Ahead Logging - WAL) là nguyên tắc nền tảng giúp hệ quản trị cơ sở dữ liệu đảm bảo tính Bền vững (Durability) và tính Nguyên tử (Atomicity) theo chuẩn ACID:
- **Nguyên tắc vàng của WAL:** Mọi thay đổi dữ liệu diễn ra trên bộ nhớ đệm (Buffer Pool) phải được ghi cố định vào tệp Transaction Log (`.ldf`) trên đĩa cứng **TRƯỚC KHI** các trang dữ liệu (Data Pages) tương ứng trong tệp dữ liệu chính (`.mdf`) được ghi xuống đĩa.
- Mỗi bản ghi nhật ký được định danh duy nhất bằng một chỉ số tăng dần gọi là **LSN (Log Sequence Number)**.
- Tiến trình **Checkpoint** định kỳ đẩy các trang dữ liệu bị sửa đổi (Dirty Pages) từ Buffer Pool xuống đĩa cứng, giúp rút ngắn thời gian phục hồi hệ thống khi có sự cố mất nguồn đột ngột (System Crash).

### 4.2.3. Thuật toán ARIES và so sánh hai mô hình phục hồi
Microsoft SQL Server ứng dụng giải thuật phục hồi hiện đại **ARIES** (Algorithms for Recovery and Isolation Exploiting Semantics). Về mặt lý thuyết, có hai mô hình phục hồi chính:

1. **Phục hồi dựa trên Hoãn cập nhật (Deferred Update - Mô hình NO-UNDO / REDO):**
   - Cơ chế: Mọi thao tác cập nhật của giao dịch chỉ được lưu trong nhật ký giao dịch và bộ nhớ tạm, tuyệt đối không ghi xuống đĩa cơ sở dữ liệu vật lý cho đến khi giao dịch phát lệnh `COMMIT` thành công.
   - Khi gặp sự cố sập nguồn:
     - Giao dịch đã `COMMIT`: Thực hiện `REDO` (làm lại) từ nhật ký.
     - Giao dịch chưa `COMMIT`: Không cần `UNDO` (vì dữ liệu chưa từng được ghi xuống đĩa).
   - Nhược điểm: Đòi hỏi bộ nhớ đệm rất lớn khi giao dịch cập nhật khối lượng dữ liệu khổng lồ.
2. **Phục hồi dựa trên Cập nhật ngay (Immediate Update - Mô hình UNDO / REDO):**
   - Cơ chế: Dữ liệu bị thay đổi có thể được tiến trình Checkpoint ghi xuống đĩa trước khi giao dịch thực hiện commit.
   - SQL Server sử dụng cơ chế này kết hợp giải thuật ARIES với 3 giai đoạn khi khởi động lại sau crash:
     - *Giai đoạn 1 - Phân tích (Analysis Phase):* Quét log từ điểm Checkpoint gần nhất để xác định trạng thái các giao dịch đang chạy và các trang bẩn (Dirty Pages).
     - *Giai đoạn 2 - Làm lại (Redo Phase):* Lặp lại toàn bộ các thay đổi của cả giao dịch đã commit và chưa commit để đưa CSDL về đúng trạng thái tại thời điểm sập nguồn.
     - *Giai đoạn 3 - Hoàn tác (Undo Phase):* Quét ngược log để hủy bỏ (Rollback) các thay đổi của toàn bộ các giao dịch chưa kịp commit khi xảy ra sự cố.

### 4.2.4. Kỹ thuật Phục hồi dựa trên Trang bóng (Shadow Paging)
- Khác với phương pháp dựa trên nhật ký ghi log, kỹ thuật Shadow Paging duy trì đồng thời hai bảng con trỏ trang:
  - **Bảng trang hiện hành (Current Page Table):** Phục vụ các thao tác đọc/ghi của giao dịch đang chạy. Khi có trang sửa đổi, một trang mới được cấp phát trên đĩa và con trỏ hiện hành trỏ tới trang mới này.
  - **Bảng trang bóng (Shadow Page Table):** Giữ nguyên các con trỏ trỏ về khối dữ liệu gốc ban đầu trên đĩa.
- Khi giao dịch `COMMIT`: Con trỏ cơ sở (Base Pointer) được cập nhật trỏ thẳng vào Bảng trang hiện hành, trang bóng cũ được giải phóng.
- Nếu xảy ra sự cố: Hệ thống chỉ cần khôi phục lại con trỏ cơ sở trỏ về Bảng trang bóng ban đầu. Toàn bộ thay đổi của giao dịch bị hủy bỏ tức thì mà không cần quét log để `UNDO`.

### 4.2.5. Kịch bản Backup và Khôi phục CSDL thực tế của Nhóm 06
Nhóm cấu hình CSDL `quanlyquancafe` hoạt động ở chế độ **FULL Recovery Model** để duy trì trọn vẹn chuỗi nhật ký giao dịch:

```sql
USE master;
GO
ALTER DATABASE quanlyquancafe SET RECOVERY FULL;
GO

-- 1. Sao lưu toàn phần (Full Backup) định kỳ hàng tuần vào lúc 00:00 Chủ Nhật
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Full Database Backup',
     DESCRIPTION = N'Sao lưu toàn phần hệ thống quán cà phê';
GO

-- 2. Sao lưu vi sai (Differential Backup) định kỳ cuối mỗi ngày làm việc (23:00)
BACKUP DATABASE quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Differential Backup',
     DESCRIPTION = N'Sao lưu vi sai các thay đổi trong ngày';
GO

-- 3. Sao lưu nhật ký giao dịch (Transaction Log Backup) định kỳ 15 phút một lần
BACKUP LOG quanlyquancafe
TO DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH FORMAT, INIT,
     NAME = 'quanlyquancafe - Log Backup',
     DESCRIPTION = N'Sao lưu nhật ký giao dịch đảm bảo RPO nhỏ nhất';
GO
```

### 4.2.6. Quy trình Phục hồi thảm họa (Disaster Recovery Simulation)
Khi xảy ra sự cố mất mát dữ liệu hoặc hỏng ổ đĩa cứng tại thời điểm trong ngày, quy trình khôi phục chuẩn tuân thủ nguyên tắc chuỗi liên tục (LSM):

```sql
USE master;
ALTER DATABASE quanlyquancafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

-- Bước 1: Phục hồi bản Full Backup gần nhất với tùy chọn NORECOVERY để giữ trạng thái chờ
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Full.bak'
WITH NORECOVERY, REPLACE;

-- Bước 2: Phục hồi bản Differential Backup gần nhất
RESTORE DATABASE quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Diff.bak'
WITH NORECOVERY;

-- Bước 3: Áp dụng các bản Log Backup liên tiếp và hoàn tất mở CSDL với RECOVERY
RESTORE LOG quanlyquancafe
FROM DISK = 'C:\Backup\quanlyquancafe_Log.trn'
WITH RECOVERY;

ALTER DATABASE quanlyquancafe SET MULTI_USER;
```

[CHÈN HÌNH: Ảnh chụp màn hình cấu hình Full Recovery Model trong SSMS (Database Properties -> Options -> Recovery model: Full)]

[CHÈN HÌNH: Ảnh chụp màn hình thông báo lệnh BACKUP DATABASE và BACKUP LOG thực thi thành công với số lượng trang xử lý được in ra màn hình Messages]

---

# CHƯƠNG 6: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

## 6.1. Đánh giá kết quả đạt được của đề tài
Sau quá trình nghiên cứu lý thuyết và trực tiếp lập trình thực nghiệm, Nhóm 06 đã hoàn thành xuất sắc các mục tiêu đề ra cho đồ án môn học Hệ quản trị Cơ sở dữ liệu:
1. **Về mặt Cơ sở dữ liệu:**
   - Xây dựng hoàn chỉnh CSDL `quanlyquancafe` với 16 bảng dữ liệu chuẩn hóa đạt chuẩn 3NF, không còn tình trạng dư thừa dữ liệu hoặc dị thường cập nhật.
   - Thiết lập hơn 20 ràng buộc toàn vẹn (`CHECK`, `UNIQUE`, `DEFAULT`, `FOREIGN KEY`), bảo vệ tính đúng đắn của dữ liệu ngay từ tầng vật lý.
   - Hiện thực 6 Trigger nghiệp vụ tự động hóa việc trừ/hoàn kho nguyên liệu và cập nhật trạng thái bàn.
   - Xây dựng 6 Khung nhìn (View), 6 Hàm người dùng (Function) và 51 Thủ tục lưu trữ (Stored Procedure) xử lý toàn diện mọi hoạt động của quán cà phê.
   - Áp dụng 5 chỉ mục Nonclustered Index giúp tối ưu hóa hiệu năng truy vấn dữ liệu lớn.
   - Triển khai thành công cơ chế quản lý giao dịch an toàn (`BEGIN TRAN ... COMMIT / ROLLBACK`) và kiểm soát truy cập đồng thời với mức cô lập `REPEATABLE READ` kết hợp khóa `UPDLOCK, HOLDLOCK`.
   - Thiết lập mô hình phân quyền bảo mật vai trò (RBAC) với 5 Login, 3 Role và chiến lược sao lưu phục hồi chuẩn Full Recovery Model.
2. **Về mặt Ứng dụng:**
   - Ứng dụng C# WinForms trên nền tảng .NET 10 hiện đại, áp dụng nghiêm ngặt kiến trúc 3 tầng (`GUI` - `BLL` - `DAL`).
   - Giao diện trực quan, đồng bộ màu sắc qua hệ thống `Theme.cs`, hỗ trợ thao tác bán hàng nhanh chóng, mượt mà.
   - Tích hợp thành công giải pháp tạo mã chuyển khoản ngân hàng VietQR tự động, hỗ trợ thanh toán không dùng tiền mặt tiện lợi.
   - Xử lý và bắt lỗi tập trung (`CustomSqlExceptionHandler.cs`), chuyển đổi các thông báo lỗi kỹ thuật của SQL Server thành ngôn ngữ tiếng Việt thân thiện với người sử dụng.

## 6.2. Những điểm hạn chế còn tồn tại
- Hệ thống hiện tại vận hành theo mô hình Client-Server nội bộ trong mạng cục bộ (LAN), chưa hỗ trợ cơ chế đồng bộ dữ liệu thời gian thực lên dịch vụ đám mây (Cloud).
- Giao diện hiện tại tối ưu tốt nhất cho màn hình máy tính bàn hoặc laptop của thu ngân, chưa có phiên bản tương thích responsive cho máy tính bảng cầm tay của nhân viên phục vụ order tại bàn.
- Phương thức thanh toán VietQR hiện tại là tạo mã một chiều; hệ thống vẫn cần nhân viên thu ngân kiểm tra biến động số dư tài khoản ngân hàng để xác nhận thanh toán, chưa tích hợp Webhook phản hồi hai chiều từ Open Banking API.

## 6.3. Hướng phát triển và mở rộng hệ thống
- **Triển khai Web API và ứng dụng di động:** Nâng cấp tầng DAL kết nối qua ASP.NET Core Web API để phát triển ứng dụng di động (Flutter / .NET MAUI) cho nhân viên phục vụ nhận order trực tiếp tại bàn và cho khách hàng tự gọi món qua mã QR tại bàn.
- **Tích hợp máy in nhiệt hóa đơn ESC/POS:** Lập trình kết nối trực tiếp với máy in nhiệt khổ K80/K58 qua cổng USB/LAN để in hóa đơn tự động ngay khi thanh toán.
- **Tích hợp cổng thanh toán trực tuyến tự động (Payment Gateway):** Đăng ký kết nối chính thức với cổng thanh toán (như MoMo, VNPay, ZaloPay, VietQR PRO Webhook) để tự động lắng nghe giao dịch thành công và hoàn tất đơn hàng mà không cần thu ngân xác nhận thủ công.
- **Mở rộng mô hình chuỗi quán (Multi-Store Replication):** Nghiên cứu ứng dụng kỹ thuật SQL Server Transactional Replication hoặc Always On Availability Groups để đồng bộ dữ liệu giữa nhiều chi nhánh quán cà phê về máy chủ trung tâm.

---

# TÀI LIỆU THAM KHẢO

1. **Giáo trình Hệ quản trị Cơ sở dữ liệu**, Bộ môn Hệ thống Thông tin, Khoa Công nghệ Thông tin, Trường Đại học Sư phạm Kỹ thuật TP. Hồ Chí Minh.
2. **Abraham Silberschatz, Henry F. Korth, S. Sudarshan (2020)**, *Database System Concepts*, 7th Edition, McGraw-Hill.
3. **Microsoft Learn (2025 - 2026)**, *SQL Server Technical Documentation: Transactions, Locking, and Concurrency Control Architecture*, truy cập tại: `https://learn.microsoft.com/en-us/sql/relational-databases/sql-server-transaction-locking-and-row-versioning-guide`.
4. **Microsoft Learn (2025 - 2026)**, *Microsoft.Data.SqlClient and ADO.NET Architecture Guide for .NET Applications*, truy cập tại: `https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/`.
5. **C.J. Date (2004)**, *An Introduction to Database Systems*, 8th Edition, Addison-Wesley.
6. **Tài liệu đặc tả chuẩn VietQR Quick Link**, Công ty Cổ phần Thanh toán Quốc gia Việt Nam (NAPAS), truy cập tại: `https://www.vietqr.io/`.

---

# PHỤ LỤC

## Phụ lục A: Bảng phân công nhiệm vụ và đánh giá mức độ đóng góp

*Bảng A.1: Bảng phân công chi tiết công việc 4 thành viên Nhóm 06*

| STT | Thành viên | MSSV | Vai trò phụ trách | Phân hệ / Màn hình phụ trách | Nhiệm vụ kỹ thuật CSDL & Báo cáo | Tỷ lệ đóng góp |
| :---: | :--- | :---: | :--- | :--- | :--- | :---: |
| 1 | **Hoàng Anh Kiệt** *(Trưởng nhóm)* | 24110190 | Nền tảng, Bảo mật, Quản trị | `FormDangNhap`, `FormMain`, `FormNhanVien`, `FormBan` | • Khởi tạo kiến trúc dự án, điều phối nhóm.<br>• Viết script khởi tạo Login/Role, chính sách RBAC (`00_init_local_logins.sql`, `01_schema_full.sql`).<br>• Cài đặt kịch bản Backup/Restore CSDL (`03_backup_recovery_concurrency.sql`).<br>• Viết Chương 1, Chương 4 (Bảo mật/Phục hồi), Chương 6, tổng hợp báo cáo. | 100% |
| 2 | **Nguyễn Anh Duy** | 24110180 | Bán hàng (POS), Giao dịch | `frmBanHang`, `frmThanhToan`, `frmXemHoaDon`, `FormBan` | • Thiết kế 16 bảng dữ liệu CSDL, phân tích 3NF.<br>• Viết các Stored Procedure bán hàng (`sp_TaoHoaDon`, `sp_ThemMonVaoHoaDon`, `sp_ThanhToanHoaDon`, `sp_HuyHoaDon`).<br>• Cài đặt kịch bản giải quyết tranh chấp đồng thời (`REPEATABLE READ`, `UPDLOCK, HOLDLOCK`).<br>• Viết Chương 2, Chương 4 (Giao dịch bán hàng), Chương 5 (Giao diện POS). | 100% |
| 3 | **Võ Lê Ngọc Hùng** | 24110195 | Quản lý Kho, Trigger, Chỉ mục | `FormNguyenLieu`, `FormNhapKho`, `FormNhaCungCap`, `FormThucUong`, `FormCongThuc` | • Cài đặt hệ thống ràng buộc toàn vẹn (`CHECK`, `UNIQUE`, `DEFAULT`).<br>• Viết và kiểm thử 6 Trigger tự động trừ/hoàn kho và đổi trạng thái bàn.<br>• Đánh 5 Nonclustered Index và đo hiệu năng với `STATISTICS IO/TIME`.<br>• Viết thủ tục `sp_NhapKhoTronGoi` xử lý JSON.<br>• Viết Chương 3 (Phần A), Chương 4 (Giao dịch kho), Chương 5 (Giao diện kho). | 100% |
| 4 | **Nguyễn Thái Sơn** | 24110210 | Báo cáo, Kế toán, Kiến trúc phần mềm | `FormBaoCao`, `FormChiTien`, `FormKhach`, `FormDoiMatKhau` | • Xây dựng 6 Khung nhìn (View) và 6 Hàm tính toán (Function).<br>• Viết các SP khách hàng, thống kê doanh thu, chi tiền (`sp_ChiTienNCC`).<br>• Hiện thực tầng DAL chung: `DbHelper.cs`, `CustomSqlExceptionHandler.cs`, chuyển đổi chuỗi kết nối theo Role trong `AppConfig.cs`.<br>• Viết Chương 3 (Phần B), Chương 4 (Chi tiền), Chương 5 (Kiến trúc & Báo cáo), thiết kế Slide. | 100% |

## Phụ lục B: Tóm tắt lịch sử commit Git thật từ Repository

Dưới đây là trích đoạn các commit tiêu biểu ghi nhận quá trình phát triển liên tục của các thành viên trên hệ thống quản lý mã nguồn Git:

```text
* cf06035 - refactor(db): gom va chuan hoa bo script SQL, cap nhat README (AnhKietK)
* b4c6bc9 - feature: Thêm tính năng mang về (AnhKietK)
* d93e27e - Thêm api cho pt thanh toán chuyển khoản (AnhKietK)
* dba97db - fix(merge): giai quyet xung dot App.config.example giua develop va main (AnhKietK)
* 0959fda - định dạng lại app.config.ex (AnhKietK)
* c085deb - Merge pull request #14 from AnhKietK/branch-kiem-tra-button (AnhKietK)
* 5e7c2e5 - thêm file hình thức uống vào images (AnhKietK)
* cc2507b - Merge pull request #13 from AnhKietK/branch-kiem-tra-button (AnhKietK)
* 64705cd - update UI (AnhKietK)
* 4d40754 - Merge pull request #12 from AnhKietK/branch-kiem-tra-button (AnhKietK)
* d5622d8 - sửa lỗi ảnh menu (AnhKietK)
* ed7c7a5 - fix lại refesh form (AnhKietK)
* d6db20f - gộp lại database (AnhKietK)
* 18d8787 - Merge pull request #11 from AnhKietK/branch-kiem-tra-button (AnhKietK)
* cd8679f - fix bug button (AnhKietK)
* 79cdd68 - debug dal và stored procedured (AnhKietK)
* 630f084 - Merge pull request #10 from AnhKietK/SonNguyen (AnhKietK)
* eea7f11 - chore(tv4): hoàn thiện toàn bộ module khách hàng, báo cáo, chi tiền và kiểm thử phân quyền (son0336362836)
* d1febdd - feat(baocao): hoàn thành FormBaoCao với 3 tab doanh thu, món bán chạy và nhật ký hóa đơn (son0336362836)
* bf15d9e - feat(baocao): thêm DTO, DAL, BLL cho thống kê doanh thu, món bán chạy và hóa đơn (son0336362836)
* d24e684 - feat(chi-tien): hoàn thành FormChiTien lập phiếu chi và tra cứu lịch sử (son0336362836)
* a60c155 - Merge branch 'SonNguyen' of https://github.com/AnhKietK/Nhom06_QuanLyQuanCafe into SonNguyen (son0336362836)
* f830976 - Merge pull request #9 from AnhKietK/feature/banhang-anhduy-v2 (AnhKietK)
* 5ef7b88 - Merge pull request #8 from AnhKietK/develop (AnhKietK)
* db8796e - feat(chi-tien): thêm DTO, DAL, BLL cho lập phiếu chi và lịch sử chi tiền (son0336362836)
* ddb9347 - Update README.md (AnhKietK)
* 545cbc2 - feat(khach): hoàn thành FormKhach quản lý khách hàng và phân quyền xóa (son0336362836)
* 526519c - feat(khach): thêm DTO, DAL, BLL cho quản lý khách hàng và lịch sử mua (son0336362836)
* 651a073 - feat(sql): thêm patch CSDL cho module khách hàng, báo cáo và chi tiền (son0336362836)
* 05ccae4 - Merge pull request #7 from AnhKietK/develop (AnhKietK)
```

