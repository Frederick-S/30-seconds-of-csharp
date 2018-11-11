using System.Collections.Generic;
using Xunit;

namespace ThirtySecondsOfCSharp.Tests.Lists
{
    public class ArrayToCSVTest
    {
        [Fact]
        public void ShouldConvertListToCSVString()
        {
            var list = new List<List<string>>
            {
                new List<string> { "a", "b" },
                new List<string> { "c", "d" },
            };

            Assert.Equal("\"a\",\"b\"\n\"c\",\"d\"", ThirtySecondsOfCSharp.Lists.Lists.ArrayToCSV(list));
        }
    }
}
