using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Tests")]
    public class Tests
    {
        [Key]
        [Display(Name = "Test ID")]
        public int Test_ID { get; set; }
        [Display( Name="Test Name")]
        public string Test_Name { get; set; }
        [Display(Name = "Test Required")]
        public bool Test_Required { get; set; }
        [Display(Name = "Base Price")]
        public float Base_Price { get; set; }
    }
}