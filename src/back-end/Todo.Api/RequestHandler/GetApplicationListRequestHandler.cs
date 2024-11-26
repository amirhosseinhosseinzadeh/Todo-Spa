namespace Todo.Api.RequestHandlers;

public class GetApplicationListRequestHandler : IRequestHandler<GetApplicationListRequest, List<ApplicationDto>>
{
    private readonly IToDoService _toDoService;

    public GetApplicationListRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<List<ApplicationDto>> Handle(GetApplicationListRequest request, CancellationToken cancellationToken = default)
        => await _toDoService.GetList(request.Input);

}