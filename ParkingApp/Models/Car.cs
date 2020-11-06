using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Car Make")]
        public string CarMake { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        public int? OwnerId { get; set; }

    }
}
