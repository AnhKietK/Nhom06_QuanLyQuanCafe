using System.Runtime.CompilerServices;

namespace QuanLyQuanCafe.Utils;

/// <summary>Keeps the designed workspace reachable on small windows and high DPI screens.</summary>
public static class ScrollableFormLayout
{
    private sealed class State
    {
        public Size DesignSize;
        public Control? Footer;
        public bool Applied;
    }

    private static readonly ConditionalWeakTable<Form, State> States = new();

    public static void Install(Form form, Control? footer = null)
    {
        if (form.IsMdiContainer) return;
        if (States.TryGetValue(form, out var existing))
        {
            if (!existing.Applied && footer != null) existing.Footer = footer;
            return;
        }

        var state = new State { DesignSize = form.ClientSize, Footer = footer };
        States.Add(form, state);
        // Constructors can still add controls after applying the theme.
        form.Shown += (_, _) => Apply(form, state);
        if (form.Visible) Apply(form, state);
    }

    private static void Apply(Form form, State state)
    {
        if (state.Applied || form.IsDisposed) return;
        state.Applied = true;
        if (form.MdiParent == null && form.WindowState == FormWindowState.Normal)
        {
            var area = Screen.FromControl(form.Owner ?? form).WorkingArea;
            // Fixed dialogs can otherwise extend below the taskbar before any
            // inner scrollbar is reachable.
            form.MinimumSize = new Size(Math.Min(form.MinimumSize.Width, area.Width),
                Math.Min(form.MinimumSize.Height, area.Height));
            form.Size = new Size(Math.Min(form.Width, area.Width), Math.Min(form.Height, area.Height));
            if (form.StartPosition != FormStartPosition.Manual)
                form.Location = new Point(Math.Clamp(form.Left, area.Left, area.Right - form.Width),
                    Math.Clamp(form.Top, area.Top, area.Bottom - form.Height));
        }
        var controls = form.Controls.Cast<Control>().Where(c => c != state.Footer).ToArray();
        var padding = form.Padding;
        int footerHeight = state.Footer?.Height ?? 0;
        var minimum = new Size(state.DesignSize.Width, Math.Max(1, state.DesignSize.Height - footerHeight));
        var viewport = new Panel
        {
            Name = "pnlFormScroll", Dock = DockStyle.Fill, AutoScroll = true,
            BackColor = Theme.Nen
        };
        var content = new Panel
        {
            Name = "pnlFormContent", Padding = padding, Size = minimum,
            BackColor = Theme.Nen
        };
        form.SuspendLayout();
        content.SuspendLayout();
        form.Padding = Padding.Empty;
        foreach (var control in controls) content.Controls.Add(control);
        viewport.Controls.Add(content);
        form.Controls.Add(viewport);
        viewport.BringToFront();
        content.ResumeLayout(true);
        form.ResumeLayout(true);

        bool resizing = false;
        void ResizeContent()
        {
            if (resizing) return;
            resizing = true;
            try
            {
                content.Size = new Size(Math.Max(minimum.Width, viewport.ClientSize.Width),
                    Math.Max(minimum.Height, viewport.ClientSize.Height));
            }
            finally { resizing = false; }
        }
        viewport.ClientSizeChanged += (_, _) => ResizeContent();
        ResizeContent();
        Theme.EnableDarkModeScrollBars(viewport);
    }
}
