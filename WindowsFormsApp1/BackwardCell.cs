using System;

namespace BoardGame
{
    // Ячейка, перемещающая игрока назад на указанное количество шагов
    public class BackwardCell : Cell
    {
        private int stepsBackward; // Количество шагов назад

        public BackwardCell(int position, int steps) : base(position, "Backward")
        {
            stepsBackward = steps; // Инициализируем шаги назад
        }

        // Срабатывание ячейки: игрок перемещается назад
        public override void Trigger(Player player)
        {
            Console.WriteLine($"Игрок {player.Name} попал на поле {Position} и перемещается назад на {stepsBackward} шагов!");
            player.Position -= stepsBackward;

            // Убедимся, что позиция не станет отрицательной
            if (player.Position < 0)
                player.Position = 0;
        }
    }
}
