using System;

namespace BoardGame
{
    // Ячейка, перемещающая игрока вперёд на указанное количество шагов
    public class ForwardCell : Cell
    {
        private int stepsForward; // Количество шагов вперёд

        public ForwardCell(int position, int steps) : base(position, "Forward")
        {
            stepsForward = steps; // Инициализируем шаги вперёд
        }

        // Срабатывание ячейки: игрок перемещается вперёд
        public override void Trigger(Player player)
        {
            Console.WriteLine($"{player.Name} попал на поле {Position} и перемещается вперёд на {stepsForward} шагов!");
            player.Move(stepsForward, int.MaxValue); // Перемещаем игрока вперёд
        }
    }
}
