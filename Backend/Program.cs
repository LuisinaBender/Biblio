using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

builder.Services.AddDbContext<Backend.DataContex.BiblioContext>(options =>
    options.UseMySql(cadenaConexion, 
    ServerVersion.AutoDetect(cadenaConexion)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
