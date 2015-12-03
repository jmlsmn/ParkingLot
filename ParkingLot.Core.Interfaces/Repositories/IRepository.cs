using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Interfaces.Repositories
{
    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    /// <typeparam name="T">Type the repository will use.</typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> List();
        bool Create(T item);
        bool Delete(int id);
        T Get(int id);
        bool SaveChanges();
    }
}
