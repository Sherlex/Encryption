using Microsoft.VisualStudio.TestTools.UnitTesting;
using lr2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2.Tests
{
    [TestClass()]
    public class VigenerTests
    {
        [TestMethod()]
        public void DecodeTest()
        {
            // Arrange
            string expected = "ловикомпаратор";
            string key = "тест";
            string input = "юууыпаяфсгедбх";
            var vigener = new Vigener();

            // Act
            string actual = vigener.Decode(input, key);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTest()
        {
            // Arrange
            string key = "тест";
            string expected = "юууыпаяфсгедбх";
            string input = "Лови компаратор";
            var vigener = new Vigener();

            // Act
            string actual = vigener.Encode(input, key);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestIncorrect()
        {
            // Arrange
            string key = "тест";
            string expected = "";
            string input = "Iachiuh";
            var vigener = new Vigener();

            // Act
            string actual = vigener.Decode(input, key);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTestIncorrect()
        {
            // Arrange
            string key = "тест";
            string expected = "";
            string input = "Iachiuh";
            var vigener = new Vigener();

            // Act
            string actual = vigener.Encode(input, key);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}