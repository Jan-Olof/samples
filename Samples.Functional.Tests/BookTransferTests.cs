﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual("Transfer date cannot be in the past", e.Single().Message);
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
            Assert.AreEqual(date, result.GetValidObject().DateOfTransfer.Value);
        }
    }
}