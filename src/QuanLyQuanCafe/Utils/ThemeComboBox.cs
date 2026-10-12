namespace QuanLyQuanCafe.Utils;

// Keep the native dropdown, data binding and keyboard behavior; theme its collapsed face.
public class ThemeComboBox : ComboBox
{
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        const int WM_PAINT = 0x000F, WM_PRINT = 0x0317, WM_PRINTCLIENT = 0x0318;
        if (DropDownStyle != ComboBoxStyle.DropDownList ||
            m.Msg is not (WM_PAINT or WM_PRINT or WM_PRINTCLIENT) || Width < 2 || Height < 2)
            return;

        using var graphics = m.Msg != WM_PAINT && m.WParam != IntPtr.Zero
            ? Graphics.FromHdc(m.WParam) : Graphics.FromHwnd(Handle);
        using var background = new SolidBrush(Theme.NenTrongHon);
        using var border = new Pen(Focused ? Theme.PrimaryTop : Theme.VienThe);
        graphics.FillRectangle(background, ClientRectangle);
        graphics.DrawRectangle(border, 0, 0, Width - 1, Height - 1);
        int arrowWidth = LogicalToDeviceUnits(24);
        int padding = LogicalToDeviceUnits(6);
        var textRect = new Rectangle(padding, 1, Math.Max(0, Width - arrowWidth - padding * 2), Height - 2);
        var text = SelectedItem == null ? Text : GetItemText(SelectedItem);
        TextRenderer.DrawText(graphics, text, Font, textRect, Enabled ? Theme.Chu : Theme.ChuPhu,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        int centerX = Width - arrowWidth / 2, centerY = Height / 2;
        using var arrow = new Pen(Theme.ChuPhu, 1.5F);
        graphics.DrawLines(arrow, new[]
        {
            new Point(centerX - 4, centerY - 2), new Point(centerX, centerY + 2),
            new Point(centerX + 4, centerY - 2)
        });
        if (Focused && ShowFocusCues)
            ControlPaint.DrawFocusRectangle(graphics, textRect, Theme.Chu, Theme.NenTrongHon);
    }
}
