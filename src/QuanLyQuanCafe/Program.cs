using Microsoft.Data.SqlClient;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.Session;
using QuanLyQuanCafe.Utils;
using System.Data;

namespace QuanLyQuanCafe
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}