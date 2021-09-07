using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SolutionProviderBase solution = new SolutionProviderBase();

            Console.WriteLine("SolutionProviderBase: " + solution.GetSolutionText() );

            solution = new SumOfNumbers(10);
            Console.WriteLine("SumOfNumbers: " + solution.GetSolutionText());

            solution = new SolutionDecorator(new SumOfNumbers(10));
            Console.WriteLine("Decorated SumOfNumbers: " + solution.GetSolutionText());

            Console.ReadKey();
        }
    }
}
