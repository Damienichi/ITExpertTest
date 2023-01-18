namespace ITExpertTest.Exceptions;

public class ErrorException: Exception
{
    public string? ErrorMessage { get; set; }
    public string? ErrorDescription { get; set; }
}