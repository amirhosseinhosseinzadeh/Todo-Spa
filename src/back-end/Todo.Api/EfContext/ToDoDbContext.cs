using Microsoft.EntityFrameworkCore;
using Todo.Api.Entities;

namespace Todo.Api.EfContext;

public class ToDoDbContext : DbContext
{
    public DbSet<Application> Applications { get; set; }
    
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options) { }
}
