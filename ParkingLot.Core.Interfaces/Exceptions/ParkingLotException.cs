using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Exceptions
{
    public class ParkingLotException : Exception
    {
        public ParkingLotException()
            : base() { }

        public ParkingLotException(string message)
            : base(message) { }

        public ParkingLotException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ParkingLotException(string message, Exception innerException)
            : base(message, innerException) { }

        public ParkingLotException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
