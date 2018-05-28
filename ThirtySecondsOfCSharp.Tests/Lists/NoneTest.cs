using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class NoneTest
    {
        [Fact]
        public void ShouldReturnTrue()
        {
            var list = new List<int> { 0, 1, 3, 0 };

            Assert.True(ThirtySecondsOfCSharp.Lists.Lists.None(list, x => x == 2));
        }

        [Fact]
        public void ShouldReturnFalse()
        {
            var list = new List<int> { 0, 1, 3, 0, 2 };

            Assert.False(ThirtySecondsOfCSharp.Lists.Lists.None(list, x => x == 2));
        }
    }
}
