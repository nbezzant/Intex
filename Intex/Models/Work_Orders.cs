using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Work_Orders")]
    public class Work_Orders
    {
        [Key]
        [Display(Name ="Work Order ID")]
        public int Work_Order_ID { get; set; }

        [Display(Name = "Status")]
        public int Status_ID{ get; set; }

        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }

        [Display(Name = "Instructions")]
        public string Instructions { get; set; }
        [Display(Name ="Run Conditional Tests")]
        public bool Conditional_Tests { get; set; }
        [Display(Name = "Rush")]
        public bool Rush { get; set; }

        [Display(Name = "Quoted Price")]
        public double Price_Quote { get; set; }

        [Display(Name = "Discount")]
        public bool Discount { get; set; }

        [Display(Name = "Total Cost")]
        public double Total_Cost { get; set; }
    }
}