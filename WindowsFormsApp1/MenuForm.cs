using System;
using System.Windows.Forms;
using System.Drawing;

namespace BoardGameUI
{
    public partial class MenuForm : Form
    {
        private readonly Action continueGame;
        private readonly Action startNewGame;
        private readonly Action loadGame;
        private readonly Action saveGame;
        private readonly Action exitGame;

        public MenuForm(Action continueGame, Action startNewGame, Action loadGame, Action saveGame, Action exitGame)
        {
            InitializeComponent();

            this.continueGame = continueGame;
            this.startNewGame = startNewGame;
            this.loadGame = loadGame;
            this.saveGame = saveGame;
            this.exitGame = exitGame;

            this.BackgroundImage = Image.FromFile("Images/Menu.png"); // Фон меню
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.MouseClick += MenuForm_MouseClick; // Подключаем обработчик кликов
        }

        private bool isProcessingClick = false; // Флаг для обработки кликов

        private void MenuForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (isProcessingClick) return; // Если клик уже обрабатывается, выходим
            isProcessingClick = true;

            try
            {
                // Получаем координаты клика
                int x = e.X;
                int y = e.Y;

                // Проверяем, куда кликнули
                if (IsWithinBounds(x, y, 100, 60, 200, 40)) // Зона "Продолжить"
                {
                    continueGame?.Invoke(); // Выполняем действие продолжения
                    this.Close(); // Закрываем меню
                }
                else if (IsWithinBounds(x, y, 100, 110, 200, 40)) // Зона "Новая игра"
                {
                    startNewGame?.Invoke(); // Выполняем действие для новой игры
                    this.Close(); // Закрываем меню
                }
                else if (IsWithinBounds(x, y, 100, 160, 200, 40)) // Зона "Загрузить"
                {
                    loadGame?.Invoke(); // Выполняем действие загрузки игры
                    MessageBox.Show("Игра успешно загружена!", "Загрузка"); // Показываем сообщение
                }
                else if (IsWithinBounds(x, y, 100, 210, 200, 40)) // Зона "Сохранить"
                {
                    saveGame?.Invoke(); // Выполняем действие сохранения игры
                    MessageBox.Show("Игра успешно сохранена!", "Сохранение"); // Показываем сообщение
                }
                else if (IsWithinBounds(x, y, 100, 260, 200, 40)) // Зона "Выход"
                {
                    exitGame?.Invoke(); // Выполняем действие выхода
                }
            }
            finally
            {
                isProcessingClick = false; // Сбрасываем флаг
            }
        }

        // Метод для проверки попадания клика в зону
        private bool IsWithinBounds(int x, int y, int zoneX, int zoneY, int width, int height)
        {
            return x >= zoneX && x <= zoneX + width && y >= zoneY && y <= zoneY + height;
        }
    }
}
