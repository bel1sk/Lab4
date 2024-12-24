namespace BoardGame
{
    public interface ISerializer
    {
        string Serialize(object obj); // Метод для сериализации объекта в строку
        T Deserialize<T>(string data); // Метод для десериализации строки в объект
    }
}
