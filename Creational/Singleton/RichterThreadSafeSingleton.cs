using System;
using System.Threading;

namespace Singleton
{
    // Потокобезопасная реализация Одиночки по Джефри Рихтеру 
    // Не самая удачная, т.к. если несколько потоков запросят instance, то будет создано
    // несколько версий синглтона. В ссылку, конечно, попадёт только один из них. Но затраты
    // на такую инициализацию могут быть выше чем у варианта ThreadSafeSingleton.
    // Не рекомендуется. У рихтера есть и другие варианты реализации
    public sealed class RichterThreadSafeSingleton
    {
        // Единственная сущность данного класса
        private static RichterThreadSafeSingleton instance;

        // Объект-заглушка для реализации потокобезопасности
        private static readonly object locker = new Object();

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private RichterThreadSafeSingleton()
        { }

        // При первом обращении к сущность создаётся новый объект, при последующих обращениях возвращается 
        // уже существующий объект.
        public static RichterThreadSafeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    Monitor.Enter(locker);
                    RichterThreadSafeSingleton temp = new RichterThreadSafeSingleton();
                    Interlocked.Exchange(ref instance, temp);
                    Monitor.Exit(locker);
                }

                return instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре и потокобезопасен!");
        }
    }
}
