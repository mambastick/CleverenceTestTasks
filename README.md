# 🔍 CleverenceTestTasks 🔍

`CleverenceTestTasks` - проект, в котором содержатся **тестовые задания** для компании "Клеверенс" на позицию C#
Developer.
___

## 💾 [Задание 1. Компрессия и декомпрессия строк.](https://github.com/mambastick/CleverenceTestTasks/tree/master/CompressionDecompressionTask)

### Исходный код

В
классе [Compression.cs](https://github.com/mambastick/CleverenceTestTasks/blob/master/CompressionDecompressionTask/Compression.cs)
содержатся алгоритмы для компрессии строки (сжатия).

В этом классе представлены две функции:

1. Функция, в которой находится алгоритм сжатия строки:

```csharp
public static string Compress(string input)
```

2. Функция, в которой находится алгоритм, который определяет какой символ ставить:

```csharp
private static void AppendCompressed(StringBuilder compressed, char currentChar, int count)
```

А в
классе [Decompression.cs](https://github.com/mambastick/CleverenceTestTasks/blob/master/CompressionDecompressionTask/Decompression.cs)
всего одна функция, которая выполняет роль декомпрессии (распаковки) строки:

```csharp
public static string Decompress(string input)
```

### Пример использования

```csharp
// Задаем входные данные
const string inputString = "rrmmmqqqwttt";
Console.WriteLine("Исходные данные: " + inputString);
        
// Сжимаем строку
var compressedString = Compression.Compress(inputString);
Console.WriteLine("Сжатая строка: " + compressedString); // Вывод: r2m3q3wt3
        
// Распаковывем сжатую строку
var decompressedString = Decompression.Decompress(compressedString);
Console.WriteLine("Распакованная строка: " + decompressedString); // Вывод: rrmmmqqqwttt
```

---

## 🌀 [Задание 2. Матрица и ее вывод по спирали против часовой стрелки.](https://github.com/mambastick/CleverenceTestTasks/tree/master/SpiralMatrixTask)

### Исходный код

У этой библиотеки всего 1
класс - [Matrix.cs](https://github.com/mambastick/CleverenceTestTasks/blob/master/SpiralMatrixTask/Matrix.cs), в котором
всего 1 функция:

```csharp
public static IEnumerable<int> GetSpiralOrder(int[,] matrix)
```

которая получает на вход матрицу любого размера MxN и возвращает
массив упорядоченный спиралью против часовой стрелки.

### Пример использования

```csharp
// Создаем матрицу
int[,] matrix = {
    {1, 2, 3, 5, 6},
    {7, 8, 9, 10, 11},
    {12, 13, 14, 15, 16}
};

// Сортируем матрицу спиралью против часов стрелки
var spiralMatrix = Matrix.GetSpiralOrder(matrix);
        
// Выводим результат
Console.WriteLine("Спиральный массив: [" + string.Join(", ", spiralMatrix) + "]");
// На экране будет: [1, 7, 12, 13, 14, 15, 16, 11, 6, 5, 3, 2, 8, 9, 10]
```

---

## 📡 [Задание 3. Серверный счетчик.](https://github.com/mambastick/CleverenceTestTasks/tree/master/ServerCountTask)

### Исходный код

В этом задании присутствует всего один статический
класс - [Server.cs](https://github.com/mambastick/CleverenceTestTasks/blob/master/ServerCountTask/Server.cs),
в котором расположились следующие поля и функции:

**Счетчик**, который читают и записывают пользователи:

```csharp
private static int _count = 0;
```

**Механизм блокировки** для управления доступом к ресурсам из нескольких потоков:

```csharp
private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();
```

Функция получения (чтение) суммы с счетчика:

```csharp
public static int GetCount()
```

Функция добавления (запись) суммы к счетчику:

```csharp
public static void AddToCount(int value)
```

### Пример использования

```csharp
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
```