using System;
using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class GroupByTest
    {
        [Fact]
        public void ShouldMapToTwoGrups()
        {
            var numbers = new List<double> { 6.1, 4.2, 6.3 };
            var expectedGroups = new Dictionary<double, List<double>>
            {
                { 4, new List<double> { 4.2 } },
                { 6, new List<double> { 6.1, 6.3 } },
            };

            Assert.Equal(expectedGroups, ThirtySecondsOfCSharp.Lists.Lists.GroupBy(numbers, Math.Floor));
        }
    }
}
