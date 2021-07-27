using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class IndicatorConfiguration : IEntityTypeConfiguration<Indicators>
    {
        public void Configure(EntityTypeBuilder<Indicators> builder)
        {
           builder.HasKey(e => e.Id)
                    .HasName("PK__Indicato__4CDF25A20F44D467");

           builder.Property(e => e.Formula)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

           builder.Property(e => e.IndicatorDescription)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

           builder.Property(e => e.IndicatorName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

           builder.HasOne(d => d.Area)
                .WithMany(p => p.Indicators)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__Indicator__AreaI__3E52440B");

           builder.HasOne(d => d.IndicatorTemplate)
                .WithMany(p => p.Indicators)
                .HasForeignKey(d => d.IndicatorTemplateId)
                .HasConstraintName("FK__Indicator__Indic__3D5E1FD2");

           builder.HasOne(d => d.Periodicity)
                .WithMany(p => p.Indicators)
                .HasForeignKey(d => d.PeriodicityId)
                .HasConstraintName("FK__Indicator__Perio__3C69FB99");
        }
    }
}
            
