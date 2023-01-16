using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository
    )
    {
        return repository.GetAll("undersin");
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "undersin";
        return (GenericCommandResult)handler.Handle(command);
    }


    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
    [FromServices] ITodoRepository repository
)
    {
        var user = "undersin";
        return repository.GetAllDone(user);
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices] ITodoRepository repository
    )
    {
        var user = "undersin";
        return repository.GetAllUndone(user);
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository
    )
    {
        var user = "undersin";
        return repository.GetByPeriod(
            user,
            DateTime.Now.Date,
            true
        );
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetInactiveForToday(
        [FromServices] ITodoRepository repository
    )
    {
        var user = "undersin";
        return repository.GetByPeriod(
            user,
            DateTime.Now.Date,
            false
        );
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
    {
        var user = "undersin";
        return repository.GetByPeriod(
            user,
            DateTime.Now.Date.AddDays(1),
            true
        );
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
    {
        var user = "undersin";
        return repository.GetByPeriod(
            user,
            DateTime.Now.Date.AddDays(1),
            false
        );
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
       [FromBody] UpdateTodoCommand command,
       [FromServices] TodoHandler handler
   )
    {
        command.User = "undersin";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "undersin";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
        [FromBody] MarkToAsUndoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "undersin";
        return (GenericCommandResult)handler.Handle(command);
    }
}
