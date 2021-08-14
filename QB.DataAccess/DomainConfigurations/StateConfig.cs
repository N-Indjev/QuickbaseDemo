using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QB.Domain;

namespace QB.DataAccess.DomainConfigurations
{
    public class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("StateId");
            
            builder.Property(e => e.Name)
                .HasMaxLength(2000)
                .HasColumnName("StateName");

            builder.HasOne(e => e.Country)
                .WithMany(e => e!.States)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}