using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Contractor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Address:")]
        public string Address { get; set; }
        [Display(Name = "City:")]
        public string City { get; set; }
        [Display(Name = "State:")]
        public string State { get; set; }
        [Display(Name = "Zip Code:")]
        public string ZipCode { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("SpotID")]
        [Display(Name = "Parking Spot ID")]
        public int? SpotID { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
    }
}
