using System;

namespace Singleton
{
    // Полностью потокобезопасная Lazy-инициализация с помощью Lazy<T> (.NET 4.*)
    // Рекомендуется
    public sealed class ModernLazyThreadSafeSigleton
    {
        // Передаём делегат в конструкто с помощью лямбда-выражение
        private static readonly Lazy<ModernLazyThreadSafeSigleton> _instance =
            new Lazy<ModernLazyThreadSafeSigleton>(() => new ModernLazyThreadSafeSigleton());

        // Единственный публичный объект
        public static ModernLazyThreadSafeSigleton Instance { get { return _instance.Value; } }

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private ModernLazyThreadSafeSigleton()
        { }

        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре и потокобезопасен!");
        }
    }
}
