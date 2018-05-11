using System.Collections;

namespace Iterator
{
    // Коллекция описывает интерфейс получения итератора из коллекции. В качестве коллекции
    // может выступать список, база данных, API, дерево и др. Поэтому сама коллекция должна создавать
    // итераторы, которые могут работать с данной коллекцией
    abstract class IterableCollection
    {
        public abstract Iterator CreateIterator();
    }

    // Конкретная реализация, возвращает новый экземпляр конкретного итератора.
    class ConcreteCollection : IterableCollection
    {
        private ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Возвращает число элементов
        public int Count
        {
            get { return _items.Count; }
        }

        // Возвращает элемент по индексу
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}
