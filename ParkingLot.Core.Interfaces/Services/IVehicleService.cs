using ParkingLot.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Interfaces.Services
{
    /// <summary>
    /// Vehicle Service Interface
    /// </summary>
    public interface IVehicleService
    {
        Vehicle GetVehicle(int vehicleId);
        int GetParkedTimeInHours(DateTime entryTime, DateTime exitTime);
        void Exit(Vehicle vehicle);
    }
}
