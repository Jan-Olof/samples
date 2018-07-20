using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class EnumerableHelperTests
    {
        [TestMethod]
        public void TestShouldAddMany()
        {
            // Given
            var x = new List<string> { "a", "b" };
            var y = new List<string> { "c", "d", "e" };

            // When
            var result = x.AddMany(y);

            // Then
            Assert.AreEqual(5, result.Count());
        }
    }
}