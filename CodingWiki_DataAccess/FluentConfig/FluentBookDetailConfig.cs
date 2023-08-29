using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetail");
            modelBuilder.Property(e => e.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Property(e => e.NumberOfChapters).IsRequired();
            modelBuilder.HasKey(e => e.BookDetail_Id);
            modelBuilder.HasOne(e => e.Book).WithOne(e => e.BookDetail).HasForeignKey<Fluent_BookDetail>("Book_Id");
        }
    }
}
