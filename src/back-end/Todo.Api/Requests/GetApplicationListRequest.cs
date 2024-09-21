using MediatR;
using Todo.Api.Dtos;
using Todo.Api.Dtos.Customqueires;

namespace Todo.Api.Requests;

public record GetApplicationListRequest(BaseCustomQuery Input) : IRequest<List<ApplicationDto>>;
