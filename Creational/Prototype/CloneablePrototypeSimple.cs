using System;

namespace Prototype
{
    // Пример использования ICloneable. Тут есть недостаток. Например, если мы хотим клонировать SimplePrototype,
    // но не хотим давать возможности клонирования SimpleDependency. Тогда так писать не стоит.
    // К тому же ICloneable интерфейс лучше заменить собственным с более понятным названием методов.

    // Внешняя зависимость ссылочного типа
    public class SimpleDependency : ICloneable
    {
        public string Text { get; set; }

        // Имплементируем ICloneable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class SimplePrototype : ICloneable
    {
        public string Text { get; set; }
        public SimpleDependency Dependency { get; set; }

        // Имплементируем ICloneable
        public object Clone()
        {
            SimplePrototype prototype = (SimplePrototype)this.MemberwiseClone();
            prototype.Dependency = (SimpleDependency)this.Dependency.Clone();
            return prototype;
        }
    }
}
