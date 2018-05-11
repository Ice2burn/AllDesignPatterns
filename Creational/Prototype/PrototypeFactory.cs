using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    // Фабрика по созданию прототипов
    public static class PrototypeFactory
    {
        private static readonly ConcretePrototypeA _concretePrototypeA;
        private static readonly ConcretePrototypeB _concretePrototypeB;
        private static readonly ConcretePrototypeN _concretePrototypeN;

        static PrototypeFactory()
        {
            _concretePrototypeA = new ConcretePrototypeA("Prototype A");
            _concretePrototypeB = new ConcretePrototypeB("Prototype B");
            _concretePrototypeN = new ConcretePrototypeN("Prototype N");
        }

        public static ConcretePrototypeA CreatePrototypeA()
        {
            return (ConcretePrototypeA)_concretePrototypeA.Clone();
        }

        public static ConcretePrototypeB CreatePrototypeB()
        {
            return (ConcretePrototypeB)_concretePrototypeB.Clone();
        }

        public static ConcretePrototypeN CreatePrototypeN()
        {
            return (ConcretePrototypeN)_concretePrototypeN.Clone();
        }

        public static T Clone<T>(this T other) where T : Prototype
        {
            return Dynamic<T>.CopyCtor(other);
        }

        private static class Dynamic<T> where T : Prototype
        {
            static Dictionary<Type, Func<T, T>> cache = new Dictionary<Type, Func<T, T>>();

            public static T CopyCtor(T other)
            {
                Type t = other.GetType();
                if (!cache.ContainsKey(t))
                {
                    var ctor = t.GetConstructor(new Type[] { t });
                    cache.Add(t, (x) => ctor.Invoke(new object[] { x }) as T);
                }
                return cache[t](other);
            }
        }
    }
}
