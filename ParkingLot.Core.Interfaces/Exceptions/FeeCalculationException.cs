using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Exceptions
{
    /// <summary>
    /// Fee Calculation Exeption
    /// </summary>
    public class FeeCalculationException : ParkingLotException 
    {
         public FeeCalculationException()
            : base() { }

        public FeeCalculationException(string message)
            : base(message) { }

        public FeeCalculationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public FeeCalculationException(string message, Exception innerException)
            : base(message, innerException) { }

        public FeeCalculationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
