using Ianf.Global360ToDo.Domain;
using Ianf.Global360ToDo.Repositories.InMemory;

namespace Ianf.Global360ToDo.Repositories.Tests;

public class InMemoryToDoRepositoryTests
{
    private readonly InMemoryToDoRepository _sut = new();

    [Fact]
    public async Task TestAddNewToDoItem()
    {
        // Assemble
        var title = "Test ToDo Title";
        var contents = "Contents of todo item.";
        var priority = Domain.Enums.Priority.High;

        var newToDo = new NewToDo
        {
            Title = title,
            Contents = contents,
            Priority = priority
        };
        var todoList = await _sut.GetToDos();
        Assert.Empty(todoList.ToList());

        // Act
        await _sut.AddToDoItem(newToDo);

        // Assert
        todoList = await _sut.GetToDos();
        Assert.Single(todoList.ToList());
        var todo = todoList.ToList().First();
        Assert.Equal(1, todo.Id.Id);
        Assert.Equal(title, todo.Title);
        Assert.Equal(contents, todo.Contents);
        Assert.Equal(priority, todo.Priority);
    }
}
