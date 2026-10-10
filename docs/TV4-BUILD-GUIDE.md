# TV4-BUILD-GUIDE: AI xây phần của Thành viên 4 (Khách hàng, Báo cáo và Chi tiền)

Đặt file này ở `docs/TV4-BUILD-GUIDE.md`. File dành cho AI lập trình (Antigravity/Codex).
Người dùng là Thành viên 4. Người dùng tự commit bằng tay sau mỗi bước.
Đọc kèm: `docs/AI-CONTEXT.md` (quy ước chung, gồm mục 8 về giao diện) và `docs/phan-cong.md` (ai làm gì).
Giả định: Thành viên 1 đã hoàn thành và gộp vào `main` toàn bộ nền tảng (DbHelper, ValidationHelper, UiHelper, DbParam, CurrentUser, AuthBLL, FormMain, FormLauncher, Theme); Thành viên 3 đã hoàn thành phần Kho & Danh mục. Bước 0 sẽ kiểm tra các giả định này.

---

## 0. Cách dùng (dành cho người dùng)

Chuẩn bị nhánh và máy:

```bash
git switch main
git pull
git switch -c feature/khach-baocao-<tên_bạn>
```

Kiểm tra `App.config` trên máy bạn đã kết nối đúng SQL Server cục bộ. Đảm bảo đã chạy `01_schema_full.sql.sql`, `02_du_lieu_mau.sql` và `03_patch_kho.sql`.

Mở thư mục repo trong Antigravity/VS Code, dán đoạn sau vào ô chat để AI bắt đầu Bước 0:

```text
Hãy đọc docs/TV4-BUILD-GUIDE.md, docs/AI-CONTEXT.md (kể cả mục 8 giao diện) và docs/phan-cong.md.
Tôi là Thành viên 4 (Khách hàng, Báo cáo và Chi tiền). Chỉ làm đúng phần của Thành viên 4, theo từng bước trong TV4-BUILD-GUIDE.md.
Sau mỗi bước phải DỪNG và chờ tôi gõ "Xác nhận Bước N" (tôi sẽ tự commit bằng git).
Chưa được làm bước tiếp theo khi tôi chưa xác nhận. Bắt đầu với Bước 0.
```

Sau mỗi bước: Tự kiểm tra theo checklist, commit bằng lệnh `git add` có đường dẫn cụ thể (AI gợi ý ở cuối mỗi bước), rồi gõ `Xác nhận Bước N`.

Nếu có lỗi, gõ `Sửa Bước N: <mô tả lỗi>` kèm ảnh/thông báo lỗi. AI sửa xong dừng lại chờ xác nhận tiếp.

Không gõ "làm hết đi". Chạy từng bước để kiểm soát lỗi và giữ lịch sử Git rõ ràng cho báo cáo.

Khi hoàn thành module Khách hàng hoặc module Báo cáo/Chi tiền, có thể `git push` và mở Pull Request cho TV1 duyệt gộp, không cần đợi làm xong toàn bộ.

Cách chạy thử: F5, đăng nhập `0901000002` (Phục vụ), `0901000006` (Kế toán) hoặc `0901000001` (Quản lý) với mật khẩu `123456`, mở form từ menu. Không sửa `Program.cs`.

---

## 1. LUẬT BẮT BUỘC CHO AI

- Làm đúng một bước rồi DỪNG. Tuyệt đối không làm trước bước sau, không "tiện tay" sửa thêm file.
- Chỉ tạo hoặc sửa các file nằm trong danh sách "File" của bước hiện tại. Không đụng file ngoài danh sách.
- Không tự chạy lệnh git (add, commit, push, pull, switch...). Người dùng tự chạy. AI chỉ gợi ý lệnh ở cuối mỗi bước.
- Sau mỗi bước có code C# phải chạy lệnh `dotnet build src/QuanLyQuanCafe/QuanLyQuanCafe.csproj`. Bước chỉ hoàn thành khi 0 Error. Nếu gặp lỗi, tự sửa tối đa 3 lần; nếu không được phải dừng và báo cáo trung thực.
- Trung thực khi báo cáo: Chưa chạy trên DB thật thì nói "chưa chạy thử", không nói "đã test".
- Không đổi TargetFramework, không cài thêm thư viện/NuGet bên ngoài, không sửa `.gitignore`, không sửa `database/01_*.sql` hay `02_*.sql`.
- Không đoán tên Stored Procedure, Function, View hay tên cột. Dùng đúng định nghĩa ở mục 3 của tài liệu này hoặc tra trực tiếp trong file SQL.
- Truy cập dữ liệu chỉ qua SP / Function / View bằng DbHelper. Không viết câu SQL `SELECT * FROM Bảng`, `INSERT`, `UPDATE`, `DELETE` rời rạc trong mã C#.
- Không hard-code connection string, tài khoản, mật khẩu. Dùng `CurrentUser` và `AppConfig` do nền tảng cung cấp.
- Không tự tính lại logic do Trigger / Database đảm nhiệm: Điểm tích lũy khách hàng do trigger thanh toán tự cộng (`trg_HoaDon_ThanhToan_CapNhatBanVaDiem`); mã khách hàng `KH...` và mã phiếu chi `PC...` do SP tự sinh khi truyền NULL.
- Mọi chuỗi hiển thị giao diện là tiếng Việt có dấu. Không để lộ chuỗi lỗi tiếng Anh hoặc exception thô ra màn hình.
- Tuân thủ kiến trúc 3 tầng + DTO: GUI -> BLL -> DAL -> DbHelper. GUI không gọi thẳng DAL, BLL không giữ control Form, DAL không hiển thị MessageBox.
- Quyền ghi file trực tiếp: AI được phép và BẮT BUỘC phải thực thi ghi đè/tạo trực tiếp các thay đổi mã nguồn xuống ổ đĩa, đảm bảo lưu file vật lý trước khi chạy `dotnet build`.
- Giao diện tự động (UI/UX): Tuân thủ `AI-CONTEXT.md` mục 8.8. Không gán màu cứng (`Color.FromArgb`), không tự gọi `Theme.Apply` (FormLauncher đã tự gọi), không sửa các file dùng chung (`Theme.cs`, `ModernMenuRenderer.cs`, `FormMain.cs`). Đặt tên nút theo chuẩn (`btnThem`, `btnSua`, `btnXoa`, `btnLamMoi`, `btnLoc`, `btnChiTien`...) để Theme tự nhận diện màu.

---

## 2. Phạm vi của Thành viên 4

Thư mục GUI sở hữu: `GUI/Khach`, `GUI/BaoCao`.

Form chính phải làm (Tên lớp và namespace đã chốt trong menu của FormMain, không đổi):

