using System;
using FactoryMethod.Simple;
using FactoryMethod.PizzaFactory;

namespace FactoryMethod
{
    /// <summary>
    /// Паттерн: Factory Method (Фабричный метод)
    /// Тип: Creational (Порождающий)
    /// О чём паттерн: Базовый класс делегирует создание объектов классам-наследникам, т.е. решает сам что ему создавать
    /// Плюсы:
    ///     + Скрываем особенности реализации
    ///     + Слабая связность. Система легко расширяется, если появляется новый класс-наследник (Pizza)
    ///     + Легко тестировать, мокать
    /// Минусы:
    ///     - Дополнительный слой абстракции
    ///     - Для каждого нового класса-наследника (NewPizza) нужно создавать отдельный класс-создатель (NewPizzaFactory)
    /// 
    /// Когда использовать:
    ///     * Когда заранее неизвестно, объекты каких типов необходимо создавать
    ///     * Когда система должна быть независимой от процесса создания новых объектов и расширяемой: 
    ///       в нее можно легко вводить новые классы, объекты которых система должна создавать.
    ///     * Когда создание новых объектов необходимо делегировать из базового класса классам наследникам
    /// </summary>
    class Program
    {
        // простое объяснение
        static void Main3(string[] args)
        {
            // Массив фабрик
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorN();

            // Каждая фабрика создаёт свой продукт
            foreach (Creator creator in creators)
            {
                AbstractProduct product = creator.FactoryMethod();
                Console.WriteLine("Создал {0}", product.GetType().Name);
            }

            Console.ReadKey();
        }
        
        // На примее пиццы
        static void Main(string[] args)
        {

            Console.WriteLine("Заказ в ДоДо:");
            var dodo = new DoDoPizzaFactory();
            dodo.Order("Четыре сыра");

            Console.WriteLine();
            Console.WriteLine("Заказ в Доминос:");
            var dominos = new DominosPizzaFactory();
            dominos.Order("Салями");

            Console.ReadKey();
        }
    }
}
