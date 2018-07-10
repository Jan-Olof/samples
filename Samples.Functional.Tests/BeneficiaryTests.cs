using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Transfer;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class BeneficiaryTests
    {
        [TestMethod]
        public void TestShouldCreateBookTransfer_invalid()
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
        public void TestShouldCreateBookTransfer_validated()
        {
            // Arrange
            const string beneficiery = "Yua Mikami";

            // Act
            var result = Beneficiary.Of(beneficiery);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(beneficiery, result.GetValidObject().Value);
        }
    }
}