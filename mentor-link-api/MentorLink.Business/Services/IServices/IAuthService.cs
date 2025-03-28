using MentorLink.API.Security;
using MentorLink.Business.Dtos;

namespace MentorLink.Business.Services.IServices;

public interface IAuthService
{
    Task<AccessToken> Login(LoginRequestDTO loginRequestDTO);
}