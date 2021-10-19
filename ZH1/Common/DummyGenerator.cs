using System.Collections.Generic;

namespace Common
{
    public class DummyGenerator : ITextSequenceSource
    {
        public int N { get; set; }
        public IEnumerable<string> GenerateTexts()
        {
            for (int i = 0; i < N; i++)
                yield return "dummy";
        }
    }
}
