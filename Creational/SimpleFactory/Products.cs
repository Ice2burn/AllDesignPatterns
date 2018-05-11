using System;

namespace SimpleFactory
{
    // Класс продукта, если не использовать фабрики вообще
    class SimpleProduct
    {
        public SimpleProduct() { Console.WriteLine("Конструктор может измениться"); }

        public void DoSomething() { Console.WriteLine("Бизнес-логика может измениться"); }
    }

    // Допустим наш продукт может быть N видов
    // Список всех продуктов 
    enum ProductType
    {
        ProductA,
        ProductB,
        ProductN
    }

    // Зададим абстрактный класс
    abstract class AbstractProduct
    {
        public abstract void DoSomething();
    }

    // Пример конкретной реализации первого продукта 
    class ConcreteProductA : AbstractProduct
    {
        public override void DoSomething()
        {
            Console.WriteLine("Продукт А готов");
        }
    }

    // Пример конкретной реализации второго продукта
    class ConcreteProductB : AbstractProduct
    {
        public override void DoSomething()
        {
            Console.WriteLine("Продукт Б готов");
        }
    }

    // Пример конкретной реализации N-го продукта
    class ConcreteProductN : AbstractProduct
    {
        public override void DoSomething()
        {
            Console.WriteLine("Продукт N готов");
        }
    }
}
