using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Interfaces.Services
{
    /// <summary>
    /// Fee Service Interface
    /// </summary>
    public interface IFeeService
    {
        decimal CalculateFees(int hours);
    }
}
