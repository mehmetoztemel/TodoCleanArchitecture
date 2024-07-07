using AutoMapper;
using TodoCleanArchitecture.Application.Features.Todos.CreateTodo;
using TodoCleanArchitecture.Application.Features.Todos.UpdateTodo;
using TodoCleanArchitecture.Domain.Entities;

namespace TodoCleanArchitecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTodoCommand, Todo>().ReverseMap();
            CreateMap<UpdateTodoCommand, Todo>().ReverseMap();
        }
    }
}