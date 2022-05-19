using AutoMapper;
using EducationalSystem.Extensions;
using EducationalSystem.Mapper;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services  = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connectionString = "server = 127.0.0.1; User = root; password = root; database = diploma";

services.AddDbContext(connectionString);
services.AddIdentityConfiguration();
services.AddIdentityServerConfiguration(connectionString);
services.RegisterDependencies();

services.AddAutoMapper(typeof(ApiToEntityProfile), typeof(EntityToViewModelProfile));

services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.InitializeDatabase();

app.Run();
