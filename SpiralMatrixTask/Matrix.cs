namespace SpiralMatrixTask;

public class Matrix
{
    /// <summary>
    /// Возвращает элементы матрицы, развернутые в массив в спиральном порядке против часовой стрелки.
    /// </summary>
    /// <param name="matrix">Исходная матрица.</param>
    /// <returns>Массив элементов в спиральном порядке против часовой стрелки.</returns>
    public static IEnumerable<int> GetSpiralOrder(int[,] matrix)
    {
        // Получаем количество строк и столбцов в матрице
        var rows = matrix.GetLength(1);
        var cols = matrix.GetLength(0);
    
        // Создаем массив для хранения элементов матрицы в порядке спирали
        var spiralArray = new int[rows * cols];
    
        // Индекс для заполнения массива
        var index = 0;
    
        // Границы области матрицы, которую мы еще не обошли
        var minX = 0;
        var maxX = rows - 1;
        var minY = 0;
        var maxY = cols - 1;
    
        // Пока есть необойденные строки или столбцы
        while (true)
        {
            // Если все строки или столбцы обошли, выходим из цикла
            if (maxY - minY < 0 || maxX - minX < 0)
                break;
        
            // Обход верхней строки, начиная с левого угла
            for (var i = minY; i <= maxY; i++)
                spiralArray[index++] = matrix[i, minX];
            minX++;
    
            // Обход последнего столбца, начиная с верхнего угла
            if (maxY - minY < 0 || maxX - minX < 0)
                break;
            for (var i = minX; i <= maxX; i++)
                spiralArray[index++] = matrix[maxY, i];
            maxY--;
        
            // Обход нижней строки, начиная с правого угла
            if (maxY - minY < 0 || maxX - minX < 0)
                break;
            for (var i = maxY; i >= minY; i--)
                spiralArray[index++] = matrix[i, maxX];
            maxX--;
        
            // Обход первого столбца, начиная с нижнего угла
            if (maxY - minY < 0 || maxX - minX < 0)
                break;
            for (var i = maxX; i >= minX; i--)
                spiralArray[index++] = matrix[minY, i];
            minY++;
        }
    
        // Возвращаем массив элементов матрицы в порядке обхода по спирали
        return spiralArray;
    }
}