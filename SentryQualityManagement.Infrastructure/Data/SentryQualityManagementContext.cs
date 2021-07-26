using Microsoft.EntityFrameworkCore;
using SentryQualityManagement.Core.Entities;
using System.Reflection;

namespace SentryQualityManagement.Infrastructure.Data
{
    public partial class SentryQualityManagementContext : DbContext
    {
        public SentryQualityManagementContext()
        {
        }

        public SentryQualityManagementContext(DbContextOptions<SentryQualityManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Indicators> Indicators { get; set; }
        public virtual DbSet<IndicatorsResults> IndicatorsResults { get; set; }
        public virtual DbSet<IndicatorsTemplate> IndicatorsTemplate { get; set; }
        public virtual DbSet<LogTransactionals> LogTransactionals { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<Periodicities> Periodicities { get; set; }
        public virtual DbSet<RoleTransactions> RoleTransactions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<TransactionsModules> TransactionsModules { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



    
    }
}
