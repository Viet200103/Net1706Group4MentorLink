namespace MentorLink.Business.Exceptions;

public class ExistedEmailException : Exception
{
    public ExistedEmailException()
    {
    }

    public ExistedEmailException(string message) : base(message)
    {
    }

    public ExistedEmailException(string message, Exception inner) : base(message, inner)
    {
    }
}