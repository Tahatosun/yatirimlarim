using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yatirimlarim.API.Models;

namespace Yatirimlarim.API.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.ToTable("urunler");
            builder.HasKey(u => u.UrunID);
            builder.Property(u => u.UrunID);
            builder.Property(u => u.UrunAd);
            
            builder.Property(u => u.UrunID).HasColumnName("urunid");
            builder.Property(u => u.UrunAd).HasColumnName("urunad");
        }
    }
}
