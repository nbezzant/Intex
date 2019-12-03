using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("User_Roles")]
    public class User_Roles
    {
        [Key]
        [Required]
        public int User_Role_ID { get; set; }
        [Display(Name ="User Role")]
        public string User_Role { get; set; }
        [Display(Name ="User Role Description")]
        public string User_Role_Desc { get; set; }
    }
}