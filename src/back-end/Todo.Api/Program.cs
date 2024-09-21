using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Dtos;
using Todo.Api.Dtos.Customqueires;
using Todo.Api.EfContext;
using Todo.Api.Requests;
using Todo.Api.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IToDoService, ToDoService>();
//using var srv = builder.Services.BuildServiceProvider(true);
builder.Services.AddDbContext<ToDoDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDbContext")));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseRouting();
app.MapPost("/api/TodoApplication/Getlist",
    async ([FromBody] BaseCustomQuery inputQury, [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new GetApplicationListRequest(inputQury));
});
app.MapPost("/api/TodoApplication/AddTodoApplication",
    async ([FromBody] ApplicationDto applicationDto, [FromServices] IMediator mediator) =>
{
    return await mediator.Send(new CreateApplicationRequest(applicationDto));
});
app.Run();
