using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Database;

public class MentorLinkDbContext(DbContextOptions<MentorLinkDbContext> options) : DbContext(options)
{
    public DbSet<News> News { get; set; }
    public DbSet<NewsCategory> NewsCategories { get; set; }
    public DbSet<CapstoneWorkspace> CapstoneWorkspaces { get; set; }
    public DbSet<TaskBoard> TaskBoards { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }
    public DbSet<User> Users { get; set; }
}