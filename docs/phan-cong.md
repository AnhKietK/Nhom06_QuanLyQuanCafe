# Phân công nhóm 06 — Quản lý quán cà phê

> Đọc kèm `docs/AI-CONTEXT.md` (quy ước chung, danh sách SP, phân quyền). File này chỉ nói **ai làm gì**.
> Ô `[điền]` là phần nhóm tự điền tên và ngày.

## 1. Bảng tổng quan

| TV | Họ tên | Vai trò | Thư mục sở hữu | Form chính (tên đã chốt) |
|---|---|---|---|---|
| **1** | Hoàng Anh Kiệt | Trưởng nhóm, nền tảng, đăng nhập, quản trị | `GUI/Auth`, `GUI/Main`, `GUI/NhanVien`, `GUI/Ban` + toàn bộ file dùng chung | `FormDangNhap`, `FormDoiMatKhau`, `FormMain`, `FormNhanVien`, `FormBan` |
| **2** | Lê Anh Duy (24110180) | Bán hàng (POS) | `GUI/BanHang` | `FormBanHang` |
| **3** | Võ Lê Ngọc Hưng | Kho và danh mục thức uống | `GUI/Kho`, `GUI/DanhMuc` | `FormNguyenLieu`, `FormNhaCungCap`, `FormNhapKho`, `FormCongThuc`, `FormThucUong` |
| **4** | Võ Tấn Phát | Khách hàng, báo cáo, chi tiền | `GUI/Khach`, `GUI/BaoCao` | `FormKhach`, `FormBaoCao`, `FormChiTien` |

Mỗi người còn tự tạo `DTO/`, `DAL/`, `BLL/` riêng cho module mình (tên file ghi ở phần 3). Tên file không trùng nhau nên không bị xung đột khi gộp.

**Vì sao chia vậy:** mỗi module chạy trên một role SQL khác nhau (Quản lý / Phục vụ / Thủ kho / Kế toán) và dùng nhóm SP riêng, nên 4 người làm song song được, gần như không chạm file của nhau. Bán hàng là phần nặng nhất nên TV2 chỉ làm đúng một module đó.

## 2. Bước 0: việc của TV1 TRƯỚC khi mọi người bắt đầu

Hiện `main` chỉ có database, còn phần nền tảng nằm trên máy TV1. Nếu không đưa lên trước, AI của các bạn sẽ không thấy `DbHelper` và sẽ tự bịa ra bản khác. Làm theo thứ tự:

1. **Dọn repo trước khi push.** Trong bản nén thấy thư mục `bin/`, `obj/`, `.vs/` và `App.config`. Kiểm tra `.gitignore` đã chặn `bin/ obj/ .vs/ App.config`; chạy `git status` đảm bảo không có file nào trong số này sắp bị commit. `App.config` chứa mật khẩu SQL nên chỉ commit `App.config.example`.
2. **Chốt phiên bản .NET.** Thư mục build có cả `net8.0-windows` và `net10.0-windows`. Mở `QuanLyQuanCafe.csproj`, chọn **một** `TargetFramework` (kế hoạch ban đầu là .NET 8) và báo cả nhóm cài đúng bản đó. Máy ai lệch bản là build lỗi.
3. **Đưa hai file tài liệu vào `docs/`:** `AI-CONTEXT.md` và `phan-cong.md` này (thay file `docs/phan-cong.md` cũ).
4. **Tạo sẵn `FormMain` khung** có menu trỏ tới các form chính ở bảng trên (chưa có form thì để dòng comment hoặc form rỗng cùng tên). Nhờ vậy 3 người kia không ai phải sửa `FormMain`.
5. **Push lên nhánh `feature/nen-tang`, mở Pull Request vào `main`, tự gộp.** Rồi nhắn nhóm: `git switch main` → `git pull`.
6. **Gửi nhóm** các thông tin: bản .NET, cách tạo `App.config` từ `App.config.example`, cách chạy `01_schema_full.sql.sql` rồi `02_du_lieu_mau.sql` trên SQL Server máy mình.

