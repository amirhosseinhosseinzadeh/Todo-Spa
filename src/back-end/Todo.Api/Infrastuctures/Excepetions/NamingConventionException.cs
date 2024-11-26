namespace Todo.Api.Infrastuctures.Excepetions;

public class NamingConventionException : Exception
{
    public NamingConventionException()
    { }

    public NamingConventionException(string message, Exception? innerException = null)
        : base(message, innerException)
    { }
}
