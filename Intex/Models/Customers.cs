using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{   
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int Customer_ID { get; set; }
        [Display(Name = "Username")]
        [Required]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        [Display(Name ="First Name")]
        [Required]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string Last_Name { get; set; }
        [Display(Name = "Street Address")]
        [Required]
        public string Street_Address { get; set; }
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "User Role ID")]
        [Required]
        public int User_Role_ID { get; set; }
        [Display(Name = "Customer")]
        [Required]
        public List<Customer_Payment> Customer_Payment_ID;
        // make sure to have new statement in customer controller

    }
}