using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Kho
{
    public partial class FormNhaCungCap : Form
    {
        private readonly NhaCungCapBLL _bll = new();
        private List<NhaCungCapDTO> _dsNCC = new();

        public FormNhaCungCap()
        {
            InitializeComponent();
            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormNhaCungCap_Load;
        }

        private void DangKySuKien()
        {
            btnLamMoi.Click += (s, e) => LamMoi();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;

            txtTimKiem.TextChanged += (s, e) => ApDungBoLoc();
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        private void FormNhaCungCap_Load(object? sender, EventArgs e)
        {
            NapDanhSach();
            LamMoi();
        }

        private void NapDanhSach()
        {
            try
            {
                _dsNCC = _bll.LayDanhSach();
                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungBoLoc()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                dgvNhaCungCap.DataSource = null;
                dgvNhaCungCap.DataSource = _dsNCC;
                return;
            }

            var ketQua = _dsNCC.Where(ncc =>
                (ncc.MaNCC != null && ncc.MaNCC.ToLower().Contains(tuKhoa)) ||
                (ncc.TenNCC != null && ncc.TenNCC.ToLower().Contains(tuKhoa)) ||
                (ncc.SoDienThoai != null && ncc.SoDienThoai.Contains(tuKhoa)) ||
                (ncc.Email != null && ncc.Email.ToLower().Contains(tuKhoa)) ||
                (ncc.DiaChi != null && ncc.DiaChi.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvNhaCungCap.DataSource = null;
            dgvNhaCungCap.DataSource = ketQua;
        }

        private void DgvNhaCungCap_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow?.DataBoundItem is NhaCungCapDTO ncc)
            {
                HienThiChiTiet(ncc);
            }
        }

        private void HienThiChiTiet(NhaCungCapDTO ncc)
        {
            txtMaNCC.Text = ncc.MaNCC;
            txtMaNCC.ReadOnly = true;

            txtTenNCC.Text = ncc.TenNCC;
            txtSoDienThoai.Text = ncc.SoDienThoai ?? "";
            txtEmail.Text = ncc.Email ?? "";
            txtDiaChi.Text = ncc.DiaChi ?? "";

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void LamMoi()
        {
            txtMaNCC.ReadOnly = false;
            txtMaNCC.Text = _bll.GoiYMaMoi(_dsNCC);

            txtTenNCC.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenNCC.Focus();
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var ncc = new NhaCungCapDTO
                {
                    MaNCC = txtMaNCC.Text.Trim(),
                    TenNCC = txtTenNCC.Text.Trim(),
                    SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim()
                };

                _bll.Them(ncc);

                UiHelper.ShowInfo("Thêm nhà cung cấp thành công.");
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
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn nhà cung cấp cần sửa từ danh sách.");
                    return;
                }

                var ncc = new NhaCungCapDTO
                {
                    MaNCC = txtMaNCC.Text.Trim(),
                    TenNCC = txtTenNCC.Text.Trim(),
                    SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim()
                };

                _bll.Sua(ncc);

                UiHelper.ShowInfo("Cập nhật thông tin nhà cung cấp thành công.");
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
                string maNCC = txtMaNCC.Text.Trim();
                string tenNCC = txtTenNCC.Text.Trim();

                if (string.IsNullOrWhiteSpace(maNCC))
                {
                    UiHelper.ShowWarning("Vui lòng chọn nhà cung cấp cần xóa từ danh sách.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa nhà cung cấp \"{tenNCC}\" ({maNCC}) không?"))
                    return;

                _bll.Xoa(maNCC);

                UiHelper.ShowInfo($"Đã xóa nhà cung cấp \"{tenNCC}\" thành công.");
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

