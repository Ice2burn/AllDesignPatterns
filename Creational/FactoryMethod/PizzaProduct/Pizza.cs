using System;

namespace FactoryMethod.PizzaProduct
{
    // Абстрактная пицца
    abstract class Pizza
    {
        // Цвет коробочки
        public string Color;

        // Имя пиццы
        public string Name { protected get; set; }

        // асбтрактный метод: как мы её готовим (это зависит от пиццы, остальное у пицц совпадает, но при неоходимости можно и переопределить)
        internal abstract void Prepare();

        // как мы её печем
        internal void Bake()
        {
            Console.WriteLine("Выпекать 20 минут при температуре 200 градусов");
        }

        // как мы её режем
        internal void Cut()
        {
            Console.WriteLine("Нарезать треугольниками");
        }

        // как мы её пакуем
        internal void Box()
        {
            Console.WriteLine("Упаковываем пиццу в " + Color + " коробочку");
        }
    }
}
