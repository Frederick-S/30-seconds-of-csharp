using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class DeepFlattenTest
    {
        [Fact]
        public void ShouldDeepFlattenNumbers()
        {
            var numbers = new List<object>
            {
                1,
                new List<int> { 2 },
                new List<object>
                {
                    new List<int> { 3 },
                    4,
                },
                5,
            };
            var expectedList = new List<int> { 1, 2, 3, 4, 5 };
            var actualList = ThirtySecondsOfCSharp.Lists.Lists.DeepFlatten(numbers);

            Enumerable.Range(0, actualList.Count)
                .ToList()
                .ForEach(i => Assert.Equal(expectedList[i], actualList[i]));
        }
    }
}
