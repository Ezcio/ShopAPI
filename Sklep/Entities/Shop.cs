using Microsoft.EntityFrameworkCore;
using Sklep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sklep.Entities
{
    public class Shop : DbContext
    {
         private string connetctionString = "";

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Item> Item { get; set; }
        public DbSet<Opinion> Opinion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Mail).IsRequired();
            modelBuilder.Entity<Role>().Property(p => p.RoleName).IsRequired();
            modelBuilder.Entity<Country>().Property(p => p.CountryName).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.CategoryId).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.NameItem).IsRequired();
            modelBuilder.Entity<Category>().Property(p => p.CategoryName).IsRequired();
            modelBuilder.Entity<Opinion>().Property(p => p.ItemId).IsRequired();
            modelBuilder.Entity<Opinion>().Property(p => p.Content).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(connetctionString);

        }
    }
}
