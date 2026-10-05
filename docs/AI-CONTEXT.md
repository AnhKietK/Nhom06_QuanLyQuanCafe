# AI-CONTEXT — Ngữ cảnh chung của dự án Quản lý quán cà phê

> **Dành cho AI (và cả người):** đọc hết file này TRƯỚC khi viết bất kỳ dòng code nào.
> Mọi thành viên dùng chung file này để code của 4 người khớp nhau.
> Đặt file tại `docs/AI-CONTEXT.md` trong repo. Chỉ **Thành viên 1** được sửa file này.

---

## 1. Dự án là gì

- Đồ án cuối kỳ môn **Hệ quản trị CSDL (DBMS330284)**, đề tài **Hệ thống quản lý quán cà phê**.
- CSDL: **SQL Server**, tên DB `quanlyquancafe`.
- Ứng dụng: **WinForms (C#)**, kết nối bằng **ADO.NET + Microsoft.Data.SqlClient**.
- **Luật của đề:** ứng dụng chỉ gọi **Stored Procedure / Function / View**. Không viết câu SQL rời rạc truy vấn thẳng vào bảng trong code C#.
  - Được phép: `EXEC sp_...` (CommandType.StoredProcedure), `SELECT * FROM v_...` (view), `SELECT * FROM dbo.fn_...(...)` (hàm).
  - Không được: `SELECT ... FROM HoaDon ...`, `INSERT INTO ...`, `UPDATE ...` viết tay trong C#. (Các role CSDL cũng không có quyền như vậy.)

## 2. Cấu trúc repo

```
database/
  01_schema_full.sql.sql     <- toàn bộ bảng, view, trigger, function, SP, login/role (tên file có đuôi kép .sql.sql)
  02_du_lieu_mau.sql         <- dữ liệu mẫu (chạy lại được nhiều lần, xóa và nạp lại)
docs/
  AI-CONTEXT.md              <- file này (Source of Truth)
  phan-cong.md               <- ai làm gì
  hinh/{auth,banhang,erd,khach-baocao,kho}/   <- ảnh chụp màn hình cho báo cáo
src/QuanLyQuanCafe/
  DAL/   DTO/   BLL/   GUI/{Auth,Ban,BanHang,BaoCao,DanhMuc,Khach,Kho,Main,NhanVien}/
  Session/   Utils/   Resources/   Program.cs   App.config.example
```

**Kiến trúc 4 lớp, gọi một chiều:** `GUI → BLL → DAL → DbHelper → SQL Server`.
- **DTO**: lớp dữ liệu thuần (thuộc tính), không có logic.
- **DAL**: chỉ gọi SP/hàm/view qua `DbHelper`, trả về DTO hoặc `DataTable`. Không có MessageBox.
- **BLL**: kiểm tra đầu vào (rỗng, số âm, định dạng SĐT...) bằng `ValidationHelper` rồi gọi DAL. Không đụng control của Form.
- **GUI**: Form, bắt sự kiện, gọi BLL, hiển thị thông báo/lỗi bằng `UiHelper`.

## 3. Phần nền tảng ĐÃ CÓ (Source of Truth — Đừng viết lại)

Các thành phần nền tảng sau do **Thành viên 1** hoàn thành 100%. Các thành viên khác **bắt buộc tái sử dụng**, mở đọc file thật để biết chữ ký hàm, không được đoán hay tự viết lại:

| Nhóm | File | Mô tả & Cách dùng |
|---|---|---|
| **DAL** | `DAL/DbHelper.cs` | Mở kết nối, chạy SP/function/view. Mọi DAL đều đi qua đây (`ExecuteDataTableSP`, `ExecuteNonQuerySP`, `ExecuteScalarSP`, `ExecuteReaderSP`). |
| **DAL** | `DAL/CustomSqlExceptionHandler.cs` | Bắt lỗi SQL (`THROW 50000` tiếng Việt từ CSDL) chuyển thành thông báo thân thiện. |
| **Tiện ích DB** | `Utils/DbParam.cs` | Tạo `SqlParameter` an toàn: `DbParam.Tao("@TenParam", value)`. Tự động chuyển `null` hoặc chuỗi rỗng sang `DBNull.Value`. |
| **Tiện ích BLL** | `Utils/ValidationHelper.cs` | Tập trung kiểm tra tính hợp lệ ở tầng BLL: `BatBuocNhap`, `BatBuocSoDuong`, `BatBuocTienTo`, `KiemTraDinhDangSoDienThoai`, `KiemTraDoDaiMatKhau`... |
| **Tiện ích UI** | `Utils/UiHelper.cs` | Chuẩn hóa toàn bộ thông báo giao diện ở tầng GUI: `ShowInfo`, `ShowWarning`, `Confirm`, `HienLoi(ex)`. |
| **Điều hướng Form** | `GUI/Main/FormLauncher.cs` | Mở Form động qua Reflection trong container MDI theo tên kiểu từ menu: `FormLauncher.Mo(this, tenDayDuKieu, tenHienThi, modal)`. Form chỉ cần constructor không tham số. |
| **Cấu hình** | `Utils/AppConfig.cs` + `App.config.example` | Đọc chuỗi kết nối động theo vai trò người dùng (`LayChuoiKetNoiTheoRole`). |
| **Phiên làm việc** | `Session/CurrentUser.cs` | Lưu thông tin người đăng nhập hiện tại (`MaNV, TenNV, ChucVu, ActiveConnectionString`). |
| **DTO mẫu** | `DTO/BanDTO.cs`, `DTO/ViTriBanDTO.cs`, `DTO/NhanVienDTO.cs` | DTO mẫu chuẩn, các DTO mới của module khác viết theo phong cách này. |
| **Form cơ sở** | `GUI/Auth/FormDangNhap.*`, `GUI/Main/FormMain.*`, `GUI/Auth/FormDoiMatKhau.*`, `GUI/NhanVien/FormNhanVien.*`, `GUI/Ban/FormBan.*` | Đã hoàn thiện đăng nhập, đổi mật khẩu, phân quyền menu động, quản lý nhân viên, quản lý bàn và khu vực. |

> ⚠️ **QUY ƯỚC BẮT BUỘC: KHÔNG TRUYỀN THAM SỐ OUTPUT TRONG C#**
> - **Nguyên nhân:** Các Stored Procedure sinh mã tự động (`sp_TaoHoaDon`, `sp_NhapKho`, `sp_ThemKhachHang`, `sp_ChiTienNCC`) đều đã có sẵn lệnh `SELECT ... AS MaMoi` ở cuối SP để trả về bảng kết quả (result set / DataTable). `DbHelper` của dự án không hỗ trợ hứng giá trị trả về qua `ParameterDirection.Output`.
> - **Quy tắc làm việc:** Trong code DAL, **tuyệt đối KHÔNG cấu hình `ParameterDirection.Output`**.
> - **Cách lấy mã sinh mới:**
>   1. Truyền tham số mã là `DBNull.Value` hoặc `DbParam.Tao("@MaHD", null)`.
>   2. Gọi `DbHelper.ExecuteDataTableSP(...)` hoặc `DbHelper.ExecuteScalarSP(...)`.
>   3. Đọc mã mới trực tiếp từ kết quả trả về:
>      ```csharp
>      // Ví dụ tạo hóa đơn:
>      var dt = DbHelper.ExecuteDataTableSP(CurrentUser.ActiveConnectionString, "sp_TaoHoaDon",
>          DbParam.Tao("@MaHD", null),
>          DbParam.Tao("@MaKH", maKH),
>          new SqlParameter("@MaNV", maNV),
>          new SqlParameter("@MaBan", maBan),
>          new SqlParameter("@PhuongThucThanhToan", phuongThuc));
>      string maHDMoi = dt.Rows[0]["MaHD"].ToString()!;
>      ```

## 4. Đăng nhập và phân quyền (rất quan trọng)

App dùng **5 connection string**, mỗi cái ứng với một login SQL Server. Luồng đăng nhập:

1. Mở kết nối bằng `login_auth` (chỉ có quyền chạy `sp_DangNhap`).
2. Gọi `sp_DangNhap(@SoDienThoai, @MatKhau)` → trả `MaNV, TenNV, ChucVu`. **Trả 0 dòng nghĩa là sai tài khoản** (SP không ném lỗi).
3. Dựa vào `ChucVu`, chọn connection string cho phần còn lại của phiên làm việc:

| ChucVu trong bảng NhanVien | Login SQL dùng cho phiên | Menu/Form được vào |
|---|---|---|
| Quản lý | `login_quantri` (db_owner, toàn quyền) | Tất cả |
| Phục vụ | `login_phucvu` | Bán hàng, Khách |
| Thu ngân | `login_phucvu` (dùng chung với Phục vụ) | Bán hàng, Khách |
| Thủ kho | `login_thukho` | Kho (nguyên liệu, NCC, nhập kho, công thức) |
| Kế toán | `login_ketoan` | Báo cáo, Chi tiền NCC |

Mật khẩu của các login SQL nằm ở `PHẦN G` cuối file `01_schema_full.sql.sql` và trong `App.config.example`. Không ghi lại vào code hay tài liệu khác.

**Tài khoản thử của ứng dụng** (mật khẩu chung `123456`, đăng nhập bằng số điện thoại):

| SĐT | Chức vụ |
|---|---|
| 0901000001 | Quản lý |
| 0901000002, 0901000003 | Phục vụ |
| 0901000004 | Thu ngân |
| 0901000005 | Thủ kho |
| 0901000006 | Kế toán |

## 5. Quy ước dữ liệu (đừng tự đặt khác)

**Tiền tố mã** (có CHECK trong bảng, sai là lỗi):
`NV` nhân viên · `KH` khách · `B` bàn · `VT` vị trí bàn · `TU` thức uống · `LTU` loại thức uống · `NL` nguyên liệu · `LNL` loại nguyên liệu · `NCC` nhà cung cấp · `HD` hóa đơn · `PN` phiếu nhập · `PC` phiếu chi · `LKH` loại khách.

**Mã tự sinh:** `HD`, `PN`, `KH`, `PC` được SP tự sinh (dạng `HD000001`) khi bạn truyền `NULL` vào tham số `@MaHD / @MaPN / @MaKH / @MaPC` và nhận về qua kết quả `SELECT` của SP. Các mã còn lại (`NV, B, VT, TU, NL, NCC...`) do người dùng/app tự nhập hoặc do BLL gợi ý (`GoiYMaMoi`).

**Giá trị cố định (phải đúng chính tả và dấu):**
- `Ban.TrangThai`: `TRONG`, `COKHACH`, `DATTRUOC`
- `HoaDon.TrangThai`: `Chưa thanh toán`, `Đã thanh toán`, `Đã hủy`
- `HoaDon.PhuongThucThanhToan`: `Tiền mặt`, `Chuyển khoản`, `Thẻ`, `Ví điện tử`
- `NhanVien.ChucVu`: `Quản lý`, `Phục vụ`, `Thu ngân`, `Thủ kho`, `Kế toán`

**Việc do TRIGGER làm sẵn, code C# KHÔNG được làm lại** (làm lại sẽ bị trừ/cộng hai lần):
- Thêm món vào hóa đơn → trừ kho nguyên liệu theo công thức (`trg_CTHD_TruKho`, `trg_CTHD_DieuChinhKho`).
- Tạo hóa đơn → bàn chuyển `COKHACH` (`trg_HoaDon_TaoDon_CapNhatBan`).
- Thanh toán → bàn về `TRONG` và cộng điểm tích lũy cho khách (`trg_HoaDon_ThanhToan_CapNhatBanVaDiem`).
- Hủy hóa đơn → hoàn kho (`trg_HoaDon_Huy_HoanKho`).
- Thêm chi tiết phiếu nhập → cộng kho (`trg_CTPN_CongKho`).

**Lỗi nghiệp vụ:** SP dùng `THROW 50000, N'thông báo tiếng Việt', 1`. Giao diện hiển thị thông báo đó cho người dùng (qua `UiHelper.HienLoi`), không tự viết lại câu chữ.

## 6. Danh sách SP / View / Function theo chức năng

Ký hiệu quyền: **QT** = Quản lý (toàn quyền) · **PV** = Phục vụ/Thu ngân · **TK** = Thủ kho · **KT** = Kế toán.  
Tham số có `= NULL` là tùy chọn. *(Nhắc lại: Trong C# KHÔNG cấu hình tham số `OUTPUT`, SP luôn SELECT trả mã sinh mới về DataTable/Scalar)*.

### Đăng nhập và Tài khoản
| Đối tượng | Tham số | Ghi chú |
|---|---|---|
| `sp_DangNhap` | `@SoDienThoai, @MatKhau` | Dùng `login_auth`. Trả `MaNV, TenNV, ChucVu`. |
| `sp_DoiMatKhau` | `@MaNV, @MatKhauCu, @MatKhauMoi` | PV, TK, KT, QT. Mật khẩu được băm SHA2_256 trong SP. |
| `sp_DatLaiMatKhau` | `@MaNV, @MatKhauMoi` | Chỉ QT. Đặt lại mật khẩu mới cho nhân viên. |

### Bán hàng (PV, QT)
| Đối tượng | Tham số | Ghi chú |
|---|---|---|
| `sp_LayDanhSachBan` | không | `MaBan, SoBan, SoChoNgoi, TrangThai, MaViTri, TenViTri` |
| `sp_LayHoaDonDangMoTheoBan` | `@MaBan` | Hóa đơn "Chưa thanh toán" của bàn; 0 dòng nếu bàn trống. |
| `sp_TaoHoaDon` | `@MaHD = NULL, @MaKH = NULL, @MaNV, @MaBan, @PhuongThucThanhToan` | Lỗi nếu bàn không `TRONG`. Trả về DataTable có cột `MaHD`. Không dùng OUTPUT param. |
| `sp_ThemMonVaoHoaDon` | `@MaHD, @MaThucUong, @SoLuong` | Món đã có thì cộng dồn. Lỗi "Không đủ nguyên liệu" nếu thiếu kho. |
| `sp_CapNhatSoLuongMon` | `@MaHD, @MaThucUong, @SoLuongMoi` | |
| `sp_LayChiTietHoaDon` | `@MaHD` | `MaThucUong, TenThucUong, SoLuong, DonGia, ThanhTien` |
| `sp_ThanhToanHoaDon` | `@MaHD, @TienGiamGia = NULL, @PhuongThucThanhToan` | `@TienGiamGia = NULL` thì tự tính theo hạng khách. Trả `TongTienThanhToan`. |
| `sp_HuyHoaDon` | `@MaHD` | Chỉ hủy được hóa đơn "Chưa thanh toán". |
| `sp_TimKiemThucUong` | `@TuKhoa = NULL, @MaLoaiTU = NULL` | |
| `sp_LayDanhSachThucUongTheoLoai` | `@MaLoaiTU = NULL` | |
| `sp_LayDanhSachLoaiThucUong` | không | |
| `fn_TinhThanhTienHoaDon(@MaHD)` · `fn_KiemTraDuNguyenLieu(@MaThucUong, @SoLuong)` · `fn_ChietKhauTheoLoaiKH(@MaKH)` | | Xem định nghĩa trong file SQL trước khi dùng. |
| `v_HoaDon` | | Hóa đơn kèm tổng tiền hàng và tổng thanh toán. |

### Khách hàng (PV, QT; riêng xóa chỉ QT)
| Đối tượng | Tham số | Ghi chú |
|---|---|---|
| `sp_ThemKhachHang` | `@MaKH = NULL, @TenKH, @SoDienThoai, @MaLoaiKH = 'LKH01'` | Trả về `MaKHMoi` qua SELECT. Không dùng OUTPUT param. |
| `sp_SuaKhach` | `@MaKH, @TenKH, @SoDienThoai, @MaLoaiKH` | |
| `sp_XoaKhach` | `@MaKH` | **Chỉ QT.** |
| `sp_TimKiemKhach` | `@TuKhoa` | Tìm theo tên hoặc SĐT. Truyền chuỗi rỗng `''` để lấy tất cả (truyền `NULL` sẽ không ra dòng nào). |
| `fn_LichSuMuaHang(@MaKH)` | | Hàm trả bảng. |
| `v_KhachHangThanThiet` | | Điểm tích lũy, hạng, chiết khấu. |

### Kho (TK, QT)
| Đối tượng | Tham số | Ghi chú |
|---|---|---|
| `sp_LayDanhSachNguyenLieu` | không | Có `TenLoai, DonViTinh`. |
| `sp_ThemNguyenLieu` | `@MaNL, @TenNL, @SoLuongTonKho = 0, @MucToiThieu = 5, @MaLoaiNL` | |
| `sp_SuaNguyenLieu` | `@MaNL, @TenNL, @MucToiThieu, @MaLoaiNL` | Không sửa được tồn kho trực tiếp (tồn kho đổi qua nhập/bán). |
| `sp_LayDanhSachNCC` · `sp_ThemNCC` · `sp_SuaNCC` | `@MaNCC, @TenNCC, @DiaChi, @SoDienThoai, @Email` | |
| `sp_NhapKho` | `@MaPN = NULL, @MaNCC, @MaNV, @GhiChu = NULL` | Tạo phiếu nhập (đầu phiếu). Trả về `MaPN` qua SELECT. Không dùng OUTPUT param. |
| `sp_ThemChiTietPhieuNhap` | `@MaPN, @MaNL, @SoLuongNhap, @DonGiaNhap, @HanSuDung = NULL` | Mỗi cặp (phiếu, nguyên liệu) chỉ một dòng. |
| `sp_LuuCongThuc` | `@MaThucUong, @MaNL, @SoLuongQuyDinh` | TK và QT. |
| `v_TonKhoCanhBao` | | Nguyên liệu dưới mức tối thiểu. |
| `v_PhieuNhap` | | Phiếu nhập kèm `TongTien`. |

### Danh mục thức uống (chỉ QT)
`sp_ThemThucUong`, `sp_SuaThucUong` (`@MaThucUong, @TenThucUong, @DonGiaBan, @MaLoaiTU, @HinhAnh = NULL`), `sp_XoaThucUong(@MaThucUong)`. `HinhAnh` có thể NULL: giao diện phải xử lý được.

### Nhân viên và Bàn (chỉ QT)
- Nhân viên: `sp_LayDanhSachNhanVien`, `sp_ThemNhanVien(@MaNV, @TenNV, @ChucVu, @SoDienThoai, @CaLamViec, @MatKhau, @MaQL = NULL)`, `sp_SuaNhanVien(@MaNV, @TenNV, @ChucVu, @SoDienThoai, @CaLamViec, @MaQL = NULL)`.
- Bàn: `sp_ThemBan(@MaBan, @SoBan, @SoChoNgoi, @MaViTri)`, `sp_SuaBan(... , @TrangThai = NULL)`, `sp_XoaBan(@MaBan)`.
- Vị trí bàn: `sp_LayDanhSachViTriBan`, `sp_ThemViTriBan(@MaViTri, @TenViTri, @MoTa = NULL)`, `sp_SuaViTriBan`, `sp_XoaViTriBan(@MaViTri)`.

### Báo cáo và chi tiền (KT, QT)
| Đối tượng | Tham số | Ghi chú |
|---|---|---|
| `sp_ThongKeDoanhThu` | `@TuNgay, @DenNgay` | `Ngay, SoHoaDon, TongDoanhThu` |
| `v_DoanhThuTheoNgay` · `v_MonBanChay` · `v_HoaDon` · `v_PhieuNhap` | | |
| `fn_MonBanChayNhat(@TuNgay, @DenNgay)` | | Hàm trả bảng. |
| `sp_ChiTienNCC` | `@MaPC = NULL, @SoTienChi, @LyDoChi, @MaNV, @MaNCC = NULL` | Trả về `MaPC` qua SELECT. Không dùng OUTPUT param. |

## 7. Quy tắc làm việc chung

**Mỗi file có đúng một chủ.** Chỉ sửa file thuộc phần mình (xem `phan-cong.md`). Cần thứ gì ở phần người khác thì nhắn người đó, đừng tự sửa hộ.

**File dùng chung, chỉ Thành viên 1 được sửa:** `Program.cs`, `*.csproj`, `DAL/DbHelper.cs`, `DAL/CustomSqlExceptionHandler.cs`, `Utils/AppConfig.cs`, `Utils/ValidationHelper.cs`, `Utils/UiHelper.cs`, `Utils/DbParam.cs`, `Session/CurrentUser.cs`, `GUI/Main/*`, `database/01_*.sql`, `database/02_*.sql`, `docs/AI-CONTEXT.md`.

**Không gọi chéo DAL/BLL của người khác.** Cần dữ liệu thuộc module khác thì gọi thẳng SP đó bằng `DbHelper` trong DAL của mình (SP là hợp đồng chung, ai được cấp quyền thì gọi được).

**Đặt tên:**
- Lớp: `XxxDTO`, `XxxDAL`, `XxxBLL`, form `FormXxx`. Namespace theo thư mục (mặc định Visual Studio), ví dụ `QuanLyQuanCafe.GUI.BanHang`.
- Mỗi form chính của module phải có **constructor không tham số** để menu của `FormMain` mở được qua `FormLauncher`.
- Tên form chính của từng module đã chốt trong `phan-cong.md`. Không đổi.

**Git:**
- Không commit thẳng lên `main`. Mỗi người làm trên nhánh `feature/<module>-<tên>`, xong thì tạo Pull Request cho Thành viên 1 duyệt và gộp.
- Commit nhỏ, thông điệp rõ (ví dụ `feat(kho): thêm form nhập kho`).
- **Không commit:** thư mục `bin/`, `obj/`, `.vs/`, file `App.config` thật (chỉ commit `App.config.example`).
- Cần sửa CSDL (thêm SP, cấp quyền): không sửa file `01_*.sql`. Tạo file mới `database/03_patch_<module>.sql` viết kiểu `CREATE OR ALTER` / `IF NOT EXISTS` để chạy lại được, rồi báo Thành viên 1 gộp vào bản chính.

**Cách làm một chức năng (thứ tự bắt buộc):** DTO → DAL → BLL → GUI. Chạy thử DAL với dữ liệu mẫu trước khi vẽ form.

**Khi thiếu thông tin:** không bịa tên SP, tên cột hay chữ ký hàm. Mở `database/01_schema_full.sql.sql` tìm đúng định nghĩa; không có thì ghi lại và hỏi.
