using Microsoft.AspNetCore.Mvc;
using Todo.Api.Dtos.CustomQueries.TodoApplication;
using Todo.Api.Infrastuctures.Endpoints;

namespace Todo.Api.Endpoints;

public class TodoApplicationEndpointAgent : EndpointAgent
{
    public override void Register(WebApplication app)
    {
        app.MapPost(GetFullPattern("Getlist"),
            async ([FromBody] BaseCustomQuery inputQury, [FromServices] IMediator mediator, CancellationToken cancelationToken) =>
        {
            return await mediator.Send(new GetApplicationListRequest(inputQury), cancelationToken);
        })
            .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapPost(GetFullPattern("Add"),
            async ([FromBody] ApplicationDto applicationDto, [FromServices] IMediator mediator, CancellationToken cancelationToken) =>
        {
            return await mediator.Send(new CreateApplicationRequest(applicationDto), cancelationToken);
        })
            .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapGet(GetFullPattern("GetById"),
            async ([AsParameters] GetTodoApplicationByIdQuery query, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await mediator.Send(new GetApplicationByIdRequest(query.TodoApplicationId), cancellationToken);
        })
            .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapPut(GetFullPattern("ToggleStatus"),
            async ([AsParameters] GetTodoApplicationByIdQuery query, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(new ToggleApplicationStatusRequest(query.TodoApplicationId), cancellationToken);
        })
            .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapDelete(GetFullPattern("Delete"), async ([AsParameters] GetTodoApplicationByIdQuery query, [FromServices] IMediator mediator) =>
        {
            await mediator.Send(new DeleteApplicationRequest(query.TodoApplicationId));
        })
            .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapPut(GetFullPattern("Update"),
            async ([FromBody] ApplicationDto applicationDto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            return await mediator.Send(new UpdateTodoApplicationRequest(applicationDto), cancellationToken);
        })
            .AddEndpointFilter<MinimalApiResultFilter>();
    }
}
