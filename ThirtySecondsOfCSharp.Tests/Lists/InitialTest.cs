using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class InitialTest
    {
        [Fact]
        public void ShouldReturnAllElementsExceptTheLastOne()
        {
            var numbers = new List<int> { 1, 2, 3 };
            var expectedList = new List<int> { 1, 2 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.Initial(numbers));
        }

        [Fact]
        public void ShouldReturnEmptyList()
        {
            Assert.Equal(new List<int>(), ThirtySecondsOfCSharp.Lists.Lists.Initial(new List<int>()));
        }
    }
}
