using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Infrastuctures.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddTransient<IActionResultWrapperFactory, ActionRestltWrapperFactory>();
builder.Services.AddDbContext<DbContext,ToDoDbContext>(opt =>
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
app.RegisterEndpointsByAgents(Assembly.GetExecutingAssembly());

var production_env = Environment.GetEnvironmentVariable("PROD_TYPE") ?? "";
if (!string.IsNullOrWhiteSpace(production_env))
{
    switch (production_env)
    {
        case "docker":
            ConfigDockerUrls();
            break;
    }
}
app.Run();

void ConfigDockerUrls()
{
    var env_ports = builder.Configuration.GetSection("Environments:docker:port_numbers").Get<List<int>>()
        ?? throw new Exception();
    env_ports.ForEach(x =>
        {
            app.Urls.Add($"http://*:{x}");
        });
}
