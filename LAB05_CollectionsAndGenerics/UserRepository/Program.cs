using System;
using System.Diagnostics;

namespace UserRepository
{
    class Program
    {

        static void Main(string[] args)
        {
            ArrayUserRepository arrayUserRepository = new ArrayUserRepository();
            Measure(arrayUserRepository);

            ListUserRepository listUserRepository = new ListUserRepository();
            Measure(listUserRepository);

            OrderedListUserRepository orderedListUserRepository = new OrderedListUserRepository();
            Measure(orderedListUserRepository);

            LinkedListUserRepository linkedListUserRepository = new LinkedListUserRepository();
            Measure(linkedListUserRepository);

            DictionaryUserRepository dictionaryUserRepository = new DictionaryUserRepository();
            Measure(dictionaryUserRepository);

            Console.WriteLine("Done. Press any key. :)");
            Console.ReadKey();
        }

        static void Measure(IUserRepository userRepository)
        {
            Console.WriteLine(userRepository.GetType().Name);
            MeasurePopulateUsers(userRepository);
            MeasureGetByIdNumber(userRepository);
            Console.WriteLine();
        }

        static void MeasurePopulateUsers(IUserRepository userRepository)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            PopulateUsers(userRepository);

            stopwatch.Stop();
            Console.WriteLine("Populate User running time: {0}", stopwatch.Elapsed);
        }

        static void MeasureGetByIdNumber(IUserRepository userRepository)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random rnd = new Random();
            stopwatch.Start();

            int times = 10000;
            for (int i = 0; i < times; i++)
            {
                var id = rnd.Next(9000);
                userRepository.GetById(id.ToString());
            }

            stopwatch.Stop();
            Console.WriteLine($"Get by id number x{times} running time: {stopwatch.Elapsed}");
        }

        static void PopulateUsers(IUserRepository userRepository)
        {
            int count = 9000;
            userRepository.Insert(new User($"John0", $"Doe0", 23, "0"));
            for (int i = count - 1; i > 0; i--)
            {
                userRepository.Insert(new User($"John{i}", $"Doe{i}", 23, i.ToString()));
            }
            userRepository.Insert(new User($"John{count}", $"Doe{count}", 23, count.ToString()));
        }
    }
}
