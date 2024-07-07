using MediatR;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Application.Features.Todos.GetAllTodo
{
    // Request classı
    public sealed record GetAllTodoQuery : IRequest<List<Todo>>
    {
    }

    //// bu zorunlu değil. Dönecek cevaba ait bit dto oluşturmak istersek o zaman ekliyoruz
    //public sealed record GetAllTodoQueryResponse
    //{
    //}
}
