using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QB.Domain;

namespace QB.DataAccess.DomainConfigurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("CityId")
                .IsRequired();
            
            builder.Property(e => e.Name)
                .HasMaxLength(2000)
                .HasColumnName("CityName")
                .IsRequired();

            builder.HasOne(e => e.State)
                .WithMany(e => e!.Cities)
                .HasForeignKey(e => e.StateId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}