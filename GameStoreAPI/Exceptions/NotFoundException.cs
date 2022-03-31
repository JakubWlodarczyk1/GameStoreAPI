namespace GameStore.API.Exceptions;

public class NotFoundException : Exception
{
    // CUSTOM EXCEPTIONS
    public NotFoundException(string message)
        : base(message) { }
 
    public NotFoundException(Exception inner, string message)
        : base(message, inner) { }
}