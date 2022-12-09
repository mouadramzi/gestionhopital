using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace GESTIONhopital.Models
{
    public class hopitalinitizer :DropCreateDatabaseAlways<hopitalcontext>
    {
    }
}