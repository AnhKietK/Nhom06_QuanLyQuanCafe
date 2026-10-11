using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BaoCao
{
    public partial class FormBaoCao : Form
    {
        private readonly BaoCaoBLL _bll = new();
        private List<HoaDonBaoCaoDTO> _dsHoaDon = new();

        public FormBaoCao()
        {
            InitializeComponent();
            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FormBaoCao_Load;

            // Tab 1: Doanh thu
            btnThongKe.Click += (s, e) => TaiBaoCaoDoanhThu();

            // Tab 2: Món bán chạy
            btnLocMon.Click += (s, e) => TaiMonBanChay();
            btnTopToanThoiGian.Click += (s, e) => TaiTopMonToanThoiGian();
            dgvMonBanChay.CellFormatting += DgvMonBanChay_CellFormatting;

            // Tab 3: Hóa đơn
            btnLocHD.Click += (s, e) => TaiDanhSachHoaDon();
            txtTimKiemHD.TextChanged += (s, e) => ApDungLocHoaDon();
        }

        private void FormBaoCao_Load(object? sender, EventArgs e)
        {
            // Thiết lập khoảng ngày mặc định: từ đầu tháng hiện tại đến hôm nay
            DateTime dauThang = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime homNay = DateTime.Today;

            dtpTuNgayDT.Value = dauThang;
            dtpDenNgayDT.Value = homNay;

            dtpTuNgayMon.Value = dauThang;
            dtpDenNgayMon.Value = homNay;

            dtpTuNgayHD.Value = dauThang;
            dtpDenNgayHD.Value = homNay;

            // Định dạng cột DataGridView
            colDTNgay.DefaultCellStyle.Format = "dd/MM/yyyy";
            colDTSoHoaDon.DefaultCellStyle.Format = "N0";
            colDTSoHoaDon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDTTongDoanhThu.DefaultCellStyle.Format = "N0";
            colDTTongDoanhThu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colMonSTT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMonSoLuong.DefaultCellStyle.Format = "N0";
            colMonSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colMonDoanhThu.DefaultCellStyle.Format = "N0";
            colMonDoanhThu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colHDNgay.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colHDTienHang.DefaultCellStyle.Format = "N0";
            colHDTienHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHDGiamGia.DefaultCellStyle.Format = "N0";
            colHDGiamGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHDTongThanhToan.DefaultCellStyle.Format = "N0";
            colHDTongThanhToan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Tải dữ liệu ban đầu
            TaiBaoCaoDoanhThu();
            TaiMonBanChay();
            TaiDanhSachHoaDon();
        }

        #region Tab 1: Doanh thu theo thời gian

        private void TaiBaoCaoDoanhThu()
        {
            try
            {
                var ds = _bll.ThongKeDoanhThu(dtpTuNgayDT.Value, dtpDenNgayDT.Value);
                dgvDoanhThu.DataSource = null;
                dgvDoanhThu.DataSource = ds;

                decimal tongDoanhThu = _bll.TinhTongDoanhThu(ds);
                int tongHoaDon = _bll.TinhTongHoaDon(ds);
                decimal doanhThuTB = _bll.TinhDoanhThuTrungBinhMoiDon(ds);

                lblTongDoanhThu.Text = $"{tongDoanhThu:N0} đ";
                lblTongHoaDon.Text = $"{tongHoaDon:N0} đơn";
                lblDoanhThuTB.Text = $"{doanhThuTB:N0} đ/đơn";
            }
            catch (Exception ex)
            {
                lblTongDoanhThu.Text = "0 đ";
                lblTongHoaDon.Text = "0 đơn";
                lblDoanhThuTB.Text = "0 đ/đơn";
                UiHelper.HienLoi(ex);
            }
        }

        #endregion

        #region Tab 2: Món bán chạy

        private void TaiMonBanChay()
        {
            try
            {
                var ds = _bll.ThongKeMonBanChay(dtpTuNgayMon.Value, dtpDenNgayMon.Value);
                CapNhatLuoiMonBanChay(ds, $"Món bán chạy nhất ({dtpTuNgayMon.Value:dd/MM} - {dtpDenNgayMon.Value:dd/MM})");
            }
            catch (Exception ex)
            {
                dgvMonBanChay.DataSource = null;
                lblTopMonInfo.Text = "Không thể tải danh sách món bán chạy";
                UiHelper.HienLoi(ex);
            }
        }

        private void TaiTopMonToanThoiGian()
        {
            try
            {
                var ds = _bll.LayTopMonBanChayToanThoiGian();
                CapNhatLuoiMonBanChay(ds, "Món bán chạy nhất (Toàn thời gian)");
            }
            catch (Exception ex)
            {
                dgvMonBanChay.DataSource = null;
                lblTopMonInfo.Text = "Không thể tải danh sách món bán chạy";
                UiHelper.HienLoi(ex);
            }
        }

        private void CapNhatLuoiMonBanChay(List<MonBanChayDTO> ds, string tieuDeTop)
        {
            dgvMonBanChay.DataSource = null;
            dgvMonBanChay.DataSource = ds;

            gbTopMon.Text = tieuDeTop;
            if (ds != null && ds.Count > 0)
            {
                var top = ds[0];
                string doanhThuStr = top.TongDoanhThu > 0 ? $" | Doanh thu: {top.TongDoanhThu:N0} đ" : "";
                lblTopMonInfo.Text = $"Quán quân: {top.TenThucUong} ({top.MaThucUong}) - Đã bán {top.SoLuongBan:N0} ly{doanhThuStr}";
            }
            else
            {
                lblTopMonInfo.Text = "Không có dữ liệu món bán trong khoảng thời gian này";
            }
        }

        private void DgvMonBanChay_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == colMonSTT.Index && e.RowIndex >= 0)
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }

        #endregion

        #region Tab 3: Nhật ký hóa đơn

        private void TaiDanhSachHoaDon()
        {
            try
            {
                _dsHoaDon = _bll.LayDanhSachHoaDon(dtpTuNgayHD.Value, dtpDenNgayHD.Value);
                ApDungLocHoaDon();
            }
            catch (Exception ex)
            {
                _dsHoaDon.Clear();
                dgvHoaDon.DataSource = null;
                lblHoaDonSummary.Text = "Tổng: 0 hóa đơn - Tiền: 0 đ";
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungLocHoaDon()
        {
            IEnumerable<HoaDonBaoCaoDTO> nguon = _dsHoaDon;

            string tuKhoa = txtTimKiemHD.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                nguon = nguon.Where(h =>
                    (!string.IsNullOrEmpty(h.MaHD) && h.MaHD.ToLower().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(h.TenKH) && h.TenKH.ToLower().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(h.TenBan) && h.TenBan.ToLower().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(h.TenNV) && h.TenNV.ToLower().Contains(tuKhoa)));
            }

            var ketQua = nguon.ToList();
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = ketQua;

            decimal tongTien = ketQua.Sum(h => h.TongThanhToan);
            lblHoaDonSummary.Text = $"Tổng: {ketQua.Count:N0} hóa đơn | Doanh thu: {tongTien:N0} đ";
        }

        #endregion
    }
}

