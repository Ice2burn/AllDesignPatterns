using System;

namespace Singleton
{
    // Потокобезопасная реализация Одиночки
    // Рекомендуется
    public sealed class ThreadSafeSingleton
    {
        // Единственная сущность данного класса
        private static ThreadSafeSingleton _threadSafeSingleton;

        // Объект-заглушка для реализации потокобезопасности
        private static readonly object locker = new Object();

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private ThreadSafeSingleton()
        {

        }

        // При первом обращении к сущность создаётся новый объект, при последующих обращениях возвращается 
        // уже существующий объект.
        public static ThreadSafeSingleton Instance
        {
            get
            {
                // Если объект уже создан, то не будем тратить ресурсы на более дорогую операцию блокировки
                if (_threadSafeSingleton == null)
                {
                    // Блокируем блок кода для других потоков
                    lock (locker)
                    {
                        // Обязательно проверяем, что ничего не изменилось пока выполнялась блокировка
                        if (_threadSafeSingleton == null)
                        {
                            _threadSafeSingleton = new ThreadSafeSingleton(); // Создаём новый экземпляр
                        }
                    }
                }

                return _threadSafeSingleton;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре и потокобезопасен!");
        }
    }
}
