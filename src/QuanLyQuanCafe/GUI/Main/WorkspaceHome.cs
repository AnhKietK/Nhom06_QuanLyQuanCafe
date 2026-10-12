using System.Drawing.Drawing2D;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Main;

// A navigation surface only: no data queries or changes to module behavior.
internal sealed class WorkspaceHome : Panel
{
    private readonly List<Button> tiles = new();
    private readonly Font headingFont = new("Segoe UI", 26F, FontStyle.Bold);
    private readonly Font smallFont = new("Segoe UI", 10F);
    private readonly Font tileFont = new("Segoe UI", 12F, FontStyle.Bold);

    public WorkspaceHome(IEnumerable<FormMain.MenuConfigItem> modules, Action<FormMain.MenuConfigItem> open)
    {
        Dock = DockStyle.Fill;
        AutoScroll = true;
        Tag = "NoTheme";
        DoubleBuffered = true;
        foreach (var module in modules)
        {
            var tile = new Button
            {
                Text = module.TenMuc, AccessibleName = module.TenMuc,
                Tag = "NoTheme", FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand, Font = tileFont,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tile.FlatAppearance.BorderSize = 0;
            bool hovered = false;
            tile.MouseEnter += (_, _) => { hovered = true; tile.Invalidate(); };
            tile.MouseLeave += (_, _) => { hovered = false; tile.Invalidate(); };
            tile.Paint += (_, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Theme.Nen);
                var rect = new Rectangle(0, 0, tile.Width - 1, tile.Height - 1);
                using var path = Theme.RoundedRect(rect, 14);
                using var fill = new SolidBrush(hovered ? Theme.DongLe : Theme.The);
                using var border = new Pen(hovered || tile.Focused ? Theme.PrimaryTop : Theme.VienThe);
                g.FillPath(fill, path);
                g.DrawPath(border, path);
                TextRenderer.DrawText(g, module.Nhom.ToUpperInvariant(), smallFont,
                    new Rectangle(20, 14, tile.Width - 70, 24), Theme.ChuPhu,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                TextRenderer.DrawText(g, module.TenMuc, tileFont,
                    new Rectangle(20, 41, tile.Width - 66, 38), Theme.Chu,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                TextRenderer.DrawText(g, "→", tileFont,
                    new Rectangle(tile.Width - 44, 36, 28, 40), Theme.NhanPhu,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            };
            tile.Click += (_, _) => open(module);
            tiles.Add(tile);
            Controls.Add(tile);
        }
    }

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        if (tiles == null) return;
        int columns = ClientSize.Width >= 1080 ? 3 : ClientSize.Width >= 680 ? 2 : 1;
        int available = Math.Max(240, ClientSize.Width - 80);
        int width = (available - (columns - 1) * 16) / columns;
        for (int i = 0; i < tiles.Count; i++)
            tiles[i].Bounds = new Rectangle(32 + i % columns * (width + 16),
                248 + i / columns * 116, width, 100);
        AutoScrollMinSize = new Size(0, 280 + (int)Math.Ceiling(tiles.Count / (double)columns) * 116);
        Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs e) => e.Graphics.Clear(Theme.Nen);

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        var hero = new Rectangle(32, 24, Math.Max(240, ClientSize.Width - 80), 180);
        using var path = Theme.RoundedRect(hero, 20);
        using var brush = new LinearGradientBrush(hero, Theme.HeaderTrai, Theme.HeaderPhai, 0F);
        g.FillPath(brush, path);
        TextRenderer.DrawText(g, "NHÓM 06  /  COFFEE WORKSPACE", smallFont,
            new Rectangle(58, 44, hero.Width - 48, 26), Color.White,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        var name = string.IsNullOrWhiteSpace(CurrentUser.TenNV) ? "bạn" : CurrentUser.TenNV;
        TextRenderer.DrawText(g, $"Xin chào, {name}", headingFont,
            new Rectangle(54, 79, hero.Width - 48, 54), Color.White,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        TextRenderer.DrawText(g, "Sẵn sàng cho một ngày làm việc hiệu quả.", smallFont,
            new Rectangle(58, 143, hero.Width - 48, 30), Color.White,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        TextRenderer.DrawText(g, "Không gian làm việc", tileFont,
            new Rectangle(32, 214, hero.Width / 2, 28), Theme.Chu,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        TextRenderer.DrawText(g, DateTime.Now.ToString("dd / MM / yyyy"), smallFont,
            new Rectangle(32 + hero.Width / 2, 214, hero.Width / 2, 28), Theme.ChuPhu,
            TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
        g.ResetTransform();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) { headingFont.Dispose(); smallFont.Dispose(); tileFont.Dispose(); }
        base.Dispose(disposing);
    }
}
