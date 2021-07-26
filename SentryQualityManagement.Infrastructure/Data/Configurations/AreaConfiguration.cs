using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Areas>
    {
        public void Configure(EntityTypeBuilder<Areas> builder)
        {
            builder.HasKey(e => e.AreaId)
                    .HasName("PK__Areas__70B82048FBDFB870");

            builder.Property(e => e.AreaName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Areas)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Areas__UserId__35BCFE0A");
        }
    }
}