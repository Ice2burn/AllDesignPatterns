using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    // Интерфейс дял обхода составных объектов. Итератор описывает интерфейс для доступа и обхода элементов коллекции.
    abstract class Iterator
    {
        public abstract void Reset();
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    // Конкретная реализация итератора для обхода объекта Aggregate. Реализует конкретный способ обхода
    class ConcreteIterator : Iterator
    {
        private ConcreteCollection _collection;
        private int _current = 0;

        public ConcreteIterator(ConcreteCollection aggregate)
        {
            this._collection = aggregate;
        }

        // Возвращает первый элемент
        public override void Reset()
        {
            _current = 0;
        }

        public override object First()
        {
            return _collection[0];
        }

        // Возвращает следующий элемент
        public override object Next()
        {
            object ret = null;

            _current++;

            if (_current < _collection.Count)
            {
                ret = _collection[_current];
            }

            return ret;
        }

        // Текущий элемент
        public override object CurrentItem()
        {
            return _collection[_current];
        }

        // Gets whether iterations are complete

        public override bool IsDone()
        {
            return _current >= _collection.Count;
        }
    }
}
