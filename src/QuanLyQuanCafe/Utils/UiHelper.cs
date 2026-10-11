using QuanLyQuanCafe.DAL;

namespace QuanLyQuanCafe.Utils
{
    public static class UiHelper
    {
        public static void ShowInfo(string noiDung, string tieuDe = "Thông báo")
        {
            MessageBox.Show(noiDung, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string noiDung, string tieuDe = "Cảnh báo")
        {
            MessageBox.Show(noiDung, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirm(string noiDung, string tieuDe = "Xác nhận")
        {
            return MessageBox.Show(noiDung, tieuDe,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static void HienThongBaoLoi(string noiDung, string tieuDe = "Lỗi")
        {
            MessageBox.Show(noiDung, tieuDe,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void HienLoi(Exception ex)
        {
            switch (ex)
            {
                case DbException dbEx:
                    MessageBox.Show(dbEx.Message,
                        dbEx.IsConnectionError ? "Mất kết nối" : "Lỗi cơ sở dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ArgumentException:
                case InvalidOperationException:
                    MessageBox.Show(ex.Message, "Dữ liệu chưa hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    HienThongBaoLoi($"Lỗi: {ex.Message}\nChi tiết: {ex.StackTrace}");
                    break;
            }
        }
    }
}

