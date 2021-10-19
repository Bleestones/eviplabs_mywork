using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Common;

namespace Tests
{
    public class DummyTests
    {
        [Fact]
        public void BasicTest()
        {
            var dummyGenerator = new DummyGenerator() { N = 10};
            Assert.Equal(10, dummyGenerator.GenerateTexts().Where(dummyText => dummyText.Equals("dummy")).Count());
        }
    }
}
