using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MentorLink.Data.Models;

public partial class MentorLinkDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public MentorLinkDbContext(DbContextOptions<MentorLinkDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    public DbSet<News> News { get; set; }
    public DbSet<NewsCategory> NewsCategories { get; set; }
    public DbSet<CapstoneWorkspace> CapstoneWorkspaces { get; set; }
    public DbSet<TaskBoard> TaskBoards { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }
    }
}