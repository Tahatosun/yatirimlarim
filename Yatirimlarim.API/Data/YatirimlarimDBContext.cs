using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yatirimlarim.API.Data.Mapping;
using Yatirimlarim.API.Models;

namespace Yatirimlarim.API.Data
{
    public class YatirimlarimDBContext:DbContext
    {
        public YatirimlarimDBContext(DbContextOptions<YatirimlarimDBContext> options) : base(options) { }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Yatirim> Yatirimlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new InvestmentMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }


    }
}