| Form | Namespace đầy đủ (FormLauncher gọi qua tên này) | Role thấy menu | Ghi chú quyền |
|---|---|---|---|
| FormKhach | `QuanLyQuanCafe.GUI.Khach.FormKhach` | Quản lý, Phục vụ, Thu ngân | Phục vụ/Thu ngân: Xem, Tìm, Thêm, Sửa; Nút Xóa chỉ Quản lý được bấm. |
| FormBaoCao | `QuanLyQuanCafe.GUI.BaoCao.FormBaoCao` | Quản lý, Kế toán | Báo cáo doanh thu, món bán chạy, danh sách hóa đơn. |
| FormChiTien | `QuanLyQuanCafe.GUI.BaoCao.FormChiTien` | Quản lý, Kế toán | Lập phiếu chi cho NCC, xem lịch sử chi. |

File riêng của TV4 (Đã chọn tên để tránh trùng lặp tuyệt đối với TV1, TV2, TV3):

| Loại | Tên file | Mô tả |
|---|---|---|
| DTO | `KhachDTO.cs`, `LoaiKhachDTO.cs`, `LichSuMuaHangDTO.cs`, `DoanhThuNgayDTO.cs`, `MonBanChayDTO.cs`, `HoaDonBaoCaoDTO.cs`, `PhieuChiDTO.cs`, `NhaCungCapLookupDTO.cs` | DTO dữ liệu thuần. Riêng NCC đặt tên `NhaCungCapLookupDTO` để không trùng với `NhaCungCapDTO` của TV3. |
| DAL | `KhachDAL.cs`, `BaoCaoDAL.cs`, `PhieuChiDAL.cs` | Chỉ gọi SP/View/Function qua DbHelper. |
| BLL | `KhachBLL.cs`, `BaoCaoBLL.cs`, `PhieuChiBLL.cs` | Kiểm tra dữ liệu hợp lệ trước khi gọi DAL. |
| SQL | `database/03_patch_khach_baocao.sql` | Patch bổ sung SP lấy loại khách, SP lấy lịch sử phiếu chi và cấp quyền. |

### CẢNH BÁO TRÁNH XUNG ĐỘT (QUAN TRỌNG)

**Tuyệt đối KHÔNG sửa:** `Program.cs`, `*.csproj`, `DbHelper.cs`, `CustomSqlExceptionHandler.cs`, `AppConfig.cs`, `CurrentUser.cs`, `Utils/*`, `GUI/Main/*`, `GUI/Auth/*`, `GUI/NhanVien/*`, `GUI/Ban/*`, `GUI/BanHang/*`, `GUI/Kho/*`, `GUI/DanhMuc/*`, các file SQL `01_*`, `02_*`, `03_patch_kho.sql`, `03_patch_nhanvien.sql`.

**Không dùng chung DAL/BLL với TV3:** Khi làm FormChiTien, cần danh sách Nhà cung cấp để chọn, TV4 tự gọi `sp_LayDanhSachNCC` bên trong `PhieuChiDAL` và ánh xạ vào `NhaCungCapLookupDTO`, không tham chiếu sang `NhaCungCapDAL` hay `NhaCungCapDTO` của TV3.

**Mã tự sinh trong C#:** `sp_ThemKhachHang` và `sp_ChiTienNCC` tự sinh mã qua sequence trong SQL Server (`KH000001`, `PC000001`). Vì DbHelper không nhận tham số OUTPUT, SP trả về kết quả qua câu `SELECT ... AS MaKH / MaPC`. DAL chỉ cần đọc giá trị cột `MaKH` hoặc `MaPC` từ dòng đầu tiên của DataTable.

### Chuẩn kỹ thuật kế thừa từ nền tảng

- Namespace tương ứng: `QuanLyQuanCafe.DTO`, `.DAL`, `.BLL`, `.GUI.Khach`, `.GUI.BaoCao`.
- Tên lớp: `XxxDTO`, `XxxDAL`, `XxxBLL`, `FormXxx`. DAL và BLL là lớp thường (không static), có constructor mặc định. BLL tự khởi tạo DAL.
- Xử lý biệt lệ: BLL kiểm tra đầu vào, ném `ArgumentException` hoặc `InvalidOperationException` bằng tiếng Việt. DAL để `DbException` lan truyền tự nhiên lên trên. GUI dùng khối `try ... catch` bao bọc và hiển thị lỗi qua `UiHelper.HienLoi(ex)`.
- Tham số truy vấn:
  - Tham số bắt buộc: `new SqlParameter("@TenThamSo", giaTri)`.
  - Tham số có thể NULL: `DbParam.Tao("@TenThamSo", giaTri)`.
  - Tiền tệ (decimal): `new SqlParameter("@SoTienChi", SqlDbType.Decimal) { Precision = 12, Scale = 2, Value = soTien }`.
- Form: Mỗi Form có `.cs` và `.Designer.cs` chuẩn WinForms, có constructor public không tham số để FormLauncher khởi tạo qua reflection. Kích thước chuẩn thiết kế 1100 x 650, neo control bằng Dock / Anchor / TableLayoutPanel để co giãn mượt mà.
- Tìm kiếm / Lọc: Khi tìm kiếm danh sách trên lưới DataGridView, ưu tiên lọc trong bộ nhớ (LINQ trên `List<T>` đã nạp) để thao tác tức thì, không spam gọi lại DB.

---

## 3. Hợp đồng SQL của Thành viên 4

Quản lý (`login_quantri`) có toàn quyền. Phục vụ (`login_phucvu`) dùng module Khách hàng. Kế toán (`login_ketoan`) dùng module Báo cáo và Chi tiền.

### 3.1 SP / View / Function có sẵn trong CSDL

