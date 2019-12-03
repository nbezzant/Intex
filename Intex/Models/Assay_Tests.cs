using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Assay_Tests")]
    public class Assay_Tests
    {
        [Key]
        [Display(Name ="Assay Test ID")]
        public int Assay_Test_ID { get; set; }
        [Display(Name = "Test Results")]
        public string Test_Results { get; set; }
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Display(Name = "Test ID")]
        public int Test_ID { get; set; }

    }
}