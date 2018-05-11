using System;

namespace Prototype
{
    /// <summary>
    /// Паттерн: Prototype (Прототип )
    /// Type: Creational (Порождающий)
    /// О чём паттерн: Позволяет создавать объекты на основе уже созданных объектов, т.е. клонирование
    /// Плюсы:
    ///     + Позволяет клонировать объекты, не привязываясь к их конкретным классам.
    ///     + Меньше повторяющегося кода инициализации объектов. Логика копирования реализована внутри классов, 
    ///       не нужно перебирать все свойства вручную. Так же охватываем приватные поля.
    ///     + Объекты можно клонировать "вслепую" не зная их точного типа 
    ///     + Альтернатива созданию подклассов для конструирования сложных объектов
    /// 
    /// Минусы:
    ///     - Копирование ссылочных типов неполное. Чтобы при копировании создавался новый экземпляр, необходима
    ///       доработка. При этом при работе с интерфейсом, неизвестно копию какой реализации нужно создать.
    ///     - 
    /// 
    /// Когда использовать:
    ///     * Когда нужно создать объект в определенном состоянии 
    ///     * Когда нужно сохранить копию объекта перед проведением над ним каких-либо операций
    ///     * Когда код не должен зависеть от классов копируемых объектов (которые пришли извне или через общий интерфейс)
    ///     * Когда нужно иметь много представителей схожих классов, которые отличаются начальными значениями полей. 
    ///       Паттерн позволяет порождать объекты с определенной конфигурацией, вместо того, чтобы плодить новые подклассы.
    ///       Это позволяет избежать взрывного роста чиста классов в программе и уменьшить её сложность.
    /// 
    ///     В .NET для этого есть интерфейс ICloneable, но его использование не рекомендуется
    ///     так как не указывается информация о способе клонирования (полном или неполном)
    /// 
    ///     Стоит рассмотреть вариант copy-конструктором или отдельным методом в фабрике.
    ///     А вот какой способ реализации лучше пока непонятно.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Простое создание клона вручную
            Prototype prototypeA = new ConcretePrototypeA("Prototype A");
            Prototype clone1 = prototypeA.Clone();

            Console.WriteLine(prototypeA.Name);
            Console.WriteLine(clone1.Name);

            // Продвинутое создание клона, так же с клонированием ссылочных типов
            Dependency dependency = new Dependency("Dependency A1");
            CloneablePrototypeAdvanced cloneablePrototype = new CloneablePrototypeAdvanced("Clone", dependency);
            CloneablePrototypeAdvanced clone2 = cloneablePrototype.Clone() as CloneablePrototypeAdvanced;
            // Убедимся, что после клонирования, при изменении dependency, ссылочный тип клона не изменится
            dependency.SetText("Dependency A2"); 

            Console.WriteLine(cloneablePrototype.GetDependencyText());
            Console.WriteLine(clone2.GetDependencyText());

            // Реализация через фабрику
            ConcretePrototypeN prototypeN = PrototypeFactory.CreatePrototypeN();
            Prototype clone3 = prototypeN.Clone();

            Console.WriteLine(prototypeN.Name);
            Console.WriteLine(clone3.Name);

            Console.ReadLine();
        }
    }
}
