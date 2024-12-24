using System;

namespace BoardGameUI
{
    partial class MenuForm
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

        #region Код, созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // MenuForm
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackgroundImage = System.Drawing.Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Menu.png"));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.MouseClick += MenuForm_MouseClick;

            this.ResumeLayout(false);
        }

        #endregion
    }
}
