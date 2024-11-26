namespace Todo.Api.RequestHandlers;

public class ToggleApplicationStatusRequestHandler : IRequestHandler<ToggleApplicationStatusRequest>
{

    IToDoService _toDoService;

    public ToggleApplicationStatusRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task Handle(ToggleApplicationStatusRequest request, CancellationToken cancellationToken = default)
        => await _toDoService.ToggleApplicationStatus(request.ApplicationId);
}
