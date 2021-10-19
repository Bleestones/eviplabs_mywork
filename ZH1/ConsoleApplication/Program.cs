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
        }

        public static void ShowTexts(ITextSequenceSource textSequenceSource)
        {
            var texts = textSequenceSource.GenerateTexts().ToList();
            for(int i = 0; i < texts.Count; i++)
            {
                Console.WriteLine($"{i} elem: {texts[i]}");
            }
        }
    }
}
