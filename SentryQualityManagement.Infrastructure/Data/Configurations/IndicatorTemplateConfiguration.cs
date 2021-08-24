using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class IndicatorTemplateConfiguration : IEntityTypeConfiguration<IndicatorsTemplate>
    {
        public void Configure(EntityTypeBuilder<IndicatorsTemplate> builder)
        {
            builder.HasKey(e => e.IndicatorTemplateId)
                      .HasName("PK__Indicato__AE06CCA6E8E4772D");

            builder.Property(e => e.ElementDate).HasColumnType("datetime");

            builder.Property(e => e.ElementName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


        }
    }
}
