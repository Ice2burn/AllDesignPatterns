namespace FactoryMethod.Simple
{
    // Задаём, какие объекты мы будем создавать с помощью абстрактного класса (например, пицца)
    abstract class AbstractProduct
    { }

    // Пример конкретной реализации первого продукта (пицца 4 сыра)
    class ConcreteProductA : AbstractProduct
    { }

    // Пример конкретной реализации N-го продукта (пицца пеперони)
    class ConcreteProductN : AbstractProduct
    { }
}
