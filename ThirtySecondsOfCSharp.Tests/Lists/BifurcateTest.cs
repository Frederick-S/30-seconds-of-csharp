using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class BifurcateTest
    {
        [Fact]
        public void ShouldDivideNumbersIntoEvenAndOdd()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = new List<int> { 2, 4, 6 };
            var oddNumbers = new List<int> { 1, 3, 5 };
            var groups = ThirtySecondsOfCSharp.Lists.Bifurcate(numbers, x => x % 2 == 0);

            Assert.Equal(evenNumbers, groups[0]);
            Assert.Equal(oddNumbers, groups[1]);
        }
    }
}