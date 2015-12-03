using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Core.Interfaces.Repositories;
using Moq;
using ParkingLot.Core.Domain;
using ParkingLot.Core.Interfaces.Services;
using ParkingLot.Core.Services;

namespace ParkingLot.Core.Tests
{
    [TestClass]
    public class VehicleServiceTests
    {
        private Mock<IRepository<Vehicle>> _vehicleRepositoryMock;
        private IVehicleService _vehicleService;

        [TestInitialize]
        public void Initialize()
        {
            _vehicleRepositoryMock = new Mock<IRepository<Vehicle>>();
        }

        [TestClass]
        public class GetVehicleMethod : VehicleServiceTests
        {
            [TestMethod]
            public void GetVehicle_ReturnsVehicle()
            {
                //Arrange
                var vehicle = new Vehicle()
                {
                    Id = 1,
                    ParkingSpaceId = 2,
                    EntryTime = DateTime.Now
                };

                _vehicleRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(vehicle);
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                Vehicle result = _vehicleService.GetVehicle(1);

                //Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Vehicle));
            }

            [TestMethod]
            public void GetVehicle_ReturnsNull()
            {
                //Arrange
                Vehicle vehicle = null;

                _vehicleRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(vehicle);
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                Vehicle result = _vehicleService.GetVehicle(1);

                //Assert
                Assert.IsNull(result);
            }
        }

        [TestClass]
        public class GetParkedTimeInHoursMethod : VehicleServiceTests
        {
            [TestMethod]
            public void GetParkedTimeInHours_ReturnsPositiveHours()
            {
                //Arrange
                int expectedHours = 3;
                DateTime entryTime = DateTime.Now;
                DateTime exitTime = entryTime.AddHours(expectedHours);
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                int result = _vehicleService.GetParkedTimeInHours(entryTime, exitTime);

                //Assert
                Assert.AreEqual(expectedHours, result);
            }

            [TestMethod]
            public void GetParkedTimeInHours_ReturnsZeroHours()
            {
                //Arrange
                int expectedHours = 0;
                DateTime entryTime = DateTime.Now;
                DateTime exitTime = entryTime.AddHours(expectedHours);
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                int result = _vehicleService.GetParkedTimeInHours(entryTime, exitTime);

                //Assert
                Assert.AreEqual(expectedHours, result);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void GetParkedTimeInHours_ThrowsArgumentException()
            {
                //Arrange
                int expectedHours = 2;
                DateTime exitTime = DateTime.Now;
                DateTime entryTime = exitTime.AddHours(expectedHours);
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                int result = _vehicleService.GetParkedTimeInHours(entryTime, exitTime);

            }
        }

        [TestClass]
        public class ExitMethod : VehicleServiceTests
        {
            [TestMethod]
            public void Exit_SetExitDateTime()
            {
                //Arrange
                var vehicle = new Vehicle()
                {
                    Id = 1,
                    ParkingSpaceId = 2,
                    EntryTime = DateTime.Now
                };
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act
                _vehicleService.Exit(vehicle);

                //Assert
                Assert.AreNotEqual(DateTime.MinValue, vehicle.ExitTime);
            }

            [TestMethod]
            public void Exit_VehicleIsNull()
            {
                //Arrange
                var vehicle = new Vehicle()
                {
                    Id = 1,
                    ParkingSpaceId = 2,
                    EntryTime = DateTime.Now
                };
                _vehicleService = new VehicleService(_vehicleRepositoryMock.Object);

                //Act & Assert
                try
                {
                    _vehicleService.Exit(vehicle);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Expected no exception, but got: " + ex.Message);
                }
            }
        }
    }
}
