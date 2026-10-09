using Microsoft.Data.SqlClient;
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
        private string? _maKH = null;

        private decimal _tienHang = 0;
        private decimal _tongCong = 0;

        public frmThanhToan() : this("", "")
        {
        }

        public frmThanhToan(string maHD, string? soBan = null, string? maKH = null)
        {
            InitializeComponent();

            _maHD = maHD;
            _soBan = soBan ?? "";
            _maKH = maKH;

            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FrmThanhToan_Load;

            numGiamGia.ValueChanged += (s, e) => CapNhatTongCongVaTienThoi();
            numTienKhachDua.ValueChanged += (s, e) => CapNhatTienThoi();

            cboPhuongThuc.SelectedIndexChanged += CboPhuongThuc_SelectedIndexChanged;

            btnTienVuaDu.Click += (s, e) => numTienKhachDua.Value = _tongCong;
            btnTien50k.Click += (s, e) => DatTienNhanh(50000);
            btnTien100k.Click += (s, e) => DatTienNhanh(100000);
            btnTien200k.Click += (s, e) => DatTienNhanh(200000);
            btnTien500k.Click += (s, e) => DatTienNhanh(500000);

            btnXacNhan.Click += BtnXacNhan_Click;
            btnDong.Click += (s, e) => this.Close();
        }

        private void DatTienNhanh(decimal soTien)
        {
            numTienKhachDua.Value = Math.Max(soTien, numTienKhachDua.Value + soTien);
        }

        private void FrmThanhToan_Load(object? sender, EventArgs e)
        {
            NapPhuongThucThanhToan();

            if (string.IsNullOrWhiteSpace(_maHD))
            {
                lblThongTinDon.Text = "Chưa chọn hóa đơn thanh toán.";
                btnXacNhan.Enabled = false;
                return;
            }

            lblThongTinDon.Text = $"Hóa đơn: {_maHD} | Bàn: {(!string.IsNullOrEmpty(_soBan) ? _soBan : "--")} | Thu ngân: {CurrentUser.TenNV}";

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
                var dsCT = _bll.LayChiTietHoaDon(_maHD);
                dgvChiTietTT.DataSource = null;
                dgvChiTietTT.DataSource = dsCT;

                _tienHang = dsCT.Sum(c => c.ThanhTien);
                lblTienHang.Text = $"{_tienHang:N0} đ";

                // Tính tiền giảm giá theo khách hàng nếu có
                decimal phanTramGiam = 0;
                if (!string.IsNullOrWhiteSpace(_maKH))
                {
                    phanTramGiam = _bll.LayChietKhauTheoKhach(_maKH);
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

            if (numTienKhachDua.Value < _tongCong && cboPhuongThuc.SelectedItem?.ToString() == "Tiền mặt")
            {
                numTienKhachDua.Value = _tongCong;
            }

            CapNhatTienThoi();
        }

        private void CapNhatTienThoi()
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            if (pt != "Tiền mặt")
            {
                lblTienThoi.ForeColor = Color.FromArgb(100, 116, 139);
                lblTienThoi.Text = "0 đ (Điện tử)";
                return;
            }

            decimal tienKhach = numTienKhachDua.Value;
            decimal tienThoi = tienKhach - _tongCong;

            if (tienThoi >= 0)
            {
                lblTienThoi.ForeColor = Color.FromArgb(22, 163, 74);
                lblTienThoi.Text = $"{tienThoi:N0} đ";
            }
            else
            {
                lblTienThoi.ForeColor = Color.FromArgb(220, 38, 38);
                lblTienThoi.Text = $"Thiếu {Math.Abs(tienThoi):N0} đ";
            }
        }

        private void CboPhuongThuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string pt = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            bool isTienMat = (pt == "Tiền mặt");

            numTienKhachDua.Enabled = isTienMat;
            pnlTienNhanh.Enabled = isTienMat;

            if (!isTienMat)
            {
                numTienKhachDua.Value = _tongCong;
                lblTienThoi.Text = "0 đ";
            }
            else
            {
                CapNhatTienThoi();
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
                return;
            }

            decimal giamGia = numGiamGia.Value;

            try
            {
                decimal tongThanhToanThucTe = _bll.ThanhToanHoaDon(_maHD, giamGia, phuongThuc);
                decimal tienThoi = (phuongThuc == "Tiền mặt") ? (numTienKhachDua.Value - tongThanhToanThucTe) : 0;

                string thongBao = $"Thanh toán hóa đơn {_maHD} thành công!\n" +
                                  $"Phương thức: {phuongThuc}\n" +
                                  $"Tổng thanh toán: {tongThanhToanThucTe:N0} đ";

                if (phuongThuc == "Tiền mặt" && tienThoi > 0)
                {
                    thongBao += $"\nTiền thối lại cho khách: {tienThoi:N0} đ";
                }

                UiHelper.ShowInfo(thongBao, "Thanh toán thành công");

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

namespace QuanLyQuanCafe.GUI
{
    public class frmThanhToan : QuanLyQuanCafe.GUI.BanHang.frmThanhToan
    {
        public frmThanhToan() : base() { }
        public frmThanhToan(string maHD, string? soBan = null, string? maKH = null) : base(maHD, soBan, maKH) { }
    }

    public class FormThanhToan : QuanLyQuanCafe.GUI.BanHang.frmThanhToan
    {
        public FormThanhToan() : base() { }
        public FormThanhToan(string maHD, string? soBan = null, string? maKH = null) : base(maHD, soBan, maKH) { }
    }
}
