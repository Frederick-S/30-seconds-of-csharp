using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class HeadTest
    {
        [Fact]
        public void ShouldReturnTheFirstElement()
        {
            var numbers = new List<int> { 1, 2, 3 };

            Assert.Equal(1, ThirtySecondsOfCSharp.Lists.Lists.Head(numbers));
        }

        [Fact]
        public void ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThirtySecondsOfCSharp.Lists.Lists.Head(new List<int>()));
        }
    }
}
