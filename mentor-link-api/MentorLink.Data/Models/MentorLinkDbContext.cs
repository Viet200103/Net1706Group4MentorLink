using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MentorLink.Data.Models;

public partial class MentorLinkDbContext : DbContext
{
    public MentorLinkDbContext(DbContextOptions<MentorLinkDbContext> options) : base(options) { }

    public DbSet<News> News { get; set; }
    public DbSet<CapstoneWorkspace> CapstoneWorkspaces { get; set; }
    public DbSet<TaskBoard> TaskBoards { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=MentorLink;user=root;password=123456;",
                new MySqlServerVersion(new Version(8, 0, 37))); // Ensure your MySQL version is correct
        }
    }
}
