namespace Todo.Api.RequestHandlers;

public class AddApplicationRequestHandler : IRequestHandler<CreateApplicationRequest, ApplicationDto>
{
    private readonly IToDoService _toDoService;

    public AddApplicationRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<ApplicationDto> Handle(CreateApplicationRequest request, CancellationToken cancellationToken = default)
        => await _toDoService.Create(request.ApplicationDto, cancellationToken);
}
