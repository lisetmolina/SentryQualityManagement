using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Modules>
    {
        public void Configure(EntityTypeBuilder<Modules> builder)
        {
           builder.HasKey(e => e.Id)
                      .HasName("PK__Modules__2B7477A79F13C6D2");

           builder.Property(e => e.ModuleDescription)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

           builder.Property(e => e.ModuleName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}