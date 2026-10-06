using System.Reflection;
using QuanLyQuanCafe.Utils;

namespace QuanLyQuanCafe.GUI.Main
{
    public static class FormLauncher
    {
        /// <summary>
        /// Mở form theo tên đầy đủ của kiểu. Nếu chưa có thì báo đang phát triển.
        /// </summary>
        public static void Mo(Form cha, string tenDayDuKieu, string tenHienThi, bool modal = false)
        {
            Type? type = typeof(Program).Assembly.GetType(tenDayDuKieu);
            if (type == null)
            {
                UiHelper.ShowInfo($"Chức năng \"{tenHienThi}\" đang được phát triển.");
                return;
            }

            if (!modal)
            {
                Form? dangMo = cha.MdiChildren.FirstOrDefault(f => f.GetType() == type);
                if (dangMo != null)
                {
                    if (dangMo.WindowState != FormWindowState.Maximized)
                        dangMo.WindowState = FormWindowState.Maximized;
                    dangMo.Activate();
                    dangMo.BringToFront();
                    return;
                }
            }

            Form formMoi;
            try
            {
                object? instance = Activator.CreateInstance(type);
                if (instance is not Form f)
                {
                    UiHelper.ShowWarning($"Lớp {tenDayDuKieu} không phải là Form.");
                    return;
                }
                formMoi = f;
            }
            catch (MissingMethodException)
            {
                UiHelper.ShowWarning($"Form {tenHienThi} thiếu constructor không tham số.");
                return;
            }
            catch (TargetInvocationException ex) when (ex.InnerException is MissingMethodException)
            {
                UiHelper.ShowWarning($"Form {tenHienThi} thiếu constructor không tham số.");
                return;
            }
            catch (Exception ex)
            {
                UiHelper.HienLoi(ex);
                return;
            }

            // Đồng bộ giao diện qua Theme cho mọi form trước khi hiển thị
            Theme.Apply(formMoi);

            if (modal)
            {
                using (formMoi)
                {
                    formMoi.StartPosition = FormStartPosition.CenterParent;
                    formMoi.ShowDialog(cha);
                }
            }
            else
            {
                formMoi.FormBorderStyle = FormBorderStyle.None;
                formMoi.ControlBox = false;
                formMoi.MdiParent = cha;
                formMoi.WindowState = FormWindowState.Maximized;
                formMoi.Show();
            }
        }
    }
}

