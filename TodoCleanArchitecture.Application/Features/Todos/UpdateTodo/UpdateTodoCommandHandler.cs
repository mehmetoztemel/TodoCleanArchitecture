using AutoMapper;
using MediatR;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private ITodoRepository _todoRepository;
        private IMapper _mapper;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            Todo? todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);
            if (todo is null)
            {
                throw new ArgumentNullException("Todo cannot found");
            }

            //todo.Work = request.Work;
            //todo.DeadLine = request.DeadLine;
            //todo.IsCompleted = request.IsCompleted;

            _mapper.Map(todo, request);

            await _todoRepository.UpdateAsync(todo, cancellationToken);
        }
    }
}
