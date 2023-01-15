using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Study English", "Anderson Vieira", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

    public CreateHandlerTests() { }

    [TestMethod]
    public void DadoUmComandoInvalidoDeveInterromperAExecucao()
    {
        var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void DadoUmComandValidoDeveCriarATarefa()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}
