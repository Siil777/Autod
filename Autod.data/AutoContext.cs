using Autod.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autod.Data
{
    public class AutoContext : DbContext
    {
        public AutoContext
            (
                    DbContextOptions<AutoContext> options
            ) : base(options) { }



        public DbSet<LandingPage> LandingPages { get; set; }
    }
}
