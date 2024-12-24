using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BoardGame;

namespace BoardGameUI
{
    public partial class Form1 : Form
    {
        private Game game;
        private readonly ISerializer serializer;
        private const int BoardSize = 24;
        private int playerCount;

        public Form1(int playerCount, bool loadGame = false)
        {
            InitializeComponent();
            serializer = new JsonSerializerImpl();
            this.playerCount = playerCount;

            if (loadGame)
            {
                LoadGame();
            }
            else
            {
                InitializeGame();
            }
        }

        private void InitializeGame()
        {
            game = new Game(playerCount, BoardSize, serializer, AddToDetailStatus)
            {
                RestartGame = RestartGame // Устанавливаем делегат для перезапуска
            };
            UpdatePlayerStatus();
            RenderBoard();
        }

        private void LoadGame()
        {
            try
            {
                game = Game.LoadGame(serializer, AddToDetailStatus, RestartGame);
                UpdatePlayerStatus();
                RenderBoard();
                MessageBox.Show("Игра загружена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                InitializeGame();
            }
        }

        private void RenderBoard()
        {
            panelBoard.Paint -= PanelBoard_Paint;
            panelBoard.Paint += PanelBoard_Paint;
            panelBoard.Invalidate();
        }

        private void AddToDetailStatus(string status)
        {
            if (DetailStatus.Items.Count >= 4)
            {
                DetailStatus.Items.Clear();
            }
            DetailStatus.Items.Add(status);
        }

        private void PanelBoard_Paint(object sender, PaintEventArgs e)
        {
            int cellSize = 80; // Размер клетки
            int tokenSize = cellSize / 2; // Размер фишек
            Graphics g = e.Graphics;

            // Загрузка изображения игрового поля
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            Image gameBoard = Image.FromFile($"{basePath}Images/Field.png");

            // Отрисовка изображения поля
            g.DrawImage(gameBoard, 0, 0, panelBoard.Width, panelBoard.Height);

            // Загрузка изображений фишек
            Image[] playerTokens =
            {
        Image.FromFile($"{basePath}Images/Player1.png"),
        Image.FromFile($"{basePath}Images/Player2.png"),
        Image.FromFile($"{basePath}Images/Player3.png"),
        Image.FromFile($"{basePath}Images/Player4.png")
    };

            // Загрузка текстур мультиигроков
            Image multiPlayer2 = Image.FromFile($"{basePath}Images/2_players.png");
            Image multiPlayer3 = Image.FromFile($"{basePath}Images/3_players.png");
            Image multiPlayer4 = Image.FromFile($"{basePath}Images/4_players.png");

            // Массив координат ячеек
            Point[] cellPositions = new Point[]
{
    // Ряд 1
    new Point(93, 30),   // Ячейка 1
    new Point(170, 30),  // Ячейка 2
    new Point(245, 30),  // Ячейка 3
    new Point(360, 30),  // Ячейка 4 (увеличено расстояние)
    new Point(436, 30),  // Ячейка 5
    new Point(513, 30),  // Ячейка 6

    // Ряд 2
    new Point(93, 100),  // Ячейка 7
    new Point(170, 100), // Ячейка 8
    new Point(245, 100), // Ячейка 9
    new Point(360, 100), // Ячейка 10 (увеличено расстояние)
    new Point(436, 100), // Ячейка 11
    new Point(513, 100), // Ячейка 12

    // Ряд 3
    new Point(93, 170),  // Ячейка 13
    new Point(170, 170), // Ячейка 14
    new Point(245, 170), // Ячейка 15
    new Point(360, 170), // Ячейка 16 (увеличено расстояние)
    new Point(436, 170), // Ячейка 17
    new Point(513, 170), // Ячейка 18

    // Ряд 4
    new Point(93, 240),  // Ячейка 19
    new Point(170, 240), // Ячейка 20
    new Point(245, 240), // Ячейка 21
    new Point(360, 240), // Ячейка 22 (увеличено расстояние)
    new Point(436, 240), // Ячейка 23
    new Point(513, 240)  // Ячейка 24
};





            // Рисуем фишки игроков
            for (int i = 0; i < BoardSize; i++)
            {
                var position = cellPositions[i]; // Получаем координаты ячейки
                int x = position.X;
                int y = position.Y;

                // Определяем игроков на этой клетке
                var playersOnCell = game.Players.Where(p => p.Position == i).ToList();
                int playerCount = playersOnCell.Count;

                // Если на клетке несколько игроков, рисуем текстуру мультиигрока
                if (playerCount == 2)
                {
                    g.DrawImage(multiPlayer2, x + (cellSize - tokenSize) / 2, y + (cellSize - tokenSize) / 2, tokenSize, tokenSize);
                }
                else if (playerCount == 3)
                {
                    g.DrawImage(multiPlayer3, x + (cellSize - tokenSize) / 2, y + (cellSize - tokenSize) / 2, tokenSize, tokenSize);
                }
                else if (playerCount >= 4)
                {
                    g.DrawImage(multiPlayer4, x + (cellSize - tokenSize) / 2, y + (cellSize - tokenSize) / 2, tokenSize, tokenSize);
                }
                else if (playerCount == 1) // Один игрок — обычная текстура
                {
                    int playerIndex = game.Players.IndexOf(playersOnCell[0]);
                    g.DrawImage(playerTokens[playerIndex % playerTokens.Length], x + (cellSize - tokenSize) / 2, y + (cellSize - tokenSize) / 2, tokenSize, tokenSize);
                }
            }
        }









        private void btnRollDice_Click(object sender, EventArgs e)
        {
            game.PlayTurn();
            UpdatePlayerStatus();
            RenderBoard();
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            // Открываем главное меню
            var welcomeForm = new WelcomeForm();
            welcomeForm.Show();

            // Закрываем текущую форму
            this.Close();
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            game.SaveGame();
            MessageBox.Show("Игра сохранена!");
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            try
            {
                game = Game.LoadGame(serializer, AddToDetailStatus, RestartGame);
                UpdatePlayerStatus();
                RenderBoard();
                MessageBox.Show("Игра загружена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            game.ResetGame(playerCount, BoardSize);
            UpdatePlayerStatus();
            RenderBoard();
            DetailStatus.Items.Clear();
            MessageBox.Show("Игра перезапущена!");
        }

        private void UpdatePlayerStatus()
        {
            listBoxPlayerStatus.Items.Clear();
            foreach (var player in game.Players)
            {
                listBoxPlayerStatus.Items.Add($"{player.Name}: Позиция {player.Position}, Пропуск хода: {player.SkipTurns}, Доп. ход: {player.HasBonusTurn}");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.M) // Если нажата клавиша M
            {
                ShowMenu(); // Показываем меню
                return true; // Предотвращаем дальнейшую обработку
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowMenu()
        {
            var menuForm = new MenuForm(
                continueGame: () => MessageBox.Show("Продолжить!"), // Продолжить игру
                startNewGame: () => RestartGame(), // Новая игра
                loadGame: () =>
                {
                    try
                    {
                        game = Game.LoadGame(serializer, AddToDetailStatus, RestartGame);
                        UpdatePlayerStatus();
                        RenderBoard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                    }
                },
                saveGame: () => game.SaveGame(), // Сохранить игру
                exitGame: () => Application.Exit() // Выйти из игры
            );

            menuForm.ShowDialog(); // Показываем меню модально
        }


    }
}
