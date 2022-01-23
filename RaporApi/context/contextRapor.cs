using Microsoft.EntityFrameworkCore;
using RaporApi.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaporApi.context
{
    public class contextRapor : DbContext
    {
        public contextRapor(DbContextOptions<contextRapor> options) : base(options)
        {

        }
        public virtual DbSet<Rapor> Rapor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(contextRapor).Assembly);
        }
    }
}
