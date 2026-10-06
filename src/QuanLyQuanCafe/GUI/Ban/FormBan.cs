using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Ban
{
    public partial class FormBan : Form
    {
        private readonly BanBLL _bll = new();
        private List<BanDTO> _dsBan = new();
        private List<ViTriBanDTO> _dsViTri = new();

        private class ViTriComboItem
        {
            public string MaViTri { get; set; } = "";
            public string TenViTri { get; set; } = "";
            public override string ToString() => $"{TenViTri} ({MaViTri})";
        }

        public FormBan()
        {
            InitializeComponent();

            Theme.Apply(this);

            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void FormBan_Load(object? sender, EventArgs e)
        {
            NapDanhSachViTri();
            NapDanhSachBan();
            LamMoiBan();
            LamMoiViTri();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormBan_Load;
        }

        private void DangKySuKien()
        {
            // Sự kiện Tab Bàn
            btnLamMoiBan.Click += (s, e) => LamMoiBan();
            btnThemBan.Click += BtnThemBan_Click;
            btnSuaBan.Click += BtnSuaBan_Click;
            btnXoaBan.Click += BtnXoaBan_Click;
            dgvBan.SelectionChanged += DgvBan_SelectionChanged;
            dgvBan.CellFormatting += DgvBan_CellFormatting;

            // Sự kiện Tab Khu vực
            btnLamMoiViTri.Click += (s, e) => LamMoiViTri();
            btnThemViTri.Click += BtnThemViTri_Click;
            btnSuaViTri.Click += BtnSuaViTri_Click;
            btnXoaViTri.Click += BtnXoaViTri_Click;
            dgvViTri.SelectionChanged += DgvViTri_SelectionChanged;
        }

        #region Xử lý Tab Bàn

        private void NapDanhSachBan()
        {
            try
            {
                _dsBan = _bll.LayDanhSachBan();
                dgvBan.DataSource = null;
                dgvBan.DataSource = _dsBan;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void DgvBan_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBan.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string tt = e.Value.ToString()?.Trim() ?? "";
                Color bg = tt.ToUpperInvariant() switch
                {
                    "TRONG" => Theme.BanTrong,
                    "COKHACH" => Theme.BanCoKhach,
                    "DATTRUOC" => Theme.BanDatTruoc,
                    _ => Theme.The
                };

                e.CellStyle.BackColor = bg;
                e.CellStyle.ForeColor = Theme.Chu;
                e.CellStyle.SelectionBackColor = bg;
                e.CellStyle.SelectionForeColor = Theme.Chu;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = Theme.FontNhanDam;
            }
        }

        private void DgvBan_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBan.CurrentRow?.DataBoundItem is BanDTO ban)
            {
                HienThiChiTietBan(ban);
            }
        }

        private void HienThiChiTietBan(BanDTO ban)
        {
            txtMaBan.Text = ban.MaBan;
            txtMaBan.ReadOnly = true;

            numSoBan.Value = Math.Clamp(ban.SoBan, numSoBan.Minimum, numSoBan.Maximum);
            numSoChoNgoi.Value = Math.Clamp(ban.SoChoNgoi, numSoChoNgoi.Minimum, numSoChoNgoi.Maximum);

            // Chọn khu vực
            int selectedIdx = -1;
            for (int i = 0; i < cboViTri.Items.Count; i++)
            {
                if ((cboViTri.Items[i] as ViTriComboItem)?.MaViTri == ban.MaViTri)
                {
                    selectedIdx = i;
                    break;
                }
            }
            cboViTri.SelectedIndex = selectedIdx;

            // Hiển thị trạng thái (chỉ xem)
            CapNhatNhanTrangThai(ban.TrangThai);

            btnThemBan.Enabled = false;
            btnSuaBan.Enabled = true;
            btnXoaBan.Enabled = true;
        }

        private void CapNhatNhanTrangThai(string trangThai)
        {
            lblHienTrangThai.Text = trangThai;
            lblHienTrangThai.Font = Theme.FontNhanDam;
            if (string.Equals(trangThai, "TRONG", StringComparison.OrdinalIgnoreCase))
            {
                lblHienTrangThai.ForeColor = Theme.BanTrong;
            }
            else if (string.Equals(trangThai, "COKHACH", StringComparison.OrdinalIgnoreCase))
            {
                lblHienTrangThai.ForeColor = Theme.BanCoKhach;
            }
            else if (string.Equals(trangThai, "DATTRUOC", StringComparison.OrdinalIgnoreCase))
            {
                lblHienTrangThai.ForeColor = Theme.BanDatTruoc;
            }
            else
            {
                lblHienTrangThai.ForeColor = Theme.Chu;
            }
        }

        private void LamMoiBan()
        {
            txtMaBan.ReadOnly = false;
            txtMaBan.Text = _bll.GoiYMaBan(_dsBan);

            int maxSoBan = _dsBan.Count > 0 ? _dsBan.Max(b => b.SoBan) + 1 : 1;
            numSoBan.Value = Math.Clamp(maxSoBan, numSoBan.Minimum, numSoBan.Maximum);
            numSoChoNgoi.Value = 4;

            if (cboViTri.Items.Count > 0 && cboViTri.SelectedIndex < 0)
            {
                cboViTri.SelectedIndex = 0;
            }

            CapNhatNhanTrangThai("TRONG");

            btnThemBan.Enabled = true;
            btnSuaBan.Enabled = false;
            btnXoaBan.Enabled = false;

            txtMaBan.Focus();
        }

        private void BtnThemBan_Click(object? sender, EventArgs e)
        {
            try
            {
                var viTriChon = cboViTri.SelectedItem as ViTriComboItem;
                if (viTriChon == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn khu vực cho bàn.");
                    return;
                }

                var ban = new BanDTO
                {
                    MaBan = txtMaBan.Text.Trim(),
                    SoBan = (int)numSoBan.Value,
                    SoChoNgoi = (int)numSoChoNgoi.Value,
                    MaViTri = viTriChon.MaViTri,
                    TrangThai = "TRONG"
                };

                _bll.ThemBan(ban);

                UiHelper.ShowInfo($"Thêm bàn {ban.MaBan} thành công.");
                NapDanhSachBan();
                LamMoiBan();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnSuaBan_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaBan.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn bàn cần sửa từ danh sách.");
                    return;
                }

                var viTriChon = cboViTri.SelectedItem as ViTriComboItem;
                if (viTriChon == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn khu vực cho bàn.");
                    return;
                }

                var ban = new BanDTO
                {
                    MaBan = txtMaBan.Text.Trim(),
                    SoBan = (int)numSoBan.Value,
                    SoChoNgoi = (int)numSoChoNgoi.Value,
                    MaViTri = viTriChon.MaViTri
                };

                _bll.SuaBan(ban);

                UiHelper.ShowInfo($"Cập nhật thông tin bàn {ban.MaBan} thành công.");
                NapDanhSachBan();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoaBan_Click(object? sender, EventArgs e)
        {
            try
            {
                string maBan = txtMaBan.Text.Trim();
                if (string.IsNullOrWhiteSpace(maBan))
                {
                    UiHelper.ShowWarning("Vui lòng chọn bàn cần xóa từ danh sách.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa bàn {maBan} không?"))
                {
                    return;
                }

                _bll.XoaBan(maBan);

                UiHelper.ShowInfo($"Xóa bàn {maBan} thành công.");
                NapDanhSachBan();
                LamMoiBan();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        #endregion

        #region Xử lý Tab Khu vực

        private void NapDanhSachViTri()
        {
            try
            {
                string? selectedMaVT = (cboViTri.SelectedItem as ViTriComboItem)?.MaViTri;

                _dsViTri = _bll.LayDanhSachViTri();
                dgvViTri.DataSource = null;
                dgvViTri.DataSource = _dsViTri;

                // Nạp lại cboViTri ở Tab Bàn
                cboViTri.Items.Clear();
                int reSelectIdx = -1;
                for (int i = 0; i < _dsViTri.Count; i++)
                {
                    var vt = _dsViTri[i];
                    cboViTri.Items.Add(new ViTriComboItem
                    {
                        MaViTri = vt.MaViTri,
                        TenViTri = vt.TenViTri
                    });

                    if (vt.MaViTri == selectedMaVT)
                    {
                        reSelectIdx = i;
                    }
                }

                if (reSelectIdx >= 0)
                {
                    cboViTri.SelectedIndex = reSelectIdx;
                }
                else if (cboViTri.Items.Count > 0)
                {
                    cboViTri.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void DgvViTri_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvViTri.CurrentRow?.DataBoundItem is ViTriBanDTO vt)
            {
                HienThiChiTietViTri(vt);
            }
        }

        private void HienThiChiTietViTri(ViTriBanDTO vt)
        {
            txtMaViTri.Text = vt.MaViTri;
            txtMaViTri.ReadOnly = true;

            txtTenViTri.Text = vt.TenViTri;
            txtMoTa.Text = vt.MoTa ?? "";

            btnThemViTri.Enabled = false;
            btnSuaViTri.Enabled = true;
            btnXoaViTri.Enabled = true;
        }

        private void LamMoiViTri()
        {
            txtMaViTri.ReadOnly = false;
            txtMaViTri.Text = _bll.GoiYMaViTri(_dsViTri);

            txtTenViTri.Clear();
            txtMoTa.Clear();

            btnThemViTri.Enabled = true;
            btnSuaViTri.Enabled = false;
            btnXoaViTri.Enabled = false;

            txtTenViTri.Focus();
        }

        private void BtnThemViTri_Click(object? sender, EventArgs e)
        {
            try
            {
                var vt = new ViTriBanDTO
                {
                    MaViTri = txtMaViTri.Text.Trim(),
                    TenViTri = txtTenViTri.Text.Trim(),
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
                };

                _bll.ThemViTri(vt);

                UiHelper.ShowInfo($"Thêm khu vực {vt.TenViTri} ({vt.MaViTri}) thành công.");
                NapDanhSachViTri();
                LamMoiViTri();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnSuaViTri_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaViTri.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn khu vực cần sửa từ danh sách.");
                    return;
                }

                var vt = new ViTriBanDTO
                {
                    MaViTri = txtMaViTri.Text.Trim(),
                    TenViTri = txtTenViTri.Text.Trim(),
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
                };

                _bll.SuaViTri(vt);

                UiHelper.ShowInfo($"Cập nhật thông tin khu vực {vt.TenViTri} thành công.");
                NapDanhSachViTri();
                // Nạp lại danh sách bàn vì tên khu vực có thể đã thay đổi
                NapDanhSachBan();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoaViTri_Click(object? sender, EventArgs e)
        {
            try
            {
                string maViTri = txtMaViTri.Text.Trim();
                if (string.IsNullOrWhiteSpace(maViTri))
                {
                    UiHelper.ShowWarning("Vui lòng chọn khu vực cần xóa từ danh sách.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa khu vực {maViTri} không?"))
                {
                    return;
                }

                _bll.XoaViTri(maViTri);

                UiHelper.ShowInfo($"Xóa khu vực {maViTri} thành công.");
                NapDanhSachViTri();
                LamMoiViTri();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        #endregion
    }
}

