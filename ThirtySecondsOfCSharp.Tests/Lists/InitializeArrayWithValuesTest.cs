using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class InitializeArrayWithValuesTest
    {
        [Fact]
        public void ShouldCreateListWithFiveTwos()
        {
            var expectedList = new List<int> { 2, 2, 2, 2, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithValues(5, 2));
        }
    }
}
