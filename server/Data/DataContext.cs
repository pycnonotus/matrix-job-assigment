using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Dto;

namespace Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DbSet<Hero> UserHeros { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasMany(x => x.UserHeros)
            .WithOne(x => x.Trainer).HasForeignKey(x => x.TrainerId);

            builder.Entity<Hero>().HasMany(x => x.TrainHistory)
            .WithOne(x => x.Hero).HasForeignKey(x => x.HeroId);
        }
    }
  
}
