namespace Ordering.Application.Exception;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key} was not found.")
    {
        
    }
}