using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult handle(CreateTodoCommand command)
    {
        // Fail fast validations
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Opa, sua tarefa está errada", command.Notifications);

        // Gerando o todo
        var todo = new TodoItem(command.Title, command.User, command.Date);

        // Salvar um todo no banco
        _repository.Create(todo);

        // Notificar o usuário
        return new GenericCommandResult(true, "Tarefa salva", todo);
    }
}
