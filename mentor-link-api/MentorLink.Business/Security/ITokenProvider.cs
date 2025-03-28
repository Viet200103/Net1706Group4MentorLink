using MentorLink.Data.Models;

namespace MentorLink.Business.Security;

public interface ITokenProvider
{
    string GenerateToken(User user, IEnumerable<string> roles);
}