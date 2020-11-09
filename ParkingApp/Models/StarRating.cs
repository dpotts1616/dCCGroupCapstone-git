using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class StarRating
    {
        [Key]
        public int RateId { get; set; }
        public int Rate { get; set; }
        public string IpAddress { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }

    }
}
