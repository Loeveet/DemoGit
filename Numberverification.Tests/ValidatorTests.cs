using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numberverification.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("0-306-40615-2", true)]
        [InlineData("3-598-21508-8", true)]
        [InlineData("3-598-21508-7", false)]
        [InlineData("99-85214-24-X", false)]
        [InlineData("99-85214-24X", false)]
        [InlineData("99-8521424X", false)]
        [InlineData("99A5214249", false)]
        [InlineData("99521424X", false)]
        public void ValidIsbn10ShouldReturnAsExpected(string isbn, bool expected)
        {
            TestingIsbn10(isbn, expected);
        }

        private static void TestingIsbn10(string isbn, bool expected)
        {

            // Arrange
            var validator = new Validator();

            // Act
            bool actual = validator.IsValidIsbn10(isbn);

            // Assert
            Assert.Equal(expected, actual);
        }

        //[Theory]
        //[InlineData("978-1522707684", true)]
        //[InlineData("978-1434242570", true)]
        //[InlineData("9781434246257", true)]
        //[InlineData("978-0-306-40615-X", true)]
        //[InlineData("978-0061120083", false)]
        //[InlineData("978-0307260610", false)]
        //[InlineData("978-1234567890123", false)]
        //[InlineData("978-123456789", false)]
        //public void ValidIsbn13ShouldReturnAsExpected(string isbn, bool expected)
        //{
        //    TestingIsbn13(isbn, expected);
        //}


        //private static void TestingIsbn13(string isbn, bool expected)
        //{

        //    // Arrange
        //    var validator = new Validator();

        //    // Act
        //    bool actual = validator.IsValidIsbn13(isbn);

        //    // Assert
        //    Assert.Equal(expected, actual);
        //}
    }
}
