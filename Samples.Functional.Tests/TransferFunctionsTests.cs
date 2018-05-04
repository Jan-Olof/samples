using LaYumba.Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Tests.SampleObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class TransferFunctionsTests
    {
        [TestMethod]
        public void TestShouldValidateBic_failure()
        {
            // Given
            var bookTransfer = SampleBookTransfers.CreateBookTransfer(new DateTime(2018, 5, 4, 0, 0, 0), "bic");

            // When
            var result = bookTransfer.ValidateBic(TransferFunctions.BicCodeRegex());

            // Then
            Assert.IsFalse(result.IsValid);

            var errors = result.Match(e => e, t => new List<Error>());
            Assert.AreEqual("The beneficiary's BIC/SWIFT code is invalid", errors.Single().Message);
        }

        [TestMethod]
        public void TestShouldValidateBic_success()
        {
            // Given
            var bookTransfer = SampleBookTransfers.CreateBookTransfer(new DateTime(2018, 5, 4, 0, 0, 0));

            // When
            var result = bookTransfer.ValidateBic(TransferFunctions.BicCodeRegex());

            // Then
            Assert.IsTrue(result.IsValid);

            var transfer = result.Match(e => new BookTransfer(), t => t);
            Assert.AreEqual("bicbac1bec9", transfer.Bic);
        }

        [TestMethod]
        public void TestShouldValidateDate_failure()
        {
            // Given
            var bookTransfer = SampleBookTransfers.CreateBookTransfer(new DateTime(2018, 5, 4, 0, 0, 0));
            var now = new DateTime(2018, 5, 4, 17, 18, 34, 00);

            // When
            var result = bookTransfer.ValidateDate(now);

            // Then
            Assert.IsFalse(result.IsValid);

            var errors = result.Match(e => e, t => new List<Error>());
            Assert.AreEqual("Transfer date cannot be in the past", errors.Single().Message);
        }

        [TestMethod]
        public void TestShouldValidateDate_success()
        {
            // Given
            var bookTransfer = SampleBookTransfers.CreateBookTransfer(new DateTime(2018, 5, 4, 0, 0, 0));
            var now = new DateTime(2018, 5, 3, 17, 18, 34, 00);

            // When
            var result = bookTransfer.ValidateDate(now);

            // Then
            Assert.IsTrue(result.IsValid);

            var transfer = result.Match(e => new BookTransfer(), t => t);
            Assert.AreEqual("ref", transfer.Reference);
        }
    }
}