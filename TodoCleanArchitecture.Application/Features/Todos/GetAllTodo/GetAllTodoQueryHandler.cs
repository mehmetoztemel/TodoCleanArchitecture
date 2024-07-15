using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoCleanArchitecture.Application.Services;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.GetAllTodo
{
    // işlemin yapıldığı yer
    public sealed class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, List<Todo>>
    {
        private ITodoRepository _todoRepository;
        ICacheService _cacheService;
        public GetAllTodoQueryHandler(ITodoRepository todoRepository, ICacheService cacheService)
        {
            _todoRepository = todoRepository;
            _cacheService = cacheService;
        }
        public async Task<List<Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            _cacheService.TryGetValue("todos", out List<Todo>? todos);
            if (todos is null)
            {
                todos = await _todoRepository.GetAll().ToListAsync(cancellationToken);

                _cacheService.Set("todos", todos);
            }
            return todos;
        }
    }
}