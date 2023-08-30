using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookDetail> BookDetail_Fluent { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost; Database=CodingWiki; TrustServerCertificate=True; Trusted_Connection=True;")
            //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(e => e.Price).HasPrecision(10, 5);

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<BookAuthorMap>().HasKey(e => new { e.Author_Id, e.Book_Id });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Toan 1", ISBN = "123B12", Price = 55.99m, Publisher_Id = 1 },
                new Book { Id = 2, Title = "Tieng Viet 1", ISBN = "12123B12", Price = 56.99m, Publisher_Id = 1 },
                new Book { Id = 3, Title = "Dao Duc 1", ISBN = "77652", Price = 23.99m, Publisher_Id = 2 },
                new Book { Id = 4, Title = "Am Nhac 1", ISBN = "CC12B12", Price = 36.99m, Publisher_Id = 3 },
                new Book { Id = 5, Title = "Mi Thuat 1", ISBN = "90392B33", Price = 44.99m, Publisher_Id = 3 }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chacago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
                );
        }
    }
}
