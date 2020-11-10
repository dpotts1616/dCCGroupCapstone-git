using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Reservation Date")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        [Display(Name ="Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Display(Name = "Date Booked")]
        [DataType(DataType.Date)]
        public DateTime DateBooked { get; set; }
        public double EstimatedCost { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("SpotID")]
        public int? OwnedSpotID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public int? BookedCustomerID { get; set; }
        
    }
}
