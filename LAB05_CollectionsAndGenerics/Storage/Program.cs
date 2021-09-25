using System;
using System.Collections.Generic;

namespace Storage
{
    class Program
    {
        static void Main()
        {
            /*Store<IStorable> myStorage = new Store<IStorable>();

            AddItems(myStorage);
            Iterate(myStorage);
            Modify(myStorage);
            Reassign(myStorage);
            */
            Console.WriteLine("Done. Press any key...");
            Console.ReadLine();
        }

        static void AddItems(Store<IStorable> store)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    store.Insert(new Game(i.ToString(), 1, $"Best game{i}", "RPG", 2020));
                }
                else
                {
                    store.Insert(new Book(i.ToString(), 2, $"Boring book{i}", "Random"));
                }
            }
        }
        static void Iterate(Store<IStorable> store)
        {
            Console.WriteLine("Iterate in dictionary");
            Dictionary<string, IStorable> dictionary = store.GetAllDictionary();
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            /*
            Console.WriteLine("Iterate in list");
            List<IStorable> list = store.GetAllList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Iterate in array");
            var array = list.ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            */
        }
        static void Modify(Store<IStorable> store)
        {
            var list = store.GetAllList();
            foreach (var item in list) Console.WriteLine("Before: {0}", item);
            Console.WriteLine("Modify");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id.Equals("4")) list[i].Id = "427";
            }
            //ugyanez foreach-el
            /*
            foreach (var item in list)
            {
                if (item.Id.Equals("42")) item.Id="427";
            }
            */
            foreach (var item in list) Console.WriteLine("After: " + item);
        }
        static void Reassign(Store<IStorable> store)
        {
            Console.WriteLine("Reassign");
            var list = store.GetAllList();
            foreach (var item in list) Console.WriteLine("Before: " + item);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id.Equals("3")) list[i] = new Game();
            }
            //ugyanez foreach-el nem megy
            /*
            foreach (var item in list)
            {
                if (item.Id.Equals("3")) item = new Game();
            }
            */
            foreach (var item in list) Console.WriteLine("After: " + item);

            //COMMIT
        }
    }
}
