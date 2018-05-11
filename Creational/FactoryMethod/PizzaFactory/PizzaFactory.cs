using FactoryMethod.PizzaProduct;

namespace FactoryMethod.PizzaFactory
{
    // Абстрактный класс фабрики пиццы (Создатели)
    abstract class PizzaFactory
    {
        // Заказ в пиццерии (Фабрике) состоит из нескольких этапов
        public Pizza Order(string type)
        {
            var pizza = Create(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        // Фабричный метод создаёт какую-то пиццу и у каждой фабрики он свой
        protected abstract Pizza Create(string type);
    }
}
