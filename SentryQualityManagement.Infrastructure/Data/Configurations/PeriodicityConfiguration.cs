using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class PeriodicityConfiguration : IEntityTypeConfiguration<Periodicities>
    {
        public void Configure(EntityTypeBuilder<Periodicities> builder)
        {
           builder.HasKey(e => e.Id)
                     .HasName("PK__Periodic__895C305DBC9624E6");

           builder.Property(e => e.PeriodicityName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
