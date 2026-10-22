using System.Text;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Net.Http;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BanHang
{
    public partial class frmThanhToan : Form
    {
        private readonly BanHangBLL _bll = new();
        private string _maHD = "";
        private string _soBan = "";
        // MANG VE: hiển thị hình thức phục vụ, không thông báo trả bàn cho đơn mang về.
        private string MoTaPhucVu => _soBan == "Mang về" ? "Mang về" : $"Bàn {(string.IsNullOrEmpty(_soBan) ? "--" : _soBan)}";
        private string? _maKH = null;

        private decimal _tienHang = 0;
        private decimal _tongCong = 0;
        private List<ChiTietHoaDonDTO> _dsChiTiet = new();
        private KhachHangDTO? _khachHang = null;
        private static readonly HttpClient QrClient = new() { Timeout = TimeSpan.FromSeconds(15) };
        private readonly PictureBox _picQR = new() { Dock = DockStyle.Left, Width = 224, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.White };
        private readonly Button _btnTaiLaiQR = new() { Dock = DockStyle.Bottom, Height = 30, Text = "Tải lại QR" };
        private CancellationTokenSource? _qrCancellation;
        private string? _qrUrl;

        public frmThanhToan() : this("", "")
        {
        }

        public frmThanhToan(string maHD, string? soBan = null, string? maKH = null)
        {
            InitializeComponent();
            pnlHeader.Name = "pnlHeader";
            pnlMain.Name = "pnlMain";
            lblTongCong.Tag = "nhanmanh";
            btnXacNhan.Tag = "success";
            btnDong.Tag = "neutral";
            ClientSize = new Size(760, 740);
            // Keep confirmation outside the scrolling receipt/payment details.
            pnlFooter.Height = 82;
            pnlFooter.AutoScroll = true;
            btnXacNhan.Left = 16;
            btnXemHoaDon.Left = 286;
            btnDong.Left = 476;
            pnlFooter.AutoScrollMinSize = new Size(610, 0);
            ScrollableFormLayout.Install(this, pnlFooter);
            grpChiTiet.Height = 180;
            foreach (Control control in tlpThanhToan.Controls)
            {
                if (control is Label label)
                {
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleLeft;
                }
                else control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            }
            Theme.Apply(this);
            var thanhToanScroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            grpThanhToan.Controls.Remove(tlpThanhToan);
            grpThanhToan.Controls.Add(thanhToanScroll);
            thanhToanScroll.Controls.Add(tlpThanhToan);
            tlpThanhToan.Dock = DockStyle.Top;
            tlpThanhToan.Height = LogicalToDeviceUnits(290);
            pnlTienNhanh.Dock = DockStyle.Fill;
            pnlQR.Dock = DockStyle.Fill;
            tlpThanhToan.SetColumn(pnlQR, 0);
            tlpThanhToan.SetColumnSpan(pnlQR, 2);
            pnlQR.Controls.Add(_picQR);
            pnlQR.Controls.Add(_btnTaiLaiQR);
            _btnTaiLaiQR.Click += async (s, e) => await TaiVietQrAsync(true);
            this.FormClosed += (s, e) =>
            {
                HuyTaiQR();
                _picQR.Image?.Dispose();
                _picQR.Image = null;
            };

            _maHD = maHD;
            _soBan = soBan ?? "";
            _maKH = maKH;

            this.KeyPreview = true;
            this.KeyDown += FrmThanhToan_KeyDown;

            KhoiTaoSuKien();
        }

        private void FrmThanhToan_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.F8)
            {
                HienThiXemTruocHoaDon();
            }
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FrmThanhToan_Load;

            numGiamGia.ValueChanged += (s, e) => CapNhatTongCongVaTienThoi();
            numTienKhachDua.ValueChanged += (s, e) => CapNhatTienThoi();

            cboPhuongThuc.SelectedIndexChanged += CboPhuongThuc_SelectedIndexChanged;

            btnTienVuaDu.Click += (s, e) => numTienKhachDua.Value = _tongCong;
            btnTien20k.Click += (s, e) => CongThemTienKhachDua(20000);
            btnTien50k.Click += (s, e) => CongThemTienKhachDua(50000);
            btnTien100k.Click += (s, e) => CongThemTienKhachDua(100000);
            btnTien200k.Click += (s, e) => CongThemTienKhachDua(200000);
            btnTien500k.Click += (s, e) => CongThemTienKhachDua(500000);

            btnXacNhan.Click += BtnXacNhan_Click;
            btnXemHoaDon.Click += (s, e) => HienThiXemTruocHoaDon();
            btnDong.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private void CongThemTienKhachDua(decimal soTien)
        {
            if (numTienKhachDua.Value == 0)
                numTienKhachDua.Value = soTien;
            else
                numTienKhachDua.Value += soTien;
        }

        private void FrmThanhToan_Load(object? sender, EventArgs e)
        {
            NapPhuongThucThanhToan();

            if (string.IsNullOrWhiteSpace(_maHD))
            {
                // Thử tìm hóa đơn đang mở đầu tiên nếu mở trực tiếp
                var dsBan = _bll.LayDanhSachBan();
                var banCoKhach = dsBan.FirstOrDefault(b => b.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase));
                if (banCoKhach != null)
                {
                    var hd = _bll.LayHoaDonDangMoTheoBan(banCoKhach.MaBan);
                    if (hd != null)
                    {
                        _maHD = hd.MaHD;
                        _soBan = banCoKhach.SoBan.ToString();
                        _maKH = hd.MaKH;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(_maHD))
            {
                lblThongTinDon.Text = "Không tìm thấy hóa đơn nào đang mở để thanh toán.";
                btnXacNhan.Enabled = false;
                btnXemHoaDon.Enabled = false;
                return;
            }

            lblThongTinDon.Text = $"Hóa đơn: {_maHD} | {MoTaPhucVu} | Thu ngân: {(string.IsNullOrEmpty(CurrentUser.TenNV) ? "Trần Thị Bình" : CurrentUser.TenNV)}";

            TaiChiTietHoaDon();
        }

        private void NapPhuongThucThanhToan()
        {
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("Tiền mặt");
            cboPhuongThuc.Items.Add("Chuyển khoản");
            cboPhuongThuc.Items.Add("Thẻ");
            cboPhuongThuc.Items.Add("Ví điện tử");
            cboPhuongThuc.SelectedIndex = 0;
        }

        private void TaiChiTietHoaDon()
        {
            try
            {
                _dsChiTiet = _bll.LayChiTietHoaDon(_maHD);
                dgvChiTietTT.DataSource = null;
                dgvChiTietTT.DataSource = _dsChiTiet;

                _tienHang = _dsChiTiet.Sum(c => c.ThanhTien);
                lblTienHang.Text = $"{_tienHang:N0} đ";

                // Tính tiền giảm giá theo khách hàng nếu có
                decimal phanTramGiam = 0;
                if (!string.IsNullOrWhiteSpace(_maKH))
                {
                    var dsKhach = _bll.TimKiemKhachHang("");
                    _khachHang = dsKhach.FirstOrDefault(k => k.MaKH == _maKH);
                    phanTramGiam = _bll.LayChietKhauTheoKhach(_maKH);
                }

                if (_khachHang != null)
                {
                    lblKhachHangInfo.Text = $"👤 Khách hàng: {_khachHang.TenKH} ({_khachHang.SoDienThoai}) | Hạng: {_khachHang.TenLoaiKH} (Chiết khấu {phanTramGiam}%)";
                }
                else
                {
                    lblKhachHangInfo.Text = "👤 Khách hàng: Khách vãng lai (Chiết khấu 0%)";
                }

                decimal tienGiam = Math.Round(_tienHang * phanTramGiam / 100m, 0);
                numGiamGia.Value = Math.Min(tienGiam, _tienHang);

                CapNhatTongCongVaTienThoi();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void CapNhatTongCongVaTienThoi()
        {
            decimal giamGia = numGiamGia.Value;
            _tongCong = Math.Max(0, _tienHang - giamGia);

            lblTongCong.Text = $"{_tongCong:N0} đ";

            // Cập nhật thông tin QR chuyển khoản
            lblQRInfo.Text = ThongTinChuyenKhoan();
            _ = TaiVietQrAsync();

            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            if (pt == "Tiền mặt")
            {
                if (numTienKhachDua.Value < _tongCong)
                {
                    numTienKhachDua.Value = _tongCong;
                }
            }

            CapNhatTienThoi();
        }

        private void CapNhatTienThoi()
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            if (pt != "Tiền mặt")
            {
                lblTienThoi.Tag = "phu";
                lblTienThoi.ForeColor = Theme.ChuPhu;
                lblTienThoi.Text = "0 đ (Điện tử)";
                return;
            }

            decimal tienKhach = numTienKhachDua.Value;
            decimal tienThoi = tienKhach - _tongCong;

            if (tienThoi >= 0)
            {
                lblTienThoi.Tag = "success";
                lblTienThoi.ForeColor = Theme.SuccessTop;
                lblTienThoi.Text = $"{tienThoi:N0} đ";
            }
            else
            {
                lblTienThoi.Tag = "danger";
                lblTienThoi.ForeColor = Theme.DangerTop;
                lblTienThoi.Text = $"Thiếu {Math.Abs(tienThoi):N0} đ";
            }
        }

        private void CboPhuongThuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            bool isTienMat = (pt == "Tiền mặt");
            bool isChuyenKhoan = (pt == "Chuyển khoản");

            numTienKhachDua.Enabled = isTienMat;
            pnlTienNhanh.Enabled = isTienMat;
            pnlQR.Visible = isChuyenKhoan;
            tlpThanhToan.RowStyles[8].Height = isChuyenKhoan ? 260 : 0;
            tlpThanhToan.Height = isChuyenKhoan ? 540 : 290;
            if (isChuyenKhoan) _ = TaiVietQrAsync();
            else
            {
                HuyTaiQR();
                _qrUrl = null;
                _picQR.Image?.Dispose();
                _picQR.Image = null;
            }

            if (!isTienMat)
            {
                numTienKhachDua.Value = _tongCong;
                lblTienThoi.Text = "0 đ (Điện tử)";
                lblTienThoi.Tag = "phu";
                lblTienThoi.ForeColor = Theme.ChuPhu;
            }
            else
            {
                CapNhatTienThoi();
            }
        }

        private string ThongTinChuyenKhoan() =>
            $"Vietcombank (VCB)\nSTK: 1050243586\nSố tiền: {_tongCong:N0} đ\nNội dung: TT {_maHD}\n\nKiểm tra tiền đã vào tài khoản trước khi xác nhận thanh toán.";

        private void HuyTaiQR()
        {
            _qrCancellation?.Cancel();
            _qrCancellation?.Dispose();
            _qrCancellation = null;
        }

        private async Task TaiVietQrAsync(bool taiLai = false)
        {
            if (cboPhuongThuc.SelectedItem?.ToString() != "Chuyển khoản" || IsDisposed) return;
            if (_tongCong <= 0 || string.IsNullOrWhiteSpace(_maHD))
            {
                HuyTaiQR();
                _qrUrl = null;
                _picQR.Image?.Dispose();
                _picQR.Image = null;
                lblQRInfo.Text = ThongTinChuyenKhoan() + "\nKhông tạo QR khi chưa có số tiền cần chuyển.";
                return;
            }

            string amount = decimal.Round(_tongCong, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture);
            string url = $"https://img.vietqr.io/image/VCB-1050243586-qr_only.png?amount={amount}&addInfo={Uri.EscapeDataString("TT " + _maHD)}";
            if (!taiLai && _qrUrl == url) return;
            HuyTaiQR();
            _qrCancellation = new CancellationTokenSource();
            var token = _qrCancellation.Token;
            _qrUrl = url;
            _picQR.Image?.Dispose();
            _picQR.Image = null;
            lblQRInfo.Text = ThongTinChuyenKhoan() + "\nĐang tải mã VietQR...";
            try
            {
                byte[] data = await QrClient.GetByteArrayAsync(url, token);
                using var stream = new MemoryStream(data);
                using var image = Image.FromStream(stream);
                if (token.IsCancellationRequested || IsDisposed) return;
                _picQR.Image = new Bitmap(image);
                lblQRInfo.Text = ThongTinChuyenKhoan();
            }
            catch (Exception ex) when (ex is HttpRequestException or OperationCanceledException or ArgumentException)
            {
                if (token.IsCancellationRequested || IsDisposed) return;
                _qrUrl = null;
                lblQRInfo.Text = ThongTinChuyenKhoan() + "\nKhông tải được QR. Kiểm tra Internet và bấm Tải lại QR.";
            }
        }

        private void BtnXacNhan_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maHD))
            {
                UiHelper.ShowWarning("Chưa có thông tin hóa đơn.");
                return;
            }

            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            if (phuongThuc == "Tiền mặt" && numTienKhachDua.Value < _tongCong)
            {
                UiHelper.ShowWarning($"Tiền khách đưa ({numTienKhachDua.Value:N0} đ) chưa đủ so với tổng thanh toán ({_tongCong:N0} đ).");
                numTienKhachDua.Focus();
                return;
            }

            decimal giamGia = numGiamGia.Value;

            try
            {
                decimal tongThanhToanThucTe = _bll.ThanhToanHoaDon(_maHD, giamGia, phuongThuc);
                decimal tienThoi = (phuongThuc == "Tiền mặt") ? (numTienKhachDua.Value - tongThanhToanThucTe) : 0;

                string thongBao = $"Thanh toán Hóa đơn {_maHD} thành công!\n" +
                                  (_soBan == "Mang về" ? "Đơn mang về đã hoàn tất.\n\n" : $"{MoTaPhucVu} đã được giải phóng về trạng thái Trống.\n\n") +
                                  $"Phương thức: {phuongThuc}\n" +
                                  $"Tổng thanh toán: {tongThanhToanThucTe:N0} đ";

                if (phuongThuc == "Tiền mặt" && tienThoi > 0)
                {
                    thongBao += $"\nTiền thối lại cho khách: {tienThoi:N0} đ";
                }

                UiHelper.ShowInfo(thongBao, "Thanh toán thành công");

                // Hỏi người dùng có muốn xem và in phiếu hóa đơn thanh toán không
                if (UiHelper.Confirm("Bạn có muốn xem và in phiếu hóa đơn thanh toán ngay không?", "In hóa đơn"))
                {
                    HienThiXemTruocHoaDon();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(ex));
            }
            catch (Exception ex)
            {
                XuLyLoi(ex);
            }
        }

        private void HienThiXemTruocHoaDon()
        {
            if (_dsChiTiet.Count == 0)
            {
                UiHelper.ShowWarning("Hóa đơn chưa có món để in.");
                return;
            }

            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            decimal giamGia = numGiamGia.Value;
            decimal tienKhachDua = numTienKhachDua.Value;
            decimal tienThoi = Math.Max(0, tienKhachDua - _tongCong);

            var sb = new StringBuilder();
            sb.AppendLine("         CAFE NHÓM 06 - COFFEE & TEA         ");
            sb.AppendLine("     01 Võ Văn Ngân, TP. Thủ Đức, TP. HCM     ");
            sb.AppendLine("             Hotline: 1900 6868              ");
            sb.AppendLine("=============================================");
            sb.AppendLine("             HÓA ĐƠN BÁN HÀNG               ");
            sb.AppendLine($"Số HĐ   : {_maHD}");
            sb.AppendLine($"Phục vụ : {MoTaPhucVu}");
            sb.AppendLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Thu ngân: {(string.IsNullOrEmpty(CurrentUser.TenNV) ? "Trần Thị Bình" : CurrentUser.TenNV)}");
            sb.AppendLine($"Khách   : {(_khachHang != null ? _khachHang.TenKH : "Khách vãng lai")}");
            if (!string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                sb.AppendLine($"Ghi chú : {txtGhiChu.Text.Trim()}");
            }
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine(string.Format("{0,-20} {1,3} {2,9} {3,10}", "Tên món", "SL", "Đơn giá", "T.Tiền"));
            sb.AppendLine("---------------------------------------------");

            foreach (var ct in _dsChiTiet)
            {
                string ten = ct.TenThucUong.Length > 20 ? ct.TenThucUong.Substring(0, 19) + "." : ct.TenThucUong;
                sb.AppendLine(string.Format("{0,-20} {1,3} {2,9:N0} {3,10:N0}", ten, ct.SoLuong, ct.DonGia, ct.ThanhTien));
            }

            sb.AppendLine("---------------------------------------------");
            sb.AppendLine($"Tiền hàng      : {_tienHang,28:N0} đ");
            sb.AppendLine($"Chiết khấu     : {giamGia,28:N0} đ");
            sb.AppendLine($"TỔNG CỘNG      : {_tongCong,28:N0} đ");
            sb.AppendLine($"Phương thức    : {phuongThuc,28}");
            if (phuongThuc == "Tiền mặt")
            {
                sb.AppendLine($"Tiền khách đưa : {tienKhachDua,28:N0} đ");
                sb.AppendLine($"Tiền thối lại  : {tienThoi,28:N0} đ");
            }
            sb.AppendLine("=============================================");
            sb.AppendLine("        CẢM ƠN QUÝ KHÁCH & HẸN GẶP LẠI!      ");
            sb.AppendLine("          Wifi: CafeNhom06 - Pass: 888888    ");

            using var frmPreview = new frmXemHoaDon("Hóa đơn thanh toán", sb.ToString());
            frmPreview.ShowDialog(this);
        }

        private void XuLyLoi(Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(sqlEx));
            }
            else if (ex.InnerException is SqlException innerSqlEx)
            {
                UiHelper.ShowWarning(CustomSqlExceptionHandler.Translate(innerSqlEx));
            }
            else if (ex is ArgumentException or InvalidOperationException)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            else
            {
                UiHelper.HienLoi(ex);
            }
        }
    }

    /// <summary>
    /// Lớp bí danh FormThanhToan để tương thích với tên cũ
    /// </summary>
    public class FormThanhToan : frmThanhToan
    {
        public FormThanhToan() : base() { }
        public FormThanhToan(string maHD, string? soBan = null, string? maKH = null) : base(maHD, soBan, maKH) { }
    }
}
