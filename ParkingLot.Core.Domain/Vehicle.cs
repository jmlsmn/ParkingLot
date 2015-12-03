using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Core.Domain
{
    /// <summary>
    /// Vehicle Class
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identifier for a Vehicle
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier for an associated Parking Space
        /// </summary>
        public int ParkingSpaceId { get; set; }

        /// <summary>
        /// Parking Entry Time for a Vehicle
        /// </summary>
        public DateTime EntryTime { get; set; }

        /// <summary>
        /// Parking Exit Time for a Vehicle
        /// </summary>
        public DateTime ExitTime { get; set; }
    }
}
