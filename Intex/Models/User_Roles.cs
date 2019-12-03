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
        [Required]
        [Key]
        public int User_Role_ID { get; }
        [Display(Name ="User Role")]
        public string User_Role { get; }
        [Display(Name ="User Role Description")]
        public string User_Role_Desc { get; }
    }
}