using Todo.Domain.Entities;
using Todo.Domain.Infra.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Title 1", "user1", DateTime.Now));
        _items.Add(new TodoItem("Title 2", "user1", DateTime.Now));
        _items.Add(new TodoItem("Title 3", "anderson", DateTime.Now));
        _items.Add(new TodoItem("Title 4", "anderson", DateTime.Now));
        _items.Add(new TodoItem("Title 5", "user1", DateTime.Now));
    }

    [TestMethod]
    public void DadaAConsultaDeveRetornarTarefasApenasDoUsuarioAnderson()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("anderson"));
        Assert.AreEqual(2, result.Count());
    }
}
