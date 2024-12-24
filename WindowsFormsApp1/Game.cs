using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace BoardGame
{
    public class Game
    {
        private List<Player> players;    // Список всех игроков
        private Board board;            // Игровое поле
        private Dice dice;              // Кубик для бросков
        private int currentPlayerIndex; // Индекс текущего игрока
        private readonly ISerializer serializer; // Интерфейс для работы с сериализацией

        public List<Player> Players => players;

        public Action<string> UpdateDetailStatus { get; set; } // Делегат для обновления статусов
        public Action RestartGame { get; set; } // Делегат для перезапуска игры

        public Board Board => board;

        public Cell GetCell(int position)
        {
            if (board == null)
            {
                throw new InvalidOperationException("Игровое поле не инициализировано.");
            }
            return board.GetCell(position);
        }

        public Game(int playerCount, int boardSize, ISerializer serializerImpl, Action<string> updateDetailStatus)
        {
            this.serializer = serializerImpl;
            this.UpdateDetailStatus = updateDetailStatus;
            InitializeGame(playerCount, boardSize);
        }

        public void InitializeGame(int playerCount, int boardSize)
        {
            players = new List<Player>();

            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Player($"Игрок {i + 1}", i)); // Передаем индекс `i`
            }

            board = new Board(boardSize);
            dice = new Dice();
            currentPlayerIndex = 0;
        }


        public void ResetGame(int playerCount, int boardSize)
        {
            foreach (var player in players)
            {
                player.Reset();
            }

            board = new Board(boardSize);
            currentPlayerIndex = 0;
            UpdateDetailStatus?.Invoke("Игра перезапущена.");
        }


        public void PlayTurn()
        {
            var currentPlayer = players[currentPlayerIndex];

            if (currentPlayer.ShouldSkipTurn())
            {
                UpdateDetailStatus?.Invoke($"Игрок {currentPlayer.Name} пропускает ход!");
                currentPlayer.DecrementSkipTurn();
                SwitchToNextPlayer();
                return;
            }

            int diceResult = dice.Roll();
            UpdateDetailStatus?.Invoke($"Игрок {currentPlayer.Name} выбросил {diceResult}.");

            int oldPosition = currentPlayer.Position;
            currentPlayer.Move(diceResult, board.TotalCells);
            UpdateDetailStatus?.Invoke($"Игрок {currentPlayer.Name} переместился с {oldPosition} на {currentPlayer.Position}.");

            var triggeredCell = board.GetCell(currentPlayer.Position);
            if (triggeredCell != null && triggeredCell.Type != "Regular")
            {
                UpdateDetailStatus?.Invoke($"Игрок {currentPlayer.Name} попал на ячейку {triggeredCell.Position} ({triggeredCell.Type}).");
                triggeredCell.Trigger(currentPlayer);
            }

            if (currentPlayer.HasWon)
            {
                AnnounceWinner();
                return;
            }

            if (!currentPlayer.HasBonusTurn)
            {
                SwitchToNextPlayer();
            }
            else
            {
                UpdateDetailStatus?.Invoke($"Игрок {currentPlayer.Name} получает дополнительный ход!");
                currentPlayer.ResetBonusTurn();
            }
        }

        private void SwitchToNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }

        public void SaveGame()
        {
            var gameState = new GameState(players, board.TotalCells, currentPlayerIndex);
            string json = serializer.Serialize(gameState);
            File.WriteAllText("game_save.json", json);
        }

        public static Game LoadGame(ISerializer serializerImpl, Action<string> updateDetailStatus, Action restartGame)
        {
            if (File.Exists("game_save.json"))
            {
                string json = File.ReadAllText("game_save.json");
                var gameState = serializerImpl.Deserialize<GameState>(json);

                var game = new Game(
                    gameState.Players.Count,
                    gameState.BoardSize,
                    serializerImpl,
                    updateDetailStatus
                )
                {
                    RestartGame = restartGame
                };

                game.players = gameState.Players;
                game.currentPlayerIndex = gameState.CurrentPlayerIndex;

                return game;
            }
            else
            {
                throw new FileNotFoundException("Сохранение не найдено!");
            }
        }

        public void AnnounceWinner()
        {
            foreach (var player in players)
            {
                if (player.HasWon)
                {
                    UpdateDetailStatus?.Invoke($"Поздравляем, {player.Name} победил!");
                    MessageBox.Show($"Поздравляем, {player.Name} победил!", "Победа");

                    var result = MessageBox.Show("Хотите начать новую игру?", "Конец игры", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        RestartGame?.Invoke();
                    }

                    return;
                }
            }
        }

        private class GameState
        {
            [JsonInclude]
            public List<Player> Players { get; private set; }

            [JsonInclude]
            public int BoardSize { get; private set; }

            [JsonInclude]
            public int CurrentPlayerIndex { get; private set; }

            [JsonConstructor]
            public GameState(List<Player> players, int boardSize, int currentPlayerIndex)
            {
                Players = players;
                BoardSize = boardSize;
                CurrentPlayerIndex = currentPlayerIndex;
            }
        }
    }
}
