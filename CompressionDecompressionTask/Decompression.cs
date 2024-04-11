using System.Text;

namespace CompressionDecompressionTask;

public static class Decompression
{
    public static string Decompress(string input)
    {
        // Проверяем на пустоту входные данные
        if (string.IsNullOrEmpty(input))
            // Создаем исключение
            throw new Exception("Входная строка не может быть пустой!");
        
        // Создаем объект StringBuilder
        var decompressed = new StringBuilder();

        // Проходим циклом по всей строке
        for (var i = 0; i < input.Length; i++)
        {
            // Берем текущий символ
            var currentChar = input[i];
            
            // Проверяем текущий символ на то, что является ли он числом ?
            if (char.IsDigit(currentChar))
            {
                // Получаем число
                var count = int.Parse(currentChar.ToString());
                
                // Получаем букву, которая стоит перед числом
                var repeatedChar = input[i - 1];
                
                // Вставляем букву нужное количество раз
                decompressed.Append(repeatedChar, count - 1);
            }
            // Если не число, то вставляем букву
            else
            {
                decompressed.Append(currentChar);
            }
        }

        // Возврващаем декомрессионную строку
        return decompressed.ToString();
    }
}