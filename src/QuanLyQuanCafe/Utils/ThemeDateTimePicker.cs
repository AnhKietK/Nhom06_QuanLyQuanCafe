namespace QuanLyQuanCafe.Utils;

public class ThemeDateTimePicker : DateTimePicker
{
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        const int WM_PAINT = 0x000F, WM_PRINT = 0x0317, WM_PRINTCLIENT = 0x0318;
        if (m.Msg is not (WM_PAINT or WM_PRINT or WM_PRINTCLIENT) || Width < 2 || Height < 2) return;
        using var g = m.Msg != WM_PAINT && m.WParam != IntPtr.Zero
            ? Graphics.FromHdc(m.WParam) : Graphics.FromHwnd(Handle);
        using var background = new SolidBrush(Theme.NenTrongHon);
        using var border = new Pen(Focused ? Theme.PrimaryTop : Theme.VienThe);
        g.FillRectangle(background, ClientRectangle);
        g.DrawRectangle(border, 0, 0, Width - 1, Height - 1);
        int left = LogicalToDeviceUnits(6), arrowWidth = LogicalToDeviceUnits(24);
        if (ShowCheckBox)
        {
            int size = LogicalToDeviceUnits(13);
            var check = new Rectangle(left, (Height - size) / 2, size, size);
            g.DrawRectangle(border, check);
            if (Checked)
            {
                using var tick = new Pen(Theme.NhanPhu, 2);
                g.DrawLines(tick, new[] { new Point(check.Left + 2, check.Top + size / 2),
                    new Point(check.Left + size / 2, check.Bottom - 3), new Point(check.Right - 2, check.Top + 3) });
            }
            left += size + LogicalToDeviceUnits(6);
        }
        var textRect = new Rectangle(left, 1, Math.Max(0, Width - left - arrowWidth), Height - 2);
        TextRenderer.DrawText(g, Text, Font, textRect, Enabled && (!ShowCheckBox || Checked) ? Theme.Chu : Theme.ChuPhu,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        using var arrow = new Pen(Theme.ChuPhu, 1.5F);
        int x = Width - arrowWidth / 2, y = Height / 2;
        g.DrawLines(arrow, new[] { new Point(x - 4, y - 2), new Point(x, y + 2), new Point(x + 4, y - 2) });
        if (Focused && ShowFocusCues) ControlPaint.DrawFocusRectangle(g, textRect, Theme.Chu, Theme.NenTrongHon);
    }
}
