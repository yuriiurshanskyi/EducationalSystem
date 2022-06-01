using EducationalSystem.Extensions;
using EducationalSystem.Mapper;

var builder = WebApplication.CreateBuilder(args);

var services  = builder.Services;

services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

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
