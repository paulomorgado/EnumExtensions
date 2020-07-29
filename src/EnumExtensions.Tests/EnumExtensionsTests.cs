using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PauloMorgado.Extensions.UseCases;

namespace PauloMorgado.Extensions.Tests
{
    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetValues_ReturnsTheSameItemsAsEnumGetValues()
        {
            CollectionAssert.AreEquivalent(new List<TestEnum>(((TestEnum[])Enum.GetValues(typeof(TestEnum))).Distinct()), EnumExtensions.GetValues<TestEnum>());
        }

        [TestMethod]
        public void GetNames_ReturnsTheSameItemsAsEnumGetNames()
        {
            CollectionAssert.AreEquivalent(Enum.GetNames(typeof(TestEnum)), EnumExtensions.GetNames<TestEnum>());
        }

        [TestMethod]
        public void GetName_ReturnsTheSameItemsAsEnumGetName()
        {
            foreach (TestEnum value in Enum.GetValues(typeof(TestEnum)))
            {
                Assert.AreEqual(Enum.GetName(typeof(TestEnum), value), value.GetName(), $"Wrong name for '{value}'");
            }
        }

        [TestMethod]
        public void IsDefined_WithDefinedValue_ReturnsTrue()
        {
            Assert.IsTrue(((TestEnum)0).IsDefined());
        }

        [TestMethod]
        public void IsDefined_WithNotDefinedValue_ReturnsFalse()
        {
            Assert.IsFalse(((TestEnum)(-1)).IsDefined());
        }
    }
}
