using ParkingLot.Core.Domain;
using ParkingLot.Core.Interfaces.Repositories;
using ParkingLot.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Services
{
    /// <summary>
    /// Vehicle Service
    /// </summary>
    public class VehicleService : IVehicleService
    {
        IRepository<Vehicle> _vehicleRepository;

        /// <summary>
        /// Constructor for a Vehicle Service
        /// </summary>
        /// <param name="vehicleRepository">A vehicle repository</param>
        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// This method retrieves a Vehicle by Id
        /// </summary>
        /// <param name="parkingSpaceId">Identifier for a Parking Space</param>
        /// <returns></returns>
        public Vehicle GetVehicle(int vehicleId)
        {
            return _vehicleRepository.Get(vehicleId);
        }

        /// <summary>
        /// This method calculates the time parked in hours
        /// </summary>
        /// <param name="entryTime">Time of entry</param>
        /// <param name="exitTime">Time of exit</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when entryTime is greater than exitTime</exception>
        /// <returns>An Integer that represents time parked in hours</returns>
        public int GetParkedTimeInHours(DateTime entryTime, DateTime exitTime)
        {
            if (entryTime > exitTime)
                throw new ArgumentOutOfRangeException("Entry Time must be less than Exit Time.");

            int differenceInHours = (exitTime - entryTime).Hours;

            return differenceInHours;
        }

        /// <summary>
        /// This method updates the Exit Time on a Vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle To Update</param>
        public void Exit(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                vehicle.ExitTime = DateTime.Now;
            }
        }
    }
}
