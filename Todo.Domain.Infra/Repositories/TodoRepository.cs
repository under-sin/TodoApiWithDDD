using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context
            .Todos.AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Done);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context
            .Todos.AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Done);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context
            .Todos.AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Done);
    }

    public TodoItem GetById(Guid id, string user)
    {
        return _context.Todos.FirstOrDefault(TodoQueries.GetById(id, user));
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context
            .Todos.AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, done, date))
            .OrderBy(x => x.Done);
    }

    public void Update(TodoItem todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
