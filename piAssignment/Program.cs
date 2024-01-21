using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using piAssignment.EntityModels;
using piAssignment.Helper;
using piAssignment.Interface;
using piAssignment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<piDbContext>()
        .AddDefaultTokenProviders();

// IdentityServer4 configuration
builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>() // Replace with your actual identity class
    .AddInMemoryClients(Config.Clients)  // Configure clients, see step 3
    .AddInMemoryIdentityResources(Config.IdentityResources)  // Configure identity resources, see step 3
    .AddInMemoryApiResources(Config.ApiResources) // Configure API resources, see step 3
    .AddDeveloperSigningCredential(); // For development purposes only, use a real certificate in production

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext configuration
var connectionString = builder.Configuration.GetConnectionString("piAssignment");
builder.Services.AddDbContext<piDbContext>(options => options.UseSqlServer(connectionString));
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

