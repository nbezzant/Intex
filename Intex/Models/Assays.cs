﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Assays")]
    public class Assays
    {
        [Key]
        [Display(Name ="Assay Id")]
        public int Assay_ID { get; set; }
        [Display(Name = "Assay Description")]
        public string Assay_Desc { get; set; }
        [Display(Name = "Assay Duration")]
        public int Assay_Duration { get; set; }
        [Display(Name = "Employee Cost")]
        public float Employee_Cost { get; set; }
    }
}