using System;
using Microsoft.EntityFrameworkCore;
using piAssignment.Models;

namespace piAssignment.EntityModels
{
	public class piDbContext : DbContext
	{
		public piDbContext(DbContextOptions<piDbContext> options) : base(options)
        {
		}

		public DbSet<UserInfoModel> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
    }
}

