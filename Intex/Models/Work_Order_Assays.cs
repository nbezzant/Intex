using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Work_Order_Assays")]
    public class Work_Order_Assays
    {
        [Key]
        [Display(Name ="Assay ID for work ID")]
        public int Work_Order_Assay_ID { get; set; }
        [Display(Name = "Work Order ID")]
        public int Work_Order_ID { get; set; }
        [Display(Name = "Assay Cost")]
        public double Assay_Cost { get; set; }
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Display(Name = "Assay Results")]
        public string Assay_results { get; set; }
    }
}