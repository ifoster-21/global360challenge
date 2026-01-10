using Ianf.Global360ToDo.Repositories;
using Ianf.Global360ToDo.Repositories.InMemory;
using Ianf.Global360ToDo.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IToDoRepository, InMemoryToDoRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var corsOriginUrl = "http://localhost:4200";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(corsOriginUrl)
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
