using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Tests.SampleObjects;
using System;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class TransferFunctionsTests
    {
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

            var transfer = result.Match(e => new BookTransfer(), t => t);
            Assert.IsNull(transfer.Reference);
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