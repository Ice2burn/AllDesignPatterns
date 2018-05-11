using System;

namespace Singleton
{
    /// <summary>
    /// Паттерн: Singleton (Одиночка)
    /// Type: Creational (Порождающий)
    /// О чём паттерн: у класса одиночки может быть только один экземпляр, который имеет глобальную точку доступа
    /// Плюсы:
    ///     + Гарантирует наличие единственного экземпляра класса в приложении
    ///     + Предоставляет глобальную точку доступа
    ///     + Реализует отложенную инциализацию
    /// 
    /// Минусы:
    ///     - Считается антипаттерном
    ///     - Нарушается принцип единственной ответственности
    ///     - Возможно использование прямых зависимостей внутри, поскольку конструктор обычно скрыт
    ///     - Нужно следить за утечкой памяти, т.е. жизненный цикл контролируется приложением, а не кодом
    /// 
    /// Когда использовать:
    ///     * Когда в программе должен быть единственный экземпляр какого-то класса, доступный всем 
    ///       клиентам (например, общий доступ к базе данных из разных частей программы)
    ///     * Когда хочется иметь больше контроля над глобальными переменными
    /// 
    /// Стоит обратить внимание на unit-тестирование при применении данного паттерна и использование DI или IOC
    /// 
    /// ToDo: реализовать Singleton с использованием фабрики
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Код содержит несколько реализаций в зависимости от сложности синглтона.
            // Рекомендуется использовать ModernLazy или ThreadSafeSingleton
            ModernLazyThreadSafeSigleton s1 = ModernLazyThreadSafeSigleton.Instance;
            ModernLazyThreadSafeSigleton s2 = ModernLazyThreadSafeSigleton.Instance;

            s1.DoSomething();
            s2.DoSomething();
            if (s1 == s2)
            {
                Console.WriteLine("Объекты являются одинаковыми экземплярами");
            }

            // Пример реализации через DI (Позволяет проводить юнит тесты)
            IDependency dependency = new Dependency();
            DIThreadSafeSingleton s3 = DIThreadSafeSingleton.CreateInstance(dependency);
            DIThreadSafeSingleton s4 = DIThreadSafeSingleton.CreateInstance(dependency);

            s3.DoSomething();
            s4.DoSomething();
            if (s3 == s4)
            {
                Console.WriteLine("Объекты являются одинаковыми экземплярами");
            }

            Console.ReadKey();
        }
    }
}
