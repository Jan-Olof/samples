using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer.Entities;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class BicTests
    {
        [TestMethod]
        public void TestShouldCreateBic_invalid()
        {
            // Arrange
            const string bic = "bicbi1234";

            // Act
            var result = Bic.Of(bic);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("The beneficiary's BIC/SWIFT code is invalid", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateBic_validated()
        {
            // Arrange
            const string bic = "asdfgh12345";

            // Act
            var result = Bic.Of(bic);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(bic, result.GetObject().Value);
        }
    }
}