using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer.Entities;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class BeneficiaryTests
    {
        [TestMethod]
        public void TestShouldCreateBeneficiary_invalid()
        {
            // Arrange
            const string beneficiery = "";

            // Act
            var result = Beneficiary.Of(beneficiery);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("The beneficiary must have a name.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateBeneficiary_validated()
        {
            // Arrange
            const string beneficiery = "Laurie Anderson";

            // Act
            var result = Beneficiary.Of(beneficiery);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(beneficiery, result.GetObject().Value);
        }
    }
}