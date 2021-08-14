using Microsoft.EntityFrameworkCore;

namespace QB.DataAccess
{
    public sealed class QDbContext : DbContext
    {
        public QDbContext(DbContextOptions<QDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}