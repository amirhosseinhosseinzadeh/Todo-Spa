namespace Todo.Api.Services;

public interface IDatabaseService
{
    Task UpdateDatabase(CancellationToken cancellationToken = default);
}