 using System;

namespace Prototype
{
    // В данной реализации используется базовый абстрактный класс, от которого нужно унаследоваться всем 
    // классам подлежащим клонированию. Данный способ будет работать, пока мы не наткнемся на подкласс, 
    // который уже от кого-то унаследован. Это главный минус данной реализации.

    // Внешняя зависимость ссылочного типа
    public class Dependency
    {
        public string Text { get; set; }

        public Dependency(string text)
        {
            this.Text = text;
        }
    }

    // Базовый класс для реализации клонирования. Имплементация ICloneable, описанного в .Net
    public abstract class CloneableBase : ICloneable
    {
        // Основной метод клонирования
        public object Clone()
        {
            // Осуществляем неполное клонирование (ссылки копираются, но новые не создаются)
            var clone = (CloneableBase)this.MemberwiseClone();
            // Если нужно полное, то в HandleCloned вручную делаем копии для ссылочных типов
            HandleCloned(clone);
            return clone;
        }

        // Дополнительный метод, предназначенный для расширения логики клонирования
        protected virtual void HandleCloned(CloneableBase clone)
        {
            // Возможно в абстрактном классе ничего делать не нужно, а вот в дочерних
            // классах пригодится для обработки, например, ссылочных типов.
            // Посколько класс виртуальный, то его реализация необязательна.
        }
    }

    // Клон реализующий ICloneable
    public class CloneablePrototypeAdvanced : CloneableBase
    {
        public string Name;
        public Dependency Dependency;

        public CloneablePrototypeAdvanced(string name, Dependency dependency)
        {
            this.Name = name;
            this.Dependency = dependency;
        }

        // Переопределив данный метод, данный код будет срабатывать при вызове Clone() 
        protected override void HandleCloned(CloneableBase baseClone)
        {
            // Выполняем операции из базового класса 
            base.HandleCloned(baseClone);

            // Приводим клона к текущему типу
            CloneablePrototypeAdvanced clone = (CloneablePrototypeAdvanced)baseClone;

            // Дополнительная логика. Здесь, например, происходит копирование ссылочной
            // сущности 
            clone.Dependency = new Dependency(this.Dependency.Text);
        }
    }
}
