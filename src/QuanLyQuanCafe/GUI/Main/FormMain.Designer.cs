namespace QuanLyQuanCafe.GUI.Main
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mnuMain = new MenuStrip();
            this.stsMain = new StatusStrip();
            this.lblTrangThai = new ToolStripStatusLabel();

            this.stsMain.SuspendLayout();
            this.SuspendLayout();

            // mnuMain
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Font = new Font("Segoe UI", 10F);
            this.mnuMain.Location = new Point(0, 0);
            this.mnuMain.Size = new Size(900, 28);
            this.mnuMain.TabIndex = 0;

            // stsMain
            this.stsMain.Name = "stsMain";
            this.stsMain.Font = new Font("Segoe UI", 10F);
            this.stsMain.Items.AddRange(new ToolStripItem[] { this.lblTrangThai });
            this.stsMain.Location = new Point(0, 524);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new Size(900, 26);
            this.stsMain.TabIndex = 1;

            // lblTrangThai
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Xin chào";

            // FormMain
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 550);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new Font("Segoe UI", 10F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán cà phê";
            this.WindowState = FormWindowState.Maximized;

            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private StatusStrip stsMain;
        private ToolStripStatusLabel lblTrangThai;
    }
}

