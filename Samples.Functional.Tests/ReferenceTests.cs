using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Transfer;
using Samples.Functional.Transfer.Entities;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class ReferenceTests
    {
        [TestMethod]
        public void TestShouldCreateReference_invalid()
        {
            // Arrange
            const string reference = null;

            // Act
            var result = Reference.Of(reference);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("Reference is invalid.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateReference_validated()
        {
            // Arrange
            const string reference = "";

            // Act
            var result = Reference.Of(reference);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(reference, result.GetObject().Value);
        }
    }
}