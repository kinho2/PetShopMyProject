using Microsoft.EntityFrameworkCore;
using PetShopMyProject.Connection;
using PetShopMyProject.Models;
using System;

namespace PetShopMyProject.Data
{
    public class PetShopContext : DbContext, IUnitOfWork
    {
        public PetShopContext(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<PetCliente> PetCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public bool Commit()
        {
            return base.SaveChanges() > 0;
        }
    }
}
