using MediatR;
using Todo.Api.Dtos;

namespace Todo.Api.Requests;

public record CreateApplicationRequest(
    ApplicationDto ApplicationDto
) : IRequest<ApplicationDto>;
