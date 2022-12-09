using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GESTIONhopital.Models
{
    public class hopitalcontext :DbContext
    {
        public DbSet<Medcin> medcins { get; set; }
        public DbSet<passion> passions { get; set; }
        public DbSet<rendez_vous> rendez_Vous { get; set; }
        public DbSet<dossiermedical> dossiermedicals { get; set; }
 




    }
}