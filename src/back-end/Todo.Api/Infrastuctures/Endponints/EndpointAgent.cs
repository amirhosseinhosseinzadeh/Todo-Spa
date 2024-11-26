namespace Todo.Api.Infrastuctures.Endpoints;

public abstract class EndpointAgent
{
    public abstract void Register(WebApplication app);

    public virtual string GetFullPattern(params string[] patterns)
    {
        return string.Format(PrePattern, patterns).Replace("//", "/");
    }

    public virtual string AgentEndpointFriendlyName
    {
        get
        {
            const string AgentFixedName = "EndpointAgent";
            var agentName = this.GetType().Name;
            if (!agentName.EndsWith(AgentFixedName))
                throw new NamingConventionException();
            var agentEndpointFriendlyName = agentName[..(agentName.Length - AgentFixedName.Length)];
            return agentEndpointFriendlyName;
        }
    }

    public virtual string PrePattern => $"/api/{AgentEndpointFriendlyName}/{{0}}";
}