| Tên đối tượng | Tham số | Dữ liệu trả về | Quyền |
|---|---|---|---|
| `sp_TimKiemKhach` | `@TuKhoa VARCHAR(50)` (Truyền `''` để lấy tất cả khách) | MaKH, TenKH, SoDienThoai, DiemTichLuy, MaLoaiKH, TenLoaiKH, PhanTramGiam | PV, QT |
| `sp_ThemKhachHang` | `@MaKH = NULL, @TenKH, @SoDienThoai, @MaLoaiKH = 'LKH01'` | KetQua, MaKH (Mã tự sinh dạng KH000001) | PV, QT |
| `sp_SuaKhach` | `@MaKH, @TenKH, @SoDienThoai, @MaLoaiKH` | KetQua | PV, QT |
| `sp_XoaKhach` | `@MaKH` | KetQua. Lỗi nếu khách đã phát sinh hóa đơn. | Chỉ QT |
| `v_KhachHangThanThiet` (view) | | MaKH, TenKH, SoDienThoai, DiemTichLuy, MaLoaiKH, TenLoaiKH, PhanTramGiam | PV, QT |
| `fn_LichSuMuaHang` | `@MaKH VARCHAR(20)` | MaHD, NgayTao, TongTienThanhToan, PhuongThucThanhToan, TenNV, TrangThai (Table function) | PV, QT |
| `sp_ChiTienNCC` | `@MaPC = NULL, @SoTienChi, @LyDoChi, @MaNV, @MaNCC = NULL` | KetQua, MaPC (Mã tự sinh dạng PC000001) | KT, QT |
| `sp_LayDanhSachNCC` | không | MaNCC, TenNCC, DiaChi, SoDienThoai, Email | KT (sau patch), QT |
| `sp_ThongKeDoanhThu` | `@TuNgay DATE, @DenNgay DATE` | Ngay, SoHoaDon, TongDoanhThu (Chỉ tính HĐ đã thanh toán) | KT, QT |
| `v_DoanhThuTheoNgay` (view) | | Ngay, SoHoaDon, TongDoanhThu | KT, QT |
| `fn_MonBanChayNhat` | `@TuNgay DATE, @DenNgay DATE` | MaThucUong, TenThucUong, SoLuongDaBan, TongDoanhThu (Table function) | KT, QT |
| `v_MonBanChay` (view) | | MaThucUong, TenThucUong, SoLuongBan, TongTien | KT, QT |
| `v_HoaDon` (view) | | MaHD, NgayTao, MaBan, TenBan, MaNV, TenNV, MaKH, TenKH, TongTienHang, TienGiamGia, TongThanhToan, PhuongThucThanhToan, TrangThai | KT, QT |

### 3.2 SP mới (Viết trong Bước 1, file `database/03_patch_khach_baocao.sql`)

| Tên đối tượng | Tham số | Dữ liệu trả về | Quyền |
|---|---|---|---|
| `sp_LayDanhSachLoaiKhach` | không | MaLoaiKH, TenLoaiKH, PhanTramGiam, DiemToiThieu | PV, KT, QT |
| `sp_LayDanhSachPhieuChi` | `@TuNgay DATE = NULL, @DenNgay DATE = NULL` | MaPC, NgayChi, SoTienChi, LyDoChi, MaNV, TenNV, MaNCC, TenNCC | KT, QT |
| (Cấp quyền) | `GRANT ...` | Cấp quyền cho KeToan và PhucVu dùng các hàm/view/SP cần thiết | PV, KT |

### 3.3 Ràng buộc nghiệp vụ cần kiểm tra ở BLL

- **KhachHang:** `TenKH` không được rỗng; `SoDienThoai` bắt buộc đúng 10 số bắt đầu bằng số 0 (`ValidationHelper.BatBuocSdt`); `MaLoaiKH` bắt buộc.
- **PhieuChi:** `SoTienChi > 0` (`ValidationHelper.BatBuocSoDuong`); `LyDoChi` không được để trống; `MaNV` lấy từ `CurrentUser.MaNV` (không nhập tay); `MaNCC` có thể null nếu là chi phí vận hành chung.
- **BaoCao:** `TuNgay` phải nhỏ hơn hoặc bằng `DenNgay` (`ValidationHelper.BatBuocKhoangNgay`).

### 3.4 Dữ liệu mẫu kiểm thử

- Khách hàng mẫu: KH01..KH05 (có KH01 hạng Kim Cương, KH02 hạng Vàng...). Loại khách: LKH01 (Đồng, 0%), LKH02 (Bạc, 5%), LKH03 (Vàng, 10%), LKH04 (Kim Cương, 15%).
- Hóa đơn mẫu: 15 hóa đơn HD000001..HD000015 với các trạng thái "Đã thanh toán".
- Nhà cung cấp: NCC01..NCC05.
- Tài khoản thử: Phục vụ `0901000002`, Kế toán `0901000006`, Quản lý `0901000001` (Mật khẩu: `123456`).

---

## 4. CÁC BƯỚC THỰC HIỆN

Cuối mỗi bước, AI phải trả lời theo mẫu báo cáo ở mục 5 rồi DỪNG.

### BƯỚC 0: Rà soát nền tảng và môi trường làm việc (Chỉ đọc & báo cáo, không viết code)

**Việc cần làm:**

- Đọc toàn bộ `docs/AI-CONTEXT.md`, `docs/phan-cong.md` và file này.
- Kiểm tra các file nền tảng thật trên ổ đĩa: `DAL/DbHelper.cs`, `DAL/CustomSqlExceptionHandler.cs`, `Utils/ValidationHelper.cs`, `Utils/UiHelper.cs`, `Utils/DbParam.cs`, `Session/CurrentUser.cs`, `Utils/Theme.cs`, `GUI/Main/FormMain.cs`, `GUI/Main/FormLauncher.cs`.
- Kiểm tra các file TV3 đã push xem đã có: `database/03_patch_kho.sql`, `DTO/NguyenLieuDTO.cs`, `GUI/Kho/FormNguyenLieu.cs`...
- Chạy lệnh kiểm tra: `dotnet build src/QuanLyQuanCafe/QuanLyQuanCafe.csproj` và báo kết quả.

**Báo cáo:**

- Xác nhận chữ ký các hàm trong DbHelper (`ExecSP`, `ExecTableFn`, `SelectView`...).
- Xác nhận 3 form của TV4 (FormKhach, FormBaoCao, FormChiTien) đã được định cấu hình chính xác trong menu `FormMain.cs` với đúng role hiển thị.
- Xác nhận danh sách các file patch SQL hiện có trong thư mục `database/`.
- Ghi nhận bất kỳ khác biệt hoặc cảnh báo nào trước khi bắt đầu.

⛔ **DỪNG. Chờ Xác nhận Bước 0.**

---

### BƯỚC 1: Patch CSDL cho Khách hàng, Báo cáo và Chi tiền (Chỉ viết SQL)

**File tạo:** `database/03_patch_khach_baocao.sql`

**Nội dung:**

