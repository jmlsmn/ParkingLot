using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Core.Interfaces.Services;
using Moq;
using ParkingLot.Controllers;
using ParkingLot.Core.Domain;
using System.Web.Http;
using System.Web.Http.Results;

namespace ParkingLot.Tests
{
    [TestClass]
    public class FeesControllerTests
    {
        private Mock<IParkingSpaceService> _parkingSpaceServiceMock;
        private Mock<IFeeService> _feeServiceMock;
        private FeesController _feesController;

        [TestInitialize]
        public void Initialize()
        {
            _parkingSpaceServiceMock = new Mock<IParkingSpaceService>();
            _feeServiceMock = new Mock<IFeeService>();
        }

        [TestClass]
        public class GetMethod : FeesControllerTests
        {
            [TestMethod]
            public void Get_ShouldReturnOkWithValidFee()
            {
                //Arrange
                var parkingSpace = new ParkingSpace()
                {
                    Id = 1,
                    IsAvailable = true
                };
                decimal fee = 5.00M;
                _parkingSpaceServiceMock.Setup(x => x.GetParkingSpace(It.IsAny<int>())).Returns(parkingSpace);
                _feeServiceMock.Setup(x => x.CalculateFees(It.IsAny<int>())).Returns(fee);
                _feesController = new FeesController(_parkingSpaceServiceMock.Object, _feeServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _feesController.Get(1,2);
                var contentResult = actionResult as OkNegotiatedContentResult<decimal>;

                //Assert
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(fee, contentResult.Content);
            }

            [TestMethod]
            public void Get_ShouldReturnNotFound()
            {
                //Arrange
                ParkingSpace parkingSpace = null;

                _parkingSpaceServiceMock.Setup(x => x.GetParkingSpace(It.IsAny<int>())).Returns(parkingSpace);
                _feeServiceMock.Setup(x => x.CalculateFees(It.IsAny<int>())).Returns(0.00M);
                _feesController = new FeesController(_parkingSpaceServiceMock.Object, _feeServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _feesController.Get(1, 2);
                var contentResult = actionResult as NotFoundResult;

                //Assert
                Assert.IsNotNull(contentResult);
            }
        }
    }
}
