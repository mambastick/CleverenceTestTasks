using System.Threading;

namespace ServerCountTask
{
    /// <summary>
    /// Статический класс, представляющий сервер счетчика.
    /// </summary>
    public static class Server
    {
        private static int _count = 0;
        private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Получает текущее значение счетчика.
        /// </summary>
        /// <returns>Текущее значение счетчика.</returns>
        public static int GetCount()
        {
            Lock.EnterReadLock(); // Получаем блокировку для чтения
            try
            {
                return _count; // Возвращаем текущее значение счетчика
            }
            finally
            {
                Lock.ExitReadLock(); // Освобождаем блокировку для чтения
            }
        }

        /// <summary>
        /// Добавляет значение к счетчику.
        /// </summary>
        /// <param name="value">Добавляемое значение.</param>
        public static void AddToCount(int value)
        {
            Lock.EnterWriteLock(); // Получаем блокировку для записи
            try
            {
                Interlocked.Add(ref _count, value); // Атомарно добавляем значение к счетчику
            }
            finally
            {
                Lock.ExitWriteLock(); // Освобождаем блокировку для записи
            }
        }
    }
}