using MediatR;

namespace Todo.Api.Requests;

public record ToggleApplicationStatusRequest(int ApplicationId) : IRequest;