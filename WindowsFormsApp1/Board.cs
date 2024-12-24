using System;
using System.Collections.Generic;

namespace BoardGame
{
    // Игровое поле, состоящее из ячеек
    public class Board
    {
        public List<Cell> Cells { get; private set; } // Список всех ячеек на поле
        public int TotalCells => Cells.Count;         // Общее количество ячеек

        // Конструктор создаёт игровое поле с заданным количеством ячеек
        public Board(int cellCount)
        {
            Cells = new List<Cell>();

            for (int i = 0; i < cellCount; i++)
            {
                // Устанавливаем бонусные ячейки в соответствии с вашим описанием
                switch (i)
                {
                    case 1:
                        Cells.Add(new SkipTurnCell(i)); // Пропуск хода
                        break;
                    case 4:
                        Cells.Add(new BackwardCell(i, 2)); // Отбросить назад на 2
                        break;
                    case 7:
                        Cells.Add(new BonusTurnCell(i)); // Дополнительный ход
                        break;
                    case 11:
                        Cells.Add(new ForwardCell(i, 6)); // Бросить вперед на 6
                        break;
                    case 14:
                        Cells.Add(new ForwardCell(i, 1)); // Бросить вперед на 1
                        break;
                    case 15:
                        Cells.Add(new BonusTurnCell(i)); // Бонусный ход
                        break;
                    case 20:
                        Cells.Add(new SkipTurnCell(i)); // Пропуск хода
                        break;
                    case 22:
                        Cells.Add(new BackwardCell(i, 4)); // Отбросить назад на 4
                        break;
                    default:
                        Cells.Add(new Cell(i)); // Обычная ячейка
                        break;
                }
            }
        }


        // Получение ячейки по её позиции
        public Cell GetCell(int position)
        {
            if (position >= 0 && position < Cells.Count)
                return Cells[position];
            else
                return null;
        }

        // Визуализация игрового поля в консоли
        public void Render()
        {
            foreach (var cell in Cells)
            {
                Console.Write(cell.Type == "Regular" ? "[ ]" : $"[{cell.Type.Substring(0, 1)}]");
            }
            Console.WriteLine();
        }
    }
}
