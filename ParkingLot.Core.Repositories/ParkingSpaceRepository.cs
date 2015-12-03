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
    /// Parking Space Repository
    /// </summary>
    public class ParkingSpaceRepository : IRepository<ParkingSpace>
    {
        private readonly object _lockObject = new object();

        private List<ParkingSpace> _parkingSpaces = new List<ParkingSpace>() 
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

        public IQueryable<ParkingSpace> List()
        {
            return _parkingSpaces.AsQueryable();
        }

        public bool Create(ParkingSpace item)
        {
            lock (_lockObject)
            {
                _parkingSpaces.Add(item);
            }
            return true;
        }

        public bool Delete(int id)
        {
            lock (_lockObject)
            {
                _parkingSpaces.RemoveAll(x => x.Id == id);
            }
            return true;
        }

        public ParkingSpace Get(int id)
        {
            return _parkingSpaces.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
