
using KisiApi.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiApi.config
{
    public class configKisiler : IEntityTypeConfiguration<Kisi>
    {
        public void Configure(EntityTypeBuilder<Kisi> builder)
        {
            builder.Property(x => x.ad).HasMaxLength(50);
            builder.Property(x => x.soyad).HasMaxLength(50);
            builder.Property(x => x.firma).HasMaxLength(150);
        }
    }
    public class configKisiBilgileri : IEntityTypeConfiguration<KisiBilgileri>
    {
        public void Configure(EntityTypeBuilder<KisiBilgileri> builder)
        {
            builder.Property(x => x.email).HasMaxLength(50);
            builder.Property(x => x.konum).HasMaxLength(50);
            builder.Property(x => x.telefonno).HasMaxLength(50);
        }
    }
}
