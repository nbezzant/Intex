using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Customer_Payment")]
    public class Customer_Payment
    {
        [Key]
        [Display(Name = "Customer Payment ID")]
        [Required]
        public int Customer_Payment_ID { get; set; }
        [Required]
        [Display(Name = "Card Type (debit or credit)")]
        public string Card_Type { get; set; } //Need to add this as a type maybe so it can be a drop down list
        [Display(Name = "Card Number")]
        [Required]
        public double Card_Num { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        public string Card_Expiration { get; set; }
        [Required]
        [Display(Name ="Security Code")]
        public int Card_CSV { get; set; }
    }
}