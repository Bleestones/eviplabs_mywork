namespace Numbers
{
    class SolutionDecorator : SolutionProviderBase
    {
        private SolutionProviderBase toDecorate;

        public SolutionDecorator(SolutionProviderBase whatToDecorate)
        {
            toDecorate = whatToDecorate;
        }

        public override string GetSolutionText()
        {
            return "---===<<< " + toDecorate.GetSolutionText() + " >>>===---";
        }
    }
}
