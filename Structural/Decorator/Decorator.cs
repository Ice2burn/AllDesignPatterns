using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    // Базовый декоратор хранит ссылку на вложенный в него объект-компонент. 
    // Базовый декоратор делегирует все свои операции этому вложенному компоненту
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
                component.Operation();
        }
    }

    // Реализации декоратора. Данный функционал попадет в ConcreteComponent.
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }

        public void ExtraOperationA()
        {
            base.Operation();
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }

        public void ExtraOperationB()
        {
            base.Operation();
        }
    }
}
