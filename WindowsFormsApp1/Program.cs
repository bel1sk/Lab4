using System;
using System.Windows.Forms;

namespace BoardGameUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запускаем приветственное окно
            Application.Run(new WelcomeForm());
        }
    }
}
