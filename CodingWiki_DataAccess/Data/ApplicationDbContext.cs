using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=CodingWiki; TrustServerCertificate=True; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(e => e.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Toan 1", ISBN = "123B12", Price = 55.99m },
                new Book { Id = 2, Title = "Tieng Viet 1", ISBN = "12123B12", Price = 56.99m },
                new Book { Id = 3, Title = "Dao Duc 1", ISBN = "77652", Price = 23.99m },
                new Book { Id = 4, Title = "Am Nhac 1", ISBN = "CC12B12", Price = 36.99m },
                new Book { Id = 5, Title = "Mi Thuat 1", ISBN = "90392B33", Price = 44.99m }
                );
        }
    }
}
