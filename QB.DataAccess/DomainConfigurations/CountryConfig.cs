using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QB.Domain;

namespace QB.DataAccess.DomainConfigurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CountryId");
            
            builder.Property(e => e.Name)
                .HasMaxLength(2000)
                .HasColumnName("CountryName");
        }
    }
}