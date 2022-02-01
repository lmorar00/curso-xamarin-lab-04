using Microsoft.EntityFrameworkCore;
using MobileApp.Models;
using System.IO;
using Xamarin.Essentials;

namespace MobileApp.Services
{
    public class BloggingDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingDBContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "blogs.db3");

            optionsBuilder.UseSqlite($"FileName={dbPath}");
        }
    }
}