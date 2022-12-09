using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESTIONhopital.Models
{
    public class passion
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Prenom")]
        public string prenom { get; set; }
        [Required]
        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [Display(Name = "Maladie")]
        public string maladie { get; set; }
        [Required]
        [Display(Name = "phone")]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }


        [Required]
        [Display(Name = "adresse")]
        [DataType(DataType.MultilineText)]
        public int adresse { get; set; }
        public virtual ICollection<Medcin> Medcins { get; set; }






    }
}