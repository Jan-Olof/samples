using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Functional.Helpers;
using System;

namespace Samples.Functional.Tests
{
    [TestClass]
    public class GuidHelperTests
    {
        [TestMethod]
        public void TestShouldParseStringIntoGuid()
        {
            // Arrange
            const string value = "54522a19-ddeb-4fe1-8c87-923a64380c77";

            // Act
            var result = value.ToGuid();

            // Assert
            Assert.AreEqual(Guid.Parse(value), result.Match(() => new Guid(), guid => guid));
        }

        [TestMethod]
        public void TestShouldParseStringIntoGuidAndFail()
        {
            // Arrange
            const string value = "54522a19-ddeb-4fe1-8c87-923a64380c7";

            // Act
            var result = value.ToGuid();

            // Assert
            Assert.IsTrue(result.Match(() => true, guid => false));
        }

        [TestMethod]
        public void TestShouldVerifyThatStringIsGuid()
        {
            // Arrange
            const string value = "54522a19-ddeb-4fe1-8c87-923a64380c77";

            // Act
            var result = value.IsGuid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestShouldVerifyThatStringIsNotGuid()
        {
            // Arrange
            const string value = "54522a19-ddeb-4fe1-8c87-923a64380c7";

            // Act
            var result = value.IsGuid();

            // Assert
            Assert.IsFalse(result);
        }
    }
}