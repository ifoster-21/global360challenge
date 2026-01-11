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

        var newToDo = new NewToDo
        {
            Title = title,
            Contents = contents
        };
        var todoList = await _sut.GetToDoItems();
        Assert.Equal(4, todoList.ToList().Count);

        // Act
        await _sut.AddToDoItem(newToDo);

        // Assert
        todoList = await _sut.GetToDoItems();
        Assert.Equal(5, todoList.ToList().Count);
        var todo = todoList.ToList().Last();
        Assert.Equal(title, todo.Title);
        Assert.Equal(contents, todo.Contents);
    }

    [Fact]
    public async Task TestGetAllToDoItems()
    {
        // Assemble
        var newToDo1 = new NewToDo
        {
            Title = "Title 1",
            Contents = "Contents 1"
        };
        var newToDo2 = new NewToDo
        {
            Title = "Title 2",
            Contents = "Contents 2"
        };
        var newToDo3 = new NewToDo
        {
            Title = "Title 3",
            Contents = "Contents 3"
        };

        // Act
        await _sut.AddToDoItem(newToDo1);
        await _sut.AddToDoItem(newToDo2);
        await _sut.AddToDoItem(newToDo3);

        // Assert
        var todoList = await _sut.GetToDoItems();
        Assert.Equal(7, todoList.ToList().Count);
    }

    [Fact]
    public async Task TestRemoveToDoItem()
    {
        // Assemble
        var newToDo1 = new NewToDo
        {
            Title = "Title 1",
            Contents = "Contents 1"
        };
        var newToDo2 = new NewToDo
        {
            Title = "Title 2",
            Contents = "Contents 2"
        };
        var newToDo3 = new NewToDo
        {
            Title = "Title 3",
            Contents = "Contents 3"
        };
        await _sut.AddToDoItem(newToDo1);
        var newToDoId = await _sut.AddToDoItem(newToDo2);
        await _sut.AddToDoItem(newToDo3);

        // Act
        await _sut.RemoveToDoItem(newToDoId);

        // Assert
        var todoList = await _sut.GetToDoItems();
        Assert.Equal(6, todoList.ToList().Count);
    }

    [Fact]

    public async Task TestRemoveToDoWithNonExistentToDoId()
    {
        // Assemble
        var newToDo1 = new NewToDo
        {
            Title = "Title 1",
            Contents = "Contents 1"
        };
        var newToDo2 = new NewToDo
        {
            Title = "Title 2",
            Contents = "Contents 2"
        };
        var newToDo3 = new NewToDo
        {
            Title = "Title 3",
            Contents = "Contents 3"
        };
        await _sut.AddToDoItem(newToDo1);
        await _sut.AddToDoItem(newToDo2);
        await _sut.AddToDoItem(newToDo3);

        // Act
        var nonExistantToDoId = 42;
        var result = await _sut.RemoveToDoItem(nonExistantToDoId);
        Console.WriteLine(result);

        // Assert
        var todoList = await _sut.GetToDoItems();
        Assert.Equal(7, todoList.ToList().Count);
    }
}
