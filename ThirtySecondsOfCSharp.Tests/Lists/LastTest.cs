using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class LastTest
    {
        [Fact]
        public void ShouldReturnLastElement()
        {
            var list = new List<int> { 1, 2, 3 };

            Assert.Equal(3, ThirtySecondsOfCSharp.Lists.Lists.Last(list));
        }
    }
}
