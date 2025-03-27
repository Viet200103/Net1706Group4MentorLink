using Microsoft.EntityFrameworkCore;

namespace MentorLink.Data.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<CapstoneWorkspace> CapstoneWorkspaces { get; set; }
    public DbSet<TaskBoard> TaskBoards { get; set; }
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