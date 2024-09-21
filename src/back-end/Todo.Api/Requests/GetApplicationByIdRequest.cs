using MediatR;
using Todo.Api.Dtos;

namespace Todo.Api.Requests;

public record GetApplicationByIdRequest(int ApplicationId) : IRequest<ApplicationDto>;
