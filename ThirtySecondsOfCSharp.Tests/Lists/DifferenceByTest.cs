using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DifferenceByTest
    {
        [Fact]
        public void ShouldReturnValuesOnlyInListA()
        {
            var a = new List<double> { 2.1, 1.2 };
            var b = new List<double> { 2.3, 3.4 };
            var difference = new List<double> { 1.2 };

            Assert.Equal(difference, ThirtySecondsOfCSharp.Lists.Lists.DifferenceBy(a, b, Math.Floor));
        }
    }
}