```sql
USE quanlyquancafe;
GO

-- 1. SP lấy danh sách loại khách hàng để đổ vào ComboBox
CREATE OR ALTER PROCEDURE sp_LayDanhSachLoaiKhach
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLoaiKH, TenLoaiKH, PhanTramGiam, DiemToiThieu
    FROM LoaiKhach
    ORDER BY DiemToiThieu ASC;
END
GO

-- 2. SP lấy danh sách lịch sử phiếu chi tiền
CREATE OR ALTER PROCEDURE sp_LayDanhSachPhieuChi
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pc.MaPC, pc.NgayChi, pc.SoTienChi, pc.LyDoChi,
           pc.MaNV, nv.TenNV,
           pc.MaNCC, ISNULL(ncc.TenNCC, N'(Chi phí khác)') AS TenNCC
    FROM PhieuChi pc
    LEFT JOIN NhanVien nv ON pc.MaNV = nv.MaNV
    LEFT JOIN NhaCungCap ncc ON pc.MaNCC = ncc.MaNCC
    WHERE (@TuNgay IS NULL OR CAST(pc.NgayChi AS DATE) >= @TuNgay)
      AND (@DenNgay IS NULL OR CAST(pc.NgayChi AS DATE) <= @DenNgay)
    ORDER BY pc.NgayChi DESC;
END
GO

-- 3. Phân quyền thực thi và truy vấn cho Phục vụ và Kế toán
-- Phục vụ cần nạp loại khách
GRANT EXECUTE ON sp_LayDanhSachLoaiKhach TO PhucVu;

-- Kế toán cần các chức năng chi tiền và báo cáo
GRANT EXECUTE ON sp_LayDanhSachPhieuChi   TO KeToan;
GRANT EXECUTE ON sp_LayDanhSachNCC        TO KeToan;
GRANT EXECUTE ON sp_ThongKeDoanhThu       TO KeToan;
GRANT SELECT ON fn_MonBanChayNhat         TO KeToan;
GRANT SELECT ON v_DoanhThuTheoNgay        TO KeToan;
GRANT SELECT ON v_MonBanChay              TO KeToan;
GRANT SELECT ON v_HoaDon                  TO KeToan;
GO

/* =========================================================================
   CÂU LỆNH KIỂM TRA CHO NGƯỜI DÙNG CHẠY TRONG SSMS:
   =========================================================================
   EXEC sp_LayDanhSachLoaiKhach;
   EXEC sp_LayDanhSachPhieuChi '2026-01-01', '2026-12-31';

   -- Kiểm tra quyền Kế toán:
   EXECUTE AS LOGIN = 'login_ketoan';
   EXEC sp_LayDanhSachPhieuChi;
   EXEC sp_ThongKeDoanhThu '2026-01-01', '2026-12-31';
   SELECT TOP 5 * FROM v_HoaDon;
   REVERT;

   -- Kiểm tra quyền Phục vụ:
   EXECUTE AS LOGIN = 'login_phucvu';
   EXEC sp_LayDanhSachLoaiKhach;
   EXEC sp_TimKiemKhach '';
   REVERT;
*/
```

**Người dùng tự làm:** Chạy file trên trong SSMS bằng tài khoản `sa` hoặc Windows Authentication.

**Commit gợi ý:**

```bash
git add database/03_patch_khach_baocao.sql
git commit -m "feat(sql): thêm patch CSDL cho module khách hàng, báo cáo và chi tiền"
```

⛔ **DỪNG. Chờ Xác nhận Bước 1.**

---

### BƯỚC 2: Khách hàng — DTO + DAL + BLL (Chưa có GUI)

**File tạo:**

- `DTO/KhachDTO.cs`
- `DTO/LoaiKhachDTO.cs`
- `DTO/LichSuMuaHangDTO.cs`
- `DAL/KhachDAL.cs`
- `BLL/KhachBLL.cs`

**Yêu cầu:**

**KhachDTO:**

- Thuộc tính: `MaKH` (string), `TenKH` (string), `SoDienThoai` (string), `DiemTichLuy` (int), `MaLoaiKH` (string), `TenLoaiKH` (string), `PhanTramGiam` (decimal).
- Thuộc tính phụ chỉ đọc: `string HienThiChietKhau => $"{TenLoaiKH} (Giảm {PhanTramGiam:N0}%)";`.

**LoaiKhachDTO:**

- Thuộc tính: `MaLoaiKH` (string), `TenLoaiKH` (string), `PhanTramGiam` (decimal), `DiemToiThieu` (int).
- `ToString()` trả về: `$"{TenLoaiKH} - Giảm {PhanTramGiam:N0}% ({DiemToiThieu} điểm)"` để hiển thị trong ComboBox.

**LichSuMuaHangDTO:**

- Thuộc tính: `MaHD` (string), `NgayTao` (DateTime), `TongTienThanhToan` (decimal), `PhuongThucThanhToan` (string), `TenNV` (string), `TrangThai` (string).

**KhachDAL:**

- `List<KhachDTO> TimKiem(string tuKhoa)`: Gọi `sp_TimKiemKhach`. Quan trọng: Nếu `tuKhoa` null hoặc rỗng, truyền chuỗi `""` vào `@TuKhoa` để lấy toàn bộ danh sách khách.
- `List<LoaiKhachDTO> LayDanhSachLoaiKhach()`: Gọi `sp_LayDanhSachLoaiKhach`.
- `List<KhachDTO> LayDanhSachKhachThanThiet()`: Gọi `DbHelper.SelectView("v_KhachHangThanThiet")`.
- `string Them(KhachDTO kh)`: Gọi `sp_ThemKhachHang` với `@TenKH`, `@SoDienThoai`, `@MaLoaiKH`. Đọc và trả về mã mới `MaKH` từ cột kết quả của DataTable.
- `void Sua(KhachDTO kh)`: Gọi `sp_SuaKhach` với `@MaKH`, `@TenKH`, `@SoDienThoai`, `@MaLoaiKH`.
- `void Xoa(string maKH)`: Gọi `sp_XoaKhach` với `@MaKH` (Chỉ Quản lý chạy được).
- `List<LichSuMuaHangDTO> LayLichSuMuaHang(string maKH)`: Gọi `DbHelper.ExecTableFn("fn_LichSuMuaHang", new SqlParameter("@MaKH", maKH))`.

**KhachBLL:**

- `LayDanhSach()`: Gọi `KhachDAL.TimKiem("")`.
- `TimKiem(string tuKhoa)`: Gọi `KhachDAL.TimKiem(tuKhoa?.Trim() ?? "")`.
- `LayDanhSachLoaiKhach()`, `LayDanhSachKhachThanThiet()`, `LayLichSuMuaHang(string maKH)`.
- `Them(KhachDTO kh)`:
  - `ValidationHelper.BatBuocNhap(kh.TenKH, "Tên khách hàng")`.
  - `ValidationHelper.BatBuocSdt(kh.SoDienThoai)`.
  - `ValidationHelper.BatBuocNhap(kh.MaLoaiKH, "Loại khách hàng")`.
  - Kiểm tra trùng SĐT với danh sách hiện có (Báo "Số điện thoại này đã được đăng ký cho khách hàng khác.").
  - Gọi DAL và trả về `MaKH` mới tạo.
