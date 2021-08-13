using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentryQualityManagement.Core.Entities;

namespace SentryQualityManagement.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(e => e.UserId)
                      .HasName("PK__Users__1788CC4C403A2F25");

            builder.Property(e => e.Active).HasDefaultValueSql("((0))");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserPassword)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__32E0915F");

            builder.Property(e => e.RoleId)

              .HasMaxLength(50)
              .IsRequired();
              


        }
    }
}