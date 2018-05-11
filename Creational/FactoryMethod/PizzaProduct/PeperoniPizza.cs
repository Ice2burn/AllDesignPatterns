using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.PizzaProduct
{
    // Пицца пеперони
    class PeperoniPizza : Pizza
    {
        // готовят её так
        internal override void Prepare()
        {
            Console.WriteLine("Готовим пиццу " + Name + " добавив тонко нарезанные салями");
            Console.WriteLine();
        }
    }
}
