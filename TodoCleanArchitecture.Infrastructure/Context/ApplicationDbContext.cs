using Microsoft.EntityFrameworkCore;
using TodoCleanArchitecture.Domain.Abstractions;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    List<Todo> todoList = new List<Todo>();
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Faker faker = new Faker();
        //        Todo todo = new Todo()
        //        {
        //            Work = faker.Lorem.Word(),
        //            DeadLine = faker.Date.BetweenDateOnly(new DateOnly(2024, 07, 13), new DateOnly(2024, 12, 31))
        //        };
        //        todoList.Add(todo);
        //    }
        //    modelBuilder.Entity<Todo>().HasData(todoList);
        //    base.OnModelCreating(modelBuilder);
        //}


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
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
