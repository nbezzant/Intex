using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Test_Materials")]
    public class Test_Materials
    {
        [Key]
        [Display(Name ="Test Material ID")]
        public int Test_Material_ID { get; set; }
        [Display(Name = "Test ID")]
        public int Test_ID { get; set; }
        [Display(Name = "Material ID")]
        public int Material_ID { get; set; }
        [Display(Name = "Material Amount")]
        public int Amount { get; set; }
        [Display(Name = "Material Cost")]
        public float Material_Cost { get; set; }
    }
}