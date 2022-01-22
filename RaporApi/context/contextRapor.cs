using Microsoft.EntityFrameworkCore;
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
        //public virtual DbSet<Kisi> Kisiler { get; set; }
        //public virtual DbSet<KisiBilgileri> KisiBilgileri { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(contextRapor).Assembly);
        }
    }
}
