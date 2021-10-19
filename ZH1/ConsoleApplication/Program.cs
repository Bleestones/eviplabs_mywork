using System;
using Common;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowTexts(new DummyGenerator() { N = 5 });
            var firstTenSquareResult = new SquareGenerator(10);
            Console.WriteLine($"10 négyzetszám közül, azon számok száma, melyben van 6-s karakter: {firstTenSquareResult.GenerateTexts().Where(value => value.Contains("6")).Count()}");
        }

        public static void ShowTexts(ITextSequenceSource textSequenceSource)
        {
            var texts = textSequenceSource.GenerateTexts().ToList();
            for (int i = 0; i < texts.Count; i++)
                Console.WriteLine($"{i} elem: {texts[i]}");
        }
    }
}
