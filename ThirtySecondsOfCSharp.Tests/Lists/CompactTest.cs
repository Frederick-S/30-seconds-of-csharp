using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class CompactTest
    {
        [Fact]
        public void ShouldReturnAllNonNullValues()
        {
            var list = new List<string> { "a", null, "c", null };
            var expectedList = new List<string> { "a", "c" };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Compact(list));
        }
    }
}