using System.Reflection;
using Todo.Api.Infrastuctures.Endpoints;

namespace Todo.Api.Infrastuctures.Extensions;

public static class EndPointRegistrar
{
    public static void RegisterEndpointsByAgents(this WebApplication app, Assembly assembly)
    {
        var endpointAgents = assembly
            .GetTypes()
            .Where(x => x.BaseType is { } && x.BaseType == typeof(EndpointAgent))
            .ToList()
            .AsReadOnly();
        Register(endpointAgents, app);
    }

    static void RegisterEndpointsByAgents(this WebApplication app, Assembly[] assemblies)
    {
        var endpointAgents = assemblies
            .SelectMany(x => x
            .GetTypes()
            .Where(x => x.BaseType == typeof(EndpointAgent)))
            .ToList()
            .AsReadOnly();
        Register(endpointAgents, app);
    }

    static void Register(IReadOnlyList<Type> agentTypes, WebApplication app)
    {
        foreach (var agent in agentTypes)
        {
            var type = (EndpointAgent)agent.InvokeMember(agent.Name, BindingFlags.CreateInstance, null, null, null);
            type.Register(app);
        }
    }
}
