using MediatR;
using Todo.Api.Dtos;
using Todo.Api.Requests;
using Todo.Api.Services;

namespace Todo.Api.RequestHandlers;

public class GetApplicationByIdRequestHandler : IRequestHandler<GetApplicationByIdRequest, ApplicationDto>
{
    private readonly IToDoService _toDoService;
    public GetApplicationByIdRequestHandler(IToDoService toDoService)
        => _toDoService = toDoService;

    public async Task<ApplicationDto> Handle(GetApplicationByIdRequest request, CancellationToken cancellationToken)
        => await _toDoService.GetById(request.ApplicationId);
}