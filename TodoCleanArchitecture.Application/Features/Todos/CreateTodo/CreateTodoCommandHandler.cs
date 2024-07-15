using AutoMapper;
using MediatR;
using TodoCleanArchitecture.Application.Services;
using TodoCleanArchitecture.Domain.Abstractions;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;

namespace TodoCleanArchitecture.Application.Features.Todos.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Result<string>>
    {
        private ITodoRepository _todoRepository;
        private IMapper _mapper;
        private ICacheService _cacheService;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper, ICacheService cacheService)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<Result<string>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _todoRepository.AnyAsync(p => p.Work == request.Work);
            if (isExist)
            {
                //throw new ArgumentException("This record alread exist");
                //throw new DublicateRecordWorkException();
                //return new Result<string>(500, "This record alread exist");
                return Result<string>.Fail(500, "This record alread exist");
            }
            Todo todo = _mapper.Map<Todo>(request);
            await _todoRepository.CreateAsync(todo, cancellationToken);
            _cacheService.Remove("todos");
            //return new Result<string>("Create is successful");
            //return Result<string>.Success("Create is successful");
            return "Create is successful";
        }
    }
}