- `Sua(KhachDTO kh)`:
  - `ValidationHelper.BatBuocNhap(kh.MaKH, "Mã khách hàng")`.
  - Kiểm tra hợp lệ Tên, SĐT, Loại khách như trên.
  - Kiểm tra trùng SĐT với khách hàng khác (trừ chính khách này).
  - Gọi DAL.
- `Xoa(string maKH)`:
  - `ValidationHelper.BatBuocNhap(maKH, "Mã khách hàng")`.
  - Kiểm tra vai trò: Nếu `CurrentUser.ChucVu != "Quản lý"`, ném `InvalidOperationException("Chỉ Quản lý mới có quyền xóa khách hàng.")`.
  - Gọi DAL (SP ném lỗi tiếng Việt nếu khách đã có hóa đơn).

**Kiểm tra:** `dotnet build` 0 Error.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/DTO/KhachDTO.cs src/QuanLyQuanCafe/DTO/LoaiKhachDTO.cs src/QuanLyQuanCafe/DTO/LichSuMuaHangDTO.cs src/QuanLyQuanCafe/DAL/KhachDAL.cs src/QuanLyQuanCafe/BLL/KhachBLL.cs
git commit -m "feat(khach): thêm DTO, DAL, BLL cho quản lý khách hàng và lịch sử mua"
```

⛔ **DỪNG. Chờ Xác nhận Bước 2.**

---

### BƯỚC 3: FormKhach — Quản lý khách hàng & lịch sử mua hàng

**File tạo:** `GUI/Khach/FormKhach.cs`, `GUI/Khach/FormKhach.Designer.cs`

**Yêu cầu:**

Namespace: `QuanLyQuanCafe.GUI.Khach`, lớp `FormKhach`, constructor public không tham số.

**Bố cục giao diện (SplitContainer hoặc 2 cột trái - phải):**

*Cột trái (Danh sách khách hàng):*

- Tiêu đề trang: "Quản lý khách hàng".
- `txtTimKiem`: Ô tìm kiếm (lọc theo tên hoặc SĐT; sự kiện `TextChanged` lọc trong danh sách bộ nhớ hoặc Enter gọi BLL).
- `chkChiKhachThanThiet`: CheckBox "Chỉ khách thân thiết (có điểm thưởng)".
- Lưới `dgvKhach`: Cột Mã KH, Họ tên, Số điện thoại, Điểm tích lũy (căn phải, định dạng N0), Hạng thành viên, Chiết khấu. `ReadOnly = true`.

*Cột phải (Thông tin & Lịch sử mua hàng):*

- GroupBox / Card Thông tin khách: `txtMaKH` (ReadOnly, hiển thị mã tự sinh hoặc "(Tự sinh khi thêm)"), `txtTenKH`, `txtSoDienThoai`, `cboLoaiKhach` (DropDownList, nạp từ `LayDanhSachLoaiKhach()`), `lblDiemTichLuy` (chỉ xem), `lblHangHienTai` (Card nổi bật hiển thị chiết khấu).
- Hàng nút thao tác: `btnLamMoi`, `btnThem`, `btnSua`, `btnXoa`.
- Phân quyền nút Xóa: Trong sự kiện `Form_Load`, kiểm tra nếu `CurrentUser.ChucVu != "Quản lý"` thì ẩn hoặc khóa nút `btnXoa` (`btnXoa.Visible = false` hoặc `btnXoa.Enabled = false`).
- GroupBox / Card Lịch sử mua hàng: Lưới `dgvLichSuMua` hiển thị lịch sử mua hàng của khách đang chọn (Mã HĐ, Ngày tạo, Tổng thanh toán định dạng N0, Phương thức, Nhân viên lập, Trạng thái). Nếu khách chưa có đơn thì lưới trống.

**Tương tác:**

- Bấm chọn dòng trong `dgvKhach`: Đổ dữ liệu vào các ô nhập, tải danh sách lịch sử mua hàng tương ứng của khách đó.
- Thêm / Sửa / Xóa thành công: Dùng `UiHelper.ShowInfo` thông báo, nạp lại dữ liệu.
- Xóa khách: Có hộp thoại hỏi xác nhận `UiHelper.Confirm("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa")`.
- Bắt lỗi qua `UiHelper.HienLoi(ex)`.

**Kiểm tra (Người dùng tự chạy thử):**

- [ ] Đăng nhập tài khoản Phục vụ `0901000002`: Menu Khách hàng mở được FormKhach, nút Xóa bị ẩn/khóa đúng yêu cầu. Lưới hiện đủ 5 khách mẫu KH01..KH05.
- [ ] Tìm kiếm theo SĐT hoặc tên hoạt động mượt mà.
- [ ] Bấm vào khách KH01: Lưới lịch sử mua hàng hiện danh sách các hóa đơn của khách này.
- [ ] Thêm khách mới "Trần Văn Test", SĐT "0988776655", hạng Đồng: Lưu thành công, mã KH... tự sinh tăng dần.
- [ ] Nhập SĐT sai định dạng (chữ, thiếu số): Báo lỗi tiếng Việt dễ hiểu.
- [ ] Đăng xuất và đăng nhập Quản lý `0901000001`: Mở FormKhach, thấy nút Xóa hiển thị và hoạt động. Thử xóa khách vừa tạo thành công; thử xóa khách cũ đã có hóa đơn thì báo lỗi nghiệp vụ từ SP.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/GUI/Khach/FormKhach.cs src/QuanLyQuanCafe/GUI/Khach/FormKhach.Designer.cs
git commit -m "feat(khach): hoàn thành FormKhach quản lý khách hàng và phân quyền xóa"
```

⛔ **DỪNG. Chờ Xác nhận Bước 3.**

---

### BƯỚC 4: Chi tiền nhà cung cấp — DTO + DAL + BLL (Chưa có GUI)

**File tạo:**

- `DTO/PhieuChiDTO.cs`
- `DTO/NhaCungCapLookupDTO.cs`
- `DAL/PhieuChiDAL.cs`
- `BLL/PhieuChiBLL.cs`

**Yêu cầu:**

**NhaCungCapLookupDTO:**

- Thuộc tính: `MaNCC` (string), `TenNCC` (string), `SoDienThoai` (string?).
- `ToString()` trả về: `$"{TenNCC} ({MaNCC})"` để đổ ComboBox chọn NCC.

**PhieuChiDTO:**

- Thuộc tính: `MaPC` (string), `NgayChi` (DateTime), `SoTienChi` (decimal), `LyDoChi` (string), `MaNV` (string), `TenNV` (string), `MaNCC` (string?), `TenNCC` (string).

**PhieuChiDAL:**

