using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class BookTransferTests
    {
        [TestMethod]
        public void TestShouldCreateBookTransfer_validated()
        {
            // Arrange
            var date = new DateTime(2018, 6, 6);
            var dto = SampleObjects.SampleBookTransferDtos.CreateBookTransferDto(date);
            DateTime now() => new DateTime(2018, 6, 5);

            // Act
            var result = dto.CreateBookTransfer(now);

            // Assert
        }
    }
}