**Cách mỗi thành viên (2, 3, 4) bắt đầu sau khi TV1 xong bước 0:**
```
git switch main
git pull
git switch -c feature/<module>-<tên>      # ví dụ feature/banhang-an
copy App.config.example -> App.config     # rồi điền SQL Server của máy mình
# chạy 2 file SQL trong thư mục database/ trên SQL Server máy mình
```

## 3. Chi tiết từng thành viên

### Thành viên 1: Nền tảng, đăng nhập, quản trị

**Thứ tự ưu tiên:** (1) bước 0 ở trên, (2) đăng nhập và `FormMain` phân quyền, vì không có đăng nhập thì các bạn khác chỉ test được bằng cách chạy form riêng, (3) Nhân viên, (4) Bàn, (5) ghép nối và kiểm thử cuối.

| Việc | File tạo | SP/Đối tượng dùng |
|---|---|---|
| Đăng nhập, chọn connection string theo chức vụ (bảng mục 4 AI-CONTEXT) | `GUI/Auth/FormDangNhap`, `BLL/AuthBLL`, `DAL/AuthDAL` | `sp_DangNhap` |
| Đổi mật khẩu | `GUI/Auth/FormDoiMatKhau` | `sp_DoiMatKhau` |
| Form chính, ẩn/hiện menu theo chức vụ | `GUI/Main/FormMain` | `Session/CurrentUser` |
| Quản lý nhân viên (xem, thêm, sửa) | `GUI/NhanVien/FormNhanVien`, `DTO/NhanVienDTO` (đã có), `DAL/NhanVienDAL`, `BLL/NhanVienBLL` | `sp_LayDanhSachNhanVien`, `sp_ThemNhanVien`, `sp_SuaNhanVien` |
| Quản lý bàn và vị trí bàn (xem, thêm, sửa, xóa) | `GUI/Ban/FormBan`, `DTO/BanDTO` (đã có), `DTO/ViTriBanDTO`, `DAL/BanDAL`, `BLL/BanBLL` | `sp_LayDanhSachBan`, `sp_ThemBan`, `sp_SuaBan`, `sp_XoaBan`, `sp_*ViTriBan` |
| Người giữ CSDL: viết `database/03_patch_*.sql` theo yêu cầu của 3 người kia (xem mục 5) | `database/03_patch_*.sql` | |
| Duyệt và gộp Pull Request, giữ `main` luôn build được | | |

**Xong khi:** đăng nhập đủ 6 tài khoản thử vào đúng quyền (Phục vụ không thấy menu Kho/Báo cáo, Kế toán không thấy Bán hàng...); nhân viên và bàn thêm/sửa được; `main` build sạch trên máy cả 4 người.

### Thành viên 2: Bán hàng (POS) — chạy bằng `login_phucvu`

Đây là module trung tâm và nhiều ràng buộc nhất (kho, trạng thái bàn, điểm khách đều do trigger xử lý, xem mục 5 AI-CONTEXT).

| Việc | File tạo | SP/Đối tượng dùng |
|---|---|---|
| Sơ đồ bàn, màu theo trạng thái `TRONG / COKHACH / DATTRUOC` | `GUI/BanHang/FormBanHang`, `DAL/BanHangDAL` | `sp_LayDanhSachBan` |
| Mở bàn: tạo hóa đơn, gắn khách (tùy chọn) | `DAL/HoaDonDAL`, `BLL/HoaDonBLL`, `DTO/HoaDonDTO`, `DTO/ChiTietHoaDonDTO` | `sp_TaoHoaDon`, `sp_LayHoaDonDangMoTheoBan` |
| Chọn món: lọc theo loại, tìm kiếm | `DAL/MenuBanHangDAL`, `DTO/ThucUongDTO` | `sp_LayDanhSachLoaiThucUong`, `sp_LayDanhSachThucUongTheoLoai`, `sp_TimKiemThucUong` |
| Thêm món, đổi số lượng, xem chi tiết hóa đơn | trong `HoaDonDAL/BLL` | `sp_ThemMonVaoHoaDon`, `sp_CapNhatSoLuongMon`, `sp_LayChiTietHoaDon` |
| Thanh toán (chọn phương thức, giảm giá), hủy hóa đơn | trong `HoaDonDAL/BLL` | `sp_ThanhToanHoaDon`, `sp_HuyHoaDon`, `fn_TinhThanhTienHoaDon`, `fn_ChietKhauTheoLoaiKH` |
| Chọn khách cho hóa đơn | trong `HoaDonDAL` (tự gọi SP, không dùng DAL của TV4) | `sp_TimKiemKhach` (truyền `''` để lấy hết) |