- `List<NhaCungCapLookupDTO> LayDanhSachNCC()`: Gọi `sp_LayDanhSachNCC`. Ánh xạ sang `NhaCungCapLookupDTO`.
- `string ChiTienNCC(decimal soTien, string lyDo, string maNV, string? maNCC)`:
  - Gọi `sp_ChiTienNCC` với `@SoTienChi = soTien`, `@LyDoChi = lyDo`, `@MaNV = maNV`, `@MaNCC = DbParam.Tao("@MaNCC", maNCC)`.
  - Đọc và trả về mã mới `MaPC` từ cột kết quả DataTable.
- `List<PhieuChiDTO> LayDanhSachPhieuChi(DateTime? tuNgay, DateTime? denNgay)`:
  - Gọi `sp_LayDanhSachPhieuChi` với tham số `@TuNgay = DbParam.Tao(...)`, `@DenNgay = DbParam.Tao(...)`.
  - Ánh xạ sang danh sách `PhieuChiDTO`.

**PhieuChiBLL:**

- `LayDanhSachNCC()`: Gọi DAL, thêm tùy chọn đầu tiên là `MaNCC = null`, `TenNCC = "(Chi phí vận hành / Không theo NCC)"` để linh hoạt lập phiếu chi.
- `LapPhieuChi(decimal soTien, string lyDo, string? maNCC)`:
  - `ValidationHelper.BatBuocSoDuong(soTien, "Số tiền chi")`.
  - `ValidationHelper.BatBuocNhap(lyDo, "Lý do chi")`.
  - Lấy `maNV = CurrentUser.MaNV`. Nếu chưa đăng nhập, ném `InvalidOperationException("Phiên làm việc hết hạn.")`.
  - Gọi `PhieuChiDAL.ChiTienNCC(...)` và trả về `MaPC` vừa sinh.
- `LayLichSuChiTien(DateTime tuNgay, DateTime denNgay)`:
  - `ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay)`.
  - Gọi DAL với `tuNgay.Date` và `denNgay.Date`.

**Kiểm tra:** `dotnet build` 0 Error.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/DTO/PhieuChiDTO.cs src/QuanLyQuanCafe/DTO/NhaCungCapLookupDTO.cs src/QuanLyQuanCafe/DAL/PhieuChiDAL.cs src/QuanLyQuanCafe/BLL/PhieuChiBLL.cs
git commit -m "feat(chi-tien): thêm DTO, DAL, BLL cho lập phiếu chi và lịch sử chi tiền"
```

⛔ **DỪNG. Chờ Xác nhận Bước 4.**

---

### BƯỚC 5: FormChiTien — Chi tiền nhà cung cấp & lịch sử chi

**File tạo:** `GUI/BaoCao/FormChiTien.cs`, `GUI/BaoCao/FormChiTien.Designer.cs`

**Yêu cầu:**

Namespace: `QuanLyQuanCafe.GUI.BaoCao`, lớp `FormChiTien`, constructor public không tham số.

**Bố cục giao diện (2 phần hoặc 2 Tab):**

*Tab/Panel 1: "Lập phiếu chi tiền":*

- `lblNguoiLap`: Hiển thị Họ tên nhân viên (Mã NV) lấy từ `CurrentUser` (ReadOnly).
- `cboNhaCungCap`: DropDownList danh sách nhà cung cấp (có lựa chọn chi ngoài).
- `numSoTienChi`: Ô nhập số tiền (NumericUpDown, `ThousandsSeparator = true`, tối thiểu 1.000đ, bước nhảy 10.000đ, căn phải).
- `txtLyDoChi`: TextBox nhập nội dung lý do chi (hỗ trợ nhiều dòng `Multiline = true`).
- Nút `btnChiTien` (Tag: `"success"`) và `btnLamMoi` (Tag: `"neutral"`).
- Khi bấm `btnChiTien`: Hỏi xác nhận số tiền `UiHelper.Confirm($"Xác nhận chi số tiền {soTien:N0} đ?", "Xác nhận chi tiền")`. Gọi BLL, nhận `MaPC`, thông báo thành công và xóa trắng form.

*Tab/Panel 2: "Lịch sử chi tiền":*

- Bộ lọc thời gian: `dtpTuNgay`, `dtpDenNgay` (mặc định 30 ngày gần nhất), nút `btnLoc` (Tag: `"primary"`).
- Lưới `dgvPhieuChi`: Mã phiếu chi, Ngày chi (định dạng `dd/MM/yyyy HH:mm`), Số tiền (căn phải, định dạng N0), Lý do chi, Nhà cung cấp, Người chi.
- Card tổng kết dưới lưới: `lblTongTienChi` hiển thị "Tổng số tiền đã chi: XX,XXX,XXX đ" (tính tổng từ lưới).

Kiểm tra phân quyền mở form: Menu này chỉ Kế toán và Quản lý thấy. Phục vụ / Thủ kho không thấy.

**Kiểm tra (Người dùng tự chạy thử):**

- [ ] Đăng nhập Kế toán `0901000006`: Mở menu Báo cáo -> Chi tiền nhà cung cấp.
- [ ] DropDownList Nhà cung cấp nạp đủ các NCC mẫu (NCC01..NCC05) và mục chi ngoài.
- [ ] Lập phiếu chi 5.000.000đ cho NCC01 với lý do "Thanh toán đợt 1 tiền cà phê hạt": Lưu thành công, sinh mã PC... tự động.
- [ ] Chuyển sang phần Lịch sử: Lọc thấy phiếu chi vừa tạo xuất hiện ngay đầu danh sách, tổng tiền chi cộng dồn chính xác.
- [ ] Nhập số tiền 0 đồng hoặc để trống lý do: Báo lỗi tiếng Việt, không tạo phiếu.
- [ ] Đăng nhập Phục vụ: Kiểm tra menu Báo cáo hoàn toàn bị ẩn.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/GUI/BaoCao/FormChiTien.cs src/QuanLyQuanCafe/GUI/BaoCao/FormChiTien.Designer.cs
git commit -m "feat(chi-tien): hoàn thành FormChiTien lập phiếu chi và tra cứu lịch sử"
```

⛔ **DỪNG. Chờ Xác nhận Bước 5.**

---

### BƯỚC 6: Báo cáo & Thống kê — DTO + DAL + BLL (Chưa có GUI)

**File tạo:**

- `DTO/DoanhThuNgayDTO.cs`
- `DTO/MonBanChayDTO.cs`
- `DTO/HoaDonBaoCaoDTO.cs`
- `DAL/BaoCaoDAL.cs`
- `BLL/BaoCaoBLL.cs`

**Yêu cầu:**

**DoanhThuNgayDTO:**

- Thuộc tính: `Ngay` (DateTime), `SoHoaDon` (int), `TongDoanhThu` (decimal).

