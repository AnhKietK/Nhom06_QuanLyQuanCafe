using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.DanhMuc
{
    public partial class FormThucUong : Form
    {
        private readonly ThucUongBLL _bll = new();
        private List<ThucUongQuanLyDTO> _dsThucUong = new();
        private List<LoaiThucUongDTO> _dsLoaiTU = new();
        private string? _currentHinhAnh = null;

        private class LoaiComboItem
        {
            public string? MaLoai { get; set; }
            public string TenLoai { get; set; } = "";
            public override string ToString() => TenLoai;
        }

        public FormThucUong()
        {
            InitializeComponent();
            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void KhoiTaoCacDieuKhien()
        {
            this.Load += FormThucUong_Load;
        }

        private void DangKySuKien()
        {
            btnLamMoi.Click += (s, e) => LamMoi();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;

            btnChonAnh.Click += BtnChonAnh_Click;
            btnXoaAnh.Click += BtnXoaAnh_Click;

            cboLocLoai.SelectedIndexChanged += (s, e) => ApDungBoLoc();
            txtTimKiem.TextChanged += (s, e) => ApDungBoLoc();
            dgvThucUong.SelectionChanged += DgvThucUong_SelectionChanged;
        }

        private void FormThucUong_Load(object? sender, EventArgs e)
        {
            NapLoaiThucUong();
            NapDanhSach();
            LamMoi();
        }

        private void NapLoaiThucUong()
        {
            try
            {
                _dsLoaiTU = _bll.LayDanhSachLoai();

                // Nạp combo lọc
                cboLocLoai.Items.Clear();
                cboLocLoai.Items.Add(new LoaiComboItem { MaLoai = null, TenLoai = "(Tất cả)" });
                foreach (var loai in _dsLoaiTU)
                {
                    cboLocLoai.Items.Add(new LoaiComboItem { MaLoai = loai.MaLoaiTU, TenLoai = loai.TenLoai });
                }
                cboLocLoai.SelectedIndex = 0;

                // Nạp combo nhập liệu
                cboLoaiThucUong.Items.Clear();
                foreach (var loai in _dsLoaiTU)
                {
                    cboLoaiThucUong.Items.Add(loai);
                }
                if (cboLoaiThucUong.Items.Count > 0)
                    cboLoaiThucUong.SelectedIndex = 0;
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
                _dsThucUong = _bll.LayDanhSach();
                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void ApDungBoLoc()
        {
            string? maLoai = (cboLocLoai.SelectedItem as LoaiComboItem)?.MaLoai;
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            var ketQua = _dsThucUong.Where(tu =>
                (string.IsNullOrEmpty(maLoai) || tu.MaLoaiTU == maLoai) &&
                (string.IsNullOrEmpty(tuKhoa) ||
                 (tu.TenThucUong != null && tu.TenThucUong.ToLower().Contains(tuKhoa)) ||
                 (tu.MaThucUong != null && tu.MaThucUong.ToLower().Contains(tuKhoa)) ||
                 (tu.TenLoaiTU != null && tu.TenLoaiTU.ToLower().Contains(tuKhoa)))
            ).ToList();

            dgvThucUong.DataSource = null;
            dgvThucUong.DataSource = ketQua;
        }

        private void DgvThucUong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvThucUong.CurrentRow?.DataBoundItem is ThucUongQuanLyDTO tu)
            {
                HienThiChiTiet(tu);
            }
        }

        private void HienThiChiTiet(ThucUongQuanLyDTO tu)
        {
            txtMaThucUong.Text = tu.MaThucUong;
            txtMaThucUong.ReadOnly = true;

            txtTenThucUong.Text = tu.TenThucUong;

            // Chọn loại tương ứng trong ComboBox nhập liệu
            for (int i = 0; i < cboLoaiThucUong.Items.Count; i++)
            {
                if ((cboLoaiThucUong.Items[i] as LoaiThucUongDTO)?.MaLoaiTU == tu.MaLoaiTU)
                {
                    cboLoaiThucUong.SelectedIndex = i;
                    break;
                }
            }

            decimal giaBan = tu.DonGiaBan;
            if (giaBan < numDonGiaBan.Minimum) giaBan = numDonGiaBan.Minimum;
            if (giaBan > numDonGiaBan.Maximum) giaBan = numDonGiaBan.Maximum;
            numDonGiaBan.Value = giaBan;

            _currentHinhAnh = tu.HinhAnh;
            HienThiHinhAnh(_currentHinhAnh);

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void LamMoi()
        {
            txtMaThucUong.ReadOnly = false;
            txtMaThucUong.Text = _bll.GoiYMaMoi(_dsThucUong);

            txtTenThucUong.Clear();
            if (cboLoaiThucUong.Items.Count > 0)
                cboLoaiThucUong.SelectedIndex = 0;

            numDonGiaBan.Value = 25000;

            _currentHinhAnh = null;
            HienThiHinhAnh(null);

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenThucUong.Focus();
        }

        private void HienThiHinhAnh(string? tenFile)
        {
            // Giải phóng ảnh cũ nếu có để tránh giữ bộ nhớ / khóa file
            if (picHinhAnh.Image != null)
            {
                var oldImg = picHinhAnh.Image;
                picHinhAnh.Image = null;
                oldImg.Dispose();
            }

            txtHinhAnh.Text = tenFile ?? "";

            if (string.IsNullOrWhiteSpace(tenFile))
            {
                return;
            }

            try
            {
                string folder = Path.Combine(AppContext.BaseDirectory, "Images");
                string fullPath = Path.Combine(folder, tenFile);
                if (File.Exists(fullPath))
                {
                    // Đọc file bằng FileStream rồi sao chép sang Bitmap để không khóa file
                    using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var temp = Image.FromStream(fs);
                    picHinhAnh.Image = new Bitmap(temp);
                }
                else
                {
                    picHinhAnh.Image = null;
                }
            }
            catch
            {
                // File hỏng hoặc không đọc được: hiển thị khung trống, không crash
                picHinhAnh.Image = null;
            }
        }

        private void BtnChonAnh_Click(object? sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "Hình ảnh (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tất cả tập tin (*.*)|*.*",
                    Title = "Chọn hình ảnh thức uống"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    string folder = Path.Combine(AppContext.BaseDirectory, "Images");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Path.GetFileName(sourceFile);
                    string destPath = Path.Combine(folder, fileName);

                    // Sao chép file vào thư mục Images nếu nguồn khác đích
                    if (!string.Equals(sourceFile, destPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(sourceFile, destPath, true);
                    }

                    _currentHinhAnh = fileName;
                    HienThiHinhAnh(_currentHinhAnh);
                }
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnXoaAnh_Click(object? sender, EventArgs e)
        {
            _currentHinhAnh = null;
            HienThiHinhAnh(null);
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var loai = cboLoaiThucUong.SelectedItem as LoaiThucUongDTO;
                var tu = new ThucUongQuanLyDTO
                {
                    MaThucUong = txtMaThucUong.Text.Trim(),
                    TenThucUong = txtTenThucUong.Text.Trim(),
                    MaLoaiTU = loai?.MaLoaiTU ?? "",
                    DonGiaBan = numDonGiaBan.Value,
                    HinhAnh = _currentHinhAnh
                };

                _bll.Them(tu);

                UiHelper.ShowInfo("Thêm thức uống thành công.\n\nHãy thiết lập công thức pha chế cho món này ở menu Kho, Công thức pha chế.");
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
                if (string.IsNullOrWhiteSpace(txtMaThucUong.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn thức uống cần sửa từ danh sách.");
                    return;
                }

                var loai = cboLoaiThucUong.SelectedItem as LoaiThucUongDTO;
                var tu = new ThucUongQuanLyDTO
                {
                    MaThucUong = txtMaThucUong.Text.Trim(),
                    TenThucUong = txtTenThucUong.Text.Trim(),
                    MaLoaiTU = loai?.MaLoaiTU ?? "",
                    DonGiaBan = numDonGiaBan.Value,
                    HinhAnh = _currentHinhAnh
                };

                _bll.Sua(tu);

                UiHelper.ShowInfo("Cập nhật thông tin thức uống thành công.");
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
                string maTU = txtMaThucUong.Text.Trim();
                string tenTU = txtTenThucUong.Text.Trim();

                if (string.IsNullOrWhiteSpace(maTU))
                {
                    UiHelper.ShowWarning("Vui lòng chọn thức uống cần xóa từ danh sách.");
                    return;
                }

                if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa thức uống \"{tenTU}\" ({maTU}) không?"))
                    return;

                _bll.Xoa(maTU);

                UiHelper.ShowInfo($"Đã xóa thức uống \"{tenTU}\" thành công.");
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

