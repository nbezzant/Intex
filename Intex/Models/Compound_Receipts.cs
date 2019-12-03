using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Compound_Receipts")]
    public class Compound_Receipts
    {
        [Key, Column(Order=1)]
        [Display(Name = "Labs Tests Number")]
        public int LT { get; set; }
        [Key, Column(Order = 2)]
        [Display(Name = "Compound Sequence Code")]
        public int Compound_Sequence_Code { get; set; }
        [Display(Name = "Compound Name")]
        public string Compound_Name { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Date Arrived")]
        public string Date_Arrived { get; set; }
        [Display(Name = "Received By")]
        public string Received_By { get; set; }
        [Display(Name = "Date Due")]
        public string Date_Due { get; set; }
        [Display(Name = "Appearance")]
        public string Appearance { get; set; }
        [Display(Name = "Indicated Weight")]
        public float Indicated_Weight { get; set; }
        [Display(Name = "Molecular Mass")]
        public float Molecular_Mass { get; set; }
        [Display(Name = "Actual Weight")]
        public float Actual_Weight { get; set; }
        [Display(Name = "Maximum Tolerated Dose")]
        public float MTD { get; set; }
        [Display(Name = "Confirmation Date")]
        public string Confirmation_Date { get; set; }
        [Display(Name = "Confirmation Time")]
        public string Confirmation_Time { get; set; }
        [Display(Name = "Work Order ID")]
        public int Work_Order_ID { get; set; }
    }
}