**Lưu ý:** không tự trừ kho, không tự đổi trạng thái bàn, không tự cộng điểm trong C# (trigger đã làm). Phải hiển thị đúng thông báo "Không đủ nguyên liệu" khi thêm món thất bại.

**Xong khi:** quy trình trọn vẹn chạy được với 2 tài khoản Phục vụ và 1 Thu ngân: mở bàn → thêm 3 món → sửa số lượng → thanh toán khách thường và khách thân thiết (đúng chiết khấu) → bàn tự về trống; hủy hóa đơn hoàn kho; thêm món vượt kho báo lỗi đúng.

### Thành viên 3: Kho và danh mục thức uống — `login_thukho` và `login_quantri`

| Việc | File tạo | SP/Đối tượng dùng | Role |
|---|---|---|---|
| Nguyên liệu: xem, thêm, sửa; cảnh báo tồn thấp | `GUI/Kho/FormNguyenLieu`, `DAL/NguyenLieuDAL`, `BLL/NguyenLieuBLL`, `DTO/NguyenLieuDTO` | `sp_LayDanhSachNguyenLieu`, `sp_ThemNguyenLieu`, `sp_SuaNguyenLieu`, `v_TonKhoCanhBao` | TK, QT |
| Nhà cung cấp: xem, thêm, sửa | `GUI/Kho/FormNhaCungCap`, `DAL/NhaCungCapDAL`, ... | `sp_LayDanhSachNCC`, `sp_ThemNCC`, `sp_SuaNCC` | TK, QT |
| Nhập kho: tạo phiếu rồi thêm nhiều dòng nguyên liệu; xem lịch sử phiếu | `GUI/Kho/FormNhapKho`, `DAL/PhieuNhapDAL`, ... | `sp_NhapKho`, `sp_ThemChiTietPhieuNhap`, `v_PhieuNhap` | TK, QT |
| Công thức pha chế của từng thức uống | `GUI/DanhMuc/FormCongThuc`, `DAL/CongThucDAL`, ... | `sp_LuuCongThuc` (xem khoảng trống ở mục 5) | TK, QT |
| Thức uống: thêm, sửa, xóa, ảnh có thể rỗng | `GUI/DanhMuc/FormThucUong`, `DAL/ThucUongDAL`, `BLL/ThucUongBLL`, `DTO/ThucUongDTO` | `sp_ThemThucUong`, `sp_SuaThucUong`, `sp_XoaThucUong`, `sp_LayDanhSachThucUongTheoLoai` | **Chỉ QT** |

**Lưu ý:** tồn kho tăng nhờ trigger khi thêm chi tiết phiếu nhập, đừng cộng tay. `FormThucUong` chỉ Quản lý mở được vì Thủ kho không có quyền ghi vào thức uống.

**Xong khi:** nhập một phiếu 3 nguyên liệu thì tồn kho tăng đúng; nguyên liệu dưới mức tối thiểu hiện trong cảnh báo; lưu được công thức cho một thức uống mới; thêm thức uống mới rồi TV2 thấy nó trong màn hình bán.

### Thành viên 4: Khách hàng, báo cáo, chi tiền

