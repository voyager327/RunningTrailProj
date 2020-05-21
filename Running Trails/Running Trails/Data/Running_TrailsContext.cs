using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Running_Trails.Models;

namespace Running_Trails.Data
{
    public class Running_TrailsContext : DbContext
    {
        public Running_TrailsContext (DbContextOptions<Running_TrailsContext> options)
            : base(options)
        {
        }

        public DbSet<Running_Trails.Models.Runner> Runner { get; set; }
    }
}
