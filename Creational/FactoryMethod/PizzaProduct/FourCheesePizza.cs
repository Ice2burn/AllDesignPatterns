using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.PizzaProduct
{
    // Пицца 4 сыра
    class FourCheesePizza : Pizza
    {
        // А готовят пиццу именно так
        internal override void Prepare()
        {
            Console.WriteLine("Готовим " + Name + " используя 4 различных сорта сыра.");
            Console.WriteLine();
        }
    }
}
