using System;
using Microsoft.EntityFrameworkCore;
using piAssignment.Models;

namespace piAssignment.EntityModels
{
	public class piDbContext : DbContext
	{
        private readonly WebApplicationBuilder _builder;

        public piDbContext(DbContextOptions options) : base(options)
        {
        }

        public piDbContext(DbContextOptions<piDbContext> options, WebApplicationBuilder builder) : base(options)
        {
            _builder = builder;
        }

        public DbSet<UserInfoModel> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            if (!optionsBuilder.IsConfigured) // Check if options are not already configured
            {
                if (_builder.Environment.IsDevelopment())
                {
                    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                }
                else
                {
                    var connectionString = _builder.Configuration.GetConnectionString("piAssignment");
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }
        }
    }
}

