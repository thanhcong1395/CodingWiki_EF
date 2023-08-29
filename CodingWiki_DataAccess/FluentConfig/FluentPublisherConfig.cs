using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Publisher_Id);
            modelBuilder.Property(e => e.Name).IsRequired();
        }
    }
}
