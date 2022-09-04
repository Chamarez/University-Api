using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

const string CONNECTION_NAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION_NAME); 
builder.Services.AddDbContext<UniversityDBContext>(options=> options.UseSqlServer(connectionString));  

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
    
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

//Use cors

app.UseCors("CorsPolicy");

app.Run();
