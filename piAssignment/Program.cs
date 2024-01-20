using Microsoft.EntityFrameworkCore;
using piAssignment.EntityModels;
using piAssignment.Interface;
using piAssignment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext configuration
var connectionString = builder.Configuration.GetConnectionString("piAssignment");
builder.Services.AddDbContext<piDbContext>(options => options.UseSqlServer(connectionString));
//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContext<piDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
//}
//else
//{
//    builder.Services.AddDbContext<piDbContext>(options => options.UseSqlServer(connectionString));
//}
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.Run();

