using System.Collections.Generic;

namespace Common
{
    public interface ITextSequenceSource
    {
        public IEnumerable<string> GenerateTexts();
    }
}
