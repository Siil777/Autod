using Autod.core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.data
{
    public class AutoContext: DbContext
    {
        public AutoContext
            (
                    DbContextOptions<AutoContext> options
            )       :base(options){ }



          public DbSet<LandingPage> LandingPages { get; set; }
    }
}
