using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Yatirimlarim.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Yatirimlarim.API.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.ToTable("kullanicilar");
            builder.HasKey(c => c.KullaniciID);
            builder.Property(c => c.KullaniciID);
            builder.Property(c => c.KullaniciAdi);
            builder.Property(c => c.Ad);
            builder.Property(c => c.Soyad);
            builder.Property(c => c.Eposta);
            builder.Property(c => c.Telefon);
            builder.Property(c => c.Sifre);

            builder.Property(c => c.KullaniciID).HasColumnName("kullaniciid");
            builder.Property(c => c.KullaniciAdi).HasColumnName("kullaniciadi");
            builder.Property(c => c.Ad).HasColumnName("ad");
            builder.Property(c => c.Soyad).HasColumnName("soyad");
            builder.Property(c => c.Eposta).HasColumnName("eposta");
            builder.Property(c => c.Telefon).HasColumnName("telefon");
            builder.Property(c => c.Sifre).HasColumnName("sifre");


        }
    }
}
