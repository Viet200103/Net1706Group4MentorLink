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
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<LecturerWorkspace> LecturerWorkspaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LecturerWorkspace>()
            .HasKey(lw => new { lw.WorkspaceId, lw.LecturerId });

        modelBuilder.Entity<LecturerWorkspace>()
            .HasOne(lw => lw.CapstoneWorkspace)
            .WithMany(cw => cw.LecturerWorkspaces)
            .HasForeignKey(lw => lw.WorkspaceId);

        modelBuilder.Entity<LecturerWorkspace>()
            .HasOne(lw => lw.Lecturer)
            .WithMany(l => l.LecturerWorkspaces)
            .HasForeignKey(lw => lw.LecturerId);
    }
}