| Việc | File tạo | SP/Đối tượng dùng | Role |
|---|---|---|---|
| Khách: tìm, thêm, sửa, xóa; xem điểm và hạng | `GUI/Khach/FormKhach`, `DAL/KhachDAL`, `BLL/KhachBLL`, `DTO/KhachDTO` | `sp_TimKiemKhach`, `sp_ThemKhachHang`, `sp_SuaKhach`, `sp_XoaKhach`, `v_KhachHangThanThiet` | PV, QT (xóa chỉ QT) |
| Lịch sử mua hàng của khách | trong `FormKhach` | `fn_LichSuMuaHang` | PV, QT |
| Báo cáo doanh thu theo khoảng ngày, biểu đồ hoặc bảng | `GUI/BaoCao/FormBaoCao`, `DAL/BaoCaoDAL`, `BLL/BaoCaoBLL` | `sp_ThongKeDoanhThu`, `v_DoanhThuTheoNgay` | KT, QT |
| Món bán chạy, danh sách hóa đơn | trong `FormBaoCao` | `v_MonBanChay`, `fn_MonBanChayNhat`, `v_HoaDon` | KT, QT |
| Chi tiền nhà cung cấp | `GUI/BaoCao/FormChiTien`, `DAL/PhieuChiDAL`, ... | `sp_ChiTienNCC` | KT, QT |
| Tổng hợp báo cáo cuối kỳ (ghép phần của 4 người vào `docs/bao-cao`) | | | |

**Xong khi:** thêm khách mới thì có mã `KH...` tự sinh; khách VIP/thân thiết hiển thị đúng chiết khấu; báo cáo doanh thu khớp với số hóa đơn đã thanh toán trong dữ liệu mẫu; Kế toán chi tiền được và có phiếu chi.

## 4. Mốc làm việc (điền ngày)

| Mốc | Nội dung | Hạn |
|---|---|---|
| 0 | TV1 push nền tảng lên `main`, cả nhóm pull và chạy được app rỗng | [điền] |
| 1 | Mỗi người xong **DTO + DAL + BLL** của module, test với dữ liệu mẫu (chưa cần form đẹp). TV1 xong đăng nhập và `FormMain`. | [điền] |
| 2 | Xong form GUI, mở được từ menu `FormMain`, chạy đủ luồng chính | [điền] |
| 3 | Tích hợp: gộp hết vào `main`, chạy thử xuyên module (nhập kho → bán hàng → báo cáo) | [điền] |
| 4 | Kiểm thử theo từng role, chụp ảnh vào `docs/hinh/<module>/`, viết báo cáo, làm thuyết trình | [điền] |

## 5. Khoảng trống CSDL đã phát hiện (gửi TV1 vá bằng `03_patch_*.sql`)

Mình đọc file SQL và thấy các chỗ app sẽ vướng nếu chỉ dùng SP/View hiện có. Ai cần thì báo TV1, đừng tự viết SQL vào code:

1. **Không có SP đọc công thức** của một thức uống (chỉ có `sp_LuuCongThuc`). TV3 cần `sp_LayCongThuc(@MaThucUong)` để hiển thị và sửa công thức.
2. **Không có SP/View đọc chi tiết phiếu nhập** (`v_PhieuNhap` chỉ có tổng tiền). TV3 cần nếu muốn xem lại từng dòng của phiếu.
3. **Không có SP lấy danh sách Loại nguyên liệu và Loại khách** để đổ vào ComboBox (TV3 khi thêm nguyên liệu, TV4 khi thêm khách).
4. **Kế toán chưa được cấp quyền lấy danh sách nhà cung cấp** (`login_ketoan` không có `sp_LayDanhSachNCC`) nên `FormChiTien` không có gì để chọn NCC. Cần `GRANT EXECUTE ON sp_LayDanhSachNCC TO KeToan`. Cũng chưa có SP/View liệt kê phiếu chi.
5. **Chưa có SP xóa** nguyên liệu, nhà cung cấp, nhân viên. Nếu cô yêu cầu CRUD đầy đủ cho các bảng này thì cần thêm.
6. Lưu ý, không phải lỗi: `sp_TimKiemKhach` truyền `''` mới lấy được tất cả khách.

## 6. Prompt mẫu để dán cho AI của từng người

