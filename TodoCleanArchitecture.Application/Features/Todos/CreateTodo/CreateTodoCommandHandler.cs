using AutoMapper;
using MediatR;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand>
    {
        private ITodoRepository _todoRepository;
        private IMapper _mapper;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _todoRepository.AnyAsync(p => p.Work == request.Work);
            if (isExist)
            {
                throw new ArgumentException("This record alread exist");
            }
            Todo todo = _mapper.Map<Todo>(request);
            await _todoRepository.CreateAsync(todo, cancellationToken);
        }
    }
}
