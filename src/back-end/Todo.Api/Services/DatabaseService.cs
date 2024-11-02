using Microsoft.EntityFrameworkCore;
using Todo.Api.EfContext;

namespace Todo.Api.Services;

public class DatabaseService : IDatabaseService
{
    private readonly ToDoDbContext _dbContext;

    public DatabaseService(ToDoDbContext dbContext)
        => _dbContext = dbContext;

    public async Task UpdateDatabase()
        => await _dbContext.Database.MigrateAsync();
}