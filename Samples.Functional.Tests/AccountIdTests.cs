using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using Samples.Functional.Transfer.Entities;
using System;
using System.Linq;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class AccountIdTests
    {
        [TestMethod]
        public void TestShouldCreateAccountId_invalid()
        {
            // Arrange
            const string accountId = "asdfgh12345";

            // Act
            var result = AccountId.Of(accountId);

            // Assert
            Assert.IsFalse(result.IsValid);
            var e = result.GetErrors().ToList();
            Assert.AreEqual(1, e.Count);
            Assert.AreEqual($"No account with id {accountId} was found.", e.Single().Message);
        }

        [TestMethod]
        public void TestShouldCreateAccountId_validated()
        {
            // Arrange
            const string accountId = "fb325803-b135-48b0-8b24-063666203929";

            // Act
            var result = AccountId.Of(accountId);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(Guid.Parse(accountId), result.GetObject().Value);
        }
    }
}