using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    // padronizando o retorno e o tipo do handle
    ICommandResult Handle(T command);
}
