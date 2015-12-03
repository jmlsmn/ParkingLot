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
    /// Fees Controller
    /// </summary>
    public class FeesController : ApiController
    {
        private IParkingSpaceService _parkingSpaceService;
        private IFeeService _feeService;

        /// <summary>
        /// Constructor for the Fees Controller 
        /// </summary>
        /// <param name="parkingSpaceService"></param>
        /// <param name="feeService"></param>
        public FeesController(IParkingSpaceService parkingSpaceService, IFeeService feeService)
        {
            _parkingSpaceService = parkingSpaceService;
            _feeService = feeService;
        }

        // GET api/parkingspaces/{psid}/fees
        /// <summary>
        /// Get Fees for a given parking space
        /// </summary>
        /// <param name="psid">Parking Space Id</param>
        /// <param name="hours">Number of hours parked</param>
        /// <returns>Fees for a parking space</returns>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("api/parkingspaces/{psid}/fees")]
        public IHttpActionResult Get(int psid, int hours)
        {
            IHttpActionResult result;

            ParkingSpace parkingSpace = _parkingSpaceService.GetParkingSpace(psid);
            if (parkingSpace == null)
            {
                result = NotFound();
            }
            else
            {
                decimal fee = _feeService.CalculateFees(hours);
                result = Ok(fee);
            }

            return result;
        }
    }
}