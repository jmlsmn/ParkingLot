using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Core.Interfaces.Services;
using Moq;
using ParkingLot.Core.Interfaces.Repositories;
using ParkingLot.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using ParkingLot.Core.Services;

namespace ParkingLot.Core.Tests
{
    [TestClass]
    public class ParkingSpaceServiceTests
    {
        private Mock<IRepository<ParkingSpace>> _parkingSpaceRepositoryMock;
        private IParkingSpaceService _parkingSpaceService;

        [TestInitialize]
        public void Initialize()
        {
            _parkingSpaceRepositoryMock = new Mock<IRepository<ParkingSpace>>();
        }

        [TestClass]
        public class GetParkingSpacesMethod : ParkingSpaceServiceTests
        {
            [TestMethod]
            public void GetParkingSpaces_ReturnsListOfParkingSpaces()
            {
                //Arrange
                
                List<ParkingSpace> parkingSpaces = new List<ParkingSpace>() 
                { 
                    new ParkingSpace()
                    {
                        Id = 1,
                        IsAvailable = true
                    },
                    new ParkingSpace()
                    {
                        Id = 2,
                        IsAvailable = false
                    },
                    new ParkingSpace()
                    {
                        Id = 3,
                        IsAvailable = true
                    },
                    new ParkingSpace()
                    {
                        Id = 4,
                        IsAvailable = false
                    },
                    new ParkingSpace()
                    {
                        Id = 5,
                        IsAvailable = false
                    }
                };

                _parkingSpaceRepositoryMock.Setup(x => x.List()).Returns(parkingSpaces.AsQueryable());
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act
                IEnumerable<ParkingSpace> result = _parkingSpaceService.GetParkingSpaces();

                //Assert
                Assert.AreEqual(parkingSpaces.Count, result.Count());
                CollectionAssert.AllItemsAreInstancesOfType(result.ToList(), typeof(ParkingSpace));
                CollectionAssert.AllItemsAreNotNull(result.ToList());
                CollectionAssert.AreEqual(parkingSpaces.ToList(), result.ToList());
            }
        }

        [TestClass]
        public class GetParkingSpaceMethod : ParkingSpaceServiceTests
        {
            [TestMethod]
            public void GetParkingSpace_ReturnsParkingSpace()
            {
                //Arrange
                var parkingSpace = new ParkingSpace()
                {
                    Id = 1,
                    IsAvailable = false
                };

                _parkingSpaceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(parkingSpace);
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act
                ParkingSpace result = _parkingSpaceService.GetParkingSpace(1);

                //Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ParkingSpace));
            }

            [TestMethod]
            public void GetParkingSpace_ReturnsNull()
            {
                //Arrange
                ParkingSpace parkingSpace = null;

                _parkingSpaceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(parkingSpace);
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act
                ParkingSpace result = _parkingSpaceService.GetParkingSpace(1);

                //Assert
                Assert.IsNull(result);
            }
        }

        [TestClass]
        public class UpdateAvailabilityMethod : ParkingSpaceServiceTests
        {
            [TestMethod]
            public void UpdateAvailability_SetIsAvailableTrue()
            {
                //Arrange
                var parkingSpace = new ParkingSpace()
                {
                    Id = 1,
                    IsAvailable = false
                };

                _parkingSpaceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(parkingSpace);
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act
                _parkingSpaceService.UpdateAvailability(1, true);


                //Assert
                Assert.IsTrue(parkingSpace.IsAvailable);
            }

            [TestMethod]
            public void UpdateAvailability_SetIsAvailableFalse()
            {
                //Arrange
                var parkingSpace = new ParkingSpace()
                {
                    Id = 1,
                    IsAvailable = true
                };

                _parkingSpaceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(parkingSpace);
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act
                _parkingSpaceService.UpdateAvailability(1, false);
                

                //Assert
                Assert.IsFalse(parkingSpace.IsAvailable);
            }

            [TestMethod]
            public void UpdateAvailability_ParkingSpaceIsNull()
            {
                //Arrange
                ParkingSpace parkingSpace = null;

                _parkingSpaceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(parkingSpace);
                _parkingSpaceService = new ParkingSpaceService(_parkingSpaceRepositoryMock.Object);

                //Act & Assert
                try
                {
                    _parkingSpaceService.UpdateAvailability(1, false);
                }
                catch(Exception ex)
                {
                    Assert.Fail("Expected no exception, but got: " + ex.Message);
                }
            }
        }
        
    }
}
