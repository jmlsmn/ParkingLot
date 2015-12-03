using System;

namespace ParkingLot.Core.Domain
{
    /// <summary>
    /// Parking Space Class
    /// </summary>
    public class ParkingSpace
    {
        /// <summary>
        /// Identifier for a Parking Space
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Flag that indicates if the Parking Space is available
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}