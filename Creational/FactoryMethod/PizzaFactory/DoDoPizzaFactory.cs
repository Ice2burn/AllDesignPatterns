using FactoryMethod.PizzaProduct;

namespace FactoryMethod.PizzaFactory
{
    class DoDoPizzaFactory : PizzaFactory
    {
        protected override Pizza Create(string type)
        {
            Pizza pizza;

            // У каждой пиццерии отличается цвет коробочки, названия пицц и способ их приготовления
            if (type.Equals("Четыре сыра"))
            {
                pizza = new FourCheesePizza();
                pizza.Name = "Сырная ДоДо";
            }
            else
            {
                pizza = new PeperoniPizza();
                pizza.Name = "ДоДо пеперони";
            }

            pizza.Color = "оранжевую";
            return pizza;
        }
    }
}
