using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer.Entities;
using System;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class TransferDateTests
    {
        [TestMethod]
        public void TestShouldCreateTransferDate_invalid()
        {
            // Arrange
            var date = new DateTime(2018, 6, 4);
            DateTime Now() => new DateTime(2018, 6, 5);

            // Act
            var result = TransferDate.Of(date, Now);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("Transfer date cannot be in the past.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateTransferDate_validated()
        {
            // Arrange
            var date = new DateTime(2018, 6, 6);
            DateTime Now() => new DateTime(2018, 6, 5);

            // Act
            var result = TransferDate.Of(date, Now);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(date, result.GetObject().Value);
        }
    }
}