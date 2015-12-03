using ParkingLot.Core.Exceptions;
using ParkingLot.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Services
{
    /// <summary>
    /// Fee Service
    /// </summary>
    public class FeeService : IFeeService
    {
        /// <summary>
        /// This method calculates the fees for a time span of hours
        /// </summary>
        /// <param name="hours">Number of Hours Parked</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when hours is less than zero</exception>
        /// <exception cref="FeeCalculationException">Thrown when fees cannot be calculated</exception>
        /// <returns>Decimal that represents the calculated fee</returns>
        public decimal CalculateFees(int hours)
        {
            if (hours < 0)
                throw new ArgumentOutOfRangeException("Hours must be greater than or equal to zero.");

            if (hours >= 0 && hours <= 2) 
                return 5.00M;

            if (hours > 2 && hours <= 10) 
                return 10.00M;

            if (hours > 10) 
                return 15.00M;

            throw new FeeCalculationException("Cannot calculate fee for given hours.");
        }
    }
}
