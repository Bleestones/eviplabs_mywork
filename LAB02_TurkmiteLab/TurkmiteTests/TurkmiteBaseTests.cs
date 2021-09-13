using Xunit;
using TurkMite;
using OpenCvSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurkmiteTests
{
    [TestClass]
    public class TurkmiteBaseTests
    {
        [TestMethod]
        public void Instantiation()
        {
            var t = new OriginalTurkmite(new Mat(10, 10, MatType.CV_8UC3));
        }
    }
}
