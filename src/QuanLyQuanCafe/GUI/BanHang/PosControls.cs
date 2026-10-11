using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.BanHang
{
    #region 1. POS Design Tokens & Drawing Helpers

    public static class PosTokens
    {
        public const int RadiusCard = 12;
        public const int RadiusInput = 8;
        public const int RadiusPill = 999;
    }

    public static class PosPalette
    {
        // Light Theme: Warm Cream
        public static readonly Color AppBg = Color.FromArgb(247, 244, 239);       // #F7F4EF
        public static readonly Color CardBg = Color.FromArgb(255, 255, 255);      // #FFFFFF
        public static readonly Color CardSubtle = Color.FromArgb(244, 239, 234);  // #F4EFEA
        public static readonly Color CardHover = Color.FromArgb(250, 247, 242);   // #FAF7F2
        public static readonly Color Border = Color.FromArgb(232, 226, 217);      // #E8E2D9
        public static readonly Color BorderHover = Color.FromArgb(210, 200, 188); // #D2C8BC

        // Brand colors
        public static readonly Color Primary = Color.FromArgb(139, 94, 60);       // #8B5E3C Nâu Cafe ấm
        public static readonly Color PrimaryHover = Color.FromArgb(116, 75, 46);  // #744B2E
        public static readonly Color PrimaryLight = Color.FromArgb(245, 238, 230); // #F5EEE6
        public static readonly Color AccentSuccess = Color.FromArgb(47, 125, 91); // #2F7D5B Xanh thanh toán
        public static readonly Color AccentSuccessHover = Color.FromArgb(39, 106, 77);
        public static readonly Color AccentSuccessLight = Color.FromArgb(231, 245, 238);

        // Typography colors
        public static readonly Color TextMain = Color.FromArgb(43, 36, 32);       // #2B2420
        public static readonly Color TextMuted = Color.FromArgb(122, 111, 102);   // #7A6F66
        public static readonly Color TextDisabled = Color.FromArgb(184, 175, 166);// #B8AFA6

        // Table status pastel colors
        public static readonly Color TableEmptyBg = Color.FromArgb(231, 245, 238);     // #E7F5EE
        public static readonly Color TableEmptyBorder = Color.FromArgb(154, 211, 181); // #9AD3B5
        public static readonly Color TableEmptyText = Color.FromArgb(31, 107, 71);     // #1F6B47
        public static readonly Color TableEmptyDot = Color.FromArgb(16, 185, 129);     // #10B981

        public static readonly Color TableOccupiedBg = Color.FromArgb(253, 235, 231);    // #FDEBE7
        public static readonly Color TableOccupiedBorder = Color.FromArgb(242, 169, 154);// #F2A99A
        public static readonly Color TableOccupiedText = Color.FromArgb(168, 64, 44);    // #A8402C
        public static readonly Color TableOccupiedDot = Color.FromArgb(239, 68, 68);     // #EF4444

        public static readonly Color TableReservedBg = Color.FromArgb(255, 244, 220);    // #FFF4DC
        public static readonly Color TableReservedBorder = Color.FromArgb(240, 203, 122);// #F0CB7A
        public static readonly Color TableReservedText = Color.FromArgb(146, 93, 8);     // #925D08
        public static readonly Color TableReservedDot = Color.FromArgb(245, 158, 11);    // #F59E0B

        // Fonts
        public static readonly Font FontTitle = new("Segoe UI", 11.5F, FontStyle.Bold);
        public static readonly Font FontBodyBold = new("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontBody = new("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font FontCaption = new("Segoe UI", 8.25F, FontStyle.Regular);
        public static readonly Font FontBadge = new("Segoe UI", 8F, FontStyle.Bold);
        public static readonly Font FontPrice = new("Segoe UI", 10.5F, FontStyle.Bold);

        public static GraphicsPath CreateRoundedPath(Rectangle r, int radius)
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

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static GraphicsPath CreateTopRoundedPath(Rectangle r, int radius)
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

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddLine(r.Right, r.Bottom, r.X, r.Bottom);
            path.CloseFigure();
            return path;
        }

        public static void DrawCoffeePlaceholder(Graphics g, Rectangle r)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Nền gradient pastel nhẹ
            using (var br = new LinearGradientBrush(r, Color.FromArgb(249, 245, 239), Color.FromArgb(238, 231, 222), LinearGradientMode.Vertical))
            {
                g.FillRectangle(br, r);
            }

            // Vẽ minh họa ly cà phê thanh lịch bằng nét vector
            int cx = r.X + r.Width / 2;
            int cy = r.Y + r.Height / 2 + 2;

            using var penSaucer = new Pen(Color.FromArgb(196, 184, 172), 1.8F);
            using var penCup = new Pen(Color.FromArgb(139, 94, 60), 2F);
            using var penSteam = new Pen(Color.FromArgb(184, 155, 130), 1.4F) { DashStyle = DashStyle.Dot };
            using var brushCoffee = new SolidBrush(Color.FromArgb(107, 72, 47));

            // Đĩa lót (Saucer)
            g.DrawEllipse(penSaucer, cx - 22, cy + 12, 44, 8);

            // Thân ly (Cup)
            var cupRect = new Rectangle(cx - 16, cy - 8, 32, 22);
            using var cupPath = new GraphicsPath();
            cupPath.AddArc(cupRect.X, cupRect.Y + 4, 12, 12, 90, 90);
            cupPath.AddLine(cupRect.X, cupRect.Y, cupRect.Right, cupRect.Y);
            cupPath.AddArc(cupRect.Right - 12, cupRect.Y + 4, 12, 12, 0, 90);
            cupPath.CloseFigure();
            g.DrawPath(penCup, cupPath);

            // Nước cà phê bên trong miệng ly
            g.FillEllipse(brushCoffee, cx - 14, cy - 10, 28, 6);

            // Quai ly (Handle)
            g.DrawArc(penCup, cx + 13, cy - 5, 9, 12, 270, 180);

            // Làn khói tỏa nhẹ (Steam)
            g.DrawBezier(penSteam, new Point(cx - 5, cy - 13), new Point(cx - 8, cy - 18), new Point(cx - 2, cy - 22), new Point(cx - 5, cy - 27));
            g.DrawBezier(penSteam, new Point(cx + 4, cy - 14), new Point(cx + 7, cy - 19), new Point(cx + 2, cy - 23), new Point(cx + 5, cy - 28));
        }
    }

    #endregion

    #region 2. PosTableCard - Thẻ bàn trực quan & thông minh

    public class PosTableCard : Control
    {
        private BanDTO _ban;
        private bool _isSelected;
        private decimal _tamTinh;
        private int _phutNgoi;
        private bool _isHovered;

        public BanDTO Ban => _ban;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    Invalidate();
                }
            }
        }

        public decimal TamTinh
        {
            get => _tamTinh;
            set
            {
                if (_tamTinh != value)
                {
                    _tamTinh = value;
                    Invalidate();
                }
            }
        }

        public int PhutNgoi
        {
            get => _phutNgoi;
            set
            {
                if (_phutNgoi != value)
                {
                    _phutNgoi = value;
                    Invalidate();
                }
            }
        }

        public PosTableCard(BanDTO ban)
        {
            _ban = ban;
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Size = new Size(130, 98);
            Margin = new Padding(6);
            Cursor = Cursors.Hand;
            Tag = "NoTheme";
        }

        public void CapNhatThongTin(BanDTO ban, decimal tamTinh = 0, int phutNgoi = 0)
        {
            _ban = ban;
            _tamTinh = tamTinh;
            _phutNgoi = phutNgoi;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new(1, 1, Width - 3, Height - 3);

            // Xác định màu trạng thái
            Color bgColor, borderColor, textColor, dotColor;
            string statusText;

            if (_ban.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase))
            {
                bgColor = PosPalette.TableOccupiedBg;
                borderColor = PosPalette.TableOccupiedBorder;
                textColor = PosPalette.TableOccupiedText;
                dotColor = PosPalette.TableOccupiedDot;
                statusText = "Có khách";
            }
            else if (_ban.TrangThai.Equals("DATTRUOC", StringComparison.OrdinalIgnoreCase))
            {
                bgColor = PosPalette.TableReservedBg;
                borderColor = PosPalette.TableReservedBorder;
                textColor = PosPalette.TableReservedText;
                dotColor = PosPalette.TableReservedDot;
                statusText = "Đặt trước";
            }
            else
            {
                bgColor = PosPalette.TableEmptyBg;
                borderColor = PosPalette.TableEmptyBorder;
                textColor = PosPalette.TableEmptyText;
                dotColor = PosPalette.TableEmptyDot;
                statusText = "Trống";
            }

            // Nền thẻ
            using (var path = PosPalette.CreateRoundedPath(rect, PosTokens.RadiusCard))
            {
                // Nếu được chọn hoặc hover: tăng độ nổi bật
                if (_isSelected)
                {
                    bgColor = Color.FromArgb(255, 255, 255);
                    borderColor = PosPalette.Primary;
                }
                else if (_isHovered)
                {
                    borderColor = Color.FromArgb(
                        Math.Max(0, borderColor.R - 25),
                        Math.Max(0, borderColor.G - 25),
                        Math.Max(0, borderColor.B - 25));
                }

                using (var brush = new SolidBrush(bgColor))
                {
                    g.FillPath(brush, path);
                }

                // Viền thẻ
                float borderWidth = _isSelected ? 2.5F : 1.2F;
                using (var pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(pen, path);
                }
            }

            // Dòng 1: Tên bàn (trái) + Badge trạng thái (phải)
            string tenBan = $"BÀN {(_ban.SoBan < 10 ? "0" : "")}{_ban.SoBan}";
            using (var fontName = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (var brText = new SolidBrush(PosPalette.TextMain))
            {
                g.DrawString(tenBan, fontName, brText, new PointF(10, 8));
            }

            // Badge trạng thái nhỏ gọn có chấm màu
            int badgeW = 66, badgeH = 20;
            Rectangle badgeRect = new(Width - badgeW - 10, 8, badgeW, badgeH);
            using (var badgePath = PosPalette.CreateRoundedPath(badgeRect, 10))
            using (var badgeBrush = new SolidBrush(Color.FromArgb(240, 255, 255, 255)))
            using (var badgePen = new Pen(borderColor, 1F))
            {
                g.FillPath(badgeBrush, badgePath);
                g.DrawPath(badgePen, badgePath);
            }

            // Chấm màu trạng thái
            using (var brDot = new SolidBrush(dotColor))
            {
                g.FillEllipse(brDot, badgeRect.X + 6, badgeRect.Y + 6, 8, 8);
            }
            // Chữ trạng thái
            using (var brStatus = new SolidBrush(textColor))
            {
                g.DrawString(statusText, PosPalette.FontBadge, brStatus, new PointF(badgeRect.X + 17, badgeRect.Y + 3));
            }

            // Dòng 2: Vị trí & Số chỗ ngồi (vd: "Tầng trệt · 4 chỗ")
            string viTriInfo = $"{_ban.TenViTri} · {_ban.SoChoNgoi} chỗ";
            using (var brMuted = new SolidBrush(PosPalette.TextMuted))
            {
                g.DrawString(viTriInfo, PosPalette.FontCaption, brMuted, new PointF(10, 32));
            }

            // Đường kẻ phân tách mảnh
            using (var penLine = new Pen(Color.FromArgb(30, 0, 0, 0), 0.8F))
            {
                g.DrawLine(penLine, 10, 52, Width - 10, 52);
            }

            // Dòng 3: Bàn có khách hiển thị Tạm tính & Thời gian ngồi
            if (_ban.TrangThai.Equals("COKHACH", StringComparison.OrdinalIgnoreCase))
            {
                string tienStr = _tamTinh > 0 ? $"{_tamTinh:#,##0} đ" : "Đang gọi món...";
                using (var brTien = new SolidBrush(PosPalette.Primary))
                using (var fontTien = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                {
                    g.DrawString(tienStr, fontTien, brTien, new PointF(10, 58));
                }

                if (_phutNgoi > 0)
                {
                    string tgStr = $"🕒 {_phutNgoi}p";
                    using (var brTg = new SolidBrush(PosPalette.TextMuted))
                    {
                        var sizeTg = g.MeasureString(tgStr, PosPalette.FontCaption);
                        g.DrawString(tgStr, PosPalette.FontCaption, brTg, new PointF(Width - sizeTg.Width - 10, 60));
                    }
                }
            }
            else
            {
                // Bàn trống hiển thị hướng dẫn thân thiện
                using (var brSanSang = new SolidBrush(PosPalette.TableEmptyText))
                {
                    g.DrawString("✓ Sẵn sàng đón khách", PosPalette.FontCaption, brSanSang, new PointF(10, 60));
                }
            }

            // Dấu Tick đánh dấu bàn đang được chọn
            if (_isSelected)
            {
                using var brTickBg = new SolidBrush(PosPalette.Primary);
                g.FillEllipse(brTickBg, Width - 18, Height - 18, 14, 14);
                using var penTick = new Pen(Color.White, 1.8F);
                g.DrawLines(penTick, new[] {
                    new Point(Width - 14, Height - 11),
                    new Point(Width - 11, Height - 8),
                    new Point(Width - 7, Height - 14)
                });
            }
        }
    }

    #endregion

    #region 3. PosDrinkCard - Thẻ món nước trực quan với ảnh / icon placeholder

    public class PosDrinkCard : Control
    {
        private ThucUongDTO _thucUong;
        private int _soLuongTrongDon;
        private bool _isHovered;
        private bool _isPressed;
        private Rectangle _btnPlusRect;

        public event EventHandler<ThucUongDTO>? DrinkClicked;
        public event EventHandler<ThucUongDTO>? QuickPlusClicked;

        public ThucUongDTO ThucUong => _thucUong;

        public int SoLuongTrongDon
        {
            get => _soLuongTrongDon;
            set
            {
                if (_soLuongTrongDon != value)
                {
                    _soLuongTrongDon = value;
                    Invalidate();
                }
            }
        }

        public PosDrinkCard(ThucUongDTO thucUong)
        {
            _thucUong = thucUong;
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Size = new Size(156, 190);
            Margin = new Padding(6);
            Cursor = Cursors.Hand;
            Tag = "NoTheme";
        }

        public void CapNhatThucUong(ThucUongDTO thucUong, int soLuongTrongDon = 0)
        {
            _thucUong = thucUong;
            _soLuongTrongDon = soLuongTrongDon;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            _isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = true;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isPressed = false;
            Invalidate();

            if (e.Button == MouseButtons.Left)
            {
                if (_btnPlusRect.Contains(e.Location))
                {
                    QuickPlusClicked?.Invoke(this, _thucUong);
                }
                else
                {
                    DrinkClicked?.Invoke(this, _thucUong);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new(1, 1, Width - 3, Height - 3);

            // Nền thẻ card
            Color cardBg = _isPressed ? PosPalette.CardSubtle : (_isHovered ? PosPalette.CardHover : PosPalette.CardBg);
            Color borderColor = _isHovered ? PosPalette.Primary : PosPalette.Border;

            using (var path = PosPalette.CreateRoundedPath(rect, PosTokens.RadiusCard))
            {
                // Đổ bóng mềm nếu hover
                if (_isHovered)
                {
                    using var shadowPen = new Pen(Color.FromArgb(18, 0, 0, 0), 3F);
                    g.DrawPath(shadowPen, path);
                }

                using (var brush = new SolidBrush(cardBg))
                {
                    g.FillPath(brush, path);
                }

                using (var pen = new Pen(borderColor, _isHovered ? 1.5F : 1F))
                {
                    g.DrawPath(pen, path);
                }
            }

            // Vùng hình ảnh đại diện (Top ~100px)
            int imgH = 96;
            Rectangle imgRect = new(rect.X, rect.Y, rect.Width, imgH);
            using (var topPath = PosPalette.CreateTopRoundedPath(imgRect, PosTokens.RadiusCard))
            {
                g.SetClip(topPath);
                // Vẽ placeholder cà phê nét đẹp, sạch
                PosPalette.DrawCoffeePlaceholder(g, imgRect);
                g.ResetClip();

                // Đường viền ngăn cách ảnh và nội dung
                using var pDivider = new Pen(PosPalette.Border, 0.8F);
                g.DrawLine(pDivider, rect.X, imgRect.Bottom, rect.Right, imgRect.Bottom);
            }

            // Nút tròn "+" nhanh ở góc trên phải ảnh
            int plusSize = 28;
            _btnPlusRect = new Rectangle(Width - plusSize - 8, 8, plusSize, plusSize);
            using (var brPlus = new SolidBrush(_isHovered ? PosPalette.PrimaryHover : PosPalette.Primary))
            {
                g.FillEllipse(brPlus, _btnPlusRect);
            }
            using (var penPlus = new Pen(Color.White, 2F))
            {
                int cx = _btnPlusRect.X + plusSize / 2;
                int cy = _btnPlusRect.Y + plusSize / 2;
                g.DrawLine(penPlus, cx - 6, cy, cx + 6, cy);
                g.DrawLine(penPlus, cx, cy - 6, cx, cy + 6);
            }

            // Badge hiển thị số lượng đã gọi trong đơn (nếu có) ở góc trên trái
            if (_soLuongTrongDon > 0)
            {
                string badgeStr = $"{_soLuongTrongDon} ly";
                var badgeSize = g.MeasureString(badgeStr, PosPalette.FontBadge);
                Rectangle bRect = new(8, 8, (int)badgeSize.Width + 12, 22);
                using var bPath = PosPalette.CreateRoundedPath(bRect, 11);
                using var brBadge = new SolidBrush(PosPalette.AccentSuccess);
                using var penBadge = new Pen(Color.White, 1F);
                g.FillPath(brBadge, bPath);
                g.DrawPath(penBadge, bPath);

                using var brBadgeText = new SolidBrush(Color.White);
                g.DrawString(badgeStr, PosPalette.FontBadge, brBadgeText, new PointF(bRect.X + 6, bRect.Y + 4));
            }

            // Phần nội dung bên dưới
            int contentY = imgH + 8;

            // Nhóm món nước (Caps nhỏ)
            string nhomStr = string.IsNullOrWhiteSpace(_thucUong.TenLoaiTU) ? "THỨC UỐNG" : _thucUong.TenLoaiTU.ToUpper();
            using (var brMuted = new SolidBrush(PosPalette.TextMuted))
            {
                g.DrawString(nhomStr, PosPalette.FontBadge, brMuted, new PointF(10, contentY));
            }

            // Tên món nước (Bold, wrap tối đa 2 dòng)
            int nameY = contentY + 16;
            Rectangle nameRect = new(10, nameY, Width - 20, 38);
            using (var brName = new SolidBrush(PosPalette.TextMain))
            {
                var sf = new StringFormat
                {
                    Trimming = StringTrimming.EllipsisWord,
                    FormatFlags = StringFormatFlags.LineLimit
                };
                g.DrawString(_thucUong.TenThucUong, PosPalette.FontBodyBold, brName, nameRect, sf);
            }

            // Giá bán (To, rõ ràng, màu Nâu Primary, định dạng tiền tệ đẹp)
            int priceY = Height - 26;
            string giaStr = $"{_thucUong.DonGiaBan:#,##0} đ";
            using (var brPrice = new SolidBrush(PosPalette.Primary))
            {
                g.DrawString(giaStr, PosPalette.FontPrice, brPrice, new PointF(10, priceY));
            }
        }
    }

    #endregion

    #region 4. PosChipButton - Nút lọc 1 chạm (Segmented Chip Filter)

    public class PosChipButton : Control
    {
        private bool _isActive;
        private bool _isHovered;
        private string _countBadge = "";

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    Invalidate();
                }
            }
        }

        public string CountBadge
        {
            get => _countBadge;
            set
            {
                if (_countBadge != value)
                {
                    _countBadge = value;
                    Invalidate();
                }
            }
        }

        public PosChipButton(string text, bool isActive = false, string countBadge = "")
        {
            Text = text;
            _isActive = isActive;
            _countBadge = countBadge;

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Height = 34;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
            Tag = "NoTheme";
            CapNhatKichThuoc();
        }

        public void CapNhatKichThuoc()
        {
            using var g = CreateGraphics();
            string full = Text + (string.IsNullOrWhiteSpace(_countBadge) ? "" : $" ({_countBadge})");
            var sz = g.MeasureString(full, Font);
            Width = Math.Max(70, (int)sz.Width + 24);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CapNhatKichThuoc();
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new(1, 1, Width - 3, Height - 3);

            Color bgColor, borderColor, textColor;
            if (_isActive)
            {
                bgColor = PosPalette.Primary;
                borderColor = PosPalette.Primary;
                textColor = Color.White;
            }
            else if (_isHovered)
            {
                bgColor = PosPalette.CardSubtle;
                borderColor = PosPalette.BorderHover;
                textColor = PosPalette.TextMain;
            }
            else
            {
                bgColor = Color.White;
                borderColor = PosPalette.Border;
                textColor = PosPalette.TextMuted;
            }

            using (var path = PosPalette.CreateRoundedPath(rect, Height / 2))
            {
                using (var brush = new SolidBrush(bgColor))
                {
                    g.FillPath(brush, path);
                }
                using (var pen = new Pen(borderColor, 1F))
                {
                    g.DrawPath(pen, path);
                }
            }

            string displayText = Text;
            if (!string.IsNullOrWhiteSpace(_countBadge))
            {
                displayText += $" {_countBadge}";
            }

            using var fontDraw = new Font(Font, _isActive ? FontStyle.Bold : FontStyle.Regular);
            using var brText = new SolidBrush(textColor);
            var sz = g.MeasureString(displayText, fontDraw);
            g.DrawString(displayText, fontDraw, brText, new PointF((Width - sz.Width) / 2, (Height - sz.Height) / 2));
        }
    }

    #endregion

    #region 5. PosEmptyState - Minh họa khi không tìm thấy kết quả

    public class PosEmptyState : Control
    {
        private string _tieuDe = "Không tìm thấy kết quả";
        private string _phuDe = "Vui lòng thử từ khóa khác hoặc xóa bộ lọc";

        public PosEmptyState(string tieuDe, string phuDe = "")
        {
            _tieuDe = tieuDe;
            _phuDe = phuDe;

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            Dock = DockStyle.Fill;
            Tag = "NoTheme";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = Width / 2;
            int cy = Height / 2 - 20;

            // Vòng tròn xám nhạt với icon kính lúp
            using (var brCircle = new SolidBrush(PosPalette.CardSubtle))
            {
                g.FillEllipse(brCircle, cx - 30, cy - 30, 60, 60);
            }

            using (var penIcon = new Pen(PosPalette.TextMuted, 2.5F))
            {
                g.DrawEllipse(penIcon, cx - 14, cy - 14, 18, 18);
                g.DrawLine(penIcon, cx + 1, cy + 1, cx + 12, cy + 12);
            }

            // Tiêu đề
            using (var brTitle = new SolidBrush(PosPalette.TextMain))
            using (var fTitle = new Font("Segoe UI", 11F, FontStyle.Bold))
            {
                var sz = g.MeasureString(_tieuDe, fTitle);
                g.DrawString(_tieuDe, fTitle, brTitle, new PointF(cx - sz.Width / 2, cy + 42));
            }

            // Phụ đề
            if (!string.IsNullOrWhiteSpace(_phuDe))
            {
                using var brSub = new SolidBrush(PosPalette.TextMuted);
                var szSub = g.MeasureString(_phuDe, PosPalette.FontCaption);
                g.DrawString(_phuDe, PosPalette.FontCaption, brSub, new PointF(cx - szSub.Width / 2, cy + 66));
            }
        }
    }

    #endregion
}
