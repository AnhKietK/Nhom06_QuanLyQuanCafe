using System.ComponentModel;
using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Kho
{
    public partial class FormNhapKho : Form
    {
        private readonly PhieuNhapBLL _bll = new();
        private readonly BindingList<ChiTietPhieuNhapDTO> _dsDong = new();
        private List<NhaCungCapDTO> _dsNCC = new();
        private List<NguyenLieuDTO> _dsNL = new();

        public FormNhapKho()
        {
            InitializeComponent();
            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormNhapKho_Load;
        }

        private void DangKySuKien()
        {
            // Tab 1: Lập phiếu nhập
            cboNguyenLieu.SelectedIndexChanged += CboNguyenLieu_SelectedIndexChanged;
            btnThemDong.Click += BtnThemDong_Click;
            btnXoaDong.Click += BtnXoaDong_Click;
            btnLuuPhieu.Click += BtnLuuPhieu_Click;
            btnLamMoi.Click += BtnLamMoi_Click;

            // Tab 2: Lịch sử nhập kho
            btnLoc.Click += (s, e) => NapLichSu();
            dgvPhieuNhap.SelectionChanged += DgvPhieuNhap_SelectionChanged;
        }

        private void FormNhapKho_Load(object? sender, EventArgs e)
        {
            // Hiển thị người lập phiếu từ phiên đăng nhập
            string tenNV = string.IsNullOrWhiteSpace(CurrentUser.TenNV) ? "Chưa đăng nhập" : CurrentUser.TenNV;
            string maNV = string.IsNullOrWhiteSpace(CurrentUser.MaNV) ? "" : $" ({CurrentUser.MaNV})";
            lblNguoiNhap.Text = $"{tenNV}{maNV}";

            // Gán dữ liệu cho DataGridView dòng nhập kho
            dgvDong.DataSource = _dsDong;

            // Cài đặt ngày mặc định (30 ngày gần nhất)
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;

            // Nạp dữ liệu các ComboBox và Lịch sử
            NapDanhSachCombo();
            LamMoiPhieu();
            NapLichSu();
        }

        private void NapDanhSachCombo()
        {
            try
            {
                _dsNCC = _bll.LayDanhSachNhaCungCap();
                cboNhaCungCap.Items.Clear();
                foreach (var ncc in _dsNCC)
                {
                    cboNhaCungCap.Items.Add(ncc);
                }
                if (cboNhaCungCap.Items.Count > 0)
                    cboNhaCungCap.SelectedIndex = 0;

                _dsNL = _bll.LayDanhSachNguyenLieu();
                cboNguyenLieu.Items.Clear();
                foreach (var nl in _dsNL)
                {
                    cboNguyenLieu.Items.Add(nl);
                }
                if (cboNguyenLieu.Items.Count > 0)
                {
                    cboNguyenLieu.SelectedIndex = 0;
                    CapNhatDonViTinh();
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void CboNguyenLieu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CapNhatDonViTinh();
        }

        private void CapNhatDonViTinh()
        {
            if (cboNguyenLieu.SelectedItem is NguyenLieuDTO nl)
            {
                lblDonViTinh.Text = string.IsNullOrWhiteSpace(nl.DonViTinh) ? "(Chưa rõ)" : nl.DonViTinh;
            }
            else
            {
                lblDonViTinh.Text = "";
            }
        }

        private void BtnThemDong_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cboNguyenLieu.SelectedItem is not NguyenLieuDTO nl)
                {
                    UiHelper.ShowWarning("Vui lòng chọn nguyên liệu cần nhập.");
                    return;
                }

                decimal soLuong = numSoLuongNhap.Value;
                if (soLuong <= 0)
                {
                    UiHelper.ShowWarning("Số lượng nhập phải lớn hơn 0.");
                    numSoLuongNhap.Focus();
                    return;
                }

                decimal donGia = numDonGiaNhap.Value;
                if (donGia <= 0)
                {
                    UiHelper.ShowWarning("Đơn giá nhập phải lớn hơn 0.");
                    numDonGiaNhap.Focus();
                    return;
                }

                DateTime? hanDung = dtpHanSuDung.Checked ? dtpHanSuDung.Value.Date : null;
                if (hanDung.HasValue && hanDung.Value < DateTime.Today)
                {
                    UiHelper.ShowWarning("Hạn sử dụng không được trước ngày hôm nay.");
                    dtpHanSuDung.Focus();
                    return;
                }

                // Kiểm tra nếu nguyên liệu đã có trong phiếu
                var dongCu = _dsDong.FirstOrDefault(x => string.Equals(x.MaNL, nl.MaNL, StringComparison.OrdinalIgnoreCase));
                if (dongCu != null)
                {
                    if (UiHelper.Confirm($"Nguyên liệu \"{nl.TenNL}\" đã có trong phiếu. Bạn có muốn cộng dồn thêm {soLuong:N3} {nl.DonViTinh} không?"))
                    {
                        dongCu.SoLuongNhap += soLuong;
                        dongCu.DonGiaNhap = donGia;
                        if (hanDung.HasValue)
                            dongCu.HanSuDung = hanDung;

                        _dsDong.ResetBindings();
                        CapNhatTongTien();

                        numSoLuongNhap.Value = 1;
                        dtpHanSuDung.Checked = false;
                    }
                    return;
                }

                _dsDong.Add(new ChiTietPhieuNhapDTO
                {
                    MaNL = nl.MaNL,
                    TenNL = nl.TenNL,
                    DonViTinh = nl.DonViTinh,
                    SoLuongNhap = soLuong,
                    DonGiaNhap = donGia,
                    HanSuDung = hanDung
                });

                CapNhatTongTien();

                numSoLuongNhap.Value = 1;
                dtpHanSuDung.Checked = false;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoaDong_Click(object? sender, EventArgs e)
        {
            if (dgvDong.CurrentRow?.DataBoundItem is ChiTietPhieuNhapDTO item)
            {
                _dsDong.Remove(item);
                CapNhatTongTien();
            }
            else
            {
                UiHelper.ShowWarning("Vui lòng chọn dòng nguyên liệu cần xóa khỏi phiếu.");
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = _dsDong.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"{tong:N0} VNĐ";
        }

        private void BtnLuuPhieu_Click(object? sender, EventArgs e)
        {
            try
            {
                var ncc = cboNhaCungCap.SelectedItem as NhaCungCapDTO;
                if (ncc == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn nhà cung cấp.");
                    return;
                }

                if (_dsDong.Count == 0)
                {
                    UiHelper.ShowWarning("Phiếu nhập phải có ít nhất một nguyên liệu.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn lưu phiếu nhập kho này với tổng tiền {lblTongTien.Text}?"))
                    return;

                string? ghiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();
                string maPN = _bll.LuuPhieu(ncc.MaNCC, ghiChu, _dsDong.ToList());

                UiHelper.ShowInfo($"Đã lưu phiếu {maPN} thành công.");
                LamMoiPhieu();
                NapLichSu();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            if (_dsDong.Count > 0)
            {
                if (!UiHelper.Confirm("Phiếu đang có dòng nguyên liệu. Bạn có chắc muốn làm mới và xóa toàn bộ phiếu đang lập?"))
                    return;
            }

            LamMoiPhieu();
        }

        private void LamMoiPhieu()
        {
            _dsDong.Clear();
            CapNhatTongTien();

            if (cboNhaCungCap.Items.Count > 0)
                cboNhaCungCap.SelectedIndex = 0;

            txtGhiChu.Clear();

            if (cboNguyenLieu.Items.Count > 0)
            {
                cboNguyenLieu.SelectedIndex = 0;
                CapNhatDonViTinh();
            }

            numSoLuongNhap.Value = 1;
            numDonGiaNhap.Value = 0;
            dtpHanSuDung.Checked = false;
        }

        private void NapLichSu()
        {
            try
            {
                var ds = _bll.LayLichSu(dtpTuNgay.Value, dtpDenNgay.Value);
                dgvPhieuNhap.DataSource = null;
                dgvPhieuNhap.DataSource = ds;

                decimal tong = ds.Sum(x => x.TongTien);
                lblTongCong.Text = $"Tổng cộng: {tong:N0} VNĐ ({ds.Count} phiếu)";

                dgvChiTietPhieu.DataSource = null;
                grbChiTietPhieu.Text = "Chi tiết nguyên liệu của phiếu nhập";
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void DgvPhieuNhap_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow?.DataBoundItem is PhieuNhapDTO pn)
            {
                try
                {
                    var ct = _bll.LayChiTiet(pn.MaPN);
                    dgvChiTietPhieu.DataSource = null;
                    dgvChiTietPhieu.DataSource = ct;
                    grbChiTietPhieu.Text = $"Chi tiết phiếu nhập: {pn.MaPN} - {pn.TenNCC}";
                }
                catch (Exception ex)
                {
                    UiHelper.HienLoi(ex);
                }
            }
        }
    }
}

