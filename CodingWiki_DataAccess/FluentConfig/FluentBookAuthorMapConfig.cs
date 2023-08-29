using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(e => new { e.Author_Id, e.Book_Id });
            modelBuilder.HasOne(e => e.Book).WithMany(e => e.BookAuthorMaps).HasForeignKey(e => e.Book_Id);
            modelBuilder.HasOne(e => e.Author).WithMany(e => e.BookAuthorMaps).HasForeignKey(e => e.Book_Id);
        }
    }
}
