using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class CountByTest
    {
        [Fact]
        public void ShouldGroupStringsIntoTwoGroups()
        {
            var strings = new List<string> { "one", "two", "three" };
            var expectedGroups = new Dictionary<int, int>
            {
                { 3, 2 },
                { 5, 1 },
            };

            Assert.Equal(expectedGroups, ThirtySecondsOfCSharp.Lists.Lists.CountBy(strings, x => x.Length));
        }
    }
}
