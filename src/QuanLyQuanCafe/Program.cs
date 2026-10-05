using System;
using System.Windows.Forms;
using QuanLyQuanCafe.GUI.Auth;
using QuanLyQuanCafe.GUI.Main;

namespace QuanLyQuanCafe
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Vòng lặp: Đăng nhập -> Vào FormMain -> Nếu Đăng xuất thì quay lại Đăng nhập
            while (true)
            {
                using var dangNhap = new FormDangNhap();
                if (dangNhap.ShowDialog() != DialogResult.OK)
                {
                    break;
                }

                using var main = new FormMain();
                Application.Run(main);

                if (!main.DangXuat)
                {
                    break;
                }
            }
        }
    }
}