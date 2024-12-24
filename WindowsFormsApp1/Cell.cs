namespace BoardGame
{
    // Базовый класс для ячейки игрового поля
    public class Cell
    {
        public int Position { get; private set; }  // Позиция ячейки на поле
        public string Type { get; private set; }  // Тип ячейки (обычная, особая и т.д.)

        public Cell(int position, string type = "Regular")
        {
            Position = position; // Устанавливаем позицию
            Type = type;         // Устанавливаем тип ячейки
        }

        // Метод, который срабатывает, когда игрок попадает на ячейку
        public virtual void Trigger(Player player)
        {
            // По умолчанию ячейка ничего не делает
        }

        // Текстовое представление ячейки
        public override string ToString()
        {
            return $"Ячейка {Position} ({Type})";
        }
    }
}
