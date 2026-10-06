using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace QuanLyQuanCafe.Utils
{
    public enum ThemeMode
    {
        Dark,
        Light
    }

    public static class Theme
    {
        public static ThemeMode CurrentMode { get; set; } = ThemeMode.Dark;

        #region 1. Bảng màu Dark Mode & Light Mode

        // --- Dark Mode ---
        private static readonly Color NenDark = ColorTranslator.FromHtml("#2B3045");
        private static readonly Color NenTrongHonDark = ColorTranslator.FromHtml("#1B2133");
        private static readonly Color TheDark = ColorTranslator.FromHtml("#343B55");
        private static readonly Color VienTheDark = ColorTranslator.FromHtml("#424A69");
        private static readonly Color HeaderTraiDark = ColorTranslator.FromHtml("#4A8AE6");
        private static readonly Color HeaderPhaiDark = ColorTranslator.FromHtml("#7062E8");
        private static readonly Color TieuDeBangDark = ColorTranslator.FromHtml("#6B5CE6");
        private static readonly Color DongLeDark = ColorTranslator.FromHtml("#232A40");
        private static readonly Color DongChonDark = ColorTranslator.FromHtml("#4B5AA8");
        private static readonly Color ChuDark = ColorTranslator.FromHtml("#FFFFFF");
        private static readonly Color ChuPhuDark = ColorTranslator.FromHtml("#AEB4C8");
        private static readonly Color NhanManhDark = ColorTranslator.FromHtml("#FFD24D");
        private static readonly Color NhanPhuDark = ColorTranslator.FromHtml("#5BC8F5");

        private static readonly Color PrimaryTopDark = ColorTranslator.FromHtml("#4F8DEB");
        private static readonly Color PrimaryBottomDark = ColorTranslator.FromHtml("#3B6FD9");
        private static readonly Color SuccessTopDark = ColorTranslator.FromHtml("#27AE60");
        private static readonly Color SuccessBottomDark = ColorTranslator.FromHtml("#00C65A");
        private static readonly Color DangerTopDark = ColorTranslator.FromHtml("#E03A47");
        private static readonly Color DangerBottomDark = ColorTranslator.FromHtml("#C62835");
        private static readonly Color InfoTopDark = ColorTranslator.FromHtml("#1AA3B8");
        private static readonly Color InfoBottomDark = ColorTranslator.FromHtml("#12879B");
        private static readonly Color NeutralTopDark = ColorTranslator.FromHtml("#5E6272");
        private static readonly Color NeutralBottomDark = ColorTranslator.FromHtml("#4A4E5C");

        private static readonly Color BanTrongDark = ColorTranslator.FromHtml("#00C65A");
        private static readonly Color BanCoKhachDark = ColorTranslator.FromHtml("#E03A47");
        private static readonly Color BanDatTruocDark = ColorTranslator.FromHtml("#F5B041");

        private static readonly Color NenMenuDropDownDark = ColorTranslator.FromHtml("#252A3D");
        private static readonly Color NenStatusStripDark = ColorTranslator.FromHtml("#252A3D");
        private static readonly Color LuoiGridColorDark = ColorTranslator.FromHtml("#2F3652");

        // --- Light Mode ---
        private static readonly Color NenLight = ColorTranslator.FromHtml("#F4F6F9");
        private static readonly Color NenTrongHonLight = ColorTranslator.FromHtml("#F8FAFC");
        private static readonly Color TheLight = ColorTranslator.FromHtml("#FFFFFF");
        private static readonly Color VienTheLight = ColorTranslator.FromHtml("#E2E8F0");
        private static readonly Color HeaderTraiLight = ColorTranslator.FromHtml("#3B82F6");
        private static readonly Color HeaderPhaiLight = ColorTranslator.FromHtml("#6366F1");
        private static readonly Color TieuDeBangLight = ColorTranslator.FromHtml("#4F46E5");
        private static readonly Color DongLeLight = ColorTranslator.FromHtml("#F1F5F9");
        private static readonly Color DongChonLight = ColorTranslator.FromHtml("#CBD5E1");
        private static readonly Color ChuLight = ColorTranslator.FromHtml("#1E293B");
        private static readonly Color ChuPhuLight = ColorTranslator.FromHtml("#64748B");
        private static readonly Color NhanManhLight = ColorTranslator.FromHtml("#D97706");
        private static readonly Color NhanPhuLight = ColorTranslator.FromHtml("#0284C7");

        private static readonly Color PrimaryTopLight = ColorTranslator.FromHtml("#3B82F6");
        private static readonly Color PrimaryBottomLight = ColorTranslator.FromHtml("#2563EB");
        private static readonly Color SuccessTopLight = ColorTranslator.FromHtml("#10B981");
        private static readonly Color SuccessBottomLight = ColorTranslator.FromHtml("#059669");
        private static readonly Color DangerTopLight = ColorTranslator.FromHtml("#EF4444");
        private static readonly Color DangerBottomLight = ColorTranslator.FromHtml("#DC2626");
        private static readonly Color InfoTopLight = ColorTranslator.FromHtml("#06B6D4");
        private static readonly Color InfoBottomLight = ColorTranslator.FromHtml("#0891B2");
        private static readonly Color NeutralTopLight = ColorTranslator.FromHtml("#64748B");
        private static readonly Color NeutralBottomLight = ColorTranslator.FromHtml("#475569");

        private static readonly Color BanTrongLight = ColorTranslator.FromHtml("#10B981");
        private static readonly Color BanCoKhachLight = ColorTranslator.FromHtml("#EF4444");
        private static readonly Color BanDatTruocLight = ColorTranslator.FromHtml("#F59E0B");

        private static readonly Color NenMenuDropDownLight = ColorTranslator.FromHtml("#FFFFFF");
        private static readonly Color NenStatusStripLight = ColorTranslator.FromHtml("#F1F5F9");
        private static readonly Color LuoiGridColorLight = ColorTranslator.FromHtml("#E2E8F0");

        // --- Thuộc tính động theo Theme.CurrentMode ---
        public static Color Nen => CurrentMode == ThemeMode.Dark ? NenDark : NenLight;
        public static Color NenTrongHon => CurrentMode == ThemeMode.Dark ? NenTrongHonDark : NenTrongHonLight;
        public static Color The => CurrentMode == ThemeMode.Dark ? TheDark : TheLight;
        public static Color VienThe => CurrentMode == ThemeMode.Dark ? VienTheDark : VienTheLight;
        public static Color HeaderTrai => CurrentMode == ThemeMode.Dark ? HeaderTraiDark : HeaderTraiLight;
        public static Color HeaderPhai => CurrentMode == ThemeMode.Dark ? HeaderPhaiDark : HeaderPhaiLight;
        public static Color TieuDeBang => CurrentMode == ThemeMode.Dark ? TieuDeBangDark : TieuDeBangLight;
        public static Color DongLe => CurrentMode == ThemeMode.Dark ? DongLeDark : DongLeLight;
        public static Color DongChon => CurrentMode == ThemeMode.Dark ? DongChonDark : DongChonLight;
        public static Color Chu => CurrentMode == ThemeMode.Dark ? ChuDark : ChuLight;
        public static Color ChuPhu => CurrentMode == ThemeMode.Dark ? ChuPhuDark : ChuPhuLight;
        public static Color NhanManh => CurrentMode == ThemeMode.Dark ? NhanManhDark : NhanManhLight;
        public static Color NhanPhu => CurrentMode == ThemeMode.Dark ? NhanPhuDark : NhanPhuLight;

        public static Color PrimaryTop => CurrentMode == ThemeMode.Dark ? PrimaryTopDark : PrimaryTopLight;
        public static Color PrimaryBottom => CurrentMode == ThemeMode.Dark ? PrimaryBottomDark : PrimaryBottomLight;
        public static Color SuccessTop => CurrentMode == ThemeMode.Dark ? SuccessTopDark : SuccessTopLight;
        public static Color SuccessBottom => CurrentMode == ThemeMode.Dark ? SuccessBottomDark : SuccessBottomLight;
        public static Color DangerTop => CurrentMode == ThemeMode.Dark ? DangerTopDark : DangerTopLight;
        public static Color DangerBottom => CurrentMode == ThemeMode.Dark ? DangerBottomDark : DangerBottomLight;
        public static Color InfoTop => CurrentMode == ThemeMode.Dark ? InfoTopDark : InfoTopLight;
        public static Color InfoBottom => CurrentMode == ThemeMode.Dark ? InfoBottomDark : InfoBottomLight;
        public static Color NeutralTop => CurrentMode == ThemeMode.Dark ? NeutralTopDark : NeutralTopLight;
        public static Color NeutralBottom => CurrentMode == ThemeMode.Dark ? NeutralBottomDark : NeutralBottomLight;

        public static Color BanTrong => CurrentMode == ThemeMode.Dark ? BanTrongDark : BanTrongLight;
        public static Color BanCoKhach => CurrentMode == ThemeMode.Dark ? BanCoKhachDark : BanCoKhachLight;
        public static Color BanDatTruoc => CurrentMode == ThemeMode.Dark ? BanDatTruocDark : BanDatTruocLight;

        public static Color NenMenuDropDown => CurrentMode == ThemeMode.Dark ? NenMenuDropDownDark : NenMenuDropDownLight;
        public static Color NenStatusStrip => CurrentMode == ThemeMode.Dark ? NenStatusStripDark : NenStatusStripLight;
        public static Color LuoiGridColor => CurrentMode == ThemeMode.Dark ? LuoiGridColorDark : LuoiGridColorLight;

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

        #region 5. Các phương thức áp dụng kiểu từng phần tử

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

                Color textColor = b.Enabled
                    ? Color.White
                    : (CurrentMode == ThemeMode.Dark ? Color.FromArgb(140, 147, 170) : Color.FromArgb(148, 163, 184));
                TextRenderer.DrawText(g, b.Text, FontNut, clientRect, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            };
        }

        private static (Color top, Color bottom) GetButtonColors(ButtonKind kind, bool hovered, bool pressed, bool enabled)
        {
            if (!enabled)
            {
                return CurrentMode == ThemeMode.Dark
                    ? (Color.FromArgb(70, 76, 98), Color.FromArgb(55, 60, 80))
                    : (Color.FromArgb(226, 232, 240), Color.FromArgb(203, 213, 225));
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

            if (_styledControls.Contains(c))
            {
                c.Invalidate();
                return;
            }
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
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = FontTieuDeBang;
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Color selectionText = CurrentMode == ThemeMode.Dark ? Chu : ColorTranslator.FromHtml("#0F172A");

            g.DefaultCellStyle.BackColor = NenTrongHon;
            g.DefaultCellStyle.ForeColor = Chu;
            g.DefaultCellStyle.Font = FontBang;
            g.DefaultCellStyle.SelectionBackColor = DongChon;
            g.DefaultCellStyle.SelectionForeColor = selectionText;

            g.AlternatingRowsDefaultCellStyle.BackColor = DongLe;
            g.AlternatingRowsDefaultCellStyle.ForeColor = Chu;
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = DongChon;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectionText;

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

            // Cập nhật thanh cuộn tối/sáng theo theme
            EnableDarkModeScrollBars(g);
            g.Invalidate();
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
                if (txt.Multiline)
                {
                    EnableDarkModeScrollBars(txt);
                }
            }
            else if (c is ComboBox cbo)
            {
                cbo.FlatStyle = FlatStyle.Flat;
                StyleComboBox(cbo);
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

            c.Invalidate();
        }

        public static void StyleLabel(Label l, bool phu = false)
        {
            if (l == null) return;

            l.BackColor = Color.Transparent;
            l.ForeColor = phu ? ChuPhu : Chu;
        }

        public static void StyleTab(TabControl t)
        {
            if (t == null) return;

            t.DrawMode = TabDrawMode.OwnerDrawFixed;
            t.SizeMode = TabSizeMode.Fixed;
            t.ItemSize = new Size(130, 36);

            if (_styledControls.Contains(t))
            {
                foreach (TabPage tp in t.TabPages)
                {
                    tp.BackColor = Nen;
                    tp.ForeColor = Chu;
                }
                t.Invalidate();
                return;
            }
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
                    rect, isSelected ? Color.White : ChuPhu,
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

            if (_styledControls.Contains(c))
            {
                c.Invalidate();
                return;
            }
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

        #region 6. Duyệt và áp dụng toàn diện (Apply) & ToggleTheme

        public static void ToggleTheme(Form formMain)
        {
            CurrentMode = CurrentMode == ThemeMode.Dark ? ThemeMode.Light : ThemeMode.Dark;

            if (formMain == null) return;

            Apply(formMain);

            // Cập nhật màu nền vùng MDI Client
            foreach (Control c in formMain.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Nen;
                    mdiClient.Invalidate();
                    break;
                }
            }

            // Làm mới các form con MDI đang mở
            foreach (Form child in formMain.MdiChildren)
            {
                Apply(child);
                child.Invalidate(true);
            }

            formMain.Invalidate(true);
        }

        public static void Apply(Form f)
        {
            if (f == null) return;

            try
            {
                f.BackColor = Nen;
                f.ForeColor = Chu;
                f.Font = FontChinh;

                EnableDarkModeTitleBar(f);
                EnableDarkModeScrollBars(f);
                ApplyToControls(f.Controls);
                f.Invalidate(true);
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

                case ListBox lb:
                    EnableDarkModeScrollBars(lb);
                    break;

                case ListView lv:
                    EnableDarkModeScrollBars(lv);
                    break;

                case TreeView tv:
                    EnableDarkModeScrollBars(tv);
                    break;

                case Panel pnl:
                    if (pnl.BackColor == NenDark || pnl.BackColor == NenLight ||
                        pnl.BackColor == SystemColors.Control || pnl.BackColor == Color.White ||
                        pnl.BackColor == SystemColors.Window)
                    {
                        pnl.BackColor = Color.Transparent;
                    }
                    if (pnl.AutoScroll)
                    {
                        EnableDarkModeScrollBars(pnl);
                    }
                    break;
            }
        }

        private static void ApplyToLabel(Label lbl)
        {
            // Nếu nhãn nằm trên thanh header gradient, luôn giữ chữ trắng
            if (lbl.Parent != null && (lbl.Parent.Name == "pnlHeader" || lbl.Parent.Parent?.Name == "pnlHeader"))
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.White;
                return;
            }

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
            if (name.Contains("reset") || name.Contains("datlai") || name.Contains("in") || name.Contains("theme"))
                return ButtonKind.Info;

            return ButtonKind.Primary;
        }

        #endregion

        #region 7. Hỗ trợ Dark Mode / Light Mode hệ thống (DWM, UxTheme) & ComboBox

        public static void StyleComboBox(ComboBox cbo)
        {
            if (cbo == null) return;

            cbo.DrawMode = DrawMode.OwnerDrawFixed;
            cbo.ItemHeight = 26;

            EnableDarkModeScrollBars(cbo);

            if (_styledControls.Contains(cbo))
            {
                cbo.Invalidate();
                return;
            }
            _styledControls.Add(cbo);
            cbo.Disposed += (s, e) => _styledControls.Remove(cbo);

            cbo.DropDown += (s, e) =>
            {
                try
                {
                    var info = new COMBOBOXINFO { cbSize = Marshal.SizeOf<COMBOBOXINFO>() };
                    if (GetComboBoxInfo(cbo.Handle, ref info) && info.hwndList != IntPtr.Zero)
                    {
                        ApplyDarkModeToHandle(info.hwndList);
                    }
                }
                catch
                {
                    // Bỏ qua nếu lỗi Win32
                }
            };

            cbo.DrawItem += (s, e) =>
            {
                Graphics g = e.Graphics;
                if (e.Index < 0)
                {
                    using var emptyBrush = new SolidBrush(NenTrongHon);
                    g.FillRectangle(emptyBrush, e.Bounds);
                    return;
                }

                g.SmoothingMode = SmoothingMode.AntiAlias;

                bool isEditPortion = (e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit;
                bool isSelected = !isEditPortion && ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
                Color bg = isSelected ? DongChon : NenTrongHon;

                using (var bgBrush = new SolidBrush(bg))
                {
                    g.FillRectangle(bgBrush, e.Bounds);
                }

                string text = cbo.GetItemText(cbo.Items[e.Index]) ?? string.Empty;
                Rectangle textRect = new(e.Bounds.X + 6, e.Bounds.Y, Math.Max(0, e.Bounds.Width - 10), e.Bounds.Height);
                Color textColor = (CurrentMode == ThemeMode.Light && isSelected) ? ColorTranslator.FromHtml("#0F172A") : Chu;
                TextRenderer.DrawText(g, text, cbo.Font ?? FontChinh, textRect, textColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            };
        }

        public static void EnableDarkModeScrollBars(Control control)
        {
            if (control == null) return;

            if (control.IsHandleCreated)
            {
                ApplyDarkModeToHandle(control.Handle);
            }
            control.HandleCreated -= Control_HandleCreated;
            control.HandleCreated += Control_HandleCreated;
        }

        private static void Control_HandleCreated(object? sender, EventArgs e)
        {
            if (sender is Control c && c.IsHandleCreated)
            {
                ApplyDarkModeToHandle(c.Handle);
            }
        }

        public static void EnableDarkModeTitleBar(Form form)
        {
            if (form == null) return;

            if (form.IsHandleCreated)
            {
                ApplyDarkModeToHandle(form.Handle);
            }
            form.HandleCreated -= Form_HandleCreated;
            form.HandleCreated += Form_HandleCreated;
        }

        private static void Form_HandleCreated(object? sender, EventArgs e)
        {
            if (sender is Form f && f.IsHandleCreated)
            {
                ApplyDarkModeToHandle(f.Handle);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
        }

        [DllImport("user32.dll")]
        private static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string? pszSubIdList);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public static void ApplyDarkModeToHandle(IntPtr handle)
        {
            ApplyDarkModeToHandle(handle, CurrentMode == ThemeMode.Dark);
        }

        public static void ApplyDarkModeToHandle(IntPtr handle, bool isDark)
        {
            if (handle == IntPtr.Zero) return;

            try
            {
                // Bật/tắt tiêu đề tối qua DWM (Windows 10/11)
                int darkMode = isDark ? 1 : 0;
                int hr = DwmSetWindowAttribute(handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref darkMode, sizeof(int));
                if (hr != 0)
                {
                    DwmSetWindowAttribute(handle, DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref darkMode, sizeof(int));
                }

                // Chuyển thanh cuộn Win32 sang Explorer / DarkMode_Explorer
                if (isDark)
                {
                    SetWindowTheme(handle, "DarkMode_Explorer", null);
                }
                else
                {
                    SetWindowTheme(handle, "Explorer", null);
                }
            }
            catch
            {
                // Bỏ qua nếu chạy trên nền tảng/phiên bản Windows không hỗ trợ
            }
        }

        #endregion
    }
}

