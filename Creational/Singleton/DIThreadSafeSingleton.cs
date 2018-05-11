using System;

namespace Singleton
{
    // Внешний интерфейс какого-то функционала
    public interface IDependency
    {
        void DoSomething();
    }

    // Реализация этого функционала
    public class Dependency : IDependency
    {
        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре и потокобезопасен! Так же его удобно тестировать!");
        }
    }

    // Синглтон с поддержкой многопоточности и DI. Проброс зависимости происходит через статический класс.
    // Легко применять Unit-тесты!!! 
    // НО! Если в ходе приложения будет вызов CreateInstance(TypeA), а позже CreateInstance(TypeB), то
    // объект будет не того типа, который ожидали. Поэтому нужно следить, чтобы инициализация была только
    // одна и это главная проблема.
    public sealed class DIThreadSafeSingleton
    {
        // Какие-то внешние зависимости
        private readonly IDependency _dependency;

        // Единственная сущность данного класса
        private static DIThreadSafeSingleton _threadSafeSingleton;

        // Объект-заглушка для реализации потокобезопасности
        private static readonly object locker = new Object();

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private DIThreadSafeSingleton(IDependency dependency)
        {
            _dependency = dependency;
        }

        // При первом обращении к сущность создаётся новый объект, при последующих обращениях возвращается 
        // уже существующий объект.
        public static DIThreadSafeSingleton CreateInstance(IDependency dependency)
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
                        _threadSafeSingleton = new DIThreadSafeSingleton(dependency); // Создаём новый экземпляр
                    }
                }
            }

            return _threadSafeSingleton;
        }

        public void DoSomething()
        {
            _dependency.DoSomething();
        }
    }
}
