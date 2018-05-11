using System;

namespace Singleton
{
    // Полностью потокобезопасная Lazy-инициализация
    // На самом деле это хак и лучше его не использовать.
    // Не рекомендуется
    public sealed class LazyThreadSafeSingleton
    {
        // Единственный публичный объект
        public static LazyThreadSafeSingleton Instance { get { return Nested.instance; } }

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private LazyThreadSafeSingleton()
        { }

        // Вложенный класс для корректной lazy - инициализации на уровне компилятора
        private class Nested
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            { }

            // Единственная сущность синглтона. Обязательно internal.
            internal static readonly LazyThreadSafeSingleton instance = new LazyThreadSafeSingleton();
        }

        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре и потокобезопасен!");
        }
    }
}
