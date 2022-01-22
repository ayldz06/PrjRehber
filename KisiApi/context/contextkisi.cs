using KisiApi.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KisiApi.context
{
    public class contextkisi:DbContext
    {
        public contextkisi(DbContextOptions<contextkisi> options) : base(options)
        {

        }
        //public virtual DbSet<Kisi> Kisiler { get; set; }
        //public virtual DbSet<KisiBilgileri> KisiBilgileri { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(contextkisi).Assembly);
        }
    }
}
