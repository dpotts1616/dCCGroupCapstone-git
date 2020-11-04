using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Models
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Card Number")]
        public string CardNumber { get; set; }
        [Display(Name = "Expiration Month")]
        public int ExpirationMonth { get; set; }
        [Display(Name = "Expiration Year")]
        public int ExpirationYear { get; set; }
        [Display(Name = "CVV")]
        public int SecurityCode { get; set; }
        [Display(Name = "Billing Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name ="Card Type")]
        public string CardType { get; set; }



    }
}
