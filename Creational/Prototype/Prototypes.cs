using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    // Класс предоставляет описание метода для клонирования самого себя
    public abstract class Prototype
    {
        public string Name { get; private set; }

        // Копирование всех полей происходит в конструкторе
        public Prototype(string name)
        {
            this.Name = name;
        }

        // Результатом клонирования всегда будет объект того же подкласса Prototype
        // 
        public abstract Prototype Clone();
    }

    // В конкретной реализации описываем как создавать клона
    public class ConcretePrototypeA : Prototype
    {
        // Вызываем конструктор родителя, чтобы скопировать приватные поля
        public ConcretePrototypeA(string name) : base(name)
        { }

        public override Prototype Clone()
        {
            return new ConcretePrototypeA(Name);
        }
    }

    // В конкретной реализации описываем как создавать клона
    public class ConcretePrototypeB : Prototype
    {
        public ConcretePrototypeB(string name) : base(name)
        { }

        public override Prototype Clone()
        {
            return new ConcretePrototypeB(Name);
        }
    }

    // В конкретной реализации описываем как создавать клона
    public class ConcretePrototypeN : Prototype
    {
        public ConcretePrototypeN(string name) : base(name)
        { }

        public override Prototype Clone()
        {
            return new ConcretePrototypeN(Name);
        }
    }
}
