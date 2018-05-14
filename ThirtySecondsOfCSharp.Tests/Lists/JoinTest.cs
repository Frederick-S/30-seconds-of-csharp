using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class JoinTest
    {
        [Fact]
        public void ShouldJoinListToStringWithSpecifiedSeparator()
        {
            var list = new List<string> { "pen", "pineapple", "apple", "pen" };

            Assert.Equal("pen,pineapple,apple&pen", ThirtySecondsOfCSharp.Lists.Lists.Join(list, ",", "&"));
        }

        [Fact]
        public void ShouldJoinListToStringWithDefaultSeparator()
        {
            var list = new List<string> { "pen", "pineapple", "apple", "pen" };

            Assert.Equal("pen,pineapple,apple,pen", ThirtySecondsOfCSharp.Lists.Lists.Join(list));
        }
    }
}
