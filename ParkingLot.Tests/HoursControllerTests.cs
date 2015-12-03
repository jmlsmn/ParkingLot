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
    public class HoursControllerTests
    {
        private Mock<IParkingSpaceService> _parkingSpaceServiceMock;
        private Mock<IVehicleService> _vehicleServiceMock;
        private HoursController _hoursController;

        [TestInitialize]
        public void Initialize()
        {
            _parkingSpaceServiceMock = new Mock<IParkingSpaceService>();
            _vehicleServiceMock = new Mock<IVehicleService>();
        }

        [TestClass]
        public class GetMethod : HoursControllerTests
        {
            [TestMethod]
            public void Get_ShouldReturnOkWithValidHours()
            {
                //Arrange
                var vehicle = new Vehicle()
                {
                    Id = 1,
                    ParkingSpaceId = 2,
                    EntryTime = DateTime.Now
                };
                int hours = 2;

                _parkingSpaceServiceMock.Setup(x => x.UpdateAvailability(It.IsAny<int>(), It.IsAny<bool>()));
                _vehicleServiceMock.Setup(x => x.GetVehicle(It.IsAny<int>())).Returns(vehicle);
                _vehicleServiceMock.Setup(x => x.GetParkedTimeInHours(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(hours);
                _hoursController = new HoursController(_vehicleServiceMock.Object, _parkingSpaceServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _hoursController.Get(1);
                var contentResult = actionResult as OkNegotiatedContentResult<int>;

                //Assert
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(hours, contentResult.Content);
            }

            [TestMethod]
            public void Get_ShouldReturnNotFound()
            {
                //Arrange
                Vehicle vehicle = null;
                int hours = 2;
                _parkingSpaceServiceMock.Setup(x => x.UpdateAvailability(It.IsAny<int>(), It.IsAny<bool>()));
                _vehicleServiceMock.Setup(x => x.GetVehicle(It.IsAny<int>())).Returns(vehicle);
                _vehicleServiceMock.Setup(x => x.GetParkedTimeInHours(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(hours);
                _hoursController = new HoursController(_vehicleServiceMock.Object, _parkingSpaceServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _hoursController.Get(1);
                var contentResult = actionResult as NotFoundResult;

                //Assert
                Assert.IsNotNull(contentResult);
            }
        }
    }
}
