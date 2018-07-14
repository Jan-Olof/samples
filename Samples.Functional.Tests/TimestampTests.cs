using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Transfer;
using Samples.Functional.Transfer.Entities;
using System;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class TimestampTests
    {
        [TestMethod]
        public void TestShouldCreateTimestamp_invalid()
        {
            // Arrange
            var date = new DateTime(2018, 6, 4, 7, 7, 7);
            DateTime Now() => new DateTime(2018, 6, 4, 7, 0, 0);

            // Act
            var result = Timestamp.Of(date, Now);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual("Timestamp is invalid. (Has not occured yet.)", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateTimestamp_validated()
        {
            // Arrange
            var date = new DateTime(2018, 6, 4, 7, 7, 7);
            DateTime Now() => new DateTime(2018, 6, 4, 8, 0, 0);

            // Act
            var result = Timestamp.Of(date, Now);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(date, result.GetObject().Value);
        }
    }
}