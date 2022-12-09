using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTIONhopital.Models
{
    public class rendez_vous
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "date rendez vous")]
        [DataType(DataType.DateTime)]
        public int date { get; set; }
        [Required]
        [Display(Name = "Passion id ")]
        public int passionid { get; set; }

        [Required]
        [Display(Name = "Medcin id ")]
        public int medcinid { get; set; }
        public virtual passion Passion { get; set; }
        public virtual Medcin Medcin { get; set; }

    }
}