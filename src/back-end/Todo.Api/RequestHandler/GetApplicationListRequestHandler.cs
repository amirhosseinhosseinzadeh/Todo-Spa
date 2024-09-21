using MediatR;
using Todo.Api.Dtos;
using Todo.Api.Requests;
using Todo.Api.Services;

namespace Todo.Api.RequestHandlers;

public class GetApplicationListRequestHandler : IRequestHandler<GetApplicationListRequest, List<ApplicationDto>>
{
    private readonly IToDoService _toDoService;

    public GetApplicationListRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<List<ApplicationDto>> Handle(GetApplicationListRequest request, CancellationToken cancellationToken)
        => await _toDoService.GetList(request.Input);

}