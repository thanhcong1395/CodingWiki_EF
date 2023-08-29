using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Author_Id);
            modelBuilder.Property(e => e.FirstName).HasMaxLength(50);
            modelBuilder.Property(e => e.FirstName).IsRequired();
            modelBuilder.Property(e => e.LastName).IsRequired();
            modelBuilder.Ignore(e => e.FullName);
        }
    }
}
