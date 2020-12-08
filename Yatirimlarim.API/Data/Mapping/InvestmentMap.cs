using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yatirimlarim.API.Models;

namespace Yatirimlarim.API.Data.Mapping
{
    public class InvestmentMap : IEntityTypeConfiguration<Yatirim>
    {
        public void Configure(EntityTypeBuilder<Yatirim> builder)
        {
            builder.ToTable("yatirimlar");
            builder.HasKey(y => y.YatirimID);
            builder.Property(y => y.YatirimID);
            builder.Property(y => y.UrunID);
            builder.Property(y => y.KullaniciID);
            builder.Property(y => y.UrunAdet);
            builder.Property(y => y.YatirimTarihi);

     
            builder.Property(y => y.YatirimID).HasColumnName("yatirimid");
            builder.Property(y => y.UrunID).HasColumnName("urunid");
            builder.Property(y => y.KullaniciID).HasColumnName("kullaniciid");
            builder.Property(y => y.UrunAdet).HasColumnName("urunadet");
            builder.Property(y => y.YatirimTarihi).HasColumnName("yatirimtarihi");



        }
    }
}
