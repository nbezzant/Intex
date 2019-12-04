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
        [Key]
        [Display(Name ="Compound Receipt ID")]
        public int Compound_Receipt_ID { get; set; }
        [Display(Name = "Labs Tests Number")]
        public int LT { get; set; }
        [Display(Name = "Compound Sequence Code")]
        public int Compound_Sequence_Code { get; set; }
        [Display(Name = "Compound Name")]
        public string Compound_Name { get; set; }
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
        [Display(Name = "Date Arrived")]
        public DateTime Date_Arrived { get; set; }
        [Display(Name = "Received By")]
        public string Received_By { get; set; }
        [Display(Name = "Date Due")]
        public DateTime Date_Due { get; set; }
        [Display(Name = "Appearance")]
        public string Appearance { get; set; }
        [Display(Name = "Indicated Weight")]
        public double Indicated_Weight { get; set; }
        [Display(Name = "Molecular Mass")]
        public double Molecular_Mass { get; set; }
        [Display(Name = "Actual Weight")]
        public double Actual_Weight { get; set; }
        [Display(Name = "Maximum Tolerated Dose")]
        public double MTD { get; set; }
        [Display(Name = "Confirmation Date")]
        public DateTime Confirmation_Date { get; set; }
        [Display(Name = "Confirmation Time")]
        public TimeSpan Confirmation_Time { get; set; }
        [Display(Name = "Work Order ID")]
        public int Work_Order_ID { get; set; }
    }
}