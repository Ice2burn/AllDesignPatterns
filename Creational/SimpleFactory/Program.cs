using System;

namespace SimpleFactory
{
    /// <summary>
    /// Паттерн: Simple Factory Method (Простой Фабричный метод)
    /// Тип: Creational (Порождающий)
    /// О чём паттерн: Базовый класс для создания объектов классов-наследников некоторого абстрактного класса
    /// Плюсы:
    ///     + Скрываем особенности реализации на уровне клиента (верхнем)
    ///     + Теперь все вызовы можно править в одном месте, клиентский код трогать не нужно.
    ///     + Мы защищены от изменений в продукте: имени, конструктора. Так же можем управлять жизненным циклом самостоятельно, а не на клиенте.
    ///     + Если нам нужно 
    /// Минусы:
    ///     - Дополнительный слой абстракции
    ///     - Если нужно добавить новый продукт, то нужно добавить новый подкласс и добавить условие в switch (Нарушение принципа открытости/закрытости SOLID)
    /// 
    /// Когда использовать:
    ///     * Лучше всегда. Особенно, если объект формируется более чем в одном месте
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Проблема:
            // SimpleProduct sproduct = new SimpleProduct();
            // sproduct.DoSomething();

            // Если по каким-либо причинам, SimpleProduct изменится, то придётся менять все обращения к SimpleProduct по всему проекту.
            // В данном примере вызов один, но вдруг их будет 20? Каждый раз менять 20 мест? 
            // К тому же жизненный цикл даного объекта контролируется на клиенте.
            // ...
            // Не стоит так делать, создадим отдельный класс для формирования продукта
            Factory simpleFactory = new SimpleFactory();

            // Создадим продукт с помощью фабричного метода
            AbstractProduct aproduct = simpleFactory.CreateProduct(ProductType.ProductA);
            aproduct.DoSomething();

            AbstractProduct bproduct = simpleFactory.CreateProduct(ProductType.ProductB);
            bproduct.DoSomething();

            AbstractProduct nproduct = simpleFactory.CreateProduct(ProductType.ProductN);
            nproduct.DoSomething();

            // Вуаля, подробности создания объекта скрыты
            Console.ReadLine();

        }
    }
}
