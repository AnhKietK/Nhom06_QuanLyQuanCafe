using System.Drawing.Drawing2D;

namespace QuanLyQuanCafe.Utils;

public class ThemeTabControl : TabControl
{
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        const int WM_PAINT = 0x000F, WM_PRINT = 0x0317, WM_PRINTCLIENT = 0x0318;
        if (m.Msg is not (WM_PAINT or WM_PRINT or WM_PRINTCLIENT) || Width < 2 || Height < 2 || Alignment != TabAlignment.Top)
            return;
        using var g = m.Msg != WM_PAINT && m.WParam != IntPtr.Zero
            ? Graphics.FromHdc(m.WParam) : Graphics.FromHwnd(Handle);
        using var background = new SolidBrush(Theme.Nen);
        g.FillRectangle(background, new Rectangle(0, 0, Width, DisplayRectangle.Top));
        g.SmoothingMode = SmoothingMode.AntiAlias;
        for (int i = 0; i < TabPages.Count; i++)
        {
            var rect = GetTabRect(i);
            bool selected = SelectedIndex == i;
            using var fill = new SolidBrush(selected ? Theme.PrimaryBottom : Theme.Nen);
            using var path = Theme.RoundedRect(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4), 8);
            g.FillPath(fill, path);
            TextRenderer.DrawText(g, TabPages[i].Text, selected ? Theme.FontNut : Theme.FontNhan, rect,
                selected ? Color.White : Theme.ChuPhu,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            if (selected && Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(g, Rectangle.Inflate(rect, -5, -5), Theme.Chu, Theme.PrimaryBottom);
        }
        using var border = new Pen(Theme.VienThe);
        g.DrawRectangle(border, 0, DisplayRectangle.Top - 1, Width - 1, Math.Max(0, Height - DisplayRectangle.Top));
    }
}
