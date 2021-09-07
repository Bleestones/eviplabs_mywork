namespace Numbers
{
    public class SolutionProviderBase
    {
        // Ennek csak a decoratorhoz kell virtualnak lennie.
        public virtual string GetSolutionText()
        {
            return "A megoldás: " + CalculateSolution().ToString();
        }

        public virtual int CalculateSolution()
        {
            return 0;
        }
    }
}
