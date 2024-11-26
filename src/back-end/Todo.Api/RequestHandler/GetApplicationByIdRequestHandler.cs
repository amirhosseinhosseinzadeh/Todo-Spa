namespace Todo.Api.RequestHandlers;

public class GetApplicationByIdRequestHandler : IRequestHandler<GetApplicationByIdRequest, ApplicationDto>
{
    private readonly IToDoService _toDoService;
    public GetApplicationByIdRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<ApplicationDto> Handle(GetApplicationByIdRequest request, CancellationToken cancellationToken = default)
        => await _toDoService.GetById(request.ApplicationId, cancellationToken);
}