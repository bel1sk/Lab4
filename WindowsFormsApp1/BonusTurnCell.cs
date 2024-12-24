using System;

namespace BoardGame
{
    // Ячейка, дающая игроку дополнительный ход
    public class BonusTurnCell : Cell
    {
        public BonusTurnCell(int position) : base(position, "BonusTurn")
        {
        }

        // Срабатывание ячейки: игрок получает дополнительный ход
        public override void Trigger(Player player)
        {
            Console.WriteLine($"Игрок {player.Name} попал на поле {Position} и получает дополнительный ход!");
            player.HasBonusTurn = true; // Устанавливаем флаг дополнительного хода
        }
    }
}
