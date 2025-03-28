using MentorLink.Business.Database;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class UserRepository(MentorLinkDbContext dbContext): IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserById(string id)
    {
        return await dbContext.Users.SingleOrDefaultAsync(u => u.UserId == id);
    }
}