using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class MapObjectTest
    {
        [Fact]
        public void ShouldReturnADictionary()
        {
            var list = new List<int> { 1, 2, 3 };
            var expectedDictionary = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 4 },
                { 3, 9 },
            };

            Assert.Equal(expectedDictionary, ThirtySecondsOfCSharp.Lists.Lists.MapObject(list, x => x * x));
        }
    }
}
