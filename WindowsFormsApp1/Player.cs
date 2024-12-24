using System;

public class Player
{
    public string Name { get; set; }    // Имя игрока
    public int Position { get; set; }  // Текущая позиция игрока на поле
    public bool HasWon { get; set; }   // Флаг, обозначающий, выиграл ли игрок
    public bool HasBonusTurn { get; set; } // Флаг для дополнительного хода
    public int SkipTurns { get; set; } // Количество пропускаемых ходов
    public int Index { get; set; }     // Уникальный идентификатор игрока

    // Конструктор для инициализации игрока
    public Player(string name, int index, int position = 0, bool hasWon = false)
    {
        Name = name;          // Устанавливаем имя
        Position = position;  // Начальная позиция
        HasWon = hasWon;      // Флаг выигрыша (по умолчанию false)
        HasBonusTurn = false; // Бонусного хода нет изначально
        Index = index;        // Устанавливаем индекс
    }

    // Метод перемещения игрока по полю
    public void Move(int steps, int boardSize)
    {
        Position += steps; // Увеличиваем позицию на количество шагов

        // Если позиция игрока выходит за границы поля, игрок побеждает
        if (Position >= boardSize)
        {
            HasWon = true;
        }
    }

    // Сбрасываем флаг бонусного хода
    public void ResetBonusTurn()
    {
        HasBonusTurn = false;
    }

    // Устанавливаем пропуск следующего цикла ходов
    public void ApplySkipTurn()
    {
        SkipTurns = 1; // Игрок пропускает один цикл
    }

    // Уменьшаем счётчик пропущенных ходов
    public void DecrementSkipTurn()
    {
        if (SkipTurns > 0)
        {
            SkipTurns--;
        }
    }

    // Проверяем, должен ли игрок пропустить текущий ход
    public bool ShouldSkipTurn()
    {
        return SkipTurns > 0;
    }

    // Метод для отображения позиции игрока в консоли
    public void Render()
    {
        Console.WriteLine($"{Name} находится на позиции {Position}");
    }

    public void Reset()
    {
        Position = 0;
        HasWon = false;
        HasBonusTurn = false;
        SkipTurns = 0;
    }
}
