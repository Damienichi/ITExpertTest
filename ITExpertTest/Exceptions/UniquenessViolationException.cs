using Microsoft.EntityFrameworkCore;

namespace ITExpertTest.Exceptions;

public class UniquenessViolationException: DbUpdateException
{
    public UniquenessViolationException(string message) : base(message)
    {
    }
}