using System.Security.Authentication;

namespace MentorLink.Business.Exceptions;

public class InvalidPasswordException : AuthenticationException
{
    public InvalidPasswordException()
    {
    }

    public InvalidPasswordException(string? message) : base(message)
    {
    }

    public InvalidPasswordException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}