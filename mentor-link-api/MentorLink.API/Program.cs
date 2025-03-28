using MentorLink.API.Config;
using MentorLink.Business.Database;
using MentorLink.Business.Mapper;
using MentorLink.Business.Repositories;
using MentorLink.Business.Services;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


DatabaseConfigure.Configure(builder.Configuration, builder);
SecurityConfigure.ConfigureAuthJwt(builder.Configuration, builder.Services);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CommonMapperProfile));

DependencyConfigure.ConfigForServices(builder.Services);
DependencyConfigure.ConfigForRepositories(builder.Services);

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

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();