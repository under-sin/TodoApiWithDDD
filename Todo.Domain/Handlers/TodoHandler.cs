using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler :
    Notifiable,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkToAsUndoneCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Sua tarefa está errada", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.UpdateTitle(command.Title);

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if (command.Valid)
            return new GenericCommandResult(false, "Não foi possível alterar a tarefa", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsDone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso", todo);
    }

    public ICommandResult Handle(MarkToAsUndoneCommand command)
    {
        command.Validate();
        if (command.Valid)
            return new GenericCommandResult(false, "Não foi possível alterar a tarefa", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsUnDone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso", todo);
    }
}
