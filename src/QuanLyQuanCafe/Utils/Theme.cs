using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace QuanLyQuanCafe.Utils
{
    public static class Theme
    {
        #region 1. Bảng màu chuẩn theo thiết kế Dark Dashboard

        public static readonly Color Nen = ColorTranslator.FromHtml("#2B3045");
        public static readonly Color NenTrongHon = ColorTranslator.FromHtml("#1B2133");
        public static readonly Color The = ColorTranslator.FromHtml("#343B55");
        public static readonly Color VienThe = ColorTranslator.FromHtml("#424A69");
        public static readonly Color HeaderTrai = ColorTranslator.FromHtml("#4A8AE6");
        public static readonly Color HeaderPhai = ColorTranslator.FromHtml("#7062E8");
        public static readonly Color TieuDeBang = ColorTranslator.FromHtml("#6B5CE6");
        public static readonly Color DongLe = ColorTranslator.FromHtml("#232A40");
        public static readonly Color DongChon = ColorTranslator.FromHtml("#4B5AA8");
        public static readonly Color Chu = ColorTranslator.FromHtml("#FFFFFF");
        public static readonly Color ChuPhu = ColorTranslator.FromHtml("#AEB4C8");
        public static readonly Color NhanManh = ColorTranslator.FromHtml("#FFD24D");
        public static readonly Color NhanPhu = ColorTranslator.FromHtml("#5BC8F5");

        public static readonly Color PrimaryTop = ColorTranslator.FromHtml("#4F8DEB");
        public static readonly Color PrimaryBottom = ColorTranslator.FromHtml("#3B6FD9");

        public static readonly Color SuccessTop = ColorTranslator.FromHtml("#27AE60");
        public static readonly Color SuccessBottom = ColorTranslator.FromHtml("#00C65A");

        public static readonly Color DangerTop = ColorTranslator.FromHtml("#E03A47");
        public static readonly Color DangerBottom = ColorTranslator.FromHtml("#C62835");

        public static readonly Color InfoTop = ColorTranslator.FromHtml("#1AA3B8");
        public static readonly Color InfoBottom = ColorTranslator.FromHtml("#12879B");

        public static readonly Color NeutralTop = ColorTranslator.FromHtml("#5E6272");
        public static readonly Color NeutralBottom = ColorTranslator.FromHtml("#4A4E5C");

        public static readonly Color BanTrong = ColorTranslator.FromHtml("#00C65A");
        public static readonly Color BanCoKhach = ColorTranslator.FromHtml("#E03A47");
        public static readonly Color BanDatTruoc = ColorTranslator.FromHtml("#F5B041");

        public static readonly Color NenMenuDropDown = ColorTranslator.FromHtml("#252A3D");
        public static readonly Color NenStatusStrip = ColorTranslator.FromHtml("#252A3D");
        public static readonly Color LuoiGridColor = ColorTranslator.FromHtml("#2F3652");

        #endregion

        #region 2. Phông chữ dùng chung

        public static readonly Font FontChinh = new("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontNhan = new("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontNhanDam = new("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontTieuDeKhoi = new("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontTieuDeTrang = new("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font FontMenu = new("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontNut = new("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontBang = new("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontTieuDeBang = new("Segoe UI", 10F, FontStyle.Bold);

        #endregion

        #region 3. Các loại nút (ButtonKind) & Trạng thái

        public enum ButtonKind
        {
            Primary,
            Success,
            Danger,
            Info,
            Neutral
        }

        private class ButtonStateTracker
        {
            public ButtonKind Kind { get; set; } = ButtonKind.Primary;
            public bool IsHovered { get; set; }
            public bool IsPressed { get; set; }
        }

        private static readonly ConditionalWeakTable<Button, ButtonStateTracker> _buttonTrackers = new();
        private static readonly HashSet<Control> _styledControls = new();

        #endregion

        #region 4. Đường bao bo góc (RoundedRect)

        public static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }

            int d = radius * 2;
            if (d > r.Width) d = r.Width;
            if (d > r.Height) d = r.Height;

            Rectangle arc = new(r.X, r.Y, d, d);
            path.AddArc(arc, 180, 90);
            arc.X = r.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = r.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = r.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        #endregion

        #region 5. Định kiểu cho từng loại Control

        public static void StyleButton(Button b, ButtonKind kind = ButtonKind.Primary)
        {
            if (b == null) return;

            var tracker = _buttonTrackers.GetOrCreateValue(b);
            tracker.Kind = kind;

            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Cursor = Cursors.Hand;
            b.Font = FontNut;

            if (_styledControls.Contains(b))
            {
                b.Invalidate();
                return;
            }
            _styledControls.Add(b);
            b.Disposed += (s, e) => _styledControls.Remove(b);

            b.MouseEnter += (s, e) => { tracker.IsHovered = true; b.Invalidate(); };
            b.MouseLeave += (s, e) => { tracker.IsHovered = false; tracker.IsPressed = false; b.Invalidate(); };
            b.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { tracker.IsPressed = true; b.Invalidate(); } };
            b.MouseUp += (s, e) => { tracker.IsPressed = false; b.Invalidate(); };
            b.EnabledChanged += (s, e) => b.Invalidate();

            b.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle clientRect = b.ClientRectangle;
                if (clientRect.Width <= 0 || clientRect.Height <= 0) return;

                // Tô nền cha để khử răng cưa góc bo
                Color parentBg = b.Parent?.BackColor ?? Nen;
                using (var bgBrush = new SolidBrush(parentBg))
                {
                    g.FillRectangle(bgBrush, clientRect);
                }

                (Color top, Color bottom) = GetButtonColors(tracker.Kind, tracker.IsHovered, tracker.IsPressed, b.Enabled);

                Rectangle drawRect = new(0, 0, b.Width - 1, b.Height - 1);
                using var path = RoundedRect(drawRect, 8);
                using var brush = new LinearGradientBrush(drawRect, top, bottom, LinearGradientMode.Vertical);
                g.FillPath(brush, path);

                Color textColor = b.Enabled ? Chu : Color.FromArgb(140, 147, 170);
                TextRenderer.DrawText(g, b.Text, FontNut, clientRect, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            };
        }

        private static (Color top, Color bottom) GetButtonColors(ButtonKind kind, bool hovered, bool pressed, bool enabled)
        {
            if (!enabled)
            {
                return (Color.FromArgb(70, 76, 98), Color.FromArgb(55, 60, 80));
            }

            (Color top, Color bottom) = kind switch
            {
                ButtonKind.Success => (SuccessTop, SuccessBottom),
                ButtonKind.Danger => (DangerTop, DangerBottom),
                ButtonKind.Info => (InfoTop, InfoBottom),
                ButtonKind.Neutral => (NeutralTop, NeutralBottom),
                _ => (PrimaryTop, PrimaryBottom)
            };

            if (pressed)
            {
                return (AdjustBrightness(top, -0.15f), AdjustBrightness(bottom, -0.15f));
            }
            if (hovered)
            {
                return (AdjustBrightness(top, 0.15f), AdjustBrightness(bottom, 0.15f));
            }

            return (top, bottom);
        }

        private static Color AdjustBrightness(Color c, float factor)
        {
            float r = c.R;
            float g = c.G;
            float b = c.B;

            if (factor > 0)
            {
                r += (255 - r) * factor;
                g += (255 - g) * factor;
                b += (255 - b) * factor;
            }
            else
            {
                r *= (1 + factor);
                g *= (1 + factor);
                b *= (1 + factor);
            }

            return Color.FromArgb(c.A,
                Math.Clamp((int)r, 0, 255),
                Math.Clamp((int)g, 0, 255),
                Math.Clamp((int)b, 0, 255));
        }

        public static void StyleCard(Control c, string? tieuDe = null, int radius = 10)
        {
            if (c == null) return;

            c.Font = FontTieuDeKhoi;
            c.ForeColor = Chu;

            if (_styledControls.Contains(c)) return;
            _styledControls.Add(c);
            c.Disposed += (s, e) => _styledControls.Remove(c);

            c.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle clientRect = c.ClientRectangle;
                if (clientRect.Width <= 0 || clientRect.Height <= 0) return;

                Color parentBg = c.Parent?.BackColor ?? Nen;
                using (var bgBrush = new SolidBrush(parentBg))
                {
                    g.FillRectangle(bgBrush, clientRect);
                }

                Rectangle drawRect = new(0, 0, c.Width - 1, c.Height - 1);
                using var path = RoundedRect(drawRect, radius);
                using var fillBrush = new SolidBrush(The);
                using var borderPen = new Pen(VienThe, 1);
                g.FillPath(fillBrush, path);
                g.DrawPath(borderPen, path);

                string title = tieuDe ?? c.Text;
                if (!string.IsNullOrWhiteSpace(title))
                {
                    TextRenderer.DrawText(g, title, FontTieuDeKhoi, new Point(14, 10), Chu);
                }
            };
        }

        public static void StyleGrid(DataGridView g)
        {
            if (g == null) return;

            g.BorderStyle = BorderStyle.None;
            g.EnableHeadersVisualStyles = false;
            g.BackgroundColor = Nen;
            g.GridColor = LuoiGridColor;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.RowTemplate.Height = 36;
            g.ColumnHeadersHeight = 38;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            g.ColumnHeadersDefaultCellStyle.BackColor = TieuDeBang;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Chu;
            g.ColumnHeadersDefaultCellStyle.Font = FontTieuDeBang;
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            g.DefaultCellStyle.BackColor = NenTrongHon;
            g.DefaultCellStyle.ForeColor = Chu;
            g.DefaultCellStyle.Font = FontBang;
            g.DefaultCellStyle.SelectionBackColor = DongChon;
            g.DefaultCellStyle.SelectionForeColor = Chu;

            g.AlternatingRowsDefaultCellStyle.BackColor = DongLe;
            g.AlternatingRowsDefaultCellStyle.ForeColor = Chu;
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = DongChon;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Chu;

            // Bật DoubleBuffered qua reflection chống giật lag
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, g, new object[] { true });
            }
            catch
            {
                // Bỏ qua nếu môi trường hạn chế reflection
            }
        }

        public static void StyleInput(Control c)
        {
            if (c == null) return;

            c.BackColor = NenTrongHon;
            c.ForeColor = Chu;
            c.Font = FontChinh;

            if (c is TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (c is ComboBox cbo)
            {
                cbo.FlatStyle = FlatStyle.Flat;
            }
            else if (c is NumericUpDown num)
            {
                num.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (c is DateTimePicker dtp)
            {
                dtp.CalendarMonthBackground = NenTrongHon;
                dtp.CalendarTitleBackColor = The;
                dtp.CalendarTitleForeColor = Chu;
                dtp.CalendarForeColor = Chu;
            }
        }

        public static void StyleLabel(Label l, bool phu = false)
        {
            if (l == null) return;

            l.BackColor = Color.Transparent;
            if (l.ForeColor == SystemColors.ControlText || l.ForeColor == Color.Black ||
                l.ForeColor == Chu || l.ForeColor == ChuPhu)
            {
                l.ForeColor = phu ? ChuPhu : Chu;
            }
        }

        public static void StyleTab(TabControl t)
        {
            if (t == null) return;

            t.DrawMode = TabDrawMode.OwnerDrawFixed;
            t.SizeMode = TabSizeMode.Fixed;
            t.ItemSize = new Size(130, 36);

            if (_styledControls.Contains(t)) return;
            _styledControls.Add(t);
            t.Disposed += (s, e) => _styledControls.Remove(t);

            t.DrawItem += (s, e) =>
            {
                if (e.Index < 0 || e.Index >= t.TabPages.Count) return;

                TabPage page = t.TabPages[e.Index];
                Rectangle rect = t.GetTabRect(e.Index);
                bool isSelected = (t.SelectedIndex == e.Index);

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (isSelected)
                {
                    Rectangle drawRect = new(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 2);
                    using var brush = new LinearGradientBrush(drawRect, PrimaryTop, PrimaryBottom, LinearGradientMode.Vertical);
                    using var path = RoundedRect(drawRect, 6);
                    g.FillPath(brush, path);
                }
                else
                {
                    using var brush = new SolidBrush(Nen);
                    g.FillRectangle(brush, rect);
                }

                TextRenderer.DrawText(g, page.Text, isSelected ? FontNut : FontNhan,
                    rect, isSelected ? Chu : ChuPhu,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            foreach (TabPage tp in t.TabPages)
            {
                tp.BackColor = Nen;
                tp.ForeColor = Chu;
            }
        }

        public static void DrawGradientHeader(Control c)
        {
            if (c == null) return;

            if (_styledControls.Contains(c)) return;
            _styledControls.Add(c);
            c.Disposed += (s, e) => _styledControls.Remove(c);

            c.Paint += (s, e) =>
            {
                Rectangle rect = c.ClientRectangle;
                if (rect.Width <= 0 || rect.Height <= 0) return;

                using var brush = new LinearGradientBrush(rect, HeaderTrai, HeaderPhai, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, rect);
            };
        }

        #endregion

        #region 6. Duyệt và áp dụng toàn diện (Apply)

        public static void Apply(Form f)
        {
            if (f == null) return;

            try
            {
                f.BackColor = Nen;
                f.ForeColor = Chu;
                f.Font = FontChinh;

                ApplyToControls(f.Controls);
            }
            catch
            {
                // Đảm bảo không ném ngoại lệ làm gián đoạn form
            }
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c == null) continue;

                if (string.Equals(c.Tag?.ToString(), "NoTheme", StringComparison.OrdinalIgnoreCase))
                    continue;

                ApplyToControl(c);

                if (c.HasChildren)
                {
                    ApplyToControls(c.Controls);
                }
            }
        }

        private static void ApplyToControl(Control c)
        {
            switch (c)
            {
                case Button btn:
                    ButtonKind kind = DetermineButtonKind(btn);
                    StyleButton(btn, kind);
                    break;

                case GroupBox gb:
                    StyleCard(gb);
                    break;

                case DataGridView dgv:
                    StyleGrid(dgv);
                    break;

                case TabControl tc:
                    StyleTab(tc);
                    break;

                case TabPage tp:
                    tp.BackColor = Nen;
                    tp.ForeColor = Chu;
                    break;

                case TextBox txt:
                case ComboBox cbo:
                case NumericUpDown num:
                case DateTimePicker dtp:
                    StyleInput(c);
                    break;

                case Label lbl:
                    ApplyToLabel(lbl);
                    break;

                case CheckBox chk:
                    chk.BackColor = Color.Transparent;
                    chk.ForeColor = Chu;
                    break;

                case RadioButton rad:
                    rad.BackColor = Color.Transparent;
                    rad.ForeColor = Chu;
                    break;

                case Panel pnl:
                    if (pnl.BackColor == SystemColors.Control || pnl.BackColor == Color.White ||
                        pnl.BackColor == SystemColors.Window)
                    {
                        pnl.BackColor = Color.Transparent;
                    }
                    break;
            }
        }

        private static void ApplyToLabel(Label lbl)
        {
            string? tag = lbl.Tag?.ToString()?.ToLowerInvariant();
            if (tag == "nhanmanh")
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = NhanManh;
                return;
            }
            if (tag == "nhanphu")
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = NhanPhu;
                return;
            }
            if (tag == "tieude")
            {
                lbl.BackColor = Color.Transparent;
                lbl.Font = FontTieuDeTrang;
                lbl.ForeColor = Chu;
                return;
            }
            if (tag == "phu")
            {
                StyleLabel(lbl, phu: true);
                return;
            }

            // Mặc định nhãn nhập liệu (có dấu hai chấm) dùng ChuPhu, ngược lại dùng Chu
            bool isFieldLabel = lbl.Text.TrimEnd().EndsWith(":") || lbl.Text.Contains("(*)");
            StyleLabel(lbl, phu: isFieldLabel);
        }

        private static ButtonKind DetermineButtonKind(Button btn)
        {
            string? tag = btn.Tag?.ToString()?.ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(tag))
            {
                return tag switch
                {
                    "primary" => ButtonKind.Primary,
                    "success" => ButtonKind.Success,
                    "danger" => ButtonKind.Danger,
                    "info" => ButtonKind.Info,
                    "neutral" => ButtonKind.Neutral,
                    _ => ButtonKind.Primary
                };
            }

            string name = btn.Name.ToLowerInvariant();
            if (name.Contains("xoa") || name.Contains("huy"))
                return ButtonKind.Danger;
            if (name.Contains("luu") || name.Contains("them") || name.Contains("thanhtoan") ||
                name.Contains("dongy") || name.Contains("xacnhan"))
                return ButtonKind.Success;
            if (name.Contains("lam") || name.Contains("thoat") || name.Contains("dong"))
                return ButtonKind.Neutral;
            if (name.Contains("reset") || name.Contains("datlai") || name.Contains("in"))
                return ButtonKind.Info;

            return ButtonKind.Primary;
        }

        #endregion
    }
}
