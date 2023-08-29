using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.Property(e => e.ISBN).HasMaxLength(50);
            modelBuilder.Property(e => e.ISBN).IsRequired();
            modelBuilder.HasKey(e => e.BookId);
            modelBuilder.Ignore(e => e.PriceRange);
            modelBuilder.HasOne(e => e.Publisher).WithMany(e => e.Books).HasForeignKey(e => e.Publisher_Id);
        }
    }
}
