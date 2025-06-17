public class DomainException: Exception
{
    public DomainException(string message, string field) : base(message)
    {
        Field = field;
    }
    
    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public string Field { get; set; } = string.Empty;
}