using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class SortingworkOrders
    {
        [Key]
        public int Database_Number { get; set; }
        [Display(Name ="Order Number")]
        public int order { get; set; }
        [Display(Name = "Assay ID for work ID")]
        public int Work_Order_Assay_ID { get; set; }
        [Display(Name = "Work Order ID")]
        public int Work_Order_ID { get; set; }
        [Display(Name = "Assay Cost")]
        public double Assay_Cost { get; set; }
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Display(Name = "Date Due")]
        public DateTime Date_Due { get; set; }
    }
}