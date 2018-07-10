using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Transfer;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class AmountTests
    {
        [TestMethod]
        public void TestShouldCreateAmount_invalid()
        {
            // Arrange
            const decimal amount = 0;

            // Act
            var result = Amount.Of(amount);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("The amount is a negative value.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateAmount_validated()
        {
            // Arrange
            const decimal amount = 0.1m;

            // Act
            var result = Amount.Of(amount);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(amount, result.GetValidObject().Value);
        }
    }
}