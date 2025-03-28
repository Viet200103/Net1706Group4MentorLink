using MentorLink.Business.Database;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.API.Config;

public static class DatabaseConfigure
{

    public static void Configure(IConfiguration configuration, WebApplicationBuilder builder)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        if (connectionString == null)
        {
            throw new InvalidOperationException("MentorLinkDb connection string not found");
        }
        
        builder.Services.AddDbContext<MentorLinkDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
}