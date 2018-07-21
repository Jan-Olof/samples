using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer;
using System;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class BookTransferTests
    {
        [TestMethod]
        public void TestShouldCreateBookTransfer_invalid()
        {
            // Arrange
            var date = new DateTime(2018, 6, 6);
            var dto = SampleObjects.SampleBookTransferDtos.CreateBookTransferDto(date);
            DateTime Now() => new DateTime(2018, 6, 7);

            // Act
            var result = dto.CreateBookTransfer(Now);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("Transfer date cannot be in the past.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateBookTransfer_validated()
        {
            // Arrange
            var date = new DateTime(2018, 6, 6);
            var dto = SampleObjects.SampleBookTransferDtos.CreateBookTransferDto(date);
            DateTime Now() => new DateTime(2018, 6, 5);

            // Act
            var result = dto.CreateBookTransfer(Now);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(date, result.GetObject().DateOfTransfer.Value);
            Assert.AreEqual(10000, result.GetObject().AmountToTransfer.Value);
            Assert.AreEqual("bla", result.GetObject().BeneficiaryOfTransfer.Value);
            Assert.AreEqual("bicbac1bec9", result.GetObject().BicCode.Value);
            Assert.AreEqual(Guid.Parse("853a2670-506b-4dcf-8cda-79f2f58d1f92"), result.GetObject().DebitedAccountId.Value);
            Assert.AreEqual("CH56 0483 5012 3456 7800 9", result.GetObject().InternationalBankAccountNumber.Value);
            Assert.AreEqual("ref", result.GetObject().ReferenceOfTransfer.Value);
            Assert.AreEqual(new DateTime(2018, 6, 1, 7, 8, 9), result.GetObject().TimestampOfTransfer.Value);
        }
    }
}