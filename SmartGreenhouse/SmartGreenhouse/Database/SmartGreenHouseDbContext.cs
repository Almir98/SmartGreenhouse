﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartGreenhouse.Database
{
    public partial class SmartGreenHouseDbContext : DbContext
    {
        public SmartGreenHouseDbContext()
        {
        }

        public SmartGreenHouseDbContext(DbContextOptions<SmartGreenHouseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RecentValues> RecentValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SmartGreenHouseDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecentValues>(entity =>
            {
                entity.Property(e => e.InsertDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
