using Todo.Domain.Commands;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class UdateHandlerTests
{
    [TestMethod]
    public void DadoUmIdInvalidoDeveInterromperAExecucao()
    {
        var command = new UpdateTodoCommand(Guid.NewGuid(), "Tarefa teste", "Anderson");
        Assert.Fail();
    }

    [TestMethod]
    public void DadoUmIdValidoAtualizarTarefa()
    {
        Assert.Fail();
    }
}
