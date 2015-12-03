using ParkingLot.Core.Domain;
using ParkingLot.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingLot.Controllers
{
    /// <summary>
    /// Parking Spaces Controller
    /// </summary>
    public class ParkingSpacesController : ApiController
    {
        private IParkingSpaceService _parkingSpaceService;

        /// <summary>
        /// Constructor for the Parking Spaces Controller
        /// </summary>
        /// <param name="parkingSpaceService">Parking Space Service</param>
        public ParkingSpacesController(IParkingSpaceService parkingSpaceService)
        {
            _parkingSpaceService = parkingSpaceService;
        }

        // GET api/parkingspaces
        /// <summary>
        /// Gets a list of parking spaces
        /// </summary>
        /// <returns>List of parking spaces</returns>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        public IHttpActionResult Get()
        {
            IHttpActionResult result;

            IEnumerable<ParkingSpace> parkingSpaces = _parkingSpaceService.GetParkingSpaces();
            result = Ok(parkingSpaces);

            return result;
        }
    }
}