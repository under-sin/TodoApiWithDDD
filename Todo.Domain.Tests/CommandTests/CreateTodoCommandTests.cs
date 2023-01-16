using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new("Study English", "Anderson Vieira", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void DadoUmComandoInvalid()
    {
        Assert.AreEqual(_invalidCommand.Valid, false);
    }

    [TestMethod]
    public void DadoUmComandoValid()
    {
        Assert.AreEqual(_validCommand.Valid, true);
    }
}