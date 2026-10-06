using System.Data;
using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.NhanVien
{
    public partial class FormNhanVien : Form
    {
        private readonly NhanVienBLL _bll = new();
        private List<NhanVienDTO> _dsNhanVien = new();

        private class QuanLyComboItem
        {
            public string? MaNV { get; set; }
            public string HienThi { get; set; } = "";
            public override string ToString() => HienThi;
        }

        public FormNhanVien()
        {
            InitializeComponent();

            Theme.Apply(this);

            KhoiTaoCacDieuKhien();
            DangKySuKien();
        }

        private void FormNhanVien_Load(object? sender, EventArgs e)
        {
            NapDanhSach();
            LamMoi();
        }

        private void KhoiTaoCacDieuKhien()
        {
            // Danh sách chức vụ cố định
            cboChucVu.Items.AddRange(new object[] { "Quản lý", "Phục vụ", "Thu ngân", "Thủ kho", "Kế toán" });
            cboChucVu.SelectedIndex = 1; // Mặc định Phục vụ

            // Gợi ý ca làm việc
            cboCaLamViec.Items.AddRange(new object[] { "Sáng", "Chiều", "Tối", "Hành chính" });
            cboCaLamViec.SelectedIndex = 0;

            this.Load += FormNhanVien_Load;
        }

        private void DangKySuKien()
        {
            btnLamMoi.Click += (s, e) => LamMoi();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnDatLaiMatKhau.Click += BtnDatLaiMatKhau_Click;

            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
            dgvNhanVien.CellFormatting += DgvNhanVien_CellFormatting;
        }

        private void NapDanhSach()
        {
            try
            {
                _dsNhanVien = _bll.LayDanhSach();
                NapComboQuanLy();
                HienThiLenLuoi(_dsNhanVien);
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void NapComboQuanLy()
        {
            string? selectedMaQL = (cboQuanLy.SelectedItem as QuanLyComboItem)?.MaNV;

            cboQuanLy.Items.Clear();
            cboQuanLy.Items.Add(new QuanLyComboItem { MaNV = null, HienThi = "(Không có)" });

            // Lấy danh sách các nhân viên có chức vụ Quản lý
            var dsQuanLy = _dsNhanVien
                .Where(x => string.Equals(x.ChucVu, "Quản lý", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var ql in dsQuanLy)
            {
                cboQuanLy.Items.Add(new QuanLyComboItem
                {
                    MaNV = ql.MaNV,
                    HienThi = $"{ql.TenNV} ({ql.MaNV})"
                });
            }

            // Chọn lại giá trị cũ nếu có
            int selectIdx = 0;
            if (!string.IsNullOrWhiteSpace(selectedMaQL))
            {
                for (int i = 0; i < cboQuanLy.Items.Count; i++)
                {
                    if ((cboQuanLy.Items[i] as QuanLyComboItem)?.MaNV == selectedMaQL)
                    {
                        selectIdx = i;
                        break;
                    }
                }
            }
            cboQuanLy.SelectedIndex = selectIdx;
        }

        private void HienThiLenLuoi(List<NhanVienDTO> list)
        {
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = list;
        }

        private void DgvNhanVien_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "colQuanLy" && e.RowIndex >= 0)
            {
                if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is NhanVienDTO nv)
                {
                    if (string.IsNullOrWhiteSpace(nv.MaQL))
                    {
                        e.Value = "(Không có)";
                    }
                    else
                    {
                        var ql = _dsNhanVien.FirstOrDefault(x => x.MaNV == nv.MaQL);
                        e.Value = ql != null ? ql.TenNV : nv.MaQL;
                    }
                    e.FormattingApplied = true;
                }
            }
            else if (dgvNhanVien.Columns[e.ColumnIndex].Name == "colChucVu" && e.Value != null)
            {
                string cv = e.Value.ToString()?.Trim() ?? "";
                e.CellStyle.ForeColor = cv switch
                {
                    "Quản lý" => Theme.NhanManh,                  // Vàng nổi bật
                    "Thu ngân" => Theme.NhanPhu,                 // Xanh nhạt
                    "Phục vụ" => Color.FromArgb(170, 225, 255),  // Xanh lơ nhạt
                    "Thủ kho" => Color.FromArgb(255, 185, 120),  // Cam nhạt
                    "Kế toán" => Color.FromArgb(200, 180, 255),  // Tím nhạt
                    _ => Theme.Chu
                };
                e.CellStyle.Font = Theme.FontNhanDam;
            }
        }

        private void DgvNhanVien_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow?.DataBoundItem is NhanVienDTO nv)
            {
                HienThiChiTiet(nv);
            }
        }

        private void HienThiChiTiet(NhanVienDTO nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtMaNV.ReadOnly = true;

            txtTenNV.Text = nv.TenNV;
            cboChucVu.SelectedItem = nv.ChucVu;
            txtSoDienThoai.Text = nv.SoDienThoai;
            cboCaLamViec.Text = nv.CaLamViec;

            // Chọn người quản lý
            int qlIndex = 0;
            if (!string.IsNullOrWhiteSpace(nv.MaQL))
            {
                for (int i = 0; i < cboQuanLy.Items.Count; i++)
                {
                    if ((cboQuanLy.Items[i] as QuanLyComboItem)?.MaNV == nv.MaQL)
                    {
                        qlIndex = i;
                        break;
                    }
                }
            }
            cboQuanLy.SelectedIndex = qlIndex;

            // Khi sửa thì khóa mật khẩu
            txtMatKhau.Clear();
            txtMatKhau.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnDatLaiMatKhau.Enabled = true;
        }

        private void LamMoi()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Text = _bll.GoiYMaMoi(_dsNhanVien);

            txtTenNV.Clear();
            cboChucVu.SelectedIndex = 1; // Phục vụ
            txtSoDienThoai.Clear();
            cboCaLamViec.SelectedIndex = 0;
            cboQuanLy.SelectedIndex = 0; // (Không có)

            txtMatKhau.Clear();
            txtMatKhau.Enabled = true;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnDatLaiMatKhau.Enabled = false;

            txtTenNV.Focus();
        }

        private void TxtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiLenLuoi(_dsNhanVien);
                return;
            }

            var ketQua = _dsNhanVien
                .Where(nv => nv.TenNV.ToLower().Contains(tuKhoa) ||
                             nv.SoDienThoai.Contains(tuKhoa) ||
                             nv.MaNV.ToLower().Contains(tuKhoa) ||
                             nv.ChucVu.ToLower().Contains(tuKhoa))
                .ToList();

            HienThiLenLuoi(ketQua);
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                var nv = new NhanVienDTO
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenNV = txtTenNV.Text.Trim(),
                    ChucVu = cboChucVu.SelectedItem?.ToString() ?? "",
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    CaLamViec = cboCaLamViec.Text.Trim(),
                    MaQL = (cboQuanLy.SelectedItem as QuanLyComboItem)?.MaNV
                };

                _bll.Them(nv, txtMatKhau.Text);

                UiHelper.ShowInfo("Thêm nhân viên thành công.");
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
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    UiHelper.ShowWarning("Vui lòng chọn nhân viên cần sửa từ danh sách.");
                    return;
                }

                var nv = new NhanVienDTO
                {
                    MaNV = txtMaNV.Text.Trim(),
                    TenNV = txtTenNV.Text.Trim(),
                    ChucVu = cboChucVu.SelectedItem?.ToString() ?? "",
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    CaLamViec = cboCaLamViec.Text.Trim(),
                    MaQL = (cboQuanLy.SelectedItem as QuanLyComboItem)?.MaNV
                };

                _bll.Sua(nv);

                UiHelper.ShowInfo("Cập nhật thông tin nhân viên thành công.");
                NapDanhSach();
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
            }
        }

        private void BtnDatLaiMatKhau_Click(object? sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                UiHelper.ShowWarning("Vui lòng chọn nhân viên cần đặt lại mật khẩu.");
                return;
            }

            // Hộp thoại nhập mật khẩu mới
            using var prompt = new Form
            {
                Width = 400,
                Height = 190,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = $"Đặt lại mật khẩu - {tenNV}",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10F)
            };

            var lbl = new Label
            {
                Left = 20,
                Top = 15,
                Text = "Nhập mật khẩu mới (tối thiểu 6 ký tự):",
                AutoSize = true
            };

            var txt = new TextBox
            {
                Left = 20,
                Top = 42,
                Width = 340,
                UseSystemPasswordChar = true,
                MaxLength = 255
            };

            var btnXacNhan = new Button
            {
                Text = "Xác nhận",
                Tag = "success",
                Left = 170,
                Top = 85,
                Width = 95,
                Height = 35,
                DialogResult = DialogResult.OK,
                UseVisualStyleBackColor = true
            };

            var btnHuy = new Button
            {
                Text = "Hủy",
                Tag = "neutral",
                Left = 275,
                Top = 85,
                Width = 85,
                Height = 35,
                DialogResult = DialogResult.Cancel,
                UseVisualStyleBackColor = true
            };

            prompt.Controls.AddRange(new Control[] { lbl, txt, btnXacNhan, btnHuy });
            prompt.AcceptButton = btnXacNhan;
            prompt.CancelButton = btnHuy;

            Theme.Apply(prompt);

            if (prompt.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string mkMoi = txt.Text;
                    _bll.DatLaiMatKhau(maNV, mkMoi);
                    UiHelper.ShowInfo($"Đặt lại mật khẩu cho nhân viên {tenNV} ({maNV}) thành công.");
                }
                catch (Exception ex)
                {
                    UiHelper.HienLoi(ex);
                }
            }
        }
    }
}