using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class FlattenTest
    {
        [Fact]
        public void ShouldFlattenListToDepthOne()
        {
            var list = new List<object>
            {
                1,
                new List<object> { 2 },
                3,
                4,
            };
            var expectedList = new List<int> { 1, 2, 3, 4 };
            var actualList = ThirtySecondsOfCSharp.Lists.Lists.Flatten(list);

            Enumerable.Range(0, actualList.Count)
                .ToList()
                .ForEach(i => Assert.Equal(expectedList[i], actualList[i]));
        }

        [Fact]
        public void ShouldFlattenListToDepthTwo()
        {
            var list = new List<object>
            {
                1,
                new List<object>
                {
                    2,
                    new List<object>
                    {
                        3,
                        new List<object> { 4, 5 },
                        6,
                    },
                    7,
                },
                8,
            };
            var expectedList = new List<object>
            {
                1,
                2,
                3,
                new List<object> { 4, 5 },
                6,
                7,
                8,
            };
            var actualList = ThirtySecondsOfCSharp.Lists.Lists.Flatten(list, 2);

            Enumerable.Range(0, actualList.Count)
                .ToList()
                .ForEach(i => Assert.Equal(expectedList[i], actualList[i]));
        }
    }
}
