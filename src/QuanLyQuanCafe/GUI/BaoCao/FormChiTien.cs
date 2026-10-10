using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BaoCao
{
    public partial class FormChiTien : Form
    {
        private readonly PhieuChiBLL _bll = new();
        private List<NhaCungCapLookupDTO> _dsNCC = new();

        public FormChiTien()
        {
            InitializeComponent();
            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FormChiTien_Load;

            btnLamMoi.Click += (s, e) => LamMoi();
            btnChiTien.Click += BtnChiTien_Click;
            btnLoc.Click += (s, e) => NapLichSuChi();
        }

        private void FormChiTien_Load(object? sender, EventArgs e)
        {
            // Hiển thị người lập phiếu từ phiên đăng nhập
            string ten = string.IsNullOrWhiteSpace(CurrentUser.TenNV) ? "Chưa đăng nhập" : CurrentUser.TenNV;
            string ma = string.IsNullOrWhiteSpace(CurrentUser.MaNV) ? "" : $" ({CurrentUser.MaNV})";
            string chucVu = string.IsNullOrWhiteSpace(CurrentUser.ChucVu) ? "" : $" - {CurrentUser.ChucVu}";
            lblNguoiLap.Text = $"{ten}{ma}{chucVu}";

            // Thiết lập ngày mặc định (30 ngày gần nhất)
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            // Định dạng cột lưới
            colNgayChi.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colSoTienChi.DefaultCellStyle.Format = "N0";
            colSoTienChi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            NapNhaCungCap();
            NapLichSuChi();
            LamMoi();
        }

        private void NapNhaCungCap()
        {
            try
            {
                _dsNCC = _bll.LayDanhSachNCC();
                cboNhaCungCap.Items.Clear();

                foreach (var ncc in _dsNCC)
                {
                    cboNhaCungCap.Items.Add(ncc);
                }

                if (cboNhaCungCap.Items.Count > 0)
                {
                    cboNhaCungCap.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void LamMoi()
        {
            numSoTienChi.Value = 10000;
            txtLyDoChi.Clear();

            if (cboNhaCungCap.Items.Count > 0)
            {
                cboNhaCungCap.SelectedIndex = 0;
            }

            numSoTienChi.Focus();
        }

        private void BtnChiTien_Click(object? sender, EventArgs e)
        {
            try
            {
                decimal soTien = numSoTienChi.Value;
                string lyDo = txtLyDoChi.Text.Trim();

                if (string.IsNullOrWhiteSpace(lyDo))
                {
                    UiHelper.ShowWarning("Vui lòng nhập lý do chi tiền.");
                    txtLyDoChi.Focus();
                    return;
                }

                if (soTien <= 0)
                {
                    UiHelper.ShowWarning("Số tiền chi phải lớn hơn 0.");
                    numSoTienChi.Focus();
                    return;
                }

                if (!UiHelper.Confirm($"Xác nhận chi số tiền {soTien:N0} đ?", "Xác nhận chi tiền"))
                {
                    return;
                }

                var ncc = cboNhaCungCap.SelectedItem as NhaCungCapLookupDTO;
                string maPC = _bll.LapPhieuChi(soTien, lyDo, ncc?.MaNCC);

                UiHelper.ShowInfo($"Lập phiếu chi thành công! Mã phiếu chi: {maPC}");

                LamMoi();
                NapLichSuChi();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void NapLichSuChi()
        {
            try
            {
                var ds = _bll.LayLichSuChiTien(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvPhieuChi.DataSource = null;
                dgvPhieuChi.DataSource = ds;

                decimal tongTien = ds.Sum(p => p.SoTienChi);
                lblTongTienChi.Text = $"Tổng số tiền đã chi: {tongTien:N0} đ ({ds.Count} phiếu)";
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }
    }
}

