using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class TransactionsModuleConfiguration : IEntityTypeConfiguration<TransactionsModules>
    {
        public void Configure(EntityTypeBuilder<TransactionsModules> builder)
        {
            builder.HasKey(e => e.Id)
                      .HasName("PK__Transact__E6113D70C8CE7511");

            builder.HasOne(d => d.Module)
                .WithMany(p => p.TransactionsModules)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Transacti__Modul__2B3F6F97");

            builder.HasOne(d => d.Transaction)
                .WithMany(p => p.TransactionsModules)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK__Transacti__Trans__2A4B4B5E");
        }
    }
}