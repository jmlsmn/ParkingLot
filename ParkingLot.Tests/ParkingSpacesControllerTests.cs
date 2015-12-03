using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Core.Interfaces.Services;
using Moq;
using ParkingLot.Controllers;
using ParkingLot.Core.Domain;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Linq;

namespace ParkingLot.Tests
{
    [TestClass]
    public class ParkingSpacesControllerTests
    {
        private Mock<IParkingSpaceService> _parkingSpaceServiceMock;
        private ParkingSpacesController _parkingSpacesController;

        [TestInitialize]
        public void Initialize()
        {
            _parkingSpaceServiceMock = new Mock<IParkingSpaceService>();
        }

        [TestClass]
        public class GetMethod : ParkingSpacesControllerTests
        {
            [TestMethod]
            public void Get_ShouldReturnListofParkingSpaces()
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

                _parkingSpaceServiceMock.Setup(x => x.GetParkingSpaces()).Returns(parkingSpaces);
                _parkingSpacesController = new ParkingSpacesController(_parkingSpaceServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _parkingSpacesController.Get();
                var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<ParkingSpace>>;

                //Assert
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.IsTrue(contentResult.Content.Any());
            }

            [TestMethod]
            public void Get_ShouldReturnEmptyListofParkingSpaces()
            {
                //Arrange
                List<ParkingSpace> parkingSpaces = new List<ParkingSpace>();

                _parkingSpaceServiceMock.Setup(x => x.GetParkingSpaces()).Returns(parkingSpaces);
                _parkingSpacesController = new ParkingSpacesController(_parkingSpaceServiceMock.Object);

                //Act
                IHttpActionResult actionResult = _parkingSpacesController.Get();
                var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<ParkingSpace>>;

                //Assert
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.IsFalse(contentResult.Content.Any());
            }
        }
    }
}
