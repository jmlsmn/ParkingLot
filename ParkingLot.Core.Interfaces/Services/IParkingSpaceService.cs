using ParkingLot.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Interfaces.Services
{
    /// <summary>
    /// Parking Space Service Interface
    /// </summary>
    public interface IParkingSpaceService
    {
        IEnumerable<ParkingSpace> GetParkingSpaces();
        ParkingSpace GetParkingSpace(int parkingSpaceId);
        void UpdateAvailability(int parkingSpaceId, bool isAvailable);
    }
}
