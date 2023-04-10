using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class VehicleDbContext : IdentityDbContext<AspUser>
    {
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Petrol> Petrols { get; set; }

        public DbSet<Waybill> Waybills { get; set; }

        public DbSet<RefuelingPrice> RefuelingPrices { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var systemRoles = new[] { new SystemRole() { Id = 1, Name="Админ"},
                new SystemRole() { Id = 2, Name="Глава отдела"},
                new SystemRole(){ Id = 3, Name="Специалист"}
            };
            modelBuilder.Entity<SystemRole>().HasData(systemRoles);

            modelBuilder.Entity<AspUser>().HasOne(c => c.Employee).WithOne(e => e.AspUser).HasForeignKey("Employee","AspUserId");
            base.OnModelCreating(modelBuilder);           
        }       

    }
}