**MonBanChayDTO:**

- Thuộc tính: `MaThucUong` (string), `TenThucUong` (string), `SoLuongBan` (decimal/int), `TongDoanhThu` (decimal).

**HoaDonBaoCaoDTO:**

- Thuộc tính: `MaHD` (string), `NgayTao` (DateTime), `TenBan` (string), `TenNV` (string), `TenKH` (string), `TongTienHang` (decimal), `TienGiamGia` (decimal), `TongThanhToan` (decimal), `PhuongThucThanhToan` (string), `TrangThai` (string).

**BaoCaoDAL:**

- `List<DoanhThuNgayDTO> ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)`:
  - Gọi `sp_ThongKeDoanhThu` với `@TuNgay = tuNgay.Date`, `@DenNgay = denNgay.Date`.
- `List<MonBanChayDTO> ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay)`:
  - Gọi `DbHelper.ExecTableFn("fn_MonBanChayNhat", new SqlParameter("@TuNgay", tuNgay.Date), new SqlParameter("@DenNgay", denNgay.Date))`.
  - Map các cột `MaThucUong`, `TenThucUong`, `SoLuongDaBan`, `TongDoanhThu`.
- `List<MonBanChayDTO> LayTopMonBanChayToanThoiGian()`:
  - Gọi `DbHelper.SelectView("v_MonBanChay")`.
- `List<HoaDonBaoCaoDTO> LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)`:
  - Gọi `DbHelper.SelectView("v_HoaDon", "NgayTao >= @tu AND NgayTao < @den", new SqlParameter("@tu", tuNgay.Date), new SqlParameter("@den", denNgay.Date.AddDays(1)))`.

**BaoCaoBLL:**

- `ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)`:
  - `ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay)`.
  - Gọi DAL; tính thêm các chỉ số tổng hợp: `TongDoanhThu`, `TongHoaDon`, `DoanhThuTrungBinhMoiDon`.
- `ThongKeMonBanChay(DateTime tuNgay, DateTime denNgay)`:
  - `ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay)`.
  - Gọi DAL, sắp xếp theo số lượng bán giảm dần.
- `LayDanhSachHoaDon(DateTime tuNgay, DateTime denNgay)`:
  - `ValidationHelper.BatBuocKhoangNgay(tuNgay, denNgay)`.
  - Gọi DAL, sắp xếp mới nhất lên đầu.

**Kiểm tra:** `dotnet build` 0 Error.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/DTO/DoanhThuNgayDTO.cs src/QuanLyQuanCafe/DTO/MonBanChayDTO.cs src/QuanLyQuanCafe/DTO/HoaDonBaoCaoDTO.cs src/QuanLyQuanCafe/DAL/BaoCaoDAL.cs src/QuanLyQuanCafe/BLL/BaoCaoBLL.cs
git commit -m "feat(baocao): thêm DTO, DAL, BLL cho thống kê doanh thu, món bán chạy và hóa đơn"
```

⛔ **DỪNG. Chờ Xác nhận Bước 6.**

---

### BƯỚC 7: FormBaoCao — Báo cáo doanh thu & Phân tích bán hàng

**File tạo:** `GUI/BaoCao/FormBaoCao.cs`, `GUI/BaoCao/FormBaoCao.Designer.cs`

**Yêu cầu:**

Namespace: `QuanLyQuanCafe.GUI.BaoCao`, lớp `FormBaoCao`, constructor public không tham số.

**Cấu trúc TabControl gồm 3 Tab:**

*Tab 1: "Doanh thu theo thời gian":*

- Bộ lọc: `dtpTuNgay`, `dtpDenNgay` (mặc định tháng hiện tại), nút `btnThongKe` (Tag: `"primary"`).
- Hàng 3 Card tổng quan nổi bật (Panel bo góc tự vẽ theo Theme):
  - Card 1: Tổng doanh thu (`lblTongDoanhThu`, chữ lớn màu vàng NhanManh, ví dụ: 15.850.000 đ).
  - Card 2: Tổng số hóa đơn (`lblTongHoaDon`, ví dụ: 42 hóa đơn).
  - Card 3: Doanh thu trung bình đơn (`lblDoanhThuTB`, ví dụ: 377.380 đ/đơn).
- Lưới `dgvDoanhThu`: Cột Ngày (`dd/MM/yyyy`), Số lượng hóa đơn, Doanh thu trong ngày (căn phải, N0).

*Tab 2: "Món bán chạy (Top Drinks)":*

- Bộ lọc ngày kèm nút `btnLocMon`.
- Lưới `dgvMonBanChay`: Thứ hạng (STT), Mã thức uống, Tên thức uống, Số lượng bán (căn phải), Doanh thu thu được (căn phải, N0).
- Card hiển thị món có doanh thu cao nhất.

*Tab 3: "Nhật ký hóa đơn":*

- Lọc theo ngày và ô `txtTimKiemHD` (tìm theo mã HĐ, tên khách, tên bàn).
- Lưới `dgvHoaDon`: Mã HĐ, Ngày tạo, Bàn, Thu ngân, Khách hàng, Tiền hàng, Giảm giá, Tổng thanh toán (N0), Phương thức, Trạng thái.

**Tương tác:**

- Định dạng hiển thị số và tiền tệ đồng nhất trên mọi DataGridView.
- Xử lý mượt mà khi khoảng ngày không có dữ liệu (hiển thị thông báo thân thiện, đặt các tổng về 0, không throw exception).

**Kiểm tra (Người dùng tự chạy thử):**

- [ ] Đăng nhập Kế toán `0901000006`: Mở menu Báo cáo -> Báo cáo doanh thu.
- [ ] Tab Doanh thu: Chọn khoảng ngày chứa dữ liệu mẫu (ví dụ cả năm 2026), bấm Thống kê. Các Card tổng kết hiển thị chuẩn xác, lưới liệt kê chi tiết từng ngày khớp với dữ liệu mẫu trong DB.
- [ ] Tab Món bán chạy: Hiện danh sách thức uống được gọi nhiều nhất (ví dụ Cà phê đen, Cà phê sữa...), doanh thu tính đúng.
- [ ] Tab Nhật ký hóa đơn: Hiện danh sách 15 hóa đơn mẫu, lọc theo từ khóa tìm kiếm chạy mượt mà.
- [ ] Chọn TuNgay > DenNgay: Báo lỗi "Khoảng ngày không hợp lệ".
- [ ] Đăng nhập Quản lý `0901000001`: Mở được cả 2 form Báo cáo và Chi tiền bình thường.

**Commit gợi ý:**

```bash
git add src/QuanLyQuanCafe/GUI/BaoCao/FormBaoCao.cs src/QuanLyQuanCafe/GUI/BaoCao/FormBaoCao.Designer.cs
git commit -m "feat(baocao): hoàn thành FormBaoCao với 3 tab doanh thu, món bán chạy và nhật ký hóa đơn"
```

⛔ **DỪNG. Chờ Xác nhận Bước 7.**

---

### BƯỚC 8: Kiểm thử tích hợp đa quyền & Hoàn thiện tài liệu báo cáo

**Việc cần làm:**

**Kiểm tra mã nguồn toàn diện:**

- Đảm bảo tuân thủ 100% kiến trúc 3 tầng: GUI -> BLL -> DAL -> DbHelper.
- Không có câu lệnh SQL rời rạc (SELECT, INSERT...) nào viết trực tiếp trong C#.
- Các Form đều có constructor không tham số.
- Tên control và nút tuân thủ chuẩn đặt tên để Theme tự áp dụng màu sắc hài hòa.
- Chạy build kiểm tra: Chạy `dotnet build` đạt kết quả 0 Error.

**Lập ma trận kiểm thử phân quyền 4 Roles đối với phần TV4:**

| Chức năng | Phục vụ (`login_phucvu`) | Thu ngân (`login_phucvu`) | Thủ kho (`login_thukho`) | Kế toán (`login_ketoan`) | Quản lý (`login_quantri`) |
|---|---|---|---|---|---|
| FormKhach | Xem, Thêm, Sửa (Ẩn Xóa) | Xem, Thêm, Sửa (Ẩn Xóa) | ❌ Không thấy menu | ❌ Không thấy menu | Toàn quyền (Có nút Xóa) |
| FormChiTien | ❌ Không thấy menu | ❌ Không thấy menu | ❌ Không thấy menu | Toàn quyền | Toàn quyền |
| FormBaoCao | ❌ Không thấy menu | ❌ Không thấy menu | ❌ Không thấy menu | Toàn quyền | Toàn quyền |

**Tập hợp hình ảnh nghiệm thu:**

Hướng dẫn người dùng chụp ảnh màn hình các chức năng và lưu vào `docs/hinh/khach-baocao/`:

- `khach-danh-sach-va-lich-su.png`
- `khach-them-moi-thanh-cong.png`
- `chi-tien-lap-phieu.png`
- `chi-tien-lich-su.png`
- `bao-cao-doanh-thu-cards.png`
- `bao-cao-mon-ban-chay.png`

**Tổng hợp nội dung báo cáo đồ án phần Thành viên 4:**

- Liệt kê các đối tượng CSDL phụ trách: Bảng `KhachHang`, `LoaiKhach`, `PhieuChi`, `HoaDon`; SP `sp_TimKiemKhach`, `sp_ThemKhachHang`, `sp_SuaKhach`, `sp_XoaKhach`, `sp_ChiTienNCC`, `sp_ThongKeDoanhThu`; Functions `fn_LichSuMuaHang`, `fn_MonBanChayNhat`; Views `v_KhachHangThanThiet`, `v_DoanhThuTheoNgay`, `v_MonBanChay`, `v_HoaDon`.
- Làm rõ cơ chế tự sinh mã sequence (`KH...`, `PC...`) và bảo toàn toàn vẹn dữ liệu tài chính.
- Sẵn sàng hỗ trợ nhóm tổng hợp file báo cáo chung vào `docs/bao-cao/`.

**Commit gợi ý:**

```bash
git add .
git commit -m "chore(tv4): hoàn thiện toàn bộ module khách hàng, báo cáo, chi tiền và kiểm thử phân quyền"
```

⛔ **DỪNG. Chờ người dùng chỉ định tiếp.**

---

## 5. MẪU BÁO CÁO CUỐI MỖI BƯỚC (Bắt buộc)

```markdown
## KẾT QUẢ BƯỚC N: <tên bước>

