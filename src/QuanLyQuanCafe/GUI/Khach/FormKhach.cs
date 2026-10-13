using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Khach
{
    public partial class FormKhach : Form
    {
        private readonly KhachBLL _bll = new();
        private List<KhachDTO> _dsKhach = new();
        private List<LoaiKhachDTO> _dsLoaiKhach = new();

        public FormKhach()
        {
            InitializeComponent();
            KhoiTaoSuKien();
        }

        private void KhoiTaoSuKien()
        {
            this.Load += FormKhach_Load;

            txtTimKiem.TextChanged += (s, e) => ApDungBoLoc();
            chkChiKhachThanThiet.CheckedChanged += (s, e) => ApDungBoLoc();

            dgvKhach.SelectionChanged += DgvKhach_SelectionChanged;
            cboLoaiKhach.SelectedIndexChanged += CboLoaiKhach_SelectedIndexChanged;

            btnLamMoi.Click += (s, e) => LamMoi();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
        }

        private void FormKhach_Load(object? sender, EventArgs e)
        {
            // Phân quyền nút Xóa: chỉ Quản lý mới được phép xóa khách hàng
            bool isQuanLy = string.Equals(CurrentUser.ChucVu, "Quản lý", StringComparison.OrdinalIgnoreCase);
            btnXoa.Visible = isQuanLy;

            // Định dạng cột hiển thị
            colDiemTichLuy.DefaultCellStyle.Format = "N0";
            colDiemTichLuy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPhanTramGiam.DefaultCellStyle.Format = "N0\\%";
            colPhanTramGiam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colLSNgayTao.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colLSTongTien.DefaultCellStyle.Format = "N0";
            colLSTongTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            NapLoaiKhach();
            NapDanhSach();
            LamMoi();
        }

        private void NapLoaiKhach()
        {
            try
            {
                _dsLoaiKhach = _bll.LayDanhSachLoaiKhach();
                cboLoaiKhach.Items.Clear();

                foreach (var lk in _dsLoaiKhach)
                {
                    cboLoaiKhach.Items.Add(lk);
                }

                if (cboLoaiKhach.Items.Count > 0)
                {
                    cboLoaiKhach.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void NapDanhSach()
        {
            try
            {
                _dsKhach = _bll.LayDanhSach();
                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungBoLoc()
        {
            IEnumerable<KhachDTO> nguon = _dsKhach;

            if (chkChiKhachThanThiet.Checked)
            {
                nguon = nguon.Where(k => k.DiemTichLuy > 0);
            }

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                nguon = nguon.Where(k =>
                    (!string.IsNullOrEmpty(k.TenKH) && k.TenKH.ToLower().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(k.SoDienThoai) && k.SoDienThoai.Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(k.MaKH) && k.MaKH.ToLower().Contains(tuKhoa)) ||
                    (!string.IsNullOrEmpty(k.TenLoaiKH) && k.TenLoaiKH.ToLower().Contains(tuKhoa)));
            }

            var ketQua = nguon.ToList();
            dgvKhach.DataSource = null;
            dgvKhach.DataSource = ketQua;
        }

        private void DgvKhach_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvKhach.CurrentRow?.DataBoundItem is KhachDTO kh)
            {
                HienThiChiTiet(kh);
            }
        }

        private void HienThiChiTiet(KhachDTO kh)
        {
            txtMaKH.Text = kh.MaKH;
            txtTenKH.Text = kh.TenKH;
            txtSoDienThoai.Text = kh.SoDienThoai;

            // Chọn đúng loại khách trên combobox
            for (int i = 0; i < cboLoaiKhach.Items.Count; i++)
            {
                if (cboLoaiKhach.Items[i] is LoaiKhachDTO lk &&
                    string.Equals(lk.MaLoaiKH, kh.MaLoaiKH, StringComparison.OrdinalIgnoreCase))
                {
                    cboLoaiKhach.SelectedIndex = i;
                    break;
                }
            }

            lblDiemTichLuy.Text = $"{kh.DiemTichLuy:N0} điểm";
            lblHangHienTai.Text = $"{kh.TenLoaiKH} (Giảm {kh.PhanTramGiam:N0}%)";

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = string.Equals(CurrentUser.ChucVu, "Quản lý", StringComparison.OrdinalIgnoreCase);

            NapLichSuMua(kh.MaKH);
        }

        private void NapLichSuMua(string maKH)
        {
            try
            {
                var lichSu = _bll.LayLichSuMuaHang(maKH);
                dgvLichSuMua.DataSource = null;
                dgvLichSuMua.DataSource = lichSu;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void CboLoaiKhach_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboLoaiKhach.SelectedItem is LoaiKhachDTO loai)
            {
                lblHangHienTai.Text = $"{loai.TenLoaiKH} (Giảm {loai.PhanTramGiam:N0}%)";
            }
        }

        private void LamMoi()
        {
            txtMaKH.Text = "(Tự sinh khi thêm)";
            txtTenKH.Clear();
            txtSoDienThoai.Clear();

            if (cboLoaiKhach.Items.Count > 0)
            {
                cboLoaiKhach.SelectedIndex = 0;
            }

            lblDiemTichLuy.Text = "0 điểm";
            if (cboLoaiKhach.SelectedItem is LoaiKhachDTO loai)
            {
                lblHangHienTai.Text = $"{loai.TenLoaiKH} (Giảm {loai.PhanTramGiam:N0}%)";
            }
            else
            {
                lblHangHienTai.Text = "Thường (Giảm 0%)";
            }

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvLichSuMua.DataSource = null;
            txtTenKH.Focus();
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var loai = cboLoaiKhach.SelectedItem as LoaiKhachDTO;
                var kh = new KhachDTO
                {
                    TenKH = txtTenKH.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaLoaiKH = loai?.MaLoaiKH ?? "LKH01"
                };

                string maMoi = _bll.Them(kh);
                UiHelper.ShowInfo($"Thêm khách hàng thành công! Mã khách hàng: {maMoi}");

                NapDanhSach();
                ChonKhachTheoMa(maMoi);
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
                string maKH = txtMaKH.Text.Trim();
                if (string.IsNullOrWhiteSpace(maKH) || maKH == "(Tự sinh khi thêm)")
                {
                    UiHelper.ShowWarning("Vui lòng chọn khách hàng cần sửa từ danh sách.");
                    return;
                }

                var loai = cboLoaiKhach.SelectedItem as LoaiKhachDTO;
                var kh = new KhachDTO
                {
                    MaKH = maKH,
                    TenKH = txtTenKH.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaLoaiKH = loai?.MaLoaiKH ?? "LKH01"
                };

                _bll.Sua(kh);
                UiHelper.ShowInfo("Cập nhật thông tin khách hàng thành công.");

                NapDanhSach();
                ChonKhachTheoMa(maKH);
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
                string maKH = txtMaKH.Text.Trim();
                if (string.IsNullOrWhiteSpace(maKH) || maKH == "(Tự sinh khi thêm)")
                {
                    UiHelper.ShowWarning("Vui lòng chọn khách hàng cần xóa từ danh sách.");
                    return;
                }

                if (UiHelper.Confirm($"Bạn có chắc chắn muốn xóa khách hàng [{txtTenKH.Text}] ({maKH})?", "Xác nhận xóa"))
                {
                    _bll.Xoa(maKH);
                    UiHelper.ShowInfo("Xóa khách hàng thành công.");

                    NapDanhSach();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ChonKhachTheoMa(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH)) return;

            foreach (DataGridViewRow row in dgvKhach.Rows)
            {
                if (row.DataBoundItem is KhachDTO k &&
                    string.Equals(k.MaKH, maKH, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvKhach.CurrentCell = row.Cells[0];
                    HienThiChiTiet(k);
                    break;
                }
            }
        }
    }
}

