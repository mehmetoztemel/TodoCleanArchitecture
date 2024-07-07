using Microsoft.EntityFrameworkCore;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=IDEAPAD; Database=TodoDB; User Id=sa; Password=sa.2016;MultipleActiveResultSets=True;TrustServerCertificate=true;");

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<TodoCleanArchitecture.Domain.Entities.BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
