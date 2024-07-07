using MediatR;

namespace TodoCleanArchitecture.Application.Features.Todos.DeleteTodo
{
    public sealed record DeleteTodoCommand(Guid Id) : IRequest
    {
    }
}
