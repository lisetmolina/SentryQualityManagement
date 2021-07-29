using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class IndicatorResultConfiguration : IEntityTypeConfiguration<IndicatorsResults>
    {
        public void Configure(EntityTypeBuilder<IndicatorsResults> builder)
        {
           builder.HasKey(e => e.Id)
                   .HasName("PK__Indicato__73E2462D86107B0B");

           builder.Property(e => e.IndicatorResultDate).HasColumnType("datetime");

            builder.HasOne(d => d.Periodicity)
                 .WithMany(p => p.IndicatorsResults)
                 .HasForeignKey(d => d.PeriodicityId)
                 .HasConstraintName("FK__Indicator__Perio__412EB0B6");
        }
    }
}
