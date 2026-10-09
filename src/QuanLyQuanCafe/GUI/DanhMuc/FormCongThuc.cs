using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.DanhMuc
{
    public partial class FormCongThuc : Form
    {
        private readonly CongThucBLL _bll = new();
        private List<ThucUongQuanLyDTO> _dsThucUong = new();
        private List<LoaiThucUongDTO> _dsLoaiTU = new();
        private List<NguyenLieuDTO> _dsNguyenLieu = new();
        private List<CongThucDTO> _dsCongThuc = new();
        private ThucUongQuanLyDTO? _monDangChon;

        private class LoaiComboItem
        {
            public string? MaLoai { get; set; }
            public string TenLoai { get; set; } = "";
            public override string ToString() => TenLoai;
        }

        public FormCongThuc()
        {
            InitializeComponent();
            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormCongThuc_Load;
        }

        private void DangKySuKien()
        {
            cboLoaiThucUong.SelectedIndexChanged += (s, e) => ApDungBoLocThucUong();
            txtTimKiem.TextChanged += (s, e) => ApDungBoLocThucUong();
            dgvThucUong.SelectionChanged += DgvThucUong_SelectionChanged;

            cboNguyenLieu.SelectedIndexChanged += CboNguyenLieu_SelectedIndexChanged;
            dgvCongThuc.SelectionChanged += DgvCongThuc_SelectionChanged;

            btnLuuDong.Click += BtnLuuDong_Click;
            btnXoaDong.Click += BtnXoaDong_Click;
            btnLamMoi.Click += (s, e) => LamMoiDong();
        }

        private void FormCongThuc_Load(object? sender, EventArgs e)
        {
            NapDanhSachLoaiThucUong();
            NapDanhSachNguyenLieu();
            NapDanhSachThucUong();
            LamMoiDong();
        }

        private void NapDanhSachLoaiThucUong()
        {
            try
            {
                _dsLoaiTU = _bll.LayDanhSachLoaiThucUong();
                cboLoaiThucUong.Items.Clear();
                cboLoaiThucUong.Items.Add(new LoaiComboItem { MaLoai = null, TenLoai = "(Tất cả)" });

                foreach (var loai in _dsLoaiTU)
                {
                    cboLoaiThucUong.Items.Add(new LoaiComboItem { MaLoai = loai.MaLoaiTU, TenLoai = loai.TenLoai });
                }

                cboLoaiThucUong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void NapDanhSachNguyenLieu()
        {
            try
            {
                _dsNguyenLieu = _bll.LayDanhSachNguyenLieu();
                cboNguyenLieu.Items.Clear();

                foreach (var nl in _dsNguyenLieu)
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

        private void NapDanhSachThucUong()
        {
            try
            {
                _dsThucUong = _bll.LayDanhSachThucUong();
                ApDungBoLocThucUong();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungBoLocThucUong()
        {
            string? maLoai = (cboLoaiThucUong.SelectedItem as LoaiComboItem)?.MaLoai;
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            var ketQua = _dsThucUong.Where(tu =>
                (string.IsNullOrEmpty(maLoai) || tu.MaLoaiTU == maLoai) &&
                (string.IsNullOrEmpty(tuKhoa) ||
                 (tu.TenThucUong != null && tu.TenThucUong.ToLower().Contains(tuKhoa)) ||
                 (tu.MaThucUong != null && tu.MaThucUong.ToLower().Contains(tuKhoa)))
            ).ToList();

            dgvThucUong.DataSource = null;
            dgvThucUong.DataSource = ketQua;

            if (ketQua.Count > 0)
            {
                dgvThucUong.Rows[0].Selected = true;
                _monDangChon = ketQua[0];
                lblTenMon.Text = $"Công thức cho: {_monDangChon.TenThucUong} ({_monDangChon.MaThucUong})";
                NapCongThuc(_monDangChon.MaThucUong);
            }
            else
            {
                _monDangChon = null;
                lblTenMon.Text = "Chọn thức uống bên trái";
                _dsCongThuc.Clear();
                dgvCongThuc.DataSource = null;
                lblCanhBao.Visible = false;
            }
        }

        private void DgvThucUong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvThucUong.CurrentRow?.DataBoundItem is ThucUongQuanLyDTO tu)
            {
                _monDangChon = tu;
                lblTenMon.Text = $"Công thức cho: {_monDangChon.TenThucUong} ({_monDangChon.MaThucUong})";
                NapCongThuc(_monDangChon.MaThucUong);
            }
        }

        private void NapCongThuc(string maThucUong)
        {
            try
            {
                _dsCongThuc = _bll.LayCongThuc(maThucUong);
                dgvCongThuc.DataSource = null;
                dgvCongThuc.DataSource = _dsCongThuc;

                // Nếu món chưa có công thức, hiển thị dòng cảnh báo
                lblCanhBao.Visible = (_dsCongThuc.Count == 0);

                LamMoiDong();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void DgvCongThuc_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCongThuc.CurrentRow?.DataBoundItem is CongThucDTO ct)
            {
                for (int i = 0; i < cboNguyenLieu.Items.Count; i++)
                {
                    if ((cboNguyenLieu.Items[i] as NguyenLieuDTO)?.MaNL == ct.MaNL)
                    {
                        cboNguyenLieu.SelectedIndex = i;
                        break;
                    }
                }

                lblDonViTinh.Text = ct.DonViTinh;

                decimal soLuong = ct.SoLuongQuyDinh;
                if (soLuong < numSoLuongQuyDinh.Minimum) soLuong = numSoLuongQuyDinh.Minimum;
                if (soLuong > numSoLuongQuyDinh.Maximum) soLuong = numSoLuongQuyDinh.Maximum;
                numSoLuongQuyDinh.Value = soLuong;

                btnLuuDong.Text = "💾 Cập nhật";
                btnXoaDong.Enabled = true;
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

        private void LamMoiDong()
        {
            if (cboNguyenLieu.Items.Count > 0)
            {
                cboNguyenLieu.SelectedIndex = 0;
                CapNhatDonViTinh();
            }

            numSoLuongQuyDinh.Value = 1;
            btnLuuDong.Text = "💾 Thêm / Cập nhật";
            btnXoaDong.Enabled = false;
        }

        private void BtnLuuDong_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_monDangChon == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn thức uống.");
                    return;
                }

                var nl = cboNguyenLieu.SelectedItem as NguyenLieuDTO;
                if (nl == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn nguyên liệu.");
                    return;
                }

                decimal soLuong = numSoLuongQuyDinh.Value;
                if (soLuong <= 0)
                {
                    UiHelper.ShowWarning("Số lượng quy định phải lớn hơn 0.");
                    numSoLuongQuyDinh.Focus();
                    return;
                }

                _bll.LuuDong(_monDangChon.MaThucUong, nl.MaNL, soLuong);

                UiHelper.ShowInfo($"Đã lưu công thức cho món \"{_monDangChon.TenThucUong}\" thành công.");
                NapCongThuc(_monDangChon.MaThucUong);
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoaDong_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_monDangChon == null)
                {
                    UiHelper.ShowWarning("Vui lòng chọn thức uống.");
                    return;
                }

                if (dgvCongThuc.CurrentRow?.DataBoundItem is not CongThucDTO ct)
                {
                    UiHelper.ShowWarning("Vui lòng chọn dòng nguyên liệu cần xóa.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa nguyên liệu \"{ct.TenNL}\" khỏi công thức món \"{_monDangChon.TenThucUong}\" không?"))
                    return;

                _bll.XoaDong(_monDangChon.MaThucUong, ct.MaNL);

                UiHelper.ShowInfo($"Đã xóa nguyên liệu \"{ct.TenNL}\" khỏi công thức món \"{_monDangChon.TenThucUong}\" thành công.");
                NapCongThuc(_monDangChon.MaThucUong);
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }
    }
}

