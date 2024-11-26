using Microsoft.EntityFrameworkCore;

namespace Todo.Api.Services;

public class DatabaseService : IDatabaseService
{
    private readonly ToDoDbContext _dbContext;

    public DatabaseService(ToDoDbContext dbContext)
        => _dbContext = dbContext;

    public async Task UpdateDatabase(CancellationToken cancellationToken = default)
        => await _dbContext.Database.MigrateAsync(cancellationToken);
}