using Ianf.Global360ToDo.Repositories;
using Ianf.Global360ToDo.Repositories.InMemory;
using Ianf.Global360ToDo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
