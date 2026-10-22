using System.ComponentModel;
using System.Reflection;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.GUI.Main;
using QuanLyQuanCafe.Utils;

internal static class Program
{
    [STAThread]
    private static int Main()
    {
        ApplicationConfiguration.Initialize();
        var failures = new List<string>();
        var assembly = typeof(Theme).Assembly;
        using var host = new FormMain
        {
            WindowState = FormWindowState.Normal,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(-20000, -20000),
            ShowInTaskbar = false,
            MinimumSize = Size.Empty
        };
        host.Show();
        string[] names = ["Kho.FormNguyenLieu", "Kho.FormNhapKho", "Kho.FormNhaCungCap",
            "DanhMuc.FormCongThuc", "DanhMuc.FormThucUong", "NhanVien.FormNhanVien",
            "Khach.FormKhach", "Ban.FormBan", "BaoCao.FormBaoCao", "BaoCao.FormChiTien",
            "BanHang.FormBanHang", "BanHang.frmThanhToan", "Auth.FormDoiMatKhau", "Auth.FormDangNhap"];
        foreach (string name in names)
        {
            using var form = (Form)Activator.CreateInstance(assembly.GetType("QuanLyQuanCafe.GUI." + name)!)!;
            // Exercise real layout/painting without opening a database connection.
            var events = (EventHandlerList)typeof(Component).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(form)!;
            var loadKey = typeof(Form).GetField("s_loadEvent", BindingFlags.Static | BindingFlags.NonPublic)!.GetValue(null)!;
            events.RemoveHandler(loadKey, events[loadKey]);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(-20000, -20000);
            form.ShowInTaskbar = false;
            // MDI children have no frame/minimum outer window size.
            form.FormBorderStyle = FormBorderStyle.None;
            form.MinimumSize = Size.Empty;
            Theme.Apply(form);
            bool dialog = name is "BanHang.frmThanhToan" or "Auth.FormDoiMatKhau" or "Auth.FormDangNhap";
            if (!dialog)
            {
                form.MdiParent = host;
                form.WindowState = FormWindowState.Maximized;
            }
            form.Show();
            foreach (var size in new[] { new Size(1100, 650), new Size(1000, 540), new Size(640, 420) })
            {
                // Main header/menu/status consume part of the outer window.
                if (dialog) form.ClientSize = new Size(Math.Min(760, size.Width), size.Height);
                else host.ClientSize = new Size(size.Width, size.Height + 150);
                Application.DoEvents();
                var viewport = Descendants(form).OfType<Panel>().FirstOrDefault(p => p.Name == "pnlFormScroll");
                if (viewport == null || !viewport.AutoScroll)
                    failures.Add(name + ": missing form scroll viewport");
                if (name == "BanHang.frmThanhToan")
                {
                    var confirm = Descendants(form).OfType<Button>().Single(b => b.Text.Contains("XÁC NHẬN THANH TOÁN"));
                    var methods = Descendants(form).OfType<ComboBox>().Single();
                    if (methods.Items.Count == 0) methods.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
                    foreach (int method in new[] { 0, 1 })
                    {
                        // Empty invoice means the QR handler does not request the network.
                        methods.SelectedIndex = method;
                        viewport!.AutoScrollPosition = new Point(10000, 10000);
                        Application.DoEvents();
                        Check(form, failures);
                        var bounds = form.RectangleToClient(confirm.RectangleToScreen(confirm.ClientRectangle));
                        if (!form.ClientRectangle.Contains(bounds)) failures.Add("Payment confirmation is outside the dialog");
                        viewport.AutoScrollPosition = Point.Empty;
                    }
                }
                foreach (var tab in Descendants(form).OfType<TabControl>())
                {
                    foreach (TabPage page in tab.TabPages)
                    {
                        tab.SelectedTab = page;
                        Application.DoEvents();
                        Check(form, failures);
                    }
                }
                Check(form, failures);
                Theme.CurrentMode = ThemeMode.Light;
                Theme.Apply(form);
                Application.DoEvents();
                Check(form, failures);
                Theme.CurrentMode = ThemeMode.Dark;
                Theme.Apply(form);
            }
            var combo = Descendants(form).OfType<ComboBox>().FirstOrDefault(c => c.Name == "cboNguyenLieu");
            if (combo != null)
            {
                var ingredient = new NguyenLieuDTO { MaNL = "NL01", TenNL = "Cà phê hạt" };
                combo.Items.Add(ingredient);
                combo.SelectedItem = ingredient;
                if (combo.GetItemText(ingredient) != ingredient.TenNL)
                    failures.Add(name + ": ingredient display text is incorrect");
            }
            Directory.CreateDirectory("tools/LayoutSmoke/artifacts");
            using (var bitmap = new Bitmap(form.Width, form.Height))
            {
                form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
                bitmap.Save($"tools/LayoutSmoke/artifacts/{form.Name}.png");
            }
            Console.WriteLine("Checked " + name);
            form.Close();
        }
        foreach (string failure in failures.Distinct()) Console.WriteLine(failure);
        return failures.Count == 0 ? 0 : 1;
    }

    private static IEnumerable<Control> Descendants(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            yield return child;
            foreach (var descendant in Descendants(child)) yield return descendant;
        }
    }

    private static void Check(Form form, List<string> failures)
    {
        foreach (var button in Descendants(form).Where(c => c.Visible &&
            c is Button or ComboBox or TextBox or NumericUpDown or DateTimePicker))
        {
            var rect = button.ClientRectangle;
            Control current = button;
            while (current.Parent != null)
            {
                rect.Offset(current.Location);
                current = current.Parent;
                // Content beyond a scroll viewport is reachable by scrolling.
                if (current is ScrollableControl { AutoScroll: true } scroll)
                {
                    if (!scroll.DisplayRectangle.Contains(rect))
                        failures.Add($"{form.Name}: {button.GetType().Name} '{button.Name}' '{button.Text}' outside scrollable content {rect} / {scroll.DisplayRectangle}");
                    break;
                }
                if (!current.ClientRectangle.Contains(rect))
                    failures.Add($"{form.Name} {form.ClientSize}: {button.Name} clipped by {current.Name} ({rect} / {current.ClientRectangle})");
            }
        }
    }
}
