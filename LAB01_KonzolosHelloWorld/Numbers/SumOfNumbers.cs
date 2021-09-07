namespace Numbers
{
    // Öröklés
    public class SumOfNumbers : SolutionProviderBase
    {
        // Erre jelezni fog a Visual Studio, hogy legyen readonly.
        private int upperLimit;

        // ctor snippet használata!
        public SumOfNumbers(int upperLimit)
        {
            // this kiemelése, mivel névegyezés van.
            this.upperLimit = upperLimit;
        }

        // override: IntelliSense használata!
        public override int CalculateSolution()
        {
            int sum = 0;
            for (int i = 1; i < upperLimit; i++)
                sum += i;
            return sum;
        }
    }
}
