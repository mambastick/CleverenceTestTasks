using CompressionDecompressionTask;
using SpiralMatrixTask;

namespace CleverenceTestTasks;

class Program
{
    private static void Main()
    {
        #region Задание #1. Компрессия и декомпрессия строк.
        Console.WriteLine("Задание #1. Компрессия и декомпрессия строк.");

        // Задаем входные данные
        const string inputString = "rrmmmqqqwttt";
        Console.WriteLine("Исходные данные: " + inputString);
        
        // Сжимаем строку
        var compressedString = Compression.Compress(inputString);
        Console.WriteLine("Сжатая строка: " + compressedString);
        
        // Распаковывем сжатую строку
        var decompressedString = Decompression.Decompress(compressedString);
        Console.WriteLine("Распакованная строк: " + decompressedString);
        
        #endregion
        
        // Добавляем оступ в выводе между заданиями
        Console.WriteLine();

        #region Задание #2. Вывод данных в виде спиральной матрицы.
        
        // Создаем матрицу 5 на 3
        int[,] matrix = {
            {1, 2, 3, 5, 6},
            {7, 8, 9, 10, 11},
            {12, 13, 14, 15, 16}
        };
        
        // Сортируем матрицу спиралью против часов стрелки
        var spiralMatrix = Matrix.GetSpiralOrder(matrix);
        
        // Выводим результат
        Console.WriteLine("Спиральный массив: [" + string.Join(", ", spiralMatrix) + "]");
        
        #endregion
        
        // Добавляем оступ в выводе между заданиями
        Console.WriteLine();
    }
}
