using FactoryMethod.PizzaProduct;

namespace FactoryMethod.PizzaFactory
{
    class DominosPizzaFactory : PizzaFactory
    {
        protected override Pizza Create(string type)
        {
            Pizza pizza;

            // У каждой пиццерии отличается цвет коробочки, названия пицц и способ их приготовления
            if (type.Equals("Четыре сыра"))
            {
                pizza = new FourCheesePizza();
                pizza.Name = "Сырный доминос";
            }
            else
            {
                pizza = new PeperoniPizza();
                pizza.Name = "Доминос пеперони";
            }

            pizza.Color = "белую";
            return pizza;
        }
    }
}
