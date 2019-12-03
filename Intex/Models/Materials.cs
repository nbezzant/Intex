using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Materials")]
    public class Materials
    {
        [Key]
        public int Material_ID { get; set; }
        [Display(Name ="Material Name")]
        public string Material_Name { get; set; }
    }
}