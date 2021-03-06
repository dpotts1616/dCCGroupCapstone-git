﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Driver's License ID:")]
        public string LicenseIDNumber { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("CarID")]
        public int? CarID { get; set; }
        public Car Car { get; set; }

        [ForeignKey("PaymentID")]
        public int? PaymentID { get; set; }
        public CreditCard CreditCard { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }

        [NotMapped]
        public int?  RateCount
        {
            get {
                if (ratings == null)
                {
                    return null;
                }
                else
                {
                    return ratings.Count;
                }
                }
        }
        [NotMapped]
        public decimal RateAvg
        {
            get
            {

                if (ratings == null) {
                    return 0;
                }
                else
                {
                   return (decimal)(RateTotal / RateCount);
                }
                   
            }
        }

        [NotMapped]
        public int? RateTotal
        {
            get
            {
                if(ratings == null)
                {
                    return null;
                }
                else
                return (ratings.Sum(m => m.Rate));
            }
        }
        [NotMapped]
        public virtual ICollection<StarRating> ratings { get; set; }


    }
}
