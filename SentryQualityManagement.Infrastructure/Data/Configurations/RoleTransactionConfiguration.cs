using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class RoleTransactionConfiguration : IEntityTypeConfiguration<RoleTransactions>
    {
        public void Configure(EntityTypeBuilder<RoleTransactions> builder)
        {
           builder.HasKey(e => e.Id)
                       .HasName("PK__RoleTran__9360F7CE42928410");

           builder.HasOne(d => d.Role)
                .WithMany(p => p.RoleTransactions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RoleTrans__RoleI__2E1BDC42");

           builder.HasOne(d => d.TransactionModule)
                .WithMany(p => p.RoleTransactions)
                .HasForeignKey(d => d.TransactionModuleId)
                .HasConstraintName("FK__RoleTrans__Trans__2F10007B");
        }
    }
}