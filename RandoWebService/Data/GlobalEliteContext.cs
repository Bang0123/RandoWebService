using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using RandoWebService.Data.Models;

namespace RandoWebService.Data
{
    public class GlobalEliteContext : DbContext
    {
        public GlobalEliteContext(DbContextOptions<GlobalEliteContext> options) : base(options)
        {
        }

        public DbSet<EliteData> EliteDatas { get; set; }
        public DbSet<EliteRef> EliteRefs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EliteData>().ToTable("EliteDatas");
            modelBuilder.Entity<EliteRef>().ToTable("EliteRefs");
        }
    }
}
