using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [Display(Name ="Status ID")]
        public int Status_ID { get; set; }
        [Display(Name = "Status Description")]
        public string Status_Desc { get; set; }
    }
}