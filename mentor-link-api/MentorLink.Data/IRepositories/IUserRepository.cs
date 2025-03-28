using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(string id);
}