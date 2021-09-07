using DotNetStandardClassLibrary;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var w = new Worker();
            Assert.Equal(5, w.GetNumber());
        }
    }
}
