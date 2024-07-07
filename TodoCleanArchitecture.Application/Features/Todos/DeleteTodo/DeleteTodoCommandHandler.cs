using MediatR;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private ITodoRepository _todoRepository;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            Todo? todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);
            if (todo is null)
            {
                throw new ArgumentNullException("Todo cannot found");
            }
            await _todoRepository.DeleteAsync(todo, cancellationToken);
        }
    }
}