Dán đoạn dưới vào AI **ngay đầu mỗi phiên làm việc** (thay phần trong `[ ]`). Nó buộc AI đọc ngữ cảnh trước khi code.

```
Tôi là Thành viên [1/2/3/4] của nhóm đồ án quản lý quán cà phê (WinForms C# + SQL Server).

BƯỚC 1 - ĐỌC TRƯỚC, CHƯA ĐƯỢC VIẾT CODE:
- docs/AI-CONTEXT.md và docs/phan-cong.md
- src/QuanLyQuanCafe/DAL/DbHelper.cs, DAL/CustomSqlExceptionHandler.cs,
  Utils/AppConfig.cs, Session/CurrentUser.cs, DTO/BanDTO.cs, DTO/NhanVienDTO.cs
- database/01_schema_full.sql.sql, đúng phần các SP/View tôi sẽ dùng
Sau khi đọc, hãy tóm tắt lại cho tôi: (a) chữ ký các hàm của DbHelper, (b) các SP tôi được dùng
và tham số của chúng, (c) role SQL mà module của tôi chạy. Tôi xác nhận rồi mới đi tiếp.

BƯỚC 2 - PHẠM VI CỦA TÔI:
- Module: [tên module, copy từ phan-cong.md]
- Chỉ được tạo/sửa file trong: [liệt kê thư mục + tên file của mình]
- KHÔNG được sửa: Program.cs, *.csproj, DbHelper, AppConfig, CurrentUser, GUI/Main, file SQL 01/02, và file của người khác.

LUẬT BẮT BUỘC:
- Chỉ gọi SP/Function/View, không viết SQL truy vấn bảng trong C#.
- Không đoán tên SP, tên cột, chữ ký hàm. Thiếu thì dừng lại và hỏi tôi.
- Không tự trừ kho / đổi trạng thái bàn / cộng điểm (trigger đã làm).
- Làm theo thứ tự DTO -> DAL -> BLL -> GUI, mỗi bước dừng cho tôi kiểm tra.
- Form chính phải đúng tên đã chốt trong phan-cong.md và có constructor không tham số.
- Cần thêm SP hoặc cấp quyền: soạn nội dung cho file database/03_patch_[module].sql
  để tôi gửi Thành viên 1, không sửa file SQL gốc.
```

**Nhắc thêm cho từng người (nối vào cuối prompt):**

- **TV1:** "Làm theo thứ tự ưu tiên trong phan-cong.md. Với đăng nhập: dùng `login_auth` gọi `sp_DangNhap`, sau đó đổi connection string theo bảng ở mục 4 của AI-CONTEXT."
- **TV2:** "Trọng tâm là luồng mở bàn → thêm món → thanh toán. Hiển thị nguyên văn thông báo lỗi tiếng Việt từ SP. Khi gọi `sp_TaoHoaDon` truyền `@MaHD = NULL` kiểu OUTPUT để SP tự sinh mã."
- **TV3:** "`FormThucUong` chỉ mở cho Quản lý. Nhập kho là hai bước: `sp_NhapKho` lấy `@MaPN` OUTPUT, rồi lặp `sp_ThemChiTietPhieuNhap` cho từng nguyên liệu."
- **TV4:** "`FormKhach` dùng role phục vụ nên không có nút Xóa trừ khi đăng nhập Quản lý. Gọi `sp_TimKiemKhach` với chuỗi rỗng để nạp toàn bộ danh sách."

## 7. Khi các phần ghép lại bị lệch, kiểm tra theo thứ tự này

1. Lệch tên form hoặc thiếu constructor không tham số → đối chiếu bảng mục 1.
2. Lỗi "permission denied" khi chạy → module đang dùng sai connection string/role, đối chiếu mục 4 AI-CONTEXT.
3. Tồn kho hoặc điểm khách bị tính hai lần → có đoạn C# tự cập nhật trong khi trigger đã làm.
4. Một người cần SP chưa có → vào mục 5 của file này, nhờ TV1 vá bằng file patch.
