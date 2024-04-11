using CompressionDecompressionTask;
using ServerCountTask;
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

        #region Задание 3. Серверный счетчик.

        // Создаем SemaphoreSlim с начальным количеством разрешений (permits) равным 1
        var semaphore = new SemaphoreSlim(1);

        // Создаем 10 задач, которые будут выполнять чтение и/или запись
        var tasks = new Task[10];
        for (var i = 0; i < tasks.Length; i++)
        {
            var taskId = i; // Уникальный идентификатор задачи

            // Задачи с четными индексами будут добавлять значение, с нечетными - только читать
            if (i % 2 == 0)
            {
                tasks[i] = Task.Run(async () =>
                {
                    await semaphore.WaitAsync(); // Ждем разрешения на доступ к ресурсу
                    Console.WriteLine($"Задача {taskId}: Начало записи...");
                    Server.AddToCount(10); // Добавляем значение
                    Console.WriteLine($"Задача {taskId}: Добавим 10, новое значение: {Server.GetCount()}");
                    semaphore.Release(); // Освобождаем разрешение
                    Console.WriteLine($"Задача {taskId}: Завершение записи...");
                });
            }
            else
            {
                tasks[i] = Task.Run(async () =>
                {
                    Console.WriteLine($"Задача {taskId}: Начало чтения...");
                    await semaphore.WaitAsync(); // Ждем разрешения на доступ к ресурсу
                    Console.WriteLine($"Задача {taskId}: Получим данные, текущее значение: {Server.GetCount()}");
                    semaphore.Release(); // Освобождаем разрешение
                    Console.WriteLine($"Задача {taskId}: Завершение чтения...");
                });
            }
        }

        // Ждем завершения всех задач
        Task.WaitAll(tasks);

        #endregion
    }
}
