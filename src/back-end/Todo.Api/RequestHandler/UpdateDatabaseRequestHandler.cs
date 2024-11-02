using MediatR;
using Todo.Api.Requests;
using Todo.Api.Services;

namespace Todo.Api.RequestHandlers;

public class UpdateDatabaseRequestHandler : IRequestHandler<UpdateDatabaseRequest>
{
    private readonly IDatabaseService _dbService;

    public UpdateDatabaseRequestHandler(IDatabaseService dbService)
        => _dbService = dbService;
    
    public async Task Handle(UpdateDatabaseRequest request, CancellationToken cancellationToken)
        => await _dbService.UpdateDatabase();
}