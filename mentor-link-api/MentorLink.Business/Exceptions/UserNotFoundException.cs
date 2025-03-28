using System.Security.Authentication;

namespace MentorLink.Business.Exceptions;

public class UserNotFoundException : AuthenticationException
{
    public UserNotFoundException()
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}