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
    /// Parking Space Service
    /// </summary>
    public class ParkingSpaceService : IParkingSpaceService
    {
        IRepository<ParkingSpace> _parkingSpaceRepository;

        /// <summary>
        /// Constructor for a Parking Space Service
        /// </summary>
        /// <param name="parkingSpaceRepository">A parking space repository</param>
        public ParkingSpaceService(IRepository<ParkingSpace> parkingSpaceRepository)
        {
            _parkingSpaceRepository = parkingSpaceRepository;
        }

        /// <summary>
        /// This method retieves all parking spaces
        /// </summary>
        /// <returns>List of Parking Spaces</returns>
        public IEnumerable<ParkingSpace> GetParkingSpaces()
        {
            return _parkingSpaceRepository.List();
        }

        /// <summary>
        /// This method retrieves a Parking Space by Id
        /// </summary>
        /// <param name="parkingSpaceId">Identifier for a Parking Space</param>
        /// <returns></returns>
        public ParkingSpace GetParkingSpace(int parkingSpaceId)
        {
            return _parkingSpaceRepository.Get(parkingSpaceId);
        }


        /// <summary>
        /// This method updates the availability on a Parking Space
        /// </summary>
        /// <param name="parkingSpaceId">Parking Space Id</param>
        /// <param name="isAvailable">Flag indicating availability</param>
        public void UpdateAvailability(int parkingSpaceId, bool isAvailable)
        {
            ParkingSpace parkingSpace = _parkingSpaceRepository.Get(parkingSpaceId);
            if (parkingSpace != null)
            {
                parkingSpace.IsAvailable = isAvailable;
            }
        }
    }
}
