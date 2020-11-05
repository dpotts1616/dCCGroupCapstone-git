using ParkingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Interfaces
{
    interface IGeocodingService
    {
        public void AttachLatAndLong(ParkingSpot parkingSpot);

    }
}
