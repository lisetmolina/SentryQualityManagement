using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class LogTransactionalConfiguration : IEntityTypeConfiguration<LogTransactionals>
    {
        public void Configure(EntityTypeBuilder<LogTransactionals> builder)
        {
            builder.HasKey(e => e.LogTransactionalId)
                        .HasName("PK__LogTrans__C3ADDD5A016F0153");

            builder.Property(e => e.LogTransactionalsDate).HasColumnType("date");

            builder.HasOne(d => d.TransactionModule)
                .WithMany(p => p.LogTransactionals)
                .HasForeignKey(d => d.TransactionModuleId)
                .HasConstraintName("FK__LogTransa__Trans__44FF419A");

            builder.HasOne(d => d.User)
                .WithMany(p => p.LogTransactionals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__LogTransa__UserI__440B1D61");
        }
    }
}
