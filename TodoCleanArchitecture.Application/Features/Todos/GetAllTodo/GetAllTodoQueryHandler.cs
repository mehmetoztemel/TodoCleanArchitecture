using MediatR;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.GetAllTodo
{
    // işlemin yapıldığı yer
    public sealed class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, List<Todo>>
    {
        private ITodoRepository _todoRepository;
        public GetAllTodoQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<List<Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var response = await _todoRepository.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
