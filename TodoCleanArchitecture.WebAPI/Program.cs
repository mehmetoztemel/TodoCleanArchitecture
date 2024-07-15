using Bogus;
using Microsoft.Extensions.Options;
using TodoCleanArchitecture.Application;
using TodoCleanArchitecture.Domain.Entities;
using TodoCleanArchitecture.Domain.Repositories;
using TodoCleanArchitecture.Infrastructure;
using TodoCleanArchitecture.Infrastructure.Options;
using TodoCleanArchitecture.WebAPI.Middlewares;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));
var connectionStringOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<ConnectionStringOptions>>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(connectionStringOptions);

builder.Services.AddExceptionHandler<MyExceptionHandler>().AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<Applicati>();
//    context.Database.Migrate();
//}


app.MapGet("SeedData", async (ITodoRepository todoRepository) =>
{
    List<Todo> todoList = new List<Todo>();
    for (int i = 0; i < 1000; i++)
    {
        Faker faker = new Faker();
        Todo todo = new Todo()
        {
            Work = faker.Lorem.Word(),
            DeadLine = faker.Date.BetweenDateOnly(new DateOnly(2024, 07, 13), new DateOnly(2024, 12, 31))
        };
        await todoRepository.CreateAsync(todo);
    }
    return Results.Created();
});

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();