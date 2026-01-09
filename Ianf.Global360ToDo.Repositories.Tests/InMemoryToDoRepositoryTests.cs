using Ianf.Global360ToDo.Domain;
using Ianf.Global360ToDo.Repositories.InMemory;
using Xunit.Sdk;

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

    [Fact]
    public async Task TestGetAllToDoItems()
    {
        // Assemble
        var newToDo1 = new NewToDo
        {
            Title = "Title 1",
            Contents = "Contents 1",
            Priority = Domain.Enums.Priority.High
        };
        var newToDo2 = new NewToDo
        {
            Title = "Title 2",
            Contents = "Contents 2",
            Priority = Domain.Enums.Priority.Medium
        };
        var newToDo3 = new NewToDo
        {
            Title = "Title 3",
            Contents = "Contents 3",
            Priority = Domain.Enums.Priority.Low
        };

        // Act
        await _sut.AddToDoItem(newToDo1);
        await _sut.AddToDoItem(newToDo2);
        await _sut.AddToDoItem(newToDo3);

        // Assert
        var todoList = await _sut.GetToDos();
        Assert.Equal(3, todoList.ToList().Count);
    }

    [Fact]
    public async Task TestRemoveToDoItem()
    {
        // Assemble
        var newToDo1 = new NewToDo
        {
            Title = "Title 1",
            Contents = "Contents 1",
            Priority = Domain.Enums.Priority.High
        };
        var newToDo2 = new NewToDo
        {
            Title = "Title 2",
            Contents = "Contents 2",
            Priority = Domain.Enums.Priority.Medium
        };
        var newToDo3 = new NewToDo
        {
            Title = "Title 3",
            Contents = "Contents 3",
            Priority = Domain.Enums.Priority.Low
        };
        await _sut.AddToDoItem(newToDo1);
        var newToDoId = await _sut.AddToDoItem(newToDo2);
        await _sut.AddToDoItem(newToDo3);

        // Act
        await _sut.RemoveToDoItem(newToDoId);

        // Assert
        var todoList = await _sut.GetToDos();
        Assert.Equal(2, todoList.ToList().Count);
    }

    [Fact]
    public async Task TestRemoveToDoWithNonExistentToDoId()
    {
        // Assemble

        // Act

        // Assert
    }
}
