using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities;
using Shared.Infrastructure.Data.Configurations;

namespace Shared.Infrastructure.Data
{
    public sealed class SharedContext : DbContext
    {

        //public (DbContextOptions<SharedContext> options)
        //    : base(options)
        //{
        //}


        public DbContextOptions Options { get; }

        public SharedContext(DbContextOptions options) : base(options)
        {
            Options = options;
            ChangeTracker.AutoDetectChangesEnabled = false;
        } 

        public DbSet<EmpMaster> EmpMaster { get; set; }
        public DbSet<LookupTypes> LookupTypes { get; set; }
        public DbSet<Lookups> Lookups { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=10.0.1.1;database=Hr;user id=admin;password=Admin123#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(ModelBuilderConfigurationsHelper.OnModelCreating(modelBuilder));
        }
    }
}
