using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    // Абстрактный класс, в качестве его так же может выступать интерфейс
    abstract class Factory
    {
        public abstract AbstractProduct CreateProduct(ProductType type);
    }

    // Конкретная реализация
    class SimpleFactory : Factory
    {
        public override AbstractProduct CreateProduct(ProductType type)
        {
            // В зависимости от типа формируем конкретный продукт. Программа будет всюду вызывать этот метод и в случае изменения
            // класса продукта, править код будем только в данном методе
            switch(type)
            {
                case ProductType.ProductA:
                    return new ConcreteProductA();
                case ProductType.ProductB:
                    return new ConcreteProductB();
                case ProductType.ProductN:
                    return new ConcreteProductN();
                default:
                    return new ConcreteProductA();
            }
        }
    }
}
