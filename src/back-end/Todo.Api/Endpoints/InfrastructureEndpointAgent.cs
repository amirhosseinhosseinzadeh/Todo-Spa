using Microsoft.AspNetCore.Mvc;
using Todo.Api.Infrastuctures.Endpoints;

namespace Todo.Api.Endpoints;

public class InfrastructureEndpointAgent : EndpointAgent
{
    public override void Register(WebApplication app)
    {
        app.MapPost(GetFullPattern("Updatedatabase"),
            async ([FromServices] IMediator mediator, CancellationToken cancelationToken) =>
        {
            await mediator.Send(new UpdateDatabaseRequest(), cancelationToken);
        })
        .AddEndpointFilter<MinimalApiResultFilter>();

        app.MapGet("dockertest", () =>
        {
            return new
            {
                result = "application is ready"
            };
        });
    }
}
