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
    public class AtbashTests
    {
        [TestMethod()]
        public void DecodeTest()
        {
            // Arrange
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string expected = "песочница";
            string input = "Пънрзсция";
            var atbash = new Atbash();

            // Act
            string actual = atbash.Decode(input, alphabet);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTest()
        {
            // Arrange
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string expected = "пънрзсция";
            string input = "Песочница";
            var atbash = new Atbash();

            // Act
            string actual = atbash.Encode(input,alphabet);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DecodeTestIncorrect()
        {
            // Arrange
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string expected = "";
            string input = "Iachiuh";
            var atbash = new Atbash();

            // Act
            string actual = atbash.Decode(input, alphabet);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EncodeTestIncorrect()
        {
            // Arrange
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string expected = "";
            string input = "Iachiuh";
            var atbash = new Atbash();

            // Act
            string actual = atbash.Encode(input, alphabet);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}