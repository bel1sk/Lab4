using System.Text.Json;

namespace BoardGame
{
    // Реализация интерфейса сериализации ISerializer
    public class JsonSerializerImpl : ISerializer
    {
        // Метод сериализации объекта в строку JSON
        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true,    // Форматированный вывод (читаемый JSON)
                IncludeFields = true     // Включение приватных полей в сериализацию
            });
        }

        // Метод десериализации строки JSON в объект указанного типа
        public T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
            {
                IncludeFields = true // Учитываем приватные поля при десериализации
            });
        }
    }
}
