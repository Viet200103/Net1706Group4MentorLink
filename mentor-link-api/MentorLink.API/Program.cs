using AutoMapper;
using MentorLink.Business.Mapper;
using MentorLink.Business.Repositories;
using MentorLink.Business.Services;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add DB Context
builder.Services.AddDbContext<MentorLinkDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

//Add Mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

//Register Dependency Injection
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<INewsCategoryService, NewsCategoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

void ApplyMigration()
{
    using var scope = app.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<MentorLinkDbContext>();
    if (_db.Database.GetPendingMigrations().Any())
    {
        _db.Database.Migrate();
    }
}