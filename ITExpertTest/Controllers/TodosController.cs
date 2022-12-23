using ITExpertTest.Commands;
using ITExpertTest.Models.Dtos;
using ITExpertTest.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITExpertTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController: ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(ILogger<TodosController> logger, IMediator mediator): base(logger)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTodosList(CancellationToken cancellationToken)
        {
            LogEnter();
            var query = new GetTodoListQuery();
            var result = await _mediator.Send(query, cancellationToken);

            LogLeave(result);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoAddDto todo, CancellationToken cancellationToken)
        {
            LogEnter(todo);
            var command = new CreateTodoCommand(todo);
            var result = await _mediator.Send(command, cancellationToken);
            if (result != null)
            {
                LogLeave(result);
                return CreatedAtAction(nameof(CreateTodo), new { id = result.Id }, result);
            }
            
            LogLeave(result);
            return BadRequest();
        }
       
        [HttpGet]
        public async Task<IActionResult> GetTodoById(int id, CancellationToken cancellationToken)
        {
            LogEnter(id);
            var query = new GetTodoByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            
            LogLeave(result);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteTodoById(int id, CancellationToken cancellationToken)
        {
            LogEnter(id);
            var command = new DeleteTodoByIdCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            
            LogLeave(result);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateTodoTitle([FromBody] string newTitle, int id, CancellationToken cancellationToken)
        {
            LogEnter(newTitle);
            var command = new UpdateTodoTitleCommand(newTitle, id);
            var result = await _mediator.Send(command, cancellationToken);
            if (result != null)
            {
                LogLeave(result);
                return Ok(result);
            }
            
            LogLeave(result);
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentariesByTodoId(int id, CancellationToken cancellationToken)
        {
            LogEnter(id);
            var query = new GetCommentariesByTodoIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            
            LogLeave(result);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCommentaryToTodoById([FromBody] CommentaryAddDto commentary, CancellationToken cancellationToken)
        {
            LogEnter(commentary);
            var command = new AddCommentaryToTodoByIdCommand(commentary);
            var result = await _mediator.Send(command, cancellationToken);
            
            LogLeave(result);
            return Ok(result);
        }
    }
}


