using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasKey(e => e.Id)
                       .HasName("PK__Transact__55433A6B46B4AA4A");

            builder.Property(e => e.TransactionName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}