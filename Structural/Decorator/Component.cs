namespace Decorator
{
    // Абстрактный класс, который определяет интерфейс "обёртки"
    abstract class Component
    {
        public abstract void Operation();
    }

    // Содержит базовое поведение, которое потом изменяют декораторы
    class ConcreteComponent : Component
    {
        public override void Operation()
        { }
    }
}
