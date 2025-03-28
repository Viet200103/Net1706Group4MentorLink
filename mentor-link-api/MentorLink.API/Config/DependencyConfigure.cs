using MentorLink.Business.IServices;
using MentorLink.Business.Repositories;
using MentorLink.Business.Security;
using MentorLink.Business.Services;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;

namespace MentorLink.API.Config;

public static class DependencyConfigure
{

    public static void ConfigForServices(IServiceCollection services)
    {
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<INewsCategoryService, NewsCategoryService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITaskBoardService, TaskBoardService>();


        services.AddScoped<ITokenProvider, TokenProvider>();
    }

    public static void ConfigForRepositories(IServiceCollection services)
    {
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITaskBoardRepository, TaskBoardRepository>();
        services.AddScoped<ILecturerWorkSpaceRepository, LecturerWorkSpaceRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
    }
    
    
}