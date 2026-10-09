using System.Drawing.Printing;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BanHang
{
    public class frmXemHoaDon : Form
    {
        private readonly RichTextBox rtbNoiDung;
        private readonly Panel pnlHeader;
        private readonly Panel pnlFooter;
        private readonly Label lblTieuDe;
        private readonly Button btnIn;
        private readonly Button btnSaoChep;
        private readonly Button btnDong;

        public frmXemHoaDon(string tieuDe, string noiDungHoaDon)
        {
            this.Text = tieuDe;
            this.Size = new Size(480, 680);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
                if (e.KeyCode == Keys.P && e.Control) InHoaDon();
            };

            // Header
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Color.FromArgb(15, 23, 42),
                Padding = new Padding(16, 12, 16, 12)
            };

            lblTieuDe = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Text = $"🖨️ {tieuDe.ToUpper()}",
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlHeader.Controls.Add(lblTieuDe);

            // Footer
            pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(12)
            };

            btnIn = new Button
            {
                Text = "🖨️ In phiếu (Ctrl+P)",
                Size = new Size(160, 38),
                Location = new Point(14, 11),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnIn.FlatAppearance.BorderSize = 0;
            btnIn.Click += (s, e) => InHoaDon();

            btnSaoChep = new Button
            {
                Text = "📋 Sao chép",
                Size = new Size(110, 38),
                Location = new Point(184, 11),
                BackColor = Color.FromArgb(71, 85, 105),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            btnSaoChep.FlatAppearance.BorderSize = 0;
            btnSaoChep.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(rtbNoiDung?.Text))
                {
                    Clipboard.SetText(rtbNoiDung.Text);
                    UiHelper.ShowInfo("Đã sao chép nội dung hóa đơn vào Clipboard!", "Thành công");
                }
            };

            btnDong = new Button
            {
                Text = "Đóng (Esc)",
                Size = new Size(110, 38),
                Location = new Point(340, 11),
                BackColor = Color.FromArgb(226, 232, 240),
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();

            pnlFooter.Controls.AddRange(new Control[] { btnIn, btnSaoChep, btnDong });

            // Nội dung hóa đơn (Mô phỏng máy in nhiệt POS 80mm)
            rtbNoiDung = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(254, 252, 232), // Màu giấy ngà ấm cúng
                ForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font("Consolas", 10F, FontStyle.Regular),
                BorderStyle = BorderStyle.None,
                Margin = new Padding(12),
                Text = noiDungHoaDon
            };

            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(14),
                BackColor = Color.FromArgb(241, 245, 249)
            };
            pnlBody.Controls.Add(rtbNoiDung);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }

        private void InHoaDon()
        {
            try
            {
                var pd = new PrintDocument();
                pd.PrintPage += (s, ev) =>
                {
                    var printFont = new Font("Consolas", 9F, FontStyle.Regular);
                    ev.Graphics?.DrawString(rtbNoiDung.Text, printFont, Brushes.Black, 10, 10);
                };

                using var printDlg = new PrintDialog();
                printDlg.Document = pd;
                if (printDlg.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                    UiHelper.ShowInfo("Đã gửi lệnh in thành công!", "In hóa đơn");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowWarning($"Không thể kết nối máy in: {ex.Message}");
            }
        }
    }
}
