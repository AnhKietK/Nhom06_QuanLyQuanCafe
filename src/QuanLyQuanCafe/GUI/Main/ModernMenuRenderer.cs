using System.Drawing.Drawing2D;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Main
{
    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernColorTable())
        {
        }

        private class ModernColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.Transparent;
            public override Color MenuStripGradientEnd => Color.Transparent;

            public override Color ToolStripDropDownBackground => Theme.NenMenuDropDown;
            public override Color MenuBorder => Theme.VienThe;
            public override Color MenuItemBorder => Color.Transparent;

            public override Color MenuItemSelected => Theme.DongChon;
            public override Color MenuItemSelectedGradientBegin => Theme.DongChon;
            public override Color MenuItemSelectedGradientEnd => Theme.DongChon;

            public override Color MenuItemPressedGradientBegin => Color.FromArgb(70, 255, 255, 255);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(70, 255, 255, 255);

            public override Color ImageMarginGradientBegin => Theme.NenMenuDropDown;
            public override Color ImageMarginGradientMiddle => Theme.NenMenuDropDown;
            public override Color ImageMarginGradientEnd => Theme.NenMenuDropDown;

            public override Color SeparatorDark => Theme.VienThe;
            public override Color SeparatorLight => Color.Transparent;

            public override Color StatusStripGradientBegin => Theme.NenStatusStrip;
            public override Color StatusStripGradientEnd => Theme.NenStatusStrip;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip)
            {
                // Để lộ dải màu gradient của Header
                return;
            }

            if (e.ToolStrip is StatusStrip)
            {
                using var brush = new SolidBrush(Theme.NenStatusStrip);
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
                return;
            }

            if (e.ToolStrip is ToolStripDropDown)
            {
                using var brush = new SolidBrush(Theme.NenMenuDropDown);
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
                return;
            }

            base.OnRenderToolStripBackground(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item is not ToolStripMenuItem item) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (item.IsOnDropDown)
            {
                // Mục trong menu thả xuống
                if (item.Selected)
                {
                    Rectangle rect = new(2, 1, item.Width - 4, item.Height - 2);
                    using var brush = new SolidBrush(Theme.DongChon);
                    using var path = Theme.RoundedRect(rect, 4);
                    g.FillPath(brush, path);
                }
            }
            else
            {
                // Mục trên MenuStrip chính
                if (item.Pressed)
                {
                    Rectangle rect = new(2, 2, item.Width - 4, item.Height - 4);
                    using var brush = new SolidBrush(Color.FromArgb(70, 255, 255, 255));
                    using var path = Theme.RoundedRect(rect, 6);
                    g.FillPath(brush, path);
                }
                else if (item.Selected)
                {
                    Rectangle rect = new(2, 2, item.Width - 4, item.Height - 4);
                    using var brush = new SolidBrush(Color.FromArgb(46, 255, 255, 255));
                    using var path = Theme.RoundedRect(rect, 6);
                    g.FillPath(brush, path);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip is StatusStrip)
            {
                e.TextColor = Theme.ChuPhu;
            }
            else if (e.Item.IsOnDropDown)
            {
                // Trong menu thả xuống: Dark mode dùng chữ trắng, Light mode dùng chữ xám đen
                e.TextColor = (Theme.CurrentMode == ThemeMode.Light && e.Item.Selected)
                    ? ColorTranslator.FromHtml("#0F172A")
                    : Theme.Chu;
            }
            else
            {
                // Trên thanh MenuStrip chính (nền gradient xanh-tím): luôn là màu trắng nổi bật
                e.TextColor = Color.White;
            }

            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle rect = new(8, e.Item.Height / 2, e.Item.Width - 16, 1);
            using var pen = new Pen(Theme.VienThe);
            e.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = (e.Item?.IsOnDropDown == true) ? Theme.Chu : Color.White;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // Bỏ dải viền ảnh bên trái, vẽ tiệp màu menu thả xuống
            using var brush = new SolidBrush(Theme.NenMenuDropDown);
            e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDown)
            {
                using var pen = new Pen(Theme.VienThe, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            }
        }
    }
}
