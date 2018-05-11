namespace FactoryMethod.Simple
{
    // Создатель абстрактной пиццы 
    abstract class Creator
    {
        // Фабричный метод
        public abstract AbstractProduct FactoryMethod();
    }

    // Конкретная фабрика для формирования Продукта A
    class ConcreteCreatorA : Creator
    {
        public override AbstractProduct FactoryMethod() { return new ConcreteProductA(); }
    }

    // Конкретная фабрика для формирования Продукта N
    class ConcreteCreatorN : Creator
    {
        public override AbstractProduct FactoryMethod() { return new ConcreteProductN(); }
    }
}
