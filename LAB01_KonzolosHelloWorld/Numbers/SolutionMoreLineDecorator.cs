using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class SolutionMoreLineDecorator : SolutionProviderBase
    {
        private SolutionProviderBase toDecorate;

        public SolutionMoreLineDecorator(SolutionProviderBase whatToDecorate)
        {
            this.toDecorate = whatToDecorate;
        }

        public override string GetSolutionText()
        {
            return "\n<EViP tárgy első laborfeladatának designos megoldása>\n"
                + toDecorate.GetSolutionText();
        }
    }
}
