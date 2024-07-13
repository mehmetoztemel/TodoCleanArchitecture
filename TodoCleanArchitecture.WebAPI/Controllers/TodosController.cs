using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoCleanArchitecture.Application.Features.Todos.CreateTodo;
using TodoCleanArchitecture.Application.Features.Todos.DeleteTodo;
using TodoCleanArchitecture.Application.Features.Todos.GetAllTodo;
using TodoCleanArchitecture.Application.Features.Todos.UpdateTodo;

namespace TodoCleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            GetAllTodoQuery request = new GetAllTodoQuery();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            //var response = await _mediator.Send(request, cancellationToken);
            //if (!response.IsSuccessful)
            //{
            //    return BadRequest(response);
            //}
            //return Ok(response);
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            DeleteTodoCommand request = new DeleteTodoCommand(id);
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}