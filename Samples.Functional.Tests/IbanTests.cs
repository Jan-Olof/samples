using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer.Entities;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class IbanTests
    {
        [TestMethod]
        public void TestShouldCreateIban_invalid()
        {
            // Arrange
            const string iban = "";

            // Act
            var result = Iban.Of(iban);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("Iban is invalid.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateIban_validated()
        {
            // Arrange
            const string iban = "123456789";

            // Act
            var result = Iban.Of(iban);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(iban, result.GetObject().Value);
        }
    }
}