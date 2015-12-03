using ParkingLot.Core.Domain;
using ParkingLot.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Repositories
{
    /// <summary>
    /// Vehicle Repository
    /// </summary>
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly object _lockObject = new object();

        private List<Vehicle> _vehicles = new List<Vehicle>()
        {
            new Vehicle()
            {
                Id = 1,
                ParkingSpaceId = 2,
                EntryTime = DateTime.Now
            },
            new Vehicle()
            {
                Id = 2,
                ParkingSpaceId = 4,
                EntryTime = DateTime.Now
            },
            new Vehicle()
            {
                Id = 3,
                ParkingSpaceId = 5,
                EntryTime = DateTime.Now
            }
        };

        public IQueryable<Vehicle> List()
        {
            return _vehicles.AsQueryable();
        }

        public bool Create(Vehicle item)
        {
            lock (_lockObject)
            {
                _vehicles.Add(item);
            }
            return true;
        }

        public bool Delete(int id)
        {
            lock (_lockObject)
            {
                _vehicles.RemoveAll(x => x.Id == id);
            }
            return true;
        }

        public Vehicle Get(int id)
        {
            return _vehicles.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
