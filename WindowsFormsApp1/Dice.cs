using System;

namespace BoardGame
{
    // Класс кубика для случайного броска
    public class Dice
    {
        private Random random; // Генератор случайных чисел

        public Dice()
        {
            random = new Random(); // Инициализация генератора
        }

        // Метод броска кубика: возвращает число от 1 до 6
        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
}
