using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class NthElementTest
    {
        [Fact]
        public void ShouldReturnTheSecondElement()
        {
            var list = new List<char> { 'a', 'b', 'c' };

            Assert.Equal('b', ThirtySecondsOfCSharp.Lists.Lists.NthElement(list, 1));
        }

        [Fact]
        public void ShouldReturnTheFirstElement()
        {
            var list = new List<char> { 'a', 'b', 'c' };

            Assert.Equal('a', ThirtySecondsOfCSharp.Lists.Lists.NthElement(list, -3));
        }
    }
}
