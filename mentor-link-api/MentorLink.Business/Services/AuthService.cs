using MentorLink.API.Security;
using MentorLink.Business.Dtos;
using MentorLink.Business.Exceptions;
using MentorLink.Business.Security;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace MentorLink.Business.Services;

public class AuthService(
    ITokenProvider tokenProvider,
    IUserRepository userRepository
) : IAuthService
{
    private readonly PasswordHasher<string> _passwordHasher = new();

    public async Task<AccessToken> Login(LoginRequestDTO loginRequestDTO)
    {
        User? user = await userRepository.GetUserByEmail(loginRequestDTO.Email);
        if (user == null)
        {
            throw new UserNotFoundException();
        }

        // var isUser = VerifyPassword(systemAccount, loginRequestDTO.Password);
        var isUser = user.Password == loginRequestDTO.Password;
        if (isUser)
        {
            // hard role code for test
            string token = tokenProvider.GenerateToken(user, ["administrator"]);
            return new AccessToken { Token = token };
        }

        throw new InvalidPasswordException("Verify password is incorrect");
    }

    private bool VerifyPassword(User user, string? password)
    {
        var email = user.Email!;
        var hashedPassword = user.Password!;

        if (password == null)
        {
            return false;
        }

        var result = _passwordHasher.VerifyHashedPassword(email, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}