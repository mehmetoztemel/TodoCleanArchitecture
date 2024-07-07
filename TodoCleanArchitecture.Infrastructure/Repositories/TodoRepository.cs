using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;
using TodoCleanArchitecture.Infrastructure.Context;

namespace TodoCleanArchitecture.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private ApplicationDbContext _dbContext;
        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AnyAsync(Expression<Func<Todo, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Todos.AnyAsync(expression, cancellationToken);
        }

        public async Task CreateAsync(Todo todo, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(todo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Todo todo, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(todo);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Todo> GetAll()
        {
            return _dbContext.Todos.AsQueryable();
        }

        public async Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Todos.ToListAsync(cancellationToken);
        }

        public async Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Todos.FindAsync(id, cancellationToken);
            //return await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Todo todo, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(todo);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}