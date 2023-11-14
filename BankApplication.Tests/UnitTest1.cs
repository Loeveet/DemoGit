using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckToSeeIfAmountIsAddedToBalance()
        {
            // Arrange
            var sut = new Account();
            sut.Balance = 100;
            var amount = 50;
            var expected = 150;

            // Act
            var actual = sut.Deposit(sut, amount);

            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckToSeeIfAmountCanBeWithdrawelFromBalance()
        {
            // Arrange
            var sut = new Account();
            sut.Balance = 100;
            var amount = 50;
            var expected = 50;

            // Act
            var actual = sut.Withdrawal(sut, amount);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}