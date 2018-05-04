using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class InitializeArrayWithRangeRightTest
    {
        [Fact]
        public void ShouldCreateNumberListFromFiveToZero()
        {
            var expectedList = new List<int> { 5, 4, 3, 2, 1, 0 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRangeRight(5));
        }

        [Fact]
        public void ShouldCreateNumberListFromSevenToThree()
        {
            var expectedList = new List<int> { 7, 6, 5, 4, 3 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRangeRight(7, 3));
        }

        [Fact]
        public void ShouldCreateNumberListFromEightToZeroWithStepTwo()
        {
            var expectedList = new List<int> { 8, 6, 4, 2, 0 };

            Assert.Equal(expectedList, ThirtySecondsOfCSharp.Lists.Lists.InitializeArrayWithRangeRight(9, 0, 2));
        }
    }
}
