namespace Numbers
{
    public class CountPrimeNumbers : SolutionProviderBase
    {
        private int upperLimit;
        public CountPrimeNumbers(int upperLimit)
        {
            this.upperLimit = upperLimit;
        }

        public override int CalculateSolution()
        {
            int cnt = 0;
            for(int i = 2; i < this.upperLimit; i++)
            {
                if(IsPrime(i))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private bool IsPrime(int n)
        {
            for(int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
