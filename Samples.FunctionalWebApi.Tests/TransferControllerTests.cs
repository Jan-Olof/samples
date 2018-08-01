using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Tests.SampleObjects;
using Samples.Functional.Transfer;
using Samples.FunctionalWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.FunctionalWebApi.Tests
{
    [TestClass]
    public class TransferControllerTests
    {
        [TestMethod]
        public void TestShouldGetTransferFromIban()
        {
            // Given
            var controller = CreateController(SampleBookTransferDaos.CreateBookTransferDaos());

            // When
            var result = controller.GetTransfersFromIban("CH56 0483 5012 3456 7800 9");

            // Then
            var r = (OkObjectResult)result;
            var dto = (IEnumerable<BookTransferDto>)r.Value;

            Assert.AreEqual(200, r.StatusCode);
            Assert.AreEqual("CH56 0483 5012 3456 7800 9", dto.Single().Iban);
        }

        [TestMethod]
        public void TestShouldGetTransferFromId()
        {
            // Given
            var controller = CreateController(SampleBookTransferDaos.CreateBookTransferDaos());

            // When
            var result = controller.GetTransferFromId(33);

            // Then
            var r = (OkObjectResult)result;
            var dto = (BookTransferDto)r.Value;

            Assert.AreEqual(200, r.StatusCode);
            Assert.AreEqual(33, dto.Id);
        }

        [TestMethod]
        public void TestShouldGetTransfers()
        {
            // Given
            var controller = CreateController(SampleBookTransferDaos.CreateBookTransferDaos());

            // When
            var result = controller.GetTransfers();

            // Then
            var r = (OkObjectResult)result;
            var dto = (IEnumerable<BookTransferDto>)r.Value;

            Assert.AreEqual(200, r.StatusCode);
            Assert.AreEqual("CH56 0483 5012 3456 7800 9", dto.Single().Iban);
        }

        private static TransferController CreateController(IEnumerable<BookTransferDao> transfers)
            => new TransferController(
                new FakeLogger(),
                (template, dao) => 1,
                (template, o) => transfers,
                () => new DateTime(2018, 7, 30, 7, 7, 7));
    }
}