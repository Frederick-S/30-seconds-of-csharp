using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class InitializeArrayWithRangeTest
    {
        [Fact]
        public void ShouldCreateNumberListFromZeroToFive()
        {
            var expectedList = new List<int> { 0, 1, 2, 3, 4, 5 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRange(5));
        }

        [Fact]
        public void ShouldCreateNumberListFromThreeToSeven()
        {
            var expectedList = new List<int> { 3, 4, 5, 6, 7 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRange(7, 3));
        }

        [Fact]
        public void ShouldCreateNumberListFromZeroToEightWithStepTwo()
        {
            var expectedList = new List<int> { 0, 2, 4, 6, 8 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRange(9, 0, 2));
        }
    }
}
