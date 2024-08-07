using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
        .AllowAnyMethod();
                                                 
                          });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SqlDbContext>(
  options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("PetAdoptionDB")

        )
    ) ; 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
