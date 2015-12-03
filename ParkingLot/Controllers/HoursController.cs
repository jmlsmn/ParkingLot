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
    /// Hours Controller
    /// </summary>
    public class HoursController : ApiController
    {
        private IParkingSpaceService _parkingSpaceService;
        private IVehicleService _vehicleService;

        /// <summary>
        /// Constructor for the Hours Controller
        /// </summary>
        /// <param name="parkingSpaceService"></param>
        public HoursController(IVehicleService vehicleService, IParkingSpaceService parkingSpaceService)
        {
            _vehicleService = vehicleService;
            _parkingSpaceService = parkingSpaceService;
        }

        // GET api/vehicles/{vid}/hours
        /// <summary>
        /// Get elapsed hours for a given parked vehicle
        /// </summary>
        /// <param name="vid">Vehicle Id</param>
        /// <returns>Elapsed Hours for a parked vehicle</returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("api/vehicles/{vid}/hours")]
        public IHttpActionResult Get(int vid)
        {
            IHttpActionResult result;

            Vehicle vehicle = _vehicleService.GetVehicle(vid);
            if (vehicle == null)
            {
                result = NotFound();
            }
            else
            {
                _vehicleService.Exit(vehicle);
                _parkingSpaceService.UpdateAvailability(vehicle.ParkingSpaceId, true);
                int hours = _vehicleService.GetParkedTimeInHours(vehicle.EntryTime, vehicle.ExitTime);
                result = Ok(hours);
            }

            return result;
        }
    }
}
