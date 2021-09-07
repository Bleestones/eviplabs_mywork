using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class SumOfPrimeNumbers : SolutionProviderBase
    {
        private int upperLimit;
        public SumOfPrimeNumbers(int upperLimit)
        {
            this.upperLimit = upperLimit;
        }

        public override int CalculateSolution()
        {
            int sum = 0;
            for (int i = 2; i < this.upperLimit; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
