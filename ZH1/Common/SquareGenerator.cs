using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SquareGenerator : ITextSequenceSource
    {
        int N;
        public SquareGenerator(int N)
        {
            this.N = N;
        }
        public IEnumerable<string> GenerateTexts()
        {
            for(int i = 0; i < N; i++)
            {
                int gyok = (int)Math.Sqrt(i);
                if (gyok * gyok == i)
                    yield return $"Az {i} négyzetszám";
            }
        }
    }
}
