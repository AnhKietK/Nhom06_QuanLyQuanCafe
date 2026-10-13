using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Kho
{
    public partial class FormNguyenLieu : Form
    {
        private readonly NguyenLieuBLL _bll = new();
        private List<NguyenLieuDTO> _dsNguyenLieu = new();
        private List<NguyenLieuDTO> _dsCanhBao = new();
        private List<LoaiNguyenLieuDTO> _dsLoai = new();

        public FormNguyenLieu()
        {
            InitializeComponent();
            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormNguyenLieu_Load;
        }

        private void DangKySuKien()
        {
            btnLamMoi.Click += (s, e) => LamMoi();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;

            txtTimKiem.TextChanged += (s, e) => ApDungBoLoc();
            chkChiCanhBao.CheckedChanged += (s, e) => ApDungBoLoc();

            cboLoaiNL.SelectedIndexChanged += CboLoaiNL_SelectedIndexChanged;
            dgvNguyenLieu.SelectionChanged += DgvNguyenLieu_SelectionChanged;
            dgvNguyenLieu.CellFormatting += DgvNguyenLieu_CellFormatting;
        }

        private void FormNguyenLieu_Load(object? sender, EventArgs e)
        {
            NapLoaiNguyenLieu();
            NapDanhSach();
            LamMoi();
        }

        private void NapLoaiNguyenLieu()
        {
            try
            {
                _dsLoai = _bll.LayDanhSachLoai();
                cboLoaiNL.Items.Clear();
                foreach (var loai in _dsLoai)
                {
                    cboLoaiNL.Items.Add(loai);
                }

                if (cboLoaiNL.Items.Count > 0)
                {
                    cboLoaiNL.SelectedIndex = 0;
                    CapNhatDonViTinh();
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void CboLoaiNL_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CapNhatDonViTinh();
        }

        private void CapNhatDonViTinh()
        {
            if (cboLoaiNL.SelectedItem is LoaiNguyenLieuDTO loai)
            {
                lblDonViTinh.Text = string.IsNullOrWhiteSpace(loai.DonViTinh) ? "(Chưa rõ)" : loai.DonViTinh;
            }
            else
            {
                lblDonViTinh.Text = "";
            }
        }

        private void NapDanhSach()
        {
            try
            {
                _dsNguyenLieu = _bll.LayDanhSach();
                _dsCanhBao = _bll.LayCanhBao();

                lblTongCanhBao.Text = $"Có {_dsCanhBao.Count} nguyên liệu dưới mức tối thiểu";
                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungBoLoc()
        {
            IEnumerable<NguyenLieuDTO> nguon = chkChiCanhBao.Checked ? _dsCanhBao : _dsNguyenLieu;

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                nguon = nguon.Where(nl =>
                    (nl.MaNL != null && nl.MaNL.ToLower().Contains(tuKhoa)) ||
                    (nl.TenNL != null && nl.TenNL.ToLower().Contains(tuKhoa)) ||
                    (nl.TenLoai != null && nl.TenLoai.ToLower().Contains(tuKhoa)));
            }

            var ketQua = nguon.ToList();
            dgvNguyenLieu.DataSource = null;
            dgvNguyenLieu.DataSource = ketQua;
        }

        private void DgvNguyenLieu_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNguyenLieu.Rows.Count)
            {
                if (dgvNguyenLieu.Rows[e.RowIndex].DataBoundItem is NguyenLieuDTO nl && nl.SapHet)
                {
                    e.CellStyle.ForeColor = Theme.DangerTop;
                    e.CellStyle.Font = Theme.FontNhanDam;
                }
            }
        }

        private void DgvNguyenLieu_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvNguyenLieu.CurrentRow?.DataBoundItem is NguyenLieuDTO nl)
            {
                HienThiChiTiet(nl);
            }
        }

        private void HienThiChiTiet(NguyenLieuDTO nl)
        {
            txtMaNL.Text = nl.MaNL;
            txtMaNL.ReadOnly = true;

            txtTenNL.Text = nl.TenNL;

            // Chọn loại nguyên liệu tương ứng
            int selectedIndex = -1;
            for (int i = 0; i < cboLoaiNL.Items.Count; i++)
            {
                if ((cboLoaiNL.Items[i] as LoaiNguyenLieuDTO)?.MaLoaiNL == nl.MaLoaiNL)
                {
                    selectedIndex = i;
                    break;
                }
            }
            if (selectedIndex >= 0)
                cboLoaiNL.SelectedIndex = selectedIndex;

            lblDonViTinh.Text = nl.DonViTinh;

            decimal mucToiThieu = nl.MucToiThieu;
            if (mucToiThieu < numMucToiThieu.Minimum) mucToiThieu = numMucToiThieu.Minimum;
            if (mucToiThieu > numMucToiThieu.Maximum) mucToiThieu = numMucToiThieu.Maximum;
            numMucToiThieu.Value = mucToiThieu;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void LamMoi()
        {
            txtMaNL.ReadOnly = false;
            txtMaNL.Text = _bll.GoiYMaMoi(_dsNguyenLieu);

            txtTenNL.Clear();
            if (cboLoaiNL.Items.Count > 0)
            {
                cboLoaiNL.SelectedIndex = 0;
                CapNhatDonViTinh();
            }

            numMucToiThieu.Value = 5;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenNL.Focus();
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var loai = cboLoaiNL.SelectedItem as LoaiNguyenLieuDTO;
                var nl = new NguyenLieuDTO
                {
                    MaNL = txtMaNL.Text.Trim(),
                    TenNL = txtTenNL.Text.Trim(),
                    MaLoaiNL = loai?.MaLoaiNL ?? "",
                    MucToiThieu = numMucToiThieu.Value
                };

                _bll.Them(nl);

                UiHelper.ShowInfo("Thêm nguyên liệu thành công.");
                NapDanhSach();
                LamMoi();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNL.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn nguyên liệu cần sửa từ danh sách.");
                    return;
                }

                var loai = cboLoaiNL.SelectedItem as LoaiNguyenLieuDTO;
                var nl = new NguyenLieuDTO
                {
                    MaNL = txtMaNL.Text.Trim(),
                    TenNL = txtTenNL.Text.Trim(),
                    MaLoaiNL = loai?.MaLoaiNL ?? "",
                    MucToiThieu = numMucToiThieu.Value
                };

                _bll.Sua(nl);

                UiHelper.ShowInfo("Cập nhật thông tin nguyên liệu thành công.");
                NapDanhSach();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            try
            {
                string maNL = txtMaNL.Text.Trim();
                string tenNL = txtTenNL.Text.Trim();

                if (string.IsNullOrWhiteSpace(maNL))
                {
                    UiHelper.ShowWarning("Vui lòng chọn nguyên liệu cần xóa từ danh sách.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa nguyên liệu \"{tenNL}\" ({maNL}) không?"))
                    return;

                _bll.Xoa(maNL);

                UiHelper.ShowInfo($"Đã xóa nguyên liệu \"{tenNL}\" thành công.");
                NapDanhSach();
                LamMoi();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }
    }
}