**File tạo mới:** (liệt kê đường dẫn chi tiết)
**File đã sửa:** (liệt kê đường dẫn chi tiết)
**File đã xóa:** (nếu có)

**dotnet build:** <dòng tổng kết: ... Warning(s), ... Error(s)>
**Đã tự chạy thử:** <nói thật: đã chạy thử gì / CHƯA chạy được gì và lý do>

**Người dùng tự kiểm tra:** (chép lại checklist của bước, đánh dấu các mục đã đạt)

**Lệnh commit gợi ý:**
git add <đường dẫn cụ thể>
git commit -m "<thông điệp ngắn gọn, rõ ràng>"

**Lưu ý / điều chưa chắc chắn:** (nếu có)

⛔ DỪNG. Tôi chờ bạn gõ "Xác nhận Bước N" (hoặc "Sửa Bước N: ...").
```

---

## 6. Phụ lục: Xử lý sự cố thường gặp

| Triệu chứng | Nguyên nhân | Cách xử lý |
|---|---|---|
| Lấy danh sách khách hàng ra bảng trống | Truyền NULL vào `@TuKhoa` của `sp_TimKiemKhach` | Luôn truyền chuỗi rỗng `""` thay vì null khi muốn lấy tất cả khách. |
| Lỗi 229 (Permission Denied) khi Kế toán mở Chi tiền hoặc Báo cáo | Chưa chạy file `03_patch_khach_baocao.sql` trên DB | Chạy file patch bằng quyền Windows Authentication / `sa` trong SSMS. |
| Phục vụ bấm nút Xóa khách bị crash hoặc báo lỗi 229 | Nút Xóa chưa bị ẩn theo vai trò | Trong `FormKhach_Load`, kiểm tra `CurrentUser.ChucVu != "Quản lý"` thì ẩn `btnXoa`. |
| Mã khách hàng hoặc mã phiếu chi sinh ra bị trùng / rỗng | Truyền giá trị sai vào tham số `@MaKH` / `@MaPC` | Truyền NULL (hoặc không truyền) để SP tự kích hoạt Sequence sinh mã. Đọc mã từ cột kết quả của SP. |
| Số tiền chi hoặc doanh thu bị làm tròn mất số lẻ | Tham số SQL decimal thiếu thuộc tính Precision/Scale | Khai báo `SqlDbType.Decimal` với `Precision = 12`, `Scale = 2`. |
| Trùng lặp file `NhaCungCapDTO.cs` với TV3 khi gộp nhánh | Đặt trùng tên file DTO | TV4 dùng tên `NhaCungCapLookupDTO.cs` đặt trong thư mục `DTO/`. |
| Form hiển thị màu nền trắng bệch hoặc nút mất bo góc | Gán màu cứng `BackColor` hoặc gọi sai `Theme.Apply` | Xóa các thuộc tính màu gán cứng trong Form; để FormLauncher tự động gắn Theme. |
