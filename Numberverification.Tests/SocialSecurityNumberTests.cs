namespace Numberverification.Tests
{
    public class SocialSecurityNumberTests
    {
        private readonly string _regexPattern = @"^(19|20)?\d{6}[-+]?\d{4}$";

        [Fact]
        public void SocialSecurityNumberThrowsInvalidNumbersExceptionWhenWrongFormat()
        {
            var sut = new SocialSecurityNumber();
            sut.Numbers = "19880924-165912";

            //Assert
            Assert.ThrowsAny<InvalidOperationException>(() => sut.ValidateSocialSecurityNumberFormat());

        }

        [Theory]
        [InlineData("19880924--1659")]
        [InlineData("198811310000")]
        [InlineData("198809241659")]
        public void SocialSecurityNumberThrowsInvalidNumbersExceptionWhenWrong(string numbers)
        {
            var sut = new SocialSecurityNumber();
            sut.Numbers = numbers;
            

            //Assert
            Assert.Matches(_regexPattern, sut.Numbers);

        }
    }
}