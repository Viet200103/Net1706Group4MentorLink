using System.Text.Json.Serialization;
using MentorLink.Business.IServices;
using MentorLink.Business.Mappers;
using MentorLink.Business.Services;
using MentorLink.Data.IRepository;
using MentorLink.Data.Models;
using MentorLink.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<ITaskBoardRepository, TaskBoardRepository>();
builder.Services.AddScoped<ILecturerWorkSpaceRepository, LecturerWorkSpaceRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITaskBoardService, TaskBoardService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();