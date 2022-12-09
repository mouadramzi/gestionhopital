using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GESTIONhopital.Models
{
    public class Medcin
    {
      
        [Required]
        [Key]
        public int id { get; set;  }
         [Required]
        [Display(Name = "Nom")]
        public string name { get; set;  }
        [Required]
        [Display(Name = "Prenom")]
        public string prenom { get; set;  }
        [Required]
        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [Display(Name = "Specialite")]
        public string specialite { get; set;  }
        [Required]
        [Display(Name = "phone")]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set;  }
        public virtual ICollection<passion> Passions{ get; set; }



    }
}