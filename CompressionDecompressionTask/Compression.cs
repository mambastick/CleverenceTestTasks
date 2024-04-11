using System.Text;

namespace CompressionDecompressionTask;

public static class Compression
{
    /// <summary>
    /// Сжимает входную строку, заменяя группы последовательно идущих одинаковых символов
    /// их количеством и символом.
    /// </summary>
    /// <param name="input">Входная строка для сжатия.</param>
    /// <returns>Сжатая строка.</returns>
    /// <exception cref="Exception">Выбрасывает исключение, если входная строка пуста или null.</exception>
    public static string Compress(string input)
    {
        // Проверяем на пустоту входные данные
        if (string.IsNullOrEmpty(input))
            // Создаем исключение
            throw new Exception("Входная строка не может быть пустой!");
        
        // Создаем объект StringBuilder
        var compressed = new StringBuilder();

        // Получаем первый символ
        var currentChar = input[0];
        
        // Создаем счетчик, который будет считать повторения букв
        var count = 1;
        
        // Циклом проходим всю строку
        for (var i = 1; i < input.Length; i++)
        {
            // Если символ в строке совпадает с текущим символов, то прибавляем счетчику 1
            if (input[i] == currentChar)
            {
                // Считаем количество одинаковых символов 
                count++;
            }
            else
            {
                // Вставляем символы и их количество
                AppendCompressed(compressed, currentChar, count);

                // Изменяем текущий символ на следующий
                currentChar = input[i];
                
                // Сбрасываем счетчик
                count = 1;
            }
        }

        // Вставляем символы и их количество
        AppendCompressed(compressed, currentChar, count);
        
        // Возвращаем сжатую строку
        return compressed.ToString();
    }

    private static void AppendCompressed(StringBuilder compressed, char currentChar, int count)
    {
        // Если количество найденных символов 1, то добавляем этот символ без его количества повторений
        if (count == 1)
        {
            // Добавляем символ
            compressed.Append(currentChar);
        }
        // Иначе добавляем символ и количество его повторений в строке
        else
        {
            // Добавляем символ
            compressed.Append(currentChar);
                    
            // Добавляем количество его повторений в строке
            compressed.Append(count);
        }
    }
}