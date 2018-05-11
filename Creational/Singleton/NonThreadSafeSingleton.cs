using System;

namespace Singleton
{
    // Непотокобезопасная реализация Одиночки
    // Два потока могут одновременно обратиться к Instance, получить true в условии
    // и породить каждый новую сущность. 
    // Не рекомендуется
    public class NonThreadSafeSingleton
    {
        // Единственная сущность данного класса
        private static NonThreadSafeSingleton _nonThreadSafeSingleton;

        // Делаем конструктор закрытым, тем самым запрещая создавать новый объект извне
        private NonThreadSafeSingleton()
        {

        }

        // При первом обращении к сущность создаётся новый объект, при последующих обращениях возвращается 
        // уже существующий объект.
        public static NonThreadSafeSingleton Instance => 
            _nonThreadSafeSingleton ?? (_nonThreadSafeSingleton = new NonThreadSafeSingleton());

        public void DoSomething()
        {
            Console.WriteLine("Сервис существует в единственном экзмепляре, но потоконебезопасен");
        }
    }
}