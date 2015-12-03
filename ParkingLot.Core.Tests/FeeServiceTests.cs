using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Core.Services;
using ParkingLot.Core.Interfaces.Services;

namespace ParkingLot.Core.Tests
{
    [TestClass]
    public class FeeServiceTests
    {
        private IFeeService _feeService;

        [TestInitialize]
        public void Initialize()
        {
            _feeService = new FeeService();
        }

        [TestMethod]
        public void CalculateFees_WithZeroHours_ShouldReturnValidFee()
        {
            //Arrange
            int hours = 0;
            decimal expectedResult = 5.00M;

            //Act
            decimal result = _feeService.CalculateFees(hours);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateFees_WithTwoHours_ShouldReturnValidFee()
        {
            //Arrange
            int hours = 2;
            decimal expectedResult = 5.00M;

            //Act
            decimal result = _feeService.CalculateFees(hours);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateFees_WithTenHours_ShouldReturnValidFee()
        {
            //Arrange
            int hours = 10;
            decimal expectedResult = 10.00M;

            //Act
            decimal result = _feeService.CalculateFees(hours);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CalculateFees_WithGreaterThanTenHours_ShouldReturnValidFee()
        {
            //Arrange
            int hours = 20;
            decimal expectedResult = 15.00M;

            //Act
            decimal result = _feeService.CalculateFees(hours);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateFees_WithNegativeHours_ShouldThrowError()
        {
            //Arrange
            int hours = -1;

            //Act
            decimal result = _feeService.CalculateFees(hours);
        }
    }
}
