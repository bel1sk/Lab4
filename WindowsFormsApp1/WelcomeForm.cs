using System;
using System.Windows.Forms;

namespace BoardGameUI
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent(); // Убедитесь, что эта строка генерируется автоматически в файле .Designer.cs
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Показать форму выбора количества игроков
            using (var playerCountForm = new PlayerCountForm())
            {
                if (playerCountForm.ShowDialog() == DialogResult.OK)
                {
                    int playerCount = playerCountForm.PlayerCount;

                    // Запуск основной формы игры
                    var form1 = new Form1(playerCount, false);
                    form1.Show();
                    this.Hide(); // Скрываем приветственное окно
                }
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            // Переход в форму игры с загрузкой сохранённой игры
            var form1 = new Form1(4, true); // Передаём 4 игрока (или исправьте, если нужно)
            form1.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Завершаем приложение
        }
    }
}
