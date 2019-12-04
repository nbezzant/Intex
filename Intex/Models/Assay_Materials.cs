using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Assay_Materials")]
    public class Assay_Materials
    {
        [Key]
        [Display(Name ="Assay Material ID")]
        public int Assay_Material_ID { get; set; }
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Display(Name = "Material ID")]
        public int Material_ID { get; set; }
        [Display(Name = "Material Amount")]
        public double Amount { get; set; }
        [Display(Name = "Material Cost")]
        public double Material_Cost { get; set; }
    }
}